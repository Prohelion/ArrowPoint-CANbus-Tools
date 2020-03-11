using Prohelion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prohelion.CanLibrary
{
    public static class CanUtilities
    {

        public static String AlignLeft(String value, int stringPadSize, Boolean commaSpaceOnLeft)
        {
            string textString = "";

            if (commaSpaceOnLeft) textString += ", ";

            textString += value;
            int paddingRequired = stringPadSize - textString.Length;
            if (paddingRequired > 0) textString += new string(' ', paddingRequired);

            // If it ends up bigger than the padding then just return the line
            if (textString.Length > stringPadSize) return (textString.TrimEnd());

            return textString.Substring(0, stringPadSize);
        }

        public static String Trim0x(String value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            if (value.Trim().Substring(0, 2).Equals("0x"))
                return value.Trim().Substring(2);
            return value;
        }

        public static byte[] StringToByteArray(string hex)
        {
            if (hex == null) throw new ArgumentNullException(nameof(hex));

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
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));

            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }

        public static string ByteArrayToText(byte[] bytes) {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            return Encoding.Default.GetString(bytes);
        }


        public static uint ByteToUInt8(byte[] bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));

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

        ///<summary>Deserialise an UInt64 stored in big endian format.</summary>
        public static ulong BytesToUInt64(byte[] value, int startIndex)
        {
            Contract.Requires(value != null);

            if (BitConverter.IsLittleEndian)
            {
                // Convert to big endian
                return BitConverter.ToUInt64(value.Reverse().ToArray(), value.Length - sizeof(UInt64) - startIndex);
            }
            else
            {
                return BitConverter.ToUInt64(value, startIndex);
            }
        }


        ///<summary>Deserialise an UInt32 stored in big endian format.</summary>
        public static uint BytesToUInt32(byte[] value, int startIndex)
        {
            Contract.Requires(value != null);

            if (BitConverter.IsLittleEndian)
            {
                // Convert to big endian
                return BitConverter.ToUInt32(value.Reverse().ToArray(), value.Length - sizeof(UInt32) - startIndex);
            }
            else
            {
                return BitConverter.ToUInt32(value, startIndex);
            }
        }


        ///<summary>Serialise an UInt64 to big endian format.</summary>
        public static byte[] GetBytes(UInt64 value)
        {
            if (BitConverter.IsLittleEndian)
            {
                return BitConverter.GetBytes(value).Reverse().ToArray();
            }
            else
            {
                return BitConverter.GetBytes(value);
            }
        }


        ///<summary>Serialise an UInt32 to big endian format.</summary>
        public static byte[] GetBytes(UInt32 value)
        {
            if (BitConverter.IsLittleEndian)
            {
                return BitConverter.GetBytes(value).Reverse().ToArray();
            }
            else
            {
                return BitConverter.GetBytes(value);
            }
        }

    }
}
