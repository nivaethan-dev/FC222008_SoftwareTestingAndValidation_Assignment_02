using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FC222008_SoftwareTestingAndValidation_Assignment_02.Framework;
using FC222008_SoftwareTestingAndValidation_Assignment_02.Pages.Home;
using FC222008_SoftwareTestingAndValidation_Assignment_02.Pages.Client_Side_Delay;
using OpenQA.Selenium;

namespace FC222008_SoftwareTestingAndValidation_Assignment_02.Tests.ClientSideDelayPageTests
{
    internal class ClientSideDelayTests
    {
        private IWebDriver _driver;
        private HomePage homePage;
        private ClientSideDelayPage clientSideDelayPage;

        // Runs ONCE before all tests in this class
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = TestDriver.GetDriver();
            _driver.Navigate().GoToUrl("https://uitestingplayground.com/");
            homePage = new HomePage(_driver);
            clientSideDelayPage = homePage.GoToClientSideDelay(); // Visit Client Side Delay Page
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

        // TC003_1 - Client Side Delay - Verificaiton of the page
        [Test]
        public void TC003_1_Verify_ClientSideDelay_Page()
        {
            // Verify page and button
            Assert.That(clientSideDelayPage.IsPageDisplayed(), Is.True, "The client side delay page isn't displayed.");

            // Trigger client-side calculation
            clientSideDelayPage.ClickClientSideLogicTriggerButton();

            // Verify loading indicator appears
            Assert.That(clientSideDelayPage.IsLoadingIndicatorDisplayed(), Is.True, "Loading indicator didn't appear after clicking the trigger.");

            // Wait for calculation to complete
            clientSideDelayPage.WaitForBanner();

            // Verify banner
            Assert.That(clientSideDelayPage.IsBannerDisplayed(), Is.True, "The banner isn't displayed after loading indicator disappeared.");
            Assert.That(clientSideDelayPage.GetBannerText(), Is.EqualTo("Data calculated on the client side."), "The banner doesn't display the expected text.");
        }
    }
}
