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
using System.Security.Claims;
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
		private readonly JobSpotAplicationContext _context;

		public DashboardController(ILogger<DashboardController> logger, UserManager<IdentityUser> userManager)
		{
			_logger = logger;
			_userManager = userManager;

			var contextOptions = new DbContextOptionsBuilder<JobSpotAplicationContext>()
		   .UseSqlServer(GlobalConfig.ConnectionString("DefaultConnection"))
		   .Options;

			var context = new JobSpotAplicationContext(contextOptions);
			_context = context;
		}

		public IActionResult Index()
		{
			return View(new JobSearch());
		}


		public IActionResult JobSearch()
		{
			return View(new JobSearch());
		}

		[HttpGet]
		public IActionResult ScheduleJobSearch()
		{
			ViewData["DisplayScheduleForm"] = true;
			
			return View("Index", new ScheduleViewModel());
		}

		[HttpPost]
		public IActionResult ScheduleJobSearch(string Keywords, string Location, string Commitment, string Salary)
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

			db.SaveJobSearchQuery(userId, seekUrl);
			db.SaveJobSearchQuery(userId, indeedUrl);

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

			ViewData["jobs"] = jobs;
			return View("Index", new JobSearch());
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