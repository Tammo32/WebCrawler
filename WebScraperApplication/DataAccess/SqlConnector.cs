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

		public void SaveJobSearchResult(string userID, DateTime resultsDate)
		{
			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("Local")))
			{
				var p = new DynamicParameters();
				p.Add("@ID", Guid.NewGuid().ToString());
				p.Add("@UserID", userID);
				p.Add("@ResultsDate", resultsDate);
				var result = connection.Execute("dbo.spJobSearchResults_Insert", p, commandType: CommandType.StoredProcedure);
			}
		}

		public void SaveJobsTransaction(List<JobEntryModel> jobs, string searchResultsId, string userID, DateTime resultsDate)
		{
			List<DynamicParameters> parameters = SetDynamicParametersForSaveJobsTransaction(jobs);

			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("DefaultConnection")))
			{
				connection.Open();
				using (var trans = connection.BeginTransaction())
				{
					var result = connection.Execute("dbo.spJobs_Insert", parameters, transaction: trans, commandType: CommandType.StoredProcedure);

					try
					{
						DynamicParameters p = new DynamicParameters();
						p.Add("@ID", searchResultsId);
						p.Add("@UserID", userID);
						p.Add("@ResultsDate", resultsDate);
						connection.Execute("dbo.spJobSearchResults_Insert", p, transaction: trans, commandType: CommandType.StoredProcedure);
						trans.Commit();
					}
					catch (Exception e)
					{
						Console.WriteLine($"Error: { e.Message }");
						trans.Rollback();
					}
					connection.Close();
				}
			}
		}

		public void SaveJobSearchQuery(string userId, string queryUrl)
		{
			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("Local")))
			{
				var p = new DynamicParameters();
				p.Add("@ID", Guid.NewGuid().ToString());
				p.Add("@UserID", userId);
				p.Add("@QueryUrl", queryUrl);
				var result = connection.Execute("dbo.spUserJobSearchQueries_Insert", p, commandType: CommandType.StoredProcedure);
			}
		}

		private static List<DynamicParameters> SetDynamicParametersForSaveJobsTransaction(List<JobEntryModel> jobs)
		{
			List<DynamicParameters> parameters = new List<DynamicParameters>();

			foreach (var job in jobs)
			{
				DynamicParameters p = new DynamicParameters();
				p.Add("@JobID", job.ID);
				p.Add("@Title", job.Title);
				p.Add("@Company", job.Company);
				p.Add("@Description", job.Description);
				p.Add("@Availability", job.Availability);
				p.Add("@Url", job.Url);
				p.Add("@Salary", job.Salary);
				parameters.Add(p);
			}

			return parameters;
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

		public void SaveMultipleJobEntriesTransaction(List<JobEntryModel> jobs)
		{

		}
	}
}
