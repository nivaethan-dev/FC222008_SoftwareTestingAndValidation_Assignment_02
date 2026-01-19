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
    // Wrapper class for JSON deserialization
    internal class TextInputDataWrapper
    {
        public List<string> TextInputs { get; set; } = new List<string>();
    }

    [TestFixture]
    internal class TextInputTests
    {
        private IWebDriver _driver;
        private HomePage homePage;
        private TextInputPage textInputPage;

        // Test data loaded from JSON. Must be static for TestCaseSource
        private static List<string> textInputData;

        [SetUp]
        public void SetUp()
        {
            _driver = TestDriver.GetDriver();
            // ONLY navigate to home page
            _driver.Navigate().GoToUrl("https://uitestingplayground.com/");
            homePage = new HomePage(_driver);
            textInputPage = homePage.GoToTextInput(); // Visit TextInput Page
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

        /* TC001_1 - Expected Result 1:
           "The text input page is displayed.
           A text box and a button is appearing on the page."
        */
        [Test(Description = "TC001_1_Verify_TextInput_Page_UI")]
        public void TC001_1_TextInput_Verify_Page_UI()
        {
            Assert.That(textInputPage.IsTextBoxDisplayed(), Is.True, "The text box is not displayed on Text Input Page.");
            Assert.That(textInputPage.IsButtonDisplayed(), Is.True, "The update button is not displayed on Text Input Page.");
        }

        // ------------------------------------------
        // Static method providing TestCaseSource
        // ------------------------------------------
        public static IEnumerable<TestCaseData> TextInputCases()
        {
            // Calculate project folder dynamically
            string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string filePath = Path.Combine(projectDir, "DataFiles", "TextInputData.json");

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Test data JSON not found: {filePath}");

            var wrapper = TestDriver.ReadJson<TextInputDataWrapper>(filePath);

            foreach (var input in wrapper.TextInputs)
            {
                yield return new TestCaseData(input)
                    .SetName($"TC001_1_VerifyTextBoxInput_{input}");
            }
        }

        // TC001_1 - Verify textbox input using data-driven JSON
        [Test, TestCaseSource(nameof(TextInputCases))]
        public void TC001_1_VerifyTextBoxInput(string inputText)
        {
            textInputPage.SetButtonName(inputText);
            Assert.That(textInputPage.GetEnteredText(), Is.EqualTo(inputText),
                $"Textbox did not retain the value: {inputText}");
        }
    }
}
