using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobSpotAplication.Models
{
    public class Jobs
    {
        [Key]
        public string JobID { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        //public string Description { get; set; }
        public string Availability { get; set; }
        public string Url { get; set; }
        public string Salary { get; set; }
    }
}
