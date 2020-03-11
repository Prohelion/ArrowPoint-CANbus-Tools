using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;
using System.Configuration;
using System.Globalization;
using Microsoft.Win32;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Diagnostics.Contracts;

namespace Prohelion.CanLibrary.Tritium
{
    ///<summary>A client to send and receive CAN messages via UDP.</summary>
    public class TritiumCanClient : ICanTrafficInterface
    {
        private const int CANUDP_DEFAULT_PORT = 4876;
        private const string CANUDP_MULTICAST_ADDRESS = "239.255.60.60";
        private const UInt64 CANUDP_BUS_ID = 0x5472697469756D;
        private const int CANUDP_HOP_LIMIT = 1;
        private const int ETH_PACKET_LENGTH = 1472;

        ///<summary>The multicast group, defined by its IP address and port.</summary>
        protected IPEndPoint groupEndPoint = null;

        ///<summary>The identifier of the bus this client is considered to be on.</summary>        
        public UInt64 BusId { get; private set; }

        ///<summary>The maximum number of hops on the network a packet is allowed to take.</summary>
        public int HopLimit { get; private set; }

        ///<summary>The unique identifier assigned to this client.</summary>        
        protected UInt64 ClientId;

        ///<summary>The local IP address to join the multicast group on when openUdp() called.</summary>
        protected IPAddress localAddr;

        ///<summary>The Serialisation library for receiving and sending data over Ethernet.</summary>
        CanPacketSerialiser serialiser;

        /// <summary>The UdpClient used to send and receive UDP packets.</summary>
        protected UdpClient udpClient;

        /// <summary>The TcpClient used to send and receive TCP packets.</summary>
        protected TcpClient tcpClient;

        uint tcpFwdAddr;
	    uint tcpFwdRange;
        byte[] tcpRecBuffer;
        bool isFirstTcpData;
        bool awaitingFirstTcpData;

        IAsyncResult currentUdpResult;
        IAsyncResult currentTcpResult;

        List<CanPacket> packetStore;

        public List<string> SelectedInterfaces { get; set; }

        public ReceivedCanPacketHandler ReceivedCanPacketCallBack { get; set; }

