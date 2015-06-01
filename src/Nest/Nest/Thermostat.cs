using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
    public class Thermostat
    {
        internal Thermostat(NestClient client)
        {
            this.client = client;
        }

        private NestClient client;
    }
}
