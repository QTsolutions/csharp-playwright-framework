using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM_Basic.Utilities
{
    public class ReadJson
    {
        public ReadJson()
        {

        }
        public string ReadData(String value)
        {
            string filePath = System.IO.Directory.GetParent(@"../../../") + "/config.json";
            dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(filePath));
            return jsonFile[value];
        }
    }
}
