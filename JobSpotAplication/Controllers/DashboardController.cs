using JobSpotAplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using WebScraper;
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

		public IActionResult JobSearch(string title, string location, string availability, string daterange, string startingPayRange, string endingPayRange, string salaryType)
		{
			ISeekWebScraper seekWebScraper = new SeekWebScraperModel();
			Dictionary<string, string> searchParams = new Dictionary<string, string>()
			{
				["title"] = title,
				["location"] = location,
				["availability"] = availability,
				["daterange"] = daterange,
				["startingPayRange"] = startingPayRange,
				["endingPayRange"] = endingPayRange,
				["salaryType"] = salaryType
			};
			ViewData["url"] = seekWebScraper.BuildUrl(searchParams);
			return View("Index");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
