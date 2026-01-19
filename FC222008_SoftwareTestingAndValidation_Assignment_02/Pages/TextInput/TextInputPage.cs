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
            EnterText(txtButtonName, name);
        }

        // 2. Helper method to click button
        public void ClickUpdateButton() 
        {
            ClickButton(btnUpdate);
        }
       
        // -------- State Queries (Assertions use THESE) --------
        // 1. Method to get status of text box display (Text box here is where button name is typed)
        public bool IsTextBoxDisplayed()
        {
            return IsElementDisplayed(txtButtonName);
        }

        // 2. Method to get status of button display
        public bool IsButtonDisplayed()
        {
            return IsElementDisplayed(btnUpdate);
        }

        // 3.Method to get Button Text
        public string GetButtonText()
        {
            return GetText(btnUpdate);
        }

        // 4. Method to get the text currently entered in the input field
        public string GetEnteredText()
        {
            return txtButtonName.GetAttribute("value") ?? string.Empty;
        }

    }
}
