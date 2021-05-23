using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Models
{
	public class SeekJobEntryModel : JobEntryModel
	{

		public SeekJobEntryModel(string id, string title, string company, string description, string url)
		{
			ID = id;
			Title = title;
			Company = company;
			Description = description;
			Url = url;
		}

		public SeekJobEntryModel(string id, string title, string company, string description, string url,
								string availability, string startingSalary, string endingSalary
			)
		{
			ID = id;
			Title = title;
			Company = company;
			Description = description;
			Url = url;
			Availability = availability;
			StartingSalary = startingSalary;
			EndingSalary = endingSalary;
			Salary = startingSalary;
		}

		public override string BriefJobDetails()
		{
			return $"{ ID } - { Title }\n";
		}

		public override string JobDetails()
		{
			return $"{ Title } \t { Company }\n{ Location }\t{ Availability }\n{ StartingSalary } - { EndingSalary }\n{ Description }";
		}
	}
}
