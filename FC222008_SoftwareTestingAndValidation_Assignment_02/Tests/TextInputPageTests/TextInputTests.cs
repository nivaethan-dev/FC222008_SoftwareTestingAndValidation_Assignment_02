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

        /* Loads JSON from "TextInputPage/TextInputData.json" using TextInputWrapper, extracts the TextInputs list, 
         * converts each item to NUnit TestCaseData, and provides it as a data source for a data-driven test
         */
        public static IEnumerable<TestCaseData> TextInputCases()
        {
            return TestCaseSourceHelper.FromJson<TextInputWrapper, string>(
                "TextInputPage/TextInputData.json",
                wrapper => wrapper.TextInputs
            );
        }

        // TC001_1 - Text Input - Verificaiton of the page
        [Test, TestCaseSource(nameof(TextInputCases))]
        public void TC001_1_TextInput_Verification_of_the_Page(string inputText)
        {
            // Verify that the Text Input page and required elements are displayed
            Assert.That(textInputPage.IsPageDisplayed(), Is.True, "TextInput page isn't displayed or missing the required elements.");

            // Enter text in the textbox
            textInputPage.SetButtonName(inputText);

            // Click the update button to apply the text
            textInputPage.ClickUpdateButton();

            // Verify that the button text updates to match the input
            Assert.That(textInputPage.GetButtonText(), Is.EqualTo(inputText), $"Button text did not update correctly for input: {inputText}");
        }

        /*
         * Additional Tests
         * ----------------
         * These tests complement the main functional test TC001_1 to ensure thorough coverage: 
         * 
         * TC001_2_TextInput_Verify_Page_UI
         *     - Purpose: Verify that all essential UI elements (textbox and button) are visible on the Text Input page.
         *     - Reason: Even if the main functionality works, missing or invisible UI elements could prevent user interaction.
         *     
         * TC001_3_VerifyTextBoxInput
         *    - Purpose: Verify that the textbox correctly retains input values from the user or test data.
         *    - Reason: Ensures the input mechanism works reliably before verifying that button updates occur (functional dependency).
         *    
         * Together with TC001_1, these additional tests provide both functional and UI validation of the Text Input page.
         */
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
