using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrowWareDiagnosticTool.Canbus
{
    public class CarData
    {
        private UdpReciever udpReciever;
        private List<CanPacket> canPacketList;
        private Boolean isNewPacket;
        private int idCounter;
        private Boolean isPaused = false;


        public float rpmPercentage;
        public float currentPercentage;
        public float busCurrentPercentage;
        public int cruiseMode;

        public CarData(UdpReciever udpReciever) {
            this.udpReciever = udpReciever;
            this.udpReciever.carDataEventHandler += new UdpRecievedEventHandler(packetRecieved);

            this.canPacketList = new List<CanPacket>();

            // Move this logic to the reciever
            Timer timer = new Timer();
            timer.Interval = (100);
            timer.Tick += new EventHandler(timerTick);
            timer.Start();
        }

        private void recieveCan(CanPacket cp)
        {
            try
            {
                switch (cp.canIdBase10)
                {
                    case CanIds.DC_BASE + CanIds.DC_DRIVE: // 0x501
                        this.rpmPercentage = cp.float0;
                        this.currentPercentage = cp.float1;
                        break;

                    case CanIds.DC_BASE + CanIds.DC_POWER: // 0x502
                        this.busCurrentPercentage = cp.float1;
                        break;

                    case CanIds.DC_BASE + CanIds.DC_CRUISE2: // 0x508
                        this.cruiseMode = cp.getInt8(7);
                        break;

                }
            } catch {
                //Let it go, let it go. Can't hold it back anymore...
            }
        }

        private void packetRecieved(UdpRecievedEventArgs e)
        {
            if (this.isPaused) return;

            CanPacket cp = e.Message;

            cp.packet = idCounter;
            this.canPacketList.Add(e.Message);

            this.isNewPacket = true;
            idCounter++;
        }

        private void timerTick(object sender, EventArgs e)
        {
            if (!this.isNewPacket) return;

            CanPacket[] canPacketListCopy = new CanPacket[canPacketList.Count];

            try
            {
                this.canPacketList.CopyTo(canPacketListCopy, 0);
                canPacketList.Clear();
            }
            catch {
                canPacketList.Clear();
            }
            

            foreach (CanPacket cp in canPacketListCopy)
            {
                recieveCan(cp);
            }

            this.isNewPacket = false;
        }

        public void Detach()
        {
            // Detach the event and delete the list
            udpReciever.recieverFormEventHandler -= new UdpRecievedEventHandler(packetRecieved);
            udpReciever = null;
        }


    }
}
