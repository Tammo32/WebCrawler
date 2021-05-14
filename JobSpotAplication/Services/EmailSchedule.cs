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
            .UseSqlServer("Server=tcp:jobspot1.database.windows.net,1433;Database=coreDB;User ID=user1;Password=Password123;Encrypt=true;Connection Timeout=30;")
            .Options;

            var context = new JobSpotAplicationContext(contextOptions);
            _context = context;
        }

        public void ScheduleEmail()
        {
            var emailFrequencies = Enum.GetValues(typeof(Frequency));

            //Loop throught the user defined email preference list 
            foreach (Frequency frequency in emailFrequencies)
            {
                //For any preferences that match the current position in the emun
                foreach (UserPreferences user in _context.UserPreferences)
                {
                    var userCount = UserCount(user, frequency);
                    if (user.EmailFrequency == frequency && userCount)
                    {
                        foreach (JobSearchResults results in _context.jobSearchResults)
                        {
                            if (user.UserID == results.UserID && results.ResultsDate != null)
                            {
                                var auth = new AuthMessageSenderOptions();
                                var email = new EmailSender(auth);
                                var userID = user.UserID;
                                var emailUser = _context.Users.FindAsync(userID);
                                var address = emailUser.Result.Email;
                                email.SendEmailAsync(address, "You have jobs to views", "Time to start applying!");
                                return;
                            } 
                        }
                    }
                }
            }
        }

        private bool UserCount(UserPreferences user, Frequency frequency)
        {
            if (user.EmailFrequency == frequency)
            {
                return true;
            }
            else
            {
                user.EmailDay++;
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
