using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tritium.CanLibrary
{
    ///<summary>This class represents a CAN packet.</summary>
    public class CanPacket
    {
        ///<summary>Identifier of the packet. This identifier is 11 or 29 bits long.</summary>
        protected UInt32 id;

        ///<summary>Identifies if this is an extended packet.</summary>
        protected Boolean extended;

        ///<summary>Identifies if this is a remote frame.</summary>
        protected Boolean rtr;

        ///<summary>Length of the data contained by this packet.</summary>
        protected Byte length;

        ///<summary>The data contained by this packet.</summary>
        protected UInt64 data;

        ///<summary>Creates a new CAN packet using the data given.</summary>
        ///<param name="id">The identifier of the packet. This identifier must be in the 11 or 29 bits range as specified in the CAN protocol.</param>
        ///<param name="extended">True if the packet is an extended one and the id is 29 bits, false when the id is 11 bits.</param>
        ///<param name="rtr">True if this is a remote frame. In this case, the data must be zero.</param>
        ///<param name="length">The length of the data in bytes. This is allowed to be more than the maximum data length of 8 bytes, but should be strictly less than 16 as specified in the CAN protocol.</param>
        ///<param name="data">The data contained by this packet. The data should be in host order, using the highest order bytes.</param>
        ///<exception cref="OverflowException">Thrown when the identifier is larger than 29 bits, or larger than 11 bits when the packet is not extended. Also thrown when the length is larger than 4 bits.</exception>
        public CanPacket(UInt32 id, Boolean extended, Boolean rtr, Byte length, UInt64 data)
        {
            if (!extended && id >= (1 << 11)) {
                throw new OverflowException("Identifier larger than 11 bits");
            }
            if (id >= (1 << 29))
            {
                throw new OverflowException("Extended identifier larger than 29 bits");
            }
            //if (length > 0xF)
            //{
            //    throw new OverflowException("Length larger than 4 bits");
            //}
            //if (rtr && data != 0)
            //{
            //    throw new OverflowException("Data not zero on a remote frame");
            //}
            this.id = id;
            this.extended = extended;
            this.rtr = rtr;
            this.length = length;
            this.data = data;
        }

        ///<summary>Creates a new CAN packet using the data given.</summary>
        ///<param name="id">The identifier of the packet. This identifier must be in the 11 or 29 bits range as specified in the CAN protocol.</param>
        ///<param name="extended">True if the packet is an extended one and the id is 29 bits, false when the id is 11 bits.</param>
        ///<param name="length">The length of the data in bytes. This is allowed to be more than the maximum data length of 8 bytes, but should be strictly less than 16 as specified in the CAN protocol.</param>
        ///<param name="data">The data contained by this packet. The data should be in host order, using the highest order bytes.</param>
        ///<exception cref="OverflowException">Thrown when the identifier is larger than 29 bits, or larger than 11 bits when the packet is not extended. Also thrown when the length is larger than 4 bits.</exception>
        public CanPacket(UInt32 id, Boolean extended, Byte length, UInt64 data)
            : this(id, extended, false, length, data)
        {
            // Nothing to be done
        }

        ///<summary>Creates a new dataless CAN packet.</summary>
        ///<param name="id">The identifier of the packet. This identifier must be in the 11 or 29 bits range as specified in the CAN protocol.</param>
        ///<param name="extended">True if the packet is an extended one and the id is 29 bits, false when the id is 11 bits.</param>
        ///<param name="rtr">True if this is a remote frame.</param>
        ///<param name="length">The length of the data in bytes. This is allowed to be more than the maximum data length of 8 bytes, but should be strictly less than 16 as specified in the CAN protocol.</param>
        ///<exception cref="OverflowException">Thrown when the identifier is larger than 29 bits, or larger than 11 bits when the packet is not extended.</exception>
        public CanPacket(UInt32 id, Boolean extended, Boolean rtr, Byte length)
            : this(id, extended, rtr, length, 0)
        {
            // Nothing to be done
        }

        ///<summary>Creates a new CAN packet using the data given.</summary>
        ///<param name="id">The identifier of the packet. This identifier must be in the 11 or 29 bits range as specified in the CAN protocol.</param>
        ///<param name="extended">True if the packet is an extended one and the id is 29 bits, false when the id is 11 bits.</param>
        ///<param name="rtr">True if this is a remote frame. In this case, the data must be zero.</param>
        ///<param name="length">The length of the data in bytes. This is allowed to be more than the maximum data length of 8 bytes, but should be strictly less than 16 as specified in the CAN protocol.</param>
        ///<param name="data">The data contained by this packet. The data should be in network order.</param>
        ///<exception cref="OverflowException">Thrown when the identifier is larger than 29 bits, or larger than 11 bits when the packet is not extended. Also thrown when the length is larger than 4 bits.</exception>
        public CanPacket(UInt32 id, Boolean extended, Boolean rtr, Byte length, byte[] data)
            : this(id, extended, rtr, length, 0)
        {
            byte[] data2 = new byte[8];
            data.CopyTo(data2, 0);
            this.data = CanPacketSerialiser.bytesToUInt64(data2, 0);
        }

        ///<summary>Creates a new CAN packet using the data given.</summary>
        ///<param name="id">The identifier of the packet. This identifier must be in the 11 or 29 bits range as specified in the CAN protocol.</param>
        ///<param name="extended">True if the packet is an extended one and the id is 29 bits, false when the id is 11 bits.</param>
        ///<param name="length">The length of the data in bytes. This is allowed to be more than the maximum data length of 8 bytes, but should be strictly less than 16 as specified in the CAN protocol.</param>
        ///<param name="data">The data contained by this packet. The data should be in network order.</param>
        ///<exception cref="OverflowException">Thrown when the identifier is larger than 29 bits, or larger than 11 bits when the packet is not extended. Also thrown when the length is larger than 4 bits.</exception>
        public CanPacket(UInt32 id, Boolean extended, Byte length, byte[] data)
            : this(id, extended, false, length, data)
        {
            // Nothing to be done
        }

        ///<summary>Creates a new CAN packet using the data given and sets the length of the packet to the length of the array containing the data.</summary>
        ///<param name="id">The identifier of the packet. This identifier must be in the 11 or 29 bits range as specified in the CAN protocol.</param>
        ///<param name="extended">True if the packet is an extended one and the id is 29 bits, false when the id is 11 bits.</param>
        ///<param name="data">The data contained by this packet. The data should be in network order.</param>
        ///<exception cref="OverflowException">Thrown when the identifier is larger than 29 bits, or larger than 11 bits when the packet is not extended. Also thrown when the length is larger than 4 bits.</exception>
        public CanPacket(UInt32 id, Boolean extended, byte[] data)
            : this(id, extended, (byte)data.Length, data)
        {
            // Nothing to be done
        }

        ///<summary>Returns the identifier of this packet. Depending on <see cref="isExtended()"/> the identifier is 29 or 11 bits long.</summary>
        ///<returns>The identifier of this packet.</returns>
        public UInt32 getId()
        {
            return id;
        }

        ///<summary>Returns whether this is an extended packet.</summary>
        ///<returns>True if this is an extended packet.</returns>
        public Boolean isExtended()
        {
            return extended;
        }

        ///<summary>Returns whether this is a remote frame.</summary>
        ///<returns>True if this is a remote frame.</returns>
        public Boolean isRTR()
        {
            return rtr;
        }

        ///<summary>Returns the data contained by this packet in host order. The data is contained in the highest order bytes.</summary>
        ///<returns>The data contained by this packet.</returns>
        public UInt64 getData()
        {
            return data;
        }

        ///<summary>Returns the data contained by this packet in host order. The data is contained in the lowest order bytes.</summary>
        ///<returns>The data contained by this packet.</returns>
        public UInt64 getDataValue()
        {
            return data >> ((8 - Math.Min(length, (byte)8)) * 8);
        }

        ///<summary>Returns the data contained by this packet in network order.</summary>
        ///<returns>The data contained by this packet.</returns>
        public byte[] getDataArray()
        {
            return CanPacketSerialiser.getBytes(data);
        }

        ///<summary>Returns the length of the data contained by this packet.</summary>
        ///<returns>The length of the data contained by this packet as specified in the CAN protocol.</returns>
        public Byte getLength()
        {
            return length;
        }

        /// <summary>Returns a <see cref="String"/> that represents the current <see cref="CanPacket"/>.</summary>
        /// <returns>A <see cref="String"/> that represents the current <see cref="CanPacket"/>.</returns>
        public override String ToString()
        {
            return "{" + base.ToString() + ",id=" + id.ToString("X3") + ",extended=" + extended + ",rtr=" + rtr + ",length=" + length.ToString("X1") + ",data=" + data.ToString("X16") + "}";
        }
    }
}
