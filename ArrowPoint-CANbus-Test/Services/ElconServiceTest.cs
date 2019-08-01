using System;
using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Services;
using NUnit.Framework;

namespace ArrowPointCANBusTest.Services
{
    [TestFixture]
    public class ElconServiceTest
    {
        [Test]
        public void StartStopChargeTest()
        {
            CanService.Instance.ConnectViaLoopBack();
            Assert.IsTrue(CanService.Instance.IsConnected());

            ElconService elconService = ElconService.Instance;
            elconService.SupplyVoltageLimit = 230;
            elconService.SupplyCurrentLimit = 10;
            
            elconService.StartCharge();

            CanPacket statusPacket = new CanPacket(ElconService.ELCON_CAN_STATUS)
            {
                IsLittleEndian = false
            };
            statusPacket.SetUint16(0, (uint)1600);
            statusPacket.SetUint16(1, (uint)100);
            CanService.Instance.SendMessage(statusPacket);            
            Assert.IsTrue(elconService.IsCharging);

            elconService.StopCharge();
            Assert.IsFalse(elconService.IsCharging);

            CanPacket canPacket = CanService.Instance.LastestCanPacketById(ElconService.ELCON_CAN_COMMAND);
            // Update voltage requested to 0
            Assert.AreEqual(canPacket.Int16Pos3, 0);
            Assert.AreEqual(canPacket.Int16Pos2, 0);

            CanService.Instance.Disconnect();
            Assert.IsFalse(CanService.Instance.IsConnected());
        }

        [Test]
        public void OverVoltageTest()
        {
            ElconService elconService = ElconService.Instance;
            // 198V is the max for the charger
            elconService.SupplyVoltageLimit = 230;
            elconService.SupplyCurrentLimit = 10;
            elconService.RequestedVoltage = 500;
            Assert.AreEqual(elconService.RequestedVoltage, elconService.ChargerVoltageLimit);

            elconService = ElconService.Instance;
            elconService.SupplyVoltageLimit = 120;
            elconService.SupplyCurrentLimit = 10;

            // Power supply voltage is now lower than the max for the charger
            // so the charger can only supply at that voltage
            elconService.RequestedVoltage = elconService.ChargerVoltageLimit;
            Assert.AreEqual(elconService.RequestedVoltage, 120);
        }

        [Test]
        public void OverCurrentTest()
        {
            // Request more current that the charger provides, make sure it steps us down
            ElconService elconService = ElconService.Instance;
            elconService.SupplyVoltageLimit = 230;
            elconService.SupplyCurrentLimit = 10;
            elconService.RequestedCurrent = 80;
            Assert.AreEqual(elconService.RequestedCurrent, elconService.ChargerCurrentLimit);

            // Request more current that the mains provides, make sure it steps us down
            elconService = ElconService.Instance;
            elconService.SupplyVoltageLimit = 230;
            elconService.SupplyCurrentLimit = 10;
            elconService.RequestedCurrent = 20;
            Assert.AreEqual(elconService.RequestedCurrent, 10);
        }

        [Test]
        public void AdjustVoltageTest()
        {
            ElconService elconService = ElconService.Instance;
            elconService.SupplyVoltageLimit = 230;
            elconService.SupplyCurrentLimit = 10;
            elconService.RequestedVoltage = 160;

            Assert.AreEqual(elconService.RequestedVoltage, 160);

            elconService.RequestedVoltage = 150;
            Assert.AreEqual(elconService.RequestedVoltage, 150);

            elconService.RequestedVoltage = 170;
            Assert.AreEqual(elconService.RequestedVoltage, 170);

            elconService.RequestedVoltage = 0;
            Assert.AreEqual(elconService.RequestedVoltage, 0);

            elconService.RequestedVoltage = 120;
            Assert.AreEqual(elconService.RequestedVoltage, 120);

            // Over the max of the charger, so should bring us back down
            elconService.RequestedVoltage = 240;
            Assert.AreEqual(elconService.RequestedVoltage, elconService.ChargerVoltageLimit);

            elconService.RequestedVoltage = 0;
            Assert.AreEqual(elconService.RequestedVoltage, 0);
        }

        [Test]
        public void AdjustCurrentTest()
        {
            ElconService elconService = ElconService.Instance;
            elconService.SupplyVoltageLimit = 230;
            elconService.SupplyCurrentLimit = 46;
            elconService.RequestedCurrent = 8;

            Assert.AreEqual(elconService.RequestedCurrent, 8);

            elconService.RequestedCurrent = 7;
            Assert.AreEqual(elconService.RequestedCurrent, 7);

            elconService.RequestedCurrent = 9;
            Assert.AreEqual(elconService.RequestedCurrent, 9);

            elconService.RequestedCurrent = 0;
            Assert.AreEqual(elconService.RequestedCurrent, 0);

            elconService.RequestedCurrent = 9;
            Assert.AreEqual(elconService.RequestedCurrent, 9);

            // Over the max of the supply, so should bring us back down
            elconService.RequestedCurrent = 59;
            Assert.AreEqual(elconService.RequestedCurrent, 46);

            elconService.RequestedCurrent = 0;
            Assert.AreEqual(elconService.RequestedCurrent, 0);
        }


    }
}
