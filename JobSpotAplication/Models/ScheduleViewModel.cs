using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static JobSpotAplication.Models.UserPreferences;

namespace JobSpotAplication.Models
{
    public class ScheduleViewModel
    {
		[Display(Name = "How often would you like to be emailed?")]
		public string EmailFrequency { get; set; }
		public List<SelectListItem> Frequency { get; set; }
        public int EmailDay { get; set; }
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
		public string Salary { get; set; }
		public List<SelectListItem> Salaries { get; set; }
		public ScheduleViewModel()
		{
			Commitments = Availability.AvailabilitySelectList;
			Salaries = SalaryRange.SalaryRangeSelectList;
			Classifications = Models.Classification.Classifcations;
			Frequency = UserPreferences.FrequencyList;
		}
	}
}
