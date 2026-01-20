using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FC222008_SoftwareTestingAndValidation_Assignment_02.Framework;
using FC222008_SoftwareTestingAndValidation_Assignment_02.Pages.TextInput;
using FC222008_SoftwareTestingAndValidation_Assignment_02.Pages.SampleApp;
using OpenQA.Selenium;
using FC222008_SoftwareTestingAndValidation_Assignment_02.Pages.Client_Side_Delay;

namespace FC222008_SoftwareTestingAndValidation_Assignment_02.Pages.Home
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        // Element Locaters
        private IWebElement lnkTextInput => FindElement(By.CssSelector("a[href='/textinput']"));
        private IWebElement lnkSampleApp => FindElement(By.CssSelector("a[href='/sampleapp']"));
        private IWebElement lnkClientSideDelay => FindElement(By.CssSelector("a[href='/clientdelay']"));
        private IWebElement lnkAlerts => FindElement(By.CssSelector("a[href='/alerts']"));

        // Method to navigate to Text Input page
        public TextInputPage GoToTextInput()
        {
            lnkTextInput.Click();
            return new TextInputPage(_driver);
        }

        // Method to navigate to Sample App page
        public SampleAppPage GoToSampleApp()
        {
            lnkSampleApp.Click();
            return new SampleAppPage(_driver);
        }

        // Method to navigate to Client Side Delay Page
        public ClientSideDelayPage GoToClientSideDelay()
        {
            lnkClientSideDelay.Click();
            return new ClientSideDelayPage(_driver);
        }
    }
}
