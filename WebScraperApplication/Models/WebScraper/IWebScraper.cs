﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Models.WebScraper
{
	public interface IWebScraper
	{
		/// <summary>
		/// Scrapes job websites for jobs based on search parameters provided
		/// </summary>
		/// <param name="searchParams">Search parameters provided by end user</param>
		/// <returns>A list containing Job Entry Models</returns>
		List<JobEntryModel> ScrapeMultipleJobs(Dictionary<string, string> searchParams);

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
		string BuildUrl(Dictionary<string, string> searchParams);
	}
}
