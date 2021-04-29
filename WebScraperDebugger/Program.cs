using System.Collections.Generic;
using System.Diagnostics;
using WebScraper.Models;
using WebScraper.Models.WebScraper;

namespace WebScraperDebugger
{
	class Program
	{
		static void Main(string[] args)
		{
			IWebScraper seekScraper = new SeekWebScraperModel();
			Dictionary<string, string> searchParams = new Dictionary<string, string>();

			searchParams.Add("title", "web developer");
			searchParams.Add("location", "melbourne");
			searchParams.Add("availability", "part-time");
			searchParams.Add("daterange", "7");
			searchParams.Add("startingPayRange", "50000");
			searchParams.Add("endingPayRange", "80000");
			var url = seekScraper.BuildUrl(searchParams);

			Debug.Print($"Url: {url}");

			//ScraperModel scraper;
			//string[] seachParameters = { "Web-Developer-jobs", "in-All-Melbourne-VIC" };
			//scraper = new ScraperModel();
			//scraper.ScrapeSeek(seachParameters);

			//var details = scraper.ScrapeSeekForJobDetails("https://www.seek.com.au/job/52075142");


		}
	}
}
