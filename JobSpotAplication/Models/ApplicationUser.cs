using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSpotAplication.Models
{
    public class ApplicationUser : IdentityUser
    {
        public EmailPreferences EmailNotificationPreferences { get; set; }
    }
}
