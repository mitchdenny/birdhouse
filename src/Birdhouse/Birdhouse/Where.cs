using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birdhouse
{
    public class Where
    {
        [JsonProperty("where_id")]
        public string WhereID { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }
    }
}
