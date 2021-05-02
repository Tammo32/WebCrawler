using System.Collections.Generic;
using WebScraper.Models;

namespace WebScraper.WebScraper
{
	public interface IWebScraper
	{

		public bool MultiplePages { get; set; }

		/// <summary>
		/// Scrapes job websites for jobs based on search parameters provided
		/// </summary>
		/// <param name="searchParams">Search parameters provided by end user</param>
		/// <returns>A list containing Job Entry Models</returns>
		List<JobEntryModel> ScrapeMultipleJobs();

		/// <summary>
		/// Scrapes data for a single job from provided url
		/// </summary>
		/// <param name="url">The url to scrape job data from</param>
		/// <returns>A single Job Entry Model</returns>
		JobEntryModel ScrapeSingleJob(string url);

		/// <summary>
		/// Builds a url based on search parameters passed in
		/// </summary>
		/// <param name="searchParams">Search parameters to combine into a url to scrape</param>
		/// <returns>The complete string of the url to scrape</returns>
		//string BuildUrl(Dictionary<string, string> searchParams);
	}
}
