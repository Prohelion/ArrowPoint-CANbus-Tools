using ArrowPointCANBusTool.Canbus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ArrowPointCANBusTool.CanBus
{
    public class CanOverEthernet : ICanInterface
    {

        /*
         * Can Packet structure is:
         * 
         * +-+------------------+-+----------------------+--------------+---------+----------+---------+
         * |8|56 - Bus Identifer|8|56 - Client Identifier|32 - Identifer|8 - Flags|8 - Length|64 - Data|
         * +-+------------------+-+----------------------+--------------+---------+----------+---------+
         * 
         */

        private const String DEFAULT_IPADDRESS = "239.255.60.60";
        private const int DEFAULT_PORT = 4876;

        private Thread UdpReceiverThread;
        private UdpClient udpConnection;
        private Boolean isConnected;
        private IPAddress ipAddress;
        private IPEndPoint ipEndPoint;

        public string Ip;
        public int Port;
        public ReceivedCanPacketHandler ReceivedCanPacketCallBack { get; set; }

        public CanOverEthernet(string Ip, int Port, ReceivedCanPacketHandler receivedCanPacketCallBack)
        {
            this.Ip = Ip;
            this.Port = Port;
            this.ReceivedCanPacketCallBack = receivedCanPacketCallBack;

            if (Ip == null || Ip.Length == 0 || Port == 0) return;

            this.isConnected = false;
        }

        public CanOverEthernet(ReceivedCanPacketHandler receivedCanPacketHandler)
        {
            this.Ip = DEFAULT_IPADDRESS;
            this.Port = DEFAULT_PORT;
            this.ReceivedCanPacketCallBack = receivedCanPacketHandler;
            this.isConnected = false;
        }

        internal void Close()
        {
            Disconnect();            
        }

        public Boolean Connect()
        {

            // Sender
            ipAddress = IPAddress.Parse(this.Ip);
            ipEndPoint = new IPEndPoint(this.ipAddress, this.Port);

            // Receiver
            try
            {
                this.udpConnection = new UdpClient(this.Port);
                this.udpConnection.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                this.udpConnection.JoinMulticastGroup(ipAddress, 50);
            }
            catch
            {
                return false;
            }

            this.isConnected = true;

            StartReceiver();                 

            return isConnected;
        }

        public Boolean Disconnect()
        {
            if (!isConnected) return false;

            udpConnection.Close();
            StopReceiver();

            isConnected = false;

            return isConnected;
        }

        public int SendMessage(CanPacket canPacket)
        {
            if (!isConnected) return -1;

            var data = canPacket.RawBytes;
            return udpConnection.Send(data, data.Length, ipEndPoint);
        }

        public Boolean IsConnected()
        {
            return isConnected;
        }       

        private Boolean StartReceiver() {
            try
            {
                UdpReceiverThread = new Thread(UdpReceiverLoop);
                UdpReceiverThread.Start();
            }
            catch {
                return false;
            }

            return true;
        }
        
        private void StopReceiver()
        {
            try {
                UdpReceiverThread.Abort();
            }
            catch { };
        }

        private void UdpReceiverLoop()
        {
            while (this.isConnected)
            {
                try
                {
                    var ipEndPoint = new IPEndPoint(IPAddress.Any, this.Port);
                    byte[] data = udpConnection.Receive(ref ipEndPoint);
                    IPAddress sourceAddress = ipEndPoint.Address;
                    int port = ipEndPoint.Port;

                    if (CheckIfTritiumDatagram(data)) {
                        SplitCanPackets(data, sourceAddress, port);                        
                    }
                }
                catch { 
                    // Caught a big one!
                }
            }
        }        

        private bool CheckIfTritiumDatagram(byte[] data) {
            string dataString = MyExtensions.ByteArrayToText(data);
            return dataString.Contains("Tritium");
        }

        private void SplitCanPackets(byte[] data, IPAddress sourceIPAddress, int sourcePort) {
            Byte[] header = data.Take(16).ToArray();
            Byte[] body = data.Skip(16).ToArray();
            int numPackets = body.Length / 14;

            for (int i = 0; i < numPackets; i++) {
                CanPacket canPacket = new CanPacket(header.Concat(body.Take(14).ToArray()).ToArray())
                {
                    SourceIPAddress = sourceIPAddress,
                    SourceIPPort = sourcePort
                };

                ReceivedCanPacketCallBack?.Invoke(canPacket);

                body = body.Skip(14).ToArray();
            }

        }
    }
    
}
