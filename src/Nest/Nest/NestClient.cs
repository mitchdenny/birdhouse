using System;
using System.Collections.Generic;
using System.Linq;
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
            return null;
        }
    }
}
