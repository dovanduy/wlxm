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

namespace wlxm
{
    public partial class Form1_mr : Form
    {
        /// <summary>
        /// 辅助的版本
        /// </summary>
        private static int fuzhuBanben =24;
        
        /// <summary>
        /// dict 游戏名称和包名存储
        /// </summary>
        private Dictionary<string, string> dict = new Dictionary<string, string>();
        /// <summary>
        /// 启动游戏的包名和架构名
        /// </summary>
        private string apkName = null;
        /// <summary>
        /// 得到当前模拟器的index
        /// </summary>
        private int dqindex = -1;
        /// <summary>
        /// 出错提示
        /// </summary>
        private Boolean tmpBool = false;
        /// <summary>
        /// 出错信息
        /// </summary>
        private StringBuilder tmpBoolString = new StringBuilder();
        /// <summary>
        /// 多线程 线程锁
        /// </summary>
        //private object locker = new object();
        /// <summary>
        /// 主线程 定时显示运行时间
        /// </summary>
        private Thread thread;
        private delegate void changeText(string result);
        /// <summary>
        /// 设置倒计时时间
        /// </summary>
        //private int DaoJiShi = 180;
        //private int jishi;
        //private Boolean jishibl = true;
        private static readonly object obj = new object();
        
        private void initPackageName()
        {
            dict.Add("明日方舟", "com.hypergryph.arknights/com.u8.sdk.U8UnityContext");
            this.label1.Text = "当前版本:" + fuzhuBanben;
            this.label3.Text = "当前游戏:" + "明日方舟";
            this.label3.ForeColor = Color.Red;

        }
        public void Form1()
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
            var i = 1;
            while (true)
            {
                Thread.Sleep(1000);
                var js = MyFuncUtil.GetTimestamp();
                i++;
                //MyFuncUtil.SecondToHour(+i + (js - ks) / 1000+" "
                CalcFinished("程序已运行:" + MyFuncUtil.SecondToHour(js - ks) );
                this.label2.ForeColor = Color.Red;
                if (1!=1)
                {
                    //break;
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


        private void quanliucheng_Click(object sender, EventArgs e)
        {

            dqindex = 0;
            apkName = dict["明日方舟"];
            ThreadStart threadStart = new ThreadStart(danxian);//通过ThreadStart委托告诉子线程执行什么方法　
            Thread thread = new Thread(threadStart);
            thread.Start();
        }
        private void danxian()
        {
            int a = (int)dqindex;
            string a_b = "d";
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd(a_b, out dizhi, out path, out seed);
            //while (true)
            {
                WriteLog.WriteLogFile(a + "", "模拟器" + a + "进入到循环当中");
                /*var r = MyFuncUtil.Launch(a, dizhi);
                if (r == 0)
                {
                    WriteLog.WriteLogFile(a + "", "模拟器" + a + "打开失败");
                    Thread.Sleep(20000);
                    return;
                }
                Thread.Sleep(20000);*/
                int dqinx = a;
                myDm dm = new myDm();
                lock (dm)
                {
                    MingRi_Sort mr = new MingRi_Sort(dm, dqinx, dizhi);
                    string bmpname = a + "_" + dm.GetTime();
                    mr.ceshi();
                }
            }
        }

        
        private void ceshi_button_Click(object sender, EventArgs e)
        {
            apkName = dict["明日方舟"];
            int[] yunxingIndex = new int[] { 1,  2,11};
            //MyFuncUtil.createDirIfNotExist("C");
            /*foreach (int a in yunxingIndex)
            {
                ParameterizedThreadStart threadStart = new ParameterizedThreadStart(duoxianc);//通过ThreadStart委托告诉子线程执行什么方法　
                Thread thread = new Thread(threadStart);
                thread.Start(a);
                Thread.Sleep(60000);
            }*/
            string dizhi = null;
            string path = null;
            string seed = null;
            string a_b = "d";
            MyFuncUtil.myqiehuancd(a_b, out dizhi, out path, out seed);
            MyFuncUtil.mylogandxianshi("准备多线程测试");
            for (int j = 0; j < 5; j++)
            {
                MyFuncUtil.mylogandxianshi("序号" + j + ",开始");
                //MyLdcmd.ClearAndCopySimulator("d");
                //打开多开器
                //MyLdcmd.RunDuokaiqi("d");
                
                /*List<int> newinx = new List<int>();
                foreach (int myinx in yunxingIndex)
                {
                    int i=MyFuncUtil.QiDongWanChengInx("d", myinx, apkName);
                    if (i != -1) {
                        newinx.Add(i);
                    }
                    Thread.Sleep(3000);
                }*/
                
                ThreadPool.SetMaxThreads(yunxingIndex.Length, yunxingIndex.Length); //设置最大线程数
                foreach (int inx in yunxingIndex)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(duoxian_cs), inx);//线程池指定线程执行Auto方法
                    Thread.Sleep(1000);
                }
                long ks = MyFuncUtil.GetTimestamp();
                var xs = false;
                while (true)
                {
                    Thread.Sleep(1000);//这句写着，主要是没必要循环那么多次。去掉也可以。
                    int maxWorkerThreads, workerThreads;
                    int portThreads;
                    ThreadPool.GetMaxThreads(out maxWorkerThreads, out portThreads);
                    ThreadPool.GetAvailableThreads(out workerThreads, out portThreads);
                    if (maxWorkerThreads - workerThreads == 0)
                    {
                        Console.WriteLine("结束了");
                        break;
                    }
                    long js = MyFuncUtil.GetTimestamp();
                    if ((js - ks) > 1000 * 60 * 10) {
                        xs = true;
                    }
                    if (xs) {
                        MyFuncUtil.mylogandxianshi("当前工作线程数" + workerThreads);
                        xs = false;
                        ks = MyFuncUtil.GetTimestamp();
                    }
                }
                MyFuncUtil.mylogandxianshi( "序号" + j + ",结束");
            }
        }

