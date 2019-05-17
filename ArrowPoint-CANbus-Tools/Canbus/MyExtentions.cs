using ArrowPointCANBusTool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.CanBus
{
    public static class MyExtentions
    {

        public static byte[] StringToByteArray(string hex)
        {
            int NumberChars = hex.Length;

            if (NumberChars % 2 == 1)
            {
                hex = String.Concat("0", hex);
                NumberChars++;
            }

            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }

            return bytes;
        }

        public static string ByteArrayToString(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }

        public static string ByteArrayToText(byte[] bytes) {
            return Encoding.Default.GetString(bytes);
        }

        public static int ByteToInt8(byte[] bytes)
        {

            if (bytes.Length != 1)
            {
                return -1;
            }

            byte[] newBytes = new byte[bytes.Length + 1];
            bytes.CopyTo(newBytes, 0);
            newBytes[1] = Byte.Parse("00");
            bytes = newBytes;

            return BitConverter.ToInt16(bytes, 0);
        }

        public static uint ByteToUInt8(byte[] bytes)
        {

            if (bytes.Length != 1)
            {
                return 0;
            }

            byte[] newBytes = new byte[bytes.Length + 1];
            bytes.CopyTo(newBytes, 0);
            newBytes[1] = Byte.Parse("00");
            bytes = newBytes;

            return BitConverter.ToUInt16(bytes, 0);
        }

        public static byte Int8ToByte(int intVal)
        {
            byte[] bytes = BitConverter.GetBytes((Int16)intVal).Reverse().ToArray();

            return bytes[1];
        }

        public static byte UInt8ToByte(uint uintVal)
        {
            byte[] bytes = BitConverter.GetBytes((UInt16)uintVal).Reverse().ToArray();

            return bytes[1];
        }

    }
}
