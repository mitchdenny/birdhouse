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

        [JsonProperty("software_version")]
        public string SoftwareVersion { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("where_id")]
        public string WhereID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("structure_id")]
        public string StructureID { get; set; }

        [JsonProperty("name_long")]
        public string NameLong { get; set; }

        [JsonProperty("is_online")]
        public bool IsOnline { get; set; }
    }
}
