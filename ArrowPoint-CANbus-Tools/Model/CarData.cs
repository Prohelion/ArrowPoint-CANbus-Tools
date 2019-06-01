using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.CanBus;
using ArrowPointCANBusTool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ArrowPointCANBusTool.Services.CanService;

namespace ArrowPointCANBusTool.Model
{
    public class CarData
    {
        private CanService udpService;
        private List<CanPacket> canPacketList;
        private Boolean isNewPacket;
        private int idCounter;
        private Boolean IsPaused { get; set; } = false;

        public float throttlePercentage;
        public float regenPercentage;
        public float rpmPercentage;
        public float currentPercentage;
        public float busCurrentPercentage;
        public int driveMode;
        public int cruiseMode;
        public int errorMode;
        public int flashMode;

        public CarData(CanService udpService) {
            this.udpService = udpService;
            this.udpService.CanUpdateEventHandler += new CanUpdateEventHandler(PacketReceived);

            this.canPacketList = new List<CanPacket>();

            // Move this logic to the receiver
            Timer timer = new Timer
            {
                Interval = (100)
            };
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }

        private void ReceiveCan(CanPacket cp)
        {
            try
            {
                switch (cp.CanIdBase10)
                {
                    case 513: // 0x501
                        this.throttlePercentage = cp.GetFloat(0);
                        this.regenPercentage = cp.GetFloat(1);
                        break;

                    case CanIds.DC_BASE + CanIds.DC_DRIVE: // 0x501
                        this.rpmPercentage = cp.GetFloat(0);
                        this.currentPercentage = cp.GetFloat(1);
                        break;

                    case CanIds.DC_BASE + CanIds.DC_POWER: // 0x502
                        this.busCurrentPercentage = cp.GetFloat(1);
                        break;

                    case CanIds.DC_BASE + CanIds.DC_CRUISE2: // 0x508
                        //this.driveMode = cp.GetInt8(7);
                        this.cruiseMode = cp.GetInt8(7);
                        break;

                    case CanIds.DC_BASE + CanIds.DC_DEBUG: // 0x50D
                        this.errorMode = cp.GetInt8(0);
                        this.driveMode = cp.GetInt8(1);
                        this.cruiseMode = cp.GetInt8(2);
                        this.flashMode = cp.GetInt8(3);
                        break;

                }
            } catch {
                //Let it go, let it go. Can't hold it back anymore...
            }
        }

        private void PacketReceived(CanReceivedEventArgs e)
        {
            if (this.IsPaused) return;

            CanPacket cp = e.Message;

            cp.PacketIndex = idCounter;
            this.canPacketList.Add(e.Message);

            this.isNewPacket = true;
            idCounter++;
        }

        private void TimerTick(object sender, EventArgs e)
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
                ReceiveCan(cp);
            }

            this.isNewPacket = false;
        }

        public void Detach()
        {
            // Detach the event and delete the list
            udpService.CanUpdateEventHandler -= new CanUpdateEventHandler(PacketReceived);            
        }

    }
}
