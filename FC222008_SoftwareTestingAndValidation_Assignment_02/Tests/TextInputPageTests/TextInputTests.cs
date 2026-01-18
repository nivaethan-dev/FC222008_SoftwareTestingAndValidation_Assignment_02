using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FC222008_SoftwareTestingAndValidation_Assignment_02.Framework;
using FC222008_SoftwareTestingAndValidation_Assignment_02.Pages.Home;
using FC222008_SoftwareTestingAndValidation_Assignment_02.Pages.TextInput;
using OpenQA.Selenium;

namespace FC222008_SoftwareTestingAndValidation_Assignment_02.Tests.TextInputPageTests
{
    [TestFixture]
    internal class TextInputTests
    {
        private IWebDriver _driver;
        private HomePage homePage;
        private TextInputPage textInputPage;

        [SetUp]
        public void SetUp()
        {
            _driver = TestDriver.GetDriver();
            // ONLY navigate to home page
            _driver.Navigate().GoToUrl("https://uitestingplayground.com/");
            homePage = new HomePage(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            // Properly dispose of WebDriver resources after each test
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }

        [Test(Description = "TC001_1 - Text Input - Verificaiton of the page")]
        public void TC001_1_TextInput_ButtonTextChanges()
        {

        }
    }
}
