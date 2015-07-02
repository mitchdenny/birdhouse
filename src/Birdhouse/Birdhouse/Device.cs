using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birdhouse
{
    public class Device
    {
        internal Device(NestClient client)
        {
            this.client = client;
        }

        private NestClient client;

        [JsonProperty("device_id")]
        public string DeviceID { get; internal set; }

        [JsonProperty("software_version")]
        public string SoftwareVersion { get; internal set; }

        [JsonProperty("locale")]
        public string Locale { get; internal set; }

        [JsonProperty("where_id")]
        public string WhereID { get; internal set; }

        public async Task<Where> GetWhereAsync()
        {
            var pendingStructure = this.GetStructureAsync();
            var where = (await pendingStructure).Wheres[this.WhereID];
            return where;
        }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("structure_id")]
        public string StructureID { get; internal set; }

        public async Task<Structure> GetStructureAsync()
        {
            var pendingStructure = this.client.GetStructureAsync(this.StructureID);
            return await pendingStructure;
        }

        [JsonProperty("name_long")]
        public string NameLong { get; internal set; }

        [JsonProperty("is_online")]
        public bool IsOnline { get; internal set; }
    }
}
