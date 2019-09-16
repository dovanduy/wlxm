using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Collections;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace SH_MyUtil
{
    public class MyFuncUtilNoJingTai
    {
        private static readonly object obj = new object();
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
        
       
        

        

        

        public void killProcess(string appname)
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(appname);
            foreach (Process process in processes)
            {
                if (process.ProcessName == appname)
                    process.Kill();
            }
        }

        public void killWindow(int jubing)
        {
            IntPtr p = new IntPtr(jubing);
            PostMessage(p, WM_CLOSE, 0, 0);
        }

        
        public Int64 GetTimestamp()
        {
            //TimeSpan ts = d - new DateTime(1970, 1, 1);
            TimeSpan ts =  DateTime.UtcNow -new DateTime(1970, 1, 1) ;             
            return (Int64)ts.TotalMilliseconds;    //精确到毫秒
        }       

        
        public int suijishu(int min, int max)
        {
            Random rd = new Random();
            return rd.Next(min, max);
        }

        
        
        
    }
}
