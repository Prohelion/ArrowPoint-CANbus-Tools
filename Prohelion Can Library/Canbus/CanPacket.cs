using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Prohelion.CanLibrary
{
    public class CanPacket
    {
        private string SamplePacket { get; set; } = "005472697469756d00be61fea90031010000050800080000000000000000";

        ///<summary>Identifier of the packet. This identifier is 11 or 29 bits long.</summary>
        public UInt32 CanId { get; set; }

        public string CanIdAsHex
        {
            get
            {
                return "0x" + this.CanId.ToString("X");
            }
        }

        public uint CanIdBase10
        {
            get
            {
                try
                {
                    string trimmedValue = CanUtilities.Trim0x(CanIdAsHex);
                    return uint.Parse(trimmedValue, System.Globalization.NumberStyles.HexNumber);
                }
                catch
                {
                    return 0;
                }
            }

            set
            {
                string hexValue = value.ToString("X");
                this.CanId = (uint)Convert.ToInt32(hexValue, 16);
            }
        }

        ///<summary>Identifies if this is an extended packet.</summary>
        public Boolean Extended { get; set; }

        ///<summary>Identifies if this is a remote frame.</summary>
        public Boolean Rtr { get; set; }

        ///<summary>Length of the data contained by this packet.</summary>
        public Byte Length { get; private set; }

        ///<summary>The data contained by this packet. Returns the data contained by this packet in host order. The data is contained in the lowest order bytes.</summary>
        ///<returns>The data contained by this packet.</returns>
        public UInt64 Data { get { return this.Data >> ((8 - Math.Min(this.Length, (byte)8)) * 8); }  private set { this.Data = value; } }

        // To do
        public string RawBytesString { get; set; }

        // Data overlay (union) structure for CAN packet formatting
        [StructLayout(LayoutKind.Explicit, Size = 64)]
        private struct CanPacketUnion64
        {
            [FieldOffset(0)]
            public ulong data_ulong;

            [FieldOffset(0)]
            public float data_fp_0;
            [FieldOffset(4)]
            public float data_fp_1;

            [FieldOffset(0)]
            public int data_32_0;
            [FieldOffset(4)]
            public int data_32_1;

            [FieldOffset(0)]
            public uint data_u32_0;
            [FieldOffset(4)]
            public uint data_u32_1;

            [FieldOffset(0)]
            public short data_16_0;
            [FieldOffset(2)]
            public short data_16_1;
            [FieldOffset(4)]
            public short data_16_2;
            [FieldOffset(6)]
            public short data_16_3;

            [FieldOffset(0)]
            public ushort data_u16_0;
            [FieldOffset(2)]
            public ushort data_u16_1;
            [FieldOffset(4)]
            public ushort data_u16_2;
            [FieldOffset(6)]
            public ushort data_u16_3;

            [FieldOffset(0)]
            public sbyte data_8_0;
            [FieldOffset(1)]
            public sbyte data_8_1;
            [FieldOffset(2)]
            public sbyte data_8_2;
            [FieldOffset(3)]
            public sbyte data_8_3;
            [FieldOffset(4)]
            public sbyte data_8_4;
            [FieldOffset(5)]
            public sbyte data_8_5;
            [FieldOffset(6)]
            public sbyte data_8_6;
            [FieldOffset(7)]
            public sbyte data_8_7;

            [FieldOffset(0)]
            public byte data_u8_0;
            [FieldOffset(1)]
            public byte data_u8_1;
            [FieldOffset(2)]
            public byte data_u8_2;
            [FieldOffset(3)]
            public byte data_u8_3;
            [FieldOffset(4)]
            public byte data_u8_4;
            [FieldOffset(5)]
            public byte data_u8_5;
            [FieldOffset(6)]
            public byte data_u8_6;
            [FieldOffset(7)]
            public byte data_u8_7;

        }

        private CanPacketUnion64 dataUnion = new CanPacketUnion64();

        public float FloatPos0 { get { return dataUnion.data_fp_0; } set { dataUnion.data_fp_0 = value; } }
        public float FloatPos1 { get { return dataUnion.data_fp_1; } set { dataUnion.data_fp_1 = value; } }

        public int Int32Pos0 { get { return dataUnion.data_32_0; } set { dataUnion.data_32_0 = value; } }
        public int Int32Pos1 { get { return dataUnion.data_32_1; } set { dataUnion.data_32_1 = value; } }

        public uint UInt32Pos0 { get { return dataUnion.data_u32_0; } set { dataUnion.data_u32_0 = value; } }
        public uint UInt32Pos1 { get { return dataUnion.data_u32_1; } set { dataUnion.data_u32_1 = value; } }

        public short Short16Pos0 { get { return dataUnion.data_16_0; } set { dataUnion.data_16_0 = value; } }
        public short Short16Pos1 { get { return dataUnion.data_16_1; } set { dataUnion.data_16_1 = value; } }
        public short Short16Pos2 { get { return dataUnion.data_16_2; } set { dataUnion.data_16_2 = value; } }
        public short Short16Pos3 { get { return dataUnion.data_16_3; } set { dataUnion.data_16_3 = value; } }

        public ushort UShort16Pos0 { get { return dataUnion.data_u16_0; } set { dataUnion.data_u16_0 = value; } }
        public ushort UShort16Pos1 { get { return dataUnion.data_u16_1; } set { dataUnion.data_u16_1 = value; } }
        public ushort UShort16Pos2 { get { return dataUnion.data_u16_2; } set { dataUnion.data_u16_2 = value; } }
        public ushort UShort16Pos3 { get { return dataUnion.data_u16_3; } set { dataUnion.data_u16_3 = value; } }

        public sbyte BytePos0 { get { return dataUnion.data_8_0; } set { dataUnion.data_8_0 = value; } }
        public sbyte BytePos1 { get { return dataUnion.data_8_1; } set { dataUnion.data_8_1 = value; } }
        public sbyte BytePos2 { get { return dataUnion.data_8_2; } set { dataUnion.data_8_2 = value; } }
        public sbyte BytePos3 { get { return dataUnion.data_8_3; } set { dataUnion.data_8_3 = value; } }
        public sbyte BytePos4 { get { return dataUnion.data_8_4; } set { dataUnion.data_8_4 = value; } }
        public sbyte BytePos5 { get { return dataUnion.data_8_5; } set { dataUnion.data_8_5 = value; } }
        public sbyte BytePos6 { get { return dataUnion.data_8_6; } set { dataUnion.data_8_6 = value; } }
        public sbyte BytePos7 { get { return dataUnion.data_8_7; } set { dataUnion.data_8_7 = value; } }

        public byte UBytePos0 { get { return dataUnion.data_u8_0; } set { dataUnion.data_u8_0 = value; } }
        public byte UBytePos1 { get { return dataUnion.data_u8_1; } set { dataUnion.data_u8_1 = value; } }
        public byte UBytePos2 { get { return dataUnion.data_u8_2; } set { dataUnion.data_u8_2 = value; } }
        public byte UBytePos3 { get { return dataUnion.data_u8_3; } set { dataUnion.data_u8_3 = value; } }
        public byte UBytePos4 { get { return dataUnion.data_u8_4; } set { dataUnion.data_u8_4 = value; } }
        public byte UBytePos5 { get { return dataUnion.data_u8_5; } set { dataUnion.data_u8_5 = value; } }
        public byte UBytePos6 { get { return dataUnion.data_u8_6; } set { dataUnion.data_u8_6 = value; } }
        public byte UBytePos7 { get { return dataUnion.data_u8_7; } set { dataUnion.data_u8_7 = value; } }

        public int Int8Pos0 { get { return Convert.ToInt16(dataUnion.data_8_0); } set { dataUnion.data_8_0 = Convert.ToSByte(value); } }
        public int Int8Pos1 { get { return Convert.ToInt16(dataUnion.data_8_1); } set { dataUnion.data_8_1 = Convert.ToSByte(value); } }
        public int Int8Pos2 { get { return Convert.ToInt16(dataUnion.data_8_2); } set { dataUnion.data_8_2 = Convert.ToSByte(value); } }
        public int Int8Pos3 { get { return Convert.ToInt16(dataUnion.data_8_3); } set { dataUnion.data_8_3 = Convert.ToSByte(value); } }
        public int Int8Pos4 { get { return Convert.ToInt16(dataUnion.data_8_4); } set { dataUnion.data_8_4 = Convert.ToSByte(value); } }
        public int Int8Pos5 { get { return Convert.ToInt16(dataUnion.data_8_5); } set { dataUnion.data_8_5 = Convert.ToSByte(value); } }
        public int Int8Pos6 { get { return Convert.ToInt16(dataUnion.data_8_6); } set { dataUnion.data_8_6 = Convert.ToSByte(value); } }
        public int Int8Pos7 { get { return Convert.ToInt16(dataUnion.data_8_7); } set { dataUnion.data_8_7 = Convert.ToSByte(value); } }

        public uint UInt8Pos0 { get { return Convert.ToUInt16(dataUnion.data_u8_0); } set { dataUnion.data_u8_0 = Convert.ToByte(value); } }
        public uint UInt8Pos1 { get { return Convert.ToUInt16(dataUnion.data_u8_1); } set { dataUnion.data_u8_1 = Convert.ToByte(value); } }
        public uint UInt8Pos2 { get { return Convert.ToUInt16(dataUnion.data_u8_2); } set { dataUnion.data_u8_2 = Convert.ToByte(value); } }
        public uint UInt8Pos3 { get { return Convert.ToUInt16(dataUnion.data_u8_3); } set { dataUnion.data_u8_3 = Convert.ToByte(value); } }
        public uint UInt8Pos4 { get { return Convert.ToUInt16(dataUnion.data_u8_4); } set { dataUnion.data_u8_4 = Convert.ToByte(value); } }
        public uint UInt8Pos5 { get { return Convert.ToUInt16(dataUnion.data_u8_5); } set { dataUnion.data_u8_5 = Convert.ToByte(value); } }
        public uint UInt8Pos6 { get { return Convert.ToUInt16(dataUnion.data_u8_6); } set { dataUnion.data_u8_6 = Convert.ToByte(value); } }
        public uint UInt8Pos7 { get { return Convert.ToUInt16(dataUnion.data_u8_7); } set { dataUnion.data_u8_7 = Convert.ToByte(value); } }

        public string Byte0AsHex { get { return BytePos0.ToString("X"); } }
        public string Byte1AsHex { get { return BytePos1.ToString("X"); } }
        public string Byte2AsHex { get { return BytePos2.ToString("X"); } }
        public string Byte3AsHex { get { return BytePos3.ToString("X"); } }
        public string Byte4AsHex { get { return BytePos4.ToString("X"); } }
        public string Byte5AsHex { get { return BytePos5.ToString("X"); } }
        public string Byte6AsHex { get { return BytePos6.ToString("X"); } }
        public string Byte7AsHex { get { return BytePos7.ToString("X"); } }

        public IPAddress SourceIPAddress { get; set; }
        public int SourceIPPort { get; set; }
        
        public int PacketIndex { get; set; }

        private readonly DateTime receivedDateTime;

        ///<summary>Creates a new CAN packet using the data given.</summary>
        ///<param name="id">The identifier of the packet. This identifier must be in the 11 or 29 bits range as specified in the CAN protocol.</param>
        ///<param name="extended">True if the packet is an extended one and the id is 29 bits, false when the id is 11 bits.</param>
        ///<param name="rtr">True if this is a remote frame. In this case, the data must be zero.</param>
        ///<param name="length">The length of the data in bytes. This is allowed to be more than the maximum data length of 8 bytes, but should be strictly less than 16 as specified in the CAN protocol.</param>
        ///<param name="data">The data contained by this packet. The data should be in host order, using the highest order bytes.</param>
        ///<exception cref="OverflowException">Thrown when the identifier is larger than 29 bits, or larger than 11 bits when the packet is not extended. Also thrown when the length is larger than 4 bits.</exception>
        public CanPacket(UInt32 id, Boolean extended, Boolean rtr, Byte length, UInt64 data)
        {
            if (!extended && id >= (1 << 11))
            {
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
            this.CanId = id;
            this.Extended = extended;
            this.Rtr = rtr;
            this.Length = length;
            this.Data = data;

            this.receivedDateTime = DateTime.Now;
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
            Contract.Requires(data != null);

            byte[] data2 = new byte[8];
            data.CopyTo(data2, 0);
            this.Data = CanUtilities.BytesToUInt64(data2, 0);
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

        public CanPacket(UInt32 canId) 
            : this(canId, false, null)
        {
            // Nothing to be done
        }

        public CanPacket(byte[] rawBytes)
        {
            // Todo
            // Nothing to be done
        }

        public CanPacket(string rawBytes)
        {
            // Todo
            // Nothing to be done
        }


        ///<summary>Returns the data contained by this packet in network order.</summary>
        ///<returns>The data contained by this packet.</returns>
        public byte[] GetDataArray()
        {
            return CanUtilities.GetBytes(this.Data);
        }

        /// <summary>Returns a <see cref="String"/> that represents the current <see cref="CanPacket"/>.</summary>
        /// <returns>A <see cref="String"/> that represents the current <see cref="CanPacket"/>.</returns>
        public override String ToString()
        {
            return "{" + base.ToString() + ",id=" + this.CanId.ToString("X3") + ",extended=" + this.Extended + ",rtr=" + this.Rtr + ",length=" + this.Length.ToString("X1") + ",data=" + this.Data.ToString("X16") + "}";
        }

        public Boolean IsLittleEndian { get; set; } = true;        

        public string Flags { get
            {
                string flagsStr = "";

                if (Extended) flagsStr = flagsStr + "E";
                if (Rtr) flagsStr = flagsStr + "R";
                return flagsStr;
            }
        }

        public int MilisecondsSinceReceived
        {
            get
            {
                TimeSpan span = DateTime.Now - receivedDateTime;
                return (int)span.TotalMilliseconds;
            }
        }

    }
}
