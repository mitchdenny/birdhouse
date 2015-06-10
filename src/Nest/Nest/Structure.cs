using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
    public class Structure
    {
        internal Structure(NestClient client)
        {
            this.client = client;
        }

        private NestClient client;

        [JsonProperty("structure_id")]
        public string StructureID { get; set; }

        [JsonProperty("thermosats")]
        public string[] ThermostatIDs { get; set; }

        [JsonProperty("smoke_co_alarms")]
        public string[] SmokeAlarmIDs { get; set; }

        [JsonProperty("away")]
        public string Away { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("peak_period_start_time")]
        public DateTimeOffset PeakPeriodStartTime { get; set; }

        [JsonProperty("peak_period_end_time")]
        public DateTimeOffset PeakPeriodEndTime { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        [JsonProperty("eta")]
        public Eta Eta { get; set; }

        [JsonProperty("wheres")]
        public Dictionary<string, Where> Wheres { get; set; }
    }
}
