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
        internal SmokeAlarm(NestClient client)
        {
            this.client = client;
        }

        private NestClient client;

        [JsonProperty("battery_health")]
        public string BatteryHealth { get; set; }

        [JsonProperty("co_alarm_state")]
        public string CoAlarmState { get; set; }

        [JsonProperty("smoke_alarm_state")]
        public string SmokeAlarmState { get; set; }

        [JsonProperty("ui_color_state")]
        public string UiColorState { get; set; }

        [JsonProperty("is_manual_test_active")]
        public bool IsManualTestActive { get; set; }

        [JsonProperty("last_manual_test_time")]
        public DateTimeOffset LastManualTestTime { get; set; }
    }
}