        private void duoxian_cs(object dqind)
        {
            int a = (int)dqind;
            string a_b = "d";
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd(a_b, out dizhi, out path, out seed);
            MyFuncUtil.mylogandxianshi("准备打开模拟器" + a);
            MyLdcmd.myRestore(a, seed,dizhi);
            Thread.Sleep(5000);
            MyFuncUtil.mylogandxianshi("模拟器" + a + "打开结束");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyFuncUtil.mylogandxianshi("开始测试");
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd("d", out dizhi, out path, out seed);

            MyFuncUtil.panduanqidong(7,"d");
            
        }

        
        
        private void duoxiancheng_Click(object sender, EventArgs e)
        {
            apkName = dict["明日方舟"];
            int[] yunxingIndex = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string a_b = "c";            
            qdinit(a_b);
            for (int j = 1; j < 1000; j++)
            {
                WriteLog.WriteLogFile("", "序号" + j + ",开始");
                Thread.Sleep(2000);
                ThreadPool.SetMaxThreads(yunxingIndex.Length, yunxingIndex.Length); //设置最大线程数
                foreach (int inx in yunxingIndex)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(duoxianc), inx);//线程池指定线程执行Auto方法
                    Thread.Sleep(20000);
                }
                var ks = MyFuncUtil.GetTimestamp();
                var xs = false;
                while (true)
                {
                    Thread.Sleep(10000);//这句写着，主要是没必要循环那么多次。去掉也可以。
                    int maxWorkerThreads, workerThreads;
                    int portThreads;
                    ThreadPool.GetMaxThreads(out maxWorkerThreads, out portThreads);
                    ThreadPool.GetAvailableThreads(out workerThreads, out portThreads);
                    if (maxWorkerThreads - workerThreads == 0)
                    {
                        break;
                    }
                    var js = MyFuncUtil.GetTimestamp();
                    if ((js - ks) > 1000 * 60 * 10)
                    {
                        xs = true;
                    }
                    if (xs)
                    {
                        MyFuncUtil.mylogandxianshi("当前工作线程数" + workerThreads);
                        xs = false;
                        ks = MyFuncUtil.GetTimestamp();
                    }
                }

