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

        [OneTimeSetUp]
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
                ChargerIpAddress = "192.168.20.35";
                ChargerIpPort = 100;
            }

        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            tdkSimulator?.StopSimulator();
        }

        [SetUp]
        public void ResetSimulator()
        {
            tdkSimulator.ResetValues();
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
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 10;
            
            tdkService.Connect(ChargerIpAddress, ChargerIpPort);

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

            if (battery.GetBMU(0) != null)
            {
                battery.GetBMU(0).CanPacketReceived(bmuOneEngaged);
                battery.GetBMU(0).CanPacketReceived(bmuOneES);
            }

            if (battery.GetBMU(1) != null)
            {
                battery.GetBMU(1).CanPacketReceived(bmuTwoEngaged);
                battery.GetBMU(1).CanPacketReceived(bmuTwoES);
            }                
        }

        private void DisengageContactors(Battery battery)
        {
            CanPacket bmuOneEngaged = new CanPacket(0x6F7);
            bmuOneEngaged.SetUint8(1, BMU.PRECHARGE_STATUS_IDLE);
            bmuOneEngaged.SetUint8(0, 0x00);

            CanPacket bmuTwoEngaged = new CanPacket(0x2F7);
            bmuTwoEngaged.SetUint8(1, BMU.PRECHARGE_STATUS_IDLE);
            bmuTwoEngaged.SetUint8(0, 0x00);

            CanPacket bmuOneES = new CanPacket(0x6FD);
            bmuOneES.SetUint32(0, 0x00000000);

            CanPacket bmuTwoES = new CanPacket(0x2FD);
            bmuTwoES.SetUint32(0, 0x00000000);

            if (battery.GetBMU(0) != null)
            {
                battery.GetBMU(0).CanPacketReceived(bmuOneEngaged);
                battery.GetBMU(0).CanPacketReceived(bmuOneES);
            }

            if (battery.GetBMU(1) != null)
            {
                battery.GetBMU(1).CanPacketReceived(bmuTwoEngaged);
                battery.GetBMU(1).CanPacketReceived(bmuTwoES);
            }
        }

        private void SendBatteryHeartBeat(CanService canService, Battery battery)
        {
            CanPacket bmuOne = new CanPacket(0x600);
            CanPacket bmuTwo = new CanPacket(0x200);

            CanPacket cmuOne = new CanPacket(0x601);
            CanPacket cmuTwo = new CanPacket(0x201);

            canService.SendMessage(bmuOne);
            canService.SendMessage(bmuTwo);

            canService.SendMessage(cmuOne);
            canService.SendMessage(cmuTwo);

            if (battery.GetBMU(0) != null) battery.GetBMU(0).CanPacketReceived(bmuOne);
            if (battery.GetBMU(1) != null) battery.GetBMU(1).CanPacketReceived(bmuTwo);

            if (battery.GetBMU(0) != null) battery.GetBMU(0).GetCMU(0).CanPacketReceived(cmuOne);
            if (battery.GetBMU(1) != null) battery.GetBMU(1).GetCMU(0).CanPacketReceived(cmuTwo);

        }

        private void SetChargeVoltageError(Battery battery, int voltageError, int cellTempMargin)
        {
            CanPacket ccVEOne = new CanPacket(0x6F6);
            CanPacket ccVETwo = new CanPacket(0x2F6);

            ccVEOne.SetInt16(0, voltageError);
            ccVETwo.SetInt16(0, voltageError);
            ccVEOne.SetInt16(1, cellTempMargin);
            ccVETwo.SetInt16(1, cellTempMargin);

            if (battery.GetBMU(0) != null) battery.GetBMU(0).CanPacketReceived(ccVEOne);
            if (battery.GetBMU(1) != null) battery.GetBMU(1).CanPacketReceived(ccVETwo);
        }

        private void SetCellVoltages(Battery battery, uint voltages)
        {

            uint baseCanId = 0x601;

            CanPacket PCBcanPacket = new CanPacket(baseCanId);
            PCBcanPacket.SetInt16(2, 520);  // PCB Temp
            PCBcanPacket.SetInt16(3, 320);  // PCB Temp

            CanPacket Battery1canPacket1 = new CanPacket(baseCanId + 1);
            Battery1canPacket1.SetUint16(0, voltages);
            Battery1canPacket1.SetUint16(1, voltages);
            Battery1canPacket1.SetUint16(2, voltages);
            Battery1canPacket1.SetUint16(3, voltages);            

            CanPacket Battery1canPacket2 = new CanPacket(baseCanId + 2);
            Battery1canPacket2.SetUint16(0, voltages);
            Battery1canPacket2.SetUint16(1, voltages);
            Battery1canPacket2.SetUint16(2, voltages);
            Battery1canPacket2.SetUint16(3, voltages);

            if (battery.GetBMU(0) != null) battery.GetBMU(0).GetCMU(0).TestCanPacketReceived(PCBcanPacket);
            if (battery.GetBMU(0) != null) battery.GetBMU(0).GetCMU(0).TestCanPacketReceived(Battery1canPacket1);
            if (battery.GetBMU(0) != null) battery.GetBMU(0).GetCMU(0).TestCanPacketReceived(Battery1canPacket2);

            baseCanId = 0x201;

            CanPacket PCBcanPacket2 = new CanPacket(baseCanId);
            PCBcanPacket.SetInt16(2, 520);  // PCB Temp
            PCBcanPacket.SetInt16(3, 320);  // PCB Temp

            CanPacket Battery2canPacket1 = new CanPacket(baseCanId + 1);
            Battery2canPacket1.SetUint16(0, voltages);
            Battery2canPacket1.SetUint16(1, voltages);
            Battery2canPacket1.SetUint16(2, voltages);
            Battery2canPacket1.SetUint16(3, voltages);

            CanPacket Battery2canPacket2 = new CanPacket(baseCanId + 2);
            Battery2canPacket2.SetUint16(0, voltages);
            Battery2canPacket2.SetUint16(1, voltages);
            Battery2canPacket2.SetUint16(2, voltages);
            Battery2canPacket2.SetUint16(3, voltages);

            if (battery.GetBMU(1) != null) battery.GetBMU(1).GetCMU(0).TestCanPacketReceived(PCBcanPacket2);
            if (battery.GetBMU(1) != null) battery.GetBMU(1).GetCMU(0).TestCanPacketReceived(Battery2canPacket1);
            if (battery.GetBMU(1) != null) battery.GetBMU(1).GetCMU(0).TestCanPacketReceived(Battery2canPacket2);

        }

        [Test]
        [NonParallelizable]
        public async Task BasicChargeStartStopTest()
        {
            BatteryChargeService batteryChargeService = BatteryChargeService.NewInstance;
            batteryChargeService.UseTimerUpdateLoop = false;

            CanService canService = CanService.NewInstance;
            canService.ConnectViaLoopBack();
            
            tdkSimulator.BatteryConnected = true;

            batteryChargeService.SetCharger(NewTDKService());
            batteryChargeService.BatteryService.BatteryData.ComponentCanService = canService;

            if (batteryChargeService.BatteryService.BatteryData.GetBMU(0) != null)
                batteryChargeService.BatteryService.BatteryData.GetBMU(0).ComponentCanService = canService;

            if (batteryChargeService.BatteryService.BatteryData.GetBMU(1) != null)
                batteryChargeService.BatteryService.BatteryData.GetBMU(1).ComponentCanService = canService;

            uint state = batteryChargeService.ChargerState;

            Assert.IsTrue(state != CanReceivingNode.STATE_NA, "Charger does not seem to be there");

            Assert.IsFalse(batteryChargeService.IsCharging, "Battery is charging when it should not be as it has not yet been started");

            // Bit out of order but we simulate the contactors engaging now as we can't insert it during the call to StartCharge
            EngageContactors(batteryChargeService.BatteryService.BatteryData);

            // Battery is now setup in normal state, run the charge loop
            batteryChargeService.RequestedCurrent = 5;
            batteryChargeService.RequestedVoltage = 32;
            batteryChargeService.BatteryService.BatteryData.ParallelStrings = 1;
            SetCellVoltages(batteryChargeService.BatteryService.BatteryData, 4100);
            SendBatteryHeartBeat(canService, batteryChargeService.BatteryService.BatteryData);

            Assert.IsTrue(await batteryChargeService.StartCharge().ConfigureAwait(true), "Charger start failed");           
            Assert.IsTrue(batteryChargeService.IsCharging, "Battery is not charging when it should be");

            // Bit out of order but we simulate the contactors disengaging now as we can't insert it during the call to StartCharge
            DisengageContactors(batteryChargeService.BatteryService.BatteryData);

            await batteryChargeService.StopCharge().ConfigureAwait(false);
            Assert.IsFalse(batteryChargeService.IsCharging, "Battery is charging when it should not be");
        }

        [Test]
        [NonParallelizable]
        public async Task BalancingChargeTest()
        {
            BatteryChargeService batteryChargeService = BatteryChargeService.NewInstance;
            batteryChargeService.UseTimerUpdateLoop = false;

            CanService canService = CanService.NewInstance;
            canService.ConnectViaLoopBack();

            TDKService tdkService = NewTDKService();
            tdkSimulator.BatteryConnected = true;

            batteryChargeService.SetCharger(NewTDKService());
            batteryChargeService.BatteryService.BatteryData.ComponentCanService = canService;

            if (batteryChargeService.BatteryService.BatteryData.GetBMU(0) != null)
                batteryChargeService.BatteryService.BatteryData.GetBMU(0).ComponentCanService = canService;

            if (batteryChargeService.BatteryService.BatteryData.GetBMU(1) != null)
                batteryChargeService.BatteryService.BatteryData.GetBMU(1).ComponentCanService = canService;

            Assert.IsFalse(batteryChargeService.IsCharging, "Battery is charging when it should not be - Point 1");

            // Bit out of order but we simulate the contactors engaging now as we can't insert it during the call to StartCharge
            EngageContactors(batteryChargeService.BatteryService.BatteryData);
                        
            // Battery is now setup in normal state, run the charge loop
            batteryChargeService.RequestedCurrent = 5;
            batteryChargeService.RequestedVoltage = 32;
            batteryChargeService.BatteryService.BatteryData.ParallelStrings = 1;            
            SetCellVoltages(batteryChargeService.BatteryService.BatteryData, 4100);
            SendBatteryHeartBeat(canService, batteryChargeService.BatteryService.BatteryData);

            Assert.IsTrue(await batteryChargeService.StartCharge().ConfigureAwait(false), "Charger start failed");            
            Assert.IsTrue(batteryChargeService.IsCharging, "Battery is not charging when it should be");

            SetChargeVoltageError(batteryChargeService.BatteryService.BatteryData, 100, -50);

            SendBatteryHeartBeat(canService, batteryChargeService.BatteryService.BatteryData);
            batteryChargeService.ChargerUpdateInner();

            tdkService.ChargerUpdateInner();
            tdkService.ChargerUpdateInner();

            Assert.IsTrue(batteryChargeService.IsCharging, "Battery is not charging when it should be - Mark 2");

            // Keep sending heartbeats so we don't time out
            SendBatteryHeartBeat(canService, batteryChargeService.BatteryService.BatteryData);

            Assert.IsTrue(batteryChargeService.IsCharging, "Battery is not charging when it should be - Mark 3");

            Assert.AreEqual(batteryChargeService.RequestedVoltage, batteryChargeService.ChargerActualVoltage,"Requested Voltage has not flowed through");
            Assert.IsTrue(batteryChargeService.ChargerService.RequestedCurrent > 0,"Battery does not appear to be charging");

            Assert.IsTrue(batteryChargeService.IsCharging, "Battery is not charging when it should be - Mark 4");

            for (int i = 0; i < 10; i++)
            {
                batteryChargeService.ChargerUpdateInner();
                tdkService.ChargerUpdateInner();
                SendBatteryHeartBeat(canService, batteryChargeService.BatteryService.BatteryData);
            }

            Assert.IsTrue(batteryChargeService.IsCharging, "Battery is not charging when it should be - Mark 3");

            float batteryChargerCurrent = batteryChargeService.ChargerService.RequestedCurrent;

            // Battery over charged
            SetChargeVoltageError(batteryChargeService.BatteryService.BatteryData, -35, -50);

            for (int i = 0; i < 10; i++)
            {
                batteryChargeService.ChargerUpdateInner();
                tdkService.ChargerUpdateInner();
                SendBatteryHeartBeat(canService, batteryChargeService.BatteryService.BatteryData);
            }

            Assert.IsTrue(batteryChargeService.IsCharging, "Battery is not charging when it should be - Mark 4");
            Assert.IsTrue(batteryChargeService.ChargerService.RequestedCurrent < batteryChargerCurrent, "Current should be going down as we are balancing, but it is not");

            // Bit out of order but we simulate the contactors disengaging now as we can't insert it during the call to StartCharge
            DisengageContactors(batteryChargeService.BatteryService.BatteryData);

            Assert.IsTrue(await batteryChargeService.StopCharge().ConfigureAwait(false), "Battery did not stop as expected");
            Assert.IsFalse(batteryChargeService.IsCharging, "Battery is charging when it should not be as it has been shutdown");
        }
    }
}
