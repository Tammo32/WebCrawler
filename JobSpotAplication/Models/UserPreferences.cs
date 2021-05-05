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
        [Key]
        public string ID { get; set; }
        [ForeignKey("AspNetUsers")]
        public string UserID { get; set; }
        public string EmailFrequency { get; set; }
    }
}
