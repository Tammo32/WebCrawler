using System;
using System.Collections.Generic;
using System.Diagnostics;
using WebScraper;
using WebScraper.DataAccess;
using WebScraper.Models;
using WebScraper.WebScraper;

namespace WebScraperDebugger
{
	/*
	 * Some code used in this class was obtained from following along with a tutorial based on Creating a C# application from the following website.
	 * Credit goes to Tim Corey from iamtimcorey.com - 2021
	 * https://www.iamtimcorey.com/courses/443886/
	 */
	class Program
	{
		static void Main(string[] args)
		{
			GlobalConfig.InitializeConnections(true);
			Dictionary<string, string> searchParams = new Dictionary<string, string>();
			searchParams.Add("title", "web developer");
			searchParams.Add("location", "melbourne");
			searchParams.Add("availability", "full-time");
			searchParams.Add("daterange", "7");
			searchParams.Add("startingPayRange", "30000");
			searchParams.Add("endingPayRange", "60000");

			ScrapeIndeed(searchParams);
			ScrapeSeek(searchParams);
		}

		private static void ScrapeSeek(Dictionary<string, string> searchParams)
		{
			var url = SeekWebScraperModel.BuildUrl(searchParams);
			IWebScraper seekScraper = new SeekWebScraperModel(url, searchParams);
			var watch = System.Diagnostics.Stopwatch.StartNew();
			List<JobEntryModel> seekJobs = seekScraper.ScrapeMultipleJobs();
			watch.Stop();
			var elapsedMs = watch.ElapsedMilliseconds;
			System.Console.WriteLine($"Elapsed ms: { elapsedMs }");
			System.Console.WriteLine($"Jobs returned: { seekJobs.Count }");
			Debug.Print($"Url: {url}\n\n");

			foreach (var job in seekJobs)
			{
				Console.WriteLine($"{ job.JobDetails() }");
			}

			// Save jobs to database
			var db = new SqlConnector();
			db.SaveJobsTransaction(seekJobs, Guid.NewGuid().ToString(), "2ca67394-19dd-4cd6-9056-ad957d93346f", DateTime.UtcNow);

			Debug.Print($"\n\nNext-Page: { (seekScraper.NextPage != null ? seekScraper.NextPage : "No more Jobs") }\n");
		}

		private static void ScrapeIndeed(Dictionary<string, string> searchParams)
		{
			var url = IndeedWebScraperModel.BuildUrl(searchParams);
			IWebScraper indeedScraper = new IndeedWebScraperModel(url, searchParams);
			List<JobEntryModel> indeedJobs = indeedScraper.ScrapeMultipleJobs();
			var counter = 1;
			

			foreach (var job in indeedJobs)
			{
				Console.WriteLine($"{ counter++ } - { job.BriefJobDetails() }");
			}
			Debug.Print($"Url: {url}\n\n");
			Debug.Print(indeedJobs.Count.ToString());
			Debug.Print($"{ indeedScraper.JobCount }");

			// Save jobs to database
			var db = new SqlConnector();
			db.SaveJobsTransaction(indeedJobs, Guid.NewGuid().ToString(), "2ca67394-19dd-4cd6-9056-ad957d93346f", DateTime.UtcNow);
		}
	}
}
