using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace JobSpotAplication.Models
{
	public static class AvailabilityModel
	{
		[DisplayName("Full TIme")]
		public static string FullTime { get { return "full-time"; } }
		[DisplayName("Part Time")]
		public static string PartTime { get { return "part-time"; } }
		[DisplayName("Contract / Temp")]
		public static string Contract { get { return "contract-temp"; } }
		[DisplayName("Casual / Vacation")]
		public static string Casual { get { return "casual-vacation"; } }
		public static List<string> AvailabilityList { get; private set; } = new List<string>() 
		{ FullTime, PartTime, Contract, Casual };
	}
}
