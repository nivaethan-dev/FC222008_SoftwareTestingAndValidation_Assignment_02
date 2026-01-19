using Newtonsoft.Json;
using System.Reflection;

namespace FC222008_SoftwareTestingAndValidation_Assignment_02.Framework
{
    public static class TestDataHelper
    {
        // Lazily computed project root - calculated once, reused everywhere
        private static readonly Lazy<string> _projectRoot = new(() =>
        {
            string baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            // Navigate up from bin/Debug/net8.0 to project root
            return Directory.GetParent(baseDir)!.Parent!.Parent!.FullName;
        });

        public static string ProjectRoot => _projectRoot.Value;
        // Loads test data from a JSON file in the DataFiles folder.
        public static T LoadTestData<T>(string fileName)
        {
            string filePath = Path.Combine(ProjectRoot, "DataFiles", fileName);

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Test data file not found: {filePath}");

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json)!;
        }

        // Converts list items to NUnit TestCaseData for data-driven tests
        public static IEnumerable<TestCaseData> CreateTestCases<T>(IEnumerable<T> items,string testNamePrefix)
        {
            foreach (var item in items)
            {
                yield return new TestCaseData(item)
                    .SetName($"{testNamePrefix}_{item}");
            }
        }
    }
}