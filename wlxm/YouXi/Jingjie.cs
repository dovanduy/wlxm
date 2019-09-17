using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using xDM;
using MyUtil;
using LuciferSrcipt;
using System.Threading;
using Newtonsoft.Json.Linq;
using Entity;
namespace fuzhu
{
    public class Jingjie:youxi
    {
        public static int YOUXIBANBEN = 15;
        private myDm mf;
        private int _dqinx;

        public int Dqinx
        {
            get { return _dqinx; }
            set { _dqinx = value; }
        }
        private int _jubing;

        public int Jubing
        {
            get { return _jubing; }
            set { _jubing = value; }
        }
        private string _mnqName;

        public string MnqName
        {
            get { return _mnqName; }
            set { _mnqName = value; }
        }
        
        /// <summary>
        /// 跳过动画专用点击位置x
        /// </summary>
        private int tiaoguoyongX = 275;
        /// <summary>
        /// 跳过动画专用点击位置y
        /// </summary>
        private int tiaoguoyongY = 254;

        /// <summary>
        /// 记录战斗画面的时间
        /// </summary>
        private long zdsj = -1;




        public Jingjie(xDm mydm, int dqinx, string dizhi = @"d:\ChangZhi\dnplayer2\")
        {
            this.mf = (myDm)mydm;
            this._dqinx = dqinx;
            this._jubing = MyLdcmd.getDqmoniqiJuBingByIndex(dqinx,dizhi);            
            //模拟器的名字 取值有问题 改为index
            this._mnqName = dqinx + "";
            int r = 0;
            if (this._jubing > 0)
            {
                r = mf.bindWindow(this._jubing);
            }
            WriteLog.WriteLogFile(this._mnqName, "构造函数,句柄是:" + _jubing + ",模拟器index是:" + _mnqName + "，thread:" + Thread.CurrentThread.ManagedThreadId + "，绑定:" + r);
        }

        public void ceshi()
        {
            jingjiecunhao();
        }

        private List<string> shibiefrombaidu(int jubing, myDm mf, FuHeSanDian qz, int x1, int y1, int x2, int y2)
        {
            List<string> rt = new List<string>();
            if (mf.mohuByLeiBool(qz.Sd))
            {
                WriteLog.WriteLogFile(_dqinx+"", qz.Name+"开始取特定位置识别");
                string filename = _dqinx + "_" + mf.GetTime() + ".bmp";
                mf.mydelay(20, 300);
                if (mf.IsFileExist(@"c:\mypic_save\" + filename) != 1)
                {
                    mf.captureBmp(jubing, @"c:\mypic_save\", filename, x1, y1, x2, y2);
                    mf.mydelay(2000, 3000);
                    if (mf.IsFileExist(@"c:\mypic_save\" + filename) == 1)
                    {
                        List<string> r = generalBaiduShibie(this._dqinx, @"c:\mypic_save\" + filename);
                        if (r != null && r.Count > 0)
                        {
                            rt = r;
                        }
                        if (File.Exists(@"c:\mypic_save\" + filename))
                        {
                            //File.Delete(@"c:\mypic_save\" + filename); ;
                        }
                    }
                }
            }
            return rt;
        }

        public void jingjiecunhao()
        {
            WriteLog.WriteLogFile(this._mnqName, "进入到境界存账号阶段");
            bool t = false;
            string zhanghao = "";
            string pwd = "";
            int xuanqu = 0;
            int xuanhao = 0;
            bool shibiechu = true;
            int kaishidian = 0;
            long ks = MyFuncUtil.GetTimestamp();
            long kstiaoguo = MyFuncUtil.GetTimestamp();
            ZhangHao zh = new ZhangHao();
            bool t1 = false;
            int tiaoguo = 0;
            while (true)
            {
                long js = MyFuncUtil.GetTimestamp();
                FuHeSanDian kt = Jingjie_SanDian.GetObject().findFuHeSandianByName("登录-选择登录注册");
                if (xuanqu == 0 && mf.mohuByLeiBool(kt.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, kt.Name);
                    mf.mytap(this._jubing, kt.Zhidingx, kt.Zhidingy);
                    mf.mydelay(2000, 4000);
                }
                kt = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊存账号-用户下载");
                if (xuanqu == 0 && mf.mohuByLeiBool(kt.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, kt.Name);
                    mf.mytap(this._jubing, kt.Zhidingx, kt.Zhidingy);
                    kaishidian = 1;
                }
                if (kaishidian == 0 && (js - kstiaoguo) > 10) {
                    mf.mytap(this._jubing, 654, 346);
                    kstiaoguo = MyFuncUtil.GetTimestamp();
                }
                FuHeSanDian yk = Jingjie_SanDian.GetObject().findFuHeSandianByName("登录-注册账号");
                if (xuanqu == 0 && mf.mohuByLeiBool(yk.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, yk.Name);
                    mf.mydelay(2000, 4000);
                    int yici0 = 0;
                    long ks0 = MyFuncUtil.GetTimestamp();
                    int jci = 0;
                    int tiaoci = 0;
                    while (true)
                    {
                        if (yici0 == 0)
                        {
                            WriteLog.WriteLogFile(this._mnqName, yk.Name + " 识别换为自己录入");
                            yici0 = 1;
                        }
                        yk = Jingjie_SanDian.GetObject().findFuHeSandianByName("登录-注册账号");
                        if (xuanqu == 0 && mf.mohuByLeiBool(yk.Sd))
                        {
                            WriteLog.WriteLogFile(this._mnqName,"当前界面为"+yk.Name);
                            zh.generateNameAndPas(this._dqinx, 7, out zhanghao, out pwd);                            
                            mf.mydelay(300, 600);
                            mf.mytap(this._jubing, yk.Zhidingx, yk.Zhidingy);//点击两次
                            mf.mydelay(4000, 6000);
                            if (mf.mohu(504, 27, 0xffffff) == 1)
                            {
                                WriteLog.WriteLogFile(this._mnqName, "搞账号");
                                mf.mytap(this._jubing, 504, 27);
                                mf.mydelay(2000, 4000);
                                zh.shuruqianhuitui(mf, this._dqinx, this._jubing);
                                mf.mydelay(2000, 4000);
                                mf.SendString(this._jubing, zhanghao);
                                mf.mydelay(2000, 4000);
                                mf.myKeyPressChar(this._jubing, "tab");
                                mf.mydelay(2000, 4000);
                            }
                            mf.mydelay(2000, 4000);
                            mf.mytap(this._jubing, 325, 183);//点击密码
                            mf.mydelay(4000, 6000);
                            if (mf.mohu(504, 27, 0xffffff) == 1)
                            {
                                WriteLog.WriteLogFile(this._mnqName, "搞密码");
                                mf.mytap(this._jubing, 504, 27);
                                mf.mydelay(2000, 4000);
                                zh.shuruqianhuitui(mf, this._dqinx, this._jubing);
                                mf.mydelay(2000, 4000);
                                mf.SendString(this._jubing, pwd);
                                mf.mydelay(2000, 4000);
                                mf.myKeyPressChar(this._jubing, "tab");
                                mf.mydelay(2000, 4000);                                
                            }                             
                            if (mf.mohu(434, 225, 0x1eb9ee) == 1)
                            {
                                mf.mydelay(2000, 4000);
                                mf.mytap(this._jubing, 436, 228);//去掉手机绑定
                                mf.mydelay(2000, 4000);
                            }
                            mf.mydelay(4000, 6000);
                            if (mf.mohu(365, 309, 0xe99100) == 1)
                            {
                                WriteLog.WriteLogFile(this._mnqName, "搞注册");
                                mf.mydelay(2000, 4000);
                                mf.mytap(this._jubing, 365, 309);//点击注册
                                mf.mydelay(9000, 18000);
                            }                            
                        }
                        kt = Jingjie_SanDian.GetObject().findFuHeSandianByName("登录-实名认证");
                        if (mf.mohuByLeiBool(kt.Sd)) {
                            WriteLog.WriteLogFile(this._mnqName, kt.Name);
                            mf.mytap(this._jubing, kt.Zhidingx, kt.Zhidingy);
                            tiaoci++;
                        }
                        kt = Jingjie_SanDian.GetObject().findFuHeSandianByName("登录-公告");
                        if (mf.mohuByLeiBool(kt.Sd))
                        {
                            WriteLog.WriteLogFile(this._mnqName, kt.Name);
                            mf.mytap(this._jubing, kt.Zhidingx, kt.Zhidingy);
                            tiaoci++;
                        }
                        if (!mf.mohuXunHuanJianChi(yk.Sd,60) && tiaoci>1)
                        {
                            WriteLog.WriteLogFile(this._mnqName, yk.Name + "成功" + zhanghao + " " + pwd);
                            WriteLog.WriteLogFile(this._mnqName, yk.Name + "注册成功,注册页面不见");
                            shibiechu = true;
                            xuanqu = 1;
                            break;
                        }
                        if (mf.mohuXunHuanJianChi(yk.Sd, 60))
                        {
                            WriteLog.WriteLogFile(this._mnqName, "账号可能已被占用"+jci);
                        }
                        long js0 = MyFuncUtil.GetTimestamp();
                        if ((js0 - ks0) > 1000 * 60 * 6)
                        {
                            WriteLog.WriteLogFile(this._mnqName, yk.Name + "6分钟没成功");
                            xuanqu = 1;
                            zhanghao = "";
                            pwd = "";
                            shibiechu = false;
                            break;
                        }
                        jci++;
                    }
                }
                if (!shibiechu)
                {
                    WriteLog.WriteLogFile(this._mnqName, yk.Name + "账号注册不成功");
                    break;
                }
                kt = Jingjie_SanDian.GetObject().findFuHeSandianByName("登录-实名认证");
                if (mf.mohuByLeiBool(kt.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, kt.Name);
                    mf.mytap(this._jubing, kt.Zhidingx, kt.Zhidingy);
                }
                kt = Jingjie_SanDian.GetObject().findFuHeSandianByName("登录-公告");
                if (mf.mohuByLeiBool(kt.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, kt.Name);
                    mf.mytap(this._jubing, kt.Zhidingx, kt.Zhidingy);
                }
                //出现登录-出现选服信息 超过10s
                FuHeSanDian dlxf = Jingjie_SanDian.GetObject().findFuHeSandianByName("选区-出现进入游戏");
                bool t0 = mf.mohuXunHuanJianChi(dlxf.Sd, 60);
                if (xuanqu == 1 && xuanhao == 0 && t0)
                {
                    WriteLog.WriteLogFile(this._mnqName, dlxf.Name);
                    mf.mytap(this._jubing, 425, 303);
                    mf.mydelay(2000, 4000);
                    FuHeSanDian xq = Jingjie_SanDian.GetObject().findFuHeSandianByName("选区-选区界面");
                    if (mf.mohuByLeiBool(xq.Sd))
                    {
                        WriteLog.WriteLogFile(this._mnqName, xq.Name);
                        mf.mytap(this._jubing, 84, 140);//增加新区要改
                    }
                }
                FuHeSanDian xq1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("选区-服务器选区界面");
                if (xuanqu == 1 && mf.mohuByLeiBool(xq1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, xq1.Name);
                    mf.mytap(this._jubing, 84, 140);//增加新区要改
                    mf.mydelay(2000, 4000);
                }
                FuHeSanDian qu1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("选区-选区界面中的1区");
                if (xuanqu == 1 && mf.mohuByLeiBool(qu1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, qu1.Name);
                    xuanqu = 2;
                    mf.mytap(this._jubing, qu1.Zhidingx, qu1.Zhidingy);
                    mf.mydelay(2000, 4000);
                    t = mf.mohuXunHuanJianChi(dlxf.Sd, 60);
                    if (t)
                    {
                        WriteLog.WriteLogFile(this._mnqName, dlxf.Name + "选服成功");
                        mf.mytap(this._jubing, 345, 324);
                        mf.mydelay(2000, 4000);
                        xuanhao = 1;
                    }
                }
                t = mf.mohuXunHuanJianChi(dlxf.Sd, 60);
                if (xuanqu == 2 && t)
                {
                    mf.mytap(this._jubing, dlxf.Zhidingx, dlxf.Zhidingy);
                    xuanhao = 1;
                    WriteLog.WriteLogFile(this._mnqName, dlxf.Name + "选服成功2");
                }
                List<FuHeSanDian> ls2 = Jingjie_SanDian.GetObject().findListFuHeSandianByName("游戏");
                if (xuanhao == 1 && ls2 != null && ls2.Count > 0)
                {
                    foreach (FuHeSanDian fh in ls2)
                    {
                        if (mf.mohuByLeiBool(fh.Sd,80))
                        {
                            WriteLog.WriteLogFile(this._mnqName, fh.Name);
                            if (fh.Zhidingx != -1 && fh.Zhidingy != -1)
                            {
                                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                            }
                            if (fh.Name.Equals("游戏-跳过")) {
                                tiaoguo++;
                                mf.mydelay(1000, 3000);
                            }
                        }
                    }
                }
                FuHeSanDian qu2 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊游戏-开始战斗");
                if (xuanhao == 1 && mf.mohuByLeiBool(qu2.Sd))
                {
                    t1 = true;
                }
                if (tiaoguo > 25) {
                    t1 = true;
                }
                qu2 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊游戏-进入任务");
                if (xuanhao == 1 && mf.mohuByLeiBool(qu2.Sd))
                {
                    t1 = true;
                }
                if (t1)
                {
                    WriteLog.WriteLogFile(this._mnqName, "账号保存游戏阶段结束");
                    break;
                }
                if ((js - ks) > 1000 * 60 * 20) {
                    WriteLog.WriteLogFile(this._mnqName, "账号保存游戏阶段超时");
                    break;
                }
            }
            if (zhanghao == "" || pwd == "")
            {
                WriteLog.WriteLogFile(this._mnqName, "账号密码截取失败");
                return;
            }
            zh = new ZhangHao();
            zh.lurenSaveNameAndPas(zhanghao, pwd, this._dqinx, "jingjieguanfang");
            WriteLog.WriteLogFile(this._mnqName, "结束了境界存账号阶段");
        }

        public Boolean denglu(int fenzhong,out string name)
        {
            WriteLog.WriteLogFile(this._mnqName, "进入到登录环节  " + this._jubing + "，thread:" + Thread.CurrentThread.ManagedThreadId);
            ZhangHao zhanghao = new ZhangHao();
            name = "";
            string pwd = "";
            int xuanqu = -1, dengji = -1;
            string youxi="jingjie";
            zhanghao.zhunbeizhanghao(this._dqinx,youxi, out name, out pwd, out xuanqu, out dengji);
            if (name==null || name == "" || pwd==null || pwd == "") {
                //当前没有找到需要练级的账号
                WriteLog.WriteLogFile(this._mnqName, "当前没有找到需要练级的账号");
                return false;
            }            
            long ks = MyFuncUtil.GetTimestamp();
            long kstiaoguo = MyFuncUtil.GetTimestamp();
            bool t1 = false;
            int denglu = 0;
            int yici = 0;
            int kaishidian = 0;
            int tiaochuci = 0;
            List<FuHeSanDian> ls = Jingjie_SanDian.GetObject().findListFuHeSandianByName("存账号");
            while (true)
            {
                if (yici == 0) {
                    WriteLog.WriteLogFile(this._mnqName, "进入登录循环");
                    yici = 1;
                }
                long js = MyFuncUtil.GetTimestamp();
                FuHeSanDian kt = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊存账号-新号首界面2");
                if (mf.mohuByLeiBool(kt.Sd))
                {
                    kaishidian = 1;
                    WriteLog.WriteLogFile(this._mnqName, kt.Name);
                    mf.mytap(this._jubing, 492, 69);
                }
                kt = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊存账号-用户下载");
                if (xuanqu == 1 && mf.mohuByLeiBool(kt.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, kt.Name);
                    mf.mytap(this._jubing, kt.Zhidingx, kt.Zhidingy);
                    kaishidian = 1;
                }
                if (kaishidian == 0 && (js - kstiaoguo) > 10)
                {
                    mf.mytap(this._jubing, 654, 346);
                    kstiaoguo = MyFuncUtil.GetTimestamp();
                }
                kt = Jingjie_SanDian.GetObject().findFuHeSandianByName("登录-输入账号");
                FuHeSanDian kt1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊存账号-用户名密码重新录2");
                if (denglu==0 && (mf.mohuByLeiBool(kt.Sd) || (mf.mohuByLeiBool(kt1.Sd))))
                {
                    WriteLog.WriteLogFile(this._mnqName, kt.Name);
                    mf.mytap(this._jubing, 437, 129);//点击两次
                    mf.mydelay(100, 300);
                    mf.mytap(this._jubing, 437, 129);
                    mf.mydelay(100, 300);
                    zhanghao.shuruqianhuitui(mf, this._dqinx, this._jubing);
                    mf.mydelay(100, 300);
                    mf.mytap(this._jubing, 437, 129);
                    mf.mydelay(2000, 4000);
                    WriteLog.WriteLogFile(this._mnqName, "录入账号 "+name);
                    mf.SendString(this._jubing, name);
                    mf.mytap(this._jubing, 434, 196);
                    mf.mydelay(100, 300);
                    mf.mytap(this._jubing, 434, 196);
                    mf.mydelay(100, 300);
                    mf.mydelay(2000, 4000);
                    WriteLog.WriteLogFile(this._mnqName, "录入密码 " + pwd);
                    mf.SendString( this._jubing, pwd);
                    mf.mydelay(2000, 4000);
                    mf.mytap(this._jubing, kt.Zhidingx, kt.Zhidingy);
                    mf.mydelay(1000, 3000);
                    mf.mytap(this._jubing, kt.Zhidingx, kt.Zhidingy);
                    mf.mydelay(1000, 3000);
                    mf.mytap(this._jubing, kt.Zhidingx, kt.Zhidingy);
                    mf.mydelay(4000, 6000);
                }
                if (denglu==0 && tiaochuci > 0 && !mf.mohuXunHuanJianChi(kt.Sd, 20) && !mf.mohuXunHuanJianChi(kt1.Sd, 20))
                {
                    WriteLog.WriteLogFile(this._mnqName, kt.Name + " 登录成功");
                    denglu = 1;
                }
                if (denglu == 0 &&(mf.mohuXunHuanJianChi(kt.Sd,20) || mf.mohuXunHuanJianChi(kt1.Sd,20))) {
                    WriteLog.WriteLogFile(this._mnqName, "当前账号无法登陆,置为N,修改时间更新换号");
                    zhanghao.zhiweidengluzhongN(this._dqinx, "jingjie", name, WriteLog.getMachineName());
                    youxi = "jingjie";
                    zhanghao.zhunbeizhanghao(this._dqinx, youxi, out name, out pwd, out xuanqu, out dengji);
                    if (name == null || name == "" || pwd == null || pwd == "")
                    {
                        //当前没有找到需要练级的账号
                        WriteLog.WriteLogFile(this._mnqName, "换账号，但没有找到需要练级的账号");
                        break;
                    }                    
                    denglu = 0;
                }
                
                if (xuanqu == 1 && ls != null && ls.Count > 0)
                {
                    foreach (FuHeSanDian fh in ls)
                    {
                        if (mf.mohuByLeiBool(fh.Sd))
                        {
                            WriteLog.WriteLogFile(this._mnqName, fh.Name);
                            if (fh.Zhidingx != -1 && fh.Zhidingy != -1)
                            {
                                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                                tiaochuci++;
                            }
                        }
                    }
                }
                FuHeSanDian dlxf = Jingjie_SanDian.GetObject().findFuHeSandianByName("选区-出现进入游戏");
                bool t = mf.mohuXunHuanJianChi(dlxf.Sd, 60);
                if (denglu == 0 && t)
                {
                    WriteLog.WriteLogFile(this._mnqName, dlxf.Name+"选择切换账号");
                    //mf.mytap(this._jubing, 563, 26);
                    //mf.mydelay(2000, 4000);
                }
                if (denglu == 1 && t)
                {
                    WriteLog.WriteLogFile(this._mnqName, dlxf.Name);
                    mf.mytap(this._jubing, 425, 303);
                    mf.mydelay(2000, 4000);
                    FuHeSanDian xq = Jingjie_SanDian.GetObject().findFuHeSandianByName("选区-服务器选区界面2");
                    if (mf.mohuByLeiBool(xq.Sd))
                    {
                        WriteLog.WriteLogFile(this._mnqName, xq.Name);
                        mf.mytap(this._jubing, 77, 213);//增加新区要改
                    }
                }
                FuHeSanDian xq1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("选区-服务器选区界面2");
                if (xuanqu == 1 && mf.mohuByLeiBool(xq1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, xq1.Name);
                    mf.mytap(this._jubing, 77, 213);//增加新区要改
                    mf.mydelay(2000, 4000);
                }
                FuHeSanDian qu1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("选区-服务器选1区2");
                if (xuanqu == 1 && mf.mohuByLeiBool(qu1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, qu1.Name);
                    xuanqu = 2;
                    mf.mytap(this._jubing, qu1.Zhidingx, qu1.Zhidingy);
                    mf.mydelay(1000, 3000);
                    mf.mytap(this._jubing, qu1.Zhidingx, qu1.Zhidingy);
                    mf.mydelay(1000, 3000);
                    t = mf.mohuXunHuanJianChi(dlxf.Sd, 60);
                    if (t)
                    {
                        WriteLog.WriteLogFile(this._mnqName, dlxf.Name + "选服成功");
                        mf.mytap(this._jubing, 345, 324);
                        mf.mydelay(2000, 4000);
                    }
                }
                t = mf.mohuXunHuanJianChi(dlxf.Sd, 60);
                if (xuanqu==2 && t)
                {
                    WriteLog.WriteLogFile(this._mnqName, dlxf.Name);
                    mf.mytap(this._jubing, dlxf.Zhidingx, dlxf.Zhidingy);
                    WriteLog.WriteLogFile(this._mnqName, dlxf.Name + "选服成功-最终");
                    denglu = 2;
                }
                SanDian[] sdzu = new SanDian[] { dlxf.Sd, };
                if (denglu == 2 && !mf.mohuqubiaoXunHuan(sdzu, 20 * 1)) {
                    WriteLog.WriteLogFile(this._mnqName, "进入游戏,登录阶段顺利结束");
                    t1 = true;
                    break;
                }
                if (t1) {
                    break;
                }
                if ((js - ks) > 1000 * 60 * fenzhong) {
                    WriteLog.WriteLogFile(this._mnqName, "登录阶段超时");
                    WriteLog.WriteLogFile(this._mnqName, "找到需要练级的账号" + name + " " + pwd + ",xuanqu " + xuanqu + ",恢复为不登录");
                    zhanghao.zhiweidengluzhongN(this._dqinx,"jingjie", name, WriteLog.getMachineName());
                    break;
                }
            }
            return t1;

        }
        
        public Boolean zhuce(int fz,out int dengji,out int xuanqu)
        {
            Boolean zccg = true;
            dengji = 1;
            xuanqu = 1;
            return zccg;
        }

        private void zhituozhuxian(string zhanghao) {
            long kstime = MyFuncUtil.GetTimestamp();
            int yici = 0;
            int youjian = 0;
            int fuli = 0;
            int shibai = 0;
            int jinji = 0;
            int zdrs5 = 0;
            int meirijiangli = 0;
            int jijieshimianfei = 0;
            //设置卡屏相关
            long kp1 = MyFuncUtil.GetTimestamp();
            long kpjishi = MyFuncUtil.GetTimestamp();
            long kp10sjishi = MyFuncUtil.GetTimestamp();
            List<ZuoBiao> kpzb = new List<ZuoBiao>();
            kpzb.Add(new ZuoBiao(220, 48));
            kpzb.Add(new ZuoBiao(407, 136));
            string[] kapingyanse1 = mf.myGetColorWuJbList(kpzb);
            string[] kapingyanse2 = mf.myGetColorWuJbList(kpzb);

            //2小时结束
            long kstime1 = MyFuncUtil.GetTimestamp();

            //得到账号的钻石信息 
            ZhangHao zh = new ZhangHao();
            int ox = -1;
            zh.getZhanghaoXinxi(this._dqinx, "jingjie", zhanghao, "zuanshi", out ox);
            int zuanshi = ox;

            //是否开局强化
            int kjqh = 0;
            if (zuanshi > 0) {
                kjqh = 1;
            }
            while (true)
            {
                if (yici == 0) {
                    yici = 1;
                    WriteLog.WriteLogFile(this._mnqName, "进入开局号,开始练级");
                }
                var jstime = MyFuncUtil.GetTimestamp();
                if ((jstime - kstime) > 60 * 1000 * 20)
                {
                    //20分钟重新计时
                    kstime = MyFuncUtil.GetTimestamp();
                    WriteLog.WriteLogFile(this._mnqName, "20分钟重新计时");
                }
                if ((jstime - kstime1) > 60 * 1000 * 60*2)
                {
                    WriteLog.WriteLogFile(this._mnqName, "2小时结束");
                    break;
                }
                if ((jstime - kpjishi) > 30 * 1000 && compareColor(kapingyanse1, kapingyanse2))
                {
                    //调用卡屏函数                   
                    if (panduankaping(kp1,zhanghao))
                    {
                        break;
                    }
                }
                if ((jstime - kp10sjishi) > 10 * 1000)
                {
                    kp10sjishi = MyFuncUtil.GetTimestamp();
                    kapingyanse2 = mf.myGetColorWuJbList(kpzb);
                    //WriteLog.WriteLogFile(this._mnqName, "10秒颜色 " + kapingyanse1[0] + " " + kapingyanse2[0] + "  " + kapingyanse1[1] + " " + kapingyanse2[1]);
                }
                if ((jstime - kpjishi) > 30 * 1000 && !compareColor(kapingyanse1, kapingyanse2))
                {
                    //颜色不等 30秒更新颜色 更新计时
                    WriteLog.WriteLogFile(this._mnqName, "30秒颜色不等时,更新颜色" + kapingyanse1[0] + " " + kapingyanse2[0] + "  " + kapingyanse1[1] + " " + kapingyanse2[1]);
                    kapingyanse1 = mf.myGetColorWuJbList(kpzb);
                    kpjishi = MyFuncUtil.GetTimestamp();
                    kp1 = MyFuncUtil.GetTimestamp();
                }
                List<FuHeSanDian> ls = Jingjie_SanDian.GetObject().findListFuHeSandianByName("引导");
                if (ls != null && ls.Count > 0)
                {
                    foreach (FuHeSanDian fh in ls)
                    {
                        if (mf.mohuByLeiBool(fh.Sd))
                        {
                            WriteLog.WriteLogFile(this._mnqName, fh.Name);
                            if (fh.Zhidingx != -1 && fh.Zhidingy != -1)
                            {
                                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                            }

                        }
                    }
                }


                FuHeSanDian ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("互换位置");
                if (mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, "互换位置" + ktsd1.Name);
                    mf.mydrag(this._jubing, 317, 266, 340, 182);
                }

                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("使用超绝技能");
                if (mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, "使用超绝技能" + ktsd1.Name);
                    mf.mydrag(this._jubing, 495, 359, 481, 268);
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("灵子剑雨");
                if (mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, "灵子剑雨" + ktsd1.Name);
                    mf.mydrag(this._jubing, 432, 360, 435, 280);
                }
                int x = -1, y = -1;
                FuHeDuoDian sz = Jingjie_DuoDian.GetObject().findFuHeDuodianByName("跳过");
                mf.myqudianqusezuobiaoByLeiWuJubing(sz.Dz, out x, out y);
                if (x != -1 && y != -1)
                {
                    WriteLog.WriteLogFile(this._mnqName, sz.Name + x + " " + y);
                    mf.mytap(this._jubing, x, y);
                }
                sz = Jingjie_DuoDian.GetObject().findFuHeDuodianByName("跳过2");
                mf.myqudianqusezuobiaoByLeiWuJubing(sz.Dz, out x, out y);
                if (x != -1 && y != -1)
                {
                    WriteLog.WriteLogFile(this._mnqName, sz.Name + x + " " + y);
                    mf.mytap(this._jubing, x, y);
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-主界面");
                if (kjqh == 1 && mf.mohuXunHuanJianChi(ktsd1.Sd, 15))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name + "准备领取满月礼");
                    if (mf.mohu(398, 45, 0xba8b54) == 1)
                    {
                        mf.mytap(this._jubing, 398, 45);
                        mf.mydelay(2000, 4000);
                        ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-领取满月礼");
                        if (mf.mohuByLeiBool(ktsd1.Sd))
                        {
                            WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                            compareSandianAndtap(ktsd1, 2000, () => mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy),
                            () =>mf.mytap(this._jubing, 613, 125)                           
                            ); 
                           
                        }
                        //kjqh++;
                    }
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-领取满月礼");
                if (mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    compareSandianAndtap(ktsd1, 2000, () => mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy),
                    () => mf.mytap(this._jubing, 613, 125)
                    );

                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-主界面");
                if (kjqh == 1 && mf.mohuXunHuanJianChi(ktsd1.Sd, 15))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name+"准备搞角色强化");
                    mf.mytap(this._jubing, 480, 356);
                    mf.mydelay(2000, 4000);
                    ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-角色强化");
                    if (mf.mohuByLeiBool(ktsd1.Sd))
                    {
                        qianghua();
                    }
                    //kjqh++;
                }

                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-集结--购买1次");
                if (mf.mohuByLeiBool(ktsd1.Sd))
                {
                    ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-集结石中免费");
                    if (mf.mohuByLeiBool(ktsd1.Sd))
                    {
                        mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                        mf.mydelay(2000, 3000);
                        jijieshimianfei++;
                    }                    
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-主界面");
                if (youjian==0 && mf.mohuXunHuanJianChi(ktsd1.Sd, 20))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    mf.mytap(this._jubing,661,173);
                    mf.mydelay(2000, 4000);
                    ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("邮件-搞邮件");
                    if (mf.mohuXunHuanJianChi(ktsd1.Sd, 20))
                    {
                        compareSandianAndtap(ktsd1, 2000, () => mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy),
                        () =>
                        {
                            mf.mytap(this._jubing, 646, 16);
                            youjian++;
                        }); 
                    }
                    
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("邮件-搞邮件");
                if (mf.mohuXunHuanJianChi(ktsd1.Sd, 20))
                {
                    compareSandianAndtap(ktsd1, 2000, () => mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy),
                        () =>
                        {
                            mf.mytap(this._jubing, 646, 16);
                            youjian++;
                        }); 
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-集结石界面");
                if (jijieshimianfei == 0 && mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-集结石中免费");
                    if (mf.mohuByLeiBool(ktsd1.Sd))
                    {
                        mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                        mf.mydelay(2000, 3000);
                    }
                    jijieshimianfei++;
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-主界面");
                if (jijieshimianfei==0 && mf.mohuXunHuanJianChi(ktsd1.Sd, 15))
                {
                    WriteLog.WriteLogFile(this._mnqName, "当前主界面,开始搞强者券");
                    mf.mytap(this._jubing, 581, 357);
                    mf.mydelay(4000, 6000);
                    ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-集结石界面");
                    if (mf.mohuByLeiBool(ktsd1.Sd))
                    {
                        if (jijieshimianfei == 0 && mf.mohuByLeiBool(ktsd1.Sd))
                        {
                            WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                            ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-集结石中免费");
                            if (mf.mohuByLeiBool(ktsd1.Sd))
                            {
                                mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                                mf.mydelay(2000, 3000);                                
                            }
                        }
                        jijieshimianfei++;
                    }
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-集结石界面");
                if (jijieshimianfei>0 && mf.mohuXunHuanJianChi(ktsd1.Sd, 20))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-集结石中免费");
                    if (mf.mohuByLeiBool(ktsd1.Sd))
                    {
                        mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                        mf.mydelay(2000, 3000);
                    }
                    jijieshimianfei++;                   
                    mf.mytap(this._jubing, 645, 15);
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-主界面");
                if (fuli<2 && mf.mohuXunHuanJianChi(ktsd1.Sd, 20))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    mf.mytap(this._jubing, 569,48);
                    mf.mydelay(2000, 4000);
                    ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("福利-升级有礼");
                    if (mf.mohuXunHuanJianChi(ktsd1.Sd, 20))
                    {
                        mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                        mf.mydelay(2000, 3000);
                        if (mf.mohu(471, 161, 0xc48141) == 1)
                        {
                            mf.mytap(this._jubing, 471, 161);
                        }
                        if (mf.mohu(470, 244, 0xc38545) == 1)
                        {
                            mf.mytap(this._jubing, 470, 244);
                        }
                        fuli++;
                    }
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("福利-升级有礼");
                if (mf.mohuXunHuanJianChi(ktsd1.Sd, 20))
                {
                    mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                    mf.mydelay(2000, 3000);
                    if (mf.mohu(471, 161, 0xc48141) == 1)
                    {
                        mf.mytap(this._jubing, 471, 161);
                    }
                    if (mf.mohu(470, 244, 0xc38545) == 1)
                    {
                        mf.mytap(this._jubing, 470, 244);
                    }
                    compareSandianAndtap(ktsd1, 2000, () => mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy),
                        () =>
                        {
                            mf.mytap(this._jubing, 642, 43);
                            fuli++;
                        });
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-主界面");
                if (meirijiangli == 0 && mf.mohuXunHuanJianChi(ktsd1.Sd, 20))
                {
                     ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-首充不打开");
                     if (mf.mohuXunHuanJianChi(ktsd1.Sd, 20))
                     {
                         meirijiangli=1;
                     }
                    if(meirijiangli==0){
                        WriteLog.WriteLogFile(this._mnqName, ktsd1.Name+"搞奖励");
                        mf.mytap(this._jubing, 487, 47);
                        mf.mydelay(2000, 4000);
                        ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-每日奖励开启----可以换号");
                        if (mf.mohuByLeiBool(ktsd1.Sd))
                        {
                            compareSandianAndtap(ktsd1, 2000, () =>
                            {
                                mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                                mf.mydelay(1000, 2000);
                                mf.mytap(this._jubing, 390, 360);
                                mf.mydelay(1000, 2000);
                                mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                                mf.mydelay(1000, 2000);
                                mf.mytap(this._jubing, 390, 360);
                                mf.mydelay(1000, 2000);
                                mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                                mf.mydelay(1000, 2000);
                                mf.mytap(this._jubing, 390, 360);
                                mf.mydelay(4000, 6000);
                            },
                            () =>
                            {
                                mf.mytap(this._jubing, 633, 40);
                                meirijiangli = 1;
                            });
                            
                        }
                    }
                    ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-第3天送啥");
                    if (meirijiangli==0 && mf.mohuByLeiBool(ktsd1.Sd))
                    {
                        compareSandianAndtap(ktsd1, 2000, () =>
                        {
                            mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                            mf.mydelay(1000, 2000);
                            mf.mytap(this._jubing, 390, 360);
                            mf.mydelay(1000, 2000);
                            mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                            mf.mydelay(1000, 2000);
                            mf.mytap(this._jubing, 390, 360);
                            mf.mydelay(1000, 2000);
                            mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                            mf.mydelay(1000, 2000);
                            mf.mytap(this._jubing, 390, 360);
                            mf.mydelay(4000, 6000);
                        },
                        () =>
                        {
                            mf.mytap(this._jubing, 633, 40);
                            meirijiangli = 1;
                        });
                       
                    }
                    ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-2天送礼");
                    if (meirijiangli == 0 && mf.mohuByLeiBool(ktsd1.Sd))
                    {
                        compareSandianAndtap(ktsd1, 2000, () =>
                        {
                            mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                            mf.mydelay(1000, 2000);
                            mf.mytap(this._jubing, 390, 360);
                            mf.mydelay(1000, 2000);
                            mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                            mf.mydelay(1000, 2000);
                            mf.mytap(this._jubing, 390, 360);
                            mf.mydelay(1000, 2000);
                            mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                            mf.mydelay(1000, 2000);
                            mf.mytap(this._jubing, 390, 360);
                            mf.mydelay(4000, 6000);
                        },
                        () =>
                        {
                            mf.mytap(this._jubing, 633, 40);
                            meirijiangli = 1;
                        });

                    }
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-每日奖励开启----可以换号");
                if (meirijiangli == 0 && mf.mohuByLeiBool(ktsd1.Sd))
                {
                    compareSandianAndtap(ktsd1, 2000, () =>
                    {
                        mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                        mf.mydelay(1000, 2000);
                        mf.mytap(this._jubing, 390, 360);
                        mf.mydelay(1000, 2000);
                        mf.mytap(this._jubing, 423, 319);
                        mf.mydelay(1000, 2000);
                        mf.mytap(this._jubing, 390, 360);
                        mf.mydelay(1000, 2000);
                        mf.mytap(this._jubing, 550, 322);
                        mf.mydelay(1000, 2000);
                        mf.mytap(this._jubing, 390, 360);
                        mf.mydelay(4000, 6000);
                    },
                        () =>
                        {
                            mf.mytap(this._jubing, 633, 40);
                            meirijiangli = 1;
                        });
                    
                }
                
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-第3天送啥");
                if (meirijiangli == 0 && mf.mohuByLeiBool(ktsd1.Sd))
                {
                    compareSandianAndtap(ktsd1, 2000, () =>
                    {
                        mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                        mf.mydelay(1000, 2000);
                        mf.mytap(this._jubing, 390, 360);
                        mf.mydelay(1000, 2000);
                        mf.mytap(this._jubing, 423, 319);
                        mf.mydelay(1000, 2000);
                        mf.mytap(this._jubing, 390, 360);
                        mf.mydelay(1000, 2000);
                        mf.mytap(this._jubing, 550, 322);
                        mf.mydelay(1000, 2000);
                        mf.mytap(this._jubing, 390, 360);
                        mf.mydelay(4000, 6000);
                    },
                        () =>
                        {
                            mf.mytap(this._jubing, 633, 40);
                            meirijiangli = 1;
                        });                    
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-2天送礼");
                if (meirijiangli == 0 && mf.mohuByLeiBool(ktsd1.Sd))
                {
                    compareSandianAndtap(ktsd1, 2000, () =>
                    {
                        mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                        mf.mydelay(1000, 2000);
                        mf.mytap(this._jubing, 390, 360);
                        mf.mydelay(1000, 2000);
                        mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                        mf.mydelay(1000, 2000);
                        mf.mytap(this._jubing, 390, 360);
                        mf.mydelay(1000, 2000);
                        mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                        mf.mydelay(1000, 2000);
                        mf.mytap(this._jubing, 390, 360);
                        mf.mydelay(4000, 6000);
                    },
                    () =>
                    {
                        mf.mytap(this._jubing, 633, 40);
                        meirijiangli = 1;
                    });

                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-升5级");
                if (mf.mohuByLeiBool(ktsd1.Sd))
                {
                    compareSandianAndtap(ktsd1, 2000, () => mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy),
                        () =>
                        {
                           mf.mytap(this._jubing, 646, 16);
                        });
                    if (mf.mohuByLeiBool(ktsd1.Sd)) {
                        mf.mytap(this._jubing, 646, 192);
                    }
                };
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-进击--目的开启每日奖励");
                if ((jinji == 0) && mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-角色界面有5人");
                if (mf.mohuXunHuanJianChi(ktsd1.Sd, 20))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-上阵人数不足");
                if ((zdrs5 == 0) && mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                    mf.mydelay(3000, 4000);
                    mf.mytap(this._jubing, 43, 344);
                    zdrs5 = 1;
                }

                if ((zdrs5 == 1) && mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    mf.mytap(this._jubing, 411, 251);
                }

                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-空邮箱返回");
                if (mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                    youjian++;
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-第五个人数");
                if ((zdrs5 == 0) && mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    mf.mytap(this._jubing, 43,344);
                    zdrs5=1;
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-关卡3-7");
                if (kjqh == 0 && mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                    mf.mydelay(1000, 2000);
                    break;
                }
                if (kjqh == 1 && mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    mf.mytap(this._jubing, 530, 176);
                    mf.mydelay(1000, 2000);
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-关卡3-6");
                if (kjqh == 0 &&  mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                    mf.mydelay(1000, 2000);
                    break;
                }
                if (kjqh == 1 && mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    mf.mytap(this._jubing, 470, 97);
                    mf.mydelay(1000, 2000);
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-关卡3-6第二次");
                if (kjqh == 0 && mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    mf.mydelay(1000, 2000);
                    break;
                }
                if (kjqh == 1 && mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    mf.mytap(this._jubing, 470, 97);
                    mf.mydelay(1000, 2000);
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-关卡3-6第3次");
                if (kjqh == 0 && mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    mf.mydelay(1000, 2000);
                    break;
                }
                if (kjqh == 1 && mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    mf.mytap(this._jubing, 470, 97);
                    mf.mydelay(1000, 2000);
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-关卡3-7第二次");
                if (kjqh == 0 && mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    mf.mydelay(1000, 2000);
                    break;
                }
                if (kjqh == 1 && mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    mf.mytap(this._jubing, 530, 176);
                    mf.mydelay(1000, 2000);
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-战斗失败");
                if ((shibai==0 || shibai==1) && mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                    shibai++;
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-主界面");
                if (jinji == 1 && mf.mohuXunHuanJianChi(ktsd1.Sd, 20)) {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name + " "+jinji+" 此处退出了");
                    break;
                }
                if (shibai >= 2)
                {
                    WriteLog.WriteLogFile(this._mnqName, "失败两次,退出");
                    break;
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-关卡界面关闭");
                if (shibai >= 2 && mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name + " " + jinji + " 此处退出了");
                    jinji = 1;
                    mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-账号被顶");
                if (mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    break;
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-主关卡3-8");
                if (mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    break;
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-主关卡3-8-2次");
                if (mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    break;
                }
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-体力终结");
                if (mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                    mf.mydelay(3000, 5000);
                    mf.mytap(this._jubing, 651, 14);
                    mf.mydelay(3000, 5000);
                    break;
                }

                if (panduanjiemian("界面-战斗界面"))
                {
                    ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("引导-战斗打开X2");
                    if (mf.mohuByLeiBool(ktsd1.Sd))
                    {
                        WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                        mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);                       
                    }
                    ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("引导-战斗打开自动");
                    if (mf.mohuByLeiBool(ktsd1.Sd))
                    {
                        WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                        mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);                        
                    }
                }
            }
        }

        public void qushufrombaidu(out int qushu,FuHeSanDian qz,int x1,int y1,int x2,int y2,int x3,int y3,int x3w,int y3h,string a="默认")
        {
            WriteLog.WriteLogFile(this._mnqName, qz.Name+"进入百度识别取数"+a);
            qushu = -1;
            if (mf.mohuByLeiBool(qz.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, qz.Name+" 截图取数");
                string filename = this._dqinx + "_" + mf.GetTime() + ".bmp";
                mf.captureBmp(this._jubing, @"c:\mypic_save\", filename, x1, y1, x2, y2);
                if (mf.IsFileExist(@"c:\mypic_save\" + filename) == 1)
                {
                    string r = generalBasicShuziDemo(this._dqinx, @"c:\mypic_save\" + filename);
                    if (r != null && r != "")
                    {
                        qushu = int.Parse(r);
                        WriteLog.WriteLogFile(this._mnqName," 截图取数的结果"+qushu);
                    }
                }
            }
            if (qushu==-1 && mf.mohuByLeiBool(qz.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, qz.Name+" 高清图取数");
                string timestamp = mf.GetTime()+"";
                string mydir1=@"c:\mypic_save\"+timestamp+".png";
                MyLdcmd.myScreencap(this._dqinx, mydir1);
                Bitmap f = MyFuncUtil.ReadImageFile(mydir1); 
                if (f != null) {
                    WriteLog.WriteLogFile(this._mnqName, "");
                    Bitmap g = MyFuncUtil.KiCut(f, x3, y3, x3w, y3h);
                    g.Save(@"C:\mypic_save\" + timestamp + "_1.jpg");
                    g.Dispose();
                }
                if (File.Exists(@"C:\mypic_save\" + timestamp + "_1.jpg"))
                {
                    string r = generalBasicShuziDemo(this._dqinx, @"c:\mypic_save\" + timestamp + "_1.jpg");
                    if (r != null && r != "")
                    {
                        qushu = int.Parse(r);
                        WriteLog.WriteLogFile(this._mnqName, " 高清取数的结果" + qushu);
                    }
                }
                mf.mydelay(2000, 4000);
            }
        }


        
        public int getMyDqindex()
        {
            return this._dqinx;
        }

        public xDm getMyDm()
        {
            return this.mf;
        }

        
        

        

        public void tiaoguo()
        {
            
        }

        

        public void fuben()
        { 
        }
        public void jiangli()
        {
        }

        public bool zhuce(int fz)
        {
            return false;
        }
        public void richang()
        {
        }
        private bool panduankaping(long kp1,string zhanghao)
        {
            bool rs = false;
            long kp2 = MyFuncUtil.GetTimestamp();
            if ((kp2 - kp1) > 1000 * 40)
            {
               
            }
            if ((kp2 - kp1) > 1000 * 20)
            {
                
            }
            if ((kp2 - kp1) > 1000 * 60*10)
            {
                WriteLog.WriteLogFile(this._mnqName,"卡屏10分钟");
                string path = @"c:\mypic_save\";
                string name = "卡屏" + this._dqinx + "_" + mf.GetTime() + ".bmp";
                mf.captureBmp(this._jubing, path, name);
                Thread.Sleep(10000);
                int res = panduankasiqudian();
                if (res == 0) {
                    WriteLog.WriteLogFile(this._mnqName, "卡屏且无任何已取点");
                    path = @"d:\mypic_save\";
                    name = "卡屏" + this._dqinx + "_" + zhanghao + ".bmp";
                    if (!File.Exists(path + name)) {
                        mf.captureBmp(this._jubing, path, name);
                    }
                    ZhangHao zh = new ZhangHao();
                    zh.zhiweiwuxiao(this._dqinx, "jingjie", zhanghao, WriteLog.getMachineName());
                }
                rs = true;
            }
            return rs;
        }

        private int panduankasiqudian() {
            int res = 0;
            for (int i = 0; i < 10; i++)
            {
                foreach (FuHeSanDian f in Jingjie_SanDian.List_yqfhsandian)
                {
                    if (mf.mohuByLeiBool(f.Sd))
                    {
                        MyFuncUtil.mylogandxianshi(f.Name + "模糊取到");
                        //mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                        mf.mydelay(1000, 2000);
                        res++;
                    }
                    if (mf.jingqueByLeiBool(f.Sd))
                    {
                        MyFuncUtil.mylogandxianshi(f.Name + "精确取到");
                        mf.mydelay(1000, 2000);
                        res++;
                    }
                }
                mf.mydelay(10, 200);
            }
            return res;
        }


        private bool panduanzhandou(SanDian sd)
        {
            bool rs = false;
            long dqsj = MyFuncUtil.GetTimestamp();
            if (mf.mohuByLei(sd) == 1)
            {
                zdsj = MyFuncUtil.GetTimestamp();
            }
            if ((dqsj - zdsj) > 1000 * 60 * 15)
            {
                WriteLog.WriteLogFile(this._mnqName,"15分钟未战斗");
                string path = @"c:\mypic_save\";
                string name = this._dqinx + "_" + mf.GetTime() + ".bmp";
                mf.captureBmp(this._jubing, path, name);
                rs = true;
            }
            return rs;
        }


        public void zhuxian(string name)
        {
            WriteLog.WriteLogFile(this._mnqName, "进入到主线任务");
            zhituozhuxian(name);
            quitdq(name);
            WriteLog.WriteLogFile(this._mnqName, "主线退出");
        }

        private void compareColorAndtap(List<ZuoBiao> kpzb, int ms, Action thentap1,Action thentap2)
        {
            string[] kapingyanse1 = mf.myGetColorWuJbList(kpzb);
            string[] kapingyanse2 = kapingyanse1;
            WriteLog.WriteLogFile(this._mnqName, "准备比较颜色");
            thentap1();
            mf.mydelay(ms, ms+1000);
            kapingyanse2 = mf.myGetColorWuJbList(kpzb);
            if (!compareColor(kapingyanse1, kapingyanse2))
            {
                thentap2();
            }            
        }

        private void compareSandianAndtap(FuHeSanDian fhsd, int ms, Action thentap1, Action thentap2)
        {
            WriteLog.WriteLogFile(this._mnqName, "比较画面 "+fhsd.Name);
            thentap1();
            if (!mf.mohuByLeiBool(fhsd.Sd))
            {
                return;
            }
            mf.mydelay(ms, ms + 1000);
            if (mf.mohuByLeiBool(fhsd.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, "比较画面不消失 " + fhsd.Name);
                thentap2();
            }
        }

        private bool compareColor(string[] kapingyanse1, string[] kapingyanse2) {
            if (kapingyanse1 != null && kapingyanse1.Length == 2
               && kapingyanse2 != null && kapingyanse2.Length == 2)
            {
                if (kapingyanse1[0].ToLower().Equals(kapingyanse2[0].ToLower())) {
                    return true;
                }
                if (kapingyanse1[1].ToLower().Equals(kapingyanse2[1].ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        private void zhuxianrenwu() {
            var kstime = MyFuncUtil.GetTimestamp();            
            int shibai = 0;
            int zaicishibai = 0;        
            //设置战斗初始点
            zdsj = MyFuncUtil.GetTimestamp();
            //设置卡屏相关
            long kp1 = MyFuncUtil.GetTimestamp();
            long kpjishi = MyFuncUtil.GetTimestamp();
            long kp10sjishi = MyFuncUtil.GetTimestamp();
            List<ZuoBiao> kpzb = new List<ZuoBiao>();
            kpzb.Add(new ZuoBiao(220, 48));
            kpzb.Add(new ZuoBiao(407, 136));

            string[] kapingyanse1 = mf.myGetColorWuJbList(kpzb);
            string[] kapingyanse2 = mf.myGetColorWuJbList(kpzb);
            while (true)
            {
                
                tiaoguo();                           
                
                jinruzhandou(out shibai);
                var jstime = MyFuncUtil.GetTimestamp();
                if ((jstime - kstime) > 60 * 1000 * 20) {
                    //20分钟重新计时
                    kstime = MyFuncUtil.GetTimestamp();
                    WriteLog.WriteLogFile(this._mnqName, "20分钟重新计时");
                }
                if ((jstime - kpjishi) > 30 * 1000 && compareColor(kapingyanse1, kapingyanse2))
                { 
                    //调用卡屏函数                   
                    if (panduankaping(kp1,""))
                    {
                        break;
                    }
                }
                if ((jstime - kp10sjishi) > 10 * 1000)
                {
                    kp10sjishi = MyFuncUtil.GetTimestamp();
                    kapingyanse2 = mf.myGetColorWuJbList(kpzb);
                    //WriteLog.WriteLogFile(this._mnqName, "10秒颜色 " + kapingyanse1[0] + " " + kapingyanse2[0] + "  " + kapingyanse1[1] + " " + kapingyanse2[1]);
                }
                if ((jstime - kpjishi) > 30 * 1000 && !compareColor(kapingyanse1,kapingyanse2))
                {
                    //颜色不等 30秒更新颜色 更新计时
                    WriteLog.WriteLogFile(this._mnqName, "30秒颜色不等时,更新颜色" + kapingyanse1[0] + " " + kapingyanse2[0]+"  "+ kapingyanse1[1] + " " + kapingyanse2[1]);
                    kapingyanse1 = mf.myGetColorWuJbList(kpzb);
                    kpjishi = MyFuncUtil.GetTimestamp();
                    kp1 = MyFuncUtil.GetTimestamp();
                }
                
                
                if (shibai==1 && zaicishibai<2) {
                    WriteLog.WriteLogFile(this._mnqName,"战斗第一次失败,进入到角色强化循环");
                    qianghua();
                    lingqu();
                    zhaozhujiemian(20 * 1000);
                    zaicishibai ++;
                }
            }
        }

        
        public void quitdq(string name)
        {
            WriteLog.WriteLogFile(this._mnqName, "进入到准备保存退出阶段");
            long ks = MyFuncUtil.GetTimestamp();
            int jiemian = 0;
            FuHeSanDian fh = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-主界面");
            while (true) {
                //mf.mytap(this._jubing, 466, 366);
                long js = MyFuncUtil.GetTimestamp();
                if ((js - ks) > 1000 * 20) {
                    break;
                }
                fh = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-主界面");
                if (mf.mohuXunHuanJianChi(fh.Sd, 15)) {
                    jiemian = 1;
                    break;
                }
                fh = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-关卡界面");
                if (mf.mohuXunHuanJianChi(fh.Sd, 15))
                {
                    jiemian = 2;
                    break;
                }
            }
            if (jiemian == 2) {
                //一键领取
                FuHeSanDian fh11 = Jingjie_SanDian.GetObject().findFuHeSandianByName("引导-关卡一件领取");
                if (mf.mohuByLeiBool(fh11.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, fh11.Name);
                    mf.mytap(this._jubing, fh11.Zhidingx, fh11.Zhidingy);
                    mf.mydelay(2000, 4000);
                }
                fh = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-关卡界面");
                long ksgk = MyFuncUtil.GetTimestamp();
                while (true)
                {
                    List<FuHeSanDian> fhh = Jingjie_SanDian.GetObject().findListFuHeSandianByName("引导-关卡一件");
                    if (!mf.mohuXunHuanJianChi(fh.Sd, 15))
                    {
                        foreach (FuHeSanDian f in fhh)
                        {
                            if (!mf.mohuXunHuanJianChi(fh.Sd, 15) && !f.Name.Equals("引导-关卡一件领取"))
                            {
                                WriteLog.WriteLogFile(this._mnqName, f.Name);
                                mf.mytap(this._jubing, f.Zhidingx, f.Zhidingy);
                                mf.mydelay(2000, 4000);
                            }
                        }
                        mf.mytap(this._jubing, 463, 336);
                    }
                    if (mf.mohuXunHuanJianChi(fh.Sd, 15))
                    {
                        break;
                    }
                    long jsgk = MyFuncUtil.GetTimestamp();
                    if ((jsgk - ksgk) > 1000 * 60 *3)
                    {
                        break;
                    }
                }
                //消耗完所有体力
                fh11 = Jingjie_SanDian.GetObject().findFuHeSandianByName("关卡-3消耗体力");
                if (mf.mohuByLeiBool(fh11.Sd)) {
                    WriteLog.WriteLogFile(this._mnqName, fh11.Name);
                    long ks1 = MyFuncUtil.GetTimestamp();
                    int z = 0;
                    int jin=0;
                    while (true)
                    {
                        if(jin==0){
                            mf.mytap(this._jubing, 210, 218);//搞3-3
                            mf.mydelay(2000, 4000);
                        }
                        fh11 = Jingjie_SanDian.GetObject().findFuHeSandianByName("关卡-3具体消耗界面");
                        if (mf.mohuByLeiBool(fh11.Sd))
                        {
                            jin=1;
                        }
                        long js1 = MyFuncUtil.GetTimestamp();
                        if ((js1 - ks1) > 1000 * 60 * 5)
                        {
                            break;
                        }
                        mf.mytap(this._jubing, 463, 336);
                        mf.mydelay(300, 600);
                        FuHeSanDian ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-体力终结");
                        if (mf.mohuByLeiBool(ktsd1.Sd))
                        {
                            WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                            mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                            z = 1;
                        }
                        if (z == 1) {
                            mf.mytap(this._jubing, 649, 15);
                        }
                        if (mf.mohuXunHuanJianChi(Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-主界面").Sd, 15))
                        {
                            jiemian = 1;
                            break;
                        }
                    }                    
                }                
            }            
            int dengji = -1;
            int zuanshi = -1;
            int qiangzhequan = -1;
            fh = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-主界面");
            FuHeSanDian fh2 = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-关卡界面");
            if (jiemian == 1)
            {
                qushufrombaidu(out zuanshi, fh, 531, 3, 580, 25,511, 756, 20, 60,"主界面取数");
                WriteLog.WriteLogFile(this._mnqName, "取数结果zuanshi=" + zuanshi);
            }
            if (jiemian == 2)
            {
                qushufrombaidu(out zuanshi, fh2, 531, 5, 580, 25, 511, 756, 20, 60,"关卡取数");
                WriteLog.WriteLogFile(this._mnqName, "取数结果zuanshi=" + zuanshi);
            }
            if (jiemian == 0)
            {
                mf.mytap(this._jubing, 646, 14);
                mf.mydelay(2000, 3000);
            }
            if (!mf.mohuByLeiBool(fh.Sd) && !mf.mohuByLeiBool(fh2.Sd) && zuanshi==-1)
            {
                string filename = this._dqinx + "退出时钻石" + name + ".bmp";
                WriteLog.WriteLogFile(this._mnqName, "保存退出未能截到钻石" + filename);
                mf.captureBmp(this._jubing, @"c:\mypic_save", filename);           
                WriteLog.WriteLogFile(this._mnqName, "钻石数没搞到");
            }
            if (jiemian == 2) {
                WriteLog.WriteLogFile(this._mnqName, "退出到主界面搞强者");
                mf.mytap(this._jubing, 646, 14);
                mf.mydelay(6000, 8000);
            }
            fh = Jingjie_SanDian.GetObject().findFuHeSandianByName("引导-不降低分辨率");
            if (mf.mohuByLeiBool(fh.Sd)){
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                mf.mydelay(2000, 3000);
            }
            fh = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-主界面");
            if (mf.mohuXunHuanJianChi(fh.Sd, 15))
            {
                WriteLog.WriteLogFile(this._mnqName, "当前主界面,开始搞强者券");
                mf.mytap(this._jubing, 581, 357);
                mf.mydelay(4000, 6000);
                fh = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-集结石界面");
                if (mf.mohuByLeiBool(fh.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, fh.Name);
                    FuHeSanDian ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-集结石中免费");
                    if (mf.mohuByLeiBool(ktsd1.Sd))
                    {
                        mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                        mf.mydelay(2000, 3000);
                        long ksjijie = MyFuncUtil.GetTimestamp();
                        while (true) {
                            long jsjijie = MyFuncUtil.GetTimestamp();
                            if ((jsjijie - ksjijie) > 1000 * 30) {
                                break;
                            }
                            ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-集结石中免费");
                            if (mf.mohuByLeiBool(ktsd1.Sd))
                            {
                                mf.mytap(this._jubing, ktsd1.Zhidingx, ktsd1.Zhidingy);
                                mf.mydelay(1000, 2000);
                            }
                            if (!mf.mohuByLeiBool(fh.Sd))
                            {
                                mf.mytap(this._jubing, 646, 13);
                                mf.mydelay(1000, 2000);
                            }                            
                            if (mf.mohuXunHuanJianChi(fh.Sd,12))
                            {
                                break;
                            }
                        }
                    }                    
                    if (mf.mohu(235, 319, 0x31b1a1) == 1)
                    {
                        qushufrombaidu(out qiangzhequan, fh, 219, 309, 256, 324, 87, 338, 20, 20,"集结石取数");
                        WriteLog.WriteLogFile(this._mnqName, "取数结果qiangzhequan=" + qiangzhequan);
                    }
                }
                if (qiangzhequan == -1)
                {
                    string filename = this._dqinx + "退出时强者" + name + ".bmp";
                    WriteLog.WriteLogFile(this._mnqName, "保存退出未能截到强者券" + filename);
                    mf.captureBmp(this._jubing, @"c:\mypic_save", filename);
                    WriteLog.WriteLogFile(this._mnqName, "强者券没搞到");
                }
            }
            WriteLog.WriteLogFile(this._mnqName, "强者券 "+qiangzhequan+",钻石 "+zuanshi);
            ZhangHao zhanghao = new ZhangHao();
            zhanghao.tuichusaveNameAndPas(name,this._dqinx, WriteLog.getMachineName(), dengji, zuanshi, qiangzhequan);
        }

        private void quqiangzhequan(out int qzs,FuHeSanDian qz){
            qzs = -1;
            if (mf.mohuByLeiBool(qz.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, qz.Name);
                string filename = this._dqinx + "_" + mf.GetTime() + ".bmp";
                mf.captureBmp(this._jubing, @"c:\mypic_save\", filename, 380, 63, 416, 80);
                if (mf.IsFileExist(@"c:\mypic_save\" + filename) == 1)
                {
                    string r = generalBasicShuziDemo(this._dqinx, @"c:\mypic_save\" + filename);
                    if (r != null && r != "")
                    {
                        qzs = int.Parse(r);
                    }
                }
                mf.mydelay(2000, 4000);
            }
        }

        private void dianjizhuxianzhixian() {
            
            mf.mytap(this._jubing, 17, 46);
            
        }

        private void zuorenwutishi() {
            int x=-1,y=-1;
            DuoDianZhaoSe dz = new DuoDianZhaoSe(0xcaa547, "-6|0|0x8b661b,-12|0|0xffdb21,-13|-3|0xffdb21,-13|2|0xffcf1a,-1|2|0xffda2f,10|-1|0xffd018", 90, 115, 85, 155, 110);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"主线任务提示");
                mf.mytap(this._jubing, x, y);
            }
            dz = new DuoDianZhaoSe(0xffcf18, "4|0|0xffdb21,4|3|0xffdb21,-1|3|0xffcf18,-1|5|0xffcf18,6|6|0xffdb21,12|6|0xffd72b", 90, 0, 0, 215, 121);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"支线领取");
                mf.mytap(this._jubing, x+7, y+5);
                zhaozhujiemian(15*1000);
            }
            
            dz = new DuoDianZhaoSe(0xf24f35, "11|1|0xffedd4,18|1|0xf5e6e4,24|1|0xeacac6,23|-3|0xad0408,15|-3|0xc61410,15|4|0xdd9790", 90, 165, 95, 215, 121);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"一键上阵提示");
                mf.mytap(this._jubing, 193, 85);
                mf.mydelay(2000, 4000);
                mf.mytap(this._jubing, x, y);
            }
            dz = new DuoDianZhaoSe(0x615f61, "-6|0|0xe8e9e8,-7|-3|0xe6a700,-8|1|0xf33a27,-2|4|0xdad8da,7|1|0xcccdcc,11|0|0x111111", 90, 0, 0, 40, 10);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"协会竞技必点");
                mf.mytap(this._jubing, 153, 21);
                mf.mydelay(2000, 4000);
                mf.mytap(this._jubing, 168, 32);
                mf.mydelay(2000, 4000);
                mf.mytap(this._jubing, 189, 16);
                mf.mydelay(2000, 4000);
                mf.mytap(this._jubing, 207, 4);
                mf.mydelay(2000, 4000);
                mf.mytap(this._jubing, 207, 4);
            }
            dz = new DuoDianZhaoSe(0x6e4c29, "0|-1|0x6a4727,0|1|0x9d7d40,-5|1|0xe7cb63,-13|0|0x13a0e0,-14|-1|0x0891d5,-44|-87|0xd2d1d2,-50|-88|0xef3c31,-55|-83|0xdc3421", 90, 5, 0, 75, 95);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, "出现购买提示,购买0钻石体力");
                mf.mytap(this._jubing, x, y);
                mf.mydelay(2000, 4000);
                WriteLog.WriteLogFile(this._mnqName, "0钻石领体力");
                mf.mytap(this._jubing, 108, 78);
            }
        }

        private void jinruzhandou(out int shibai) {
            int x=-1,y=-1;
            DuoDianZhaoSe dz1 = new DuoDianZhaoSe(0xfffcd5, "-7|0|0x5b5045,-15|0|0xf3f3d2,-19|0|0x434038,-19|-3|0x363336,-8|-3|0x37332b,12|-3|0xdbdfd9", 90, 5, 0, 50, 10);
            DuoDianZhaoSe dz2 = new DuoDianZhaoSe(0x8b7164, "0|-6|0x8b7365,-4|-7|0x726965,-4|2|0x79797d,-7|6|0xfffbef,-7|11|0x877242,-3|5|0xc7af37", 90, 0, 85, 25, 121);
            DuoDianZhaoSe[] dzzu = new DuoDianZhaoSe[] {dz1,dz2 };
            shibai = 0;
            if (mf.myqudianqusezuobiaoShuZu(dzzu))
            {
                WriteLog.WriteLogFile(this._mnqName,"进入到战斗场景");
                int beisu = 0;
                var kstime = MyFuncUtil.GetTimestamp();                
                while (true) {
                    if (beisu == 0) {
                        WriteLog.WriteLogFile(this._mnqName, "战斗时速度问题");
                        //mf.mytap(this._jubing, 17, 5);
                        beisu = 1;
                    }
                    DuoDianZhaoSe dz = new DuoDianZhaoSe(0xf7c320, "0|-11|0xfecb21,10|-8|0xfcb40f,23|-8|0xffcb21,31|-8|0xf3ac16,33|-6|0xf7a610,30|0|0xf7a618", 90, 90, 10, 135, 45);
                    mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        WriteLog.WriteLogFile(this._mnqName,"胜利");
                        mf.mysuijitap(this._jubing, tiaoguoyongX, tiaoguoyongY);
                        break;
                    }
                    dz = new DuoDianZhaoSe(0xffba18, "5|0|0xfebd18,5|-5|0x917711,10|-5|0xfade17,14|-6|0xffdf18,-5|-1|0xfcdd22,-11|-1|0xfcdc1a", 90, 5, 10, 45, 30);
                    mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        WriteLog.WriteLogFile(this._mnqName,"全场最佳");
                        mf.mysuijitap(this._jubing, tiaoguoyongX, tiaoguoyongY);
                        shibai = 0;
                        break;
                    }
                    if (panduanjiemian("战斗后失败"))
                    {
                        WriteLog.WriteLogFile(this._mnqName,"失败");
                        mf.mysuijitap(this._jubing, tiaoguoyongX, tiaoguoyongY);
                        shibai = 1;
                        break;
                    }
                    var jstime = MyFuncUtil.GetTimestamp();
                    if ((jstime - kstime) > 1000*60*5)
                    {
                        WriteLog.WriteLogFile(this._mnqName,"5分钟退出战斗场景");
                        shibai = 0;
                        break;
                    }
                }
            }
        }

        
        
   

        
        private void zhandouxuanren() {
            if (panduanjiemian("战斗画面")) {

                if (mf.fanwei(308, 66, 363, 127, 0x5fd0ff) == 1)
                {
                    WriteLog.WriteLogFile(this._mnqName, "打前排第一个");
                    mf.mytap(this._jubing, 336, 88);
                }
                if (mf.fanwei(336, 117, 377, 138, 0x5fd0ff) == 1)
                {
                    WriteLog.WriteLogFile(this._mnqName, "打前排第2个");
                    mf.mytap(this._jubing, 361, 130);
                }
                if (mf.fanwei(368, 177, 400, 201, 0x5fd0ff) == 1)
                {
                    WriteLog.WriteLogFile(this._mnqName, "打前排第3个");
                    mf.mytap(this._jubing, 386, 188);
                }
                if (mf.fanwei(425, 118, 454, 140, 0x5fd0ff) == 1)
                {
                    WriteLog.WriteLogFile(this._mnqName, "打hou前排第2个");
                    mf.mytap(this._jubing, 440, 129);
                }
            }
        }
        

        public void lingqu()
        {
            WriteLog.WriteLogFile(this._mnqName, "进入到领取环节");
            
        }
        
        public void qianghua()
        {
            WriteLog.WriteLogFile(this._mnqName, "进去强化");
            List<int> juesel = new List<int>();
            for (int i = 0; i < 5; i++) {
                if (i == 0 && mf.mohu(53, 36, 0xef3344) == 1)
                {
                    WriteLog.WriteLogFile(this._mnqName, "第"+(i+1)+"个角色需要强化");
                    juesel.Add(i + 1);
                }
                if (i == 1 && mf.mohu(52, 91, 0xf43442) == 1)
                {
                    WriteLog.WriteLogFile(this._mnqName, "第" + (i + 1) + "个角色需要强化");
                    juesel.Add(i + 1);
                }
                if (i == 2 && mf.mohu(52, 146, 0xf43342) == 1)
                {
                    WriteLog.WriteLogFile(this._mnqName, "第" + (i + 1) + "个角色需要强化");
                    juesel.Add(i + 1);
                }
                if (i == 3 && mf.mohu(53, 201, 0xef3343) == 1)
                {
                    WriteLog.WriteLogFile(this._mnqName, "第" + (i + 1) + "个角色需要强化");
                    juesel.Add(i + 1);
                }
                if (i == 4 && mf.mohu(51, 257, 0xee2d3b) == 1)
                {
                    WriteLog.WriteLogFile(this._mnqName, "第" + (i + 1) + "个角色需要强化");
                    juesel.Add(i + 1);
                }
            }
            foreach(int ij in juesel){
                WriteLog.WriteLogFile(this._mnqName, "第" + ij + "个角色准备强化");
                if (!panduanjiemian("界面-角色强化"))
                {
                    mf.mytap(this._jubing, 361, 357);
                    mf.mydelay(2000, 3000);
                }
                if (panduanjiemian("界面-角色强化")) {
                    mf.mytap(this._jubing, 33, 57+(ij-1)*55);
                    mf.mydelay(2000, 3000);
                    WriteLog.WriteLogFile(this._mnqName, "第" + ij + "个角色选定");
                    List<int> jueseqhl = new List<int>();
                    for (int i = 0; i < 6; i++)
                    {
                        if (i == 0 && mf.mohu(622, 53, 0xf43341) == 1)
                        {
                            WriteLog.WriteLogFile(this._mnqName, "第" + ij + "个角色需要强化升级");
                            jueseqhl.Add(i + 1);
                        }
                        if (i == 1 && mf.mohu(622, 96, 0xf43341) == 1)
                        {
                            WriteLog.WriteLogFile(this._mnqName, "第" + ij + "个角色需要强化升品");
                            jueseqhl.Add(i + 1);
                        }
                        if (i == 2 && mf.mohu(622, 139, 0xf43341) == 1)
                        {
                            WriteLog.WriteLogFile(this._mnqName, "第" + ij + "个角色需要强化升星");
                            jueseqhl.Add(i + 1);
                        }
                        if (i == 3 && mf.mohu(622, 182, 0xf43341) == 1)
                        {
                            WriteLog.WriteLogFile(this._mnqName, "第" + ij + "个角色需要强化装束");
                            jueseqhl.Add(i + 1);
                        }
                        if (i == 4 && mf.mohu(623, 225, 0xf23342) == 1)
                        {
                            WriteLog.WriteLogFile(this._mnqName, "第" + ij + "个角色需要强化技能");
                            jueseqhl.Add(i + 1);
                        }
                        if (i == 5 && mf.mohu(622, 268, 0xf43341) == 1)
                        {
                            WriteLog.WriteLogFile(this._mnqName, "第" + ij + "个角色需要强化羁绊");
                            jueseqhl.Add(i + 1);
                        }
                    }
                    WriteLog.WriteLogFile(this._mnqName, "第" + ij + "个角色根据红点搜集情况开始强化");
                    jutiqianghua(jueseqhl);
                }
            }
            WriteLog.WriteLogFile(this._mnqName, "强化完结");
            if (!panduanjiemian("界面-角色强化"))
            {
                mf.mytap(this._jubing, 361, 357);
                mf.mydelay(2000, 3000);
                mf.mytap(this._jubing, 361, 357);
                mf.mydelay(2000, 3000);
            }
            if (panduanjiemian("界面-角色强化")) {
                mf.mytap(this._jubing, 650, 13);
                mf.mydelay(2000, 3000);
            }
        }

        public void jutiqianghua(List<int> jueseqhl)
        {
            foreach (int ij in jueseqhl)
            {
                WriteLog.WriteLogFile(this._mnqName, "角色准备强化具体项目");
                if (!panduanjiemian("界面-角色强化"))
                {
                    mf.mytap(this._jubing, 361, 357);
                    mf.mydelay(2000, 3000);
                }
                if (panduanjiemian("界面-角色强化"))
                {
                    mf.mytap(this._jubing, 645, 71 + (ij - 1) * 40);
                    mf.mydelay(2000, 3000);
                    WriteLog.WriteLogFile(this._mnqName, "准备强化选定的项目"+ij);
                    long ks = MyFuncUtil.GetTimestamp();
                    int yici = 0;
                    int jineng = 0;
                    while (true) {
                        long js = MyFuncUtil.GetTimestamp();
                        if ((js - ks) > 1000 * 60)
                        {
                            break;
                        }
                        if (ij == 1 && yici==0) {
                            WriteLog.WriteLogFile(this._mnqName, "强化升级");
                            yici = 1;
                        }
                        if (ij == 1)
                        {
                            mf.mytap(this._jubing, 549, 345);
                            mf.mydelay(2000, 3000);
                        }
                        if (ij == 1 && mf.mohu(622, 53, 0xf43341) != 1)
                        {
                            WriteLog.WriteLogFile(this._mnqName, "强化升级红点不见");
                            break;
                        }
                        if (ij == 2 && yici == 0)
                        {
                            WriteLog.WriteLogFile(this._mnqName, "强化升品");
                            yici = 1;
                        }
                        if (ij == 2)
                        {
                            mf.mytap(this._jubing, 495, 343);
                            mf.mydelay(2000, 3000);
                        }
                        if (ij == 2 && panduanjiemian("界面-角色强化") && mf.mohu(622, 96, 0xf43341) != 1)
                        {
                            WriteLog.WriteLogFile(this._mnqName, "强化升品红点不见");
                            mf.mydelay(3000, 4000);
                            mf.mytap(this._jubing, 361, 357);
                            break;
                        }

                        if (ij == 3 && yici == 0)
                        {
                            WriteLog.WriteLogFile(this._mnqName, "强化升星");
                            yici = 1;
                        }
                        if (ij == 3 && panduanjiemian("界面-角色强化")&& mf.mohu(553, 346, 0xc38844) == 1)
                        {
                            mf.mytap(this._jubing, 556, 343);
                            mf.mydelay(2000, 3000);     
                        }
                        if (ij == 3 && panduanjiemian("界面-角色强化") && mf.mohu(553, 346, 0xc38844) != 1)
                        {
                            WriteLog.WriteLogFile(this._mnqName, "强化升星完成");
                            break;
                        }
                        if (ij == 3 && !panduanjiemian("界面-角色强化"))
                        {
                            mf.mytap(this._jubing, 361, 357);
                            mf.mydelay(2000, 3000);
                        } 
                        if (ij == 4 && yici == 0)
                        {
                            WriteLog.WriteLogFile(this._mnqName, "强化装束");                            
                            yici = 1;
                        }
                        if (ij == 4) {
                            gaozhuangshu();
                            break;
                        }

                        if (ij == 5 && yici == 0)
                        {
                            WriteLog.WriteLogFile(this._mnqName, "强化技能");
                            yici = 1;
                        }
                        if (ij == 5 && mf.mohu(563, 108, 0xcf9e74)==1)
                        {
                            mf.mytap(this._jubing, 560, 109);
                            mf.mydelay(1000, 3000);
                            jineng++;
                        }
                        if (ij == 5 && panduanjiemian("界面-角色强化") && mf.mohu(563, 108, 0xcf9e74) != 1) {
                            WriteLog.WriteLogFile(this._mnqName, "强化技能第一个完毕,无按钮");
                            break;
                        }
                        if (ij == 5 && jineng > 10) {
                            WriteLog.WriteLogFile(this._mnqName, "强化技能第一个超10次结束");
                            break;
                        }

                        if (ij == 6 && yici == 0)
                        {
                            WriteLog.WriteLogFile(this._mnqName, "强化羁绊");
                            yici = 1;
                        }
                        if (ij == 6)
                        {
                            //挨个点一遍
                            mf.mytap(this._jubing, 483, 88);
                            mf.mydelay(200, 400);
                            mf.mytap(this._jubing, 494, 158);
                            mf.mydelay(200, 400);
                            mf.mytap(this._jubing, 494, 227);
                            mf.mydelay(200, 400);
                            mf.mytap(this._jubing, 489, 311);
                            mf.mydelay(200, 400);
                            break;
                        }
                    }
                }
            }
        }


        private void gaozhuangshu() {
            //第一件
            mf.mytap(this._jubing, 428, 76);
            mf.mydelay(2000, 4000);
            FuHeSanDian fh = Jingjie_SanDian.GetObject().findFuHeSandianByName("强化-装束界面的一键强化");
            if (mf.mohuByLeiBool(fh.Sd))
            {
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                mf.mydelay(2000, 3000);
            }
            if (mf.mohu(538, 336, 0xf43342) == 1)
            {
                mf.mytap(this._jubing, 498, 343);
                mf.mydelay(2000, 3000);
            }
            if (!panduanjiemian("界面-角色强化"))
            {
                mf.mytap(this._jubing, 361, 357);
                mf.mydelay(2000, 3000);
            }
            //第2件 数完左边数右边
            mf.mytap(this._jubing, 447, 128);
            mf.mydelay(2000, 4000);
            if (mf.mohuByLeiBool(fh.Sd))
            {
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                mf.mydelay(2000, 3000);
            }
            if (mf.mohu(538, 336, 0xf43342) == 1)
            {
                mf.mytap(this._jubing, 498, 343);
                mf.mydelay(2000, 3000);
            }
            if (!panduanjiemian("界面-角色强化"))
            {
                mf.mytap(this._jubing, 361, 357);
                mf.mydelay(2000, 3000);
            }
            //第3件
            mf.mytap(this._jubing, 423, 184);
            mf.mydelay(2000, 4000);
            if (mf.mohuByLeiBool(fh.Sd))
            {
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                mf.mydelay(2000, 3000);
            }
            if (mf.mohu(538, 336, 0xf43342) == 1)
            {
                mf.mytap(this._jubing, 498, 343);
                mf.mydelay(2000, 3000);
            }
            if (!panduanjiemian("界面-角色强化"))
            {
                mf.mytap(this._jubing, 361, 357);
                mf.mydelay(2000, 3000);
            }
            //第4件
            mf.mytap(this._jubing, 574, 76);
            mf.mydelay(2000, 4000);
            if (mf.mohuByLeiBool(fh.Sd))
            {
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                mf.mydelay(2000, 3000);
            }
            if (mf.mohu(538, 336, 0xf43342) == 1)
            {
                mf.mytap(this._jubing, 498, 343);
                mf.mydelay(2000, 3000);
            }
            if (!panduanjiemian("界面-角色强化"))
            {
                mf.mytap(this._jubing, 361, 357);
                mf.mydelay(2000, 3000);
            }
            //第5件
            mf.mytap(this._jubing, 550, 124);
            mf.mydelay(2000, 4000);
            if (mf.mohuByLeiBool(fh.Sd))
            {
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                mf.mydelay(2000, 3000);
            }
            if (mf.mohu(538, 336, 0xf43342) == 1)
            {
                mf.mytap(this._jubing, 498, 343);
                mf.mydelay(2000, 3000);
            }
            if (!panduanjiemian("界面-角色强化"))
            {
                mf.mytap(this._jubing, 361, 357);
                mf.mydelay(2000, 3000);
            }
            //第6件
            mf.mytap(this._jubing, 572, 180);
            mf.mydelay(2000, 4000);
            if (mf.mohuByLeiBool(fh.Sd))
            {
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                mf.mydelay(2000, 3000);
            }
            if (mf.mohu(538, 336, 0xf43342) == 1)
            {
                mf.mytap(this._jubing, 498, 343);
                mf.mydelay(2000, 3000);
            }
            if (!panduanjiemian("界面-角色强化"))
            {
                mf.mytap(this._jubing, 361, 357);
                mf.mydelay(2000, 3000);
            }
        }
        
        

        public Boolean panduanjiemian(string jiemian) {
            Boolean tmp = false;
            FuHeSanDian fh = null;
            if (jiemian.Equals("界面-主界面")) {
                fh = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-主界面");
                if (mf.mohuByLeiBool(fh.Sd)) {
                    tmp = true;
                }
            }
            if (jiemian.Equals("界面-角色强化"))
            {
                fh = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-角色强化");
                if (mf.mohuByLeiBool(fh.Sd))
                {
                    tmp = true;
                }
            }
            if (jiemian.Equals("界面-战斗界面"))
            {
                fh = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-战斗界面");
                if (mf.mohuByLeiBool(fh.Sd))
                {
                    tmp = true;
                }
            }
            return tmp;
        }

        public void guanbi_all() {
            
        }

        private void zhaozhujiemian(int haomiao) {
            bool tmp = false;
            if (panduanjiemian("主界面"))
            {
                mf.mydelay(1000, 3000);
                if (panduanjiemian("主界面"))
                {
                    tmp = true;
                }
            }
            if (tmp)
            {
                WriteLog.WriteLogFile(this._mnqName, "已经进入主界面!");
            }
            else
            {
                long ks = MyFuncUtil.GetTimestamp();
                while (true) {
                    long js = MyFuncUtil.GetTimestamp();
                    guanbi_all();
                    mf.mydelay(600, 1200);
                    if (panduanjiemian("主界面"))
                    {
                        mf.mydelay(2000, 3000);
                        if (panduanjiemian("主界面"))
                        {
                            break;
                        }
                    }
                    if ((js - ks) > haomiao) {
                        break;
                    }
                }
            }
        }



        public void qidong(int index, string name)
        {
            throw new NotImplementedException();
        }

        public void guanbi(int index, string name)
        {
            throw new NotImplementedException();
        }

        public bool yiqidong()
        {
            throw new NotImplementedException();
        }

        public bool chongxindenglu()
        {
            throw new NotImplementedException();
        }

        public string generalBasicShuziDemo(int ind, string path)
        {
            WriteLog.WriteLogFile(ind + "", "进入到数字识别" + " " + path);            
            BaiDuShiTu bd = new BaiDuShiTu();
            JObject rs = bd.Number(path);
            if (rs.Root["words_result"] == null) {
                WriteLog.WriteLogFile(ind + "", "啥也识别不出来" + " " + path);       
                return null;
            }
            var txts = (from obj in (JArray)rs.Root["words_result"]
                        select (string)obj["words"]);
            string rt = "";
            foreach (var r in txts)
            {
                WriteLog.WriteLogFile(ind + "", "原有的 " + r);                
            }
            foreach (var r in txts)
            {
                if (r != null && r != "")
                {
                    WriteLog.WriteLogFile(ind + "", "识别出 " + r);
                    rt = r;
                    break;
                }
            }
            return rt;
        }

        public List<string> generalBaiduShibie(int ind, string path)
        {
            WriteLog.WriteLogFile(ind + "", "进入到app账号文字识别"+" "+path);
            BaiDuShiTu bd = new BaiDuShiTu();
            JObject rs = bd.GeneralBasic(path);
            if (rs.Root["words_result"] == null)
            {
                return null;
            }
            var txts = (from obj in (JArray)rs.Root["words_result"]
                        select (string)obj["words"]);
            List<string> rt = new List<string>();
            foreach (var r in txts)
            {
                if (r != null && r != "")
                {
                    WriteLog.WriteLogFile(ind + "", r);
                    rt.Add(r);
                }
            }
            return rt;
        }

        public string generalBaiduShibieDantiao(int ind, string path)
        {
            WriteLog.WriteLogFile(ind + "", "进入到app账号文字识别-返回单条数据");
            BaiDuShiTu bd = new BaiDuShiTu();
            JObject rs = bd.GeneralBasic(path);
            if (rs.Root["words_result"] == null)
            {
                return null;
            }
            var txts = (from obj in (JArray)rs.Root["words_result"]
                        select (string)obj["words"]);
            string rt = "";
            foreach (var r in txts)
            {
                if (r != null && r != "")
                {
                    WriteLog.WriteLogFile(ind + "", r);
                    rt = r;
                }
            }
            return rt;
        }
    }
}
