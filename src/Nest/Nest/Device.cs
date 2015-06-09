using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
    public class Device
    {
        [JsonProperty("device_id")]
        public string DeviceID { get; set; }
    }
}
