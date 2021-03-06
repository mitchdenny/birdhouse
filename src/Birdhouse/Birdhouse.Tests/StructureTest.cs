﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Birdhouse.Tests
{
    [TestClass()]
    public class StructureTest
    {
        [TestMethod]
        public async Task GetDevicesAsyncOnOfficeReturnsOneDevice()
        {
            var client = new NestClient(TestConstants.AccessToken);
            var structure = await client.GetStructureAsync(TestConstants.OfficeStructureID);
            var devices = await structure.GetDevicesAsync();

            Assert.AreEqual(1, devices.Count());
        }

        [TestMethod]
        public async Task GetDevicesAsyncOnHouseReturnsFourDevices()
        {
            var client = new NestClient(TestConstants.AccessToken);
            var structure = await client.GetStructureAsync(TestConstants.HouseStructureID);
            var devices = await structure.GetDevicesAsync();

            Assert.AreEqual(4, devices.Count());
        }

        [TestMethod]
        public async Task UpdateEtaAsyncDoesntFail()
        {
            var client = new NestClient(TestConstants.AccessToken);
            var structure = await client.GetStructureAsync(TestConstants.OfficeStructureID);
            await structure.UpdateEtaAsync(
                Guid.NewGuid().ToString(),
                DateTimeOffset.Now.AddMinutes(10),
                DateTimeOffset.Now.AddMinutes(20)
                );
        }
    }
}
