﻿using System.Configuration;
using System.Net;
using System.Text;
using NUnit.Framework;

namespace Classical_Music_Acceptance_Tests
{
	[TestFixture]
	public class StatusEndpointTests
	{
		private WebResponse _response;

		[TestFixtureSetUp]
		public void BeforeAll()
		{
			string url = ConfigurationManager.AppSettings["RootUrl"] + "/status";
			WebRequest request = WebRequest.Create(url);
			_response = request.GetResponse();
		}

		[TestFixtureTearDown]
		public void AfterAll()
		{
			_response.Dispose();
		}

		[Test]
		public void Returns_an_OK_response()
		{
			var httpStatusCode = ((HttpWebResponse)_response).StatusCode;
			Assert.That(httpStatusCode, Is.EqualTo(HttpStatusCode.OK));
		}

		[Test]
		public void Returns_a_Database_status()
		{
			string responseText;

			using (var reader = new System.IO.StreamReader(_response.GetResponseStream(), ASCIIEncoding.ASCII))
			{
				responseText = reader.ReadToEnd();
			}

			Assert.That(responseText, Is.StringContaining("Database: "));
		}
	}
}
