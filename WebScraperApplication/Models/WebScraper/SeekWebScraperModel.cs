using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Models.WebScraper
{
	public class SeekWebScraperModel : IWebScraper
	{
		private string SeekUrl { get; set; }

		// TODO - Implement ScrapeSingleJob feature
		public JobEntryModel ScrapeSingleJob(string url)
		{
			throw new NotImplementedException();
		}

		// TODO - Implement Scrape MultipleJobs feature
		public List<JobEntryModel> ScrapeMultipleJobs(Dictionary<string, string> searchParams)
		{
			throw new NotImplementedException();
		}


		public string BuildUrl(Dictionary<string, string> searchParams)
		{
			if (searchParams.ContainsKey("title"))
			{
				var titleArray = searchParams["title"].Split(" ");
				var title = string.Join("-", titleArray);
				SeekUrl += $"{title}-jobs/";
			}

			if (searchParams.ContainsKey("location"))
			{
				var locationArray = searchParams["location"].Split(" ");
				var location = string.Join("-", locationArray);
				SeekUrl += $"in-{location}/";
			}

			if (searchParams.ContainsKey("availability"))
			{
				var availability = searchParams["availability"];
				SeekUrl += $"{availability}?";
			}

			if (searchParams.ContainsKey("daterange"))
			{
				var dateRange = searchParams["daterange"];
				SeekUrl += $"&daterange={dateRange}";
			}

			if (searchParams.ContainsKey("startingPayRange") && searchParams.ContainsKey("endingPayRange"))
			{
				var start = searchParams["startingPayRange"];
				var end = searchParams["endingPayRange"];

				SeekUrl += $"&salaryrange={start}-{end}";
			}

			return SeekUrl;
		}

		public SeekWebScraperModel()
		{
			SeekUrl = "https://seek.com.au/";
		}

	}
}
