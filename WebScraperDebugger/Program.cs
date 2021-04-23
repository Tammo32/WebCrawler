using System;
using WebScraper.Models;

namespace WebScraperDebugger
{
	class Program
	{
		static void Main(string[] args)
		{
			ScraperModel scraper;

			string[] seachParameters = { "Web-Developer-jobs", "in-Melbourne" };
			scraper = new ScraperModel();
			scraper.ScrapeSeek(seachParameters);
		}
	}
}
