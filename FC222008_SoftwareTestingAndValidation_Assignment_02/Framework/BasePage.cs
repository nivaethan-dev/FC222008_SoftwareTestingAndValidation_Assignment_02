using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC222008_SoftwareTestingAndValidation_Assignment_02.Framework
{
    // Parent class for all page objects in the framework
    internal class BasePage
    {
        // Holds the reference to the WebDriver instance used by this page
        protected IWebDriver _driver;

        // Constructor to initialize the page with a WebDriver
        // Any page class inheriting BasePage will have access to this driver
        protected BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Custom method to find an element with an explicit wait => by: locator (e.g., By.Id, By.XPath, and so on)
        // timeoutSeconds: maximum wait time in seconds (default 30)
        protected IWebElement FindElement(By by, int timeoutSeconds = 30)
        {
            // Waits until the element is found or the timeout expires
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds)).Until(d => d.FindElement(by));
        }

        // Helper method to enter text
        protected void EnterText(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        // Helper method to click button
        protected void ClickButton(IWebElement button)
        {
            button.Click();
        }

        // Helper method for element display status
        protected bool IsElementDisplayed(IWebElement element)
        {
            return element.Displayed;
        }

        // Helper method to Get Text
        protected string GetText(IWebElement element)
        {
            return element.Text;
        }

        // Waits until an element located by 'by' is no longer visible
        protected void WaitUntilInvisible(By by, int timeoutSeconds = 10)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        // ---------- Alert Helpers ----------
        protected IAlert SwitchToAlert(int timeoutSeconds = 10)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));

            return wait.Until(driver =>
            {
                try
                {
                    return driver.SwitchTo().Alert();
                }
                catch (NoAlertPresentException)
                {
                    return null;
                }
            })
            ?? throw new WebDriverTimeoutException("Alert did not appear within the timeout.");
        }

        // Returns true if an alert is currently present
        protected bool IsAlertPresent()
        {
            try
            {
                _driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }


        protected string GetAlertText()
        {
            var alert = SwitchToAlert();

            // Alert.Text is nullable in Selenium API → normalize it
            return alert.Text ?? string.Empty;
        }

        protected void AcceptAlert()
        {
            var alert = SwitchToAlert();
            alert.Accept();
        }

        protected void DismissAlert()
        {
            var alert = SwitchToAlert();
            alert.Dismiss();
        }

        protected void SendTextToAlert(string text)
        {
            var alert = SwitchToAlert();
            alert.SendKeys(text);
            alert.Accept();
        }

        // Waits until any alert is gone
        protected void WaitUntilAlertIsGone(int timeoutSeconds = 10)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds))
                .Until(d =>
                {
                    try
                    {
                        d.SwitchTo().Alert();
                        return false; // still present
                    }
                    catch (NoAlertPresentException)
                    {
                        return true; // gone
                    }
                });
        }

        // Waits until a new alert appears after the previous one
        protected IAlert WaitForNextAlert(int timeoutSeconds = 5)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(d =>
            {
                try
                {
                    return d.SwitchTo().Alert();
                }
                catch (NoAlertPresentException)
                {
                    return null;
                }
            }) ?? throw new WebDriverTimeoutException("Next alert did not appear within timeout.");
        }
    }
}