                WriteLog.WriteLogFile("", "序号" + j + ",结束");
            }
        }

        private void duoxianc(object dqind)
        {
            int a = (int)dqind;
            duoxianxunhuan("c", a,20);
            return;
        }
        private void dpanduoxiancheng_Click(object sender, EventArgs e)
        {
            apkName = dict["明日方舟"];
            int[] yunxingIndex = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9,10,11,12,13,14,15 };
            string a_b = "d";            
            qdinit(a_b);
            for (int j = 1; j < 1000; j++)
            {
                WriteLog.WriteLogFile("", "序号" + j + ",开始");
                Thread.Sleep(2000);
                ThreadPool.SetMaxThreads(yunxingIndex.Length, yunxingIndex.Length); //设置最大线程数
                foreach (int inx in yunxingIndex)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(duoxiand), inx);//线程池指定线程执行Auto方法
                    Thread.Sleep(20000);
                }
                var ks = MyFuncUtil.GetTimestamp();
                var xs = false;
                while (true)
                {
                    Thread.Sleep(10000);//这句写着，主要是没必要循环那么多次。去掉也可以。
                    int maxWorkerThreads, workerThreads;
                    int portThreads;
                    ThreadPool.GetMaxThreads(out maxWorkerThreads, out portThreads);
                    ThreadPool.GetAvailableThreads(out workerThreads, out portThreads);
                    if (maxWorkerThreads - workerThreads == 0)
                    {
                        break;
                    }
                    var js = MyFuncUtil.GetTimestamp();
                    if ((js - ks) > 1000 * 60 * 10)
                    {
                        xs = true;
                    }
                    if (xs)
                    {
                        MyFuncUtil.mylogandxianshi("当前工作线程数" + workerThreads);
                        xs = false;
                        ks = MyFuncUtil.GetTimestamp();
                    }
                }

                WriteLog.WriteLogFile("", "序号" + j + ",结束");
            }
            /*foreach (int a in yunxingIndex)
            {
                ParameterizedThreadStart threadStart = new ParameterizedThreadStart(duoxiand);//通过ThreadStart委托告诉子线程执行什么方法　
                Thread thread = new Thread(threadStart);
                thread.Start(a);
                Thread.Sleep(60000);
                if (a > 9)
                {
                    Thread.Sleep(120000);
                }
            }*/
            
        }

        private void duoxiand(object dqind)
        {
            int a = (int)dqind;
            duoxianxunhuan("d", a,20);
            return;
        }

        

        private void qdinit(string a_b) {
            //MyFuncUtil.createDirIfNotExist(a_b);
            //MyLdcmd.ClearAndCopySimulator(a_b);
            MyLdcmd.RunDuokaiqi(a_b);
        }

        private void duoxianxunhuan(string a_b, int dqinx,int xhcishu)
        {
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd(a_b, out dizhi, out path, out seed);
            //MyLdcmd.mySort(dizhi);
            var cishu = 0;
            var cgcishu = 0;
            for (int cs = 0; cs < xhcishu; cs++)
            {
                var ks = MyFuncUtil.GetTimestamp();
                Thread.Sleep(2000);
                MyFuncUtil.mylogandxianshi("模拟器" + dqinx + "进入到循环当中");
                Thread.Sleep(1000);
                bool temp=MyFuncUtil.myQuit(dqinx, dizhi);
                if (!temp)
                {
                    MyFuncUtil.mylogandxianshi("模拟器" + dqinx + "关闭失败");
                    Thread.Sleep(20000);
                    continue;
                }
                MyFuncUtil.mylogandxianshi("模拟器" + dqinx +"复原");
                MyLdcmd.myRestore(dqinx, seed, dizhi);
                MyFuncUtil.mylogandxianshi("模拟器" + dqinx + "改名");
                MyLdcmd.myRename(dqinx, "雷" + dqinx + "-" + cgcishu, dizhi);
                temp=MyFuncUtil.Launch(dqinx, dizhi);
                if (!temp) {
                    MyFuncUtil.mylogandxianshi("模拟器" + dqinx + "打开失败");
                    Thread.Sleep(20000);
                    continue;
                }
                int i = MyFuncUtil.QiDongWanChengInx(a_b, dqinx, apkName);
                if (i == -1)
                {
                    MyFuncUtil.mylogandxianshi("模拟器" + dqinx + "打开app" + apkName + "失败");
                    Thread.Sleep(20000);
                    continue;
                }
                MyLdcmd.mySort(a_b);
                //Thread.Sleep(2000 * 60 * 200);
                //lock (obj)
                {
                    myDm dm = new myDm();
                    MingRi_Sort mr = new MingRi_Sort(dm, dqinx, dizhi);
                    //登录 要下载文件 暂定十分钟 发现start按钮则立刻跳出
                    tmpBool = mr.denglu(10);
                    if (!tmpBool)
                    {
                        tmpBoolString.Append("登录环节出错");
                        return;
                    }
                    tmpBool = mr.zhuce(3);
                    if (!tmpBool)
                    {
                        tmpBoolString.Append("注册环节出错");
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
                            if (abc.Length > 0) {
                                cgcishu++;
                            }else
                            {
                                dm.DeleteFile(path + bmpname + ".png");
                            }
                        }
                    }
                    cishu++;
                    var js = MyFuncUtil.GetTimestamp();
                    MyFuncUtil.mylogandxianshi("模拟器" + dqinx + "循环"+cishu+"次数");
                    MyFuncUtil.mylogandxianshi("模拟器" + dqinx + "循环1次耗时"+MyFuncUtil.SecondToHour(js-ks));
                }
            }
        }

        private void oldquanqd() {
            apkName = dict["明日方舟"];
            int[] yunxingIndex = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            string a_b = "d";
            qdinit(a_b);
            for (int j = 1; j < 1000; j++)
            {
                WriteLog.WriteLogFile("", "序号" + j + ",开始");
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
                ThreadPool.SetMaxThreads(newinx.Count, newinx.Count); //设置最大线程数
                foreach (int inx in newinx)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(duoxiand), inx);//线程池指定线程执行Auto方法
                    Thread.Sleep(20000);
                }

                while (true)
                {
                    Thread.Sleep(10000);//这句写着，主要是没必要循环那么多次。去掉也可以。
                    int maxWorkerThreads, workerThreads;
                    int portThreads;
                    ThreadPool.GetMaxThreads(out maxWorkerThreads, out portThreads);
                    ThreadPool.GetAvailableThreads(out workerThreads, out portThreads);
                    if (maxWorkerThreads - workerThreads == 0)
                    {
                        break;
                    }
                }

                WriteLog.WriteLogFile("", "序号" + j + ",结束");
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
            WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "进入到循环当中");
            /*var r = MyFuncUtil.Launch(a, dizhi);
            if (r == 0)
            {
                WriteLog.WriteLogFile(a + "", "模拟器" + a + "打开失败");
                Thread.Sleep(20000);
                return;
            }
            Thread.Sleep(20000);*/
            myDm dm = new myDm();
            lock (dm)
            {
                MingRi_Sort mr = new MingRi_Sort(dm, dqinx, dizhi);
                //登录 要下载文件 暂定十分钟 发现start按钮则立刻跳出
                tmpBool = mr.denglu(10);
                if (!tmpBool)
                {
                    tmpBoolString.Append("登录环节出错");
                    return;
                }
                tmpBool = mr.zhuce(3);
                if (!tmpBool)
                {
                    tmpBoolString.Append("注册环节出错");
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
                //continue;//绝对的死循环
                if (i == 3)
                {
                    continue;//一直循环，循环的是最里面的if判断！不是while，一般会进入死循环
                }
                if (i == 21)
                {
                    return;//跟return一样，结束方法体，后面代码全部不再执行直接返回
                }
                if (i == 9)
                {
                    break;//跟return一样，结束方法体，后面代码全部不再执行直接返回
                }                
                WriteLog.WriteLogFile("",i+"");
            }
        }

        
    }
}
