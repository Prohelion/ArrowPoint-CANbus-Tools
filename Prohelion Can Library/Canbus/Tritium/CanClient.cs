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

namespace Tritium.CanLibrary
{
    ///<summary>A client to send CAN messages.</summary>
    public interface CanClient
    {
        ///<summary>Opens the connection of this client. This is necessary to send messages.</summary>
        ///<seealso cref="send"/>
        void open();

        ///<summary>Send a CanPacket. The connection should be open before messages can be send.</summary>
        ///<param name="packet">The message to be send.</param>
        ///<exception cref="IOException">Thrown when the connection is not open.</exception>
        ///<seealso cref="open"/>
        void send(CanPacket packet);

        ///<summary>Close the connection of this client. After closing no messages can be send.</summary>
        void close();
    }
}
