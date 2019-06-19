using System;
using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Model;
using ArrowPointCANBusTool.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrowPointCANBusTest.Model
{
    [TestClass]
    public class BMUTest
    {
        [TestMethod]
        public void SetupBMU()
        {
            CanService canService = new CanService();
            canService.ConnectViaLoopBack();

            BMU bmu = new BMU(canService,0x200, true);
            Assert.IsTrue(bmu.InRange(new CanPacket(0x202)));
            Assert.IsFalse(bmu.InRange(new CanPacket(0x2FF)));
        }

        [TestMethod]
        public void SimulateSOCCan()
        {
            CanService canService = new CanService();
            canService.ConnectViaLoopBack();

            BMU bmu = new BMU(canService,0x200, true);

            CanPacket SOCcanPacket = new CanPacket(0x2F4);
            SOCcanPacket.SetFloat(0, 100);  // AMP Hours
            SOCcanPacket.SetFloat(1, 89);   // Percentage SOC

            bmu.CanPacketReceived(SOCcanPacket);

            Assert.AreEqual(bmu.SOCAh, (float)100);
            Assert.AreEqual(bmu.SOCPercentage, (float)89);            
        }

    }
}
