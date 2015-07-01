using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
    public class NestClientError
    {
        [JsonProperty("error")]
        public string ErrorMessage { get; internal set; }
    }
}
