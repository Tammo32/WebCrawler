using JobSpotAplication.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSpotAplication.Services
{
    public class EmailSchedule
    {
        private readonly JobSpotAplicationContext _context;

        public EmailSchedule()
        {
            var contextOptions = new DbContextOptionsBuilder<JobSpotAplicationContext>()
            .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-JobSpotAplication-910F077B-3B60-4872-A2EF-3946254C9CEF;Trusted_Connection=True;MultipleActiveResultSets=true")
            .Options;

            var context = new JobSpotAplicationContext(contextOptions);
            _context = context;
        }

        public void ScheduleEmail()
        {
            
        }


    }
}
