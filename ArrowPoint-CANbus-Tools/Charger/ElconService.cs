
using ArrowPointCANBusTool.CanBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrowWareDiagnosticTool.Charger
{
    public class ElconService
    {
        private UdpService udpService;

        private Boolean chargerRunning = false;

        private Timer timer;

        private int voltageRequested { get; set; } = 0;
        private int currentRequested { get; set; } = 0;

        private int chargerVoltage { get; set; } = 0;
        private int chargerCurrent { get; set; } = 0;
        private int chargerStatus { get; set; } = 0;
        
        private CanPacket elconControlPacket = new CanPacket(403105268); // 0x1806E5F4

        public ElconService(UdpService udpService)
        {            
            this.udpService = udpService;
            this.udpService.UdpReceiver().CarDataEventHandler += new UdpReceivedEventHandler(packetReceived);
        }

        private void receiveCan(CanPacket cp)
        {
            try
            {
                switch (cp.canIdBase10)
                {
                    case 403105268: // 0x1806E5F4
                        this.chargerCurrent = cp.getInt8(1);
                        this.chargerVoltage = cp.getInt8(2);
                        this.chargerStatus = cp.getInt8(3);                        
                        break;
                }
            }
            catch
            {
                //Let it go, let it go. Can't hold it back anymore...
            }
        }

        private void packetReceived(UdpReceivedEventArgs e)
        {
            CanPacket cp = e.Message;

            receiveCan(cp);
        }

        public void Detach()
        {
            // Detach the event and delete the list
            udpService.UdpReceiver().ReceiverFormEventHandler -= new UdpReceivedEventHandler(packetReceived);
            
        }

        private void timerTick(object sender, EventArgs e)
        {
            if (!this.chargerRunning) return;

            this.elconControlPacket.setInt8(3, this.currentRequested);
            this.elconControlPacket.setInt8(2, this.voltageRequested);
            udpService.SendMessage(this.elconControlPacket);
        }

        public void start()
        {
            // Timer to keep the Elcon charger alive
            if (timer != null) timer.Stop();
            timer = new Timer();
            timer.Interval = (100);
            timer.Tick += new EventHandler(timerTick);
            timer.Start();

            this.chargerRunning = true;
        }

        public void stop()
        {
            timer.Stop();
            timer = null;

            this.chargerRunning = false;

        }


    }
}
