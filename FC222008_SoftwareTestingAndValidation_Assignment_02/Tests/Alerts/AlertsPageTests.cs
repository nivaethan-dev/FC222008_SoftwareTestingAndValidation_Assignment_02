using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FC222008_SoftwareTestingAndValidation_Assignment_02.Framework;
using FC222008_SoftwareTestingAndValidation_Assignment_02.Pages.Home;
using FC222008_SoftwareTestingAndValidation_Assignment_02.Pages.Alerts;
using OpenQA.Selenium;

namespace FC222008_SoftwareTestingAndValidation_Assignment_02.Tests.Alerts
{
    internal class AlertsPageTests
    {
        private IWebDriver _driver;
        private HomePage homePage;
        private AlertsPage alertsPage;

        // Runs ONCE before all tests in this class
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = TestDriver.GetDriver();
            _driver.Navigate().GoToUrl("https://uitestingplayground.com/");
            homePage = new HomePage(_driver);
            alertsPage = homePage.GoToAlerts(); // Visits Alerts Page
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

        // TC004_1 - Alerts - Verification of the Alerts page
        [Test]
        public void TC004_1_Alerts_Verification_Of_the_Alerts_page()
        {
            Assert.That(alertsPage.IsPageDisplayed(), Is.True,"Alerts page or one of the alert buttons is not displayed.");
        }

        // TC004_2 - Alerts - Verification of the Alert text
        [Test]
        public void TC004_2_Alerts_Verification_Of_the_Alert_text()
        {
            alertsPage.ClickAlertButton();
            Assert.That(alertsPage.IsAlertPopupDisplayed(), Is.True, "Alert popup didn't appear");
            Assert.That(alertsPage.ReadAlertText(), Is.EqualTo("Today is a working day.\r\nOr less likely a holiday."), "The text didn't match or didn't appear.");
            alertsPage.AcceptAlertPopup();
            alertsPage.WaitForAlertToClose();
            Assert.That(alertsPage.IsAlertPopupDisplayed(), Is.False, "Alert popup didn't close.");
        }

        // TC004_3 - Alerts - Verification of the Alert text depneding on the first alert
        [TestCase(true, "Yes", TestName = "TC004_3_Alert_Accept_FirstAlert_SecondAlertYes")]
        [TestCase(false, "No", TestName = "TC004_3_Alert_Decline_FirstAlert_SecondAlertNo")]
        public void TC004_3_Alerts_Verification_Of_the_Alert_text_dependending_on_the_first_alert(bool acceptFirstAlert, string expectedSecondAlertText)
        {
            // Click Confirm button to trigger first alert
            alertsPage.ClickConfirmButton();

            // Verify first alert text
            Assert.That(alertsPage.IsAlertPopupDisplayed(), Is.True, "Confirm popup didn't appear");
            Assert.That(alertsPage.ReadAlertText(), Is.EqualTo("Today is Friday.\r\nDo you agree?"), "The text of first alert didn't match.");

            // Respond to first alert based on test case parameter
            if (acceptFirstAlert)
                alertsPage.AcceptAlertPopup();
            else
                alertsPage.DismissAlertPopup(); 

            // Wait for second alert to appear
            alertsPage.WaitUntilNextPopup();

            // Verify second alert text
            Assert.That(alertsPage.IsAlertPopupDisplayed(), Is.True, "Second alert did not appear after first alert.");
            Assert.That(alertsPage.ReadAlertText(), Is.EqualTo(expectedSecondAlertText), "Second alert text did not match expected.");
        }

        // TC004_4 - Alerts - Verification of the Alert prompt
    }
}
