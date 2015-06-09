using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
    public class NestClient
    {
        private const string ThermostatsQuery = "https://developer-api.nest.com/devices/thermostats/{0}?auth={1}";
        private const string SmokeAlarmsQuery = "https://developer-api.nest.com/devices/smoke_co_alarms/{0}?auth={1}";
        private const string StructuresQuery = "https://developer-api.nest.com/structures/{0}?auth={1}";

        public NestClient(string accessToken)
        {
            this.accessToken = accessToken;
        }

        private string accessToken;

        private async Task<Dictionary<string, T>> GetAsync<T>(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);

            var payloadAsString = await response.Content.ReadAsStringAsync();
            var payload = JToken.Parse(payloadAsString);

            if (payload.Count() == 1)
            {
                return null;
            }
            else
            {
                var entities = payload.ToObject<Dictionary<string, T>>();
                return entities;
            }
        }

        public async Task<Dictionary<string, Thermostat>> GetThermostatsAsync()
        {
            var thermostatsUrl = string.Format(NestClient.ThermostatsQuery, null, this.accessToken);

            var client = new HttpClient();
            var response = await client.GetAsync(thermostatsUrl);

            var payloadAsString = await response.Content.ReadAsStringAsync();
            var payload = JToken.Parse(payloadAsString);

            if (payload.Count() == 0)
            {
                return null;
            }
            else
            {
                var thermostats = payload.ToObject<Dictionary<string, Thermostat>>();
                return thermostats;
            }
        }

        public async Task<Thermostat> GetThermostatAsync(string thermostatID)
        {
            var thermostatsUrl = string.Format(NestClient.ThermostatsQuery, thermostatID, this.accessToken);
            var thermostats = await this.GetAsync<Thermostat>(thermostatsUrl);
            return thermostats[thermostatID];
        }

        public async Task<Dictionary<string, SmokeAlarm>> GetSmokeAlarmsAsync()
        {
            var smokeAlarmsUrl = string.Format(NestClient.SmokeAlarmsQuery, null, this.accessToken);

            var client = new HttpClient();
            var response = await client.GetAsync(smokeAlarmsUrl);

            var payloadAsString = await response.Content.ReadAsStringAsync();
            var payload = JToken.Parse(payloadAsString);

            if (payload.Count() == 0)
            {
                return null;
            }
            else
            {
                var smokeAlarms = payload.ToObject<Dictionary<string, SmokeAlarm>>();
                return smokeAlarms;
            }
        }

        public async Task<SmokeAlarm> GetSmokeAlarm(string smokeAlarmID)
        {
            return null;
        }

        public async Task<Dictionary<string, Structure>> GetStructuresAsync()
        {
            var structuresUrl = string.Format(NestClient.StructuresQuery, null, this.accessToken);

            var client = new HttpClient();
            var response = await client.GetAsync(structuresUrl);

            var payloadAsString = await response.Content.ReadAsStringAsync();
            var payload = JToken.Parse(payloadAsString);

            if (payload.Count() == 0)
            {
                return null;
            }
            else
            {
                var structures = payload.ToObject<Dictionary<string, Structure>>();
                return structures;
            }
        }

        public async Task<Structure> GetStructureAsync(string structureID)
        {
            return null;
        }
    }
}
