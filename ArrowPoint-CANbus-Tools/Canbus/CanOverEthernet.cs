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
        
        private Thread UdpReceiverThread;
        private UdpClient udpClient;
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

        public Boolean Connect()
        {

            // Sender
            ipAddress = IPAddress.Parse(this.Ip);
            ipEndPoint = new IPEndPoint(this.ipAddress, this.Port);

            // Receiver
            try
            {
                this.udpClient = new UdpClient(this.Port);
                this.udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                this.udpClient.JoinMulticastGroup(ipAddress, 50);
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

            udpClient.Close();            
            StopReceiver();            

            isConnected = false;

            return isConnected;
        }

        public int SendMessage(CanPacket canPacket)
        {
            if (!isConnected) return -1;

            var data = canPacket.RawBytes;
            return udpClient.Send(data, data.Length, ipEndPoint);
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
            UdpReceiverThread.Abort();
        }

        private void UdpReceiverLoop()
        {
            while (this.isConnected)
            {
                try
                {
                    var ipEndPoint = new IPEndPoint(IPAddress.Any, this.Port);
                    byte[] data = udpClient.Receive(ref ipEndPoint);

                    if (CheckIfTritiumDatagram(data)) {
                        SplitCanPackets(data);
                    }
                }
                catch { 
                    // Caught a big one!
                }
            }
        }        

        private bool CheckIfTritiumDatagram(byte[] data) {
            string dataString = MyExtentions.ByteArrayToText(data);
            return dataString.Contains("Tritium");
        }

        private void SplitCanPackets(byte[] data) {
            Byte[] header = data.Take(16).ToArray();
            Byte[] body = data.Skip(16).ToArray();
            int numPackets = body.Length / 14;

            for (int i = 0; i < numPackets; i++) {
                CanPacket canPacket = new CanPacket(header.Concat(body.Take(14).ToArray()).ToArray());

                ReceivedCanPacketCallBack?.Invoke(canPacket);

                body = body.Skip(14).ToArray();
            }

        }
    }
    
}
