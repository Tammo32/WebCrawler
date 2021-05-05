using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSpotAplication.Models
{
    public class JobSearchResults
    {
        [Key]
        public int resultID { get; set; }
        [ForeignKey("AspNetUser")]
        public string UserID { get; set; }
        public string ResultsDate { get; set; }

    }
}
