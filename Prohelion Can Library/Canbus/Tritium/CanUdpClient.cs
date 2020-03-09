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

namespace Tritium.CanLibrary
{
    ///<summary>A client to send and receive CAN messages via UDP.</summary>
    public class CanUdpClient : CanClient
    {
        static readonly int CANUDP_DEFAULT_PORT = 4876;
        static readonly string CANUDP_MULTICAST_ADDRESS = "239.255.60.60";
        static readonly UInt64 CANUDP_BUS_ID = 0x5472697469756D;
        static readonly int CANUDP_HOP_LIMIT = 1;
        static readonly int ETH_PACKET_LENGTH = 1472;

        ///<summary>The multicast group, defined by its IP address and port.</summary>
        protected IPEndPoint groupEndPoint = null;

        ///<summary>The identifier of the bus this client is considered to be on.</summary>
        ///<seealso cref="getBusId()"/>
        protected UInt64 busId;

        ///<summary>The maximum number of hops on the network a packet is allowed to take.</summary>
        ///<seealso cref="getHopLimit()"/>
        protected int hopLimit;

        ///<summary>The unique identifier assigned to this client.</summary>
        ///<seealso cref="getClientId()"/>
        protected UInt64 clientId;

        ///<summary>The local IP address to join the multicast group on when openUdp() called.</summary>
        protected IPAddress localAddr;

        ///<summary>The Serialisation library for receiving and sending data over Ethernet.</summary>
        CanPacketSerialiser serialiser;

        ///<summary>Delegate that is used to notify others when packets are received. Whereas it is possible to receive an UdpPacket to inspect all UDP specific properties, for normal use it is advised to use a CanPacket.</summary>
        ///<seealso cref="packetReceived"/>
        public delegate void PacketReceivedEvent(UdpPacket packet);

        ///<summary>Event that is called when a packet is received. The connection should be open before packets are received.</summary>
        ///<seealso cref="open"/>
        public event PacketReceivedEvent packetReceived;

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

        ///<summary>Create a new CanUdpClient with the given properties. Note that for normal use the <see cref="CanUdpClient()">parameterless constructor</see> is most likely to work, so that is the preferred constructor.</summary>
        ///<param name="groupAddress">The multicast IP address to which the packets should be send and from which packets should be received.</param>
        ///<param name="groupPort">The IP port to which the packets should be send and on which packets should be received.</param>
        ///<param name="busId">The identifier of the bus this client is considered to be on.</param>
        ///<param name="hopLimit">The maximum number of hops on the network a packet is allowed to take.</param>
        ///<param name="localAddr">The local IP address to join the multicast group on when openUdp() called.</param>
        public CanUdpClient(IPAddress groupAddress, int groupPort, UInt64 busId, int hopLimit, IPAddress localAddr)
        {
            init( groupAddress, groupPort, busId, hopLimit, localAddr );
        }


        /// <summary>This is what actually initialises the CanUdpLibrary.</summary>
        protected void init(IPAddress groupAddress, int groupPort, UInt64 busId, int hopLimit, IPAddress localAddr)
        {
            this.groupEndPoint = new IPEndPoint(groupAddress, groupPort);
            this.busId = busId & 0xffffffffffffff;
            this.hopLimit = hopLimit;
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
            clientId = ((UInt64)BitConverter.ToUInt32(ipBytes, 0) << 24) | (uint)random.Next(1 << 24);
        }


        ///<summary>Create a new CanUdpClient.</summary>
        public CanUdpClient() //:
            //this(IPAddress.Parse(fromSettings("groupAddress", "239.255.60.60")), fromSettings("groupPort", 65000), fromSettingsHex("busId", 0x5472697469756D), fromSettings("hopLimit", 1))
        {
            IPAddress groupAddress = IPAddress.Parse(CANUDP_MULTICAST_ADDRESS); //IPAddress.Parse(fromSettings("groupAddress", CANUDP_MULTICAST_ADDRESS));
            //DONT CARE ABOUT WHICH NETWORK INTERFACE IS USED - AS LONG AS CAN CONNECT TO DEVICE (fixes mainly win7 issues)
            localAddr = IPAddress.Parse("0.0.0.0");
            int groupPort = CANUDP_DEFAULT_PORT;
            busId = CANUDP_BUS_ID;

            try
            {
               /* RegistryKey masterKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Tritium\\CanBridgeConfig", false);
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
                masterKey.Close();*/
            }
            catch (System.Exception)
            {
                //Do nothing! Defaults will be used
            }

            init(groupAddress, groupPort, busId, CANUDP_HOP_LIMIT, localAddr); //init(groupAddress, groupPort, busId, fromSettings("hopLimit", CANUDP_HOP_LIMIT), localAddr);
        }


