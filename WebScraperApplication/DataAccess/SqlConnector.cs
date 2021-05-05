using Dapper;
using System.Data;
using WebScraper.Models;

namespace WebScraper.DataAccess
{
	/*
	 * Some code used in this class was obtained from following along with a tutorial based on Creating a C# application from the following website.
	 * Credit goes to Tim Corey from iamtimcorey.com - 2021
	 * https://www.iamtimcorey.com/courses/443886/
	 */
	public class SqlConnector : IDataConnection
	{
		/// <summary>
		/// Saves a Job Entry to the database
		/// </summary>
		/// <param name="model">Job information</param>
		/// <returns>The Job Entry information, including a unique identifier</returns>
		public JobEntryModel CreateJobEntry(JobEntryModel model)
		{
			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("Local")))
			{
				var p = new DynamicParameters();
				p.Add("@id", model.ID);
				p.Add("@Title", model.Title);
				p.Add("@BriefDescription", model.BriefDescription);
				p.Add("@Availability", model.Availability);
				p.Add("@Url", model.Url);
				p.Add("@Company", model.Company);
				p.Add("@StartingSalary", model.StartingSalary);
				p.Add("@EndingSalary", model.EndingSalary);
				connection.Execute("dbo.spJobs_BriefInsert", p, commandType: CommandType.StoredProcedure);
				return model;
			}
		}
	}
}
