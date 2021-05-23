using JobSpotAplication.Data;
using JobSpotAplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using X.PagedList;
using System.Security.Claims;
using System.Threading.Tasks;
using WebScraper;
using WebScraper.DataAccess;
using WebScraper.Models;
using WebScraper.WebScraper;

namespace JobSpotAplication.Controllers
{
	[Authorize]
	public class DashboardController : Controller
	{
		private readonly ILogger<DashboardController> _logger;
		private readonly UserManager<IdentityUser> _userManager;
		JobSpotAplicationContext DbContext = new JobSpotAplicationContext(new DbContextOptionsBuilder<JobSpotAplicationContext>()
		   .UseSqlServer(GlobalConfig.ConnectionString("DefaultConnection"))
		   .Options);
		private string jobSearchId = "bb077f00-be48-406b-87c9-9a0d3f0a57dd";

		public DashboardController(ILogger<DashboardController> logger, UserManager<IdentityUser> userManager)
		{
			_logger = logger;
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View(new JobSearch());
		}


		public IActionResult JobSearch()
		{
			ViewData["DisplaySearchForm"] = true;

			return View(new JobSearch());
		}

		[HttpGet]
		public IActionResult ScheduleJobSearch()
		{
			ViewData["DisplayScheduleForm"] = true;
			
			return View("Index", new ScheduleViewModel());
		}

		[HttpGet]
		public async Task<IActionResult> JobSearchResults(int? page = 1)
		{
			
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			//jobSearchId = DbContext.jobSearchResults.Find().ID.Where(DbContext.jobSearchResults.Find("bb077f00-be48-406b-87c9-9a0d3f0a57dd") == userId);
			// Page the transactions, maximum of 4 per page.
			const int pageSize = 10;

			var pagedList = new SqlConnector().GetJobsByJobSearchResults( "bb077f00-be48-406b-87c9-9a0d3f0a57dd" , userId).ToPagedListAsync((int)page, pageSize);

			//Make the account available to the view
			ViewBag.JobSearchResultsLayout = await DbContext.Jobs.FindAsync(userId);
			return View("Index", pagedList);

			//return View("Index", new JobSearchResults());
		}

		[HttpPost]
		public IActionResult ScheduleJobSearch(string Keywords, string Location, string Commitment, string Salary, string Frequency)
		{
			SqlConnector db = new SqlConnector();
			Dictionary<string, string> searchParams = new Dictionary<string, string>()
			{
				{ "title", Keywords },
				{ "location", Location },
				{ "availability", Commitment },
				{ "daterange", "3" },
				{ "startingPayRange", Salary },
				{ "endingPayRange", "999999" },
			};
			// Build the url
			string seekUrl = SeekWebScraperModel.BuildUrl(searchParams);
			string indeedUrl = IndeedWebScraperModel.BuildUrl(searchParams);

			// Grab UserID
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			jobSearchId = Guid.NewGuid().ToString();

			db.SaveJobSearchQuery(jobSearchId, userId, seekUrl);
			db.SaveJobSearchQuery(jobSearchId, userId, indeedUrl);

			db.SaveJobSearchQuery(jobSearchId, userId, seekUrl);
			db.SaveJobSearchQuery(jobSearchId, userId, indeedUrl);

			return View("Index", new JobSearch());
		}

		[HttpPost]
		public IActionResult JobSearch(string Keywords, string Location, string Commitment, string Salary)
		{
			SqlConnector db = new SqlConnector();
			Dictionary<string, string> searchParams = new Dictionary<string, string>()
			{
				{ "title", Keywords },
				{ "location", Location },
				{ "availability", Commitment },
				{ "daterange", "3" },
				{ "startingPayRange", Salary },
				{ "endingPayRange", "999999" },
			};
			// Build the url
			string seekUrl = SeekWebScraperModel.BuildUrl(searchParams);
			string indeedUrl = IndeedWebScraperModel.BuildUrl(searchParams);

			// Create our seek web scraper and scrape a list of jobs relevant to the passed in parameters
			IWebScraper seekWebScraper = new SeekWebScraperModel(seekUrl);
			IWebScraper indeedWebScraper = new IndeedWebScraperModel(indeedUrl);
			List<JobEntryModel> jobs = new List<JobEntryModel>();
			jobs.AddRange(GetJobsBySearch(seekUrl, seekWebScraper));
			jobs.AddRange(GetJobsBySearch(indeedUrl, indeedWebScraper));

			// Grab UserID
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			// Save jobs to database if results returned
			if (jobs.Count > 0)
			{
				db.SaveJobsTransaction(jobs, Guid.NewGuid().ToString(), userId, DateTime.UtcNow);
			}

			ViewData["DisplayJobSearchResults"] = true;
			return View("Index", jobs);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		private List<JobEntryModel> GetJobsBySearch(string url, IWebScraper scraper)
		{
			List<JobEntryModel> seekJobs = scraper.ScrapeMultipleJobs();
			return seekJobs;
		}

		private Dictionary<string, string> GetSeekUrl(string title, string location, string availability, string startingPayRange, string endingPayRange, string daterange = "7", string salaryType = "annual")
		{
			return new Dictionary<string, string>()
			{
				["title"] = title,
				["location"] = location,
				["availability"] = availability,
				["daterange"] = daterange,
				["startingPayRange"] = startingPayRange,
				["endingPayRange"] = endingPayRange,
				["salaryType"] = salaryType
			};
		}
	}
}