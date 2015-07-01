using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Nest.Tests
{
    [TestClass()]
    public class ThermostatTest
    {
        [TestMethod()]
        public async Task GetStructureAsyncFromThermostat()
        {
            var client = new NestClient(TestConstants.AccessToken);
            var thermostat = await client.GetThermostatAsync(TestConstants.DownstairsThermostatID);
            var structure = await thermostat.GetStructureAsync();

            Assert.AreEqual("House", structure.Name);
        }

        [TestMethod()]
        public async Task GetWhereAsyncFromThermostat()
        {
            var client = new NestClient(TestConstants.AccessToken);
            var thermostat = await client.GetThermostatAsync(TestConstants.DownstairsThermostatID);
            var where = await thermostat.GetWhereAsync();

            Assert.AreEqual("Downstairs", where.Name);
        }

        [TestMethod()]
        public async Task UpdateHvacModeAsyncAlternatesBetweenOffAndHeatCool()
        {
            var client = new NestClient(TestConstants.AccessToken);
            var thermostat = await client.GetThermostatAsync(TestConstants.DownstairsThermostatID);

            await thermostat.UpdateHvacModeAsync(HvacMode.Off);
            Assert.AreEqual(HvacMode.Off, thermostat.HvacMode);

            await thermostat.UpdateHvacModeAsync(HvacMode.HeatCool);
        }

        [TestMethod()]
        public async Task UpdateFanTimerActiveAsyncAlternatesBetweenTrueAndFalse()
        {
            var client = new NestClient(TestConstants.AccessToken);
            var thermostat = await client.GetThermostatAsync(TestConstants.DownstairsThermostatID);
            var originalState = thermostat.FanTimerActive;

            await thermostat.UpdateFanTimerActiveAsync(!originalState);
            Assert.AreEqual(!originalState, thermostat.FanTimerActive);
        }
        [TestMethod()]
        public async Task UpdateTargetTemperatureSucceeds()
        {
            var client = new NestClient(TestConstants.AccessToken);
            var thermostat = await client.GetThermostatAsync(TestConstants.UpstairsThermostatID);
            var targetTemperature = thermostat.TargetTemperatureCelsius + 1;

            await thermostat.UpdateTargetTemperatureAsync(targetTemperature, TemperatureScale.Celsius);
            Assert.AreEqual(targetTemperature, thermostat.TargetTemperatureCelsius);

            await thermostat.UpdateTargetTemperatureAsync(targetTemperature - 1, TemperatureScale.Celsius);
        }

        [TestMethod()]
        public async Task UpdateTargetTemperatureHighLowSucceeds()
        {
            var client = new NestClient(TestConstants.AccessToken);
            var thermostat = await client.GetThermostatAsync(TestConstants.DownstairsThermostatID);
            var targetTemperatureHigh = thermostat.TargetTemperatureHighCelsius + 1;
            var targetTemperatureLow = thermostat.TargetTemperatureLowCelsius + 1;

            await thermostat.UpdateTargetTemperatureAsync(targetTemperatureHigh, targetTemperatureLow, TemperatureScale.Celsius);
            Assert.AreEqual(targetTemperatureHigh, thermostat.TargetTemperatureHighCelsius);
            Assert.AreEqual(targetTemperatureLow, thermostat.TargetTemperatureLowCelsius);

            await thermostat.UpdateTargetTemperatureAsync(targetTemperatureHigh - 1, targetTemperatureLow - 1, TemperatureScale.Celsius);
        }
    }
}
