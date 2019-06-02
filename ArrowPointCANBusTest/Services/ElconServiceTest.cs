using System;
using ArrowPointCANBusTool.Charger;
using ArrowPointCANBusTool.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrowPointCANBusTest.Services
{
    [TestClass]
    public class ElconServiceTest
    {
        [TestMethod]
        public void ConnectTest()
        {
            CanService canService = new CanService();

            canService.ConnectViaLoopBack();
            Assert.IsTrue(canService.IsConnected());

            ElconService elconService = new ElconService(canService, 230, 10);
            elconService.StartCharge();
            Assert.IsTrue(elconService.IsOutputOn());

            canService.Disconnect();
            Assert.IsFalse(canService.IsConnected());
        }
    }
}
