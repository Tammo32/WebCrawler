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

		private void ScrapeSeekData(string searchUrl)
		{
			var web = new HtmlWeb();
			var doc = web.Load(searchUrl);
			var jobs = doc.DocumentNode.SelectNodes("//*[@class = '_1UfdD4q']");

			foreach (var job in jobs)
			{
				var details = job.SelectSingleNode(".//article");
				var title = HttpUtility.HtmlDecode(details.SelectSingleNode(".//a[@class = '_2S5REPk']").InnerText);
				Debug.Print($"Title: {title}\n");
			}
		}
	}
}
