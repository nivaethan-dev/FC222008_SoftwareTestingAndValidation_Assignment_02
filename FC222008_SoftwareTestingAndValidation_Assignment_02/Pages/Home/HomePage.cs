using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FC222008_SoftwareTestingAndValidation_Assignment_02.Framework;
using FC222008_SoftwareTestingAndValidation_Assignment_02.Pages.TextInput;
using OpenQA.Selenium;

namespace FC222008_SoftwareTestingAndValidation_Assignment_02.Pages.Home
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        // Element Locaters
        private IWebElement lnkTextInput => FindElement(By.CssSelector("a[href='/textinput']"));

        // Method to navigate to Text Input page
        public TextInputPage GoToTextInput()
        {
            lnkTextInput.Click();
            return new TextInputPage(_driver);
        }
    }
}
