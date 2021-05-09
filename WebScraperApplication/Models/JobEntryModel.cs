using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WebScraper.Models
{
	public abstract class JobEntryModel
	{
		public string ID { get; protected set; }
		public string Title { get; protected set; }
		public string Location { get; protected set; }
		public string Company { get; protected set; }
		[DisplayName("Description")]
		public string BriefDescription { get; protected set; }
		public string Description { get; protected set; }
		public string Availability { get; protected set; }
		public string Url { get; protected set; }
		public string StartingSalary { get; protected set; }
		public string EndingSalary { get; protected set; }
	}
}
