using System;
using System.Collections;
using Microsoft.Win32;

namespace WinProdKeyFind
{
    public class KeyDecoder
    {
        public static string GetWindowsProductKey()
        {
                var key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                                              RegistryView.Default);
                const string keyPath = @"Software\Microsoft\Windows NT\CurrentVersion";
                var digitalProductId = (byte[])key.OpenSubKey(keyPath).GetValue("DigitalProductId");

            var isWin8OrUp =
                (Environment.OSVersion.Version.Major == 6 && System.Environment.OSVersion.Version.Minor >= 2)
                ||
                (Environment.OSVersion.Version.Major > 6);

            var productKey = isWin8OrUp ? DecodeProductKeyWin8AndUp(digitalProductId) : DecodeProductKey(digitalProductId);
            return productKey;
        }

        public static string DecodeProductKey(byte[] digitalProductId)
        {
            const int keyStartIndex = 52;
            const int keyEndIndex = keyStartIndex + 15;
            var digits = new[]
            {
                'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'M', 'P', 'Q', 'R',
                'T', 'V', 'W', 'X', 'Y', '2', '3', '4', '6', '7', '8', '9',
            };
            const int decodeLength = 29;
            const int decodeStringLength = 15;
            var decodedChars = new char[decodeLength];
            // Extract byte 52 to 67 inclusive.
            var hexPid = new ArrayList();
            for (var i = keyStartIndex; i <= keyEndIndex; i++)
            {
                hexPid.Add(digitalProductId[i]);
            }
            for (var i = decodeLength - 1; i >= 0; i--)
            {
                // Every sixth char is a separator.
                if ((i + 1) % 6 == 0)
                {
                    decodedChars[i] = '-';
                }
                else
                {
                    // Do the actual decoding.
                    var digitMapIndex = 0;
                    for (var j = decodeStringLength - 1; j >= 0; j--)
                    {
                        var byteValue = (digitMapIndex << 8) | (byte)hexPid[j];
                        hexPid[j] = (byte)(byteValue / 24);
                        digitMapIndex = byteValue % 24;
                        decodedChars[i] = digits[digitMapIndex];
                    }
                }
            }
            return new string(decodedChars);
        }

        public static string DecodeProductKeyWin8AndUp(byte[] digitalProductId)
        {
            var key = String.Empty;
            const int keyOffset = 52;
            var isWin8 = (byte)((digitalProductId[66] / 6) & 1);
            digitalProductId[66] = (byte)((digitalProductId[66] & 0xf7) | (isWin8 & 2) * 4);

            // Possible alpha-numeric characters in product key.
            const string digits = "BCDFGHJKMPQRTVWXY2346789";
            int last = 0;
            for (var i = 24; i >= 0; i--)
            {
                var current = 0;
                for (var j = 14; j >= 0; j--)
                {
                    current = current*256;
                    current = digitalProductId[j + keyOffset] + current;
                    digitalProductId[j + keyOffset] = (byte)(current/24);
                    current = current%24;
                    last = current;
                }
                key = digits[current] + key;
            }
            var keypart1 = key.Substring(1, last);
            const string insert = "N";
            key = key.Substring(1).Replace(keypart1, keypart1 + insert);
            if (last == 0)
                key = insert + key;
            for (var i = 5; i < key.Length; i += 6)
            {
                key = key.Insert(i, "-");
            }
            return key;
        }
        //Got ot from http://www.csharphelp.com/board2/read.html?f=1&i=11982&t=11982
        private static System.DateTime ToDateTime(string dmtfDate)
        {
            //There is a utility called mgmtclassgen that ships with the .NET SDK that
            //will generate managed code for existing WMI classes. It also generates
            // datetime conversion routines like this one.
            //Thanks to Chetan Parmar and dotnet247.com for the help.
            var year = System.DateTime.Now.Year;
            var month = 1;
            var day = 1;
            var hour = 0;
            var minute = 0;
            var second = 0;
            var millisec = 0;
            var dmtf = dmtfDate;

            if (string.IsNullOrEmpty(dmtf))
            {
                return System.DateTime.MinValue;
            }

            if ((dmtf.Length != 25))
            {
                return System.DateTime.MinValue;
            }

            var tempString = dmtf.Substring(0, 4);
            if (("****" != tempString))
            {
                year = System.Int32.Parse(tempString);
            }

            tempString = dmtf.Substring(4, 2);

            if (("**" != tempString))
            {
                month = System.Int32.Parse(tempString);
            }

            tempString = dmtf.Substring(6, 2);

            if (("**" != tempString))
            {
                day = System.Int32.Parse(tempString);
            }

            tempString = dmtf.Substring(8, 2);

            if (("**" != tempString))
            {
                hour = System.Int32.Parse(tempString);
            }

            tempString = dmtf.Substring(10, 2);

            if (("**" != tempString))
            {
                minute = System.Int32.Parse(tempString);
            }

            tempString = dmtf.Substring(12, 2);

            if (("**" != tempString))
            {
                second = System.Int32.Parse(tempString);
            }

            tempString = dmtf.Substring(15, 3);

            if (("***" != tempString))
            {
                millisec = System.Int32.Parse(tempString);
            }

            var dateRet = new System.DateTime(year, month, day, hour, minute, second, millisec);
            return dateRet;
        }
    }
}