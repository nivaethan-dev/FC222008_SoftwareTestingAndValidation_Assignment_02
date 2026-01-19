using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC222008_SoftwareTestingAndValidation_Assignment_02.Framework
{
    internal class TestCaseSourceHelper
    {
        // Generic method to create TestCaseData from any JSON wrapper
        public static IEnumerable<TestCaseData> FromJson<TWrapper, TItem>(string jsonFilePath, System.Func<TWrapper, IEnumerable<TItem>> selector)
        {
            var data = TestDataHelper.LoadTestData<TWrapper>(jsonFilePath);

            foreach (var item in selector(data))
            {
                yield return new TestCaseData(item)
                    .SetDescription($"Testing input: {item}");
            }
        }
    }
}
