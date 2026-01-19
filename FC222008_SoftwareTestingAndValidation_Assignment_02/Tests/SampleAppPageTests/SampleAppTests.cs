using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FC222008_SoftwareTestingAndValidation_Assignment_02.Framework;
using FC222008_SoftwareTestingAndValidation_Assignment_02.Pages.Home;
using FC222008_SoftwareTestingAndValidation_Assignment_02.Pages.SampleApp;
using FC222008_SoftwareTestingAndValidation_Assignment_02.DataFiles.SampleAppPage;
using OpenQA.Selenium;

namespace FC222008_SoftwareTestingAndValidation_Assignment_02.Tests.SampleAppPageTests
{
    internal class SampleAppTests
    {
        private IWebDriver _driver;
        private HomePage homePage;
        private SampleAppPage sampleAppPage;

        // Runs ONCE before all tests in this class
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = TestDriver.GetDriver();
            _driver.Navigate().GoToUrl("https://uitestingplayground.com/");
            homePage = new HomePage(_driver);
            sampleAppPage = homePage.GoToSampleApp(); // Visit Sample App Page
        }

        // Runs ONCE after all tests in this class
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Navigate().Refresh(); // ensure fresh page
        }

        // Only successful login cases
        public static IEnumerable<TestCaseData> SuccessfulLoginCases()
        {
            return TestCaseSourceHelper.FromJson<SampleAppWrapper, SampleAppData>(
                "SampleAppPage/SampleAppData.json",
                wrapper => wrapper.Logins.Where(l => l.Password == "pwd")  // success = password is "pwd"
            );
        }

        // Only unsuccessful login cases
        public static IEnumerable<TestCaseData> UnsuccessfulLoginCases()
        {
            return TestCaseSourceHelper.FromJson<SampleAppWrapper, SampleAppData>(
                "SampleAppPage/SampleAppData.json",
                wrapper => wrapper.Logins.Where(l => l.Password != "pwd")  // failure = password != "pwd"
            );
        }

        // TC002_1 - Sample App - Verification of the sample app page
        [Test]
        public void TC002_1_Verify_Whether_Page_Is_Displayed()
        {
            Assert.That(sampleAppPage.IsPageDisplayed(),Is.True, "Sample App page isn't displayed.");
        }

        // TC002_2 - Sample App - Verification of a successful login
        [Test, TestCaseSource(nameof(SuccessfulLoginCases))]
        public void TC002_2_SampleApp_Verify_Successful_Login(SampleAppData login) 
        {
            sampleAppPage.Login(login.Username, login.Password);

            Assert.That(sampleAppPage.GetLoginStatusMessage(), Is.EqualTo(login.ExpectedMessage), $"Successful login test failed for user: {login.Username}");
        }

        // TC002_3 - Sample App - Verification of an unsuccessful login
        [Test, TestCaseSource(nameof(UnsuccessfulLoginCases))]
        public void TC002_3_SampleApp_Verify_Unsuccessful_Login(SampleAppData login)
        {
            sampleAppPage.Login(login.Username, login.Password);

            Assert.That(sampleAppPage.GetLoginStatusMessage(), Is.EqualTo(login.ExpectedMessage), $"Unsuccessful login test failed for user: {login.Username}");
        }
    }
}
