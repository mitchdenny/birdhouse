using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
    public class SmokeAlarm : Device
    {
        internal SmokeAlarm(NestClient client) : base(client)
        {
            this.client = client;
        }

        private NestClient client;

        [JsonProperty("battery_health")]
        public string BatteryHealth { get; internal set; }

        [JsonProperty("co_alarm_state")]
        public string CoAlarmState { get; internal set; }

        [JsonProperty("smoke_alarm_state")]
        public string SmokeAlarmState { get; internal set; }

        [JsonProperty("ui_color_state")]
        public string UiColorState { get; internal set; }

        [JsonProperty("is_manual_test_active")]
        public bool IsManualTestActive { get; internal set; }

        [JsonProperty("last_manual_test_time")]
        public DateTimeOffset LastManualTestTime { get; internal set; }
    }
}
