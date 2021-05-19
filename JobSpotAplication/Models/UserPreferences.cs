using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace JobSpotAplication.Models
{
    public enum Frequency
    {
        Everyday = 1,
        Weekly = 2,
        Monthly = 3
    }

    public class UserPreferences
    {
        [Key]
        public string ID { get; set; }
        [ForeignKey("AspNetUsers")]
        public string UserID { get; set; }
        public Frequency EmailFrequency { get; set; }
        public int EmailDay { get; set; }


        public static string Everyday { get { return Frequency.Everyday.ToString(); } }
        public static string Weekly { get { return Frequency.Weekly.ToString(); } }
        public static string Monthly { get { return Frequency.Monthly.ToString(); } }

        public static List<string> FrequencyRangeList { get; private set; } = new List<string>()
        {
        Everyday, Weekly, Monthly
        };

        public static List<SelectListItem> FrequencyList { get; private set; } = new List<SelectListItem>()
        {
            new SelectListItem("Daily", Everyday, true),
            new SelectListItem("Weekly", Weekly, false),
            new SelectListItem("Monthly", Monthly, false),
        };
    }
}
