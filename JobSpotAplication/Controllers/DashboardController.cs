using JobSpotAplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
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
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> JobSearch(string title, string location, string availability, string daterange, string startingPayRange, string endingPayRange, string salaryType = "annual")
		{
			Dictionary<string, string> searchParams = GetSeekUrl(title, location, availability, daterange, startingPayRange, endingPayRange, salaryType);
			string url = SeekWebScraperModel.BuildUrl(searchParams);
			ISeekWebScraper seekWebScraper = new SeekWebScraperModel(url, searchParams);
			List<JobEntryModel> seekJobs = await Task.Run(() => GetJobsBySearch(url, searchParams, seekWebScraper));
			ViewData["seekJobs"] = seekJobs;
			return View("Index", seekJobs);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		private List<JobEntryModel> GetJobsBySearch(string url, Dictionary<string, string> searchParams, ISeekWebScraper scraper)
		{
			 List<JobEntryModel> seekJobs = scraper.ScrapeMultipleJobs().Result;
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