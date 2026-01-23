using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FC222008_SoftwareTestingAndValidation_Assignment_02.Framework;
using OpenQA.Selenium;

namespace FC222008_SoftwareTestingAndValidation_Assignment_02.Pages.Alerts
{
    internal class AlertsPage : BasePage
    {
        public AlertsPage(IWebDriver driver) : base(driver) { }

        // Element Locaters
        private IWebElement btnAlert => FindElement(By.CssSelector("button#alertButton"));
        private IWebElement btnConfirm => FindElement(By.CssSelector("button#confirmButton"));
        private IWebElement btnPrompt => FindElement(By.CssSelector("button#promptButton"));

        // ---------- Actions ----------
        // 1. Click Alert Button
        public void ClickAlertButton()
        {
            btnAlert.Click();
        }

        // 2. Click Confirm Button
        public void ClickConfirmButton()
        {
            btnConfirm.Click();
        }

        // 3. Click Prompt Button
        public void ClickPromptButton()
        {
            btnPrompt.Click();
        }

        // -------- State Queries (Assertions use THESE) --------
        // 1. Method to get status of alert button display
        public bool IsAlertButtonDisplayed()
        {
            return IsElementDisplayed(btnAlert);
        }

        // 2. Method to get status of alert button display
        public bool IsConfirmButtonDisplayed()
        {
            return IsElementDisplayed(btnConfirm);
        }

        // 3. Method to get status of alert button display
        public bool IsPromptButtonDisplayed()
        {
            return IsElementDisplayed(btnPrompt);
        }

        // 4. Method to get status of Alerts Page display
        public bool IsPageDisplayed()
        {
            return IsPromptButtonDisplayed() && IsConfirmButtonDisplayed() && IsAlertButtonDisplayed();
        }

        // 5. Read Alert Text
        public string ReadAlertText()
        {
            return GetAlertText();  // from BasePage
        }

        // 6. Accept the alert
        public void AcceptAlertPopup()
        {
            AcceptAlert();          // from BasePage
        }

        // 7. Dismiss the alert
        public void DismissAlertPopup()
        {
            DismissAlert();         // from BasePage
        }

        // 8. Enter Text and Accept prompt
        public void EnterTextPrompt(string text)
        {
            SendTextToAlert(text);  // from BasePage
        }

        // 9. Method to get status of alert (ALERT POPUP: alert, confirm, prompt)
        public bool IsAlertPopupDisplayed()
        {
            return IsAlertPresent();
        }

        // 10. Method to wait until alert popup closed
        public void WaitForAlertToClose()
        {
            WaitUntilAlertIsGone();
        }

        // 11. Wait until next popup
        public void WaitUntilNextPopup()
        {
            WaitForNextAlert();
        }
    }
}
