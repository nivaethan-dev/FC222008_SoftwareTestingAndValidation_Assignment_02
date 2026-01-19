using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FC222008_SoftwareTestingAndValidation_Assignment_02.Framework;
using OpenQA.Selenium;

namespace FC222008_SoftwareTestingAndValidation_Assignment_02.Pages.Client_Side_Delay
{
    internal class ClientSideDelayPage : BasePage
    {
        public ClientSideDelayPage(IWebDriver driver) : base(driver) { }

        // Element Locaters
        private IWebElement btnClientSideLogicTrigger => FindElement(By.CssSelector("button#ajaxButton"));
        private IWebElement loadingIndicator => FindElement(By.CssSelector("i#spinner"));
        private IWebElement banner => FindElement(By.CssSelector("p.bg-success"));

        //-------------------------------------------------//
        //                    Actions                      //
        //-------------------------------------------------//
    }
}
