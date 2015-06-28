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
        private string thermostat;

        [JsonProperty("structure_id")]
        public string StructureID { get; internal set; }

        [JsonProperty("thermostats")]
        public string[] ThermostatIDs { get; internal set; }

        public async Task<Dictionary<string, Device>> GetDevicesAsync()
        {
            var pendingThermostats = this.GetThermosatsAsync();
            var pendingProtects = this.GetProtectsAsync();

            var devices = new List<Device>();
            devices.AddRange((await pendingThermostats).Values);
            devices.AddRange((await pendingProtects).Values);

            return devices.ToDictionary(device => device.DeviceID);
        }

        public async Task<Dictionary<string, Thermostat>> GetThermosatsAsync()
        {
            var thermostats = new Dictionary<string, Thermostat>();

            if (this.ThermostatIDs == null)
            {
                return thermostats;
            }
            else
            {
                foreach (var thermostatID in this.ThermostatIDs)
                {
                    var pendingThermostat = this.client.GetThermostatAsync(thermostatID);
                    thermostats.Add((await pendingThermostat).DeviceID, (await pendingThermostat));
                }

                return thermostats;
            }
        }

        [JsonProperty("smoke_co_alarms")]
        public string[] ProtectIDs { get; internal set; }

        public async Task<Dictionary<string, Protect>> GetProtectsAsync()
        {
            var protects = new Dictionary<string, Protect>();

            if (this.ProtectIDs == null)
            {
                return protects;
            }
            else
            {
                foreach (var protectID in this.ProtectIDs)
                {
                    var pendingProtect = this.client.GetProtectAsync(protectID);
                    protects.Add((await pendingProtect).DeviceID, (await pendingProtect));
                }

                return protects;
            }
        }

        [JsonProperty("away")]
        public Away Away { get; internal set; }

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

        [JsonProperty("wheres")]
        public Dictionary<string, Where> Wheres { get; internal set; }
    }
}
