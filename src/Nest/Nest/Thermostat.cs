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
        public Thermostat()
        {
        }

        [JsonProperty("humidity")]
        public float Humidity { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("temperature_scale")]
        public string TemperatureScale { get; set; }

        [JsonProperty("is_using_emergency_heat")]
        public bool IsUsingEmergencyHeat { get; set; }

        [JsonProperty("has_fan")]
        public bool HasFan { get; set; }

        [JsonProperty("software_version")]
        public string SoftwareVersion { get; set; }

        [JsonProperty("has_leaf")]
        public bool HasLeaf { get; set; }

        [JsonProperty("where_id")]
        public string WhereID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("can_heat")]
        public bool CanHeat { get; set; }

        [JsonProperty("can_cool")]
        public bool CanCool { get; set; }

        [JsonProperty("hvac_mode")]
        public string HvacMode { get; set; }

        [JsonProperty("target_temperature_c")]
        public float TargetTemperatureCelsius { get; set; }

        [JsonProperty("target_temperature_high_c")]
        public float TargetTemperatureHighCelsius { get; set; }

        [JsonProperty("target_temperature_low_c")]
        public float TargetTemperatureLowCelsius { get; set; }

        [JsonProperty("target_temperature_f")]
        public float TargetTemperatureFahrenheit { get; set; }

        [JsonProperty("target_temperature_high_f")]
        public float TargetTemperatureHighFahrenheit { get; set; }

        [JsonProperty("target_temperature_low_f")]
        public float TargetTemperatureLowFahrenheit { get; set; }

        [JsonProperty("ambient_temperature_c")]
        public float AmbientTemperatureCelsius { get; set; }

        [JsonProperty("ambient_temperature_f")]
        public float AmbientTemperatureFahrenheit { get; set; }

        [JsonProperty("away_temperature_high_c")]
        public float AwayTemperatureHighCelsius { get; set; }

        [JsonProperty("away_temperature_low_c")]
        public string AwayTemperatureLowCelsius { get; set; }

        [JsonProperty("away_temperature_high_f")]
        public string AwayTemperatureHighFahrenheit { get; set; }

        [JsonProperty("away_temperature_low_f")]
        public string AwayTemperatureLowFahrenheit { get; set; }

        [JsonProperty("structure_id")]
        public string StructureID { get; set; }

        [JsonProperty("fan_timer_active")]
        public bool FanTimerActive { get; set; }

        [JsonProperty("name_long")]
        public string NameLong { get; set; }

        [JsonProperty("is_online")]
        public bool IsOnline { get; set; }

        [JsonProperty("last_connection")]
        public DateTimeOffset LastConnection { get; set; }

        [JsonProperty("hvac_state")]
        public string HvacState { get; set; }
    }
}
