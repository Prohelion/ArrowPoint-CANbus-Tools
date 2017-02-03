using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ArrowWareDiagnosticTool
{
    public delegate void UdpRecievedEventHandler(UdpRecievedEventArgs e);

    public class UdpReciever
    {
        public event UdpRecievedEventHandler udpRecievedEventHandler;
        private Thread udpRecieverThread;
        private UdpClient udpClient;
        private Boolean isRecieving;
        public Boolean isConnected;

        private int port;
        private string ip;
        
        public UdpReciever() {
            this.isRecieving = false;
            this.isConnected = false;
        }

        public Boolean connect(string ip, int port) {
            this.ip = ip;
            this.port = port;

            try
            {
                udpClient = new UdpClient();
                udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                udpClient.ExclusiveAddressUse = false;
                udpClient.JoinMulticastGroup(IPAddress.Parse(this.ip), 50);
                udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, this.port));

                this.isRecieving = true;

                udpRecieverThread = new Thread(udpReceiverLoop);
                udpRecieverThread.Start();
            }
            catch {
                return false;
            }

            this.isConnected = true;

            return true;
        }

        public void disconnect()
        {
            this.isRecieving = false;
            try
            {
                udpClient.Close();
                udpRecieverThread.Abort(-1);
            }
            catch {
                // Gotta catch 'em all
            }

            this.isConnected = false;
        }

        public void close()  // destructor
        {
            this.disconnect();
        }

        public void udpReceiverLoop()
        {
            while (this.isRecieving)
            {
                try
                {
                    var ipEndPoint = new IPEndPoint(IPAddress.Any, this.port);
                    var data = udpClient.Receive(ref ipEndPoint);

                    //string dataStr = Encoding.Default.GetString(data);
                    

                    CanPacket canPacket = new CanPacket(data);

                    OnUdpRecieved(new UdpRecievedEventArgs(canPacket));
                }
                catch { 
                    // Caught a big one!
                }
            }
        }

        protected virtual void OnUdpRecieved(UdpRecievedEventArgs e)
        {
            if (udpRecievedEventHandler != null)
                udpRecievedEventHandler(e);
        }

    }

    public class UdpRecievedEventArgs : EventArgs
    {
        public CanPacket Message { get; set; }

        public UdpRecievedEventArgs(CanPacket Messgage)
        {
            this.Message = Messgage;
        }
    }
}
