using System;
using WebScraper.Models;

namespace WebScraperDebugger
{
	class Program
	{
		static void Main(string[] args)
		{
			ScraperModel scraper;

			string[] seachParameters = { "Web-Developer-jobs", "in-All-Melbourne-VIC" };
			scraper = new ScraperModel();
			scraper.ScrapeSeek(seachParameters);

			var details = scraper.ScrapeSeekForJobDetails("https://www.seek.com.au/job/52075142");
		}
	}
}
