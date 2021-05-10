using System.Collections.Generic;

namespace JobSpotAplication.Models
{
	public class Classification : IClassification
	{
		// TODO - Create property for List<SelectListItem> that does something similar to the list below.
		public static Dictionary<string, string> Classifcations { get; set; } = new Dictionary<string, string>()
		{
			{ "Accounting", "accounting" },
			{ "Administration &Aacute; Office Support", "administration-office" },
			{ "Advertising, Arts &Aacute; Media", "advertising-arts-media" },
			{ "Banking &Aacute; Financial Services", "banking-finance" },
			{ "Call Centre &Aacute; Customer Service", "callcentre-customerservice" },
			{ "CEO &Aacute; General Management", "ceo-management" },
			{ "Community Services &Aacute; Development", "community-services" },
			{ "Construction", "construction" },
			{ "Consulting &Aacute; Strategy", "consulting-strategy" },
			{ "Design &Aacute; Architecture", "design-architecture" },
		};
	}
}
