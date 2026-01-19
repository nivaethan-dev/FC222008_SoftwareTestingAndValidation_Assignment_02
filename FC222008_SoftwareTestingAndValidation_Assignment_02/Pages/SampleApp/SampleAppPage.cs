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
        private IWebElement msgWelcome => FindElement(By.CssSelector("label#loginstatus"));

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
    }
}
