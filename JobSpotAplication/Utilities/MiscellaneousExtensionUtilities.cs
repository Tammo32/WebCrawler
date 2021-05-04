using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSpotAplication.Utilities
{
	public static class MiscellaneousExtensionUtilities
	{
		public static SqlConnection CreateConnection(this string connectionString) => new SqlConnection(connectionString);
	}
}
