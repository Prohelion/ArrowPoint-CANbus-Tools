using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Canbus
{
    public class CanPacket
    {
        private string SamplePacket { get; set; } = "00547269fdd6000d006508a8c0007f5d0000040400080000000000000000";                                                                                                

        public Boolean IsLittleEndian { get; set; } = true;
        public int PacketIndex { get; set; } = 0;
        private Byte[] rawBytes;

        public CanPacket() {
            RawBytesString = SamplePacket;
            ReceivedDateTime = DateTime.Now;
        }

        public CanPacket(uint canId)
        {
            RawBytesString = SamplePacket;
            CanId = canId;
            ReceivedDateTime = DateTime.Now;
        }

        public CanPacket(String rawBytesString)
        {
            RawBytesString = rawBytesString;
            ReceivedDateTime = DateTime.Now;
        }

        public CanPacket(Byte[] rawBytes)
        {
            RawBytes = rawBytes;
            ReceivedDateTime = DateTime.Now;
        }

        public Byte Byte0 { get { return GetByte(0); } }
        public Byte Byte1 { get { return GetByte(1); } }
        public Byte Byte2 { get { return GetByte(2); } }
        public Byte Byte3 { get { return GetByte(3); } }
        public Byte Byte4 { get { return GetByte(4); } }
        public Byte Byte5 { get { return GetByte(5); } }
        public Byte Byte6 { get { return GetByte(6); } }
        public Byte Byte7 { get { return GetByte(7); } }

        public string Byte0AsHex { get { return GetByte(0).ToString("X"); } }
        public string Byte1AsHex { get { return GetByte(1).ToString("X"); } }
        public string Byte2AsHex { get { return GetByte(2).ToString("X"); } }
        public string Byte3AsHex { get { return GetByte(3).ToString("X"); } }
        public string Byte4AsHex { get { return GetByte(4).ToString("X"); } }
        public string Byte5AsHex { get { return GetByte(5).ToString("X"); } }
        public string Byte6AsHex { get { return GetByte(6).ToString("X"); } }
        public string Byte7AsHex { get { return GetByte(7).ToString("X"); } }

        public int Int16Pos0 { get { return GetInt16(0); } }
        public int Int16Pos1 { get { return GetInt16(1); } }
        public int Int16Pos2 { get { return GetInt16(2); } }
        public int Int16Pos3 { get { return GetInt16(3); } }

        public uint Uint16Pos0 { get { return GetUint16(0); } }
        public uint Uint16Pos1 { get { return GetUint16(1); } }
        public uint Uint16Pos2 { get { return GetUint16(2); } }
        public uint Uint16Pos3 { get { return GetUint16(3); } }

        public int Int32Pos0 { get { return GetInt32(0); } }
        public int Int32Pos1 { get { return GetInt32(1); } }

        public uint Uint32Pos0 { get { return GetUint32(0); } }
        public uint Uint32Pos1 { get { return GetUint32(1); } }

        public float Float0 { get { return GetFloat(0); } }
        public float Float1 { get { return GetFloat(1); } }

        public IPAddress SourceIPAddress { get; set; }
        public int SourceIPPort { get; set; }

        public DateTime ReceivedDateTime;

        public string Flags { get
            {
                string flagsStr = "";

                if (Extended) flagsStr = flagsStr + "E";
                if (Rtr) flagsStr = flagsStr + "R";
                return flagsStr;
            }
        }

        public string RawBytesString
        {
            get
            {
                return MyExtensions.ByteArrayToString(RawBytes);
            }
            set
            {
                RawBytes = MyExtensions.StringToByteArray(value);
            }
        }

        public Byte[] RawBytes
        {
            get { return rawBytes; }
            private set
            {
                if ((value.Length - 16) % 14 == 0)
                {
                    rawBytes = value;
                }
            }
        }

        public string DataBytesString
        {
            get { return MyExtensions.ByteArrayToString(DataBytes); }
        }

        public Byte[] DataBytes
        {
            get { return rawBytes.Skip(22).Take(16).ToArray(); }
        }


        private void ReplaceRawBytes(Byte[] newBytes, int start, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (i < newBytes.Length)
                    rawBytes[start + i] = newBytes[i];                
                else
                    rawBytes[start + i] = 0;
            }
        }

        public string CanIdAsHex
        {
            get
            {
                return "0x" + CanId.ToString("X");
            }

        } 

        public uint CanId {
            get
            {
                return BitConverter.ToUInt32(ForceEndian(RawBytes.Skip(16).Take(4).ToArray(),false), 0);
            }
            set
            {
                ReplaceRawBytes(ForceEndian(BitConverter.GetBytes((Int32)value).ToArray(),false), 16, 4);
            }
        }

        public uint CanIdBase10 {
            get
            {
                try
                {
                    string trimmedValue = MyExtensions.Trim0x(CanIdAsHex);
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
                CanId = (uint)Convert.ToInt32(hexValue, 16);
            }
        }

        public bool Extended {
            get
            {
                byte[] flagBytes = RawBytes.Skip(20).Take(1).ToArray();

                if ((flagBytes[0] & (1 << 0)) == 1)
                {
                    return true;
                }

                return false;
            }

            set
            {
                if (value)
                {
                    RawBytes[20] = (byte)(RawBytes[20] | (1 << 0));
                }
                else
                {
                    RawBytes[20] = (byte)(RawBytes[20] & (0 << 0));
                }
            }
        }

        public bool Rtr
        {
           get
           {
                byte[] flagBytes = RawBytes.Skip(20).Take(1).ToArray();

                if ((flagBytes[0] & (1 << 1)) == 2)
                {
                    return true;
                }

                return false;
            }

            set
            {
                if (value)
                {
                    RawBytes[20] = (byte)(RawBytes[20] | (1 << 1));
                }
                else
                {
                    RawBytes[20] = (byte)(RawBytes[20] & (0 << 1));
                }
            }
        }

        public byte GetByte(int index)
        {
            if (index > 7) throw new IndexOutOfRangeException("Max index for a getByte operation is 7");

            int pos = 22 + index;
            return RawBytes.Skip(pos).Take(1).ToArray()[0];
        }

        public void SetByte(int index, byte newByte)
        {
            if (index > 7) throw new IndexOutOfRangeException("Max index for a setByte operation is 7");

            int pos = 22 + index;
            RawBytes[pos] = newByte;
        }

        public void ClearBytes() {
            for (int i = 0; i < 8; i++) {
                this.SetInt8(i, 0);
            }
        }

        public string GetByteString(int index)
        {
            if (index > 7) throw new IndexOutOfRangeException("Max index for a GetByteString operation is 7");

            int pos = 22 + index;
            return MyExtensions.ByteArrayToString(RawBytes.Skip(pos).Take(1).ToArray());
        }

        public void SetByteString(int index, string byteString)
        {
            if (byteString.Length == 1)
            {
                byteString = "0" + byteString;
            }
            else if (byteString.Length != 2)
            {
                throw new IndexOutOfRangeException("Byte" + index.ToString() + " must have a length of 2");
            }

            if (index > 7) throw new IndexOutOfRangeException("Max index for a SetByteString operation is 7");

            int pos = 22 + index;
            ReplaceRawBytes(MyExtensions.StringToByteArray(byteString), pos, 1);
        }

        public int GetInt8(int index)
        {
            if (index > 7) throw new IndexOutOfRangeException("Max index for a GetInt8 operation is 7");

            int pos = 22 + index;
            return MyExtensions.ByteToInt8(RawBytes.Skip(pos).Take(1).ToArray());
        }

        public void SetInt8(int index, int newInt)
        {
            if (index > 7) throw new IndexOutOfRangeException("Max index for a SetInt8 operation is 7");
            
            int pos = 22 + index;
            RawBytes[pos] = MyExtensions.Int8ToByte(newInt);            
        }

        public uint GetUint8(int index)
        {
            if (index > 7) throw new IndexOutOfRangeException("Max index for a setUInt8 operation is 7");

            int pos = 22 + index;
            return MyExtensions.ByteToUInt8(RawBytes.Skip(pos).Take(1).ToArray());
        }

        public void SetUint8(int index, uint newUInt)
        {
            if (index > 7) throw new IndexOutOfRangeException("Max index for a setUInt8 operation is 7");

            int pos = 22 + index;
            RawBytes[pos] = MyExtensions.UInt8ToByte(newUInt);
        }

        public int GetInt16(int index)
        {
            if (index > 3) throw new IndexOutOfRangeException("Max index for a GetInt16 operation is 3");
            
            int pos = 22 + (2 * index);            
            return BitConverter.ToInt16(EndianCorrectArray(RawBytes.Skip(pos).Take(2).ToArray()), 0);
        }

        public void SetInt16(int index, int newInt)
        {
            if (index > 3) throw new IndexOutOfRangeException("Max index for a SetInt16 operation is 3");

            int pos = 22 + (2 * index);
            ReplaceRawBytes(EndianCorrectArray(BitConverter.GetBytes((Int16)newInt).ToArray()), pos, 2);
        }

        public uint GetUint16(int index)
        {
            if (index > 3) throw new IndexOutOfRangeException("Max index for a GetUInt16 operation is 3");

            int pos = 22 + (2 * index);
            return BitConverter.ToUInt16(EndianCorrectArray(RawBytes.Skip(pos).Take(2).ToArray()), 0);
        }

        public void SetUint16(int index, uint newUInt)
        {
            if (index > 3) throw new IndexOutOfRangeException("Max index for a setUInt16 operation is 3");

            int pos = 22 + (2 * index);
            ReplaceRawBytes(EndianCorrectArray(BitConverter.GetBytes((UInt16)newUInt).ToArray()), pos, 2);
        }

        public int GetInt32(int index)
        {
            if (index > 1) throw new IndexOutOfRangeException("Max index for a GetInt32 operation is 1");

            int pos = 22 + (4 * index);
            return BitConverter.ToInt32(EndianCorrectArray(RawBytes.Skip(pos).Take(4).ToArray()), 0);
        }

        public void SetInt32(int index, int newInt)
        {
            if (index > 1) throw new IndexOutOfRangeException("Max index for a setInt32 operation is 1");

            int pos = 22 + (4 * index);
            ReplaceRawBytes(EndianCorrectArray(BitConverter.GetBytes((Int32)newInt).ToArray()), pos, 4);
        }

        public uint GetUint32(int index)
        {
            if (index > 1) throw new IndexOutOfRangeException("Max index for a GetUInt32 operation is 1");

            int pos = 22 + (4 * index);
            return BitConverter.ToUInt32(EndianCorrectArray(RawBytes.Skip(pos).Take(4).ToArray()), 0);
        }

        public void SetUint32(int index, int newUInt)
        {
            if (index > 1) throw new IndexOutOfRangeException("Max index for a setUInt32 operation is 1");

            int pos = 22 + (4 * index);
            ReplaceRawBytes(EndianCorrectArray(BitConverter.GetBytes((UInt32)newUInt).ToArray()), pos, 4);
        }

        public float GetFloat(int index)
        {
            if (index > 1) throw new IndexOutOfRangeException("Max index for a SetFloat operation is 1");

            int pos = 22 + (4 * index);
            return BitConverter.ToSingle(EndianCorrectArray(RawBytes.Skip(pos).Take(4).ToArray()), 0);
        }

        public void SetFloat(int index, float newFloat)
        {
            if (index > 1) throw new IndexOutOfRangeException("Max index for a SetFloat operation is 1");

            int pos = 22 + (4 * index);
            ReplaceRawBytes(EndianCorrectArray(BitConverter.GetBytes(newFloat).ToArray()), pos, 4);
        }

        public int MilisecondsSinceReceived
        {
            get
            {
                TimeSpan span = DateTime.Now - ReceivedDateTime;
                return (int)span.TotalMilliseconds;
            }
        }

        private byte[] EndianCorrectArray(byte[] inputByteArray)
        {
            if (BitConverter.IsLittleEndian == IsLittleEndian)
                return inputByteArray;
            
            Array.Reverse(inputByteArray, 0, inputByteArray.Length);
            return (inputByteArray);
        }

        private byte[] ForceEndian(byte[] inputByteArray, Boolean littleEndian)
        {
            if (BitConverter.IsLittleEndian == littleEndian)
                return inputByteArray;

            Array.Reverse(inputByteArray, 0, inputByteArray.Length);
            return (inputByteArray);
        }

    }
}
