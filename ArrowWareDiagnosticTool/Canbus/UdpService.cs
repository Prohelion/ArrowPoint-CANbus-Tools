using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.CanBus
{

    public delegate void RequestConnectionStatusChangeDelegate(bool connected);

    public class UdpService
    {

        public event RequestConnectionStatusChangeDelegate RequestConnectionStatusChange;

        private UdpReceiver udpReceiver;        
        private UdpClient udpClient;

        private IPAddress ipAddress;
        private IPEndPoint ipEndPoint;

        private bool isConnected = false;
        private string ip;
        private int port;

        public UdpService(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
            isConnected = false;

            udpReceiver = new UdpReceiver();
        }

        public UdpService() // constructor
        {
            isConnected = false;

            // Create this early as the event registrations occur prior to a connection
            udpReceiver = new UdpReceiver();
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
            } catch (SocketException se) {
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

        public UdpReceiver UdpReceiver()
        {
            return udpReceiver;
        }
        
    }
}
