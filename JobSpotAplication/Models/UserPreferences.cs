using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSpotAplication.Models
{
    public class UserPreferences
    {
        public enum Frequency
        {
            Everyday = 1,
            Weekly = 2,
            Monthly = 3
        }

        [Key]
        public int ID { get; set; }
        [ForeignKey("AspNetUsers")]
        public string UserID { get; set; }
        public Frequency EmailFrequency { get; set; }
    }
}
