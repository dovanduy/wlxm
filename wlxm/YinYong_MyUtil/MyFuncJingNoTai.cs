using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
namespace MyUtil
{
    public class MyFuncJingNoTai
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int PostMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_CLOSE = 0x10;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndlnsertAfter, int X, int Y, int cx, int cy, uint Flags);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, out  Rect lpRect);
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        public const int SWP_NOMOVE = 2;
        public const int HWND_TOP = 0;
        public const int SWP_SHOWWINDOW = 40;
        public const int SWP_NOSIZE = 1;



        public bool lurenResizeOk(int index)
        {

            WriteLog.WriteLogFile(index + "", "改变窗口位置--开始");
            string dizhi = @"d:\ChangZhi\dnplayer2\";
            bool t = false;
            long ksjs = MyFuncUtil.GetTimestamp();
            long ks = MyFuncUtil.GetTimestamp();
            int width = -1, height = -1;
            myReSize(index, out width, out height);
            int jubing = MyLdcmd.getDqmoniqiWaiCengJuBingByIndex(index, dizhi);
            int jubing2 = MyLdcmd.getDqmoniqiJuBingByIndex(index, dizhi);
            if (jubing <= 0)
            {
                WriteLog.WriteLogFile(index + "", "改变窗口位置，句柄绑定错误");
                return t;
            }
            Rect lprect = new Rect();
            GetWindowRect(new IntPtr(jubing), out lprect);
            Rect rprect = new Rect();
            GetWindowRect(new IntPtr(jubing2), out rprect);
            WriteLog.WriteLogFile(index + "", "当前width,height" + width + "," + height + " 改变位置外框" + (lprect.Right - lprect.Left) + " " + (lprect.Bottom - lprect.Top) + "，内框" + (rprect.Right - rprect.Left) + " " + (rprect.Bottom - rprect.Top));
            if ((lprect.Right - lprect.Left) == width && (lprect.Bottom - lprect.Top) == height)
            {
                WriteLog.WriteLogFile(index + "", "改变位置外框成功" + (lprect.Right - lprect.Left) + " " + (lprect.Bottom - lprect.Top) + "，内框" + (rprect.Right - rprect.Left) + " " + (rprect.Bottom - rprect.Top));
                t = true;
                return t;
            }
            while (true)
            {
                long js = MyFuncUtil.GetTimestamp();
                if ((js - ksjs) > 30 * 1000)
                {
                    lprect = new Rect();
                    GetWindowRect(new IntPtr(jubing), out lprect);
                    rprect = new Rect();
                    GetWindowRect(new IntPtr(jubing2), out rprect);
                    WriteLog.WriteLogFile(index + "", "当前width,height" + width + "," + height + " 改变位置外框" + (lprect.Right - lprect.Left) + " " + (lprect.Bottom - lprect.Top) + "，内框" + (rprect.Right - rprect.Left) + " " + (rprect.Bottom - rprect.Top));
                    if ((lprect.Right - lprect.Left) == width && (lprect.Bottom - lprect.Top) == height)
                    {
                        WriteLog.WriteLogFile(index + "", "改变位置外框" + (lprect.Right - lprect.Left) + " " + (lprect.Bottom - lprect.Top) + "，内框" + (rprect.Right - rprect.Left) + " " + (rprect.Bottom - rprect.Top));
                        t = true;
                        break;
                    }
                    if ((lprect.Right - lprect.Left) != width || (lprect.Bottom - lprect.Top) != height)
                    {
                        myReSize(index, out width, out height);
                    }
                    ksjs = MyFuncUtil.GetTimestamp();
                    WriteLog.WriteLogFile(index + "", "30s resize一次");
                }
                if ((js - ks) > 10 * 60 * 1000)
                {
                    WriteLog.WriteLogFile(index + "", "10分钟改变位置不成功 ");
                    break;
                }
            }
            return t;
        }
        public void myReSize(int index, out int width, out int height, string dizhi = @"d:\ChangZhi\dnplayer2\", string youxi = "luneng")
        {
            WriteLog.WriteLogFile(index + "", "模拟器" + index + "开始改位置");
            int dqwidth = 2560;//1920 1024
            int dqheight = 1440;//1080 768
            int yiquanw = 601;
            int yiquany = 338;
            if (youxi.Equals("luneng"))
            {
                yiquanw = 727; //原来外框 727 425
                yiquany = 425;
            }
            width = yiquanw;
            height = yiquany;
            int jubing = MyLdcmd.getDqmoniqiWaiCengJuBingByIndex(index, dizhi);
            IntPtr p = new IntPtr(jubing);
            IntPtr p2 = new IntPtr(HWND_TOP);
            int x = 0;
            int y = 0;
            x = (index % 4) * (dqwidth / 4);
            y = (index / 4) * (dqheight / 4);
            WriteLog.WriteLogFile(index + "", index + "x:" + x + ",y:" + y);
            if (youxi.Equals("luneng"))
            {
                SetWindowPos(p, p2, x, y, yiquanw, yiquany, SWP_SHOWWINDOW);
            }
            else
            {
                SetWindowPos(p, p2, x, y, yiquanw, yiquany, SWP_SHOWWINDOW);
            }
        }
        
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
