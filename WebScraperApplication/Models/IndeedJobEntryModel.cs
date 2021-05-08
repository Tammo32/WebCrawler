using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Models
{
	public class IndeedJobEntryModel : JobEntryModel
	{
		public string DatePosted { get; }

		public IndeedJobEntryModel(string id, string title, string company, string description, string url)
		{
			ID = id;
			Title = title;
			Company = company;
			Description = description;
			Url = url;
		}

		public IndeedJobEntryModel(string id, string title, string company, string description, string url,
								string availability, string datePosted, string salary)
		{
			ID = id;
			Title = title;
			Company = company;
			Description = description;
			Url = url;
			Availability = availability;
			DatePosted = datePosted;
			Salary = salary;
			StartingSalary = salary;
		}

		public override string JobDetails()
		{
			return $"{ Title }\n{ Company }\n{ Location }\n{ Availability }\n{ DatePosted }\n{ Salary }\n\n{ Description }\n";
		}

		public override string BriefJobDetails()
		{
			return $"{ Title }\n";
		}
	}
}
