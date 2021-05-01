using System.Collections.Generic;
using WebScraper.WebScraper;
using Xunit;

namespace JobSpotApplication.Tests
{
	
	public class WebScraperTests
	{
		[Fact]
		public void SeekWebScraperBuildUrl_ShouldReturnTitleLocationUrl()
		{
			// Arrange
			Dictionary<string, string> _searchParameters = new Dictionary<string, string>();
			_searchParameters.Add("title", "Web Developer");
			_searchParameters.Add("location", "Melbourne");
			string expected = "https://seek.com.au/Web-Developer-jobs/in-Melbourne/";

			// Act
			string actual = new SeekWebScraperModel().BuildUrl(_searchParameters);
			
			// Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void SeekWebScraperBuildUrl_ShouldReturnTitleLocationAvailabilityUrl()
		{
			// Arrange
			Dictionary<string, string> _searchParameters = new Dictionary<string, string>();
			_searchParameters.Add("title", "Web Developer");
			_searchParameters.Add("location", "Melbourne");
			_searchParameters.Add("availability", "full-time");
			string expected = "https://seek.com.au/Web-Developer-jobs/in-Melbourne/full-time?";

			// Act
			string actual = new SeekWebScraperModel().BuildUrl(_searchParameters);

			// Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void SeekWebScraperBuildUrl_ShouldReturnTitleLocationAvailabilityDaterangeUrl()
		{
			// Arrange
			Dictionary<string, string> _searchParameters = new Dictionary<string, string>();
			_searchParameters.Add("title", "Web Developer");
			_searchParameters.Add("location", "Melbourne");
			_searchParameters.Add("availability", "full-time");
			_searchParameters.Add("daterange", "5");
			string expected = "https://seek.com.au/Web-Developer-jobs/in-Melbourne/full-time?daterange=5";

			// Act
			string actual = new SeekWebScraperModel().BuildUrl(_searchParameters);

			// Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void SeekWebScraperBuildUrl_ShouldReturnTitleLocationAvailabilityDaterangeSalaryRangeUrl()
		{
			// Arrange
			Dictionary<string, string> _searchParameters = new Dictionary<string, string>();
			_searchParameters.Add("title", "Web Developer");
			_searchParameters.Add("location", "Melbourne");
			_searchParameters.Add("availability", "full-time");
			_searchParameters.Add("daterange", "5");
			_searchParameters.Add("startingPayRange", "50000");
			_searchParameters.Add("endingPayRange", "80000");
			string expected = "https://seek.com.au/Web-Developer-jobs/in-Melbourne/full-time?daterange=5&salaryrange=50000-80000";

			// Act
			string actual = new SeekWebScraperModel().BuildUrl(_searchParameters);

			// Assert
			Assert.Equal(expected, actual);
		}
	}
}
