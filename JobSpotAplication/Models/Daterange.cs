using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSpotAplication.Models
{
	public enum DaterangeEnum
	{
		PastDay = 1,
		Past3Days = 3,
		Past5Days = 5,
		PastWeek = 7
	}

	public static class Daterange
	{
		public static string PastDay { get { return DaterangeEnum.PastDay.ToString(); } }
		public static string Past3Days { get { return DaterangeEnum.Past3Days.ToString(); } }
		public static string Past5Days { get { return DaterangeEnum.Past5Days.ToString(); } }
		public static string PastWeek { get { return DaterangeEnum.PastWeek.ToString(); } }
		public static List<string> DaterangeList { get; private set; } = new List<string>()
		{ PastDay, Past3Days, Past5Days, PastWeek };
	}
}
