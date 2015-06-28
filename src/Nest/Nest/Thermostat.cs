using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
    public class Thermostat : Device
    {
        internal Thermostat(NestClient client) : base(client)
        {
            this.client = client;
        }

        private NestClient client;

        [JsonProperty("humidity")]
        public float Humidity { get; internal set; }

        [JsonProperty("temperature_scale")]
        public TemperatureScale TemperatureScale { get; internal set; }

        [JsonProperty("is_using_emergency_heat")]
        public bool IsUsingEmergencyHeat { get; internal set; }

        [JsonProperty("has_fan")]
        public bool HasFan { get; internal set; }

        [JsonProperty("has_leaf")]
        public bool HasLeaf { get; internal set; }

        [JsonProperty("can_heat")]
        public bool CanHeat { get; internal set; }

        [JsonProperty("can_cool")]
        public bool CanCool { get; internal set; }

        [JsonProperty("hvac_mode")]
        public HvacMode HvacMode { get; internal set; }

        [JsonProperty("target_temperature_c")]
        public float TargetTemperatureCelsius { get; internal set; }

        [JsonProperty("target_temperature_high_c")]
        public float TargetTemperatureHighCelsius { get; internal set; }

        [JsonProperty("target_temperature_low_c")]
        public float TargetTemperatureLowCelsius { get; internal set; }

        [JsonProperty("target_temperature_f")]
        public float TargetTemperatureFahrenheit { get; internal set; }

        [JsonProperty("target_temperature_high_f")]
        public float TargetTemperatureHighFahrenheit { get; internal set; }

        [JsonProperty("target_temperature_low_f")]
        public float TargetTemperatureLowFahrenheit { get; internal set; }

        [JsonProperty("ambient_temperature_c")]
        public float AmbientTemperatureCelsius { get; internal set; }

        [JsonProperty("ambient_temperature_f")]
        public float AmbientTemperatureFahrenheit { get; internal set; }

        [JsonProperty("away_temperature_high_c")]
        public float AwayTemperatureHighCelsius { get; internal set; }

        [JsonProperty("away_temperature_low_c")]
        public float AwayTemperatureLowCelsius { get; internal set; }

        [JsonProperty("away_temperature_high_f")]
        public float AwayTemperatureHighFahrenheit { get; internal set; }

        [JsonProperty("away_temperature_low_f")]
        public float AwayTemperatureLowFahrenheit { get; internal set; }

        [JsonProperty("fan_timer_active")]
        public bool FanTimerActive { get; internal set; }

        [JsonProperty("last_connection")]
        public DateTimeOffset LastConnection { get; internal set; }

        [JsonProperty("hvac_state")]
        public HvacState HvacState { get; internal set; }
    }
}
