﻿using TechTalk.SpecFlow;

namespace Classical_Music_Acceptance_Tests.Specs
{
	[Binding]
	class ReleaseIdEndpointSteps
	{
		private ReleaseIdEndpointStepsDriver _driver;

		[Given(@"The Website is running")]
		public void GivenTheWebsiteIsRunning()
		{
			_driver = new ReleaseIdEndpointStepsDriver();
			_driver.AssertWebsiteIsRunning();
		}

		[Given(@"a release exists in the database")]
		public void GivenAReleaseExistsInTheDatabase()
		{
			_driver.AddReleaseToDatabase();
		}

		[When(@"I request the release from the endpoint")]
		public void WhenIRequestTheReleaseFromTheEndpoint()
		{
			_driver.GetReleaseFromEndpoint();
		}

		[Then(@"I should see its release title")]
		public void ThenIShouldSeeItsReleaseTitle()
		{
			_driver.AssertReleaseTitleIsCorrect();
		}

	}
}