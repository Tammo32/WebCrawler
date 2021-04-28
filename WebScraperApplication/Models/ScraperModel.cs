using HtmlAgilityPack;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
			Debug.Print("Search for multiple jobs\n\n");
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
		public JobEntryModel ScrapeSeekForJobDetails(string url)
		{
			
			var web = new HtmlWeb();
			var doc = web.Load(url).DocumentNode.SelectSingleNode("//*[@id=\"app\"]/div/div[4]/div/div/div/div[1]/div/div");

			var title = HttpUtility.HtmlDecode
				(doc.SelectSingleNode("//*[@id=\"app\"]/div/div[4]/div/div/div/div[1]/div/div/div[1]/div/div[1]/div/div/div[1]/div/div/div/div[1]/div/div[1]/h1").InnerText);
			var company = HttpUtility.HtmlDecode
				(doc.SelectSingleNode("//*[@id=\"app\"]/div/div[4]/div/div/div/div[1]/div/div/div[1]/div/div[1]/div/div/div[1]/div/div/div/div[1]/div/div[2]/div/div/div/span/text()").InnerText);
			var type = HttpUtility.HtmlDecode
				(doc.SelectSingleNode("//*[@id=\"app\"]/div/div[4]/div/div/div/div[1]/div/div/div[1]/div/div[1]/div/div/div[1]/div/div/div/div[1]/div/div[3]/div/span[3]/div/div").InnerText);
			// TODO - grab and store description of job
			var details = new SeekJobEntryModel(title, company, type, "To be implemented");
			Debug.Print("Details of single job searched\n\n");
			Debug.Print($"Title: {details.Title}\nCompany: {details.Company}\nType: {details.Type}\nDescription: {details.Description}");
			return details;
		}
	}
}
