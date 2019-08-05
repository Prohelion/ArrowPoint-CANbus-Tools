using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArrowPointCANBusTool.Services;

namespace ArrowPointCANBusTest.Services
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    [TestFixture]
    [NonParallelizable]
    class TDKServiceTest
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
                ChargerIpAddress = "192.168.20.35";
                ChargerIpPort = 100;
            }
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            tdkSimulator?.StopSimulator();
        }

        private TDKService NewTDKService()
        {
            TDKService tdkService = TDKService.NewInstance;
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 10;
            
            tdkService.Connect(ChargerIpAddress, ChargerIpPort);

            return tdkService;
        }

        [Test]
        [NonParallelizable]
        public void CheckBasicComms()
        {
            TDKService tdkService = NewTDKService();
            tdkService.SendMessageGetResponse("ADR 05");
            Assert.AreEqual("OK", tdkService.SendMessageGetResponse("RMT LOC"));
            Assert.AreEqual("LOC",tdkService.SendMessageGetResponse("RMT?"));
        }


        [Test]
        [NonParallelizable]
        public void CheckTDKNotAvailable()
        {
            // Shutdown the simulator
            RunAfterAnyTests();

            TDKService tdkService = NewTDKService();
            tdkService.SendMessageGetResponse("ADR 05");
            Assert.AreEqual("ERROR", tdkService.SendMessageGetResponse("RMT LOC"));

            // Startup the simulator
            RunBeforeAnyTests();
        }

        [Test]
        [NonParallelizable]
        public void CheckNetworkError()
        {
            TDKService tdkService = NewTDKService();
            
            try
            {
                tdkService.Connect(null, 0);
                tdkService.SendMessageGetResponse("RMT LOC");
            } catch
            {
                Assert.IsTrue(true, "Network should have thrown an exception");
            }

            tdkService.Connect(ChargerIpAddress, ChargerIpPort);

            try
            {
                tdkService.SendMessageGetResponse("RMT LOC");                
            }
            catch
            {
                Assert.Fail("Network should not have thown an exception, look like IP is not set");
            }
        }

        [Test]
        [NonParallelizable]
        public void StartStopChargeTest()
        {
            TDKService tdkService = NewTDKService();

            tdkService.StartCharge();
            Assert.IsTrue(tdkService.IsCharging,"Charger is not charging and should be");

            tdkService.StopCharge();
            Assert.IsFalse(tdkService.IsCharging, "Charger is charging and should be stopped");                        
        }

        [Test]
        [NonParallelizable]
        public void SetChargePower()
        {
            TDKService tdkService = NewTDKService();

            tdkService.StartCharge();
            Assert.IsTrue(tdkService.IsCharging,"Charger is not charging and should be");

            tdkService.RequestedCurrent = 3.2f;
            tdkService.RequestedVoltage = 32.1f;

            // We call it twice as it gets set on the first time and read on the second
            tdkService.ChargerUpdateInner();
            tdkService.ChargerUpdateInner();

            Assert.AreEqual(tdkService.ActualCurrent, 0);
            Assert.AreEqual(tdkService.ActualVoltage, tdkService.RequestedVoltage,0.5);

            tdkService.StopCharge();
            Assert.IsFalse(tdkService.IsCharging, "Charger is still charging and should be stopped");
        }

        [Test]
        [NonParallelizable]
        public void OverVoltageTest()
        {
            TDKService tdkService = NewTDKService();
            // 300V is the max for the charger
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 10;
            tdkService.RequestedVoltage = 500;
            Assert.AreEqual(tdkService.RequestedVoltage, tdkService.ChargerVoltageLimit, "Voltage has not been dropped to the Supply Voltage limit");
            
            tdkService.SupplyVoltageLimit = 120;
            tdkService.SupplyCurrentLimit = 10;

            // Power supply voltage is now lower than the max for the charger
            // so the charger can only supply at that voltage
            tdkService.RequestedVoltage = tdkService.ChargerVoltageLimit;
            Assert.AreEqual(tdkService.RequestedVoltage, 120);
        }

        [Test]
        [NonParallelizable]
        public void OverCurrentTest()
        {
            // Request more current that the charger provides, make sure it steps us down
            TDKService tdkService = NewTDKService();
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 10;
            tdkService.RequestedCurrent = 80;
            Assert.AreEqual(tdkService.RequestedCurrent, tdkService.ChargerCurrentLimit);

            // Request more current that the mains provides, make sure it steps us down            
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 5;
            tdkService.RequestedCurrent = 20;
            Assert.AreEqual(tdkService.RequestedCurrent, 5);
        }

        [Test]
        [NonParallelizable]
        public void AdjustVoltageTest()
        {
            TDKService tdkService = NewTDKService();
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 10;
            tdkService.RequestedVoltage = 160;

            Assert.AreEqual(tdkService.RequestedVoltage, 160);

            tdkService.RequestedVoltage = 150;
            Assert.AreEqual(tdkService.RequestedVoltage, 150);

            tdkService.RequestedVoltage = 170;
            Assert.AreEqual(tdkService.RequestedVoltage, 170);

            tdkService.RequestedVoltage = 0;
            Assert.AreEqual(tdkService.RequestedVoltage, 0);

            tdkService.RequestedVoltage = 120;
            Assert.AreEqual(tdkService.RequestedVoltage, 120);

            // Over the max of the charger, so should bring us back down
            tdkService.RequestedVoltage = 240;
            Assert.AreEqual(tdkService.RequestedVoltage, tdkService.ChargerVoltageLimit);

            tdkService.RequestedVoltage = 0;
            Assert.AreEqual(tdkService.RequestedVoltage, 0);
        }

        [Test]
        [NonParallelizable]
        public void AdjustCurrentTest()
        {
            TDKService tdkService = NewTDKService();
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 5;

            // Max available is 5
            tdkService.RequestedCurrent = 8;            
            Assert.AreEqual(tdkService.RequestedCurrent, 5);

            tdkService.RequestedCurrent = 7;
            Assert.AreEqual(tdkService.RequestedCurrent, 5);

            tdkService.RequestedCurrent = 4;
            Assert.AreEqual(tdkService.RequestedCurrent, 4);

            tdkService.RequestedCurrent = 0;
            Assert.AreEqual(tdkService.RequestedCurrent, 0);

            tdkService.RequestedCurrent = 3;
            Assert.AreEqual(tdkService.RequestedCurrent, 3);

            // Over the max of the supply, so should bring us back down
            tdkService.RequestedCurrent = 11;
            Assert.AreEqual(tdkService.RequestedCurrent, 5);

            tdkService.RequestedCurrent = 0;
            Assert.AreEqual(tdkService.RequestedCurrent, 0);
        }


    }
}
