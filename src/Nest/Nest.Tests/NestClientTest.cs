using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Nest.Tests
{
    [TestClass()]
    public class NestClientTest
    {
        [TestMethod()]
        public async Task GetThermostatsAsyncReturnsFourThermostats()
        {
            var client = new NestClient(TestConstants.AccessToken);
            var thermostats = await client.GetThermostatsAsync();
            Assert.AreEqual(3, thermostats.Count);
        }

        [TestMethod()]
        public async Task GetSmokeAlarmsAsyncReturnsTwoSmokeAlarms()
        {
            var client = new NestClient(TestConstants.AccessToken);
            var smokeAlarms = await client.GetSmokeAlarmsAsync();
            Assert.AreEqual(2, smokeAlarms.Count);
        }

        [TestMethod()]
        public async Task GetStructuresAsyncReturnsTwoStructures()
        {
            var client = new NestClient(TestConstants.AccessToken);
            var structures = await client.GetStructuresAsync();
            Assert.AreEqual(2, structures.Count);
        }
    }
}
