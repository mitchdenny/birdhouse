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
        public NestClient(string accessToken)
        {
            this.accessToken = accessToken;
        }

        private string accessToken;

        public async Task<IEnumerable<Thermostat>> GetThermostatsAsync()
        {
            var thermostatsUri = string.Format(
                "https://developer-api.nest.com/devices/thermostats/?auth={0}",
                this.accessToken
                );

            var client = new HttpClient();
            var response = await client.GetAsync(thermostatsUri);
            var payloadAsString = await response.Content.ReadAsStringAsync();

            return null;
        }
    }
}
