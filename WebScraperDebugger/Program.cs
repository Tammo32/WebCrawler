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
			searchParams.Add("title", "junior accountant");
			searchParams.Add("location", "melbourne");
			searchParams.Add("availability", "full-time");
			searchParams.Add("daterange", "1");
			searchParams.Add("startingPayRange", "30000");
			searchParams.Add("endingPayRange", "60000");

			var url = SeekWebScraperModel.BuildUrl(searchParams);
			IWebScraper seekScraper = new SeekWebScraperModel(url, searchParams);
			var watch = System.Diagnostics.Stopwatch.StartNew();
			List<JobEntryModel> seekJobs = seekScraper.ScrapeMultipleJobs();
			watch.Stop();
			var elapsedMs = watch.ElapsedMilliseconds;
			System.Console.WriteLine($"Elapsed ms: { elapsedMs }");
			System.Console.WriteLine($"Jobs returned: { seekJobs.Count }");
			Debug.Print($"Url: {url}\n\n");

			// Save jobs to database
			new SqlConnector().SaveMultipleJobEntries(seekJobs);

			Debug.Print($"\n\nNext-Page: { (seekScraper.NextPage != null ? seekScraper.NextPage : "No more Jobs") }\n");
		}
	}
}
