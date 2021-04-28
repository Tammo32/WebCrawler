using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Models
{
	public class SeekJobEntryModel : JobEntryModel
	{

		public SeekJobEntryModel(string title, string company, string type, string description)
		{
			Title = title;
			Company = company;
			Description = description;
			Type = type;
		}
	}
}
