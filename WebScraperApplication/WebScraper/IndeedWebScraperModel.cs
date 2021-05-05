using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Models;

namespace WebScraper.WebScraper
{
	public class IndeedWebScraperModel : IIndeedWebScraper
	{
		public string NextPage { get; set; }
		public string Url { get; set; }

		private readonly string _baseUrl;
		private readonly Dictionary<string, string> _searchParams;
		private List<JobEntryModel> _entries;

		public Task<List<JobEntryModel>> ScrapeMultipleJobs()
		{
			throw new NotImplementedException();
		}

		public JobEntryModel ScrapeSingleJob(string url)
		{
			throw new NotImplementedException();
		}

		public static string BuildUrl(Dictionary<string, string> searchParams)
		{
			throw new NotImplementedException();
		}

		public IndeedWebScraperModel(string url)
		{
			_baseUrl = "https://seek.com.au/";
			_entries = new List<JobEntryModel>();
			Url = _baseUrl + url;
		}

		public IndeedWebScraperModel(string url, Dictionary<string, string> searchParams)
		{
			_baseUrl = "https://seek.com.au/";
			_entries = new List<JobEntryModel>();
			Url = _baseUrl + url;
			_searchParams = searchParams;
		}
	}
}
