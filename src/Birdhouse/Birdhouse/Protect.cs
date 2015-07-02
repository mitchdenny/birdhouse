using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birdhouse
{
    public class Protect : Device
    {
        internal Protect(NestClient client) : base(client)
        {
            this.client = client;
        }

        private NestClient client;

        [JsonProperty("battery_health")]
        public BatteryHealth BatteryHealth { get; internal set; }

        [JsonProperty("co_alarm_state")]
        public CoAlarmState CoAlarmState { get; internal set; }

        [JsonProperty("smoke_alarm_state")]
        public SmokeAlarmState SmokeAlarmState { get; internal set; }

        [JsonProperty("ui_color_state")]
        public UIColorState UiColorState { get; internal set; }

        [JsonProperty("is_manual_test_active")]
        public bool IsManualTestActive { get; internal set; }

        [JsonProperty("last_manual_test_time")]
        public DateTimeOffset LastManualTestTime { get; internal set; }
    }
}
