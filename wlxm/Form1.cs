using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using xDM;
using XXDM.Helper;
using System.Threading;
using System.Diagnostics;
using MyUtil;
using fuzhu;
using Entity;
namespace wlxm
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// ?助的版本
        /// </summary>
        private static int fuzhuBanben = 12;
        

        /// <summary>
        /// 全局button ?了就不自??行
        /// </summary>
        private static int quanjubutton = 0;

        /// <summary>
        /// dict 游?名?和包名存?
        /// </summary>
        private Dictionary<string, string> dict = new Dictionary<string, string>();
        /// <summary>
        /// ??游?的包名和架构名
        /// </summary>
        private string apkName = null;
        /// <summary>
        /// 得到?前模?器的index
        /// </summary>
        //private int dqindex = -1;
        /// <summary>
        /// 出?提示
        /// </summary>
        private Boolean tmpBool = false;
        /// <summary>
        /// 出?信息
        /// </summary>
        private StringBuilder tmpBoolString = new StringBuilder();
        /// <summary>
        /// 多?程 ?程?
        /// </summary>
        //private object locker = new object();
        /// <summary>
        /// 主?程 定??示?行??
        /// </summary>
        private Thread thread;
        private delegate void changeText(string result);
        private delegate void getduokaiqi();
        /// <summary>
        /// ?置倒????
        /// </summary>
        //private int DaoJiShi = 180;
        //private int jishi;
        //private Boolean jishibl = true;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, out  Rect lpRect);
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        
        /// <summary>
        /// ??多?程的?程ID
        /// </summary>
        private List<Thread> list_xc = new List<Thread>();
        /// <summary>
        /// ?例模式?量
        /// </summary>
        private static readonly object obj = new object();

        private void initPackageName()
        {
            dict.Add("明日方舟", "com.hypergryph.arknights/com.u8.sdk.U8UnityContext");
            dict.Add("一拳超人", "com.playcrab.kos.gw/org.cocos2dx.lua.AppActivity");
            dict.Add("路人超能", "com.idreamsky.psycho100/com.yinghuochong.unity_entry.CustomUnityPlayerActivity");
            dict.Add("境界", "com.wk.jingjie.ewan/cn.ewan.supersdk.activity.SplashActivity");
            this.label1.Text = "?前版本:" + fuzhuBanben;
            this.label3.Text = "?前游?:" + "?定:境界";
            this.label3.ForeColor = Color.Red;
            string a_b = "";
            if (WriteLog.getMachineName().ToLower().Equals("wlzhongkong"))
            {
                a_b = "d";
            }
            else
            {
                a_b = "c";
            }
            MyFuncUtil.createDirIfNotExist(a_b);

        }
        public Form1()
        {
            InitializeComponent();
            initPackageName();
            ThreadStart threadStart = new ThreadStart(foo);
            this.thread = new Thread(threadStart);
            this.thread.Start();
        }

        private void foo()
        {

            var ks = MyFuncUtil.GetTimestamp();
            var ks_gxyunxing = MyFuncUtil.GetTimestamp();
            var ks_cqyunxing = MyFuncUtil.GetTimestamp();
            var i = 1;
            var yici = 0;
            string zidong = "";            
            while (true)
            {
                Thread.Sleep(1000);
                var js = MyFuncUtil.GetTimestamp();
                i++;

                //MyFuncUtil.SecondToHour(+i + (js - ks) / 1000+" "
                CalcFinished("程序已?行:" + MyFuncUtil.SecondToHour(js - ks) + zidong);
                this.label2.ForeColor = Color.Red;
                if (quanjubutton == 0 && yici == 0 && (js - ks) > 1000 * 10 && (js - ks) <= 1000 * 20)
                {
                    WriteLog.WriteLogFile("", "程序搞自?倒?? " + (20-(js - ks)/1000)+"秒");
                }
                if (quanjubutton==0 && yici == 0 && (js - ks) > 1000 * 20)
                {
                    quanjubutton = 1;
                    yici = 1;
                    //dpanduoxiancheng.PerformClick();
                    zidong = ",自??行中";
                    if (WriteLog.getMachineName().ToUpper().Equals("1HAO"))
                    {
                        ThreadStart threadStart = new ThreadStart(gaozhanghaotou);//通?ThreadStart委托告?子?程?行什么方法　
                        Thread thread = new Thread(threadStart);
                        thread.Name = "wodegaozhanghao";
                        thread.Start();
                    }
                    else
                    {
                        ThreadStart threadStart = new ThreadStart(duoxianzongtou);//通?ThreadStart委托告?子?程?行什么方法　
                        Thread thread = new Thread(threadStart);
                        thread.Name = "wodedpanduoxian";
                        thread.Start();
                    }
                }
                //每隔一小?由zk更新一次 ??? 每隔1分?
                if (WriteLog.getMachineName().ToUpper().Equals("WLZHONGKONG") && (js - ks_gxyunxing) > 1000 * 60*20)
                {
                    ks_gxyunxing = MyFuncUtil.GetTimestamp();
                    ZhangHao zh = new ZhangHao();
                    DateTime dt=zh.getYunXingQkLasttime();
                    TimeSpan span = DateTime.Now.Subtract(dt);
                    WriteLog.WriteLogFile("", "准?更新与上次??相比,?隔 " + span.Minutes + "分?");
                    
                    if (span.Hours >= 1 || span.Minutes > 45)
                    
                    {
                        WriteLog.WriteLogFile("", "与上次??相比,?隔 " + span.Minutes + "分?");
                        zh.gxYunXingQk();
                    }
                }

                //每隔60分?查看是否??重? ??? 每隔1分?
                if (WriteLog.getMachineName().ToUpper().Equals("WLZHONGKONG") && (js - ks_cqyunxing) > 1000 * 60 * 60)
                {
                    ks_cqyunxing = MyFuncUtil.GetTimestamp();
                    ZhangHao zh = new ZhangHao();
                    bool t = zh.panDuanChongQi(WriteLog.getMachineName());
                    if (t)
                    {
                        WriteLog.WriteLogFile("", "?前需要重?" + DateTime.Now);
                        myDm dm = new myDm();
                        dm.ExitOs(2);
                    }
                }
            }

        }

        

        private void CalcFinished(string result)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new changeText(CalcFinished), result);
            }
            else
            {
                this.label2.Text = result.ToString();
            }
        }

        private void duokaiqi()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new getduokaiqi(duokaiqi));
            }
            else
            {
                MyLdcmd.RunDuokaiqi("d");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            quanjubutton = 1;
            MyFuncUtil.mylogandxianshi("?始");
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd("d", out dizhi, out path, out seed);            
            int dqinx = int.Parse(this.textBox1.Text);
            int jubing = MyLdcmd.getDqmoniqiJuBingByIndex(dqinx, dizhi);
            //MyLdcmd.myRemove(dqinx);
            //int t = MyLdcmd.addSimulator();
            myDm mf = new myDm();
            Jingjie ln = new Jingjie(mf, dqinx);
            ln.denglu(15, out apkName);
            ln.zhuxian(apkName);
            //ln.generalBasicShuziDemo(1, @"c:\mypic_save\1_192622781.bmp");
            MyFuncUtil.mylogandxianshi("?束");
            
        }
        private void lurenzhanghao(object inx)
        {
            /*??程模式：
             *1、新建成功后打??模?器 安?可以在模?器未打?情?下?行
             *2、模?器打?后安?apk
             *3、安?成功后打?游?
             *4、游?更新成功后??游客登?并保存
             *5、保存后截取要保存的?并??
             *6、??后存入sql
             *7、??模?器
             *8、reload存?文件
             */
            //for (int cs = 0; cs < 20; cs++)
            {
                var ks = MyFuncUtil.GetTimestamp();
                string dizhi = null;
                string path = null;
                string seed = null;
                string a_b = "d";
                MyFuncUtil.myqiehuancd(a_b, out dizhi, out path, out seed);
                int dqinx = (int)inx;                
                if (dqinx <= -1)
                {
                    return;
                }
                WriteLog.WriteLogFile(dqinx + "", "准?操作" + dqinx + "?模?器");
                bool temp = MyFuncUtil.myQuit(dqinx, dizhi);//??指定模?器 dqinx
                if (!temp)
                {
                    WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + "??失?");
                    Thread.Sleep(20000);
                    return;
                }
                WriteLog.WriteLogFile(dqinx + "", "准?操作" + dqinx + "?模?器");
                MyLdcmd.installApp(dqinx, @"C:\迅雷下?\jjlydj_ew100224700.apk");
                bool t = MyFuncUtil.lureninstallOk(dqinx);
                if (t == false)
                {
                    WriteLog.WriteLogFile(dqinx + "", "安?app?成功");
                    return;
                }
                t = MyFuncUtil.myQuit(dqinx, dizhi);//??指定模?器 dqinx
                if (!t)
                {
                    WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + "??失?");
                    Thread.Sleep(20000);
                    return;
                }
                WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + "改名");
                MyLdcmd.myRename(dqinx, "雷?" + dqinx, dizhi);                
                temp = MyFuncUtil.LaunchQiHao(dqinx);
                if (!temp)
                {
                    WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + "打?失?");
                    Thread.Sleep(20000);
                    return;
                }
                Thread.Sleep(20000);
                apkName = dict["境界"];
                int i = MyFuncUtil.QiDongWanChengLurenzhanghao(a_b, dqinx, apkName);
                if (i == -1)
                {
                    WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + "打?app" + apkName + "失?");
                    Thread.Sleep(20000);
                    return;
                }
                int w = -1, h = -1;
                MyFuncUtil.getWindowSize(dqinx, out w, out h);
                if (w != -1 && h != -1 && w < h) {
                    WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + "w h不?"+w+" "+h);
                    Thread.Sleep(20000);
                    return;
                }
                MyFuncJingNoTai mno = new MyFuncJingNoTai();
                temp = mno.lurenResizeOk(dqinx);
                if (temp == false)
                {
                    WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + ",resize?成功");
                    return;
                }
                myDm mf = new myDm();
                Jingjie jn = new Jingjie(mf, dqinx);
                if (jn.Jubing <= 0)
                {
                    WriteLog.WriteLogFile(dqinx + "", "句柄有??");
                    Thread.Sleep(20000);
                    return;
                }
                jn.jingjiecunhao();
                temp = MyFuncUtil.myQuit(dqinx, dizhi);//??指定模?器 dqinx
                if (!temp)
                {
                    WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + "??失?");
                    Thread.Sleep(20000);
                    return;
                }
                Thread.Sleep(10000);
                WriteLog.WriteLogFile(dqinx + "", "一次循??束");
                var js = MyFuncUtil.GetTimestamp();
                WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + "循?完成");
                WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + "循?1次耗?" + MyFuncUtil.SecondToHour(js - ks));
            }
        }

        private void lrzh_Click(object sender, EventArgs e)
        {
            quanjubutton = 1;
            ThreadStart threadStart = new ThreadStart(gaozhanghaotou);//通?ThreadStart委托告?子?程?行什么方法　
            Thread thread = new Thread(threadStart);
            thread.Name = "wodegaozhanghao";
            thread.Start();
            
        }

        private void gaozhanghaotou() {
            int[] yunxingIndex = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };//3,4,5,6,7,8,9,10,11,12,13,14
            string dizhi = null;
            string path = null;
            string seed = null;
            string a_b = "d";
            MyFuncUtil.myqiehuancd(a_b, out dizhi, out path, out seed);
            MyFuncUtil.mylogandxianshi("准?搞??");
            MyFuncUtil.createDirIfNotExist();
            Thread.Sleep(2000);
            for (int j = 0; j < 10000; j++)
            {
                MyFuncUtil.mylogandxianshi("序?" + j + ",?始");
                MyLdcmd.myQuitAll(dizhi);
                Thread.Sleep(2000);
                MyLdcmd.myRemoveAll(dizhi);
                Thread.Sleep(2000);
                MyLdcmd.RunDuokaiqi(a_b);
                MyFuncUtil.duokaiqiAdd();
                Thread.Sleep(2000);
                ThreadPool.SetMaxThreads(yunxingIndex.Length, yunxingIndex.Length); //?置最大?程?
                foreach (int inx in yunxingIndex)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(lurenzhanghao), inx);//?程池指定?程?行Auto方法
                    Thread.Sleep(1000);
                }
                long ks = MyFuncUtil.GetTimestamp();
                while (true)
                {
                    Thread.Sleep(1000);//?句??，主要是?必要循?那么多次。去掉也可以。
                    int maxWorkerThreads, workerThreads;
                    int portThreads;
                    ThreadPool.GetMaxThreads(out maxWorkerThreads, out portThreads);
                    ThreadPool.GetAvailableThreads(out workerThreads, out portThreads);
                    if (maxWorkerThreads - workerThreads == 0)
                    {
                        Console.WriteLine("?束了");
                        break;
                    }
                }
                MyFuncUtil.mylogandxianshi("序?" + j + ",?束");
            }
        }
        
        private void ceshi_button_Click(object sender, EventArgs e)
        {
            quanjubutton = 1;
            apkName = dict["一拳超人"];
            int[] yunxingIndex = null;
            if (WriteLog.getMachineName().ToLower().Equals("wlzhongkong"))
            {
                yunxingIndex = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };//, 6, 7, 8, 9,10,11,12,13,14,15,16,17,18,19
            }
            else
            {
                yunxingIndex = new int[] { 1, 2,  4, };//,4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,15
            } 
            string dizhi = null;
            string path = null;
            string seed = null;
            string a_b = "d";
            //MyLdcmd.RunDuokaiqi(a_b);
            MyFuncUtil.myqiehuancd(a_b, out dizhi, out path, out seed);            
            MyFuncUtil.mylogandxianshi("准?多?程??");
            for (int j = 0; j < 5; j++)
            {
                MyFuncUtil.mylogandxianshi("序?" + j + ",?始");

                ThreadPool.SetMaxThreads(yunxingIndex.Length, yunxingIndex.Length); //?置最大?程?
                foreach (int inx in yunxingIndex)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(duoxian_cs), inx);//?程池指定?程?行Auto方法
                    Thread.Sleep(1000*20);
                }
                long ks = MyFuncUtil.GetTimestamp();
                while (true)
                {
                    Thread.Sleep(1000);//?句??，主要是?必要循?那么多次。去掉也可以。
                    int maxWorkerThreads, workerThreads;
                    int portThreads;
                    ThreadPool.GetMaxThreads(out maxWorkerThreads, out portThreads);
                    ThreadPool.GetAvailableThreads(out workerThreads, out portThreads);
                    if (maxWorkerThreads - workerThreads == 0)
                    {
                        Console.WriteLine("?束了");
                        break;
                    }                    
                }
                MyFuncUtil.mylogandxianshi("序?" + j + ",?束");
            }
        }
        private void duoxian_cs(object dqind)
        {
            int a = (int)dqind;
            duoxianxunhuancs("d", a, 20);
            return;
        }

        private void duoxianxunhuancs(string a_b, int dqinx, int xhcishu)
        {
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd(a_b, out dizhi, out path, out seed);
            var cishu = 0;
            for (int cs = 0; cs < xhcishu; cs++)
            {
                var ks = MyFuncUtil.GetTimestamp();
                
                
                myDm dm = new myDm();
                MyFuncUtil.mylogandxianshi("模?器" + dqinx + "降低cpu");
                //MyLdcmd.myDownCpu(dqinx, 50);
                Jingjie yq = new Jingjie(dm, dqinx, dizhi);
                //yq.denglu(15, out a_b);
                yq.zhuxian(a_b);
                Thread.Sleep(1000 * 60 * 60);
                
                var js = MyFuncUtil.GetTimestamp();
                MyFuncUtil.mylogandxianshi("模?器" + dqinx + "循?" + cishu + "次?");
                MyFuncUtil.mylogandxianshi("模?器" + dqinx + "循?1次耗?" + MyFuncUtil.SecondToHour(js - ks));
            }
        }


        private void quanliucheng_Click(object sender, EventArgs e)
        {
            quanjubutton = 1;
            MyFuncUtil.mylogandxianshi("?始-已取?");
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd("d", out dizhi, out path, out seed);
            int dqinx = int.Parse(this.textBox1.Text);
            myDm mf = new myDm();
            Jingjie yq = new Jingjie(mf, dqinx, dizhi);
            for (int i = 0; i < 20; i++)
            {
                foreach (FuHeDuoDian f in Jingjie_DuoDian.List_yqfhduodian)
                {
                    int x = -1, y = -1;
                    mf.myqudianqusezuobiaoByLeiWuJubing(f.Dz, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        MyFuncUtil.mylogandxianshi(f.Name);
                        //mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                        mf.mydelay(1000, 2000);
                    }
                }               
                mf.mydelay(10, 200);
            }
            for (int i = 0; i < 10; i++)
            {
                foreach (FuHeSanDian f in Jingjie_SanDian.List_yqfhsandian)
                {
                    if (mf.mohuByLeiBool(f.Sd))
                    {
                        MyFuncUtil.mylogandxianshi(f.Name+"模糊取到");
                        //mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                        mf.mydelay(1000, 2000);
                    }
                    if (mf.jingqueByLeiBool(f.Sd))
                    {
                        MyFuncUtil.mylogandxianshi(f.Name + "精确取到");
                        mf.mydelay(1000, 2000);
                    }
                }
                mf.mydelay(10, 200);

            }
            MyFuncUtil.mylogandxianshi("?束-已取?");
        }
        
        private void dpanduoxiancheng_Click(object sender, EventArgs e)
        {
            quanjubutton = 1;
            ThreadStart threadStart = new ThreadStart(duoxianzongtou);//通?ThreadStart委托告?子?程?行什么方法　
            Thread thread = new Thread(threadStart);
            thread.Name = "wodedpanduoxian";
            thread.Start();
            
        }

        private void duoxianzongtou() {
            int[] yunxingIndex = null;
            if (WriteLog.getMachineName().ToLower().Equals("wlzhongkong"))
            {
                yunxingIndex = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, };//, 6, 7, 8, 9,10,11,12,13,14,15,16,17,18,19
            }
            else
            {
                yunxingIndex = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, };//,4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,15
            }
            string a_b = "d";
            //qdinit(a_b);
            //MyLdcmd.RunDuokaiqi(a_b);
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd(a_b, out dizhi, out path, out seed);
            //所有??置?dengluzhong N 多?机器的? ?有麻?
            //ZhangHao zh = new ZhangHao();
            //zh.zhiweidengluzhongN("jingjie", WriteLog.getMachineName());
            for (int j = 1; j < 1000; j++)
            {
                WriteLog.WriteLogFile("", "序?" + j + ",?始");
                MyLdcmd.myQuitAll(dizhi);
                Thread.Sleep(2000);
                MyLdcmd.myRemoveAll(dizhi);
                Thread.Sleep(2000);
                MyLdcmd.RunDuokaiqi(a_b);
                Thread.Sleep(2000);
                MyFuncUtil.duokaiqiAdd(a_b);
                Thread.Sleep(2000);
                ThreadPool.SetMaxThreads(yunxingIndex.Length, yunxingIndex.Length); //?置最大?程?
                foreach (int inx in yunxingIndex)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(duoxiand), inx);//?程池指定?程?行Auto方法
                    //Thread.Sleep(1000 * 40);
                }
                var ks = MyFuncUtil.GetTimestamp();
                while (true)
                {
                    Thread.Sleep(10000);//?句??，主要是?必要循?那么多次。去掉也可以。
                    int maxWorkerThreads, workerThreads;
                    int portThreads;
                    ThreadPool.GetMaxThreads(out maxWorkerThreads, out portThreads);
                    ThreadPool.GetAvailableThreads(out workerThreads, out portThreads);
                    if (maxWorkerThreads - workerThreads == 0)
                    {
                        break;
                    }
                }

                WriteLog.WriteLogFile("", "序?" + j + ",?束");
            }
        }

        private void duoxiand(object dqind)
        {
            int a = (int)dqind;
            duoxianxunhuan("d", a,200);
            return;
        }

        
        /// <summary>
        /// ??雷?多?器 ?除模?器 建文件? 复制模?器
        /// </summary>
        /// <param name="a_b"></param>
        private void qdinit(string a_b) {
            if (WriteLog.getMachineName().ToLower().Equals("wlzhongkong"))
            {
                a_b = "d";
            }
            else {
                a_b = "c";
            }
            MyFuncUtil.createDirIfNotExist(a_b);
            MyLdcmd.ClearAndCopySimulator(a_b);
            //MyLdcmd.RunDuokaiqi(a_b);
        }

        private void duoxianxunhuan(string a_b, int dqinx,int xhcishu)
        {
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd(a_b, out dizhi, out path, out seed);
            if (dqinx <= -1)
            {
                return;
            }
            WriteLog.WriteLogFile(dqinx + "", "准?操作" + dqinx + "?模?器");            
            var cishu = 0;
            for (int cs = 0; cs < xhcishu; cs++)
            {
                var ks = MyFuncUtil.GetTimestamp();
                Thread.Sleep(2000);
                WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + "?入到循??中，thread:" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
                bool temp=MyFuncUtil.myQuit(dqinx, dizhi);
                if (!temp)
                {
                    WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + "??失?");
                    Thread.Sleep(20000);
                    continue;
                }
                WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + "复原");
                MyLdcmd.myRestore(dqinx, seed, dizhi);
                WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + "改名");
                MyLdcmd.myRename(dqinx, "雷" + dqinx + "-" + cishu, dizhi);
                temp=MyFuncUtil.Launch(dqinx, dizhi);
                if (!temp) {
                    WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + "打?失?");
                    Thread.Sleep(20000);
                    continue;
                }
                Thread.Sleep(20000);
                apkName = dict["境界"];
                int i = MyFuncUtil.QiDongWanChengLurenzhanghao(a_b, dqinx, apkName);
                if (i == -1)
                {
                    WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + "打?app" + apkName + "失?");
                    Thread.Sleep(20000);
                    continue;
                }
                int w = -1, h = -1;
                MyFuncUtil.getWindowSize(dqinx, out w, out h);
                if (w != -1 && h != -1 && w < h)
                {
                    WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + "w h不?" + w + " " + h);
                    Thread.Sleep(20000);
                    continue;
                }
                Thread.Sleep(20000);
                MyFuncJingNoTai mno = new MyFuncJingNoTai();
                temp = mno.lurenResizeOk(dqinx);
                if (temp == false)
                {
                    WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + ",resize?成功");
                    continue;
                }
                WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + "降低cpu");
                MyLdcmd.myDownCpu(dqinx, 50);
                Thread.Sleep(1000 * 10); 
                myDm dm = new myDm();
                Jingjie yq = new Jingjie(dm, dqinx, dizhi);
                string name = "";
                tmpBool = yq.denglu(15,out name);
                if (!tmpBool)
                {
                    WriteLog.WriteLogFile(dqinx + "", "登???出?");
                    Thread.Sleep(1000 * 60 * 3);
                    continue;
                }                
                yq.zhuxian(name);
                //Thread.Sleep(1000 * 60*60);//停住1小?
                cishu++;
                var js = MyFuncUtil.GetTimestamp();
                WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + "循?" + cishu + "次?");
                WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + "循?1次耗?" + MyFuncUtil.SecondToHour(js - ks));
            }
        }

        private void oldquanqd() {
            apkName = dict["明日方舟"];
            int[] yunxingIndex = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            string a_b = "d";
            qdinit(a_b);
            for (int j = 1; j < 1000; j++)
            {
                WriteLog.WriteLogFile("", "序?" + j + ",?始");
                MyFuncUtil.LaunchAll(yunxingIndex.Length);
                Thread.Sleep(10000);
                List<int> newinx = new List<int>();
                foreach (int myinx in yunxingIndex)
                {
                    int i = MyFuncUtil.QiDongWanChengInx(a_b, myinx, apkName);
                    if (i != -1)
                    {
                        newinx.Add(i);
                    }
                    Thread.Sleep(3000);
                }
                MyLdcmd.mySort(a_b);
                Thread.Sleep(2000);
                ThreadPool.SetMaxThreads(newinx.Count, newinx.Count); //?置最大?程?
                foreach (int inx in newinx)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(duoxiand), inx);//?程池指定?程?行Auto方法
                    Thread.Sleep(20000);
                }

                while (true)
                {
                    Thread.Sleep(10000);//?句??，主要是?必要循?那么多次。去掉也可以。
                    int maxWorkerThreads, workerThreads;
                    int portThreads;
                    ThreadPool.GetMaxThreads(out maxWorkerThreads, out portThreads);
                    ThreadPool.GetAvailableThreads(out workerThreads, out portThreads);
                    if (maxWorkerThreads - workerThreads == 0)
                    {
                        break;
                    }
                }

                WriteLog.WriteLogFile("", "序?" + j + ",?束");
            }
        }

        private void duoxian(string a_b, int dqinx)
        {
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd(a_b, out dizhi, out path, out seed);
            //MyLdcmd.mySort(dizhi);
            Thread.Sleep(2000);
            WriteLog.WriteLogFile(dqinx + "", "模?器" + dqinx + "?入到循??中");
            /*var r = MyFuncUtil.Launch(a, dizhi);
            if (r == 0)
            {
                WriteLog.WriteLogFile(a + "", "模?器" + a + "打?失?");
                Thread.Sleep(20000);
                return;
            }
            Thread.Sleep(20000);*/
            myDm dm = new myDm();
            lock (dm)
            {
                MingRi_Sort mr = new MingRi_Sort(dm, dqinx, dizhi);
                //登? 要下?文件 ?定十分? ??start按??立刻跳出
                tmpBool = mr.denglu(10);
                if (!tmpBool)
                {
                    tmpBoolString.Append("登???出?");
                    return;
                }
                tmpBool = mr.zhuce(3);
                if (!tmpBool)
                {
                    tmpBoolString.Append("注???出?");
                    return;
                }
                string bmpname = dqinx + "_" + dm.GetTime();
                mr.zhuxian();
                Thread.Sleep(10000);
                int rg = mr.ganyuan_jietu();
                if (rg != -1)
                {
                    Thread.Sleep(10000);
                    MyLdcmd.myScreencap(dqinx, path + bmpname + ".png", dizhi);
                    Thread.Sleep(20000);
                    if (dm.IsFileExist(path + bmpname + ".png") == 1)
                    {
                        string abc = mr.generalBasicDemo(dqinx, path + bmpname + ".png");
                        WriteLog.WriteLogFile(dqinx + "", abc + " " + abc.Length);
                        MyFuncUtil.MyRestore(dqinx, abc, a_b);
                        if (abc.Length <= 0)
                        {
                            dm.DeleteFile(path + bmpname + ".png");
                        }
                    }
                }
            }
        }

        
        private void mydo()
        {
            int i = 0;
            while (true)
            {
                i++;
                //continue;//??的死循?
                if (i == 3)
                {
                    continue;//一直循?，循?的是最里面的if判?！不是while，一般??入死循?
                }
                if (i == 21)
                {
                    return;//跟return一?，?束方法体，后面代?全部不再?行直接返回
                }
                if (i == 9)
                {
                    break;//跟return一?，?束方法体，后面代?全部不再?行直接返回
                }                
                WriteLog.WriteLogFile("",i+"");
            }
        }

        private void duoxiancheng_Click(object sender, EventArgs e)
        {
            var ks = MyFuncUtil.GetTimestamp();
            Thread.Sleep(2000);
            MyFuncUtil.mylogandxianshi("系??始初始化,做好种子");
            MyFuncUtil.createDirIfNotExist("d");
            MyLdcmd.ClearAndCopySimulator("d");
            var js = MyFuncUtil.GetTimestamp();
            MyFuncUtil.mylogandxianshi("初始化完?,耗?" + MyFuncUtil.SecondToHour(js - ks));
        }

        private void resizebutton_Click(object sender, EventArgs e)
        {
            quanjubutton = 1;
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd("d", out dizhi, out path, out seed);
            int dqinx = int.Parse(this.textBox1.Text);
            int jubing = MyLdcmd.getDqmoniqiJuBingByIndex(dqinx, dizhi);
            int width = -1, height = -1;
            MyFuncJingNoTai mno = new MyFuncJingNoTai();
            mno.myReSize(dqinx, out width, out height);
        }

        private void gaotupian_Click(object sender, EventArgs e)
        {
            quanjubutton = 1;
            MyFuncUtil.mylogandxianshi("系??始??Pic?片");
            var ks = MyFuncUtil.GetTimestamp();
            string mydir1 = @"d:\pic1\";
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd("d", out dizhi, out path, out seed);
            myDm dm = new myDm();
            Jingjie yq = new Jingjie(dm, 1, dizhi);
            Bitmap f = null;
            System.IO.DirectoryInfo TheFolder = new System.IO.DirectoryInfo(mydir1);
            int i = 1;
            foreach (System.IO.FileInfo myfile in TheFolder.GetFiles())
            {
                MyFuncUtil.mylogandxianshi("?前第"+i+"?文件");
                f = MyFuncUtil.ReadImageFile(mydir1 + "//" + myfile);
                if (f != null)
                {
                    long temp = MyFuncUtil.GetTimestamp();
                    Bitmap g = MyFuncUtil.KiCut(f, 331, 191, 888, 405);
                    g.Save(@"C:\mypic_save\" + temp + ".jpg");
                    g.Dispose();
                    MyFuncUtil.mylogandxianshi(@"C:\mypic_save\" + temp + ".jpg");
                    if (System.IO.File.Exists(@"C:\mypic_save\" + temp + ".jpg"))
                    {
                        List<string> rs = yq.generalBaiduShibie(1, @"C:\mypic_save\" + temp + ".jpg");
                        if (rs != null && rs.Count > 0)
                        {
                            string zhanghao = "", pwd = "";
                            foreach (string r in rs)
                            {
                                if (r.IndexOf("??") >= 0 && r.Substring(r.IndexOf("??")).Length > 2)
                                {
                                    zhanghao = r.Substring(r.IndexOf("??")+2).Trim().ToLower();
                                }
                                if (r.IndexOf("密?") >= 0 && r.Substring(r.IndexOf("密?")).Length > 2)
                                {
                                    pwd = r.Substring(r.IndexOf("密?")+2).Trim().ToLower();
                                }                                
                            }
                            if (zhanghao != "" && pwd != "")
                            {
                                ZhangHao zh = new ZhangHao();
                                zh.lurenSaveNameAndPas(zhanghao, pwd, 1);
                            }
                        }
                    }
                }
                i++;
            }
            
            
            var js = MyFuncUtil.GetTimestamp();
            MyFuncUtil.mylogandxianshi("初始化完?,耗?" + MyFuncUtil.SecondToHour(js - ks));
        }

        private void chongfusandian_Click(object sender, EventArgs e)
        {
            quanjubutton = 1;
            WriteLog.WriteLogFile("", "???始");
            List<string> a = Jingjie_SanDian.GetObject().findListShiFouChongMing();
            foreach (string f in a)
            {
                WriteLog.WriteLogFile("",f);
            }

            WriteLog.WriteLogFile("", "???束");
        }

        

        
    }
}
