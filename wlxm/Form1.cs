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
        /// ?�U������
        /// </summary>
        private static int fuzhuBanben = 12;
        

        /// <summary>
        /// ����button ?�F�N����??��
        /// </summary>
        private static int quanjubutton = 0;

        /// <summary>
        /// dict ��?�W?�M�]�W�s?
        /// </summary>
        private Dictionary<string, string> dict = new Dictionary<string, string>();
        /// <summary>
        /// ??��?���]�W�M�[�ۦW
        /// </summary>
        private string apkName = null;
        /// <summary>
        /// �o��?�e��?����index
        /// </summary>
        //private int dqindex = -1;
        /// <summary>
        /// �X?����
        /// </summary>
        private Boolean tmpBool = false;
        /// <summary>
        /// �X?�H��
        /// </summary>
        private StringBuilder tmpBoolString = new StringBuilder();
        /// <summary>
        /// �h?�{ ?�{?
        /// </summary>
        //private object locker = new object();
        /// <summary>
        /// �D?�{ �w??��?��??
        /// </summary>
        private Thread thread;
        private delegate void changeText(string result);
        private delegate void getduokaiqi();
        /// <summary>
        /// ?�m��????
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
        /// ??�h?�{��?�{ID
        /// </summary>
        private List<Thread> list_xc = new List<Thread>();
        /// <summary>
        /// ?�ҼҦ�?�q
        /// </summary>
        private static readonly object obj = new object();

        private void initPackageName()
        {
            dict.Add("������", "com.hypergryph.arknights/com.u8.sdk.U8UnityContext");
            dict.Add("�@���W�H", "com.playcrab.kos.gw/org.cocos2dx.lua.AppActivity");
            dict.Add("���H�W��", "com.idreamsky.psycho100/com.yinghuochong.unity_entry.CustomUnityPlayerActivity");
            dict.Add("�Ҭ�", "com.wk.jingjie.ewan/cn.ewan.supersdk.activity.SplashActivity");
            this.label1.Text = "?�e����:" + fuzhuBanben;
            this.label3.Text = "?�e��?:" + "?�w:�Ҭ�";
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
                CalcFinished("�{�Ǥw?��:" + MyFuncUtil.SecondToHour(js - ks) + zidong);
                this.label2.ForeColor = Color.Red;
                if (quanjubutton == 0 && yici == 0 && (js - ks) > 1000 * 10 && (js - ks) <= 1000 * 20)
                {
                    WriteLog.WriteLogFile("", "�{�Ƿd��?��?? " + (20-(js - ks)/1000)+"��");
                }
                if (quanjubutton==0 && yici == 0 && (js - ks) > 1000 * 20)
                {
                    quanjubutton = 1;
                    yici = 1;
                    //dpanduoxiancheng.PerformClick();
                    zidong = ",��??�椤";
                    if (WriteLog.getMachineName().ToUpper().Equals("1HAO"))
                    {
                        ThreadStart threadStart = new ThreadStart(gaozhanghaotou);//�q?ThreadStart�e���i?�l?�{?�椰�\��k�@
                        Thread thread = new Thread(threadStart);
                        thread.Name = "wodegaozhanghao";
                        thread.Start();
                    }
                    else
                    {
                        ThreadStart threadStart = new ThreadStart(duoxianzongtou);//�q?ThreadStart�e���i?�l?�{?�椰�\��k�@
                        Thread thread = new Thread(threadStart);
                        thread.Name = "wodedpanduoxian";
                        thread.Start();
                    }
                }
                //�C�j�@�p?��zk��s�@�� ??? �C�j1��?
                if (WriteLog.getMachineName().ToUpper().Equals("WLZHONGKONG") && (js - ks_gxyunxing) > 1000 * 60*20)
                {
                    ks_gxyunxing = MyFuncUtil.GetTimestamp();
                    ZhangHao zh = new ZhangHao();
                    DateTime dt=zh.getYunXingQkLasttime();
                    TimeSpan span = DateTime.Now.Subtract(dt);
                    WriteLog.WriteLogFile("", "��?��s�O�W��??�ۤ�,?�j " + span.Minutes + "��?");
                    
                    if (span.Hours >= 1 || span.Minutes > 45)
                    
                    {
                        WriteLog.WriteLogFile("", "�O�W��??�ۤ�,?�j " + span.Minutes + "��?");
                        zh.gxYunXingQk();
                    }
                }

                //�C�j60��?�d�ݬO�_??��? ??? �C�j1��?
                if (WriteLog.getMachineName().ToUpper().Equals("WLZHONGKONG") && (js - ks_cqyunxing) > 1000 * 60 * 60)
                {
                    ks_cqyunxing = MyFuncUtil.GetTimestamp();
                    ZhangHao zh = new ZhangHao();
                    bool t = zh.panDuanChongQi(WriteLog.getMachineName());
                    if (t)
                    {
                        WriteLog.WriteLogFile("", "?�e�ݭn��?" + DateTime.Now);
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
            MyFuncUtil.mylogandxianshi("?�l");
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
            MyFuncUtil.mylogandxianshi("?��");
            
        }
        private void lurenzhanghao(object inx)
        {
            /*??�{�Ҧ��G
             *1�B�s�ئ��\�Z��??��?�� �w?�i�H�b��?������?��?�U?��
             *2�B��?����?�Z�w?apk
             *3�B�w?���\�Z��?��?
             *4�B��?��s���\�Z??��ȵn?�}�O�s
             *5�B�O�s�Z�I���n�O�s��?�}??
             *6�B??�Z�s�Jsql
             *7�B??��?��
             *8�Breload�s?���
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
                WriteLog.WriteLogFile(dqinx + "", "��?�ާ@" + dqinx + "?��?��");
                bool temp = MyFuncUtil.myQuit(dqinx, dizhi);//??���w��?�� dqinx
                if (!temp)
                {
                    WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + "??��?");
                    Thread.Sleep(20000);
                    return;
                }
                WriteLog.WriteLogFile(dqinx + "", "��?�ާ@" + dqinx + "?��?��");
                MyLdcmd.installApp(dqinx, @"C:\���p�U?\jjlydj_ew100224700.apk");
                bool t = MyFuncUtil.lureninstallOk(dqinx);
                if (t == false)
                {
                    WriteLog.WriteLogFile(dqinx + "", "�w?app?���\");
                    return;
                }
                t = MyFuncUtil.myQuit(dqinx, dizhi);//??���w��?�� dqinx
                if (!t)
                {
                    WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + "??��?");
                    Thread.Sleep(20000);
                    return;
                }
                WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + "��W");
                MyLdcmd.myRename(dqinx, "�p?" + dqinx, dizhi);                
                temp = MyFuncUtil.LaunchQiHao(dqinx);
                if (!temp)
                {
                    WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + "��?��?");
                    Thread.Sleep(20000);
                    return;
                }
                Thread.Sleep(20000);
                apkName = dict["�Ҭ�"];
                int i = MyFuncUtil.QiDongWanChengLurenzhanghao(a_b, dqinx, apkName);
                if (i == -1)
                {
                    WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + "��?app" + apkName + "��?");
                    Thread.Sleep(20000);
                    return;
                }
                int w = -1, h = -1;
                MyFuncUtil.getWindowSize(dqinx, out w, out h);
                if (w != -1 && h != -1 && w < h) {
                    WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + "w h��?"+w+" "+h);
                    Thread.Sleep(20000);
                    return;
                }
                MyFuncJingNoTai mno = new MyFuncJingNoTai();
                temp = mno.lurenResizeOk(dqinx);
                if (temp == false)
                {
                    WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + ",resize?���\");
                    return;
                }
                myDm mf = new myDm();
                Jingjie jn = new Jingjie(mf, dqinx);
                if (jn.Jubing <= 0)
                {
                    WriteLog.WriteLogFile(dqinx + "", "�y�`��??");
                    Thread.Sleep(20000);
                    return;
                }
                jn.jingjiecunhao();
                temp = MyFuncUtil.myQuit(dqinx, dizhi);//??���w��?�� dqinx
                if (!temp)
                {
                    WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + "??��?");
                    Thread.Sleep(20000);
                    return;
                }
                Thread.Sleep(10000);
                WriteLog.WriteLogFile(dqinx + "", "�@���`??��");
                var js = MyFuncUtil.GetTimestamp();
                WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + "�`?����");
                WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + "�`?1����?" + MyFuncUtil.SecondToHour(js - ks));
            }
        }

        private void lrzh_Click(object sender, EventArgs e)
        {
            quanjubutton = 1;
            ThreadStart threadStart = new ThreadStart(gaozhanghaotou);//�q?ThreadStart�e���i?�l?�{?�椰�\��k�@
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
            MyFuncUtil.mylogandxianshi("��?�d??");
            MyFuncUtil.createDirIfNotExist();
            Thread.Sleep(2000);
            for (int j = 0; j < 10000; j++)
            {
                MyFuncUtil.mylogandxianshi("��?" + j + ",?�l");
                MyLdcmd.myQuitAll(dizhi);
                Thread.Sleep(2000);
                MyLdcmd.myRemoveAll(dizhi);
                Thread.Sleep(2000);
                MyLdcmd.RunDuokaiqi(a_b);
                MyFuncUtil.duokaiqiAdd();
                Thread.Sleep(2000);
                ThreadPool.SetMaxThreads(yunxingIndex.Length, yunxingIndex.Length); //?�m�̤j?�{?
                foreach (int inx in yunxingIndex)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(lurenzhanghao), inx);//?�{�����w?�{?��Auto��k
                    Thread.Sleep(1000);
                }
                long ks = MyFuncUtil.GetTimestamp();
                while (true)
                {
                    Thread.Sleep(1000);//?�y??�A�D�n�O?���n�`?���\�h���C�h���]�i�H�C
                    int maxWorkerThreads, workerThreads;
                    int portThreads;
                    ThreadPool.GetMaxThreads(out maxWorkerThreads, out portThreads);
                    ThreadPool.GetAvailableThreads(out workerThreads, out portThreads);
                    if (maxWorkerThreads - workerThreads == 0)
                    {
                        Console.WriteLine("?���F");
                        break;
                    }
                }
                MyFuncUtil.mylogandxianshi("��?" + j + ",?��");
            }
        }
        
        private void ceshi_button_Click(object sender, EventArgs e)
        {
            quanjubutton = 1;
            apkName = dict["�@���W�H"];
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
            MyFuncUtil.mylogandxianshi("��?�h?�{??");
            for (int j = 0; j < 5; j++)
            {
                MyFuncUtil.mylogandxianshi("��?" + j + ",?�l");

                ThreadPool.SetMaxThreads(yunxingIndex.Length, yunxingIndex.Length); //?�m�̤j?�{?
                foreach (int inx in yunxingIndex)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(duoxian_cs), inx);//?�{�����w?�{?��Auto��k
                    Thread.Sleep(1000*20);
                }
                long ks = MyFuncUtil.GetTimestamp();
                while (true)
                {
                    Thread.Sleep(1000);//?�y??�A�D�n�O?���n�`?���\�h���C�h���]�i�H�C
                    int maxWorkerThreads, workerThreads;
                    int portThreads;
                    ThreadPool.GetMaxThreads(out maxWorkerThreads, out portThreads);
                    ThreadPool.GetAvailableThreads(out workerThreads, out portThreads);
                    if (maxWorkerThreads - workerThreads == 0)
                    {
                        Console.WriteLine("?���F");
                        break;
                    }                    
                }
                MyFuncUtil.mylogandxianshi("��?" + j + ",?��");
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
                MyFuncUtil.mylogandxianshi("��?��" + dqinx + "���Ccpu");
                //MyLdcmd.myDownCpu(dqinx, 50);
                Jingjie yq = new Jingjie(dm, dqinx, dizhi);
                //yq.denglu(15, out a_b);
                yq.zhuxian(a_b);
                Thread.Sleep(1000 * 60 * 60);
                
                var js = MyFuncUtil.GetTimestamp();
                MyFuncUtil.mylogandxianshi("��?��" + dqinx + "�`?" + cishu + "��?");
                MyFuncUtil.mylogandxianshi("��?��" + dqinx + "�`?1����?" + MyFuncUtil.SecondToHour(js - ks));
            }
        }


        private void quanliucheng_Click(object sender, EventArgs e)
        {
            quanjubutton = 1;
            MyFuncUtil.mylogandxianshi("?�l-�w��?");
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
                        MyFuncUtil.mylogandxianshi(f.Name+"�ҽk����");
                        //mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                        mf.mydelay(1000, 2000);
                    }
                    if (mf.jingqueByLeiBool(f.Sd))
                    {
                        MyFuncUtil.mylogandxianshi(f.Name + "���̨���");
                        mf.mydelay(1000, 2000);
                    }
                }
                mf.mydelay(10, 200);

            }
            MyFuncUtil.mylogandxianshi("?��-�w��?");
        }
        
        private void dpanduoxiancheng_Click(object sender, EventArgs e)
        {
            quanjubutton = 1;
            ThreadStart threadStart = new ThreadStart(duoxianzongtou);//�q?ThreadStart�e���i?�l?�{?�椰�\��k�@
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
            //�Ҧ�??�m?dengluzhong N �h?�󾹪�? ?����?
            //ZhangHao zh = new ZhangHao();
            //zh.zhiweidengluzhongN("jingjie", WriteLog.getMachineName());
            for (int j = 1; j < 1000; j++)
            {
                WriteLog.WriteLogFile("", "��?" + j + ",?�l");
                MyLdcmd.myQuitAll(dizhi);
                Thread.Sleep(2000);
                MyLdcmd.myRemoveAll(dizhi);
                Thread.Sleep(2000);
                MyLdcmd.RunDuokaiqi(a_b);
                Thread.Sleep(2000);
                MyFuncUtil.duokaiqiAdd(a_b);
                Thread.Sleep(2000);
                ThreadPool.SetMaxThreads(yunxingIndex.Length, yunxingIndex.Length); //?�m�̤j?�{?
                foreach (int inx in yunxingIndex)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(duoxiand), inx);//?�{�����w?�{?��Auto��k
                    //Thread.Sleep(1000 * 40);
                }
                var ks = MyFuncUtil.GetTimestamp();
                while (true)
                {
                    Thread.Sleep(10000);//?�y??�A�D�n�O?���n�`?���\�h���C�h���]�i�H�C
                    int maxWorkerThreads, workerThreads;
                    int portThreads;
                    ThreadPool.GetMaxThreads(out maxWorkerThreads, out portThreads);
                    ThreadPool.GetAvailableThreads(out workerThreads, out portThreads);
                    if (maxWorkerThreads - workerThreads == 0)
                    {
                        break;
                    }
                }

                WriteLog.WriteLogFile("", "��?" + j + ",?��");
            }
        }

        private void duoxiand(object dqind)
        {
            int a = (int)dqind;
            duoxianxunhuan("d", a,200);
            return;
        }

        
        /// <summary>
        /// ??�p?�h?�� ?����?�� �ؤ��? �`���?��
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
            WriteLog.WriteLogFile(dqinx + "", "��?�ާ@" + dqinx + "?��?��");            
            var cishu = 0;
            for (int cs = 0; cs < xhcishu; cs++)
            {
                var ks = MyFuncUtil.GetTimestamp();
                Thread.Sleep(2000);
                WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + "?�J��`??���Athread:" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
                bool temp=MyFuncUtil.myQuit(dqinx, dizhi);
                if (!temp)
                {
                    WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + "??��?");
                    Thread.Sleep(20000);
                    continue;
                }
                WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + "�`��");
                MyLdcmd.myRestore(dqinx, seed, dizhi);
                WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + "��W");
                MyLdcmd.myRename(dqinx, "�p" + dqinx + "-" + cishu, dizhi);
                temp=MyFuncUtil.Launch(dqinx, dizhi);
                if (!temp) {
                    WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + "��?��?");
                    Thread.Sleep(20000);
                    continue;
                }
                Thread.Sleep(20000);
                apkName = dict["�Ҭ�"];
                int i = MyFuncUtil.QiDongWanChengLurenzhanghao(a_b, dqinx, apkName);
                if (i == -1)
                {
                    WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + "��?app" + apkName + "��?");
                    Thread.Sleep(20000);
                    continue;
                }
                int w = -1, h = -1;
                MyFuncUtil.getWindowSize(dqinx, out w, out h);
                if (w != -1 && h != -1 && w < h)
                {
                    WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + "w h��?" + w + " " + h);
                    Thread.Sleep(20000);
                    continue;
                }
                Thread.Sleep(20000);
                MyFuncJingNoTai mno = new MyFuncJingNoTai();
                temp = mno.lurenResizeOk(dqinx);
                if (temp == false)
                {
                    WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + ",resize?���\");
                    continue;
                }
                WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + "���Ccpu");
                MyLdcmd.myDownCpu(dqinx, 50);
                Thread.Sleep(1000 * 10); 
                myDm dm = new myDm();
                Jingjie yq = new Jingjie(dm, dqinx, dizhi);
                string name = "";
                tmpBool = yq.denglu(15,out name);
                if (!tmpBool)
                {
                    WriteLog.WriteLogFile(dqinx + "", "�n???�X?");
                    Thread.Sleep(1000 * 60 * 3);
                    continue;
                }                
                yq.zhuxian(name);
                //Thread.Sleep(1000 * 60*60);//����1�p?
                cishu++;
                var js = MyFuncUtil.GetTimestamp();
                WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + "�`?" + cishu + "��?");
                WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + "�`?1����?" + MyFuncUtil.SecondToHour(js - ks));
            }
        }

        private void oldquanqd() {
            apkName = dict["������"];
            int[] yunxingIndex = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            string a_b = "d";
            qdinit(a_b);
            for (int j = 1; j < 1000; j++)
            {
                WriteLog.WriteLogFile("", "��?" + j + ",?�l");
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
                ThreadPool.SetMaxThreads(newinx.Count, newinx.Count); //?�m�̤j?�{?
                foreach (int inx in newinx)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(duoxiand), inx);//?�{�����w?�{?��Auto��k
                    Thread.Sleep(20000);
                }

                while (true)
                {
                    Thread.Sleep(10000);//?�y??�A�D�n�O?���n�`?���\�h���C�h���]�i�H�C
                    int maxWorkerThreads, workerThreads;
                    int portThreads;
                    ThreadPool.GetMaxThreads(out maxWorkerThreads, out portThreads);
                    ThreadPool.GetAvailableThreads(out workerThreads, out portThreads);
                    if (maxWorkerThreads - workerThreads == 0)
                    {
                        break;
                    }
                }

                WriteLog.WriteLogFile("", "��?" + j + ",?��");
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
            WriteLog.WriteLogFile(dqinx + "", "��?��" + dqinx + "?�J��`??��");
            /*var r = MyFuncUtil.Launch(a, dizhi);
            if (r == 0)
            {
                WriteLog.WriteLogFile(a + "", "��?��" + a + "��?��?");
                Thread.Sleep(20000);
                return;
            }
            Thread.Sleep(20000);*/
            myDm dm = new myDm();
            lock (dm)
            {
                MingRi_Sort mr = new MingRi_Sort(dm, dqinx, dizhi);
                //�n? �n�U?��� ?�w�Q��? ??start��??�ߨ���X
                tmpBool = mr.denglu(10);
                if (!tmpBool)
                {
                    tmpBoolString.Append("�n???�X?");
                    return;
                }
                tmpBool = mr.zhuce(3);
                if (!tmpBool)
                {
                    tmpBoolString.Append("�`???�X?");
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
                //continue;//??�����`?
                if (i == 3)
                {
                    continue;//�@���`?�A�`?���O�̨�����if�P?�I���Owhile�A�@��??�J���`?
                }
                if (i == 21)
                {
                    return;//��return�@?�A?����k�^�A�Z���N?�������A?�檽����^
                }
                if (i == 9)
                {
                    break;//��return�@?�A?����k�^�A�Z���N?�������A?�檽����^
                }                
                WriteLog.WriteLogFile("",i+"");
            }
        }

        private void duoxiancheng_Click(object sender, EventArgs e)
        {
            var ks = MyFuncUtil.GetTimestamp();
            Thread.Sleep(2000);
            MyFuncUtil.mylogandxianshi("�t??�l��l��,���n���l");
            MyFuncUtil.createDirIfNotExist("d");
            MyLdcmd.ClearAndCopySimulator("d");
            var js = MyFuncUtil.GetTimestamp();
            MyFuncUtil.mylogandxianshi("��l�Ƨ�?,��?" + MyFuncUtil.SecondToHour(js - ks));
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
            MyFuncUtil.mylogandxianshi("�t??�l??Pic?��");
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
                MyFuncUtil.mylogandxianshi("?�e��"+i+"?���");
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
                                if (r.IndexOf("�K?") >= 0 && r.Substring(r.IndexOf("�K?")).Length > 2)
                                {
                                    pwd = r.Substring(r.IndexOf("�K?")+2).Trim().ToLower();
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
            MyFuncUtil.mylogandxianshi("��l�Ƨ�?,��?" + MyFuncUtil.SecondToHour(js - ks));
        }

        private void chongfusandian_Click(object sender, EventArgs e)
        {
            quanjubutton = 1;
            WriteLog.WriteLogFile("", "???�l");
            List<string> a = Jingjie_SanDian.GetObject().findListShiFouChongMing();
            foreach (string f in a)
            {
                WriteLog.WriteLogFile("",f);
            }

            WriteLog.WriteLogFile("", "???��");
        }

        

        
    }
}
