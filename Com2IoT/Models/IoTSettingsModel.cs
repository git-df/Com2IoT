using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com2IoT.Models
{
    public class IoTSettingsModel
    {
        public string DivId { get; set; }
        public string DivKey { get; set; }
        public string HostName { get; set; }

        public IoTSettingsModel()
        {
            DivKey = "";
            HostName = "";
            DivId = "";
        }

        public IoTSettingsModel(string id, string key, string host)
        {
            DivKey = key;
            HostName = host;
            DivId = id;
        }
    }
}
