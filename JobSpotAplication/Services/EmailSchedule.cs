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
        private readonly ApplicationDbContext _context;

        public EmailSchedule(ApplicationDbContext context)
        {
            _context = context;
        }

        public void ScheduleEmail()
        {
            
        }


    }
}
