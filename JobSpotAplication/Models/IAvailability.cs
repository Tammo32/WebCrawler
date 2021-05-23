using System.Collections.Generic;
using System.ComponentModel;

namespace JobSpotAplication.Models
{
	public interface IAvailability
	{
		[DisplayName("Full Time")]
		public static string FullTime { get; }
		[DisplayName("Part Time")]
		public static string PartTime { get; }
		[DisplayName("Contract")]
		public static string Contract { get; }
		[DisplayName("Casual")]
		public static string Casual { get; }
		public static List<string> AvailabilityList { get; set; }
	}
}
