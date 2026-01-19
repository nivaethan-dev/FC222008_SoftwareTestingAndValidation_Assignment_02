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
        // 1. Helper Method to Click Client Side Logic Trigger Button
        public void ClickClientSideLogicTriggerButton()
        {
            ClickButton(btnClientSideLogicTrigger);
        }

        // 2. Helper method to wait until the loading indicator dissapears
        public void WaitForBanner()
        {
            WaitUntilInvisible(By.CssSelector("i#spinner"), 30); // wait until loading disappears (30 s max wait)
        }

        // -------- State Queries (Assertions use THESE) --------
        // 1. Get loadingIndicator status following the click of client side logic trigger button
        public bool IsLoadingIndicatorDisplayed()
        {
            return IsElementDisplayed(loadingIndicator);
        }

        // 2. Display status of Banner
        public bool IsBannerDisplayed()
        {
            return IsElementDisplayed(banner);
        }

        // 3. Get Text displayed in Banner
        public string GetBannerText()
        {
            return GetText(banner);
        }

        // 4. Page display status
        public bool IsPageDisplayed()
        {
            return IsElementDisplayed(btnClientSideLogicTrigger);
        }
    }
}
