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
            // If any alert is still open from previous test, close it
            try
            {
                _driver.SwitchTo().Alert().Accept();
            }
            catch (NoAlertPresentException)
            {
                // no alert, safe to continue
            }

            _driver.Navigate().Refresh(); // now safe to refresh
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
            // Step 1: Click the Alert button to trigger the alert popup
            alertsPage.ClickAlertButton();

            // Verify that the alert popup is displayed
            Assert.That(alertsPage.IsAlertPopupDisplayed(), Is.True, "Alert popup didn't appear");

            //Assert.That(alertsPage.ReadAlertText(), Is.EqualTo("Today is a working day.\r\nOr less likely a holiday."), "The text didn't match or didn't appear."); Used this earlier

            // Read the alert text and replace line breaks with spaces 
            // (Alert contains a newline between the two sentences)
            string alertText = alertsPage.ReadAlertText().Replace("\r\n", " ");

            // Verify that the alert text contains the expected message
            Assert.That(alertText.Contains("Today is a working day. Or less likely a holiday."),"The text didn't match or didn't appear.");

            // Step 2: Accept the alert popup
            alertsPage.AcceptAlertPopup();

            // Wait until the alert is completely closed
            alertsPage.WaitForAlertToClose();

            // Verify that the alert popup is no longer displayed
            Assert.That(alertsPage.IsAlertPopupDisplayed(), Is.False, "Alert popup didn't close.");
        }

        // TC004_3 - Alerts - Verification of the Alert text depneding on the first alert
        [TestCase(true, "Yes", TestName = "TC004_3_Alert_Accept_FirstAlert_SecondAlertYes")]
        [TestCase(false, "No", TestName = "TC004_3_Alert_Decline_FirstAlert_SecondAlertNo")]
        public void TC004_3_Alerts_Verification_Of_the_Alert_text_dependending_on_the_first_alert(bool acceptFirstAlert, string expectedSecondAlertText)
        {
            // Step 1: Click Confirm button to trigger first alert
            alertsPage.ClickConfirmButton();

            // Verify first alert text
            Assert.That(alertsPage.IsAlertPopupDisplayed(), Is.True, "Confirm popup didn't appear");
            Assert.That(alertsPage.ReadAlertText(), Is.EqualTo("Today is Friday.\r\nDo you agree?"), "The text of first alert didn't match.");

            // Step 2: Respond to first alert based on test case parameter
            if (acceptFirstAlert)
                alertsPage.AcceptAlertPopup();
            else
                alertsPage.DismissAlertPopup(); 

            // Wait for second alert to appear
            alertsPage.WaitUntilNextPopup();

            // Verify second alert text
            Assert.That(alertsPage.IsAlertPopupDisplayed(), Is.True, "Second alert did not appear after first alert.");
            Assert.That(alertsPage.ReadAlertText(), Is.EqualTo(expectedSecondAlertText), "Second alert text did not match the expected.");

            // CLOSE second alert (VERY IMPORTANT: Since it second alert here shouldn't interrupt next test.)
            alertsPage.AcceptAlertPopup();
            alertsPage.WaitForAlertToClose();
            Assert.That(alertsPage.IsAlertPopupDisplayed(), Is.False, "Second alert did not close properly.");
        }

        // TC004_4 - Alerts - Verification of the Alert prompt
        [TestCase(true, "HelloWorld", "User value: HelloWorld",TestName = "TC004_4_Prompt_Accept_ShowsUserInput")]
        [TestCase(false, "HelloWorld", "User value: no answer",TestName = "TC004_4_Prompt_Dismiss_ShowsNoAnswer")]
        public void TC004_4_Alerts_Verification_of_the_Alert_Prompt(bool accept, string typedTextInPrompt, string expectedValue)
        {
            // Step 1: Click the prompt button
            alertsPage.ClickPromptButton();

            // Check if prompt popup shows up
            Assert.That(alertsPage.IsAlertPopupDisplayed(), Is.True, "Prompt popup didn't appear.");

            // Step 2: Enter some random text (provided in test case)
            alertsPage.EnterTextPrompt(typedTextInPrompt);

            // Step 3: Accept / Dismiss the alert
            if (accept)
            {
                alertsPage.AcceptAlertPopup();
            } else
            {
                alertsPage.DismissAlertPopup();
            }

            // Wait for second alert to pop up
            alertsPage.WaitUntilNextPopup();

            // Verify second alert
            Assert.That(alertsPage.IsAlertPopupDisplayed(), Is.True, "Second alert popup didn't appear within timeout.");
            Assert.That(alertsPage.ReadAlertText(), Is.EqualTo(expectedValue), "Second aler text didn't match the expected text.");

            // CLOSE second alert (VERY IMPORTANT: Since it second alert here shouldn't interrupt next test.)
            alertsPage.AcceptAlertPopup();
            alertsPage.WaitForAlertToClose();
            Assert.That(alertsPage.IsAlertPopupDisplayed(), Is.False, "Second alert did not close properly.");
        }

    }
}
