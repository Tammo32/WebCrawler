using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using WebScraper.Models;

namespace WebScraper.WebScraper
{
	public class SeekWebScraperModel : IWebScraper, ISeekWebScraper
	{
		public string NextPage { get; set; }
		public string Url { get; set; }

		private readonly string _baseUrl;
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

		public async Task<List<JobEntryModel>> ScrapeMultipleJobs()
		{
			while (String.IsNullOrWhiteSpace(Url) == false)
			{
				HtmlDocument doc = LoadHtmlDocument();
				Url = GetNextPage(doc);
				NextPage = Url;
				Console.WriteLine(NextPage);
				await Task.Run(() => ScrapeJobs(doc));
			}
			return _entries;
		}

		private HtmlDocument LoadHtmlDocument()
		{
			HtmlWeb web = new HtmlWeb();
			HtmlDocument doc = web.Load(Url);
			return doc;
		}

		private void ScrapeJobs(HtmlDocument doc)
		{
			string title = "", company = "", url = "";
			HtmlNodeCollection jobs = doc.DocumentNode.SelectNodes(".//article");

			foreach (HtmlNode job in jobs)
			{
				foreach (HtmlNode node in job.SelectNodes(".//*[@data-automation]"))
				{
					if (node.GetAttributeValue("data-automation", "") == "jobTitle")
					{
						title = node.InnerText;
						url = node.GetAttributeValue("href", "");
					}
					if (node.GetAttributeValue("data-automation", "") == "jobCompany")
					{
						company = node.InnerText;
					}
				}
				var description = HttpUtility.HtmlDecode(job.SelectSingleNode(".//span[@class = '_2OKR1ql']").InnerText);
				_entries.Add(new SeekJobEntryModel(title, company, description, $"https://seek.com.au/{url}"));
			}
		}

		private string GetNextPage(HtmlDocument doc)
		{
			string next = "";
			HtmlNodeCollection nodes;
			if ((nodes = doc.DocumentNode.SelectNodes(".//a[@data-automation]")) != null)
			{
				foreach (HtmlNode node in nodes)
				{
					if (node.GetAttributeValue("data-automation", "") == "page-next")
					{
						next = _baseUrl + HttpUtility.HtmlDecode(node.GetAttributeValue("href", null));
					}
				}
			}
			return next;
		}


		public static string BuildUrl(Dictionary<string, string> searchParams)
		{
			string url = "";
			if (searchParams.ContainsKey("title"))
			{
				var titleArray = searchParams["title"].Split(" ");
				var title = string.Join("-", titleArray);
				url += $"{title}-jobs/";
			}

			if (searchParams.ContainsKey("location"))
			{
				var locationArray = searchParams["location"].Split(" ");
				var location = string.Join("-", locationArray);
				url += $"in-{location}/";
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

				url += $"{availability}?";
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

				url += $"daterange={dateRange}";
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
				url += $"&salaryrange={start}-{end}";
			}

			return url;
		}

		public SeekWebScraperModel(string url)
		{
			_baseUrl = "https://seek.com.au/";
			_entries = new List<JobEntryModel>();
			Url = _baseUrl + url;
		}
	}
}
