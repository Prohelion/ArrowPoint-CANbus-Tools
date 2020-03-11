using Prohelion.CanLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;

namespace Prohelion.CanLibrary.Ethernet
{
    public class CanOverEthernet : ICanTrafficInterface, IDisposable
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
        private List<UdpClient> udpSenderConnections;
        private Boolean isConnected = false;
        private IPAddress ipAddressMulticast;
        private IPEndPoint ipEndPointMulticast;
        private IPEndPoint localEndPoint;

        public string Ip { get; set; } = DEFAULT_IPADDRESS;
        public int Port { get; set; } = DEFAULT_PORT;       
        public ReceivedCanPacketHandler ReceivedCanPacketCallBack { get; set; }
        public List<string> SelectedInterfaces { get; set; }

        internal void Close()
        {
            Disconnect();            
        }

        public Dictionary<string, string> AvailableInterfaces
        {
            get
            {
                Dictionary<string, string> availableInterfaces = null;

                // Find all available network interfaces
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface networkInterface in networkInterfaces)
                {
                    if ((!networkInterface.Supports(NetworkInterfaceComponent.IPv4)) ||
                        (networkInterface.OperationalStatus != OperationalStatus.Up))
                    {
                        continue;
                    }

                    IPInterfaceProperties adapterProperties = networkInterface.GetIPProperties();
                    UnicastIPAddressInformationCollection unicastIPAddresses = adapterProperties.UnicastAddresses;
                    IPAddress ipAddress = null;

                    foreach (UnicastIPAddressInformation unicastIPAddress in unicastIPAddresses)
                    {
                        if (unicastIPAddress.Address.AddressFamily != AddressFamily.InterNetwork)
                        {
                            continue;
                        }

                        ipAddress = unicastIPAddress.Address;
                        break;
                    }

                    if (ipAddress == null)
                    {
                        continue;
                    }

                    if (availableInterfaces == null)
                        availableInterfaces = new Dictionary<string, string>();

                    availableInterfaces.Add(ipAddress.ToString(), ipAddress.ToString() + " - " + networkInterface.Name);

                }
                return availableInterfaces;
            }
        }

        
        public Boolean Connect()
        {

            // Both the sender the receiver
            ipAddressMulticast = IPAddress.Parse(this.Ip);
            ipEndPointMulticast = new IPEndPoint(this.ipAddressMulticast, this.Port);
            localEndPoint = new IPEndPoint(IPAddress.Any, this.Port);

            try
            {
                this.udpReceiverConnection = new UdpClient()
                {
                    ExclusiveAddressUse = false
                };
                udpReceiverConnection.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                udpReceiverConnection.Client.Bind(localEndPoint);

                // join multicast group on all available network interfaces
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface networkInterface in networkInterfaces)
                {
                    if ((!networkInterface.Supports(NetworkInterfaceComponent.IPv4)) ||
                        (networkInterface.OperationalStatus != OperationalStatus.Up))
                    {
                        continue;
                    }

                    IPInterfaceProperties adapterProperties = networkInterface.GetIPProperties();
                    UnicastIPAddressInformationCollection unicastIPAddresses = adapterProperties.UnicastAddresses;
                    IPAddress ipAddress = null;

                    foreach (UnicastIPAddressInformation unicastIPAddress in unicastIPAddresses)
                    {
                        if (unicastIPAddress.Address.AddressFamily != AddressFamily.InterNetwork)
                        {
                            continue;
                        }

                        ipAddress = unicastIPAddress.Address;
                        break;
                    }

                    if (ipAddress == null)
                    {
                        continue;
                    }
                    
                    if (SelectedInterfaces != null && !SelectedInterfaces.Contains(ipAddress.ToString()))
                    {
                        continue;
                    }

                    udpReceiverConnection.JoinMulticastGroup(ipAddressMulticast, ipAddress);

                    // Also create a client for this interface and add it to the list of interfaces
                    IPEndPoint interfaceEndPoint = new IPEndPoint(ipAddress, this.Port);

                    UdpClient sendClient = new UdpClient();
                    sendClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                    sendClient.Client.MulticastLoopback = true;
                    sendClient.Client.Bind(interfaceEndPoint);
                    sendClient.JoinMulticastGroup(ipAddressMulticast);

                    if (udpSenderConnections == null) udpSenderConnections = new List<UdpClient>();
                    udpSenderConnections.Add(sendClient);
                }

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

            try
            {
                udpReceiverConnection.Close();
                foreach (UdpClient client in udpSenderConnections)
                    client.Close();
            }
            catch { }

            StopReceiver();

            isConnected = false;

            return isConnected;
        }

        public int SendMessage(CanPacket canPacket)
        {
            if (canPacket == null) throw new ArgumentNullException(nameof(canPacket));

            if (!isConnected) return -1;

            byte[] data = canPacket.GetDataArray();

            int resultToReturn = 0;

            foreach (UdpClient client in udpSenderConnections)
            {
                int result = client.Send(data, data.Length, ipEndPointMulticast);
                if (result > resultToReturn)
                    resultToReturn = result;
            }

            return resultToReturn;
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
                catch {
                    Disconnect();
                }
            }
        }        

        private static bool CheckIfTritiumDatagram(byte[] data) {
            string dataString = CanUtilities.ByteArrayToText(data);         

            // Some tritium Can Bridges uses Tritiub rather that Tritium
            // The latest release seems to just use Tri
            return dataString.Contains("Tri");
        }

        private void SplitCanPackets(byte[] data, IPAddress sourceIPAddress, int sourcePort) {
            Byte[] header = data.Take(16).ToArray();
            Byte[] body = data.Skip(16).ToArray();
            int numPackets = body.Length / 14;

            for (int i = 0; i < numPackets; i++) {
               /* CanPacket canPacket = new CanPacket(header.Concat(body.Take(14).ToArray()).ToArray())
                {
                    SourceIPAddress = sourceIPAddress,
                    SourceIPPort = sourcePort
                };
                
                ReceivedCanPacketCallBack?.Invoke(canPacket);
                */
                body = body.Skip(14).ToArray();
            }

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    udpReceiverConnection?.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {            
            Dispose(true);            
            GC.SuppressFinalize(this);
        }
        #endregion
    }
    
}
