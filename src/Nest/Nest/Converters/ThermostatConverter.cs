using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Converters
{
    internal class ThermostatConverter : CustomCreationConverter<Thermostat>
    {
        public ThermostatConverter(NestClient client)
        {
            this.client = client;
        }

        private NestClient client;

        public override Thermostat Create(Type objectType)
        {
            return new Thermostat(this.client);
        }
    }
}
