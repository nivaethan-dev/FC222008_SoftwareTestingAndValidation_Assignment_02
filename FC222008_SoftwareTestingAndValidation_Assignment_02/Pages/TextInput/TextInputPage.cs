using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FC222008_SoftwareTestingAndValidation_Assignment_02.Framework;
using OpenQA.Selenium;

namespace FC222008_SoftwareTestingAndValidation_Assignment_02.Pages.TextInput
{
    internal class TextInputPage : BasePage
    {
        public TextInputPage(IWebDriver driver) : base(driver) { }

        // Element Locaters
        private IWebElement txtButtonName => FindElement(By.CssSelector("input#newButtonName"));
        private IWebElement btnUpdate => FindElement(By.CssSelector("button#updatingButton"));

        //-------------------------------------------------//
        //                    Actions                      //
        //-------------------------------------------------//
        // 1. Helper method to set new button name
        public void SetButtonName(string name)
        {
            txtButtonName.Clear();
            txtButtonName.SendKeys(name);
        }

        // 2. Helper method to click button
        public void ClickUpdateButton() 
        {
            btnUpdate.Click();
        }

        // 3. Helper Method to get Button Text
        public string GetButtonTxt()
        {
            return btnUpdate.Text;
        }
    }
}
