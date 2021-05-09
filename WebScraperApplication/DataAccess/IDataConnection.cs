using System.Collections.Generic;
using System.Threading.Tasks;
using WebScraper.Models;

namespace WebScraper.DataAccess
{
	/*
	 * Some code used in this class was obtained from following along with a tutorial based on Creating a C# application from the following website.
	 * Credit goes to Tim Corey from iamtimcorey.com - 2021
	 * https://www.iamtimcorey.com/courses/443886/
	 */
	public interface IDataConnection
	{
		public int SaveJobEntry(JobEntryModel model);
		public void SaveMultipleJobEntries(List<JobEntryModel> models);
	}
}
