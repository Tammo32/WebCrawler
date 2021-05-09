using System;
using JobSpotAplication.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace JobSpotAplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DatabaseManager.CreateTables();
            DatabaseManager.InsertDummyData("DummyInserts_Craig.sql");

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 }//)
                // .ConfigureAppConfiguration((context, config) =>
                // {
                    // Build the current set of configuration to load values from
                    // JSON files and environment variables, including VaultName.
                  //  var builtConfig = config.Build();

                    // Use VaultName from the configuration to create the full vault URL.
                 //   var vaultName = builtConfig["jobspot"];
                 //    Uri vaultUri = new Uri($"https://jobspot.vault.azure.net/");

                    // Load all secrets from the vault into configuration. This will automatically
                    // authenticate to the vault using a managed identity. If a managed identity
                    // is not available, it will check if Visual Studio and/or the Azure CLI are
                    // installed locally and see if they are configured with credentials that can
                    // access the vault.
                   // config.AddAzureKeyVault(vaultUri, new Azure.Identity.DefaultAzureCredential());
                 );
    }
}