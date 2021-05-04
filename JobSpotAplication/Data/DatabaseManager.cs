using JobSpotAplication.Utilities;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace JobSpotAplication.Data
{
	public class DatabaseManager
	{
		public static void CreateTables()
		{
			using var connection = GetConnection().CreateConnection();
			connection.Open();

			var command = connection.CreateCommand();
			command.CommandText = File.ReadAllText("../WebScraperApplication/Sql/CreateTables.sql");
			command.ExecuteNonQuery();
		}

		public static string GetConnection()
		{
			var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			return connectionString;
		}
	}
}
