using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Models
{
	public abstract class JobEntryModel
	{
		public string Title { get; protected set; }
		public string Company { get; protected set; }
		public string Description { get; protected set; }
		public string Type { get; protected set; }
		public string Url { get; protected set; }
		public string SalaryRange { get; protected set; }
	}
}
