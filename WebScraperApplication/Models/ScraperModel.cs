using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
			string searchUrl = $"https:////seek.com.au/{ title }//in-{ location }";
			ScrapeSeekData(searchUrl);
		}

		private void ScrapeSeekData(string searchUrl)
		{
			var web = new HtmlWeb();

		}
	}
}
