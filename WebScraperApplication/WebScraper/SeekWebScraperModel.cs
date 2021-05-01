using System;
using System.Collections.Generic;
using System.Web;
using HtmlAgilityPack;

namespace WebScraper.Models.WebScraper
{
	// TODO - Create unit tests for this class
	public class SeekWebScraperModel : IWebScraper
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
		public List<JobEntryModel> ScrapeMultipleJobs(Dictionary<string, string> searchParams)
		{
			var web = new HtmlWeb();
			var doc = web.Load(BuildUrl(searchParams));
			var list = doc.DocumentNode.SelectSingleNode("//*[@class = '_1UfdD4q']");
			var jobs = list.SelectNodes(".//article");
			foreach (var job in jobs)
			{
				var title = HttpUtility.HtmlDecode(job.SelectSingleNode(".//a[@class = '_2S5REPk']").InnerText);
				var url = HttpUtility.HtmlDecode(job.SelectSingleNode(".//a[@class = '_2S5REPk']").GetAttributeValue("href", ""));
				var company = HttpUtility.HtmlDecode(job.SelectSingleNode(".//a[@class = '_17sHMz8']").InnerText);
				var description = HttpUtility.HtmlDecode(job.SelectSingleNode(".//span[@class = '_2OKR1ql']").InnerText);
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
				var availability = searchParams["availability"];
				SeekUrl += $"{availability}?";
			}

			if (searchParams.ContainsKey("daterange"))
			{
				var dateRange = searchParams["daterange"];
				SeekUrl += $"daterange={dateRange}";
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
			_entries = new List<JobEntryModel>();
			SeekUrl = "https://seek.com.au/";
		}

	}
}
