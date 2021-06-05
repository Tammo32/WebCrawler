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

		public DashboardController()
		{

		}

		[HttpGet]
		public IActionResult Index()
		{
			return View(new JobSearch());
		}

		[HttpGet]
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
		public async Task<IActionResult> MyJobs(int? page = 1)
		{
			// Page the transactions, maximum of 10 per page.
			const int pageSize = 4;

			JobSpotAplicationContext DbContext = new JobSpotAplicationContext(new DbContextOptionsBuilder<JobSpotAplicationContext>()
		   .UseSqlServer(GlobalConfig.ConnectionString("DefaultConnection"))
		   .Options);
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			//Unable to nest the foreach loops, getting the error "context already exists". Work around was to create a 
			//list of the bridge data and then loop through that.
			List<BridgeData> bridgeList = new List<BridgeData>();

			var list = GetBridgeData(userId, DbContext, bridgeList);

			List<Jobs> jobList = null;
			jobList = new List<Jobs>();
			foreach (BridgeData bridgeListJob in list)
            {
				var jobResult = DbContext.Jobs.Where(x => x.JobID == bridgeListJob.JobID);
				var jobs = jobResult.FirstOrDefault();
				jobList.Add(jobs);		
			}

			DbContext.Dispose();
			var pagedList = await jobList.ToPagedListAsync((int)page, pageSize);

			//Make the account available to the view
			ViewData["MyJobs"] = true;
			return View("Index", pagedList);
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

			var jobSearchId = Guid.NewGuid().ToString();

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

		private List<BridgeData> GetBridgeData(string userId, JobSpotAplicationContext DbContext, List<BridgeData> bridgeList)
        {
			foreach (Jobs_JobSearchResults_Bridge bridgeJob in DbContext.Jobs_JobSearchResults_Bridge)
			{
				if (bridgeJob.UserID == userId)
				{
					var jobs = new BridgeData();
					jobs.JobID = bridgeJob.JobID;
					jobs.UserID = bridgeJob.UserID;
					bridgeList.Add(jobs);
				}
				if (bridgeList.Count == 50)
                {
					return bridgeList;
                }
			}
			return bridgeList;
        }
	}
}