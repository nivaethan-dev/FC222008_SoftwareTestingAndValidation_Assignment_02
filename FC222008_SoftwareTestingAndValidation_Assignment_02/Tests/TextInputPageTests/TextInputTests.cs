using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FC222008_SoftwareTestingAndValidation_Assignment_02.Framework;
using FC222008_SoftwareTestingAndValidation_Assignment_02.Pages.Home;
using FC222008_SoftwareTestingAndValidation_Assignment_02.Pages.TextInput;
using FC222008_SoftwareTestingAndValidation_Assignment_02.DataFiles.TextInputPage;
using OpenQA.Selenium;

namespace FC222008_SoftwareTestingAndValidation_Assignment_02.Tests.TextInputPageTests
{
    [TestFixture]
    internal class TextInputTests
    {
        private IWebDriver _driver;
        private HomePage homePage;
        private TextInputPage textInputPage;

        // Runs ONCE before all tests in this class
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = TestDriver.GetDriver();
            _driver.Navigate().GoToUrl("https://uitestingplayground.com/");
            homePage = new HomePage(_driver);
            textInputPage = homePage.GoToTextInput(); // Visit TextInput Page
        }

        // Runs ONCE after all tests in this class
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }

        // Data source for data-driven test below
        public static IEnumerable<TestCaseData> TextInputCases()
        {
            var data = TestDataHelper.LoadTestData<TextInputWrapper>("TextInputPage/TextInputData.json");
            foreach (var input in data.TextInputs)
            {
                yield return new TestCaseData(input)
                    .SetDescription($"Testing input: {input}");
            }
        }

        // Verifies that the button text is changing to the text entered by the user
        [Test, TestCaseSource(nameof(TextInputCases))]
        public void TC001_1_Verify_Button_Text_Changes_To_UserEnteredText(string inputText)
        {
            textInputPage.SetButtonName(inputText);
            textInputPage.ClickUpdateButton();

            Assert.That(textInputPage.GetButtonText(), Is.EqualTo(inputText), $"Button text did not update correctly for input: {inputText}");
        }

        // Verifies text box and button are visible on the Text Input page
        [Test(Description = "TC001_2_Verify_TextInput_Page_UI")]
        public void TC001_2_TextInput_Verify_Page_UI()
        {
            Assert.That(textInputPage.IsTextBoxDisplayed(), Is.True, "The text box is not displayed on Text Input Page.");
            Assert.That(textInputPage.IsButtonDisplayed(), Is.True, "The update button is not displayed on Text Input Page.");
        }

        // Verifies text box accepts and retains input values from JSON test data
        [Test, TestCaseSource(nameof(TextInputCases))]
        public void TC001_3_VerifyTextBoxInput(string inputText)
        {
            textInputPage.SetButtonName(inputText);
            Assert.That(textInputPage.GetEnteredText(), Is.EqualTo(inputText),$"Textbox did not retain the value: {inputText}");
        }
    }
}
