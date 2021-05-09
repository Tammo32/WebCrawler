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
            var emailFrequencys = Enum.GetValues(typeof(Frequency));

            //Loop throught the user defined email preference list 
            foreach (Frequency frequency in emailFrequencys)
            {
                //For any preferences that match the current position in the emun
                foreach (UserPreferences user in _context.UserPreferences)
                {
                    var userCount = UserCount(user);
                    if (user.EmailFrequency == frequency && userCount)
                    {
                        foreach (JobSearchResults results in _context.jobSearchResults)
                        {
                            if (user.UserID == results.UserID && results.ResultsDate != null)
                            {
                                var auth = new AuthMessageSenderOptions();
                                var email = new EmailSender(auth);
                                var ID = user.UserID;
                                var emailUser = _context.Users.FindAsync(ID);
                                var address = emailUser.Result.Email;
                                email.SendEmailAsync(address, "You have jobs to views", "Time to start applying!");
                                return;
                            } 
                        }
                    }
                }
            }
        }

        private bool UserCount(UserPreferences user)
        {
            if (user.EmailFrequency == Frequency.Everyday)
            {
                return true;
            }
            else
            {
                user.EmailFrequency++;
                if (user.EmailFrequency == Frequency.Weekly && user.EmailDay == 7)
                {
                    user.EmailDay = 1;
                    _context.SaveChangesAsync();
                    return true;
                }

                if (user.EmailFrequency == Frequency.Monthly && user.EmailDay == 30)
                {
                    user.EmailDay = 1;
                    _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }
    }
}
