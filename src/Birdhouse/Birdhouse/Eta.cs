using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birdhouse
{
    public class Eta
    {
        internal Eta()
        {
        }

        [JsonProperty("trip_id")]
        public string TripID { get; internal set; }

        [JsonProperty("estimated_arrival_window_begin")]
        public DateTimeOffset EstimatedArrivalWindowBegin { get; internal set; }

        [JsonProperty("estimated_arrival_window_end")]
        public DateTimeOffset EstimatedArrivalWindowEnd { get; internal set; }
    }
}
