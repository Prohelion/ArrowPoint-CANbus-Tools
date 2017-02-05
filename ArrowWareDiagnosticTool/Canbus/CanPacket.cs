using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowWareDiagnosticTool
{
    public class CanPacket
    {
        private string samplePacket = "005472697469756d006508a8c0007f5d0000012300080000000000000000";

        public int packet { get; set; }
        public string canId { get; set; }
        public int canIdBase10 { get; set; }
        public Boolean extended { get; set; }
        public Boolean rtr { get; set; }
        public string flags { get; set; }
        public string byte0 { get; set; }
        public string byte1 { get; set; }
        public string byte2 { get; set; }
        public string byte3 { get; set; }
        public string byte4 { get; set; }
        public string byte5 { get; set; }
        public string byte6 { get; set; }
        public string byte7 { get; set; }
        public int int0 { get; set; }
        public int int1 { get; set; }
        public int int2 { get; set; }
        public int int3 { get; set; }
        public float float0 { get; set; }
        public float float1 { get; set; }
        public string rawBytesStr { get; set; }


        private Byte[] rawBytes;

        public CanPacket() {
            this.setRawBytesString(samplePacket);
        }

        public CanPacket(int canIdBase10)
        {
            this.setRawBytesString(samplePacket);
            this.setCanIdBase10(canIdBase10);
        }

        public CanPacket(String rawBytesString)
        {
            this.setRawBytesString(rawBytesString);
        }

        public CanPacket(Byte[] rawBytes)
        {
            this.setRawBytes(rawBytes);
        }

        public byte[] getRawBytes()
        {
            return this.rawBytes;
        }

        public bool setRawBytes(byte[] newBytes)
        {
            if (newBytes.Length != 30) {
                //return false;
            }

            this.rawBytes = newBytes.Take(30).ToArray(); ;
            updateDataFields();
            return true;
        }

        public string getRawBytesString()
        {
            return MyExtentions.ByteArrayToString(this.getRawBytes());
        }

        public bool setRawBytesString(string newBytesString)
        {
            if (!this.setRawBytes(MyExtentions.StringToByteArray(newBytesString))) {
                return false;
            }

            updateDataFields();
            return true;
        }

        public string getCanId()
        {
            return MyExtentions.ByteArrayToString(this.rawBytes.Skip(18).Take(2).ToArray());;
        }

        public void setCanId(string newCanId)
        {
            replaceRawBytes(MyExtentions.StringToByteArray(newCanId), 18, 2);
            updateDataFields();
        }

        public int getCanIdBase10()
        {
            return BitConverter.ToInt16(this.rawBytes.Skip(18).Take(2).Reverse().ToArray(), 0);
        }

        public void setCanIdBase10(int newCanIdBase10)
        {
            replaceRawBytes(BitConverter.GetBytes((Int16)newCanIdBase10).Reverse().ToArray(), 18, 2);
            updateDataFields();
        }

        public bool getExtended()
        {
            byte[] flagBytes = this.rawBytes.Skip(20).Take(1).ToArray();

            if ((flagBytes[0] & (1 << 0)) == 1)
            {
                return true;
            }

            return false;
        }

        public void setExtended(bool isExtended)
        {
            if (isExtended)
            {
                this.rawBytes[20] = (byte)(rawBytes[20] | (1 << 0));
            }
            else
            {
                this.rawBytes[20] = (byte)(rawBytes[20] & (0 << 0));
            }

            updateDataFields();
        }

        public bool getRtr()
        {
            byte[] flagBytes = this.rawBytes.Skip(20).Take(1).ToArray();

            if ((flagBytes[0] & (1 << 1)) == 2)
            {
                return true;
            }

            return false;
        }

        public void setRtr(bool isRtr)
        {
            if (isRtr)
            {
                this.rawBytes[20] = (byte)(rawBytes[20] | (1 << 1));
            }
            else {
                this.rawBytes[20] = (byte)(rawBytes[20] & (0 << 1));
            }
            
            updateDataFields();
        }

        public byte getByte(int index)
        {
            int pos = 22 + index;
            return this.rawBytes.Skip(pos).Take(1).ToArray()[0];
        }

        public void setByte(int index, byte newByte)
        {
            int pos = 22 + index;

            this.rawBytes[pos] = newByte;
            updateDataFields();
        }

        public void resetBytes() {
            for (int i = 0; i < 8; i++) {
                this.setInt8(i, 0);
            }
        }

        public string getByteString(int index)
        {
            int pos = 22 + index;
            return MyExtentions.ByteArrayToString(this.rawBytes.Skip(pos).Take(1).ToArray());
        }

        public void setByteString(int index, string newByte)
        {
            int pos = 22 + index;

            replaceRawBytes(MyExtentions.StringToByteArray(newByte), pos, 1);
            updateDataFields();
        }

        public int getInt8(int index)
        {
            int pos = 22 + index;
            return MyExtentions.ByteToInt8(this.rawBytes.Skip(pos).Take(1).ToArray());
        }

        public void setInt8(int index, int newInt)
        {
            int pos = 22 + index;

            this.rawBytes[pos] = MyExtentions.Int8ToByte(newInt);
            updateDataFields();
        }

        public int getInt16(int index)
        {
            int pos = 22 + (2 * index);
            return BitConverter.ToInt16(this.rawBytes.Skip(pos).Take(2).Reverse().ToArray(), 0);
        }

        public void setInt16(int index, int newInt)
        {
            int pos = 22 + (2 * index);

            replaceRawBytes(BitConverter.GetBytes((Int16)newInt).Reverse().ToArray(), pos, 2);
            updateDataFields();
        }

        public float getFloat(int index)
        {
            int pos = 22 + (4 * index);
            return BitConverter.ToSingle(this.rawBytes.Skip(pos).Take(4).Reverse().ToArray(), 0);
        }

        public void setFloat(int index, float newFloat)
        {
            int pos = 22 + (4 * index);

            replaceRawBytes(BitConverter.GetBytes(newFloat).Reverse().ToArray(), pos, 4);
            updateDataFields();
        }

        private void updateDataFields()
        {
            this.rawBytesStr = this.getRawBytesString();
            this.canId = this.getCanId();
            this.canIdBase10 = this.getCanIdBase10();
            this.extended = this.getExtended();
            this.rtr = this.getRtr();

            this.flags = "";
            if (this.extended)
            {
                this.flags += "E";
            }

            if (this.rtr)
            {
                this.flags += "R";
            }

            this.byte0 = this.getByteString(0);
            this.byte1 = this.getByteString(1);
            this.byte2 = this.getByteString(2);
            this.byte3 = this.getByteString(3);
            this.byte4 = this.getByteString(4);
            this.byte5 = this.getByteString(5);
            this.byte6 = this.getByteString(6);
            this.byte7 = this.getByteString(7);

            this.int0 = this.getInt16(0);
            this.int1 = this.getInt16(1);
            this.int2 = this.getInt16(2);
            this.int3 = this.getInt16(3);

            this.float0 = this.getFloat(0);
            this.float1 = this.getFloat(1);
        }

        private void replaceRawBytes(Byte[] newBytes, int start, int length)
        {
            for (int i = 0; i < length; i++)
            {
                this.rawBytes[start + i] = newBytes[i];
            }
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
