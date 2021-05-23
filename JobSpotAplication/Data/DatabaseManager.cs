using JobSpotAplication.Utilities;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace JobSpotAplication.Data
{
	public class DatabaseManager
	{
		private static readonly string _filepath = "../WebScraperApplication/Sql/";

		public static void CreateTables()
		{
			using var connection = GetConnection().CreateConnection();
			connection.Open();

			var command = connection.CreateCommand();
			command.CommandText = File.ReadAllText($"{ _filepath }CreateTables.sql");
			command.ExecuteNonQuery();
		}

		public static void InsertDummyData(string filename)
		{
			using var connection = GetConnection().CreateConnection();
			connection.Open();

			var command = connection.CreateCommand();
			command.CommandText = File.ReadAllText(_filepath + filename);
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
