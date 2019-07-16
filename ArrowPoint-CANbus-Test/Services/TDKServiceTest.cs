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
                Thread.Sleep(1000);
            }
            else
            {
                ChargerIpAddress = "192.168.14.100";
                ChargerIpPort = 10000;
            }
        }

        [Test]
        public void CheckBasicComms()
        {
            TDKService tdkService = TDKService.Instance;
            tdkService.ChargerIpAddress = ChargerIpAddress;
            tdkService.ChargerIpPort = ChargerIpPort;
            Assert.AreEqual("LOC",tdkService.SendMessageGetResponse("RMT?"));
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            tdkSimulator.StopSimulator();
        }


    }
}
