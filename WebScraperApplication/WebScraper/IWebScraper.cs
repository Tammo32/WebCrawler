using System.Collections.Generic;
using System.Threading.Tasks;
using WebScraper.Models;

namespace WebScraper.WebScraper
{
	public interface IWebScraper
	{
		public string NextPage { get; set; }

		/// <summary>
		/// Scrapes job websites for jobs based on search parameters provided
		/// </summary>
		/// <param name="searchParams">Search parameters provided by end user</param>
		/// <returns>A list containing Job Entry Models</returns>
		Task<List<JobEntryModel>> ScrapeMultipleJobs();

		/// <summary>
		/// Scrapes data for a single job from provided url
		/// </summary>
		/// <param name="url">The url to scrape job data from</param>
		/// <returns>A single Job Entry Model</returns>
		JobEntryModel ScrapeSingleJob(string url);

		/// <summary>
		/// Checks to see if the job search returned multiple pages of job listings
		/// </summary>
		/// <returns>true or false depending on whether there are multiple pages of jobs</returns>
		//bool CheckForMultiplePages();

		/// <summary>
		/// Builds a url based on search parameters passed in
		/// </summary>
		/// <param name="searchParams">Search parameters to combine into a url to scrape</param>
		/// <returns>The complete string of the url to scrape</returns>
		//string BuildUrl(Dictionary<string, string> searchParams);
	}
}
