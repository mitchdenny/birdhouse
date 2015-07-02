using Birdhouse.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Birdhouse
{
    public class NestClient
    {
        private const string ThermostatsQuery = "https://developer-api.nest.com/devices/thermostats/{0}?auth={1}";
        private const string ProtectsQuery = "https://developer-api.nest.com/devices/smoke_co_alarms/{0}?auth={1}";
        private const string StructuresQuery = "https://developer-api.nest.com/structures/{0}?auth={1}";

        public NestClient(string accessToken)
        {
            this.AccessToken = accessToken;
            
            this.serializer = new JsonSerializer();
            this.serializer.Converters.Add(new ThermostatConverter(this));
            this.serializer.Converters.Add(new SmokeAlarmConverter(this));
            this.serializer.Converters.Add(new StructureConverter(this));
            this.serializer.Converters.Add(new StringEnumConverter());
        }

        internal string AccessToken { get; set; }
        private JsonSerializer serializer;

        private async Task<JToken> GetPayloadAsync(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var pendingPayloadAsString = response.Content.ReadAsStringAsync();
                var payload = JToken.Parse(await pendingPayloadAsString);
                return payload;
            }
            else
            {
                var exception = await this.BuildExceptionFromResponse(response);
                throw exception;
            }
        }

        private async Task ExecuteRequestAsync(string method, string url, string requestPayload, object entity)
        {
            var requestContent = new StringContent(requestPayload);
            var requestMessage = new HttpRequestMessage(new HttpMethod(method), url);
            requestMessage.Content = requestContent;

            var client = new HttpClient();
            var pendingResponse = client.SendAsync(requestMessage);
            var response = await pendingResponse;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                using (var reader = new StreamReader(responseStream))
                {
                    this.serializer.Populate(reader, entity);
                }
            }
            else
            {
                var exception = await this.BuildExceptionFromResponse(response);
                throw exception;
            }
        }

        private async Task<NestClientException> BuildExceptionFromResponse(HttpResponseMessage response)
        {
            var errorResponseStream = await response.Content.ReadAsStreamAsync();

            using (var reader = new StreamReader(errorResponseStream))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var error = this.serializer.Deserialize<NestClientError>(jsonReader);
                return new NestClientException(error.ErrorMessage, response);
            }
        }

        internal async Task PutItemAsync<T>(string url, object entity, T change)
        {
            using (var writer = new StringWriter())
            {
                this.serializer.Serialize(writer, change);
                var payload = writer.ToString();
                await this.ExecuteRequestAsync("PUT", url, payload, entity);
            }
        }
        internal async Task PatchItemAsync<T>(string url, object entity, T change)
        {
            using (var writer = new StringWriter())
            {
                this.serializer.Serialize(writer, change);
                var payload = writer.ToString();
                await this.ExecuteRequestAsync("PATCH", url, payload, entity);
            }
        }

        private async Task<T> GetItemAsync<T>(string url) where T: class
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

        private async Task<Dictionary<string, T>> GetItemsAsync<T>(string url)
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
            var thermostatsUrl = string.Format(NestClient.ThermostatsQuery, null, this.AccessToken);
            var pendingThermostats = this.GetItemsAsync<Thermostat>(thermostatsUrl);
            return await pendingThermostats;
        }

        public async Task<Thermostat> GetThermostatAsync(string thermostatID)
        {
            var thermostatsUrl = string.Format(NestClient.ThermostatsQuery, thermostatID, this.AccessToken);
            var pendingThermostat = this.GetItemAsync<Thermostat>(thermostatsUrl);
            return await pendingThermostat;
        }

        public async Task<Dictionary<string, Protect>> GetProtectsAsync()
        {
            var protectsUrl = string.Format(NestClient.ProtectsQuery, null, this.AccessToken);
            var pendingProtects = this.GetItemsAsync<Protect>(protectsUrl);
            return await pendingProtects;
        }

        public async Task<Protect> GetProtectAsync(string protectID)
        {
            var protectsUrl = string.Format(NestClient.ProtectsQuery, protectID, this.AccessToken);
            var pendingProtect = this.GetItemAsync<Protect>(protectsUrl);
            return await pendingProtect;
        }

        public async Task<Dictionary<string, Structure>> GetStructuresAsync()
        {
            var structuresUrl = string.Format(NestClient.StructuresQuery, null, this.AccessToken);
            var pendingStructures = this.GetItemsAsync<Structure>(structuresUrl);
            return await pendingStructures;
        }

        public async Task<Structure> GetStructureAsync(string structureID)
        {
            var structuresUrl = string.Format(NestClient.StructuresQuery, structureID, this.AccessToken);
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
