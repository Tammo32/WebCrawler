using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Web;

namespace WebScraper.Models
{
	public class ScraperModel
	{
		private ObservableCollection<JobEntryModel> _entries = new ObservableCollection<JobEntryModel>();

		public ObservableCollection<JobEntryModel> Entries
		{
			get { return _entries; }
			set { _entries = value; }
		}

		/// <summary>
		/// Scrapes seek.com.au for jobs
		/// </summary>
		/// <param name="searchDetails">Search criteria for jobs</param>
		public void ScrapeSeek(string[] searchDetails)
		{
			string title = searchDetails[0];
			string location = searchDetails[1];
			string searchUrl = $"https://seek.com.au/{ title }/{ location }";
			ScrapeSeekData(searchUrl);
		}

		/// <summary>
		/// Method scrapes data on large job listing from search criteria
		/// </summary>
		/// <param name="searchUrl">Search criteria for jobs</param>
		private void ScrapeSeekData(string searchUrl)
		{
			var web = new HtmlWeb();
			var doc = web.Load(searchUrl);
			var list = doc.DocumentNode.SelectSingleNode("//*[@class = '_1UfdD4q']");
			var jobs = list.SelectNodes(".//article");
			foreach (var job in jobs)
			{
				var title = HttpUtility.HtmlDecode(job.SelectSingleNode(".//a[@class = '_2S5REPk']").InnerText);
				var url = HttpUtility.HtmlDecode(job.SelectSingleNode(".//a[@class = '_2S5REPk']").GetAttributeValue("href", ""));
				var company = HttpUtility.HtmlDecode(job.SelectSingleNode(".//a[@class = '_17sHMz8']").InnerText);
				var description = HttpUtility.HtmlDecode(job.SelectSingleNode(".//span[@class = '_2OKR1ql']").InnerText);
				var nodes = job.SelectNodes(".//span[@class = '_2cFajGc']");

				Debug.Print($"{title}\n{company}\n{description}\nhttps://seek.com.au/{url}\n");
			}
		}

		// TODO - Scrape web page for all details about a job listing
		/// <summary>
		/// Method used to scrape seek for a full job listing
		/// </summary>
		/// <param name="url">Url that directs to a single job listing</param>
		private void ScrapeSeekForJobDetails(string url)
		{
			var web = new HtmlWeb();
			var doc = web.Load(url);
		}
	}
}
