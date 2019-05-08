using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ArrowPointCANBusTool.CanBus
{
    public delegate void UdpReceivedEventHandler(UdpReceivedEventArgs e);

    public class UdpReceiver
    {
        public event UdpReceivedEventHandler UdpReceiverEventHandler;
        private Thread UdpReceiverThread;
        private UdpClient udpClient;
        private Boolean isRecieving;

        private int port;

        public UdpReceiver()
        {
            this.isRecieving = false;
        }

        public UdpReceiver(UdpClient udpClient, int port) {
            this.isRecieving = false;
            this.udpClient = udpClient;
            this.port = port;
        }

        public Boolean StartReceiver() {

            try
            {
                this.isRecieving = true;

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
            isRecieving = false;
            UdpReceiverThread.Abort();
        }

        public void UdpReceiverLoop()
        {
            while (this.isRecieving)
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

        protected virtual void OnUdpReceived(UdpReceivedEventArgs e)
        {
            UdpReceiverEventHandler?.Invoke(e);
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
                CanPacket canPacket1 = new CanPacket(header.Concat(body.Take(14).ToArray()).ToArray());
                OnUdpReceived(new UdpReceivedEventArgs(canPacket1));
                body = body.Skip(14).ToArray();
            }

        }
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