        ///<summary>Create a new CanUdpClient with the given properties. Note that for normal use the <see cref="TritiumCanClient()">parameterless constructor</see> is most likely to work, so that is the preferred constructor.</summary>
        ///<param name="groupAddress">The multicast IP address to which the packets should be send and from which packets should be received.</param>
        ///<param name="groupPort">The IP port to which the packets should be send and on which packets should be received.</param>
        ///<param name="busId">The identifier of the bus this client is considered to be on.</param>
        ///<param name="hopLimit">The maximum number of hops on the network a packet is allowed to take.</param>
        ///<param name="localAddr">The local IP address to join the multicast group on when openUdp() called.</param>
        public TritiumCanClient(IPAddress groupAddress, int groupPort, UInt64 busId, int hopLimit, IPAddress localAddr)
        {
            Init( groupAddress, groupPort, busId, hopLimit, localAddr );
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
        
       
        /// <summary>This is what actually initialises the CanUdpLibrary.</summary>
        protected void Init(IPAddress groupAddress, int groupPort, UInt64 busId, int hopLimit, IPAddress localAddr)
        {
            this.groupEndPoint = new IPEndPoint(groupAddress, groupPort);
            this.BusId = busId & 0xffffffffffffff;
            this.HopLimit = hopLimit;
            this.serialiser = new CanPacketSerialiser();
            this.packetStore = new List<CanPacket>();
            

            // Generate a random client identifier based on ip address and 24 bits random data            
            Random random = new Random();
            // Choose a nice IP address
            IPAddress[] ipAddresses = Dns.GetHostAddresses(Dns.GetHostName());
            IPAddress ipAddress = null;
            for (int i = 0; i < ipAddresses.Length; i++)
            {
                if (ipAddresses[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddress = ipAddresses[i];
                }
            }
            // Generate id based on ip
            byte[] ipBytes;
            if (ipAddress == null)
            {
                ipBytes = new byte[4];
                random.NextBytes(ipBytes);
            }
            else
            {
                ipBytes = ipAddress.GetAddressBytes();
            }
            // Generate random client id
            ClientId = ((UInt64)BitConverter.ToUInt32(ipBytes, 0) << 24) | (uint)random.Next(1 << 24);
        }


        ///<summary>Create a new CanUdpClient.</summary>
        public TritiumCanClient() //:
            //this(IPAddress.Parse(fromSettings("groupAddress", "239.255.60.60")), fromSettings("groupPort", 65000), fromSettingsHex("busId", 0x5472697469756D), fromSettings("hopLimit", 1))
        {
            IPAddress groupAddress = IPAddress.Parse(CANUDP_MULTICAST_ADDRESS); //IPAddress.Parse(fromSettings("groupAddress", CANUDP_MULTICAST_ADDRESS));
            //DONT CARE ABOUT WHICH NETWORK INTERFACE IS USED - AS LONG AS CAN CONNECT TO DEVICE (fixes mainly win7 issues)
            localAddr = IPAddress.Parse("0.0.0.0");
            int groupPort = CANUDP_DEFAULT_PORT;
            BusId = CANUDP_BUS_ID;

            /*
            try
            {
                RegistryKey masterKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Tritium\\CanBridgeConfig", false);
                if (masterKey != null)
                {

                    if (masterKey.GetValueKind("port") == RegistryValueKind.DWord)
                    {
                        object obj = masterKey.GetValue("port");
                        groupPort = (int)obj;
                    }

                    if (masterKey.GetValueKind("busId") == RegistryValueKind.QWord)
                    {
                        object obj = masterKey.GetValue("busId");
                        busId = Convert.ToUInt64(obj);
                    }
                }
                masterKey.Close();
            }
            catch (System.Exception)
            {
                //Do nothing! Defaults will be used
            }*/

            Init(groupAddress, groupPort, BusId, CANUDP_HOP_LIMIT, localAddr); //init(groupAddress, groupPort, busId, fromSettings("hopLimit", CANUDP_HOP_LIMIT), localAddr);
        }


        ///<summary>Opens the UDP connection of this client. This is necessary to send or receive packets.</summary>
        ///<seealso cref="send"/>        
        public bool Connect()
        {
            OpenUdp();
            return true;
        }


        ///<summary>Opens the UDP connection of this client. This is necessary to send or receive packets.</summary>
        public void OpenUdp()
        {
            lock (this)
            {
                if (udpClient == null)
                {
                    udpClient = new UdpClient();

                    // Set the socket used by the receive UDP client to be non-exclusive
                    udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
                    try
                    {
                        udpClient.Client.Bind(new IPEndPoint(localAddr, groupEndPoint.Port));
                    }
                    catch (Exception)
                    {
                        return;
                    }

                    // Connect to the UDP multicast subnet
                    udpClient.JoinMulticastGroup(groupEndPoint.Address, HopLimit);

                    // Begin a subthread for packet reception
                    udpClient.BeginReceive(new AsyncCallback(HandlePacketReceiveUdp), null);
                }
            }
        }


        ///<summary>Opens the TCP connection of this client. This is necessary to send or receive packets over TCP.</summary>
        public void OpenTcp( IPAddress ipAddr, uint fwdAddr = 0, uint fwdRange = 0 )
        {
            lock (this)
            {
                if (tcpClient == null)
                {
                    tcpClient = new TcpClient(AddressFamily.InterNetwork);

                    tcpClient.Connect(ipAddr, groupEndPoint.Port);

                    tcpFwdAddr = fwdAddr;
                    tcpFwdRange = fwdRange;
                    isFirstTcpData = true;
                    awaitingFirstTcpData = true;

                    tcpRecBuffer = new byte[ETH_PACKET_LENGTH];
                    
                    // Begin a subthread for packet reception
                    currentTcpResult = tcpClient.Client.BeginReceive(tcpRecBuffer, 0, ETH_PACKET_LENGTH, SocketFlags.None, new AsyncCallback(HandlePacketReceiveTcp), null); //CanPacketSerialiser.PACKET_LENGTH
                }
            }
        }


        ///<summary>Handle a received packet by reading its bus and sender id and calling the ReceivedCanPacketCallBack event if the packet is valid.</summary>
        ///<param name="ar">The IAsyncResult provided by the asynchronuous call.</param>
        protected void HandlePacketReceiveUdp(IAsyncResult ar)
        {
            Byte[] receiveBytes = null;
            IPAddress senderAddr = null;
            lock (this)
            {
                if (udpClient != null)
                {
                    // Receive the incoming packet
                    IPEndPoint remoteReceive = null;
                    receiveBytes = udpClient.EndReceive(ar, ref remoteReceive);
                    senderAddr = remoteReceive.Address;

                    // Begin another thread for the next packet
                    udpClient.BeginReceive(new AsyncCallback(HandlePacketReceiveUdp), null);

                }
            }
            if (receiveBytes != null)
            {

                //Deserialise the bulk packets received
                List<UdpPacket> packet = serialiser.Deserialise(receiveBytes);

                //Iterate through the received packets store and handle as required
                foreach (UdpPacket pkt in packet)
                {
                    pkt.setSenderAddr(senderAddr);
                    pkt.setSenderPort(getGroupPort());
                    pkt.setLocalAddr(getLocalAddress());

                    // Decide if the packet needs to be passed on to the main program
                    // All packets:
                    //  - drop packets without a correct bus identifier
                    //  - drop packets from ourself
                    if (pkt.getBusId() == BusId && pkt.getSenderId() != ClientId)
                    {
                        ReceivedCanPacketCallBack?.Invoke(pkt);                     
                    }
                }
            }
        }


        ///<summary>Handle a received packet by reading its bus and sender id and calling the ReceivedCanPacketCallBack event if the packet is valid.</summary>
        ///<param name="ar">The IAsyncResult provided by the asynchronuous call.</param>
        protected void HandlePacketReceiveTcp(IAsyncResult ar)
        {
            byte[] receiveBytes = null;
            UInt64 bridgeClientId = 0;

            lock (this)
            {
                if (tcpClient != null)
                {
                    if (ar == currentTcpResult)
                    {
                        try
                        {
                            receiveBytes = new byte[tcpClient.Client.EndReceive(ar)];
                            Array.Copy(tcpRecBuffer, receiveBytes, receiveBytes.Length);
                        }
                        catch (Exception)
                        {
                            GetBulkCount();
                        }
                    }
                    else
                    {
                        GetBulkCount();
                    }
                    

                    // Begin a subthread for packet reception
                    tcpClient.Client.BeginReceive(tcpRecBuffer, 0, ETH_PACKET_LENGTH, SocketFlags.None, new AsyncCallback(HandlePacketReceiveTcp), null);//CanPacketSerialiser.PACKET_LENGTH
                     
                }
                
            }
            if (receiveBytes != null)
            {
                List<UdpPacket> packet = null;
                //Deserialise the bulk packets received
                try
                {
                    packet = serialiser.Deserialise(receiveBytes, awaitingFirstTcpData, BusId, bridgeClientId);
                }
                catch (Exception) {
                    GetBulkCount();
                }

                //Iterate through the received packets store and handle as required
                foreach (UdpPacket pkt in packet)
                {
                    if (awaitingFirstTcpData)
                    {
                        awaitingFirstTcpData = false;
                        bridgeClientId = pkt.getSenderId();//Incase user program wants to know
                    }
                    // Decide if the packet needs to be passed on to the main program
                    // All packets:
                    //  - drop packets without a correct bus identifier
                    //  - drop packets from ourself
                    if (pkt.getBusId() == BusId && pkt.getSenderId() != ClientId)
                    {
                        ReceivedCanPacketCallBack?.Invoke(pkt);
                    }
                }
            }
        }


        ///<summary>Send a CanPacket on the UDP network. The connection should be open before packets can be send.</summary>
        ///<param name="packet">The packet to be send.</param>
        ///<exception cref="IOException">Thrown when the connection is not open.</exception>
        ///<seealso cref="open"/>
        public int SendMessage(CanPacket packet)
        {
            Contract.Requires(packet != null);

            Byte[] transmitBytes = serialiser.Serialise(packet, BusId, ClientId);
            SendBytesUdp(transmitBytes);
            return 1;
        }


        ///<summary>Adds a CAN packet to the bulk store which is to be sent over UDP or TCP.</summary>
        public void AddToBulk(CanPacket packet)
        {
            Contract.Requires(packet != null);

            packetStore.Add(new CanPacket(packet.CanId, packet.Extended, packet.Rtr, packet.Length, packet.Data));
        }


        ///<summary>Gets the amount of CAN packets awaiting transmission.</summary>
        public int GetBulkCount()
        {
            return packetStore.Count;
        }


        ///<summary>Sends the queued up CAN packets over UDP.</summary>
        public void SendBulkUdp()
        {
            Byte[] transmitBytes = serialiser.SerialiseBulk(packetStore, BusId, ClientId, true, false);
            SendBytesUdp(transmitBytes);
            packetStore.Clear();
        }


        ///<summary>Sends the queued up CAN packets over TCP.</summary>
        public void SendBulkTcp( bool isSettings = false )
        {
            byte[] transmitBytes = serialiser.SerialiseBulk(packetStore, BusId, ClientId, isFirstTcpData, isSettings);
	        if ( isFirstTcpData )
	        {
		        // add tcpFwdAdd and tcpFwdRange as preamble
                transmitBytes = CanUtilities.GetBytes(tcpFwdAddr).Concat(CanUtilities.GetBytes(tcpFwdRange)).Concat(transmitBytes).ToArray();
	        }
            SendBytesTcp(transmitBytes);
            packetStore.Clear();
	        isFirstTcpData = false;
        }


        ///<summary>Send a serialised stream of bytes over UDP.</summary>
        protected void SendBytesUdp(byte[] transmitBytes)
        {
            Contract.Requires(transmitBytes != null);

            lock (this)
            {
                if (udpClient == null)
                {
                    throw new IOException("Unable to send CAN packets: CanUdpClient is not open");
                }
                // Serialise to byte array and transmit the packet
                udpClient.BeginSend(transmitBytes, transmitBytes.Length, groupEndPoint, new AsyncCallback(SendCallbackUdp), udpClient);
            }
        }


        ///<summary>Finish an asynchronous send.</summary>
        ///<param name="ar">The IAsyncResult provided by the asynchronous call with as state the UdpClient that made the call.</param>
        protected void SendCallbackUdp(IAsyncResult ar)
        {
            Contract.Requires(ar != null);

            UdpClient u = ar.AsyncState as UdpClient;
            // End sending if the connection is still open, otherwise that is impossible.
            if (ar == udpClient)
            {
                u.EndSend(ar);
            }
        }


        ///<summary>Send a serialised stream of bytes over TCP.</summary>
        protected void SendBytesTcp(byte[] transmitBytes)
        {
            Contract.Requires(transmitBytes != null);

            lock (this)
            {
                if (tcpClient == null)
                {
                    throw new IOException("Unable to send CAN packets: CanUdpClient is not open");
                }
                // Serialise to byte array and transmit the packet
                tcpClient.Client.BeginSend(transmitBytes, 0, transmitBytes.Length, SocketFlags.None, new AsyncCallback(SendCallbackTcp), tcpClient);
            }
        }


        ///<summary>Finish an asynchronous send via TCP.</summary>
        ///<param name="ar">The IAsyncResult provided by the asynchronous call with as state the TcpClient that made the call.</param>
        protected void SendCallbackTcp(IAsyncResult ar)
        {
            Contract.Requires(ar != null);

            TcpClient t = ar.AsyncState as TcpClient;
            // End sending if the connection is still open, otherwise that is impossible.
            if (ar.AsyncState == tcpClient)
            {
                t.Client.EndSend(ar);
            }
        }


        ///<summary>Close any open UDP and TCP connections.</summary>
        public bool Disconnect()
        {
            ReceivedCanPacketCallBack = null;  //This will sort out any Form disposed issues
            CloseUdp();
            CloseTcp();
            return true;
        }


        ///<summary>Close the UDP connection of this client. After closing no packets can be send and no packets will be received.</summary>
        public void CloseUdp()
        {
            lock (this)
            {
                if (udpClient != null)
                {
                    udpClient.DropMulticastGroup(groupEndPoint.Address);
                    udpClient.Client.Close();
                    udpClient = null;
                }
            }
        }


        ///<summary>Close the TCP connection of this client. After closing no packets can be send and no packets will be received.</summary>
        public void CloseTcp()
        {
            lock (this)
            {
                if (tcpClient != null)
                {
                    tcpClient.Client.Shutdown(SocketShutdown.Both);
                    tcpClient.Client.Close();
                    tcpClient.Close();
                    tcpClient = null;
                }
            }
        }


        ///<summary>Returns the multicast IP address to which the packets are send and from which packets are received.</summary>
        ///<returns>The multicast IP address.</returns>
        public IPAddress getGroupAddress()
        {
            return groupEndPoint.Address;
        }


        ///<summary>Returns the IP port to which the packets are send and on which packets are received.</summary>
        ///<returns>The IP port.</returns>
        public int getGroupPort()
        {
            return groupEndPoint.Port;
        }


        ///<summary>Returns the local IP address used to subscribe to multicast packets.</summary>
        ///<returns>The identifier of this client.</returns>
        public IPAddress getLocalAddress()
        {
            return localAddr;
        }
        
        public bool IsConnected()
        {
            return true;
        }

    }
}
