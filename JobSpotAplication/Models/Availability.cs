using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace JobSpotAplication.Models
{
	public class Availability : IAvailability
	{
		[DisplayName("Full Time")]
		public static string FullTime { get { return "fulltime"; } }
		[DisplayName("Part Time")]
		public static string PartTime { get { return "parttime"; } }
		[DisplayName("Contract")]
		public static string Contract { get { return "contract"; } }
		[DisplayName("Casual")]
		public static string Casual { get { return "casual"; } }

		public static List<string> AvailabilityList { get; private set; } = new List<string>()
		{ FullTime, PartTime, Contract, Casual };

		public static List<SelectListItem> AvailabilitySelectList { get; } = new List<SelectListItem>
		{
			new SelectListItem("Full Time", FullTime, true),
			new SelectListItem("Part Time", PartTime, false),
			new SelectListItem("Contract", Contract, false),
			new SelectListItem("Casual", Casual, false),
		};
	}
}
