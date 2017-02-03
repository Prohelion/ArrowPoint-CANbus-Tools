using System;
using System.Net;
using System.Net.Sockets;

namespace ArrowWareDiagnosticTool
{
    public class UdpSender

    {
        private IPAddress ipAddress;
        private IPEndPoint ipEndPoint;
        private UdpClient udpClient;
        public Boolean isConnected;

        private string ip;
        private int port;

        public UdpSender() // constructor
        {
            this.isConnected = false;
        }

        public Boolean connect(string ip, int port)
        {
            this.ip = ip;
            this.port = port;

            try
            {
                this.ipAddress = IPAddress.Parse(this.ip);
                this.ipEndPoint = new IPEndPoint(this.ipAddress, this.port);
                this.udpClient = new UdpClient();
                this.udpClient.JoinMulticastGroup(this.ipAddress);
            }
            catch {
                return false;
            }
            this.isConnected = true;

            return true;
        }

        public void disconnect()
        {
            if (udpClient != null)
            {
                udpClient.Close();
            }
            this.isConnected = false;
        }

        public void close()  // destructor
        {
            this.disconnect();
        }

        public bool SendMessage(CanPacket canPacket)
        {
            if (isConnected)
            {
                var data = canPacket.getRawBytes();
                this.udpClient.Send(data, data.Length, this.ipEndPoint);
            }
            else {
                return false;
            }

            return true;
        }

    }
}
