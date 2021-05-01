using System;
using System.Collections.Generic;
using System.Web;
using HtmlAgilityPack;
using WebScraper.Models;

namespace WebScraper.WebScraper
{
	// TODO - Create unit tests for this class
	public class SeekWebScraperModel : IWebScraper, ISeekWebScraper
	{
		private string SeekUrl { get; set; }
		private List<JobEntryModel> _entries;

		// TODO - Finish implementing this feature
		public JobEntryModel ScrapeSingleJob(string searchurl)
		{
			var web = new HtmlWeb();
			var doc = web.Load(searchurl).DocumentNode.SelectSingleNode("//*[@id=\"app\"]/div/div[4]/div/div/div/div[1]/div/div");

			var title = HttpUtility.HtmlDecode
				(doc.SelectSingleNode("//*[@id=\"app\"]/div/div[4]/div/div/div/div[1]/div/div/div[1]/div/div[1]/div/div/div[1]/div/div/div/div[1]/div/div[1]/h1").InnerText);
			var company = HttpUtility.HtmlDecode
				(doc.SelectSingleNode("//*[@id=\"app\"]/div/div[4]/div/div/div/div[1]/div/div/div[1]/div/div[1]/div/div/div[1]/div/div/div/div[1]/div/div[2]/div/div/div/span/text()").InnerText);
			var type = HttpUtility.HtmlDecode
				(doc.SelectSingleNode("//*[@id=\"app\"]/div/div[4]/div/div/div/div[1]/div/div/div[1]/div/div[1]/div/div/div[1]/div/div/div/div[1]/div/div[3]/div/span[3]/div/div").InnerText);
			// TODO - grab and store description of job
			return new SeekJobEntryModel(title, company, type, "To be implemented");
		}

		// TODO - Check to see if this is enough information scraped, or if more is required
		public List<JobEntryModel> ScrapeMultipleJobs(string searchUrl, Dictionary<string, string> searchParams)
		{
			string title = "", company = "", description = "", url = "";
			var web = new HtmlWeb();
			var doc = web.Load(searchUrl);
			var jobs = doc.DocumentNode.SelectNodes(".//article");

			foreach (var job in jobs)
			{
				foreach (var node in job.SelectNodes(".//*[@data-automation]"))
				{
					if (node.GetAttributeValue("data-automation", "") == "jobTitle") {
						title = node.InnerText;
						url = node.GetAttributeValue("href", "");
					}
					if (node.GetAttributeValue("data-automation", "") == "jobCompany")
					{
						company = node.InnerText;
					}
				}
				description = HttpUtility.HtmlDecode(job.SelectSingleNode(".//span[@class = '_2OKR1ql']").InnerText);
				_entries.Add(new SeekJobEntryModel(title, company, description, $"https://seek.com.au/{url}")); 
			}
			return _entries;
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
				string availability;
				if (String.IsNullOrWhiteSpace(searchParams.GetValueOrDefault("availability", "")))
				{
					availability = "full-time";
				}
				else
				{
					availability = searchParams["availability"];
				}
				
				SeekUrl += $"{availability}?";
			}

			if (searchParams.ContainsKey("daterange"))
			{
				string dateRange;
				if (String.IsNullOrWhiteSpace(searchParams.GetValueOrDefault("daterange", "")))
				{
					dateRange = "full-time";
				}
				else
				{
					dateRange = searchParams["daterange"];
				}
				
				SeekUrl += $"daterange={dateRange}";
			}

			if (searchParams.ContainsKey("startingPayRange") && searchParams.ContainsKey("endingPayRange"))
			{
				string start, end;
				if (String.IsNullOrWhiteSpace(searchParams.GetValueOrDefault("daterange", "")))
				{
					start = "0";
					end = "999999";
				}
				else
				{
					start = searchParams["startingPayRange"];
					end = searchParams["endingPayRange"];
				}
				SeekUrl += $"&salaryrange={start}-{end}";
			}

			return SeekUrl;
		}

		public SeekWebScraperModel()
		{
			_entries = new List<JobEntryModel>();
			SeekUrl = "https://seek.com.au/";
		}

	}
}
