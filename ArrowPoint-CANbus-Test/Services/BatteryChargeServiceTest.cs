using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Model;
using ArrowPointCANBusTool.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArrowPointCANBusTest.Services
{
    [TestFixture]
    [NonParallelizable]
    class BatteryChargeServiceTest
    {
        private TDKSimulator tdkSimulator;

        private readonly bool USE_SIMULATOR = true;
        private string ChargerIpAddress;
        private int ChargerIpPort;

        [SetUp]
        public void RunBeforeAnyTests()
        {
            if (USE_SIMULATOR)
            {
                ChargerIpAddress = "127.0.0.1";
                ChargerIpPort = 10000;

                tdkSimulator = new TDKSimulator
                {
                    SimulatorIpAddress = ChargerIpAddress,
                    SimulatorIpPort = ChargerIpPort
                };
                tdkSimulator.StartSimulator();
                Thread.Sleep(100);
            }
            else
            {
                ChargerIpAddress = "192.168.14.35";
                ChargerIpPort = 100;
            }

        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            tdkSimulator?.StopSimulator();
        }

        [Test]
        [NonParallelizable]
        public void CreateChargeService()
        {
            BatteryChargeService batteryChargeService = BatteryChargeService.NewInstance;
            Assert.AreEqual(batteryChargeService.ChargeToPercentage, 100);
        }

        private TDKService NewTDKService()
        {
            TDKService tdkService = TDKService.NewInstance;

            tdkService.ChargerIpAddress = ChargerIpAddress;
            tdkService.ChargerIpPort = ChargerIpPort;
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 10;

            return tdkService;
        }

        private void EngageContactors(Battery battery)
        {
            CanPacket bmuOneEngaged = new CanPacket(0x6F7);
            bmuOneEngaged.SetUint8(1, BMU.PRECHARGE_STATUS_RUN);
            bmuOneEngaged.SetUint8(0, 0x04);

            CanPacket bmuTwoEngaged = new CanPacket(0x2F7);
            bmuTwoEngaged.SetUint8(1, BMU.PRECHARGE_STATUS_RUN);
            bmuTwoEngaged.SetUint8(0, 0x04);

            CanPacket bmuOneES = new CanPacket(0x6FD);
            bmuOneES.SetUint32(0, 0x00000080);

            CanPacket bmuTwoES = new CanPacket(0x2FD);
            bmuTwoES.SetUint32(0, 0x00000080);

            battery.GetBMU(0).CanPacketReceived(bmuOneEngaged);
            battery.GetBMU(0).CanPacketReceived(bmuOneES);
            battery.GetBMU(1).CanPacketReceived(bmuTwoEngaged);
            battery.GetBMU(1).CanPacketReceived(bmuTwoES);
        }

        private void SendBatteryHeartBeat(CanService canService, Battery battery)
        {
            CanPacket bmuOne = new CanPacket(0x600);
            CanPacket bmuTwo = new CanPacket(0x200);

            canService.SendMessage(bmuOne);
            canService.SendMessage(bmuTwo);
            battery.GetBMU(0).CanPacketReceived(bmuOne);
            battery.GetBMU(1).CanPacketReceived(bmuTwo);
        }

        private void SetChargeVoltageError(Battery battery, int voltageError, int cellTempMargin)
        {
            CanPacket ccVEOne = new CanPacket(0x6F6);
            CanPacket ccVETwo = new CanPacket(0x2F6);

            ccVEOne.SetInt16(0, voltageError);
            ccVETwo.SetInt16(0, voltageError);
            ccVEOne.SetInt16(1, cellTempMargin);
            ccVETwo.SetInt16(1, cellTempMargin);

            battery.GetBMU(0).CanPacketReceived(ccVEOne);
            battery.GetBMU(1).CanPacketReceived(ccVETwo);
        }

        [Test]
        [NonParallelizable]
        public void BasicChargeStartStopTest()
        {
            BatteryChargeService batteryChargeService = BatteryChargeService.NewInstance;
            batteryChargeService.UseTimerUpdateLoop = false;
            batteryChargeService.ChargerService = NewTDKService();

            Assert.IsFalse(batteryChargeService.IsCharging, "Battery is charging when it should not be");
            batteryChargeService.StartCharge();

            EngageContactors(batteryChargeService.BatteryService.BatteryData);

            Assert.IsTrue(batteryChargeService.IsCharging, "Battery is not charging when it should be");

            batteryChargeService.StopCharge();
            Assert.IsFalse(batteryChargeService.IsCharging, "Battery is charging when it should not be");
        }

        [Test]
        [NonParallelizable]
        public void BalancingChargeTest()
        {
            BatteryChargeService batteryChargeService = BatteryChargeService.NewInstance;
            batteryChargeService.UseTimerUpdateLoop = false;

            CanService canService = CanService.NewInstance;
            canService.ConnectViaLoopBack();

            TDKService tdkService = NewTDKService();

            batteryChargeService.ChargerService = tdkService;
            batteryChargeService.BatteryService.BatteryData.ComponentCanService = canService;
            batteryChargeService.BatteryService.BatteryData.GetBMU(0).ComponentCanService = canService;
            batteryChargeService.BatteryService.BatteryData.GetBMU(1).ComponentCanService = canService;

            Assert.IsFalse(batteryChargeService.IsCharging, "Battery is charging when it should not be");
            batteryChargeService.StartCharge();

            EngageContactors(batteryChargeService.BatteryService.BatteryData);
            Assert.IsTrue(batteryChargeService.IsCharging, "Battery is not charging when it should be");

            // Battery is now setup in normal state, run the charge loop
            batteryChargeService.RequestedCurrent = 5;
            batteryChargeService.RequestedVoltage = 45;

            SendBatteryHeartBeat(canService, batteryChargeService.BatteryService.BatteryData);
            SetChargeVoltageError(batteryChargeService.BatteryService.BatteryData, 100, -50);            

            batteryChargeService.ChargerUpdateInner();
            tdkService.ChargerUpdateInner();
            tdkService.ChargerUpdateInner();

            Assert.AreEqual(batteryChargeService.RequestedVoltage, batteryChargeService.ChargerVoltage,"Requested Voltage has not flowed through");
            Assert.IsTrue(batteryChargeService.ChargerCurrent > 0,"Battery does not appear to be charging");

            batteryChargeService.StopCharge();
            Assert.IsFalse(batteryChargeService.IsCharging, "Battery is charging when it should not be");
        }
    }
}
