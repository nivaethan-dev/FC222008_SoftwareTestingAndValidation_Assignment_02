using Newtonsoft.Json;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC222008_SoftwareTestingAndValidation_Assignment_02.Framework
{
    internal class TestDriver
    {
        // Method that creates and returns a Chrome WebDriver instance
        public static IWebDriver GetDriver()
        {
            // To configure browser behavior
            ChromeOptions options = new ChromeOptions();

            // Opens the Chrome browser in maximized mode
            options.AddArgument("start-maximized");

            // Creates and returns a new ChromeDriver using the given options
            return new ChromeDriver(options);
        }

        // Generic method to read JSON data and convert it into any required object type: Future reference
        public static T ReadJson<T>(string filePath)
        {
            // Reads the entire JSON file content as a string
            string json = File.ReadAllText(filePath);

            // Converts JSON string into an object of type T and returns it
            return JsonConvert.DeserializeObject<T>(json)!;
        }
    }
}
