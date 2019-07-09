using ArrowPointCANBusTool.Canbus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ArrowPointCANBusTool.Canbus
{
    public class CanOverEthernet : ICanTrafficInterface
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
        private UdpClient udpReceiverConnection;
        private UdpClient udpSenderConnection;
        private Boolean isConnected;
        private IPAddress ipAddressMulticast;
        private IPEndPoint ipEndPointMulticast;
        private IPEndPoint localEndPoint;

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

            // Both the sender the receiver
            ipAddressMulticast = IPAddress.Parse(this.Ip);
            ipEndPointMulticast = new IPEndPoint(this.ipAddressMulticast, this.Port);
            localEndPoint = new IPEndPoint(IPAddress.Any, this.Port);

            // Setup sender and receiver
            try
            {
                udpSenderConnection = new UdpClient()
                {
                    ExclusiveAddressUse = false
                };
                udpSenderConnection.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                udpSenderConnection.Client.Bind(localEndPoint);
                udpSenderConnection.JoinMulticastGroup(ipAddressMulticast);
                udpSenderConnection.Client.MulticastLoopback = true;

                this.udpReceiverConnection = new UdpClient()
                {
                    ExclusiveAddressUse = false
                };
                udpReceiverConnection.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                udpReceiverConnection.Client.Bind(localEndPoint);
                udpReceiverConnection.JoinMulticastGroup(ipAddressMulticast, 50);                
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

            udpReceiverConnection.Close();
            udpSenderConnection.Close();
            StopReceiver();

            isConnected = false;

            return isConnected;
        }

        public int SendMessage(CanPacket canPacket)
        {
            if (!isConnected) return -1;

            var data = canPacket.RawBytes;
            return udpSenderConnection.Send(data, data.Length, ipEndPointMulticast);
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
                    byte[] data = udpReceiverConnection.Receive(ref ipEndPoint);
                    IPAddress sourceAddress = ipEndPoint.Address;
                    int port = ipEndPoint.Port;

                    if (CheckIfTritiumDatagram(data)) {
                        SplitCanPackets(data, sourceAddress, port);                        
                    }
                }
                catch (Exception ex) {
                    Disconnect();
                }
            }
        }        

        private bool CheckIfTritiumDatagram(byte[] data) {
            string dataString = MyExtensions.ByteArrayToText(data);         

            // Some tritium Can Bridges uses Tritiub rather that Tritium
            // The latest release seems to just use Tri
            return dataString.Contains("Tri");
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
