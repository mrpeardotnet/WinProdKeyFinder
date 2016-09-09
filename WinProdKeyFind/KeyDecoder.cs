using System;
using System.Collections;
using Microsoft.Win32;
using System.Linq;

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

        public static string GetOfficeProductKey(RegistryView registryView = RegistryView.Registry32)
        {
            const string keyPath = @"Software\Microsoft\Office";

            var key = RegistryKey
                .OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                .OpenSubKey(keyPath);

            var result = key.FindSubKeyByName("Registration");

            if (result == null)
                return null;

            var digitalProductId = result.FindValueNameByName("DigitalProductId");

            if (digitalProductId == null)
                return GetOfficeProductKey(RegistryView.Registry64);

            var isOffice2013OrUp = OfficeVersion(result.Name) > 14;

            var productKey = isOffice2013OrUp ? DecodeProductKeyWin8AndUp(digitalProductId) : DecodeProductKey(digitalProductId);

            return productKey;
        }

        private static Double OfficeVersion(string path)
        {
            var items = path.Split('\\');

            if(items.Count() < 5)
                return 0;

            Double version = 0;
            
            if(Double.TryParse(items[4], out version))
            {
                return version;
            }

            return 0;
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

            const string digits = "BCDFGHJKMPQRTVWXY2346789";
            int last = 0;
            for (var i = 24; i >= 0; i--)
            {
                var current = 0;
                for (var j = 14; j >= 0; j--)
                {
                    current = current * 256;
                    current = digitalProductId[j + keyOffset] + current;
                    digitalProductId[j + keyOffset] = (byte)(current / 24);
                    current = current % 24;
                    last = current;
                }
                key = digits[current] + key;
            }

            var keypart1 = key.Substring(1, last);
            var keypart2 = key.Substring(last + 1, key.Length - (last + 1));
            key = keypart1 + "N" + keypart2;

            for (var i = 5; i < key.Length; i += 6)
            {
                key = key.Insert(i, "-");
            }

            return key;
        }
    }
}