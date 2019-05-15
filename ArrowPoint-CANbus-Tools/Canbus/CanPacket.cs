using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.CanBus
{
    public class CanPacket
    {
        private string SamplePacket { get; set; } = "005472697469756d006508a8c0007f5d0000012300080000000000000000";

        public Boolean BigEndian { get; set; } = false;
        public int PacketIndex { get; set; } = 0;

        public CanPacket() {
            SetRawBytesString(SamplePacket);
        }

        public CanPacket(int canIdBase10)
        {
            SetRawBytesString(SamplePacket);
            CanIdBase10 = canIdBase10;
        }

        public CanPacket(String rawBytesString)
        {
            this.SetRawBytesString(rawBytesString);
        }

        public CanPacket(Byte[] rawBytes)
        {
            RawBytes = rawBytes;
        }

        private Byte[] RawBytes
        {

            get { return RawBytes; }
            set
            {
                if ((value.Length - 16) % 14 == 0)
                {
                    this.RawBytes = value;
                }
            }

        }

        public Byte[] GetRawBytes()
        {
            return RawBytes;
        }

        private void ReplaceRawBytes(Byte[] newBytes, int start, int length)
        {
            for (int i = 0; i < length; i++)
            {
                RawBytes[start + i] = newBytes[i];
            }
        }

        public string GetRawBytesString()
        {
            return MyExtentions.ByteArrayToString(RawBytes);
        }

        public void SetRawBytesString(string newBytesString)
        {
            RawBytes = MyExtentions.StringToByteArray(newBytesString);        
        }

        public string CanId {
            get
            {
                return MyExtentions.ByteArrayToString(RawBytes.Skip(16).Take(4).ToArray()); ;
            }

            set
            {
                ReplaceRawBytes(MyExtentions.StringToByteArray(value), 16, 4);                
            }
        }

        public int CanIdBase10 {
            get
            {
                return BitConverter.ToInt32(RawBytes.Skip(16).Take(4).Reverse().ToArray(), 0);
            }

            set
            {
                ReplaceRawBytes(BitConverter.GetBytes((Int32)value).Reverse().ToArray(), 16, 4);                
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
            return MyExtentions.ByteArrayToString(RawBytes.Skip(pos).Take(1).ToArray());
        }

        public void SetByteString(int index, string newByte)
        {
            if (index > 7) throw new IndexOutOfRangeException("Max index for a SetByteString operation is 7");

            int pos = 22 + index;

            ReplaceRawBytes(MyExtentions.StringToByteArray(newByte), pos, 1);
        }

        public int GetInt8(int index)
        {
            if (index > 7) throw new IndexOutOfRangeException("Max index for a GetInt8 operation is 7");

            int pos = 22 + index;
            return MyExtentions.ByteToInt8(RawBytes.Skip(pos).Take(1).ToArray());
        }

        public void SetInt8(int index, int newInt)
        {
            if (index > 7) throw new IndexOutOfRangeException("Max index for a SetInt8 operation is 7");
            
            int pos = 22 + index;
            RawBytes[pos] = MyExtentions.Int8ToByte(newInt);            
        }

        public uint GetUInt8(int index)
        {
            if (index > 7) throw new IndexOutOfRangeException("Max index for a setUInt8 operation is 7");

            int pos = 22 + index;
            return MyExtentions.ByteToUInt8(RawBytes.Skip(pos).Take(1).ToArray());
        }

        public void SetUInt8(int index, uint newUInt)
        {
            if (index > 7) throw new IndexOutOfRangeException("Max index for a setUInt8 operation is 7");

            int pos = 22 + index;
            RawBytes[pos] = MyExtentions.UInt8ToByte(newUInt);
        }

        public int GetInt16(int index)
        {
            if (index > 3) throw new IndexOutOfRangeException("Max index for a GetInt16 operation is 3");
            
            int pos = 22 + (2 * index);
            return BitConverter.ToInt16(RawBytes.Skip(pos).Take(2).ToArray(), 0);
        }

        public void SetInt16(int index, int newInt)
        {
            if (index > 3) throw new IndexOutOfRangeException("Max index for a SetInt16 operation is 3");

            int pos = 22 + (2 * index);
            ReplaceRawBytes(BitConverter.GetBytes((Int16)newInt).ToArray(), pos, 2);
        }

        public uint GetUInt16(int index)
        {
            if (index > 3) throw new IndexOutOfRangeException("Max index for a GetUInt16 operation is 3");

            int pos = 22 + (2 * index);
            return BitConverter.ToUInt16(RawBytes.Skip(pos).Take(2).ToArray(), 0);
        }

        public void SetUInt16(int index, uint newUInt)
        {
            if (index > 3) throw new IndexOutOfRangeException("Max index for a setUInt16 operation is 3");

            int pos = 22 + (2 * index);
            ReplaceRawBytes(BitConverter.GetBytes((UInt16)newUInt).ToArray(), pos, 2);
        }

        public int GetInt32(int index)
        {
            if (index > 1) throw new IndexOutOfRangeException("Max index for a GetInt32 operation is 1");

            int pos = 22 + (4 * index);
            return BitConverter.ToInt32(RawBytes.Skip(pos).Take(4).ToArray(), 0);
        }

        public void SetInt32(int index, int newInt)
        {
            if (index > 1) throw new IndexOutOfRangeException("Max index for a setInt32 operation is 1");

            int pos = 22 + (4 * index);
            ReplaceRawBytes(BitConverter.GetBytes((Int32)newInt).ToArray(), pos, 4);
        }

        public uint GetUInt32(int index)
        {
            if (index > 1) throw new IndexOutOfRangeException("Max index for a GetUInt32 operation is 1");

            int pos = 22 + (4 * index);
            return BitConverter.ToUInt32(RawBytes.Skip(pos).Take(4).ToArray(), 0);
        }

        public void SetUInt32(int index, int newUInt)
        {
            if (index > 1) throw new IndexOutOfRangeException("Max index for a setUInt32 operation is 1");

            int pos = 22 + (4 * index);
            ReplaceRawBytes(BitConverter.GetBytes((UInt32)newUInt).ToArray(), pos, 4);
        }

        public float GetFloat(int index)
        {
            if (index > 1) throw new IndexOutOfRangeException("Max index for a SetFloat operation is 1");

            int pos = 22 + (4 * index);
            return BitConverter.ToSingle(RawBytes.Skip(pos).Take(4).ToArray(), 0);
        }

        public void SetFloat(int index, float newFloat)
        {
            if (index > 1) throw new IndexOutOfRangeException("Max index for a SetFloat operation is 1");

            int pos = 22 + (4 * index);

            ReplaceRawBytes(BitConverter.GetBytes(newFloat).ToArray(), pos, 4);
        }


        /*public void updateRawBytes()
        {
            int currIdBase10 = BitConverter.ToInt16(this.rawBytes.Skip(18).Take(2).Reverse().ToArray(), 0);

            if (currIdBase10 == this.idBase10)
            {
                replaceRawBytes(MyExtentions.StringToByteArray(id), 18, 2);
            }
            else {
                replaceRawBytes(BitConverter.GetBytes((Int16)this.idBase10).Reverse().ToArray(), 18, 2);
            }
            

            this.rawBytes[20] = (byte)(rawBytes[20] & (Convert.ToInt32(extended) << 0));
            this.rawBytes[20] = (byte)(rawBytes[20] & (Convert.ToInt32(rtr) << 1));

            if (compareRawBytes(BitConverter.GetBytes(float0), 22, 4))
            {
                if (compareRawBytes(BitConverter.GetBytes((Int16)int0).Reverse().ToArray(), 22, 2))
                {
                    replaceRawBytes(MyExtentions.StringToByteArray(byte0), 22, 1);
                    replaceRawBytes(MyExtentions.StringToByteArray(byte1), 23, 1);
                }
                else {
                    replaceRawBytes(BitConverter.GetBytes((Int16)int0).Reverse().ToArray(), 22, 2);
                }

                if (compareRawBytes(BitConverter.GetBytes((Int16)int1).Reverse().ToArray(), 24, 2))
                {
                    replaceRawBytes(MyExtentions.StringToByteArray(byte2), 24, 1);
                    replaceRawBytes(MyExtentions.StringToByteArray(byte3), 25, 1);
                }
                else
                {
                    replaceRawBytes(BitConverter.GetBytes((Int16)int1).Reverse().ToArray(), 24, 2);
                }
            }
            else {
                replaceRawBytes(BitConverter.GetBytes(float0), 22, 4);
            }

            if (compareRawBytes(BitConverter.GetBytes(float1), 26, 4))
            {
                if (compareRawBytes(BitConverter.GetBytes((Int16)int2).Reverse().ToArray(), 26, 2))
                {
                    replaceRawBytes(MyExtentions.StringToByteArray(byte4), 26, 1);
                    replaceRawBytes(MyExtentions.StringToByteArray(byte5), 27, 1);
                }
                else
                {
                    replaceRawBytes(BitConverter.GetBytes((Int16)int2).Reverse().ToArray(), 26, 2);
                }

                if (compareRawBytes(BitConverter.GetBytes((Int16)int3).Reverse().ToArray(), 28, 2))
                {
                    replaceRawBytes(MyExtentions.StringToByteArray(byte6), 28, 1);
                    replaceRawBytes(MyExtentions.StringToByteArray(byte7), 29, 1);
                }
                else
                {
                    replaceRawBytes(BitConverter.GetBytes((Int16)int3).Reverse().ToArray(), 28, 2);
                }
            }
            else
            {
                replaceRawBytes(BitConverter.GetBytes(float1), 26, 4);
            }

            this.updateDataFields();
        } 



        private Boolean compareRawBytes(Byte[] newBytes, int start, int length) {
            Boolean isSame = true;

            for (int i = 0; i < length; i++)
            {
                if (this.rawBytes[start + i] != newBytes[i])
                {
                    isSame = isSame && false;
                }
            }

            return isSame;
        } */
    }
}
