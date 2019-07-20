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
            
            TDKService.Instance.ChargerIpAddress = ChargerIpAddress;
            TDKService.Instance.ChargerIpPort = ChargerIpPort;
            TDKService.Instance.SupplyVoltageLimit = 230;
            TDKService.Instance.SupplyCurrentLimit = 10;
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            tdkSimulator?.StopSimulator();
        }

        [Test]
        public void CreateChargeService()
        {
            BatteryChargeService batteryChargeService = BatteryChargeService.Instance;
            Assert.AreEqual(batteryChargeService.ChargeToPercentage, 100);
        }

        [Test]
        public void BasicChargeTest()
        {

            CanService.Instance.ConnectViaLoopBack();
            
            CanPacket bmuOneEngaged = new CanPacket(0x6F7);
            bmuOneEngaged.SetUint8(1,BMU.PRECHARGE_STATUS_RUN);
            bmuOneEngaged.SetUint8(0, 0x04);

            CanPacket bmuTwoEngaged = new CanPacket(0x2F7);
            bmuTwoEngaged.SetUint8(1, BMU.PRECHARGE_STATUS_RUN);
            bmuTwoEngaged.SetUint8(0, 0x04);

            BatteryChargeService batteryChargeService = BatteryChargeService.Instance;
            batteryChargeService.UseTimerUpdateLoop = false;
            batteryChargeService.ChargerService = TDKService.Instance;

            Assert.IsFalse(batteryChargeService.IsCharging);
            batteryChargeService.StartCharge();

            BatteryChargeService.Instance.BatteryService.BatteryData.GetBMU(0).CanPacketReceived(bmuOneEngaged);
            BatteryChargeService.Instance.BatteryService.BatteryData.GetBMU(1).CanPacketReceived(bmuTwoEngaged);

            Assert.IsTrue(batteryChargeService.IsCharging);
            batteryChargeService.StopCharge();
            Assert.IsFalse(batteryChargeService.IsCharging);

            CanService.Instance.Disconnect();
        }

    }
}
