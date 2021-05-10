using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobSpotAplication.Models
{
	public class JobSearch
	{
		[Required]
		[RegularExpression(@"^[a-zA-Z0-9 ]+$")]
		public string Keywords { get; set; }

		[Display(Name = "Classification")]
		public string Classification { get; set; }

		public Dictionary<string, string> Classifications { get; set; }

		[Required]
		public string Location { get; set; }

		[Display(Name = "Commitment")]
		public string Commitment { get; set; }

		public List<SelectListItem> Commitments { get; set; }

		[Display(Name = "Salary")]
		[Range((double)SalaryEnum.NoPay, (double)SalaryEnum.MaxPay)]
		public string Salary { get; set; }

		public List<SelectListItem> Salaries { get; set; }

		public JobSearch()
		{
			Commitments = Availability.AvailabilitySelectList;
			Salaries = SalaryRange.SalaryRangeSelectList;
			Classifications = Models.Classification.Classifcations;
		}
	}
}
