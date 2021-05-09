using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebScraper.Models;

namespace WebScraper.WebScraper
{
	public class IndeedWebScraperModel : IWebScraper
	{
		public string NextPage { get; set; }
		public string Url { get; set; }
		public string JobCount { get; set; }

		private readonly string _baseUrl;
		private readonly Dictionary<string, string> _searchParams;
		private List<JobEntryModel> _entries;

		// TODO - Complete method
		public List<JobEntryModel> ScrapeMultipleJobs()
		{
			//HtmlDocument doc = LoadHtmlDocument();
			//ScrapeJobs(doc);
			while (String.IsNullOrWhiteSpace(Url) == false)
			{
				HtmlDocument doc = LoadHtmlDocument();
				Url = GetNextPage(doc);
				NextPage = Url;
				ScrapeJobs(doc);
			}
			return _entries;
		}

		public JobEntryModel ScrapeSingleJob(string url)
		{
			var web = new HtmlWeb();
			var doc = web.Load(url).DocumentNode.SelectSingleNode("//*[@id=\"app\"]/div/div[4]/div/div/div/div[1]/div/div");
			var id = "0123456789";
			// /html/body/script[9]/text() (for title)
			// //*[@id="what"] (start with the double //)
			var title = HttpUtility.HtmlDecode
				(doc.SelectSingleNode("html/body/script[9]/text()").InnerText);
			//	//*[@id="pj_3829e1b664531317"]/div[1]/a/img
			var company = HttpUtility.HtmlDecode
				(doc.SelectSingleNode("//*[@id=\"pj_3829e1b664531317\"]/div[1]/a/img").InnerText);
			// //*[@id="filter-job-type"]/button/span (start with the double)	
			var type = HttpUtility.HtmlDecode
				(doc.SelectSingleNode("//*[@id=\"filter - job - type\"]/button/span").InnerText);
			// TODO - grab and store description of job
			return new IndeedJobEntryModel(id, title, company, type, "To be implemented");

		}

		private void ScrapeJobs(HtmlDocument doc)
		{
			string id = "", title = "", company = "", url = "", location = "", description = "", datePosted = "";
			string availability = _searchParams["availability"];
			string salary = "";
			JobCount = doc.DocumentNode.SelectSingleNode(".//div[@id = 'searchCountPages']").InnerText;
			IEnumerable<HtmlNode> jobs = doc.DocumentNode.Descendants(0).Where(n => n.HasClass("jobsearch-SerpJobCard"));

			foreach (HtmlNode node in jobs)
			{
				// Yet to figure out what the job id is on indeed
				HtmlNode remote, pay, date;
				var uri = node.SelectSingleNode(".//h2[@class = 'title']");
				title	= HttpUtility.HtmlDecode(uri.ChildNodes[1].InnerText);
				url		= HttpUtility.HtmlDecode(uri.ChildNodes[1].GetAttributeValue("href", ""));
				Guid guid = Guid.NewGuid();
				id = guid.ToString();

				company = HttpUtility.HtmlDecode(node.SelectSingleNode(".//span[@class = 'company']").InnerText);
				var locationNode = node.Descendants(0).Where(n => n.HasClass("location"));
				location = HttpUtility.HtmlDecode(locationNode.First().InnerText);
				if ((remote = node.SelectSingleNode(".//span[@class = 'remote']")) != null)
				{
					location += $" { HttpUtility.HtmlDecode(remote.InnerText) }";
				}
				if ((pay = node.SelectSingleNode(".//span[@class = 'salaryText']")) != null)
				{
					salary = HttpUtility.HtmlDecode(pay.InnerText);
				}

				if ((date = node.SelectSingleNode(".//span[@class = 'date']")) != null)
				{
					datePosted = HttpUtility.HtmlDecode(date.InnerText);
				}

				var summary = node.SelectSingleNode(".//div[@class = 'summary']");

				foreach (HtmlNode item in summary.SelectNodes(".//li"))
				{
					description += HttpUtility.HtmlDecode($"{ item.InnerText }") + "\n";
				}

				_entries.Add(new IndeedJobEntryModel(id, title, company, description, $"https://au.indeed.com{url}",
					availability, datePosted, salary));
				description = "";
			}
		}

		private HtmlDocument LoadHtmlDocument()
		{
			HtmlWeb web = new HtmlWeb();
			HtmlDocument doc = web.Load(Url);
			return doc;
		}

		private string GetNextPage(HtmlDocument doc)
		{
			string next = "";
			HtmlNodeCollection nodes;
			if ((nodes = doc.DocumentNode.SelectNodes(".//a[@aria-label]")) != null)
			{
				foreach (HtmlNode node in nodes)
				{
					if (node.GetAttributeValue("aria-label", "") == "Next")
					{
						next = _baseUrl + HttpUtility.HtmlDecode(node.GetAttributeValue("href", null));
					}
				}
			}
			return next;
		}

		private string GetRealUrl(HtmlDocument doc)
		{

			return "";
		}


		// TODO - Implement BuildUrl
		public static string BuildUrl(Dictionary<string, string> searchParams)
		{
			string url = "jobs?q=";
			string title = "", location = "", dateRange = "";
			if (searchParams.ContainsKey("title"))
			{
				var titleArray = searchParams["title"].Split(" ");
				title = string.Join("+", titleArray);
				url += $"{title}";
				if (searchParams.ContainsKey("startingPayRange"))
				{
					string salary;
					if (String.IsNullOrWhiteSpace(searchParams.GetValueOrDefault("startingPayRange", "")))
					{
						salary = $"+${ searchParams["startingPayRange"] }";
					}
				}
			}

			if (searchParams.ContainsKey("location"))
			{
				var locationArray = searchParams["location"].Split(" ");
				location = string.Join("+", locationArray);
				url += $"&l={location}&radius=25";
			}

			if (searchParams.ContainsKey("availability"))
			{
				string availability;
				if (String.IsNullOrWhiteSpace(searchParams.GetValueOrDefault("availability", "")))
				{
					availability = "fulltime";
				}
				else
				{
					availability = searchParams["availability"];
				}

				url += $"&jt={availability}";
			}

			if (searchParams.ContainsKey("daterange"))
			{
				if (String.IsNullOrWhiteSpace(searchParams.GetValueOrDefault("daterange", "")))
				{
					dateRange = "3";
				}
				else
				{
					dateRange = searchParams["daterange"];
				}

				url += $"&fromage={dateRange}";
			}

			return url;
		}

		public IndeedWebScraperModel(string url)
		{
			_baseUrl = "https://au.indeed.com/";
			_entries = new List<JobEntryModel>();
			Url = _baseUrl + url;
		}

		public IndeedWebScraperModel(string url, Dictionary<string, string> searchParams)
		{
			_baseUrl = "https://au.indeed.com/";
			_entries = new List<JobEntryModel>();
			Url = _baseUrl + url;
			_searchParams = searchParams;
		}
	}
}
