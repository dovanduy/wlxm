using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Win32;
using xDM;
namespace MyUtil
{
    public class MyFuncJingNoTai
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



        public bool lurenResizeOk(int index,string youxi="luneng")
        {

            WriteLog.WriteLogFile(index + "", "改变窗口位置--开始");
            string dizhi = @"d:\ChangZhi\dnplayer2\";
            bool t = false;
            long ksjs = MyFuncUtil.GetTimestamp();
            long ks = MyFuncUtil.GetTimestamp();
            int width = -1, height = -1;
            myReSize(index, out width, out height,youxi);
            WriteLog.WriteLogFile(index + "", "准备获取句柄，在lurenResizeOk处");
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
        public void myReSize(int index, out int width, out int height, string youxi = "luneng", string dizhi = @"d:\ChangZhi\dnplayer2\")
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

        public void myBianWeiZhi(int index, string dizhi = @"d:\ChangZhi\dnplayer2\")
        {
            WriteLog.WriteLogFile(index + "", "模拟器" + index + "开始改位置");
            int dqwidth = 2560;//1920 1024
            int dqheight = 1440;//1080 768            
            int jubing = MyLdcmd.getDqmoniqiWaiCengJuBingByIndex(index, dizhi);
            IntPtr p = new IntPtr(jubing);
            IntPtr p2 = new IntPtr(HWND_TOP);
            int x = 0;
            int y = 0;
            int yiquanw = 578;
            int yiquany = 1028;
            x = ((index-1) % 4) * (dqwidth / 4);
            y = (index / 4) * (dqheight / 4);
            WriteLog.WriteLogFile(index + "", index + "x:" + x + ",y:" + y);
            SetWindowPos(p, p2, x, y, yiquanw, yiquany, SWP_SHOWWINDOW);
        }

        public void myReSizeByWAndH(int index,int jubing,int width,int height,string dizhi = @"d:\ChangZhi\dnplayer2\")
        {
            if (jubing <=0) {
                jubing = MyLdcmd.getDqmoniqiWaiCengJuBingByIndex(index,dizhi);
            }
            WriteLog.WriteLogFile(index + "", "模拟器" + index + "开始改大小,外层句柄" + jubing);
            int dqwidth = 2560;//1920 1024
            int dqheight = 1440;//1080 768
            IntPtr p = new IntPtr(jubing);
            IntPtr p2 = new IntPtr(HWND_TOP);
            int x = 0;
            int y = 0;
            x = (index % 4) * (dqwidth / 4);
            y = (index / 4) * (dqheight / 4);
            WriteLog.WriteLogFile(index + "", index + "x:" + x + ",y:" + y);
            SetWindowPos(p, p2, x, y, width, height, SWP_SHOWWINDOW);
            
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

        public bool myQuit(int index, string dizhi)
        {
            var res = false;
            WriteLog.WriteLogFile(index+"","准备获取句柄，在myquit处");
            int jubing = MyLdcmd.getDqmoniqiWaiCengJuBingByIndex(index, dizhi);
            IntPtr p = new IntPtr(jubing);
            PostMessage(p, WM_CLOSE, 0, 0);
            Thread.Sleep(5000);
            MyLdcmd myldcmd = MyLdcmd.GetObject(dizhi);
            long kstime = MyFuncUtil.GetTimestamp();
            long kstime2 = MyFuncUtil.GetTimestamp();
            int[] abc = MyLdcmd.getDqmoniqiHuodongIndex(dizhi);
            if (abc.Contains(index))
            {
                MyLdcmd.getLdCmd().Quit(index);
                Thread.Sleep(5000);
                MyFuncUtil.zaiciguanbi();
            }
            abc = MyLdcmd.getDqmoniqiHuodongIndex(dizhi);
            if (!abc.Contains(index))
            {
                return true;
            }
            int shi = 0;
            while (true)
            {
                long jstime = MyFuncUtil.GetTimestamp();
                if ((jstime - kstime2) > 1000 * 30)
                {
                    abc = MyLdcmd.getDqmoniqiHuodongIndex(dizhi);
                    kstime2 = MyFuncUtil.GetTimestamp();
                }
                if (shi == 0 && abc.Contains(index))
                {
                    MyLdcmd.getLdCmd().Quit(index);
                    Thread.Sleep(5000);
                    MyFuncUtil.zaiciguanbi();
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
                    MyFuncUtil.mylogandxianshi("循环很久5分钟也没有关闭" + index);
                    break;
                }
            }
            
        return res;
        }

        public bool PanDuan_QidongLurenzhanghao(int dqinx,myDm dm,int jubing)
        {

            int x1 = -1;
            int y1 = -1;
            if (jubing <= 0)
            {
                WriteLog.WriteLogFile(dqinx + "", "游戏判断启动，句柄绑定错误");
                return false;
            }
            Entity.FuHeSanDian tysd = null;
            int w = -1, h = -1;
            getWindowSize(dqinx,jubing, out w, out h);
            //WriteLog.WriteLogFile(dqinx + "", w + " " + h);
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
            if (a == 1 && dm.mohuByLeiBool_duokai(tysd.Sd))
            {
                WriteLog.WriteLogFile(dqinx + "", "游戏启动不成功，界面有雷电游戏 " + x1 + " " + y1);
                return false;
            }
            return true;
        }


        public bool PanDuan_GetZhiDingDian(int dqinx, myDm dm, int jubing,fuzhu.SanDianAbs sdabs,string sdname)
        {

            if (jubing <= 0)
            {
                WriteLog.WriteLogFile(dqinx + "", "游戏判断启动，句柄错误<=0");
                return false;
            }
            Entity.FuHeSanDian tysd = sdabs.findFuHeSandianByName(sdname);
            int r = dm.bindWindow(jubing);
            if (r <= 0)
            {
                WriteLog.WriteLogFile(dqinx + "", "游戏句柄绑定错误");
                return false;
            }
            if (dm.mohuByLeiBool_duokai(tysd.Sd))
            {
                WriteLog.WriteLogFile(dqinx + "", "游戏启动成功，界面有游戏画面" + sdname);
                return true;
            }
            return false;
        }

        public int QiDongWanChengGetZhiDingDian(int dqinx, string app,myDm dm, int jubing,fuzhu.SanDianAbs sdabs,string sdname)
        {
            WriteLog.WriteLogFile(dqinx + "", "尝试打开app" + app);
            bool qidongcg = true;
            long ks = MyFuncUtil.GetTimestamp();
            int i = 1;
            while (true)
            {
                if (i == 1)
                {
                    MyFuncUtil.Qidong(dqinx, app);
                    Thread.Sleep(1000 * 20);
                    i++;
                }
                if (PanDuan_GetZhiDingDian(dqinx,dm,jubing,sdabs,sdname))
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

        public void getWindowSize(int index,int jubing, out int width, out int height)
        {
            string dizhi = @"d:\ChangZhi\dnplayer2\";
            width = -1;
            height = -1;
            if (jubing <= 0)
            {
                WriteLog.WriteLogFile(index + "", "准备获取句柄，在getWindowSize处外层句柄");
                jubing = MyLdcmd.getDqmoniqiWaiCengJuBingByIndex(index, dizhi);
                if (jubing <= 0)
                {
                    WriteLog.WriteLogFile(index + "", "改变窗口位置，句柄绑定错误");
                    return;
                }
            }
            Rect lprect = new Rect();
            GetWindowRect(new IntPtr(jubing), out lprect);
            width = lprect.Right - lprect.Left;
            height = lprect.Bottom - lprect.Top;
            //WriteLog.WriteLogFile(index + "", "当前width,height" + width + "," + height + " 改变位置外框" + (lprect.Right - lprect.Left) + " " + (lprect.Bottom - lprect.Top));
         }


        public bool PanDuan_QidongByYiQuDian(int dqinx, int haomiao, myDm mf, int jubing, out string yiqudian)
        {
            WriteLog.WriteLogFile(dqinx + "", "模拟器发现已取点已去电非ip-开始判断"+haomiao);
            long ks = MyFuncUtil.GetTimestamp();
            var rt = false;
            string oyiqudian = "";
            while (true) {
                long js = MyFuncUtil.GetTimestamp();
                if ((js - ks) > haomiao) {
                    break;
                }
                int r = panduankasiqudian(dqinx, mf, jubing, out oyiqudian);
                if (r >= 1) {
                    rt = true;
                    break;
                }
            }
            yiqudian = oyiqudian;
            WriteLog.WriteLogFile(dqinx + "", "模拟器发现已取点已去电非ip-结束判断" + haomiao);
            return rt;
        }

        public bool PanDuan_QidongByYiQuDian_IP(int dqinx, int haomiao, myDm mf, int jubing, out string yiqudian)
        {
            WriteLog.WriteLogFile(dqinx + "", "模拟器发现已取点-开始判断" + haomiao);
            long ks = MyFuncUtil.GetTimestamp();
            var rt = false;
            string oyiqudian = "请稍候";
            Entity.FuHeSanDian f = fuzhu.TongYong_SanDian.GetObject().findFuHeSandianByName("IPtool");
            lock (obj)
            {
                while (true)
                {
                    long js = MyFuncUtil.GetTimestamp();
                    if ((js - ks) > haomiao)
                    {
                        break;
                    }
                    if (mf.mohuByLeiBool(f.Sd))
                    {
                        WriteLog.WriteLogFile(dqinx + "", f.Name + "模糊取到" + jubing + " " + mf.bindWindow(jubing));
                        //mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);                    
                        //mf.myMove(jubing, f.Zhidingx, f.Zhidingy);
                        if (mf.mohu_duokai(84, 237, 0xd5d5d5) == 1)
                        {
                            mf.mytap_duokai(jubing, 84, 237);
                            WriteLog.WriteLogFile(dqinx + "", "复制信息1");
                        }
                        mf.mydelay(2000, 3000);
                        if (mf.mohu_duokai(80, 536, 0xffffff) == 1)
                        {
                            mf.mytap_duokai(jubing, 80, 536);
                            mf.mydelay(2000, 3000);
                            //mf.mytap_duokai(jubing, 428, 763);
                            //mf.mydelay(2000, 3000);
                            WriteLog.WriteLogFile(dqinx + "", "复制信息2");
                        }
                        WriteLog.WriteLogFile(dqinx + "", mf.GetClipboard() + " 当前剪切板");
                        oyiqudian = mf.GetClipboard();
                        if (oyiqudian != "" && oyiqudian.IndexOf("请") < 0)
                        {
                            rt = true;
                            break;
                        }
                    }
                }
            }
            yiqudian = oyiqudian;
            return rt;
        }

        private int panduankasiqudian(int dqinx,myDm mf,int jubing,out string yiqudian)
        {
            WriteLog.WriteLogFile(dqinx + "", "进入已取点-开始判断" );
            StringBuilder rt = new StringBuilder();
            int res = 0;
            for (int i = 0; i < 10; i++)
            {
                foreach (Entity.FuHeSanDian f in fuzhu.YiQuan_SanDian.List_yqfhsandian)
                {
                    if (mf.mohuByLeiBool(f.Sd))
                    {
                        WriteLog.WriteLogFile(dqinx + "", f.Name + "模糊取到");
                        //mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                        mf.mydelay(1000, 2000);
                        rt.Append(f.Name);
                        res++;
                    }
                    if (res > 0) {
                        break;
                    }
                }
                foreach (Entity.FuHeSanDian f in fuzhu.YiQuanZhiTuo_SanDian.List_yqfhsandian)
                {
                    if (mf.mohuByLeiBool(f.Sd))
                    {
                        WriteLog.WriteLogFile(dqinx + "", f.Name + "Zhituo模糊取到");
                        //mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                        mf.mydelay(1000, 2000);
                        rt.Append(f.Name);
                        res++;
                    }
                    if (res > 0) {
                        break;
                    }
                }
                if (res > 0)
                {
                    break;
                }
                mf.mydelay(10, 200);
            }
            string rr = "";
            if (rt != null && rt.Length > 0) {
                rr = rt.ToString();
            }
            yiqudian = rr;
            WriteLog.WriteLogFile(dqinx + "", "进入已取点-结束");
            return res;
        }

        public bool PanDuan_QidongBySize(int dqinx, int waicengjubing,int haomiao,int wid=727,int hei=425)
        {
            long ks = MyFuncUtil.GetTimestamp();
            var rt = false;
            while (true)
            {
                long js = MyFuncUtil.GetTimestamp();
                if ((js - ks) > haomiao)
                {
                    break;
                }
                int w = -1, h = -1;
                getWindowSize(dqinx, waicengjubing,out w, out h);
                if (w==wid && h==hei)
                {
                    rt = true;
                    break;
                }
                Thread.Sleep(3000);
                myReSizeByWAndH(dqinx, waicengjubing, wid, hei);
            }
            return rt;
        }

        public void getIP(int dqinx, string dizhi, string seed,int jubing, int waicengjubing, out string ip)
        {
            WriteLog.WriteLogFile(dqinx + "", "获取IP,jubing:" + jubing + ",waicengjubing:" + waicengjubing);
            ip = "";
            bool t = false;
            string packagename = "package:com.ddm.iptools";
            //lock (obj)
            {
                t = MyFuncUtil.lureninstallOk(dqinx, packagename, () =>
                {
                    WriteLog.WriteLogFile(dqinx + "", "安装app没成功--iptools");
                    /*temp = myQuit(dqinx, dizhi);
                    if (!temp)
                    {
                        WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "关闭失败");
                        Thread.Sleep(20000);
                        return;
                    }*/
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "安装iptools");
                    //MyLdcmd.myRestore(dqinx, seed, dizhi);
                    MyLdcmd.installApp(dqinx, @"C:\迅雷下载\2_1b823b1928a42f09423f28cb79179bfe.apk");
                    /*temp = myQuit(dqinx, dizhi);
                    if (!temp)
                    {
                        WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "关闭失败");
                        Thread.Sleep(20000);
                        return;
                    }
                    temp = MyFuncUtil.Launch(dqinx, dizhi);
                    if (!temp)
                    {
                        WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "打开失败");
                        Thread.Sleep(20000);
                        return;
                    }*/
                    Thread.Sleep(3000);
                });
                if (t == false)
                {
                    Thread.Sleep(1000*60*2);
                    bool luren = MyLdcmd.jingjieisok(dqinx, packagename);
                    if (!luren)
                    {
                        return;
                    }
                    
                }
                //窗口已打开 获取句柄
                if (jubing <= 0)
                {
                    WriteLog.WriteLogFile(dqinx + "", "准备获取句柄，在getIP处");
                    jubing = MyLdcmd.getDqmoniqiJuBingByIndex(dqinx, dizhi);
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "句柄为" + jubing);
                }
                myDm dm = new myDm();
                int r1 = 0;
                if (jubing > 0)
                {
                    r1 = dm.bindWindow(jubing);
                }
                if (r1 != 1)
                {
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "绑定失败");
                    Thread.Sleep(20000);
                    return;
                }
                dm.SetClipboard("请");
                //apkName = dict["IPtool"];
                string apkName = "com.ddm.iptools/com.ddm.iptools.ui.MainActivity";
                //int i = MyFuncUtil.QiDongWanChengLurenzhanghao("d", dqinx, apkName);
                fuzhu.YouXiFactory yxf = new fuzhu.YouXiFactory();
                int i = QiDongWanChengGetZhiDingDian(dqinx, apkName, dm, jubing, yxf.CreateYouXiSanDian("tongyongsandian"), "IPtool");
                if (i == -1)
                {
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "打开app" + apkName + "失败");
                    Thread.Sleep(20000);
                    return;
                } 
                string yiqu = "";                
                bool t2 = PanDuan_QidongByYiQuDian_IP(dqinx, 1000 * 60*5, dm, jubing, out yiqu);
                if (t2)
                {
                    WriteLog.WriteLogFile(dqinx + "", "模拟器发现已取点" + yiqu);
                }
                ip = yiqu;                
                /*if (ip != "" && ip.IndexOf("请") < 0)
                {
                    return;
                }  */              
            }
        }



    }
}
