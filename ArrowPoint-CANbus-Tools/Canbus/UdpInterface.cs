using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ArrowPointCANBusTool.CanBus
{
    public class UdpInterface
    {
        
        private Thread UdpReceiverThread;
        private Thread UdpSenderThread;
        private UdpClient udpClient;
        private Boolean isConnected;
        private Hashtable lastCanPacket = new Hashtable();
        private List<CanPacket> canList = new List<CanPacket>();
        private Hashtable canOn10Hertz = new Hashtable();
        private IPAddress ipAddress;
        private IPEndPoint ipEndPoint;
        private string ip;
        private int port;

        public UdpInterface()
        {
            this.isConnected = false;
        }

        public Boolean Connect(string ip, int port)
        {
            this.ip = ip;
            this.port = port;

            if (ip == null || ip.Length == 0 || port == 0) return false;

            // Sender
            ipAddress = IPAddress.Parse(this.ip);
            ipEndPoint = new IPEndPoint(this.ipAddress, this.port);

            // Receiver
            try
            {
                this.udpClient = new UdpClient(this.port);
                this.udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                this.udpClient.JoinMulticastGroup(ipAddress, 50);
            }
            catch
            {
                return false;
            }

            this.isConnected = true;

            StartReceiver();
            StartSender();            

            return isConnected;
        }

        public void Disconnect()
        {
            if (!isConnected) return;

            udpClient.Close();            
            StopReceiver();
            StopSender();

            isConnected = false;            
        }

        public int SendMessage(CanPacket canPacket)
        {
            if (!isConnected) return -1;

            var data = canPacket.RawBytes;
            return udpClient.Send(data, data.Length, ipEndPoint);
        }

        public bool IsUdpConnected()
        {
            return isConnected;
        }

        public List<CanPacket> CanList => canList;

        public void ClearCanList()
        {
            canList.Clear();
        }

        public void SetCanToSendAt10Hertz(CanPacket canPacket)
        {
            if (canOn10Hertz.ContainsKey(canPacket.CanIdBase10))
            {
                canOn10Hertz.Remove(canPacket.CanIdBase10);
            }

            canOn10Hertz.Add(canPacket.CanIdBase10, canPacket);
        }

        public void StopSendingCanAt10Hertz(CanPacket canPacket)
        {
            if (canOn10Hertz.ContainsKey(canPacket.CanIdBase10))
            {
                canOn10Hertz.Remove(canPacket.CanIdBase10);
            }
        }

        public Boolean StartReceiver() {

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
        
        public void StopReceiver()
        {
            UdpReceiverThread.Abort();
        }


        public Boolean StartSender()
        {

            try
            {
                UdpSenderThread = new Thread(UdpSenderLoop);
                UdpSenderThread.Start();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public void StopSender()
        {
            UdpSenderThread.Abort();
        }

        public void UdpSenderLoop()
        {
            while (this.isConnected)
            {
                // Wait 1/10th of a second
                // Hence this loop runs at ~10hz.
                System.Threading.Thread.Sleep(100);

                try
                {
                    foreach (DictionaryEntry s in canOn10Hertz)
                    {
                        CanPacket canPacket = (CanPacket)s.Value;
                        var data = canPacket.RawBytes;
                        udpClient.Send(data, data.Length, ipEndPoint);
                    }
                }
                catch
                {
                    // Caught a big one!
                }
            }
        }

        public void UdpReceiverLoop()
        {
            while (this.isConnected)
            {
                try
                {
                    var ipEndPoint = new IPEndPoint(IPAddress.Any, this.port);
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
                canList.Add(canPacket);
                if (lastCanPacket.ContainsKey(canPacket.CanId))
                {
                    lastCanPacket.Remove(canPacket.CanId);
                }
                lastCanPacket.Add(canPacket.CanId, canPacket);
                body = body.Skip(14).ToArray();
            }

        }
    }
    
}
