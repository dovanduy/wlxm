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
    public class MyFuncUtil
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
        private static ReaderWriterLockSlim LogWriteLock = new ReaderWriterLockSlim();
        /// <summary>
        /// 得到内存地址
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string getMemory(object o) // 获取引用类型的内存地址方法  
        {
            GCHandle h = GCHandle.Alloc(o, GCHandleType.WeakTrackResurrection);

            IntPtr addr = GCHandle.ToIntPtr(h);

            return "0x" + addr.ToString("X");
        }


        /// <summary>
        /// 得到当前内网ip
        /// </summary>
        /// <returns></returns>
        public static IPAddress GetInternalIP()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in nics)
            {
                foreach (var uni in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (uni.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return uni.Address;
                    }
                }
            }
            return null;
        }

        public static string getRemoteIP()
        {
            try
            {
                WebClient client = new WebClient();
                byte[] bytRecv = client.DownloadData("http://www.123cha.com/"); //下载网页数据
                string str = System.Text.Encoding.GetEncoding("gb2312").GetString(bytRecv);
                string r = @"(((\d{1,3})|(1\d{2})|(2[0-4]\d)|(25[0-5]))\.){3}((\d{1,3})|(1\d{2})|(2[0-4]\d)|(25[0-5]))";
                string ip = System.Text.RegularExpressions.Regex.Match(str, r).ToString(); //提取信息   
                return IPAddress.Parse(ip).ToString();
            }
            catch (Exception ex) {
                WriteLog.WriteLogFile( ex.Message);
            }
            return "";
        }
        /// <summary>
        /// 得到电脑主机名字
        /// </summary>
        /// <returns></returns>
        public static string getMachineName()
        {
            return Environment.MachineName;
        }
        public static void createDirIfNotExist(string a="d") {
            
            if (!Directory.Exists(@"c:\mypic_save\"))//如果不存在就创建file文件夹　　             　　              
            {
                Directory.CreateDirectory(@"c:\mypic_save\");
            }
           
            
            if (!Directory.Exists(@"d:\mypic_save\"))//如果不存在就创建file文件夹　　             　　              
            {
                Directory.CreateDirectory(@"d:\mypic_save\");
            }
           
            
            if (!Directory.Exists(@"d:\lunengpic\"))//如果不存在就创建file文件夹　　             　　              
            {
                Directory.CreateDirectory(@"d:\lunengpic\");
            }
            
            if (a.ToLower().Equals("d"))
            {
                if (!Directory.Exists(@"c:\mypic_save\"))//如果不存在就创建file文件夹　　             　　              
                {
                    Directory.CreateDirectory(@"c:\mypic_save\");
                }
            }
        }

        

        

        public static void mylogandxianshi(String a)
        {
            WriteLog.WriteLogFile(a);
            //myxinxitishi(a);
        }

        public static void myqiehuancd(string a_b, out string dizhi, out string path, out string seed) {
            dizhi = null;
            if (a_b.ToLower().Equals("c"))
            {
                dizhi = @"d:\ChangZhi\dnplayer2\";
            }
            if (a_b.ToLower().Equals("d"))
            {
                dizhi = @"D:\ChangZhi\dnplayer2\";
            }
            path = null;
            if (a_b.ToLower().Equals("c"))
            {
                path = @"d:\mypic_save\";
            }
            if (a_b.ToLower().Equals("d"))
            {
                path = @"d:\mypic_save\";
            }
            seed = null;
            if (a_b.ToLower().Equals("c"))
            {
                seed = @"d:\ChangZhi\seed1";
            }
            if (a_b.ToLower().Equals("d"))
            {
                seed = @"d:\ChangZhi\seed1";
            }
        }

        public static void killProcess(string appname)
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(appname);
            foreach (Process process in processes)
            {
                if (process.ProcessName == appname)
                    process.Kill();
            }
        }

        public static void killWindow(int jubing)
        {
            IntPtr p = new IntPtr(jubing);
            PostMessage(p, WM_CLOSE, 0, 0);
        }

        
        public static Int64 GetTimestamp()
        {
            //TimeSpan ts = d - new DateTime(1970, 1, 1);
            TimeSpan ts =  DateTime.UtcNow -new DateTime(1970, 1, 1) ;             
            return (Int64)ts.TotalMilliseconds;    //精确到毫秒
        }

        #region 秒转换小时 SecondToHour
        /// <summary>
        /// 秒转换小时
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string SecondToHour(Int64 time)
        {
            int hour = 0;
            int minute = 0;
            int second = 0;
            second = Convert.ToInt32(time/1000); 

            if (second > 60)
            {
                minute = second / 60;
                second = second % 60;
            }
            if (minute > 60)
            {
                hour = minute / 60;
                minute = minute % 60;
            }
            return (hour + "小时" + minute + "分钟"
                + second + "秒");
        }
        #endregion

        
        public static int suijishu(int min, int max)
        {
            Random rd = new Random();
            return rd.Next(min, max);
        }

        /// <summary>
        /// 解压RAR和ZIP文件(需存在Winrar.exe(只要自己电脑上可以解压或压缩文件就存在Winrar.exe))
        /// </summary>
        /// <param name="UnPath">解压后文件保存目录</param>
        /// <param name="rarPathName">待解压文件存放绝对路径（包括文件名称）</param>
        /// <param name="IsCover">所解压的文件是否会覆盖已存在的文件(如果不覆盖,所解压出的文件和已存在的相同名称文件不会共同存在,只保留原已存在文件)</param>
        /// <param name="PassWord">解压密码(如果不需要密码则为空)</param>
        /// <returns>true(解压成功);false(解压失败)</returns>
        public static bool UnRarOrZip(string UnPath, string rarPathName, bool IsCover, string PassWord)
        {
            if (!Directory.Exists(UnPath))
                Directory.CreateDirectory(UnPath);
            Process Process1 = new Process();
            Process1.StartInfo.FileName = "Winrar.exe";
            Process1.StartInfo.CreateNoWindow = true;
            string cmd = "";
            if (!string.IsNullOrEmpty(PassWord) && IsCover)
                //解压加密文件且覆盖已存在文件( -p密码 )
                cmd = string.Format(" x -p{0} -o+ {1} {2} -y", PassWord, rarPathName, UnPath);
            else if (!string.IsNullOrEmpty(PassWord) && !IsCover)
                //解压加密文件且不覆盖已存在文件( -p密码 )
                cmd = string.Format(" x -p{0} -o- {1} {2} -y", PassWord, rarPathName, UnPath);
            else if (IsCover)
                //覆盖命令( x -o+ 代表覆盖已存在的文件)
                cmd = string.Format(" x -o+ {0} {1} -y", rarPathName, UnPath);
            else
                //不覆盖命令( x -o- 代表不覆盖已存在的文件)
                cmd = string.Format(" x -o- {0} {1} -y", rarPathName, UnPath);
            //命令
            Process1.StartInfo.Arguments = cmd;
            Process1.Start();
            Process1.WaitForExit();//无限期等待进程 winrar.exe 退出
            //Process1.ExitCode==0指正常执行，Process1.ExitCode==1则指不正常执行
            if (Process1.ExitCode == 0)
            {
                Process1.Close();
                return true;
            }
            else
            {
                Process1.Close();
                return false;
            }

        }

        /// <summary>
        /// 压缩文件成RAR或ZIP文件(需存在Winrar.exe(只要自己电脑上可以解压或压缩文件就存在Winrar.exe))
        /// </summary>
        /// <param name="filesPath">将要压缩的文件夹或文件的绝对路径</param>
        /// <param name="rarPathName">压缩后的压缩文件保存绝对路径（包括文件名称）</param>
        /// <param name="IsCover">所压缩文件是否会覆盖已有的压缩文件(如果不覆盖,所压缩文件和已存在的相同名称的压缩文件不会共同存在,只保留原已存在压缩文件)</param>
        /// <param name="PassWord">压缩密码(如果不需要密码则为空)</param>
        /// <returns>true(压缩成功);false(压缩失败)</returns>
        public static bool CondenseRarOrZip(string filesPath, string rarPathName, bool IsCover, string PassWord)
        {
            string rarPath = Path.GetDirectoryName(rarPathName);
            if (!Directory.Exists(rarPath))
                Directory.CreateDirectory(rarPath);
            Process Process1 = new Process();
            Process1.StartInfo.FileName = "Winrar.exe";
            Process1.StartInfo.CreateNoWindow = true;
            string cmd = "";
            if (!string.IsNullOrEmpty(PassWord) && IsCover)
                //压缩加密文件且覆盖已存在压缩文件( -p密码 -o+覆盖 )
                cmd = string.Format(" a -ep1 -p{0} -o+ {1} {2} -r", PassWord, rarPathName, filesPath);
            else if (!string.IsNullOrEmpty(PassWord) && !IsCover)
                //压缩加密文件且不覆盖已存在压缩文件( -p密码 -o-不覆盖 )
                cmd = string.Format(" a -ep1 -p{0} -o- {1} {2} -r", PassWord, rarPathName, filesPath);
            else if (string.IsNullOrEmpty(PassWord) && IsCover)
                //压缩且覆盖已存在压缩文件( -o+覆盖 )
                cmd = string.Format(" a -ep1 -o+ {0} {1} -r", rarPathName, filesPath);
            else
                //压缩且不覆盖已存在压缩文件( -o-不覆盖 )
                cmd = string.Format(" a -ep1 -o- {0} {1} -r", rarPathName, filesPath);
            //命令
            Process1.StartInfo.Arguments = cmd;
            Process1.Start();
            Process1.WaitForExit();//无限期等待进程 winrar.exe 退出
            //Process1.ExitCode==0指正常执行，Process1.ExitCode==1则指不正常执行
            if (Process1.ExitCode == 0)
            {
                Process1.Close();
                return true;
            }
            else
            {
                Process1.Close();
                return false;
            }
        }
        
        
    }
}
