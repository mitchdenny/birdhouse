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
        public string StructureID { get; internal set; }

        [JsonProperty("thermosats")]
        public string[] ThermostatIDs { get; internal set; }

        public async Task<IEnumerable<Device>> GetDevicesAsync()
        {
            var thermostats = await this.GetThermosatsAsync();
            var smokeAlarms = await this.GetSmokeAlarmsAsync();

            var devices = new List<Device>();
            devices.AddRange(thermostats);
            devices.AddRange(smokeAlarms);

            return devices;
        }

        public async Task<IEnumerable<Thermostat>> GetThermosatsAsync()
        {
            var thermostats = new List<Thermostat>();

            foreach (var thermostatID in this.ThermostatIDs)
            {
                var thermostat = await this.client.GetThermostatAsync(thermostatID);
                thermostats.Add(thermostat);
            }

            return thermostats;
        }

        [JsonProperty("smoke_co_alarms")]
        public string[] SmokeAlarmIDs { get; internal set; }

        public async Task<IEnumerable<SmokeAlarm>> GetSmokeAlarmsAsync()
        {
            var smokeAlarms = new List<SmokeAlarm>();

            foreach (var smokeAlarmID in this.SmokeAlarmIDs)
            {
                var smokeAlarm = await this.client.GetSmokeAlarmAsync(smokeAlarmID);
                smokeAlarms.Add(smokeAlarm);
            }

            return smokeAlarms;
        }

        [JsonProperty("away")]
        public string Away { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; internal set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; internal set; }

        [JsonProperty("peak_period_start_time")]
        public DateTimeOffset PeakPeriodStartTime { get; internal set; }

        [JsonProperty("peak_period_end_time")]
        public DateTimeOffset PeakPeriodEndTime { get; internal set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; internal set; }

        [JsonProperty("eta")]
        public Eta Eta { get; internal set; }

        [JsonProperty("wheres")]
        public Dictionary<string, Where> Wheres { get; internal set; }
    }
}
