using Nest.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        private const string ProtectsQuery = "https://developer-api.nest.com/devices/smoke_co_alarms/{0}?auth={1}";
        private const string StructuresQuery = "https://developer-api.nest.com/structures/{0}?auth={1}";

        public NestClient(string accessToken)
        {
            this.accessToken = accessToken;
            
            this.serializer = new JsonSerializer();
            this.serializer.Converters.Add(new ThermostatConverter(this));
            this.serializer.Converters.Add(new SmokeAlarmConverter(this));
            this.serializer.Converters.Add(new StructureConverter(this));
            this.serializer.Converters.Add(new StringEnumConverter());
        }

        private string accessToken;
        private JsonSerializer serializer;

        private async Task<JToken> GetPayloadAsync(string url)
        {
            var client = new HttpClient();
            var pendingResponse = client.GetAsync(url);

            var pendingPayloadAsString = (await pendingResponse).Content.ReadAsStringAsync();
            var payload = JToken.Parse(await pendingPayloadAsString);
            return payload;
        }

        internal async Task<T> GetItemAsync<T>(string url) where T: class
        {
            var pendingPayload = this.GetPayloadAsync(url);

            if ((await pendingPayload).Count() < 1)
            {
                return null;
            }
            else
            {
                var entity = (await pendingPayload).ToObject<T>(this.serializer);
                return entity;
            }
        }

        internal async Task<Dictionary<string, T>> GetItemsAsync<T>(string url)
        {
            var pendingPayload = this.GetPayloadAsync(url);

            if ((await pendingPayload).Count() < 1)
            {
                return null;
            }
            else
            {
                var entities = (await pendingPayload).ToObject<Dictionary<string, T>>(this.serializer);
                return entities;
            }
        }

        public async Task<Dictionary<string, Thermostat>> GetThermostatsAsync()
        {
            var thermostatsUrl = string.Format(NestClient.ThermostatsQuery, null, this.accessToken);
            var pendingThermostats = this.GetItemsAsync<Thermostat>(thermostatsUrl);
            return await pendingThermostats;
        }

        public async Task<Thermostat> GetThermostatAsync(string thermostatID)
        {
            var thermostatsUrl = string.Format(NestClient.ThermostatsQuery, thermostatID, this.accessToken);
            var pendingThermostat = this.GetItemAsync<Thermostat>(thermostatsUrl);
            return await pendingThermostat;
        }

        public async Task<Dictionary<string, Protect>> GetProtectsAsync()
        {
            var protectsUrl = string.Format(NestClient.ProtectsQuery, null, this.accessToken);
            var pendingProtects = this.GetItemsAsync<Protect>(protectsUrl);
            return await pendingProtects;
        }

        public async Task<Protect> GetProtectAsync(string protectID)
        {
            var protectsUrl = string.Format(NestClient.ProtectsQuery, protectID, this.accessToken);
            var pendingProtect = this.GetItemAsync<Protect>(protectsUrl);
            return await pendingProtect;
        }

        public async Task<Dictionary<string, Structure>> GetStructuresAsync()
        {
            var structuresUrl = string.Format(NestClient.StructuresQuery, null, this.accessToken);
            var pendingStructures = this.GetItemsAsync<Structure>(structuresUrl);
            return await pendingStructures;
        }

        public async Task<Structure> GetStructureAsync(string structureID)
        {
            var structuresUrl = string.Format(NestClient.StructuresQuery, structureID, this.accessToken);
            var pendingStructure = this.GetItemAsync<Structure>(structuresUrl);
            return await pendingStructure;
        }

        public async Task<Dictionary<string, Device>> GetDevicesAsync()
        {
            var pendingThermostats = this.GetThermostatsAsync();
            var pendingProtects = this.GetProtectsAsync();

            var devices = new List<Device>();
            devices.AddRange((await pendingThermostats).Values);
            devices.AddRange((await pendingProtects).Values);

            return devices.ToDictionary(device => device.DeviceID);
        }
    }
}
