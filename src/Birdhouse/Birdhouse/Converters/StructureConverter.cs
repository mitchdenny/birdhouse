using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birdhouse.Converters
{
    internal class StructureConverter : CustomCreationConverter<Structure>
    {
        public StructureConverter(NestClient client)
        {
            this.client = client;
        }

        private NestClient client;

        public override Structure Create(Type objectType)
        {
            return new Structure(this.client);
        }
    }
}
