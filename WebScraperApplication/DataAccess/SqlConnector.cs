using Dapper;
using System;
using System.Collections.Generic;
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
		/// <param name="job">Job information</param>
		/// <returns>The Job Entry information, including a unique identifier</returns>
		public int SaveJobEntry(JobEntryModel job)
		{
			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("Local")))
			{
				var p = new DynamicParameters();
				p.Add("@JobID", job.ID);
				p.Add("@Title", job.Title);
				p.Add("@Company", job.Company);
				p.Add("@Description", job.Description);
				p.Add("@Availability", job.Availability);
				p.Add("@Url", job.Url);
				p.Add("@Salary", job.Salary);
				var result = connection.Execute("dbo.spJobs_Insert", p, commandType: CommandType.StoredProcedure);
				return result;
			}
		}

		/// <summary>
		/// Saves multiple job entries to the database
		/// </summary>
		/// <param name="jobs">A list of Job Entry Model that includes job entry information including a unique identifier</param>
		public void SaveMultipleJobEntries(List<JobEntryModel> jobs)
		{
			foreach (JobEntryModel job in jobs)
			{
				foreach (IDataConnection db in GlobalConfig.Connections)
				{
					var result = db.SaveJobEntry(job);
				}
			 }
		}
	}
}
