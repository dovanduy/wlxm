using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using wlxm;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Diagnostics;
using System.Collections;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using xDM;
namespace MyUtil
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
                WriteLog.WriteLogFile("", ex.Message);
            }
            return "";
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

        public static void myxinxitishi(String a)
        {
            //Form2 frmShowWarning = Form2.getInstance();//Form1为要弹出的窗体（提示框），
            
            //frmShowWarning.CalcFinished(a);
            //Thread.Sleep(2000);
            //frmShowWarning.Show();
            //for (int i = 0; i <= frmShowWarning.Height; i++)
            {
               // frmShowWarning.Location = new Point(p.X, p.Y - i);
                //Thread.Sleep(10);//将线程沉睡时间调的越小升起的越快
            }
            myDm dm = new myDm();
            int width = dm.GetScreenWidth();
            int height = dm.GetScreenHeight();
            int foobar = dm.CreateFoobarRect(0, width - 210, height - 210, 200, 200);
            if (a.Length > 200) {
                a=a.Substring(0,200);
            }
            var dm_ret = dm.FoobarPrintText(foobar,a , "ff0000");
            dm.FoobarUpdate(foobar);
            dm.mydelay(1000, 3000);
            dm_ret = dm.FoobarClose(foobar);
        }

        

        public static void mylogandxianshi(String a)
        {
            WriteLog.WriteLogFile("",a);
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

        public static void myReSize1(int index, out int width,out int height,string dizhi = @"d:\ChangZhi\dnplayer2\", string youxi = "luneng")
        {
            mylogandxianshi("模拟器" + index + "开始改位置");
            int dqwidth = 2560;//1920 1024
            int dqheight = 1440;//1080 768
            int yiquanw = 601;
            int yiquany = 338;
            if (youxi.Equals("luneng")) {
                yiquanw = 727; //原来外框 727 425
                yiquany = 425;
            }
            width = yiquanw;
            height = yiquany;
            lock (obj)
            {
                int jubing = MyLdcmd.getDqmoniqiWaiCengJuBingByIndex(index, dizhi);
                IntPtr p = new IntPtr(jubing);
                IntPtr p2 = new IntPtr(HWND_TOP);
                int x = 0;
                int y = 0;
                x = (index % 4) * (dqwidth / 4);
                y = (index / 4) * (dqheight / 4);
                mylogandxianshi(index+"x:"+x+",y:"+y);
                if (youxi.Equals("luneng"))
                {
                    SetWindowPos(p, p2, x, y, yiquanw, yiquany, SWP_SHOWWINDOW);
                }
                else
                {
                    SetWindowPos(p, p2, x, y, yiquanw, yiquany, SWP_SHOWWINDOW);
                }
            }
        }

        public static void myReSizeNeiKuang(int index, out int width, out int height, string dizhi = @"d:\ChangZhi\dnplayer2\", string youxi = "luneng")
        {
            mylogandxianshi("模拟器内框" + index + "开始改位置");
            int dqwidth = 1920;//1920 1024
            int dqheight = 1080;//1080 768
            int yiquanw = 601;
            int yiquany = 338;
            if (youxi.Equals("luneng"))
            {
                yiquanw = 688; //原来外框 727 425
                yiquany = 387;
            }            
            width = yiquanw;
            height = yiquany;
            lock (obj)
            {
                int jubing = MyLdcmd.getDqmoniqiJuBingByIndex(index, dizhi);
                IntPtr p = new IntPtr(jubing);
                IntPtr p2 = new IntPtr(HWND_TOP);
                int x = 0;
                int y = 0;
                x = (index % 4) * (dqwidth / 4);
                y = (index / 4) * (dqheight / 4);
                mylogandxianshi(index + "x:" + x + ",y:" + y);
                if (youxi.Equals("luneng"))
                {
                    SetWindowPos(p, p2, x+20, y+19, yiquanw, yiquany, SWP_SHOWWINDOW);
                }
                else
                {
                    SetWindowPos(p, p2, x, y, yiquanw, yiquany, SWP_SHOWWINDOW);
                }
            }
        }

       

        public static void myReplace(int index)
        {
            string dizhi = @"d:\ChangZhi\dnplayer2\";
            mylogandxianshi("模拟器" + index + "开始改位置");
            int dqwidth = 2560;//2560 1920 1024
            int dqheight = 1440;//1440 1080 768            
            lock (obj)
            {
                int jubing = MyLdcmd.getDqmoniqiWaiCengJuBingByIndex(index, dizhi);
                IntPtr p = new IntPtr(jubing);
                IntPtr p2 = new IntPtr(HWND_TOP);
                int x = 0;
                int y = 0;
                x = (index % 4) * (dqwidth / 4);
                y = (index / 4) * (dqheight / 4);
                SetWindowPos(p, p2, x, y, -1, -1, SWP_NOSIZE);
            }
        }

        public static bool lurenResizeOk1(int index)
        {
            WriteLog.WriteLogFile(index + "", "改变窗口位置--开始");
            string dizhi = @"d:\ChangZhi\dnplayer2\";
            bool t = false;
            long ksjs = GetTimestamp();
            long ks = GetTimestamp();
            int width = -1, height = -1;
            myReSize1(index, out width, out height);
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
                long js = GetTimestamp();
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
                        myReSize1(index, out width, out height);
                    }
                    ksjs = GetTimestamp();
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

        public static void getWindowSize(int index,out int width,out int height)
        {
            string dizhi = @"d:\ChangZhi\dnplayer2\";
            width = -1;
            height = -1;
            int jubing = MyLdcmd.getDqmoniqiWaiCengJuBingByIndex(index, dizhi);
            if (jubing <= 0)
            {
                WriteLog.WriteLogFile(index + "", "改变窗口位置，句柄绑定错误");
                return;
            }
            Rect lprect = new Rect();
            GetWindowRect(new IntPtr(jubing), out lprect);            
            WriteLog.WriteLogFile(index + "", "当前width,height" + width + "," + height + " 改变位置外框" + (lprect.Right - lprect.Left) + " " + (lprect.Bottom - lprect.Top) );
            width = lprect.Right - lprect.Left;
            height = lprect.Bottom - lprect.Top;
        }

        public static bool lureninstallOk(int dqinx)
        {
            WriteLog.WriteLogFile(dqinx + "", "检测安装是否成功");
            bool t = false;
            //隔30秒检测是否安装成功
            long ksjs = MyFuncUtil.GetTimestamp();
            long ks = MyFuncUtil.GetTimestamp();
            bool luren = false;
            while (true)
            {
                long js = MyFuncUtil.GetTimestamp();
                if ((js - ks) > 30 * 1000)
                {
                    WriteLog.WriteLogFile(dqinx + "", "30s检测安装一次");
                    luren = MyLdcmd.jingjieisok(dqinx, "package:com.wk.jingjie.ewan");
                    ks = MyFuncUtil.GetTimestamp();
                }
                if ((js - ksjs) > 10 * 60 * 1000)
                {
                    WriteLog.WriteLogFile(dqinx + "", "10分钟了,安装app没成功");
                    break;
                }
                if (luren)
                {
                    WriteLog.WriteLogFile(dqinx + "", "安装app成功");
                    t = true;
                    break;
                }
            }
            return t;
        }

        public static bool myQuit(int index, string dizhi)
        {
            var res = false;
            lock (obj)
            {
                int jubing = MyLdcmd.getDqmoniqiWaiCengJuBingByIndex(index, dizhi);
                IntPtr p = new IntPtr(jubing);
                PostMessage(p, WM_CLOSE, 0, 0);
                Thread.Sleep(5000);
                MyLdcmd myldcmd = MyLdcmd.GetObject(dizhi);
                long kstime = GetTimestamp();
                long kstime2 = GetTimestamp();
                int[] abc = MyLdcmd.getDqmoniqiHuodongIndex(dizhi);
                if (abc.Contains(index))
                {
                    MyLdcmd.getLdCmd().Quit(index);
                    Thread.Sleep(5000);                    
                    zaiciguanbi();
                }
                abc = MyLdcmd.getDqmoniqiHuodongIndex(dizhi);
                if (!abc.Contains(index))
                {
                    return true;
                }
                int shi = 0;
                while (true)
                {
                    long jstime = GetTimestamp();
                    if ((jstime - kstime2) > 1000 * 30)
                    {
                        abc = MyLdcmd.getDqmoniqiHuodongIndex(dizhi);
                        kstime2 = GetTimestamp();
                    }
                    if (shi == 0 && abc.Contains(index))
                    {
                        MyLdcmd.getLdCmd().Quit(index);
                        Thread.Sleep(5000);
                        zaiciguanbi();
                        shi = 1;
                    }
                    if (shi == 1 && abc.Contains(index))
                    {
                        PostMessage(p, WM_CLOSE, 0, 0);
                        Thread.Sleep(5000);
                        shi = 0;
                    }
                    if (!abc.Contains(index))
                    {
                        res = true;
                        break;
                    }
                    if ((jstime - kstime) > 1000 * 60 * 5)
                    {
                        mylogandxianshi("循环很久5分钟也没有关闭" + index);
                        break;
                    }
                }
            }
            return res;
        }

        public static void zaiciguanbi()
        {
            myDm dm = new myDm();
            lock (dm)
            {
                int jb2 = dm.FindWindowEx(0, "LDPlayerMsgFrame", "");
                if (jb2 > 0)
                {
                    dm.bindWindow(jb2);
                    WriteLog.WriteLogFile("", "发现一个是否关闭,点是");
                    if (dm.mohu(366, 181, 0x009de4) == 1) {
                        dm.mytap(jb2, 346, 181);
                        dm.mydelay(1000, 2000);
                    }
                }
            }
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

        public static void BackupAndlunch(int index, string backname, string a_b)
        {
            WriteLog.WriteLogFile(index + "", "准备关闭并备份");
            Thread.Sleep(10000);
            string dizhi = null;
            string path = null;
            string seed = null;
            myqiehuancd(a_b, out dizhi, out path, out seed);
            myQuit(index, dizhi);
            Thread.Sleep(2000);
            zaiciguanbi();
            if (backname.Length > 0)
            {
                WriteLog.WriteLogFile(index + "", "值得备份的" + backname);
                Thread.Sleep(20000);
                MyLdcmd.myBackup(index, @"c:\mypic_save\" + backname, dizhi);
            }
            Thread.Sleep(30000);
            try
            {
                LogWriteLock.EnterReadLock();
                MyLdcmd.myRestore(index, seed, dizhi);
            }
            catch { }
            finally
            {
                LogWriteLock.ExitReadLock();
            }
            Thread.Sleep(40000);
            MyLdcmd.myRename(index, "雷电模拟器-" + index, dizhi);
            Thread.Sleep(5000);
        }

        public static void MyRestore(int index, string backname, string a_b)
        {
            WriteLog.WriteLogFile(index + "", "准备关闭并备份");
            Thread.Sleep(10000);
            string dizhi = null;
            string path = null;
            string seed = null;
            myqiehuancd(a_b, out dizhi, out path, out seed);
            if (backname.Length > 0)
            {
                myQuit(index, dizhi);
                Thread.Sleep(2000);
                zaiciguanbi();
                WriteLog.WriteLogFile(index + "", "值得备份的" + backname);
                Thread.Sleep(20000);
                MyLdcmd.myBackup(index, @"c:\mypic_save\" + backname, dizhi);
                Thread.Sleep(30000);
            }
            else {
                myQuit(index, dizhi);
                Thread.Sleep(2000);
                zaiciguanbi();
            }            
        }

        public static bool Launch(int index, string dizhi = @"d:\ChangZhi\dnplayer2\")
        {
            var res = false;
            lock (obj)
            {
                WriteLog.WriteLogFile(index + "", "准备打开" + index + "号模拟器");
                Int64 kstime = GetTimestamp();
                long ksjs = GetTimestamp();
                int i = 0;
                int[] abc = MyLdcmd.getDqmoniqiHuodongIndex(dizhi);
                while (true)
                {
                    if (i == 0)
                    {
                        WriteLog.WriteLogFile(index + "", "打开" + index + "号模拟器");
                        dakaimoniqiByIndex(index);
                        i++;
                    }
                    Int64 jstime = GetTimestamp();
                    if ((jstime - kstime) > 1000 * 60 * 5)
                    {
                        mylogandxianshi("打开很久5分钟也没打开" + index);
                        break;
                    }
                    if ((jstime - ksjs) > 1000 * 20)
                    {
                        abc = MyLdcmd.getDqmoniqiHuodongIndex(dizhi);                        
                        ksjs = GetTimestamp();
                    }
                    if (abc.Contains(index))
                    {
                        res = true;
                        break;
                    }
                }
            }
            return res;
        }

        public static bool LaunchQiHao(int index, string dizhi = @"d:\ChangZhi\dnplayer2\")
        {
            var res = false;
            lock (obj)
            {
                WriteLog.WriteLogFile(index + "", "起号开始,准备打开" + index + "号模拟器");
                Int64 kstime = GetTimestamp();
                long ksjs = GetTimestamp();
                int i = 0;
                int[] abc = MyLdcmd.getDqmoniqiHuodongIndex(dizhi);
                while (true)
                {
                    if (i == 0)
                    {
                        WriteLog.WriteLogFile(index + "", "打开" + index + "号模拟器");
                        dakaimoniqiByIndexQiHao(index);
                        i++;
                    }
                    Int64 jstime = GetTimestamp();
                    if ((jstime - kstime) > 1000 * 60 * 5)
                    {
                        mylogandxianshi("打开很久5分钟也没打开" + index);
                        break;
                    }
                    if ((jstime - ksjs) > 1000 * 20)
                    {
                        abc = MyLdcmd.getDqmoniqiHuodongIndex(dizhi);
                        ksjs = GetTimestamp();
                    }
                    if (abc.Contains(index))
                    {
                        res = true;
                        break;
                    }
                }
            }
            return res;
        }

        public static void Qidong(int dqinx,string app)
        {
            WriteLog.WriteLogFile("" + dqinx, dqinx + "----" + app + "，thread:" + Thread.CurrentThread.ManagedThreadId);
            MyLdcmd.getLdCmd().StartApp(dqinx, app);
        }



        public static bool PanDuan_Qidong(string a_b,int dqinx)
        {
            //大框 原始 376 668 横过来后 960 540 
            //小框 原始 217 387 横过来后216 122
            //1920 分辨率  2560 1440
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd(a_b, out dizhi, out path, out seed);
            myDm dm = new myDm();            
            int x1 = -1;
            int y1 = -1;
            int jubing = MyLdcmd.getDqmoniqiJuBingByIndex(dqinx, dizhi);
            if (jubing <= 0) {
                WriteLog.WriteLogFile(dqinx + "", "游戏判断启动，句柄绑定错误");
                return false;
            }
            dm.myGetClientRect(jubing, out x1, out y1);
            if (y1 != 540 && y1!=122 && y1!=668 && y1!=432)
            {
                WriteLog.WriteLogFile(dqinx+"", "游戏启动不成功，界面有微信图标 "+ x1+" "+y1);
                return false;
            }
            return true;
        }

        public static bool PanDuan_QidongLurenzhanghao(string a_b, int dqinx)
        {
            
            myDm dm = new myDm();
            int x1 = -1;
            int y1 = -1;
            int jubing = MyLdcmd.getDqmoniqiJuBingByIndex(dqinx);
            if (jubing <= 0)
            {
                WriteLog.WriteLogFile(dqinx + "", "游戏判断启动，句柄绑定错误");
                return false;
            }
            dm.bindWindow(jubing);
            Entity.FuHeSanDian tysd =null;
            int w=-1,h=-1;
            getWindowSize(dqinx,out w,out h);
            WriteLog.WriteLogFile(dqinx + "", w + " " + h);
            int a = 0;
            if (w == 489 && h == 840)
            {
                a = 1;
                tysd = fuzhu.TongYong_SanDian.GetObject().findFuHeSandianByName("雷电首页截图-路人");
            }
            if (w == 1318 && h == 758)
            {
                a = 1;
                tysd = fuzhu.TongYong_SanDian.GetObject().findFuHeSandianByName("雷电首页截图-平板");
            }
            if (a==1 && dm.mohuByLeiBool_duokai(tysd.Sd))
            {
                WriteLog.WriteLogFile(dqinx + "", "游戏启动不成功，界面有雷电游戏 " + x1 + " " + y1);
                return false;
            }
            return true;
        }

        public static int QiDongWanChengLurenzhanghao(string a_b, int dqinx, string app)
        {
            WriteLog.WriteLogFile(dqinx + "", "尝试打开app" + dqinx);
            bool qidongcg = true;
            long ks = GetTimestamp();
            int i = 1;
            while (true)
            {
                if (i == 1)
                {
                    Qidong(dqinx, app);
                    i++;
                }
                if (PanDuan_QidongLurenzhanghao(a_b, dqinx))
                {
                    break;
                }
                long js = MyFuncUtil.GetTimestamp();
                Thread.Sleep(20000);
                if ((js - ks) > 1000 * 60)
                {
                    i = 1;
                }
                if ((js - ks) > 1000 * 60 * 5)
                {
                    WriteLog.WriteLogFile(dqinx + "", "打开app很久5分钟也没打开" + dqinx);
                    qidongcg = false;
                    break;
                }
            }
            if (!qidongcg)
            {
                MyFuncUtil.mylogandxianshi("打开app失败" + dqinx);
                return -1;
            }
            return dqinx;
        }

        public static int QiDongWanChengInx(string a_b,int dqinx, string app)
        {
            bool qidongcg = true;
            long ks = GetTimestamp();
            int i = 1;
            while (true)
            {
                if(i==1){
                    Qidong(dqinx, app);
                    i++;
                }
                if (PanDuan_Qidong(a_b,dqinx))
                {
                    break;
                }
                long js = MyFuncUtil.GetTimestamp();
                Thread.Sleep(20000);
                if ((js - ks) > 1000 * 60)
                {
                    i = 1;
                }
                if ((js - ks) > 1000 * 60 * 5)
                {
                    MyFuncUtil.mylogandxianshi("打开app很久5分钟也没打开" + dqinx);
                    qidongcg = false;
                    break;
                }
            }
            if (!qidongcg)
            {
                MyFuncUtil.mylogandxianshi("打开app失败" + dqinx);
                return -1;
            }
            return dqinx;
        }

        public static void LaunchAll(int shuliang)
        {
            zaiciguanbi();
            Thread.Sleep(2000);
            myDm dm = new myDm();
            lock (dm)
            {
                int jb = dm.FindWindowEx(0, "", "雷电多开器");
                int res=dm.bindWindow(jb);
                int dian = 0;
                if (res>0)
                {
                    Thread.Sleep(2000);
                    for (var j = 0; j < 20; j++)
                    {
                        dm.mytap(jb, 674, 97);
                        Thread.Sleep(1500);
                    }
                    for (int i = 0; i < shuliang; i++)
                    {
                        Thread.Sleep(2000);                        
                        int x = 373;
                        int y = 116;
                        int jiange = 50;
                        if (i <= 9)
                        {
                            String tmpcolor = dm.GetColor(x - 90, y + i * jiange);
                            if (!("c6c6c6".Equals(tmpcolor)))
                            {
                                WriteLog.WriteLogFile("", i + " " + tmpcolor);
                                //return;
                            }
                            dm.mytap(jb, x, y + i * jiange);
                            Thread.Sleep(12000);
                        }
                        else
                        {
                            if (dian == 0)
                            {
                                Thread.Sleep(2000);
                                for (var j = 0; j < 12; j++)
                                {
                                    dm.mytap(jb, 674, 593);
                                    Thread.Sleep(1500);
                                }
                                dian = 1;
                            }
                            String tmpcolor = dm.GetColor(x - 90, y + i * jiange - 340);
                            if (!("c6c6c6".Equals(tmpcolor)))
                            {
                                WriteLog.WriteLogFile("", i + "颜色不对呀 " + tmpcolor);
                                //return;
                            }
                            dm.mytap(jb, x, y + i * jiange - 340);
                            Thread.Sleep(12000);
                        }
                    }
                }
            }
        }

        public static void duokaiqiAdd(string a_b)
        {
            WriteLog.WriteLogFile("", "打开模拟器,新增15个或20个");
            int a = 3;
            if (WriteLog.getMachineName().ToLower().Equals("wlzhongkong"))
            {
                a = 2;
            }
            
            lock (obj)
            {
                myDm dm = new myDm();
                int jb = dm.FindWindowEx(0, "", "雷电多开器");
                if (jb <= 0)
                {
                    WriteLog.WriteLogFile("", "多开器未找到");
                    return;
                }
                int res = dm.bindWindow(jb);
                for (int i = 0; i < a; i++)
                {
                    if (res > 0)
                    {
                        dm.mytap_duokai(jb, 125, 628);
                        Thread.Sleep(2000);
                        int jb2 = dm.FindWindowEx(0, "assistantupdateframe", "");
                        if (jb2 <= 0)
                        {
                            WriteLog.WriteLogFile("", "多开器弹出框未找到");
                            return;
                        }
                        myDm dm2 = new myDm();
                        int res2 = dm2.bindWindow(jb2);
                        if (res2 > 0)
                        {
                            dm2.click(92, 12, 300);
                            Thread.Sleep(1000*30);
                        }
                    }
                }
            }
        }

        public static void duokaiqiAdd()
        {
            WriteLog.WriteLogFile("", "打开模拟器,新增9个,搞账号");
            lock (obj)
            {
                myDm dm = new myDm();
                int jb = dm.FindWindowEx(0, "", "雷电多开器");
                if (jb <= 0)
                {
                    WriteLog.WriteLogFile("", "多开器未找到");
                    return;
                }
                int res = dm.bindWindow(jb);
                for (int i = 0; i < 2; i++)
                {
                    if (res > 0)
                    {
                        dm.mytap_duokai(jb, 125, 628);
                        Thread.Sleep(2000);
                        int jb2 = dm.FindWindowEx(0, "assistantupdateframe", "");
                        if (jb2 <= 0)
                        {
                            WriteLog.WriteLogFile("", "多开器弹出框未找到");
                            return;
                        }
                        myDm dm2 = new myDm();
                        int res2 = dm2.bindWindow(jb2);
                        if (res2 > 0)
                        {
                            dm2.click(92, 12, 300);
                            Thread.Sleep(1000 * 30);
                        }
                    }
                }
            }
        }
        private static void dakaimoniqiByIndex(int index)
        {
            zaiciguanbi();
            Thread.Sleep(2000);
            WriteLog.WriteLogFile(index + "", "打开模拟器" + index);
            lock (obj)
            {
                myDm dm = new myDm();
                int jb = dm.FindWindowEx(0, "", "雷电多开器");
                if (jb <= 0) {
                    WriteLog.WriteLogFile(index + "", "多开器未找到" + index);
                    return;
                }
                int res=dm.bindWindow(jb);
                if (res > 0)
                {
                    Thread.Sleep(2000);
                    for (var i = 0; i < 25; i++)
                    {
                        dm.mytap_duokai(jb, 674, 97);
                        Thread.Sleep(1500);
                    }
                    int x = 373;
                    int y = 126;
                    int jiange = 50;
                    if (index <= 9)
                    {
                        String tmpcolor = dm.GetColor(x - 90, y + index * jiange);
                        if (!("c6c6c6".Equals(tmpcolor)))
                        {
                            
                            //WriteLog.WriteLogFile("", index + " " + tmpcolor);
                            //return;
                        }
                        dm.mytap_duokai(jb, x, y + index * jiange);
                        Thread.Sleep(12000);
                    }
                    else if (index>9 && index <= 16)
                    {
                        Thread.Sleep(2000);
                        for (var i = 0; i < 12; i++)
                        {
                            dm.mytap_duokai(jb, 674, 593);
                            Thread.Sleep(1500);
                        }
                        String tmpcolor = dm.GetColor(x - 90, y + index * jiange - 340);
                        if (!("c6c6c6".Equals(tmpcolor)))
                        {
                            //WriteLog.WriteLogFile("", index + "颜色不对呀 " + tmpcolor);
                            //return;
                        }
                        dm.mytap_duokai(jb, x, y + index * jiange - 340);
                        Thread.Sleep(12000);
                    }
                    else 
                    {
                        Thread.Sleep(2000);
                        for (var i = 0; i < 19; i++)
                        {
                            dm.mytap_duokai(jb, 674, 593);
                            Thread.Sleep(1500);
                        }
                        String tmpcolor = dm.GetColor(x - 90, y + index * jiange - 545);
                        WriteLog.WriteLogFile("", (x - 90) + " " + (y + index * jiange - 545));
                        if (!("c6c6c6".Equals(tmpcolor)))
                        {
                            //WriteLog.WriteLogFile("", index + "颜色不对呀 " + tmpcolor);
                            //return;
                        }
                        dm.mytap_duokai(jb, x, y + index * jiange - 545);
                        Thread.Sleep(12000);
                    }
                }
            }
        }



        private static void dakaimoniqiByIndexQiHao(int index)
        {
            WriteLog.WriteLogFile(index + "", "打开模拟器" + index);
            lock (obj)
            {
                myDm dm = new myDm();
                int jb = dm.FindWindowEx(0, "", "雷电多开器");
                if (jb <= 0)
                {
                    WriteLog.WriteLogFile(index + "", "多开器未找到" + index);
                    return;
                }
                int res = dm.bindWindow(jb);
                if (res > 0)
                {
                    int x = 373;
                    int y = 126;
                    int jiange = 50;
                    if (index <= 9)
                    {
                        String tmpcolor = dm.GetColor(x - 90, y + index * jiange);
                        if (!("c6c6c6".Equals(tmpcolor)))
                        {

                            //WriteLog.WriteLogFile("", index + " " + tmpcolor);
                            //return;
                        }
                        dm.mytap_duokai(jb, x, y + index * jiange);
                        Thread.Sleep(12000);
                    }                    
                }
            }
        }

        public static void findcolor() {
            myDm dm = new myDm();
            int jb = dm.FindWindowEx(0, "", "雷电多开器");
            int res=dm.bindWindow(jb);
            if (res > 0)
            {
                mylogandxianshi("绑好了");
                int x= -1;
                int y= -1;
                string firstColor = 0xc6c6c6.ToString("X");
                dm.FindColor(417, 109, 512, 151, firstColor, 0.9, 0, out x, out y);
                
                if (x > -1) {
                    mylogandxianshi("找到了");
                }
                mylogandxianshi("结束了"+x);
            }
        
        }

        public static void panduanqidong(int dqinx, string a_b)
        {
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd(a_b, out dizhi, out path, out seed);
            myDm dm = new myDm();
            int x1 = -1;
            int y1 = -1;
            int jubing = MyLdcmd.getDqmoniqiJuBingByIndex(dqinx, dizhi);
            if (jubing <= 0)
            {
                return;
            }
            dm.myGetClientRect(jubing, out x1, out y1);
            MyFuncUtil.mylogandxianshi("游戏启动不成功，界面有微信图标" + x1 + "  " + y1);
        }

        public static int suijishu(int min, int max)
        {
            Random rd = new Random();
            return rd.Next(min, max);
        }

        public static void zuobiaobianhua(int pgx, int pgy, out int mnx, out int mny)
        {
            int pg_width = 1334, pg_height = 750;
            int mn_width = 215, mn_height = 121;
            mnx = pgx * mn_width / pg_width;
            mny = pgy * mn_height / pg_height;
        }

        public static void cutJpgLuren()
        {
            Bitmap f = ReadImageFile(@"C:\mypic_save\193739625.png");
            Bitmap g = KiCut(f, 511, 756, 20, 60);
            g.Save(@"C:\mypic_save\haha11.jpg");
            g.Dispose();
        }
        /// <summary>
        /// 读取图片文件
        /// </summary>
        /// <param name="path">图片文件路径</param>
        /// <returns>图片文件</returns>
        public static Bitmap ReadImageFile(String path)
        {
            Bitmap bitmap = null;
            lock (obj)
            {
                try
                {
                    FileStream fileStream = File.OpenRead(path);
                    Int32 filelength = 0;
                    filelength = (int)fileStream.Length;
                    Byte[] image = new Byte[filelength];
                    fileStream.Read(image, 0, filelength);
                    System.Drawing.Image result = System.Drawing.Image.FromStream(fileStream);
                    fileStream.Close();
                    bitmap = new Bitmap(result);
                }

                catch (Exception ex)
                {
                    //  异常输出
                    WriteLog.WriteLogFile("", ex.Message);
                }
            }
            return bitmap;
        }

        /// <summary>
        /// 剪裁
        /// </summary>
        /// <param name="b">原始Bitmap</param>
        /// <param name="StartX">开始坐标X</param>
        /// <param name="StartY">开始坐标Y</param>
        /// <param name="iWidth">宽度</param>
        /// <param name="iHeight">高度</param>
        /// <returns>剪裁后的Bitmap</returns>
        public static Bitmap KiCut(Bitmap b, int StartX, int StartY, int iWidth, int iHeight)
        {
            if (b == null)
            {
                return null;
            }

            int w = b.Width;
            int h = b.Height;
            if (StartX >= w || StartY >= h)
            {
                WriteLog.WriteLogFile("", StartX +"" );
                return null;
            }
            WriteLog.WriteLogFile("", StartX + " "+iWidth+" "+w+" "+h);
            if (StartX + iWidth > w)
            {
                iWidth = w - StartX;
            }

            if (StartY + iHeight > h)
            {
                iHeight = h - StartY;
            }
            lock (obj)
            {
                try
                {
                    //Bitmap bmpOut = new Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb);//裁剪成小一号的图片

                    Bitmap bmpOut = new Bitmap(w, h, PixelFormat.Format24bppRgb);//保持原大小，裁剪部分用指定的颜色填充
                    Graphics graphics = Graphics.FromImage(bmpOut);
                    graphics.Clear(Color.White);//裁剪部分用指定的颜色填充
                    graphics.DrawImage(b, new Rectangle(StartX, StartY, iWidth, iHeight), new Rectangle(StartX, StartY, iWidth, iHeight), GraphicsUnit.Pixel);
                    graphics.Dispose();
                    return bmpOut;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
