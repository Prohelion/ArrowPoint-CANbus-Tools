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
        public int packet { get; set; }
        public string id { get; set; }
        public int idBase10 { get; set; }
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

        public CanPacket() { }

        public CanPacket(String rawBytesStr)
        {
            this.rawBytesStr = rawBytesStr;
            this.rawBytes = MyExtentions.StringToByteArray(rawBytesStr);

            updateDataFields();
        }

        public CanPacket(Byte[] rawBytes)
        {
            this.rawBytes = rawBytes;
            this.rawBytesStr = MyExtentions.ByteArrayToString(rawBytes);

            updateDataFields();
        }

        public byte[] getRawBytes()
        {
            return this.rawBytes;
        }

        public string getRawText()
        {
            return MyExtentions.ByteArrayToString(this.rawBytes);
        }

        private void updateDataFields() {

            this.id = MyExtentions.ByteArrayToString(this.rawBytes.Skip(18).Take(2).ToArray());
            this.idBase10 = BitConverter.ToInt16(this.rawBytes.Skip(18).Take(2).Reverse().ToArray(), 0);

            this.flags = "";
            byte[] flagBytes = this.rawBytes.Skip(20).Take(1).ToArray();

            if ((flagBytes[0] & (1 << 0)) == 1)
            {
                this.extended = true;
                this.flags += "E";
            }
            else {
                this.extended = false;
            }

            if ((flagBytes[0] & (1 << 1)) == 1)
            {
                this.rtr = true;
                this.flags += "R";
            }
            else
            {
                this.rtr = false;
            }

            this.flags += Convert.ToString(flagBytes[0] , 2).PadLeft(8, '0');

            this.byte0 = MyExtentions.ByteArrayToString(this.rawBytes.Skip(22).Take(1).ToArray());
            this.byte1 = MyExtentions.ByteArrayToString(this.rawBytes.Skip(23).Take(1).ToArray());
            this.byte2 = MyExtentions.ByteArrayToString(this.rawBytes.Skip(24).Take(1).ToArray());
            this.byte3 = MyExtentions.ByteArrayToString(this.rawBytes.Skip(25).Take(1).ToArray());
            this.byte4 = MyExtentions.ByteArrayToString(this.rawBytes.Skip(26).Take(1).ToArray());
            this.byte5 = MyExtentions.ByteArrayToString(this.rawBytes.Skip(27).Take(1).ToArray());
            this.byte6 = MyExtentions.ByteArrayToString(this.rawBytes.Skip(28).Take(1).ToArray());
            this.byte7 = MyExtentions.ByteArrayToString(this.rawBytes.Skip(29).Take(1).ToArray());

            this.int0 = BitConverter.ToInt16(this.rawBytes.Skip(22).Take(2).ToArray(), 0);
            this.int1 = BitConverter.ToInt16(this.rawBytes.Skip(24).Take(2).ToArray(), 0);
            this.int2 = BitConverter.ToInt16(this.rawBytes.Skip(26).Take(2).ToArray(), 0);
            this.int3 = BitConverter.ToInt16(this.rawBytes.Skip(28).Take(2).ToArray(), 0);

            this.float0 = BitConverter.ToSingle(this.rawBytes.Skip(22).Take(4).ToArray(), 0);
            this.float1 = BitConverter.ToSingle(this.rawBytes.Skip(26).Take(4).ToArray(), 0);

            this.rawBytesStr = MyExtentions.ByteArrayToString(this.rawBytes);
        }

        public void updateRawBytes()
        {
            replaceRawBytes(MyExtentions.StringToByteArray(id), 18, 2);

            this.rawBytes[20] = (byte)(rawBytes[20] & (Convert.ToInt32(extended) << 0));
            this.rawBytes[20] = (byte)(rawBytes[20] & (Convert.ToInt32(rtr) << 1));

            if (compareRawBytes(BitConverter.GetBytes(float0), 22, 4))
            {
                if (compareRawBytes(BitConverter.GetBytes((Int16)int0), 22, 2))
                {
                    replaceRawBytes(MyExtentions.StringToByteArray(byte0), 22, 1);
                    replaceRawBytes(MyExtentions.StringToByteArray(byte1), 23, 1);
                }
                else {
                    replaceRawBytes(BitConverter.GetBytes((Int16)int0), 22, 2);
                }

                if (compareRawBytes(BitConverter.GetBytes((Int16)int1), 24, 2))
                {
                    replaceRawBytes(MyExtentions.StringToByteArray(byte2), 24, 1);
                    replaceRawBytes(MyExtentions.StringToByteArray(byte3), 25, 1);
                }
                else
                {
                    replaceRawBytes(BitConverter.GetBytes((Int16)int1), 24, 2);
                }
            }
            else {
                replaceRawBytes(BitConverter.GetBytes(float0), 22, 4);
            }

            if (compareRawBytes(BitConverter.GetBytes(float1), 26, 4))
            {
                if (compareRawBytes(BitConverter.GetBytes((Int16)int2), 26, 2))
                {
                    replaceRawBytes(MyExtentions.StringToByteArray(byte4), 26, 1);
                    replaceRawBytes(MyExtentions.StringToByteArray(byte5), 27, 1);
                }
                else
                {
                    replaceRawBytes(BitConverter.GetBytes((Int16)int2), 26, 2);
                }

                if (compareRawBytes(BitConverter.GetBytes((Int16)int3), 28, 2))
                {
                    replaceRawBytes(MyExtentions.StringToByteArray(byte6), 28, 1);
                    replaceRawBytes(MyExtentions.StringToByteArray(byte7), 29, 1);
                }
                else
                {
                    replaceRawBytes(BitConverter.GetBytes((Int16)int3), 28, 2);
                }
            }
            else
            {
                replaceRawBytes(BitConverter.GetBytes(float1), 26, 4);
            }

            this.updateDataFields();
        }

        private void replaceRawBytes(Byte[] newBytes, int start, int length) {
            for (int i = 0; i < length; i++) {
                if (this.rawBytes[start + i] != newBytes[i])
                {
                    this.rawBytes[start + i] = newBytes[i];
                }
            }
        }

        private Boolean compareRawBytes(Byte[] newBytes, int start, int length) {
            Boolean same = true;

            for (int i = 0; i < length; i++)
            {
                if (this.rawBytes[start + i] != newBytes[i])
                {
                    same = same && false;
                }
            }

            return same;
        }

            /*public byte[] StringToByteArray(String hex)
            {
                int NumberChars = hex.Length;
                byte[] bytes = new byte[NumberChars / 2];
                for (int i = 0; i < NumberChars; i += 2)
                    bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                return bytes;
            }

            public string ByteArrayToString(byte[] bytes)
            {
                StringBuilder hex = new StringBuilder(bytes.Length * 2);
                foreach (byte b in bytes)
                    hex.AppendFormat("{0:x2}", b);
                return hex.ToString();
            }*/
        }
}
