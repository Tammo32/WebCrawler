using System;
using System.Collections.Generic;
using WebScraper.DataAccess;
using WebScraper.Exceptions;

namespace WebScraper
{
	/*
	 * Some code used in this class was obtained from following along with a tutorial based on Creating a C# application from the following website.
	 * Credit goes to Tim Corey from iamtimcorey.com - 2021
	 * https://www.iamtimcorey.com/courses/443886/
	 */
	public static class GlobalConfig
	{
		public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

		public static void InitializeConnections(bool database)
		{
			if (database)
			{
				SqlConnector sql = new SqlConnector();
				Connections.Add(sql);
			}
		}

		public static string ConnectionString(string name)
		{
			try
			{
				//if (name == "DefaultConnection")
				//	return "Server=(localdb)\\mssqllocaldb;Database=aspnet-JobSpotAplication-910F077B-3B60-4872-A2EF-3946254C9CEF;Trusted_Connection=True;MultipleActiveResultSets=true";
				if (name == "DefaultConnection")
					return "Server=tcp:jobspot1.database.windows.net,1433;Database=coreDB;User ID=user1;Password=Password123;Encrypt=true;Connection Timeout=30;";
				//if (name == "JobSpotAplicationContextConnection")
				//	return "Server=(localdb)\\mssqllocaldb;Database=JobSpotAplication;Trusted_Connection=True;MultipleActiveResultSets=true";
			}
			catch (Exception e)
			{
				throw new ConnectionStringNotFoundException($"The connection string you requested does not exist.\n\n{e.Message}");
			}
			return "";
		}
	}
}
