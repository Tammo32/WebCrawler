using Hangfire.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSpotAplication.Services
{
    public class AuthFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var _context = context.GetHttpContext();

            if(_context.User.Identity.Name == "admin@admin")
            {
                return _context.User.Identity.IsAuthenticated;           
            }
            // Allow all authenticated users to see the Dashboard (potentially dangerous).
            return false;
        }
    }
}
