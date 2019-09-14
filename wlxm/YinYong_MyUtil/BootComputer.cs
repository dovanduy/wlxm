using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace MyUtil
{
    public class BootComputer
    {
        public string strIp, strAdmin, strPassword, strMothod;
        public string[] inParams;
        public void BootMachine()
        {
            ConnectionOptions BootConn = new ConnectionOptions();
            BootConn.Username = strAdmin;
            BootConn.Password = strPassword;
            ManagementScope ms = new ManagementScope("\\\\" + strIp + "\\root\\cimv2", BootConn);
            ms.Options.EnablePrivileges = true;
            WriteLog.WriteLogFile("", strIp + ":00");
            if (!string.IsNullOrEmpty(strAdmin) && !string.IsNullOrEmpty(strPassword))
            {
                try { ms.Connect(); }
                catch { }
            }
            
            if (ms.IsConnected)
            {
                try
                {
                    WriteLog.WriteLogFile("", strIp + ":11");
                    ObjectQuery oq = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                    ManagementObjectSearcher mos = new ManagementObjectSearcher(ms, oq);
                    ManagementObjectCollection moc = mos.Get();
                    foreach (ManagementObject mo in moc)
                    {
                        string[] ss = inParams;
                        mo.InvokeMethod(strMothod, ss);
                    }
                }
                catch (Exception ex)
                {
                    WriteLog.WriteLogFile("",strIp + ":" + ex.Message + "网络不通或用户名、密码不正确！");
                }
            }
            WriteLog.WriteLogFile("", ms.IsConnected + ":30");
        }
    }
}
