using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSpotAplication.Models
{
    public class UserJobSearchQueries
    {
        [Key]
        public string ID { get; set; }
        [ForeignKey("AspNetUser")]
        public string UserID { get; set; }
        private string Query { get; set; }
    }
}
