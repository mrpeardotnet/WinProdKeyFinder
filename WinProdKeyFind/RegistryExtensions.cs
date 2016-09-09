using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinProdKeyFind
{
    public static class RegistryExtensions
    {
        public static RegistryKey FindSubKeyByName(this RegistryKey key, string name)
        {
            var subKeys = key.GetSubKeyNames();
            var subKey = subKeys.FirstOrDefault(k => k == name);

            if (!string.IsNullOrWhiteSpace(subKey))
                return key.OpenSubKey(subKey);

            foreach (var item in subKeys)
            {
                var step = key.OpenSubKey(item);

                var result = FindSubKeyByName(step, name);

                if (result != null)
                    return result;
            }

            return null;
        }

        public static byte[] FindValueNameByName(this RegistryKey key, string name)
        {
            var value = key.GetValue(name);

            if (value != null)
                return (byte[])value;

            var subKeys = key.GetSubKeyNames();

            foreach (var item in subKeys)
            {
                var step = key.OpenSubKey(item);

                var result = FindValueNameByName(step, name);

                if (result != null)
                    return result;
            }

            return null;
        }

    }
}
