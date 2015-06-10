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
            
            this.serializer = new JsonSerializer();
            this.serializer.Converters.Add(new ThermostatConverter(this));
            this.serializer.Converters.Add(new SmokeAlarmConverter(this));
            this.serializer.Converters.Add(new StructureConverter(this));
        }

        private string accessToken;
        private JsonSerializer serializer;

        private async Task<JToken> GetPayloadAsync(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);

            var payloadAsString = await response.Content.ReadAsStringAsync();
            var payload = JToken.Parse(payloadAsString);
            return payload;
        }

        private async Task<T> GetItemAsync<T>(string url) where T: class
        {
            var payload = await this.GetPayloadAsync(url);

            if (payload.Count() < 1)
            {
                return null;
            }
            else
            {
                var entity = payload.ToObject<T>(this.serializer);
                return entity;
            }
        }

        private async Task<Dictionary<string, T>> GetItemsAsync<T>(string url)
        {
            var payload = await this.GetPayloadAsync(url);

            if (payload.Count() < 1)
            {
                return null;
            }
            else
            {
                var entities = payload.ToObject<Dictionary<string, T>>(this.serializer);
                return entities;
            }
        }

        public async Task<Dictionary<string, Thermostat>> GetThermostatsAsync()
        {
            var thermostatsUrl = string.Format(NestClient.ThermostatsQuery, null, this.accessToken);
            var thermostats = await this.GetItemsAsync<Thermostat>(thermostatsUrl);
            return thermostats;
        }

        public async Task<Thermostat> GetThermostatAsync(string thermostatID)
        {
            var thermostatsUrl = string.Format(NestClient.ThermostatsQuery, thermostatID, this.accessToken);
            var thermostat = await this.GetItemAsync<Thermostat>(thermostatsUrl);
            return thermostat;
        }

        public async Task<Dictionary<string, SmokeAlarm>> GetSmokeAlarmsAsync()
        {
            var smokeAlarmsUrl = string.Format(NestClient.SmokeAlarmsQuery, null, this.accessToken);
            var smokeAlarms = await this.GetItemsAsync<SmokeAlarm>(smokeAlarmsUrl);
            return smokeAlarms;
        }

        public async Task<SmokeAlarm> GetSmokeAlarmAsync(string smokeAlarmID)
        {
            var smokeAlarmsUrl = string.Format(NestClient.SmokeAlarmsQuery, smokeAlarmID, this.accessToken);
            var smokeAlarm = await this.GetItemAsync<SmokeAlarm>(smokeAlarmsUrl);
            return smokeAlarm;
        }

        public async Task<Dictionary<string, Structure>> GetStructuresAsync()
        {
            var structuresUrl = string.Format(NestClient.StructuresQuery, null, this.accessToken);
            var structures = await this.GetItemsAsync<Structure>(structuresUrl);
            return structures;
        }

        public async Task<Structure> GetStructureAsync(string structureID)
        {
            var structuresUrl = string.Format(NestClient.StructuresQuery, structureID, this.accessToken);
            var structure = await this.GetItemAsync<Structure>(structuresUrl);
            return structure;
        }
    }
}
