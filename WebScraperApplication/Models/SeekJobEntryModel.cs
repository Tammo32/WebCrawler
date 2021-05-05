using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Models
{
	public class SeekJobEntryModel : JobEntryModel
	{

		public SeekJobEntryModel(string id, string title, string company, string briefDescription, string url)
		{
			ID = id;
			Title = title;
			Company = company;
			BriefDescription = briefDescription;
			Url = url;
		}

		public SeekJobEntryModel(string id, string title, string company, string briefDescription, string url,
								string availability, string startingSalary, string endingSalary
			)
		{
			ID = id;
			Title = title;
			Company = company;
			BriefDescription = briefDescription;
			Url = url;
			Availability = availability;
			StartingSalary = startingSalary;
			EndingSalary = endingSalary;
		}
	}
}
