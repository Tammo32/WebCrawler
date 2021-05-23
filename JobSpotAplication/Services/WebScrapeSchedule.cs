using JobSpotAplication.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraper;

namespace JobSpotAplication.Services
{

    public class WebScrapeSchedule
    {
        private readonly JobSpotAplicationContext _context;
        public WebScrapeSchedule()
        {
            var contextOptions = new DbContextOptionsBuilder<JobSpotAplicationContext>()
           .UseSqlServer(GlobalConfig.ConnectionString("DefaultConnection"))
           .Options;

            var context = new JobSpotAplicationContext(contextOptions);
            _context = context;
        }
        public void ScheduleScrape()
        {
            Console.WriteLine();
        }
    }
}
