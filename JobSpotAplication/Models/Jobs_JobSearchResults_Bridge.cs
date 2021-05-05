using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSpotAplication.Models
{
    public class Jobs_JobSearchResults_Bridge
    {
        [Key]
        public int BridgeID { get; set; }
        [ForeignKey("Jobs")]
        public string JobID { get; set; }
        public virtual Jobs Jobs { get; set; }
        [ForeignKey("AspNetUser")]
        public string UserID { get; set; }
   
    }
}
