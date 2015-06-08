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
        private const string ThermostatsQuery = "https://developer-api.nest.com/devices/thermostats/?auth={0}";
        private const string SmokeAlarmsQuery = "https://developer-api.nest.com/devices/smoke_co_alarms/?auth={0}";
        private const string StructuresQuery = "https://developer-api.nest.com/structures/?auth={0}";

        public NestClient(string accessToken)
        {
            this.accessToken = accessToken;
        }

        private string accessToken;

        public async Task<Dictionary<string, Thermostat>> GetThermostatsAsync()
        {
            var thermostatsUrl = string.Format(NestClient.ThermostatsQuery, this.accessToken);

            var client = new HttpClient();
            var response = await client.GetAsync(thermostatsUrl);

            var payloadAsString = await response.Content.ReadAsStringAsync();
            var payload = JToken.Parse(payloadAsString);
            var thermostats = payload.ToObject<Dictionary<string, Thermostat>>();
            
            return thermostats;
        }

        public async Task<Dictionary<string, SmokeAlarm>> GetSmokeAlarmsAsync()
        {
            var smokeAlarmsUrl = string.Format(NestClient.SmokeAlarmsQuery, this.accessToken);

            var client = new HttpClient();
            var response = await client.GetAsync(smokeAlarmsUrl);

            var payloadAsString = await response.Content.ReadAsStringAsync();
            var payload = JToken.Parse(payloadAsString);
            var smokeAlarms = payload.ToObject<Dictionary<string, SmokeAlarm>>();

            return smokeAlarms;
        }

        public async Task<Dictionary<string, Structure>> GetStructuresAsync()
        {
            var structuresUrl = string.Format(NestClient.StructuresQuery, this.accessToken);

            var client = new HttpClient();
            var response = await client.GetAsync(structuresUrl);

            var payloadAsString = await response.Content.ReadAsStringAsync();
            var payload = JToken.Parse(payloadAsString);
            var structures = payload.ToObject<Dictionary<string, Structure>>();

            return structures;
        }
    }
}
