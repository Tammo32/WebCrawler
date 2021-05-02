using System.Collections.Generic;
using System.Diagnostics;
using WebScraper.Models;
using WebScraper.WebScraper;

namespace WebScraperDebugger
{
	class Program
	{
		static void Main(string[] args)
		{
			
			Dictionary<string, string> searchParams = new Dictionary<string, string>();
			searchParams.Add("title", "web developer");
			searchParams.Add("location", "melbourne");
			searchParams.Add("availability", "full-time");
			searchParams.Add("daterange", "7");
			searchParams.Add("startingPayRange", "50000");
			searchParams.Add("endingPayRange", "80000");

			var url = SeekWebScraperModel.BuildUrl(searchParams);
			IWebScraper seekScraper = new SeekWebScraperModel(url, searchParams);
			var seekJobs = seekScraper.ScrapeMultipleJobs();
			Debug.Print($"Url: {url}\n\n");

			foreach (var job in seekJobs) 
			{
				Debug.Print($"{job.Title}\n{job.Company}\n{job.Description}\n{job.Url}\n\n");
			}
		}
	}
}
