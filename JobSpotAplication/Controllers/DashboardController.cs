using JobSpotAplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using WebScraper.DataAccess;
using WebScraper.Models;
using WebScraper.WebScraper;

namespace JobSpotAplication.Controllers
{
	[Authorize]
	public class DashboardController : Controller
	{
		private readonly ILogger<DashboardController> _logger;

		public DashboardController(ILogger<DashboardController> logger)
		{
			_logger = logger;
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
			return View("Index", new JobSearch());
		}

		[HttpPost]
		public IActionResult ScheduleJobSearch(string title, string location, string availability, string daterange, string startingPayRange, string endingPayRange, string salaryType = "annual")
		{
			// Setup our data dictionary and database
			Dictionary<string, string> searchParams = GetSeekUrl(title, location, availability, startingPayRange, endingPayRange, daterange, salaryType);
			SqlConnector db = new SqlConnector();

			// Build the url
			string seekUrl = SeekWebScraperModel.BuildUrl(searchParams);
			string indeedUrl = IndeedWebScraperModel.BuildUrl(searchParams);

			// Create our seek web scraper and scrape a list of jobs relevant to the passed in parameters
			IWebScraper seekWebScraper = new SeekWebScraperModel(seekUrl, searchParams);
			IWebScraper indeedWebScraper = new IndeedWebScraperModel(indeedUrl, searchParams);
			List<JobEntryModel> seekJobs = GetJobsBySearch(seekUrl, searchParams, seekWebScraper);
			List<JobEntryModel> indeedJobs = GetJobsBySearch(indeedUrl, searchParams, indeedWebScraper);


			// Save jobs to database if results returned
			if (seekJobs.Count > 0)
			{
				db.SaveMultipleJobEntries(seekJobs);
			}

			// Save jobs to database if results returned
			if (indeedJobs.Count > 0)
			{
				db.SaveMultipleJobEntries(indeedJobs);
			}


			ViewData["seekJobs"] = seekJobs;
			ViewData["indeedJobs"] = indeedJobs;
			ViewData["searchParams"] = searchParams;
			return View(new JobSearch());
		}

		[HttpPost]
		public async Task<IActionResult> JobSearch(string title, string location, string availability, string daterange, string startingPayRange, string endingPayRange, string salaryType = "annual")
		{
			// Setup our data dictionary and database
			Dictionary<string, string> searchParams = GetSeekUrl(title, location, availability, startingPayRange, endingPayRange, daterange, salaryType);
			SqlConnector db = new SqlConnector();

			// Build the url for Seek
			string url = SeekWebScraperModel.BuildUrl(searchParams);

			// Create our seek web scraper and scrape a list of jobs relevant to the passed in parameters
			ISeekWebScraper seekWebScraper = new SeekWebScraperModel(url, searchParams);
			List<JobEntryModel> seekJobs = await Task.Run(() => GetJobsBySearch(url, searchParams, seekWebScraper));

			// Save jobs to database if results returned
			if (seekJobs.Count > 0)
			{
				db.SaveMultipleJobEntries(seekJobs);
			}

			ViewData["seekJobs"] = seekJobs;
			ViewData["searchParams"] = searchParams;
			return View("Index", seekJobs);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		private List<JobEntryModel> GetJobsBySearch(string url, Dictionary<string, string> searchParams, IWebScraper scraper)
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