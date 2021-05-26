using JobSpotAplication.Data;
using JobSpotAplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebScraper;
using static JobSpotAplication.Models.UserPreferences;


namespace JobSpotAplication.Services
{
    public class EmailSchedule
    {
        public EmailSchedule()
        {

        }

        public void ScheduleEmail()
        {
            
            var contextOptions = new DbContextOptionsBuilder<JobSpotAplicationContext>()
            .UseSqlServer(GlobalConfig.ConnectionString("DefaultConnection"))
            .Options;

            var context = new JobSpotAplicationContext(contextOptions);
           
            var emailFrequencies = Enum.GetValues(typeof(Frequency));


            try
            {
                //Loop throught the user defined email preference list 
                foreach (Frequency frequency in emailFrequencies)
                {

                    //For any preferences that match the current position in the emun
                    foreach (UserPreferences user in context.UserPreferences)
                    {
                        var userCount = UserCount(context, user, frequency);
                        if (user.EmailFrequency == frequency && userCount)
                        {
                            foreach (JobSearchResults results in context.jobSearchResults)
                            {
                                if (user.UserID == results.UserID && results.ResultsDate != null)
                                {
                                    var auth = new AuthMessageSenderOptions();
                                    var email = new EmailSender(auth);
                                    var userID = user.UserID;
                                    var emailUser = context.Users.FindAsync(userID);
                                    var address = emailUser.Result.Email;
                                    email.SendEmailAsync(address, "You have jobs to views", "Time to start applying!");
                                    context.Dispose();
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                context.Dispose();
                return;
            }    
        }

        private bool UserCount(JobSpotAplicationContext context, UserPreferences user, Frequency frequency)
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
                    context.SaveChangesAsync();
                    return true;
                }

                if (user.EmailFrequency == Frequency.Monthly && user.EmailDay == 30)
                {
                    user.EmailDay = 1;
                    context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }
    }
}
