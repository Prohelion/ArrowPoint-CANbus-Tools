using ArrowPointCANBusTool.CanLibrary;
using ArrowPointCANBusTool.Services;
using Prohelion.CanLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static ArrowPointCANBusTool.Services.CanService;

namespace ArrowPointCANBusTool.Model
{
    public class CarData
    {        
        private List<CanPacket> canPacketList;
        private Boolean isNewPacket;
        private int idCounter;
        private Boolean IsPaused { get; set; } = false;
        private readonly object timerLock = new object();

        public float ThrottlePercentage { get; set; }
        public float RegenPercentage { get; set; }
        public float RpmPercentage { get; set; }
        public float CurrentPercentage { get; set; }
        public float BusCurrentPercentage { get; set; }
        public int DriveMode { get; set; }
        public int CruiseMode { get; set; }
        public int ErrorMode { get; set; }
        public int FlashMode { get; set; }

        private static Timer timer = new System.Timers.Timer(100);

        public CarData() {
            CanService.Instance.CanUpdateEventHandler += new CanUpdateEventHandler(PacketReceived);

            this.canPacketList = new List<CanPacket>();
           
            timer.Elapsed += new ElapsedEventHandler(TimerTick);
            timer.Enabled = true;
        }

        private void ReceiveCan(CanPacket cp)
        {
            try
            {
                switch (cp.CanIdBase10)
                {
                    case 513: // 0x501
                        this.ThrottlePercentage = cp.FloatPos0;
                        this.RegenPercentage = cp.FloatPos1;
                        break;

                    case CanIds.DC_BASE + CanIds.DC_DRIVE: // 0x501
                        this.RpmPercentage = cp.FloatPos0;
                        this.CurrentPercentage = cp.FloatPos1;
                        break;

                    case CanIds.DC_BASE + CanIds.DC_POWER: // 0x502
                        this.BusCurrentPercentage = cp.FloatPos1;
                        break;

                    case CanIds.DC_BASE + CanIds.DC_CRUISE2: // 0x508
                        //this.driveMode = cp.Int8Pos7;
                        this.CruiseMode = cp.Int8Pos7;
                        break;

                    case CanIds.DC_BASE + CanIds.DC_DEBUG: // 0x50D
                        this.ErrorMode = cp.Int8Pos0;
                        this.DriveMode = cp.Int8Pos1;
                        this.CruiseMode = cp.Int8Pos2;
                        this.FlashMode = cp.Int8Pos3;
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
            if (cp == null) return;
            
            this.canPacketList.Add(e.Message);

            this.isNewPacket = true;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            lock (timerLock)
            {

                if (!this.isNewPacket) return;

                CanPacket[] canPacketListCopy = new CanPacket[canPacketList.Count];

                try
                {
                    this.canPacketList.GetRange(0,canPacketListCopy.Length).CopyTo(canPacketListCopy, 0);
                    canPacketList.Clear();
                }
                catch
                {
                    canPacketList.Clear();
                }

                foreach (CanPacket cp in canPacketListCopy)
                {
                    if (cp != null)
                        ReceiveCan(cp);
                }

                this.isNewPacket = false;

            }

        }

        public void Detach()
        {
            // Detach the event and delete the list
            CanService.Instance.CanUpdateEventHandler -= new CanUpdateEventHandler(PacketReceived);            
        }

    }
}
