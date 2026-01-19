using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FC222008_SoftwareTestingAndValidation_Assignment_02.Framework;

namespace FC222008_SoftwareTestingAndValidation_Assignment_02.Pages.SampleApp
{
    internal class SampleAppPage : BasePage
    {
        public SampleAppPage(IWebDriver driver) : base(driver) { }

        // Element Locaters
        private IWebElement txtUsername => FindElement(By.CssSelector("input[name='UserName']"));
        private IWebElement txtPassword => FindElement(By.CssSelector("input[name='Password']"));
        private IWebElement btnLogin => FindElement(By.CssSelector("button#login"));
        private IWebElement msgLogin => FindElement(By.CssSelector("label#loginstatus"));

        //-------------------------------------------------//
        //                    Actions                      //
        //-------------------------------------------------//
        // 1. Helper method to type username
        public void TypeUsername(string username)
        {
            EnterText(txtUsername, username);
        }

        // 2. Helper Method to type password
        public void TypePassword(string password)
        {
            EnterText(txtPassword, password);
        }

        // 3. Helper Method to click Login
        public void ClickLogin()
        {
            ClickButton(btnLogin);
        }

        // 4. Helper Method for Login
        public void Login(string username, string password)
        {
            TypeUsername(username);
            TypePassword(password);
            ClickLogin();
        }

        // -------- State Queries (Assertions use THESE) --------
        // 1. Method to get login status message text
        public string GetLoginStatusMessage()
        {
            return GetText(msgLogin);
        }

        // 2. Method to get status of txtUsername display
        public bool IsTxtUsernameDisplayed()
        {
            return IsElementDisplayed(txtUsername);
        }

        // 3. Method to get status of txtPassword display
        public bool IsTxtPasswordDisplayed()
        {
            return IsElementDisplayed(txtPassword);
        }

        // 4. Method to get status of btnLogin display
        public bool IsBtnLoginDisplayed()
        {
            return IsElementDisplayed(btnLogin);
        }

        // 5. Method to verify if page displayed
        public bool IsPageDisplayed()
        {
            return IsTxtUsernameDisplayed() && IsTxtPasswordDisplayed() && IsBtnLoginDisplayed();
        }

        // 6. Method to get status of LoginMessage
        public bool IsLoginMessageDisplayed()
        {
            return IsElementDisplayed(msgLogin);
        }
    }
}
