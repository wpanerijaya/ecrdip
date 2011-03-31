using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECRDIP.common
{
    class DataUtil
    {
        #region HexToByte
        /// <summary>
        /// method to convert hex string into a byte array
        /// </summary>
        /// <param name="msg">string to convert</param>
        /// <returns>a byte array</returns>
        public static byte[] HexToByte(string msg)
        {
            //remove any spaces from the string
            msg = msg.Replace(" ", "");
            //create a byte array the length of the
            //divided by 2 (Hex is 2 characters in length)
            byte[] comBuffer = new byte[msg.Length / 2];
            //loop through the length of the provided string
            for (int i = 0; i < msg.Length; i += 2)
                //convert each set of 2 characters to a byte
                //and add to the array
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            //return the array
            return comBuffer;
        }
        #endregion

        #region ByteToHex
        /// <summary>
        /// method to convert a byte array into a hex string
        /// </summary>
        /// <param name="comByte">byte array to convert</param>
        /// <returns>a hex string</returns>
        public static string ByteToHex(byte[] comByte)
        {
            //create a new StringBuilder object
            StringBuilder builder = new StringBuilder(comByte.Length * 3);
            //loop through each byte in the array
            foreach (byte data in comByte)
                //convert the byte to a string and add to the stringbuilder
                builder.Append(Convert.ToString(data, 16).PadLeft(2, '0').PadRight(3, ' '));
            //return the converted value
            return builder.ToString().ToUpper();
        }
        #endregion

        public static string ConvertToHex(string asciiString)
        {
            string hex = "";
            foreach (char c in asciiString)
            {
                int tmp = c;
                hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
            }
            return hex;
        }

        public static string HexAsciiConvert(string hex)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i <= hex.Length - 2; i += 2)
            {
                char c = Convert.ToChar(Int32.Parse(hex.Substring(i, 2),
                System.Globalization.NumberStyles.HexNumber));

                sb.Append(Char.IsControl(c) ? ' ' : c);

            }

            return sb.ToString();
        }

        public static char ReturnLRC(string RequestMessage)
        {
            int lrcAnswer = 0;
            byte[] byt = HexToByte(RequestMessage);
            for (int i = 0; i < byt.Length; i++)
            {
                lrcAnswer = lrcAnswer ^ byt[i];
            }
            return (Char)lrcAnswer;
        }

        public static string ConvertToAmountFormat(int pAmount)
        {
            return String.Format("{0:000000000000}", pAmount);
        }

        public static string ConvertToLengthFormat(int pLength)
        {
            return String.Format("{0:0000}", pLength);
        }
    }
}
