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

        public NestClient(string accessToken)
        {
            this.accessToken = accessToken;
        }

        private string accessToken;

        public async Task<IEnumerable<Thermostat>> GetThermostatsAsync()
        {
            var thermostatsUrl = string.Format(NestClient.ThermostatsQuery, accessToken);

            var client = new HttpClient();
            var response = await client.GetAsync(thermostatsUrl);
            var payloadAsString = await response.Content.ReadAsStringAsync();

            var payload = JObject.Parse(payloadAsString);

            var thermostats = new List<Thermostat>();

            foreach (var property in payload.Properties())
            {
                var thermostat = property.Value.ToObject<Thermostat>();
                thermostats.Add(thermostat);
            }

            return thermostats;
        }
    }
}
