using System;
using System.ComponentModel.DataAnnotations;

namespace JobSpotAplication.Models
{
	public class JobSearch
	{
		[Required]
		[RegularExpression(@"^[a-zA-Z0-9 ]+$")]
		public string Keywords { get; set; }
		public string Classification { get; set; }
		[Required]
		public string Location { get; set; }
		public string Commitment { get; set; }
		[Range((double)SalaryEnum.NoPay, (double)SalaryEnum.MaxPay)]
		public string Salary { get; set; }
	}
}
