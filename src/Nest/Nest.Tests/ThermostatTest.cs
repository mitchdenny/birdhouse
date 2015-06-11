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
    }
}
