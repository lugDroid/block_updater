using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace CopyBlocks
{
    public static class Utils
    {
        public static bool verbose;
        public static TextBox log;

        public static void Log(string text)
        {
            log.AppendText(text);
            log.AppendText(Environment.NewLine);
        }

        public static void LogVerbose(string text)
        {
            if (verbose)
            {
                Log(text);
            }
        }

        [SuppressUnmanagedCodeSecurity]
        internal static class SafeNativeMethods
        {
            [System.Runtime.InteropServices.DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
            public static extern int StrCmpLogicalW(string psz1, string psz2);
        }

        public sealed class NaturalStringComparer : IComparer<string>
        {
            public int Compare(string a, string b)
            {
                return SafeNativeMethods.StrCmpLogicalW(a, b);
            }
        }

        public sealed class NaturalFileInfoNameComparer : IComparer<FileInfo>
        {
            public int Compare(FileInfo a, FileInfo b)
            {
                return SafeNativeMethods.StrCmpLogicalW(a.Name, b.Name);
            }
        }

        public static string CalculateAppHash()
        {
            string appPath = Application.StartupPath + @"\CopyBlocks.exe";

            HashAlgorithm hashAlgorithm = SHA256.Create();
            FileStream stream = File.OpenRead(appPath);

            byte[] hash = hashAlgorithm.ComputeHash(stream);

            return Convert.ToBase64String(hash);
        }

        public static void SetKey()
        {
            Console.WriteLine("Setting key...");

            string keyName = "SOFTWARE\\Siemens\\Automation\\Openness\\15.0\\PublicAPI\\15.0.0.0";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName);
            Console.WriteLine(key.GetValue("PublicKeyToken"));

            string keyName2 = "SOFTWARE\\Siemens\\Automation\\Openness\\15.0\\Copy.exe\\Entry";
            RegistryKey key2 = Registry.LocalMachine.CreateSubKey(keyName2);
            key2.SetValue("FileHash", "asdasdasd");
        }
    }
}
