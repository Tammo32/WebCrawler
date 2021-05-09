using System.Collections.Generic;
using System.ComponentModel;

namespace JobSpotAplication.Models
{
	public class IndeedAvailability : IAvailability
	{
		public static string FullTime { get { return "fulltime"; } }
		public static string PartTime { get { return "parttime"; } }
		public static string Contract { get { return "contract"; } }
		public static string Casual { get { return "casual"; } }

		public static List<string> AvailabilityList { get; private set; } = new List<string>() 
		{ FullTime, PartTime, Contract, Casual };
	}
}
