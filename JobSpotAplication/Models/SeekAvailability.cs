using System.Collections.Generic;
using System.ComponentModel;

namespace JobSpotAplication.Models
{
	public class SeekAvailability : IAvailability
	{
		public static string FullTime { get { return "full-time"; } }
		public static string PartTime { get { return "part-time"; } }
		public static string Contract { get { return "contract-temp"; } }
		public static string Casual { get { return "casual-vacation"; } }

		public static List<string> AvailabilityList { get; private set; } = new List<string>() 
		{ FullTime, PartTime, Contract, Casual };
	}
}
