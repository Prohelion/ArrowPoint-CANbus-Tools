using ArrowPointCANBusTool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Canbus
{
    public static class MyExtensions
    {

        public static String AlignLeft(String value, int stringPadSize, Boolean commaSpaceOnLeft)
        {
            string textString = "";

            if (commaSpaceOnLeft) textString = textString + ", ";

            textString = textString + value;
            int paddingRequired = stringPadSize - textString.Length;
            if (paddingRequired > 0) textString = textString + new string(' ', paddingRequired);

            // If it ends up bigger than the padding then just return the line
            if (textString.Length > stringPadSize) return (textString.TrimEnd());

            return textString.Substring(0, stringPadSize);
        }

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
     
            return (int)(sbyte)bytes[0];
        }

        public static uint ByteToUInt8(byte[] bytes)
        {

            if (bytes.Length != 1)
            {
                return 0;
            }

            return (uint)bytes[0];
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
