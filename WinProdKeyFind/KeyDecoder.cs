using System;
using System.Collections;
using Microsoft.Win32;
using System.Linq;
using System.IO;

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

            var productKey = isWin8OrUp ? DecodeProductKey(digitalProductId, 52) : DecodeProductKey(digitalProductId, 52);
            return productKey;
        }

        public static string GetOfficeProductKey()
        {
            string result = string.Empty;

            result = GetOfficeProductKey( RegistryView.Registry32);

            if(string.IsNullOrEmpty(result))
                result = GetOfficeProductKey(RegistryView.Registry64);

            return result;
        }

        private static string GetOfficeProductKey(RegistryView registryView)
        {
            const string keyPath = @"Software\Microsoft\Office";

            var key = RegistryKey
                .OpenBaseKey(RegistryHive.LocalMachine, registryView)
                .OpenSubKey(keyPath);

            var result = key.FindSubKeyByName("Registration");

            if (result == null)
                return null;

            var digitalProductId = result.FindValueNameByName("DigitalProductId");

            if (digitalProductId == null)
                return null;

            int keyStartIndex = 52;

            if (OfficeVersion(result.Name) >= 14)
                keyStartIndex = 808;

            var productKey = DecodeProductKey(digitalProductId, keyStartIndex);

            return productKey;
        }

        private static Double OfficeVersion(string path)
        {
            var items = path.Split('\\');

            if (items.Count() < 5)
                return 0;

            Double version = 0;

            if (Double.TryParse(items[4], out version))
            {
                return version;
            }

            return 0;
        }

        public static string DecodeProductKey(byte[] digitalProductId, int keyStartIndex)
        {
            var key = String.Empty;
            var isWin8 = (byte)((digitalProductId[keyStartIndex + 14] / 6) & 1);
            digitalProductId[keyStartIndex + 14] = (byte)((digitalProductId[keyStartIndex + 14] & 0xf7) | (isWin8 & 2) * 4);

            const string digits = "BCDFGHJKMPQRTVWXY2346789";
            int last = 0;
            for (var i = 24; i >= 0; i--)
            {
                var current = 0;
                for (var j = 14; j >= 0; j--)
                {
                    current = current * 256;
                    current = digitalProductId[j + keyStartIndex] + current;
                    digitalProductId[j + keyStartIndex] = (byte)(current / 24);

                    current = current % 24;
                    last = current;
                }
                key = digits[current] + key;
            }

            var keypart1 = key.Substring(1, last);
            var keypart2 = key.Substring(last + 1, key.Length - (last + 1));

            if (isWin8 ==1)
            {
                key = keypart1 + "N" + keypart2;
            }

            for (var i = 5; i < key.Length; i += 6)
            {
                key = key.Insert(i, "-");
            }

            return key;
        }

    }
}