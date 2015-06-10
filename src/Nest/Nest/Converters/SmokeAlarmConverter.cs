using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Converters
{
    internal class SmokeAlarmConverter : CustomCreationConverter<SmokeAlarm>
    {
        public SmokeAlarmConverter(NestClient client)
        {
            this.client = client;
        }

        private NestClient client;

        public override SmokeAlarm Create(Type objectType)
        {
            return new SmokeAlarm(this.client);
        }
    }
}
