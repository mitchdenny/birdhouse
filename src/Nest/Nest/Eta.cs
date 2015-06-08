using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
    public class Eta
    {
        [JsonProperty("trip_id")]
        public string TripID { get; set; }

        [JsonProperty("estimated_arrival_window_begin")]
        public DateTimeOffset EstimatedArrivalWindowBegin { get; set; }

        [JsonProperty("estimated_arrival_window_end")]
        public DateTimeOffset EstimatedArrivalWindowEnd { get; set; }
    }
}
