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

    }
}
