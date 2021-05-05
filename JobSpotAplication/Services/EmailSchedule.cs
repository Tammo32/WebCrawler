using JobSpotAplication.Data;
using JobSpotAplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static JobSpotAplication.Models.UserPreferences;

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
            foreach (UserPreferences user in _context.UserPreferences)
            {
                if (user.EmailFrequency == Frequency.Everyday)
                {
                    foreach (JobSearchResults results in _context.jobSearchResults)
                    {
                        if (results.ResultsDate != null)
                        {
                            var auth = new AuthMessageSenderOptions();
                            var email = new EmailSender(auth);
                            var ID = user.UserID;
                            var emailUser = _context.Users.FindAsync(ID);
                            var address = emailUser.Result.Email;
                            email.SendEmailAsync(address, "You have jobs to views", "Time to start applying!");
                        }
                    }
                }
            }
        }
    }
}
