using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
namespace MyUtil
{
    public class MyFuncJingTai
    {
        public static string GetProductGuid(string displayName)
        {
            string productGuid = string.Empty;

            string bit32 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

            RegistryKey localMachine = Registry.LocalMachine;
            RegistryKey unistall = localMachine.OpenSubKey(bit32, true);

            var subNames = unistall.GetSubKeyNames();

            foreach (string subkey in subNames)
            {
                RegistryKey product = unistall.OpenSubKey(subkey);
                try
                {
                    if (product.GetValueNames().Any(n => n == "DisplayName") == true)
                    {
                        string tempDisplayName = product.GetValue("DisplayName").ToString();
                        if (tempDisplayName == displayName && product.GetValueNames().Any(n => n == "UninstallString") == true)
                        {
                            var unitstallStr = product.GetValue("UninstallString").ToString();

                            if (unitstallStr.Contains("MsiExec.exe"))
                            {
                                string[] strs = unitstallStr.Split(new char[2] { '{', '}' });
                                productGuid = strs[1];
                                break;
                            }
                        }
                    }
                }
                catch
                {
                    return string.Empty;
                }
            }

            return productGuid;
        }
    }
}
