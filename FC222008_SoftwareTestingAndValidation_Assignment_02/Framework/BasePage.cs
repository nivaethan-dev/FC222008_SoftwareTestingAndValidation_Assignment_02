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
    }
}
