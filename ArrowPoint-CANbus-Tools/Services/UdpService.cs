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

        private UdpReceiver udpReceiver;        
        private UdpClient udpClient;

        private IPAddress ipAddress;
        private IPEndPoint ipEndPoint;

        private bool isConnected = false;
        private string ip;
        private int port;

        private Timer aTimer;

        public UdpService(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
            isConnected = false;

            udpReceiver = new UdpReceiver();
            startTimer();
        }

        public UdpService() // constructor
        {
            isConnected = false;

            // Create this early as the event registrations occur prior to a connection
            udpReceiver = new UdpReceiver();
            startTimer();
        }

        private void startTimer()
        {
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 1000;

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            // Start the timer
            aTimer.Enabled = true;
        }       

        public Boolean Connect(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
            return Connect();
        }

        public Boolean Connect()
        {
            if (ip == null || ip.Length == 0 || port == 0) return false;

            // Sender
            ipAddress = IPAddress.Parse(this.ip);
            ipEndPoint = new IPEndPoint(this.ipAddress, this.port);

            // Receiver
            try
            {
                udpClient = new UdpClient(this.port);
                udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                udpClient.JoinMulticastGroup(ipAddress, 50);
                //udpClient.Client.Bind(ipEndPoint);            
            } catch {
                return false;
            }

            udpReceiver = new UdpReceiver(udpClient, port);
            udpReceiver.StartReceiver();

            isConnected = true;            
            RequestConnectionStatusChange(true);
            return isConnected;
        }

        internal void Close()
        {
            Disconnect();
        }

        public Boolean Disconnect()
        {
            if (!isConnected) return false;

            udpClient.Close();
            udpClient = null;

            udpReceiver.StopReceiver();

            isConnected = false;
            RequestConnectionStatusChange(false);

            return true;
        }

        public int SendMessage(CanPacket canPacket)
        {
            if (!isConnected) return -1;

            var data = canPacket.getRawBytes();
            return udpClient.Send(data, data.Length, ipEndPoint);
        }

        public bool IsUdpConnected()
        {
            return isConnected;
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            // We take a copy so that if all this eventing is taking too long we are not adding more items to the list
            CanPacket[] canPacketListCopy = new CanPacket[udpReceiver.CanList.Count];
            udpReceiver.CanList.CopyTo(canPacketListCopy, 0);
            udpReceiver.ClearCanList();

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
