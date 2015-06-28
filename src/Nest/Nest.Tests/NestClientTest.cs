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
        public async Task GetProtectsAsyncReturnsTwoProtects()
        {
            var client = new NestClient(TestConstants.AccessToken);
            var protects = await client.GetProtectsAsync();
            Assert.AreEqual(2, protects.Count);
        }

        [TestMethod()]
        public async Task GetStructuresAsyncReturnsTwoStructures()
        {
            var client = new NestClient(TestConstants.AccessToken);
            var structures = await client.GetStructuresAsync();
            Assert.AreEqual(2, structures.Count);
        }

        [TestMethod()]
        public async Task GetDevicesAsyncReturnsFiveDevices()
        {
            var client = new NestClient(TestConstants.AccessToken);
            var devices = await client.GetDevicesAsync();
            Assert.AreEqual(5, devices.Count);
        }
    }
}
