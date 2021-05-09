using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace JobSpotAplication.Models
{
	public enum SalaryEnum
	{
		NoPay = 0,
		ThirtyThousand = 30000,
		FourtyThousand = 40000,
		FiftyThousand = 50000,
		SixtyThousand = 60000,
		SeventyThousand = 70000,
		EightyThousand = 80000,
		NinetyThousand = 90000,
		OneHundredThousand = 100000,
		OneHundredTenThousand = 110000,
		OneHundredTwentyThousand = 120000,
		OneHundredFiftyThousand = 150000,
		TwoHundredThousand = 200000,
		MaxPay = 999999
	}
	public static class SalaryRange
	{
		[DisplayName("No Pay")]
		public static string NoPay { get { return SalaryEnum.NoPay.ToString(); } }
		[DisplayName("30k")]
		public static string ThirtyThousand { get { return SalaryEnum.ThirtyThousand.ToString(); } }
		[DisplayName("40k")]
		public static string FortyThousand { get { return SalaryEnum.FourtyThousand.ToString(); } }
		[DisplayName("50k")]
		public static string FiftyThousand { get { return SalaryEnum.FiftyThousand.ToString(); } }
		[DisplayName("60k")]
		public static string SixtyThousand { get { return SalaryEnum.SixtyThousand.ToString(); } }
		[DisplayName("70k")]
		public static string SeventyThousand { get { return SalaryEnum.SeventyThousand.ToString(); } }
		[DisplayName("80k")]
		public static string EightyThousand { get { return SalaryEnum.EightyThousand.ToString(); } }
		[DisplayName("90k")]
		public static string NinetyThousand { get { return SalaryEnum.NinetyThousand.ToString(); } }
		[DisplayName("100k")]
		public static string OneHundredThousand { get { return SalaryEnum.OneHundredThousand.ToString(); } }
		[DisplayName("110k")]
		public static string OneHundredTenThousand { get { return SalaryEnum.OneHundredTenThousand.ToString(); } }
		[DisplayName("120k")]
		public static string OneHundredTwentyThousand { get { return SalaryEnum.OneHundredTwentyThousand.ToString(); } }
		[DisplayName("150k")]
		public static string OneHundredFiftyThousand { get { return SalaryEnum.OneHundredFiftyThousand.ToString(); } }
		[DisplayName("200k")]
		public static string TwoHundredThousand { get { return SalaryEnum.TwoHundredThousand.ToString(); } }
		[DisplayName("200k+")]
		public static string MaxPay { get { return SalaryEnum.MaxPay.ToString(); } }
		public static List<string> SalaryRangeList { get; private set; } = new List<string>() 
		{ 
			NoPay, ThirtyThousand, FortyThousand, FiftyThousand, SixtyThousand, SeventyThousand, EightyThousand, 
			NinetyThousand, OneHundredThousand, OneHundredTenThousand, OneHundredTwentyThousand, 
			OneHundredFiftyThousand, TwoHundredThousand, MaxPay
		};

		public static List<SelectListItem> SalaryRangeSelectList { get; private set; } = new List<SelectListItem>()
		{
			new SelectListItem("No Pay", NoPay, true),
			new SelectListItem("$30,000", ThirtyThousand, false),
			new SelectListItem("$40,000", FortyThousand, false),
			new SelectListItem("$50,000", FiftyThousand, false),
			new SelectListItem("$60,000", SixtyThousand, false),
			new SelectListItem("$70,000", SeventyThousand, false),
			new SelectListItem("$80,000", EightyThousand, false),
			new SelectListItem("$90,000", NinetyThousand, false),
			new SelectListItem("$100,000", OneHundredThousand, false),
			new SelectListItem("$110,000", OneHundredThousand, false),
			new SelectListItem("$120,000", OneHundredTwentyThousand, false),
			new SelectListItem("$150,000", OneHundredFiftyThousand, false),
			new SelectListItem("$200,000", TwoHundredThousand, false),
			new SelectListItem("$200,000+", MaxPay, false),
		};

		/// <summary>
		/// Formats the string parameter for display
		/// </summary>
		/// <param name="str">SalaryRange property return value</param>
		/// <param name="n">Number of characters to remove from string</param>
		/// <returns>A formatted string</returns>
		public static string FormattedSalary(this string str, int n)
		{
			System.Text.StringBuilder result = new System.Text.StringBuilder();
			string strCopy = str;
			str.Substring(str.Length - n);
			result.Append(str);
			result.Append("k");
			if (strCopy.Equals(MaxPay)) result.Append("+");
			return result.ToString();
		}
	}
}
