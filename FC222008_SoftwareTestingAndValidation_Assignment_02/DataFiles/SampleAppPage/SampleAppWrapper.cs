using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC222008_SoftwareTestingAndValidation_Assignment_02.DataFiles.SampleAppPage
{
    internal class SampleAppWrapper
    {
        public List<SampleAppData> Logins { get; set; } = new List<SampleAppData>();
    }

    internal class SampleAppData
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ExpectedMessage { get; set; } = string.Empty;
    }
}
