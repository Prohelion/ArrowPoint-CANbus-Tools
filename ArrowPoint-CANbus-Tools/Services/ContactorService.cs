using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ArrowPointCANBusTool.Services
{
    public class ContactorService : IDisposable
    {
        private static readonly ContactorService instance = new ContactorService();

        private const uint TIME_VALID = 5000;

        private readonly ContactorService contactorService;
        private CanControl canControl;
        private Timer contactorUpdateTimer;

        static ContactorService()
        {
        }

        public static ContactorService Instance
        {
            get
            {
                return instance;
            }
        }

        private ContactorService()
        {
            contactorService = ContactorService.Instance;
            canControl = new CanControl(0x508);
        }

        public async Task<bool> EngageContactor()         
        {

            CanPacket canPacket = new CanPacket(0x508);
            canPacket.SetByte(7, 0x0);
            canControl.ComponentCanService.SetCanToSendAt10Hertz(canPacket);

            await Task.Delay(1000).ConfigureAwait(false);

            canPacket.SetByte(7, 0x30);
            canControl.ComponentCanService.SetCanToSendAt10Hertz(canPacket);

            contactorUpdateTimer = new System.Timers.Timer
            {
                Interval = 100,
                AutoReset = true,
                Enabled = true
            };
            contactorUpdateTimer.Elapsed += ContactUpdate;

            return true;
        }

        private void ContactUpdate(object sender, EventArgs e)
        {

           if (!IsContactorsEngaged())
                DisengageContactor();
        }

        public void DisengageContactor()
        {
            contactorUpdateTimer.Stop();

            CanPacket canPacket = new CanPacket(0x508);
            canPacket.SetByte(7,0x0);            
            canControl.ComponentCanService.SetCanToSendAt10Hertz(canPacket);
        }

        public Boolean IsContactorsEngaged()
        {
            CanPacket contactorStatus = canControl.ComponentCanService.LastestCanPacketById(0x302);
            if (contactorStatus == null) return (false);
            return contactorStatus.Byte1 == 0x30 && contactorStatus.MilisecondsSinceReceived < TIME_VALID;
        }

        public uint State {
            get {

                CanPacket contactorStatus = canControl.ComponentCanService.LastestCanPacketById(0x302);

                uint result = CanReceivingNode.STATE_NA;

                if (contactorStatus == null || contactorStatus.MilisecondsSinceReceived > TIME_VALID) result = CanReceivingNode.STATE_NA;
                else
                { 
                    if (contactorStatus.Byte1 == 0x30) result = CanReceivingNode.STATE_ON;
                    if (contactorStatus.Byte1 != 0x30) result = CanReceivingNode.STATE_IDLE;
                }

                return result;
            }
        }

        public string StateMessage { get { return CanReceivingNode.GetStatusText(State); } }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    contactorUpdateTimer?.Stop();
                    contactorUpdateTimer?.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
