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
using System.Xml;

namespace wlxm
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 辅助的版本
        /// </summary>
        //private static int fuzhuBanben = 1;

        private static string fuzhuyouxi = JiuYouZhuCe.DangQianYouXi;
        
        /// <summary>
        /// 全局button 点了就不自动运行
        /// </summary>
        private static int quanjubutton = 0;

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
        //private int dqindex = -1;
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
        /// 主线程 定时显示运行时间 自动更新游戏情况
        /// </summary>
        private Thread thread;
        private delegate void changeText(string result);
        private delegate void getduokaiqi();

        private Thread zidongthread;
        /// <summary>
        /// 设置倒计时时间
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
        /// 记录多线程的线程ID
        /// </summary>
        private List<Thread> list_xc = new List<Thread>();
        /// <summary>
        /// 单例模式变量
        /// </summary>
        private static readonly object obj = new object();


        /// <summary>
        /// 多个游戏的保存
        /// </summary>
        private List<YouXiEntity> myyouxi = new List<YouXiEntity>();

        

        private void initPackageName()
        {
            dict.Add("明日方舟", "com.hypergryph.arknights/com.u8.sdk.U8UnityContext");
            dict.Add("一拳超人", "com.playcrab.kos.gw/org.cocos2dx.lua.AppActivity");
            dict.Add("路人超能", "com.idreamsky.psycho100/com.yinghuochong.unity_entry.CustomUnityPlayerActivity");
            dict.Add("境界", "com.wk.jingjie.ewan/cn.ewan.supersdk.activity.SplashActivity");
            dict.Add("境界官方","com.ourpalm.bleach.gw/com.ourpalm.gamesdk.MainActivity");
            dict.Add("IPtool", "com.ddm.iptools/com.ddm.iptools.ui.MainActivity");
            this.label3.Text = "当前游戏:" + fuzhuyouxi;
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
            this.label24.Visible = false;
            XmlDocument xmlDoc2 = new XmlDocument();
            xmlDoc2.Load(Application.StartupPath + "\\" + "update.xml");
            XmlNode list = xmlDoc2.SelectSingleNode("Update");
            foreach (XmlNode node in list)
            {
                if (node.Name == "Soft" && node.Attributes["Name"].Value.ToLower() == "ExceTransforCsv".ToLower())
                {
                    foreach (XmlNode xml in node)
                    {
                        if (xml.Name == "Verson")
                        {
                           this.Text = "游戏辅助,版本" + xml.InnerText;
                        }
                    }
                }
            }
            YouXiEntity yx = new YouXiEntity("一拳超人", "yiquan", "1.0.0.0", "主线", "com.playcrab.kos.gw/org.cocos2dx.lua.AppActivity", "package:com.playcrab.kos.gw", "", "YiQuanXin", "YiQuanXin");
            myyouxi.Add(yx);
            yx = new YouXiEntity("九游注册", "jiuyouzhuce", "1.0.0.0", "注册", "cn.ninegame.gamemanager/cn.ninegame.gamemanager.activity.MainActivity", "package:cn.ninegame.gamemanager", @"C:\迅雷下载\109_01292442093833704133b4b27b3d6149.apk", "JiuYou", "JiuYou");
            myyouxi.Add(yx);            
            this.comboBox1.DataSource = myyouxi;
            this.comboBox1.DisplayMember = "youxiname";
            this.comboBox1.ValueMember = "youxiname";
            YouXiEntity myy = myyouxi.Find(ob => ob.Youxiname == this.comboBox1.SelectedValue.ToString());
            if (myy != null)
            {
                this.label1.Text = myy.Version.ToString();
                this.label17.Text = myy.Zidong;
            }
            //ZhangHao zh = new ZhangHao();
            //List<ZhangHaoEntity> myzhanghaolist=zh.getZhangHaoList("yiquan");
            //this.dataGridView1.DataSource = myzhanghaolist;
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
                int daojishi = 60*3;
                //MyFuncUtil.SecondToHour(+i + (js - ks) / 1000+" "
                CalcFinished("程序已运行:" + MyFuncUtil.SecondToHour(js - ks) + zidong);
                this.label2.ForeColor = Color.Red;
                if (quanjubutton == 0 && yici == 0 && (js - ks) > 1000 * 10 && (js - ks) <= 1000 * daojishi)
                {
                    WriteLog.WriteLogFile("", "程序搞自动倒计时 " + (daojishi - (js - ks) / 1000) + "秒");
                }
                if (quanjubutton == 0 && yici == 0 && (js - ks) > 1000 * daojishi)
                {
                    quanjubutton = 1;
                    yici = 1;
                    //dpanduoxiancheng.PerformClick();
                    zidong = ",自动运行中";
                    if (WriteLog.getMachineName().ToUpper().Equals("2HAO"))
                    {
                        //gaozhanghaotou duoxianzongtou
                        ThreadStart threadStart = new ThreadStart(gaozhanghaotou);//通过ThreadStart委托告诉子线程执行什么方法　
                        this.zidongthread = new Thread(threadStart);
                        this.zidongthread.Name = "wodegaozhanghao";
                        this.zidongthread.Start();
                    }
                    else
                    {
                        ThreadStart threadStart = new ThreadStart(gaozhanghaotou);//通过ThreadStart委托告诉子线程执行什么方法　
                        this.zidongthread = new Thread(threadStart);
                        this.zidongthread.Name = "wodedpanduoxian";
                        this.zidongthread.Start();
                    }
                }
                //每隔一小时由zk更新一次 测试时 每隔1分钟
                if (WriteLog.getMachineName().ToUpper().Equals("WLZHONGKONG") && (js - ks_gxyunxing) > 1000 * 60*20)
                {
                    WriteLog.WriteLogFile("", "准备更新运行情况");
                    ks_gxyunxing = MyFuncUtil.GetTimestamp();
                    ZhangHao zh = new ZhangHao();
                    DateTime dt=zh.getYunXingQkLasttime();
                    TimeSpan span = DateTime.Now.Subtract(dt);
                    //WriteLog.WriteLogFile("", "准备更新与上次统计相比,间隔 " + span.Minutes + "分钟");
                    if (span.Hours >= 1)
                    {
                        //WriteLog.WriteLogFile("", "与上次统计相比,间隔 " + span.Minutes + "分钟");
                        zh.gxYunXingQk("yiquan");
                    }
                }

                //每隔60分钟查看是否应该重启 测试时 每隔1分钟
                if ((js - ks_cqyunxing) > 1000 * 60 * 60)
                {
                    ks_cqyunxing = MyFuncUtil.GetTimestamp();
                    ZhangHao zh = new ZhangHao();
                    bool t = zh.panDuanChongQi(WriteLog.getMachineName());
                    if (t)
                    {
                        WriteLog.WriteLogFile("", "当前需要重启" + DateTime.Now);
                        //myDm dm = new myDm();
                        //dm.ExitOs(2);
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
            MyFuncUtil.mylogandxianshi("开始");
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd("d", out dizhi, out path, out seed);            
            int dqinx = int.Parse(this.textBox1.Text);
            int jubing = MyLdcmd.getDqmoniqiJuBingByIndex(dqinx, dizhi);
            int waicengjubing = MyLdcmd.getDqmoniqiWaiCengJuBingByIndex(dqinx,dizhi);
            MyFuncJingNoTai mno = new MyFuncJingNoTai();
            myDm mf = new myDm();
            int r = 0;
            if (jubing > 0)
            {
                r = mf.bindWindow(jubing);
            }
            //mno.myBianWeiZhi(dqinx);
            JiuYouZhuCe yq = new JiuYouZhuCe(mf, dqinx, jubing);
            //string name = "";
            //int xuanqu = -1, dengji = -1;
            //tmpBool = yq.zhuce("jiuyouzhuce", 20, out dengji, out xuanqu, ref name);            
            //更新ip
            ZhangHao zhanghao = new ZhangHao();
            //zhanghao.updateIp(dqinx, "jiuyouzhuce", name, "121.25.36");

            //apkName = myyouxi.Find(f => f.Youxiname == "九游注册").Apkname;
            //YouXiFactory yxf = new YouXiFactory();
            //int i = mno.QiDongWanChengGetZhiDingDian(dqin apkName, mf, jubing, yxf.CreateYouXiSanDian("jiuyouzhuce"), "注册-打开九游后第一界面");
            //BaiDuShiTu bdt = new BaiDuShiTu();
            //int getyzm = bdt.qushufrombaidu(mf, dqinx, jubing, 148, 378, 407, 428);
            string yiqu = "";
            bool t2 = mno.PanDuan_QidongByYiQuDian_IP(dqinx, 1000 * 60 * 5, mf, jubing, out yiqu);
            MyFuncUtil.mylogandxianshi("结束" + yiqu);
        }

        private void lrzh_Click(object sender, EventArgs e)
        {
            quanjubutton = 1;
            ThreadStart threadStart = new ThreadStart(gaozhanghaotou);//通过ThreadStart委托告诉子线程执行什么方法　
            Thread thread = new Thread(threadStart);
            thread.Name = "wodegaozhanghao";
            thread.Start();
        }

        private void gaozhanghaotou() {
            int[] yunxingIndex = null;
            if (WriteLog.getMachineName().ToLower().Equals("wlzhongkong"))
            {
                yunxingIndex = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, };//2, 3, 4, 5, 6, 7, 8, 9,10,11,12,13,14,15,16,17,18,19
            }
            else
            {
                yunxingIndex = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, };// 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,15
            }
            string a_b = "d";
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd(a_b, out dizhi, out path, out seed);
            //所有账号置为dengluzhong N 多个机器的话 会有麻烦
            //ZhangHao zh = new ZhangHao();
            //zh.zhiweidengluzhongN("jingjie", WriteLog.getMachineName());
            int xinzengmoniqi = 2;
            for (int j = 1; j < 1000; j++)
            {
                var ks = MyFuncUtil.GetTimestamp();
                WriteLog.WriteLogFile("", "序号" + j + ",开始搞账号");
                MyLdcmd.myQuitAll(dizhi);
                Thread.Sleep(2000);
                MyLdcmd.RunDuokaiqi(a_b);
                Thread.Sleep(2000);
                MyFuncUtil.duokaiqiRemoveAll();
                Thread.Sleep(2000);
                MyLdcmd.myRemoveAll(dizhi);
                Thread.Sleep(2000);
                MyLdcmd.RunDuokaiqi(a_b);
                Thread.Sleep(2000);
                MyFuncUtil.duokaiqiAdd(xinzengmoniqi);
                Thread.Sleep(2000);
                ThreadPool.SetMaxThreads(yunxingIndex.Length, yunxingIndex.Length); //设置最大线程数
                string[] getquanbujubing = MyLdcmd.getDqmoniqiJuBing();
                string[] getquanbuwaicengjubing = MyLdcmd.getDqmoniqiWaiCengJuBing();
                //搞出句柄来 放到每个线程开始里面 如果该句柄为0线程再去检索
                List<LeiDianCanShu> listleidian = new List<LeiDianCanShu>();
                foreach (int inx in yunxingIndex)
                {
                    int jubing = -1;
                    foreach (string s in getquanbujubing)
                    {
                        string[] b = s.Split('|');
                        int zt = int.Parse(b[1]);
                        int ind = int.Parse(b[0]);
                        if (inx == ind && zt != 1)
                        {

                            jubing = zt;
                        }
                    }
                    int waicengjubing = -1;
                    foreach (string s in getquanbuwaicengjubing)
                    {
                        string[] b = s.Split('|');
                        int zt = int.Parse(b[1]);
                        int ind = int.Parse(b[0]);
                        if (inx == ind && zt != 1)
                        {

                            waicengjubing = zt;
                        }
                    }
                    WriteLog.WriteLogFile("", "index:" + inx + ",jubing:" + jubing + ",waicengjubing:" + waicengjubing);
                    LeiDianCanShu ld = new LeiDianCanShu(inx, jubing,waicengjubing);
                    listleidian.Add(ld);
                }
                LeiDianCanShu[] myleiddian = listleidian.ToArray<LeiDianCanShu>();

                foreach (int inx in yunxingIndex)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(yiquancunzhanghao), listleidian.Find(sd => sd.Dqinx == inx));//线程池指定线程执行Auto方法
                    //Thread.Sleep(1000 * 40);
                }
                //var ks = MyFuncUtil.GetTimestamp();
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
                var js = MyFuncUtil.GetTimestamp();
                WriteLog.WriteLogFile("", "大循环1次耗时" + MyFuncUtil.SecondToHour(js - ks));
            }           
        }

        private void yiquancunzhanghao(object inx)
        {
            duoxianxunhuan_zhanghao("d", inx, 20);
            return;
        }

        private void duoxianxunhuan_zhanghao(string a_b, object dqind, int xhcishu)
        {
            LeiDianCanShu ld = (LeiDianCanShu)dqind;
            int dqinx = ld.Dqinx;
            int jubing = ld.Jubing;
            int waicengjubing = ld.WaiCengJuBing;
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd(a_b, out dizhi, out path, out seed);
            if (dqinx <= -1)
            {
                return;
            }
            WriteLog.WriteLogFile(dqinx + "", "准备操作" + dqinx + "号模拟器-搞账号");
            var cishu = 0;
            MyFuncJingNoTai mno = new MyFuncJingNoTai();
            bool temp = false;
            int chongqi = 0;
            string youxibaocun = myyouxi.Find(f => f.Youxiname == "九游注册").Youxibaocun;
            int ipbeizhan = 0;
            for (int ii = 0; ii < 1;ii++ )
            {
                /*进入操作模拟器循环中
                1.模拟器是不是开着
                2.开着就看有没有app
                3.有app就看是不是已进入
                4.模拟器没开着 打开 第一次 则restore
                5.模拟器开着 没有app 则关闭 restore
                6.先检测是不是有指定app 没有则关闭 restore
                7.有app 再看是不是开着
                 * */

                var ks = MyFuncUtil.GetTimestamp();
                var ks1 = MyFuncUtil.GetTimestamp();
                Thread.Sleep(2000);
                WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "进入到循环当中，thread:" + Thread.CurrentThread.ManagedThreadId + ",jubing" + jubing);
                Thread.Sleep(1000);               
                bool t = MyFuncUtil.isLaunch(dqinx);
                if (!t)
                {
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "改名");
                    MyLdcmd.myRename(dqinx, "雷" + dqinx + "-" + cishu, dizhi);
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "改属性");
                    MyLdcmd.modifySimulator(dqinx);
                    temp = MyFuncUtil.LaunchQiHao(dqinx, dizhi);
                    if (!temp)
                    {
                        WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "打开失败");
                        Thread.Sleep(20000);
                        continue;
                    }
                    Thread.Sleep(1000);
                    //MyLdcmd.installApp(dqinx, myyouxi.Find(f=>f.Youxiname=="九游注册").Apkinstall);
                    Thread.Sleep(1000 * 20); 
                    jubing = -1;//句柄要重新取
                    waicengjubing = -1;
                }
                var js = MyFuncUtil.GetTimestamp();
                WriteLog.WriteTeDingLog(dqinx + "", "模拟器" + dqinx + "打开耗时" + MyFuncUtil.SecondToHour(js - ks1));
                ks1 = MyFuncUtil.GetTimestamp();
                //开始改位置
                mno.myBianWeiZhi(dqinx);
                t = MyFuncUtil.lureninstallOk(dqinx, myyouxi.Find(f => f.Youxiname == "九游注册").Package, () =>
                {
                    WriteLog.WriteLogFile(dqinx + "", "安装app没成功--九游注册");
                    /*temp = mno.myQuit(dqinx, dizhi);
                    if (!temp)
                    {
                        WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "关闭失败");
                        Thread.Sleep(20000);
                        return;
                    }*/
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "开始安装");
                    //MyLdcmd.myRestore(dqinx, seed, dizhi);
                    MyLdcmd.installApp(dqinx, myyouxi.Find(f => f.Youxiname == "九游注册").Apkinstall);
                    /*
                    temp = mno.myQuit(dqinx, dizhi);
                    if (!temp)
                    {
                        WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "关闭失败");
                        Thread.Sleep(20000);
                        return;
                    }
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "改名");
                    MyLdcmd.myRename(dqinx, "雷" + dqinx + "-" + cishu, dizhi);
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "改属性");
                    MyLdcmd.modifySimulator(dqinx);
                    temp = MyFuncUtil.Launch(dqinx, dizhi);
                    if (!temp)
                    {
                        WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "打开失败");
                        Thread.Sleep(20000);
                        return;
                    }*/
                    Thread.Sleep(20*1000);
                    //jubing = -1;//句柄要重新取
                    //waicengjubing = -1;
                });
                js = MyFuncUtil.GetTimestamp();
                WriteLog.WriteTeDingLog(dqinx + "", "模拟器" + dqinx + "安装app耗时" + MyFuncUtil.SecondToHour(js - ks1));
                ks1 = MyFuncUtil.GetTimestamp();
                if (chongqi == 1)
                {
                    /*WriteLog.WriteLogFile(dqinx + "", "安装app没成功--九游注册");
                    temp = mno.myQuit(dqinx, dizhi);
                    if (!temp)
                    {
                        WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "关闭失败");
                        Thread.Sleep(20000);
                        continue;
                    }*/
                    //WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "开始安装");
                    //MyLdcmd.myRestore(dqinx, seed, dizhi);
                    //MyLdcmd.installApp(dqinx, myyouxi.Find(f => f.Youxiname == "九游注册").Apkinstall);
                    /*temp = mno.myQuit(dqinx, dizhi);
                     if (!temp)
                     {
                         WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "关闭失败");
                         Thread.Sleep(20000);
                         continue;
                     }
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "改名");
                    MyLdcmd.myRename(dqinx, "雷" + dqinx + "-" + cishu, dizhi);
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "改属性");
                    MyLdcmd.modifySimulator(dqinx);
                    temp = MyFuncUtil.LaunchQiHao(dqinx, dizhi);
                    if (!temp)
                    {
                        WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "打开失败");
                        Thread.Sleep(20000);
                        continue;
                    }
                    chongqi = 0;
                    Thread.Sleep(20*1000);
                    jubing = -1;//句柄要重新取
                    waicengjubing = -1;*/
                    //continue;
                }
                string ip = "请稍候";
                ZhangHao zhanghao = new ZhangHao();
                //if (WriteLog.getMachineName().ToLower().Equals("wlzhongkong"))
                {
                    mno.getIP(dqinx, dizhi, seed, jubing, waicengjubing, out ip);
                    if (ip != null && !"".Equals(ip) && ip.IndexOf("请") < 0 && !"1".Equals(ip))
                    {
                        //保存当前ip 看看碰到几次
                        bool yiyong = false;
                        zhanghao.saveipfirst(dqinx, ip, out yiyong);
                        if (yiyong)
                        {
                            WriteLog.WriteLogFile(dqinx + "", "ip:" + ip + "这个ip今天已经被用过");
                            continue;
                        }
                        t = zhanghao.panduanIpKeYong(dqinx, youxibaocun, ip);
                        if (t)
                        {
                            WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "ip已被占");
                            //MyLdcmd.myReboot(dqinx);
                            temp = mno.myQuit(dqinx, dizhi);
                            Thread.Sleep(1000 * 60 * 4);
                            ipbeizhan++;
                            jubing = -1;//句柄要重新取
                            waicengjubing = -1;
                            continue;
                        }
                    }
                }
                js = MyFuncUtil.GetTimestamp();
                WriteLog.WriteTeDingLog(dqinx + "", "模拟器" + dqinx + "检测ip耗时" + MyFuncUtil.SecondToHour(js - ks1));
                ks1 = MyFuncUtil.GetTimestamp();

                //窗口已打开 获取句柄
                if (jubing <= 0)
                {
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
                    continue;
                }
                
                string name = "";
                //zhanghao.generateNameAndPas(dqinx, 7, out name, out pwd);
                apkName = myyouxi.Find(f => f.Youxiname == "九游注册").Apkname;
                YouXiFactory yxf=new YouXiFactory();
                int i = mno.QiDongWanChengGetZhiDingDian(dqinx, apkName, dm, jubing, yxf.CreateYouXiSanDian(youxibaocun), "注册-打开九游后第一界面");
                if (i == -1)
                {
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "打开app" + apkName + "失败");
                    Thread.Sleep(20000);
                    continue;
                }
                js = MyFuncUtil.GetTimestamp();
                WriteLog.WriteTeDingLog(dqinx + "", "模拟器" + dqinx + "启动app耗时" + MyFuncUtil.SecondToHour(js - ks1));
                ks1 = MyFuncUtil.GetTimestamp();
                WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "开始尝试登录主线");
                JiuYouZhuCe yq = new JiuYouZhuCe(dm, dqinx, jubing);
                int xuanqu = -1, dengji = -1;
                tmpBool = yq.zhuce(youxibaocun,10, out dengji, out xuanqu, ref name);
                if (!tmpBool)
                {
                    WriteLog.WriteLogFile(dqinx + "", "注册环节出错");
                    Thread.Sleep(1000 * 60 * 3);
                    chongqi = 1;
                    continue;
                }
                //更新ip
                zhanghao.updateIp(dqinx, youxibaocun, name, ip);
                //yq.zhuxian_zhuceyong(name);
                //yq.quitdq(name);
                //Thread.Sleep(1000 * 60*60);//停住1小时
                js = MyFuncUtil.GetTimestamp();
                WriteLog.WriteTeDingLog(dqinx + "", "模拟器" + dqinx + "操作注册耗时" + MyFuncUtil.SecondToHour(js - ks1));
                ks1 = MyFuncUtil.GetTimestamp();
                //zhanghao.tuichusaveNameAndPas(name,dqinx, youxi,WriteLog.getMachineName(), -1, -1, -1);
                cishu++;
                // MyLdcmd.myReboot(dqinx);
                WriteLog.WriteLogFile(dqinx + "", "睡20s");
                Thread.Sleep(1000 * 20);
                jubing = -1;//句柄要重新取
                waicengjubing = -1;
                temp = mno.myQuit(dqinx, dizhi);
                if (!temp)
                {
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "关闭失败");
                    Thread.Sleep(20000);
                    continue;
                }             
                //zhanghao.zhiweidengluzhongN(dqinx, "yiquan", name, WriteLog.getMachineName());
                js = MyFuncUtil.GetTimestamp();
                WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "循环" + cishu + "次数");
                WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "循环1次耗时" + MyFuncUtil.SecondToHour(js - ks));
            }
        }

        private void duoxianxunhuan(string a_b, object leidian, int xhcishu)
        {
            LeiDianCanShu ld = (LeiDianCanShu)leidian;
            int dqinx = ld.Dqinx;
            int jubing = ld.Jubing;
            int waicengjubing = ld.WaiCengJuBing;
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd(a_b, out dizhi, out path, out seed);
            if (dqinx <= -1)
            {
                return;
            }
            WriteLog.WriteLogFile(dqinx + "", "准备操作" + dqinx + "号模拟器-搞主线");
            var cishu = 0;
            MyFuncJingNoTai mno = new MyFuncJingNoTai();
            bool temp = false;
            while (true)
            {
                /*进入操作模拟器循环中
                1.模拟器是不是开着
                2.开着就看有没有app
                3.有app就看是不是已进入
                4.模拟器没开着 打开 第一次 则restore
                5.模拟器开着 没有app 则关闭 restore
                6.先检测是不是有指定app 没有则关闭 restore
                7.有app 再看是不是开着
                 * */

                var ks = MyFuncUtil.GetTimestamp();
                Thread.Sleep(2000);
                WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "进入到循环当中，thread:" + Thread.CurrentThread.ManagedThreadId + ",jubing" + jubing);
                Thread.Sleep(1000);
                bool t = MyFuncUtil.isLaunch(dqinx);
                if (!t)
                {
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "改名");
                    MyLdcmd.myRename(dqinx, "雷" + dqinx + "-" + cishu, dizhi);
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "改属性");
                    MyLdcmd.modifySimulator(dqinx);
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "降低cpu");
                    MyLdcmd.myDownCpu(dqinx, 50);
                    temp = MyFuncUtil.Launch(dqinx, dizhi);
                    if (!temp)
                    {
                        WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "打开失败");
                        Thread.Sleep(20000);
                        continue;
                    }
                    jubing = -1;//句柄要重新取
                    waicengjubing = -1;
                    Thread.Sleep(20000);
                }
                t = MyFuncUtil.lureninstallOk(dqinx, "package:com.playcrab.kos.gw", () =>
                {
                    WriteLog.WriteLogFile(dqinx + "", "安装app没成功");
                    temp = mno.myQuit(dqinx, dizhi);
                    if (!temp)
                    {
                        WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "关闭失败");
                        Thread.Sleep(20000);
                        return;
                    }
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "复原");
                    MyLdcmd.myRestore(dqinx, seed, dizhi);
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "改名");
                    MyLdcmd.myRename(dqinx, "雷" + dqinx + "-" + cishu, dizhi);
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "降低cpu");
                    MyLdcmd.myDownCpu(dqinx, 50);
                    temp = MyFuncUtil.Launch(dqinx, dizhi);
                    if (!temp)
                    {
                        WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "打开失败");
                        Thread.Sleep(20000);
                        return;
                    }
                    jubing = -1;//句柄要重新取
                    waicengjubing = -1;
                    Thread.Sleep(20000);
                });
                if (t == false)
                {
                    WriteLog.WriteLogFile(dqinx + "", "安装app没成功");
                    temp = mno.myQuit(dqinx, dizhi);
                    if (!temp)
                    {
                        WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "关闭失败");
                        Thread.Sleep(20000);
                        continue;
                    }
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "复原");
                    MyLdcmd.myRestore(dqinx, seed, dizhi);
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "改名");
                    MyLdcmd.myRename(dqinx, "雷" + dqinx + "-" + cishu, dizhi);
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "改属性");
                    MyLdcmd.modifySimulator(dqinx);
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "降低cpu");
                    MyLdcmd.myDownCpu(dqinx, 50);
                    temp = MyFuncUtil.Launch(dqinx, dizhi);
                    if (!temp)
                    {
                        WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "打开失败");
                        Thread.Sleep(20000);
                        continue;
                    }
                    jubing = -1;//句柄要重新取
                    waicengjubing = -1;
                    Thread.Sleep(20000);
                    continue;
                }
                //窗口已打开 获取句柄
                if (jubing <= 0)
                {
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
                    continue;
                }
                string youxi = fuzhuyouxi;
                string ip = "1";
                ZhangHao zhanghao = new ZhangHao();
                int w = -1, h = -1;
                MyFuncUtil.getWindowSize(dqinx, out w, out h);
                if ((w != -1 && h != -1 && w < h) && WriteLog.getMachineName().ToLower().Equals("wlzhongkong"))
                {
                    mno.getIP(dqinx, dizhi, seed, jubing, waicengjubing, out ip);
                    if (ip != null && !"".Equals(ip) && ip.IndexOf("请") < 0 && !"1".Equals(ip))
                    {
                        t = zhanghao.panduanIpKeYong(dqinx, youxi, ip);
                        if (t)
                        {
                            WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "ip已被占");
                            MyLdcmd.myReboot(dqinx);
                            Thread.Sleep(1000 * 60 * 4);
                            jubing = -1;//句柄要重新取
                            waicengjubing = -1;
                            continue;
                        }
                    }
                }
                apkName = dict["一拳超人"];
                int i = MyFuncUtil.QiDongWanChengLurenzhanghao(a_b, dqinx, apkName);
                if (i == -1)
                {
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "打开app" + apkName + "失败");
                    Thread.Sleep(20000);
                    continue;
                }
                t = mno.PanDuan_QidongLurenzhanghao(dqinx, dm,waicengjubing);//根据窗口大小 和 是否有雷电游戏中心标志  判断是否启动了app
                temp = mno.PanDuan_QidongBySize(dqinx, waicengjubing, 1000 * 30, 601, 338);
                bool t2 = false;
                if (t && temp)
                {
                    Thread.Sleep(1000 * 50);
                    string yiqu = "";
                    t2 = mno.PanDuan_QidongByYiQuDian(dqinx, 1000 * 30, dm, jubing, out yiqu);
                    if (t2)
                    {
                        WriteLog.WriteLogFile(dqinx + "", "模拟器发现已取点" + yiqu);
                    }
                }
                WriteLog.WriteLogFile(dqinx + "", "t2 已取点判断:" + t2 + "t 路人账号判断:" + t + "temp Size判断:" + temp);
                if (!t2 || !t || !temp)
                {
                    if (i == -1)
                    {
                        i = MyFuncUtil.QiDongWanChengLurenzhanghao(a_b, dqinx, apkName);
                        if (i == -1)
                        {
                            WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "打开app" + apkName + "失败");
                            Thread.Sleep(20000);
                            continue;
                        }
                    }
                    w = -1;
                    h = -1;
                    MyFuncUtil.getWindowSize(dqinx, out w, out h);
                    if (w != -1 && h != -1 && w < h)
                    {
                        WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "w h不对" + w + " " + h);
                        Thread.Sleep(20000);
                        continue;
                    }
                    Thread.Sleep(20000);
                    temp = mno.lurenResizeOk(dqinx,"yiquan");
                    if (temp == false)
                    {
                        WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + ",resize没成功");
                        continue;
                    }
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "降低cpu");
                    MyLdcmd.myDownCpu(dqinx, 50);
                    Thread.Sleep(1000 * 10);
                }
                WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "app"+youxi+"已打开,开始搞登录和主线");
                YiQuan_Xin yq = new YiQuan_Xin(dm, dqinx, jubing, dizhi);
                string name = "";
                string pwd = "";
                string jieduan = "";
                int xuanqu = -1, dengji = -1;                
                zhanghao.zhunbeizhanghao(dqinx, youxi, out name, out pwd, out xuanqu, out dengji, out jieduan);
                if (name == null || name == "" || pwd == null || pwd == "")
                {
                    //当前没有找到需要练级的账号
                    WriteLog.WriteLogFile(dqinx + "", "当前没有找到需要练级的账号");
                    return;
                }
                tmpBool = yq.denglu(15, ref name, ref pwd,ref xuanqu);
                if (!tmpBool)
                {
                    WriteLog.WriteLogFile(dqinx + "", "登录环节出错");
                    Thread.Sleep(1000 * 60 * 3);
                    continue;
                }
                zhanghao.updateIp(dqinx, youxi, name, ip);
                yq.zhuxian(name, 1000 * 60 * 60 * 3);
                yq.quitdq(name);
                //Thread.Sleep(1000 * 60*60);//停住1小时
                zhanghao.tuichusaveNameAndPas(name, dqinx, youxi, WriteLog.getMachineName(), -1, -1, -1);               
                cishu++;
                jubing = -1;//句柄要重新取
                waicengjubing = -1;
                WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "改名");
                MyLdcmd.myRename(dqinx, "雷" + dqinx + "-" + cishu, dizhi);
                WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "改属性");
                MyLdcmd.modifySimulator(dqinx);
                WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "降低cpu");
                MyLdcmd.myDownCpu(dqinx, 50);
                WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "重新启动");
                MyLdcmd.myReboot(dqinx);
                Thread.Sleep(1000 * 60 * 4);
                bool cqcg = false;
                t = MyFuncUtil.isLaunch(dqinx);
                if (t)
                {
                    w = -1;
                    h = -1;
                    MyFuncUtil.getWindowSize(dqinx, out w, out h);
                    if (w != -1 && h != -1 && w < h)
                    {
                        WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "重启成功完成,w h分别为" + w + " " + h);
                        Thread.Sleep(1000);
                        cqcg = true;
                    }
                }
                if (!cqcg)
                {
                    WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "重启失败,强关");
                    temp = mno.myQuit(dqinx, dizhi);
                    if (!temp)
                    {
                        WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "关闭失败");
                        Thread.Sleep(20000);
                        return;
                    }
                }
                //zhanghao.zhiweidengluzhongN(dqinx, Jingjie.DANGQIAN_YOUXI, name, WriteLog.getMachineName());
                var js = MyFuncUtil.GetTimestamp();
                WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "循环" + cishu + "次数");
                WriteLog.WriteLogFile(dqinx + "", "模拟器" + dqinx + "循环1次耗时" + MyFuncUtil.SecondToHour(js - ks));
            }
        }

        private void quanliucheng_Click(object sender, EventArgs e)
        {
            quanjubutton = 1;
            ThreadStart threadStart = new ThreadStart(duoxianchengyiqudian);//通过ThreadStart委托告诉子线程执行什么方法　
            Thread thread = new Thread(threadStart);
            thread.Name = "wodeduoxianyiquandian";
            thread.Start();
            
        }

        private void duoxianchengyiqudian() {
            MyFuncUtil.mylogandxianshi("开始-已取点");
            int dqinx = int.Parse(this.textBox1.Text);
            int jubing = MyLdcmd.getDqmoniqiJuBingByIndex(dqinx);
            myDm mf = new myDm();
            int r = 0;
            if (jubing > 0)
            {
                r = mf.bindWindow(jubing);
            }
            for (int i = 0; i < 0; i++)
            {
                foreach (FuHeDuoDian f in YiQuan_DuoDian.List_yqfhduodian)
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
                foreach (FuHeSanDian f in JiuYou_SanDian.List_yqfhsandian)
                {
                    if (mf.mohuByLeiBool_duokai(f.Sd))
                    {
                        MyFuncUtil.mylogandxianshi(f.Name + "模糊取到YiQuan_SanDian");
                        //mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                        mf.mydelay(1000, 2000);
                    }
                    if (mf.jingqueByLeiBool_duokai(f.Sd))
                    {
                        MyFuncUtil.mylogandxianshi(f.Name + "精确取到YiQuan_SanDian");
                        mf.mydelay(1000, 2000);
                    }
                }
                mf.mydelay(10, 200);

            }
            MyFuncUtil.mylogandxianshi("结束-已取点");
        }
        
        private void dpanduoxiancheng_Click(object sender, EventArgs e)
        {
            quanjubutton = 1;
            ThreadStart threadStart = new ThreadStart(duoxianzongtou);//通过ThreadStart委托告诉子线程执行什么方法　
            Thread thread = new Thread(threadStart);
            thread.Name = "wodedpanduoxian";
            thread.Start();
            
        }

        private void duoxianzongtou() {
            int[] yunxingIndex = null;
            if (WriteLog.getMachineName().ToLower().Equals("wlzhongkong"))
            {
                yunxingIndex = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, };//, 6, 7, 8, 9,10,11,12,13,14,15,16,17,18,19
            }
            else
            {
                yunxingIndex = new int[] { 1};//,4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,15
            }
            string a_b = "d";
            //qdinit(a_b);
            //MyLdcmd.RunDuokaiqi(a_b);
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd(a_b, out dizhi, out path, out seed);
            //所有账号置为dengluzhong N 多个机器的话 会有麻烦
            //ZhangHao zh = new ZhangHao();
            //zh.zhiweidengluzhongN("jingjie", WriteLog.getMachineName());
            int xinzengmoniqi = 4;
            for (int j = 1; j < 1000; j++)
            {
                WriteLog.WriteLogFile("", "序号" + j + ",开始，搞主线");
                //MyLdcmd.myQuitAll(dizhi);
                //Thread.Sleep(2000);
                //MyLdcmd.myRemoveAll(dizhi);
                Thread.Sleep(2000);
                MyLdcmd.RunDuokaiqi(a_b);
                Thread.Sleep(2000);
                //MyFuncUtil.duokaiqiAdd(a_b);
                Thread.Sleep(2000);
                ThreadPool.SetMaxThreads(yunxingIndex.Length, yunxingIndex.Length); //设置最大线程数
                string[] getquanbujubing = MyLdcmd.getDqmoniqiJuBing();
                if (getquanbujubing.Length <= 1) {
                    MyLdcmd.myQuitAll(dizhi);
                    Thread.Sleep(2000);
                    MyLdcmd.myRemoveAll(dizhi);
                    Thread.Sleep(2000);
                    MyLdcmd.RunDuokaiqi(a_b);
                    Thread.Sleep(2000);
                    MyFuncUtil.duokaiqiAdd(xinzengmoniqi);
                    Thread.Sleep(2000);
                    getquanbujubing = MyLdcmd.getDqmoniqiJuBing();
                }
                string[] getquanbuwaicengjubing = MyLdcmd.getDqmoniqiWaiCengJuBing();
                //搞出句柄来 放到每个线程开始里面 如果该句柄为0线程再去检索
                List<LeiDianCanShu> listleidian = new List<LeiDianCanShu>();
                foreach (int inx in yunxingIndex)
                {
                    int jubing = -1;
                    foreach (string s in getquanbujubing)
                    {
                        string[] b = s.Split('|');
                        int zt = int.Parse(b[1]);
                        int ind = int.Parse(b[0]);
                        if (inx == ind && zt != 1)
                        {

                            jubing= zt;
                        }
                    }
                    int waicengjubing = -1;
                    foreach (string s in getquanbuwaicengjubing)
                    {
                        string[] b = s.Split('|');
                        int zt = int.Parse(b[1]);
                        int ind = int.Parse(b[0]);
                        if (inx == ind && zt != 1)
                        {

                            waicengjubing = zt;
                        }
                    }
                    WriteLog.WriteLogFile("", "index:" + inx + ",jubing:" + jubing + ",waicengjubing:" + waicengjubing);
                    LeiDianCanShu ld = new LeiDianCanShu(inx, jubing, waicengjubing);
                    listleidian.Add(ld);
                }
                LeiDianCanShu[] myleiddian = listleidian.ToArray<LeiDianCanShu>();
                
                foreach (int inx in yunxingIndex)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(duoxiand), listleidian.Find(sd=>sd.Dqinx==inx));//线程池指定线程执行Auto方法
                    //Thread.Sleep(1000 * 40);
                }
                var ks = MyFuncUtil.GetTimestamp();
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

        private void duoxiand(object dqind)
        {
            duoxianxunhuan("d", dqind, 200);
            return;
        }

        
        /// <summary>
        /// 启动雷电多开器 删除模拟器 建文件夹 复制模拟器
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

        private void duoxiancheng_Click(object sender, EventArgs e)
        {
            var ks = MyFuncUtil.GetTimestamp();
            Thread.Sleep(2000);
            MyFuncUtil.mylogandxianshi("系统开始初始化,做好种子");
            MyFuncUtil.createDirIfNotExist("d");
            MyLdcmd.ClearAndCopySimulator("d");
            var js = MyFuncUtil.GetTimestamp();
            MyFuncUtil.mylogandxianshi("初始化完毕,耗时" + MyFuncUtil.SecondToHour(js - ks));
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
            mno.myReSize(dqinx, out width, out height,"yiquan");
        }

        private void gaotupian_Click(object sender, EventArgs e)
        {
            quanjubutton = 1;
            MyFuncUtil.mylogandxianshi("系统开始识别Pic图片");
            var ks = MyFuncUtil.GetTimestamp();
            string mydir1 = @"d:\pic1\";
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd("d", out dizhi, out path, out seed);
            int dqinx = int.Parse(this.textBox1.Text);
            int jubing = MyLdcmd.getDqmoniqiJuBingByIndex(dqinx);
            myDm mf = new myDm();
            int r1 = 0;
            if (jubing > 0)
            {
                r1 = mf.bindWindow(jubing);
            }
            Jingjie yq = new Jingjie(mf, 1,jubing, dizhi);
            Bitmap f = null;
            System.IO.DirectoryInfo TheFolder = new System.IO.DirectoryInfo(mydir1);
            int i = 1;
            foreach (System.IO.FileInfo myfile in TheFolder.GetFiles())
            {
                MyFuncUtil.mylogandxianshi("当前第"+i+"个文件");
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
                                if (r.IndexOf("账号") >= 0 && r.Substring(r.IndexOf("账号")).Length > 2)
                                {
                                    zhanghao = r.Substring(r.IndexOf("账号")+2).Trim().ToLower();
                                }
                                if (r.IndexOf("密码") >= 0 && r.Substring(r.IndexOf("密码")).Length > 2)
                                {
                                    pwd = r.Substring(r.IndexOf("密码")+2).Trim().ToLower();
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
            MyFuncUtil.mylogandxianshi("初始化完毕,耗时" + MyFuncUtil.SecondToHour(js - ks));
        }

        private void chongfusandian_Click(object sender, EventArgs e)
        {
            quanjubutton = 1;
            WriteLog.WriteLogFile("", "测试开始");
            List<string> a = Jingjie_SanDian.GetObject().findListShiFouChongMing();
            foreach (string f in a)
            {
                WriteLog.WriteLogFile("",f);
            }

            WriteLog.WriteLogFile("", "测试结束");
        }

        private void guanbixiancheng_Click(object sender, EventArgs e)
        {
            quanjubutton = 1;
            //MyFuncUtil.killProcess("wlxm");
            //if (this.zidongthread!=null && this.zidongthread.ThreadState == System.Threading.ThreadState.Running)
            {
                this.zidongthread.Abort();
            }
            this.thread.Abort();
            //Application.Exit();
            this.label24.Text = "线程已关闭";
            this.label24.Visible = true;
        }

        private void jietujiese_Click(object sender, EventArgs e)
        {
            quanjubutton = 1;
            WriteLog.WriteLogFile("", "开始截图");
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd("d", out dizhi, out path, out seed);
            string ab = this.textBox1.Text;
            if (ab == null || ab.Equals("")) {
                WriteLog.WriteLogFile("", "没填写句柄值");
                return;
            }
            int dqinx = int.Parse(this.textBox1.Text);
            int jubing = MyLdcmd.getDqmoniqiJuBingByIndex(dqinx, dizhi);
            myDm mf = new myDm();
            int r = 0;
            if (jubing > 0)
            {
                r = mf.bindWindow(jubing);
            }
            string filename = dqinx + "_" + mf.GetTime() + ".bmp";
            if (mf.IsFileExist(@"c:\mypic\" + filename) == 1)
            {
                WriteLog.WriteLogFile("", "有重复图存在");
                filename = dqinx + "_" + mf.GetTime() + ".bmp";
            }
            mf.captureBmp(jubing, @"c:\mypic\", filename);
            if (mf.IsFileExist(@"c:\mypic\" + filename) == 1)
            {
                if (System.IO.File.Exists(@"D:\TSColorPicker\TSColorPicker.exe"))
                {
                    Process p = new Process();
                    p.StartInfo.FileName = @"D:\TSColorPicker\TSColorPicker.exe";
                    p.StartInfo.Arguments = @"c:\mypic\" + filename;
                    //启动程序
                    p.Start();
                }
                else {
                    WriteLog.WriteLogFile("", "d盘没有tscolor");
                }
            }
            WriteLog.WriteLogFile("", "结束截图");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectValue = this.comboBox1.SelectedValue.ToString();
            YouXiEntity myy=myyouxi.Find(ob => ob.Youxiname == selectValue);
            if (myy != null) {
                this.label1.Text = myy.Version.ToString();
                this.label17.Text = myy.Zidong;
            }
        }

        

        

        
    }
}
