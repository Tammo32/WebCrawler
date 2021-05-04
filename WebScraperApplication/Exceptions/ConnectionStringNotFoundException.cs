using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Exceptions
{
	public class ConnectionStringNotFoundException : Exception
	{
		public ConnectionStringNotFoundException(string message) : base()
		{
		}

		public ConnectionStringNotFoundException(string message, Exception inner) : base()
		{
		}
	}
}
