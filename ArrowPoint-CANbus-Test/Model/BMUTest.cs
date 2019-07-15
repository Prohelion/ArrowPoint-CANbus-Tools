using System;
using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Model;
using ArrowPointCANBusTool.Services;
using NUnit.Framework;

namespace ArrowPointCANBusTest.Model
{
    [TestFixture]
    public class BMUTest
    {
        [Test]
        public void SetupBMU()
        {            
            CanService.Instance.ConnectViaLoopBack();

            BMU bmu = new BMU(0x200, true);
            Assert.IsTrue(bmu.InRange(new CanPacket(0x202)));
            Assert.IsFalse(bmu.InRange(new CanPacket(0x2FF)));

            CanService.Instance.Disconnect();
        }

        [Test]
        public void SimulateSOCCan()
        {
            CanService.Instance.ConnectViaLoopBack();

            BMU bmu = new BMU(0x200, true);

            CanPacket SOCcanPacket = new CanPacket(0x2F4);
            SOCcanPacket.SetFloat(0, 100);  // AMP Hours
            SOCcanPacket.SetFloat(1, 89);   // Percentage SOC

            bmu.CanPacketReceived(SOCcanPacket);

            Assert.AreEqual(bmu.SOCAh, (float)100);
            Assert.AreEqual(bmu.SOCPercentage, (float)89);

            CanService.Instance.Disconnect();
        }

    }
}
