using System;
using ArrowPointCANBusTool.CanLibrary;
using ArrowPointCANBusTool.Model;
using ArrowPointCANBusTool.Services;
using NUnit.Framework;
using Prohelion.CanLibrary;

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
            SOCcanPacket.FloatPos0 = 100;  // AMP Hours
            SOCcanPacket.FloatPos1 = 89;   // Percentage SOC

            bmu.CanPacketReceived(SOCcanPacket);

            Assert.AreEqual(bmu.SOCAh, (float)100);
            Assert.AreEqual(bmu.SOCPercentage, (float)89);

            CanService.Instance.Disconnect();
        }

    }
}
