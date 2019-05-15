using ArrowPointCANBusTool.CanBus;
using System;
using System.Net;
using System.Net.Sockets;
using System.Timers;
using static ArrowPointCANBusTool.Services.UdpService;

namespace ArrowPointCANBusTool.Services
{

    public delegate void RequestConnectionStatusChangeDelegate(bool connected);
    public delegate void UdpReceivedEventHandler(UdpReceivedEventArgs e);

    public class UdpService
    {

        public event RequestConnectionStatusChangeDelegate RequestConnectionStatusChange;
        public event UdpReceivedEventHandler UdpReceiverEventHandler;

        private UdpInterface udpInterface;        

        private Timer aTimer;

        public UdpService() // constructor
        {                    
            // Create this early as the event registrations occur prior to a connection
            udpInterface = new UdpInterface();
            StartTimer();
        }
              
        internal void Close()
        {
            udpInterface.Disconnect();
            RequestConnectionStatusChange(false);
        }

        public Boolean Connect(string ip, int port)
        {            
            Boolean result = udpInterface.Connect(ip, port);            
            if (result) RequestConnectionStatusChange(true);
            return result;
        }

        public void Disconnect()
        {
            udpInterface.Disconnect();
            RequestConnectionStatusChange(false);
        }

        public Boolean IsUdpConnected()
        {
            return udpInterface.IsUdpConnected();
        }

        public void SetCanToSendAt10Hertz(CanPacket canPacket)
        {
            udpInterface.SetCanToSendAt10Hertz(canPacket);
        }

        public void StopSendingCanAt10Hertz(CanPacket canPacket)
        {
            udpInterface.StopSendingCanAt10Hertz(canPacket);
        }

        public int SendMessage(CanPacket canPacket)
        {
            return udpInterface.SendMessage(canPacket);
        }

        private void StartTimer()
        {
            aTimer = new System.Timers.Timer
            {
                Interval = 100,
                AutoReset = true,
                Enabled = true                
            };

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            // We take a copy so that if all this eventing is taking too long we are not adding more items to the list
            CanPacket[] canPacketListCopy = new CanPacket[udpInterface.CanList.Count];
            udpInterface.CanList.CopyTo(canPacketListCopy, 0);
            udpInterface.ClearCanList();

            foreach (CanPacket canPacket in canPacketListCopy)
            {
                OnUdpReceived(new UdpReceivedEventArgs(canPacket));
            }        
        }

        protected virtual void OnUdpReceived(UdpReceivedEventArgs e)
        {
            UdpReceiverEventHandler?.Invoke(e);
        }

        public class UdpReceivedEventArgs : EventArgs
        {
            public CanPacket Message { get; set; }

            public UdpReceivedEventArgs(CanPacket Message)
            {
                this.Message = Message;
            }
        }

    }
}