        ///<summary>Opens the UDP connection of this client. This is necessary to send or receive packets.</summary>
        ///<seealso cref="send"/>
        ///<seealso cref="packetReceived"/>
        public void open()
        {
            openUdp();
        }


        ///<summary>Opens the UDP connection of this client. This is necessary to send or receive packets.</summary>
        public void openUdp()
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
                    udpClient.JoinMulticastGroup(groupEndPoint.Address, hopLimit);

                    // Begin a subthread for packet reception
                    udpClient.BeginReceive(new AsyncCallback(handlePacketReceiveUdp), null);
                }
            }
        }


        ///<summary>Opens the TCP connection of this client. This is necessary to send or receive packets over TCP.</summary>
        public void openTcp( IPAddress ipAddr, uint fwdAddr = 0, uint fwdRange = 0 )
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
                    currentTcpResult = tcpClient.Client.BeginReceive(tcpRecBuffer, 0, ETH_PACKET_LENGTH, SocketFlags.None, new AsyncCallback(handlePacketReceiveTcp), null); //CanPacketSerialiser.PACKET_LENGTH
                }
            }
        }


        ///<summary>Handle a received packet by reading its bus and sender id and calling the packetReceived event if the packet is valid.</summary>
        ///<param name="ar">The IAsyncResult provided by the asynchronuous call.</param>
        protected void handlePacketReceiveUdp(IAsyncResult ar)
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
                    udpClient.BeginReceive(new AsyncCallback(handlePacketReceiveUdp), null);

                }
            }
            if (receiveBytes != null)
            {

                //Deserialise the bulk packets received
                List<UdpPacket> packet = serialiser.deserialise(receiveBytes);

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
                    if (pkt.getBusId() == busId && pkt.getSenderId() != clientId)
                    {
                        if (packetReceived != null)
                        {
                            packetReceived(pkt);
                        }
                    }
                }
            }
        }


        ///<summary>Handle a received packet by reading its bus and sender id and calling the packetReceived event if the packet is valid.</summary>
        ///<param name="ar">The IAsyncResult provided by the asynchronuous call.</param>
        protected void handlePacketReceiveTcp(IAsyncResult ar)
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
                            getBulkCount();
                        }
                    }
                    else
                    {
                        getBulkCount();
                    }
                    

                    // Begin a subthread for packet reception
                    tcpClient.Client.BeginReceive(tcpRecBuffer, 0, ETH_PACKET_LENGTH, SocketFlags.None, new AsyncCallback(handlePacketReceiveTcp), null);//CanPacketSerialiser.PACKET_LENGTH
                     
                }
                
            }
            if (receiveBytes != null)
            {
                List<UdpPacket> packet = null;
                //Deserialise the bulk packets received
                try
                {
                    packet = serialiser.deserialise(receiveBytes, awaitingFirstTcpData, busId, bridgeClientId);
                }
                catch (Exception) {
                    getBulkCount();
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
                    if (pkt.getBusId() == busId && pkt.getSenderId() != clientId)
                    {
                        if (packetReceived != null)
                        {
                            packetReceived(pkt);
                        }
                    }
                }
            }
        }


        ///<summary>Send a CanPacket on the UDP network. The connection should be open before packets can be send.</summary>
        ///<param name="packet">The packet to be send.</param>
        ///<exception cref="IOException">Thrown when the connection is not open.</exception>
        ///<seealso cref="open"/>
        public void send(CanPacket packet)
        {
            Byte[] transmitBytes = serialiser.serialise(packet, busId, clientId);
            sendBytesUdp(transmitBytes);
        }


        ///<summary>Adds a CAN packet to the bulk store which is to be sent over UDP or TCP.</summary>
        public void addToBulk(CanPacket packet)
        {
            packetStore.Add(new CanPacket(packet.getId(), packet.isExtended(), packet.isRTR(), packet.getLength(), packet.getData()));
        }


        ///<summary>Gets the amount of CAN packets awaiting transmission.</summary>
        public int getBulkCount()
        {
            return packetStore.Count();
        }


        ///<summary>Sends the queued up CAN packets over UDP.</summary>
        public void sendBulkUdp()
        {
            Byte[] transmitBytes = serialiser.serialiseBulk(packetStore, busId, clientId, true, false);
            sendBytesUdp(transmitBytes);
            packetStore.Clear();
        }


        ///<summary>Sends the queued up CAN packets over TCP.</summary>
        public void sendBulkTcp( bool isSettings = false )
        {
            byte[] transmitBytes = serialiser.serialiseBulk(packetStore, busId, clientId, isFirstTcpData, isSettings);
	        if ( isFirstTcpData )
	        {
		        // add tcpFwdAdd and tcpFwdRange as preamble
                transmitBytes = CanPacketSerialiser.getBytes(tcpFwdAddr).Concat(CanPacketSerialiser.getBytes(tcpFwdRange)).Concat(transmitBytes).ToArray();
	        }
            sendBytesTcp(transmitBytes);
            packetStore.Clear();
	        isFirstTcpData = false;
        }


        ///<summary>Send a serialised stream of bytes over UDP.</summary>
        protected void sendBytesUdp(byte[] transmitBytes)
        {
            lock (this)
            {
                if (udpClient == null)
                {
                    throw new IOException("Unable to send CAN packets: CanUdpClient is not open");
                }
                // Serialise to byte array and transmit the packet
                udpClient.BeginSend(transmitBytes, transmitBytes.Length, groupEndPoint, new AsyncCallback(sendCallbackUdp), udpClient);
            }
        }


        ///<summary>Finish an asynchronous send.</summary>
        ///<param name="ar">The IAsyncResult provided by the asynchronous call with as state the UdpClient that made the call.</param>
        protected void sendCallbackUdp(IAsyncResult ar)
        {
            UdpClient u = ar.AsyncState as UdpClient;
            // End sending if the connection is still open, otherwise that is impossible.
            if (ar == udpClient)
            {
                u.EndSend(ar);
            }
        }


        ///<summary>Send a serialised stream of bytes over TCP.</summary>
        protected void sendBytesTcp(byte[] transmitBytes)
        {
            lock (this)
            {
                if (tcpClient == null)
                {
                    throw new IOException("Unable to send CAN packets: CanUdpClient is not open");
                }
                // Serialise to byte array and transmit the packet
                tcpClient.Client.BeginSend(transmitBytes, 0, transmitBytes.Length, SocketFlags.None, new AsyncCallback(sendCallbackTcp), tcpClient);
            }
        }


        ///<summary>Finish an asynchronous send via TCP.</summary>
        ///<param name="ar">The IAsyncResult provided by the asynchronous call with as state the TcpClient that made the call.</param>
        protected void sendCallbackTcp(IAsyncResult ar)
        {
            TcpClient t = ar.AsyncState as TcpClient;
            // End sending if the connection is still open, otherwise that is impossible.
            if (ar.AsyncState == tcpClient)
            {
                t.Client.EndSend(ar);
            }
        }


        ///<summary>Close any open UDP and TCP connections.</summary>
        public void close()
        {
            packetReceived = null;  //This will sort out any Form disposed issues
            closeUdp();
            closeTcp();
        }


        ///<summary>Close the UDP connection of this client. After closing no packets can be send and no packets will be received.</summary>
        public void closeUdp()
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
        public void closeTcp()
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


        ///<summary>Returns the identifier of the bus this client is considered to be on.</summary>
        ///<returns>The bus identifier.</returns>
        public UInt64 getBusId()
        {
            return busId;
        }


        ///<summary>Returns the maximum number of hops on the network a packet is allowed to take.</summary>
        ///<returns>The hop limit.</returns>
        public int getHopLimit()
        {
            return hopLimit;
        }


        ///<summary>Returns the unique identifier assigned to this client. This identifier is used to identify the sender of a packet.</summary>
        ///<returns>The identifier of this client.</returns>
        public UInt64 getClientId()
        {
            return clientId;
        }


        ///<summary>Returns the local IP address used to subscribe to multicast packets.</summary>
        ///<returns>The identifier of this client.</returns>
        public IPAddress getLocalAddress()
        {
            return localAddr;
        }
    }
}
