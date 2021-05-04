using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Models
{
	public class SeekJobEntryModel : JobEntryModel
	{

		public SeekJobEntryModel(string title, string company, string description, string url)
		{
			Title = title;
			Company = company;
			Description = description;
			Url = url;
		}
	}
}
