using System;
using JobSpotAplication.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using WebScraper;

namespace JobSpotAplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DatabaseManager.CreateTables();

            // Initialize data connections and set connection to sql db
            GlobalConfig.InitializeConnections(true);

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
               
    }
}
