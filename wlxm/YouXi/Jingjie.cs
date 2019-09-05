﻿using System;
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
            while (true)
            {
                long js = MyFuncUtil.GetTimestamp();
                FuHeSanDian kt = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊存账号-新号首界面");
                if (xuanqu == 0 && mf.mohuByLeiBool(kt.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, kt.Name);
                    mf.mytap(this._jubing, kt.Zhidingx, kt.Zhidingy);
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
                List<FuHeSanDian> ls = Jingjie_SanDian.GetObject().findListFuHeSandianByName("存账号");
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
                            }
                        }
                    }
                }
                if (mf.mohuXunHuanJianChi(Jingjie_SanDian.GetObject().findFuHeSandianByName("存账号-跳过绑定手机2").Sd,60)) {
                    WriteLog.WriteLogFile(this._mnqName, "存账号-跳过绑定手机2 xuanqu重置为0");
                    xuanqu = 0;
                }
                FuHeSanDian yk = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊存账号-用户名密码界面");
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
                        yk = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊存账号-用户名密码界面");
                        if (xuanqu == 0 && mf.mohuByLeiBool(yk.Sd))
                        {
                            WriteLog.WriteLogFile(this._mnqName,"当前界面为"+yk.Name);
                            zh.generateNameAndPas(this._dqinx, 7, out zhanghao, out pwd);
                            mf.mydelay(2000, 4000);
                            mf.mytap(this._jubing, 489, 127);//账号需要回退
                            mf.mydelay(300, 600);
                            mf.mytap(this._jubing, 386, 130);//点击两次
                            mf.mydelay(100, 300);
                            mf.mytap(this._jubing, 386, 130);
                            mf.mydelay(100, 300);
                            zh.shuruqianhuitui(mf, this._dqinx, this._jubing);
                            mf.mydelay(2000, 4000);
                            mf.mytap(this._jubing, 386, 130);
                            mf.mydelay(100, 300);
                            mf.SendString(this._jubing, zhanghao);
                            mf.mydelay(2000, 4000);
                            mf.myKeyPressChar(this._jubing, "tab");
                            mf.mydelay(2000, 4000);
                            mf.mytap(this._jubing, 420, 197);//点击密码框
                            mf.SendString(this._jubing, pwd);
                            mf.mydelay(2000, 4000);
                            mf.mytap(this._jubing, 346, 263);//点击注册
                            mf.mydelay(9000, 18000);
                        }
                        foreach (FuHeSanDian fh in ls)
                        {
                            if (!fh.Name.Equals("存账号-跳过绑定手机2") && mf.mohuByLeiBool(fh.Sd))
                            {
                                WriteLog.WriteLogFile(this._mnqName, fh.Name);
                                if (fh.Zhidingx != -1 && fh.Zhidingy != -1)
                                {
                                    mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                                    tiaoci++;
                                } 
                            }
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
                yk = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊存账号-用户名密码界面");
                if (xuanqu == 1 && mf.mohuByLeiBool(yk.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, yk.Name+"注册"+shibiechu);
                    mf.mytap(this._jubing, yk.Zhidingx, yk.Zhidingy);
                }
                //出现登录-出现选服信息 超过10s
                FuHeSanDian dlxf = Jingjie_SanDian.GetObject().findFuHeSandianByName("选区-出现进入游戏");
                bool t0 = mf.mohuXunHuanJianChi(dlxf.Sd, 60);
                if (xuanqu == 1 && xuanhao == 0 && t0)
                {
                    WriteLog.WriteLogFile(this._mnqName, dlxf.Name);
                    mf.mytap(this._jubing, 425, 303);
                    mf.mydelay(2000, 4000);
                    FuHeSanDian xq = Jingjie_SanDian.GetObject().findFuHeSandianByName("选区-服务器选区界面");
                    if (mf.mohuByLeiBool(xq.Sd))
                    {
                        WriteLog.WriteLogFile(this._mnqName, xq.Name);
                        mf.mytap(this._jubing, 87, 178);
                    }
                }
                FuHeSanDian xq1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("选区-服务器选区界面");
                if (xuanqu == 1 && mf.mohuByLeiBool(xq1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, xq1.Name);
                    mf.mytap(this._jubing, 87, 178);
                    mf.mydelay(2000, 4000);
                }
                FuHeSanDian qu1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("选区-服务器选1区");
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
                        }
                    }
                }
                FuHeSanDian qu2 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊游戏-开始战斗");
                if (xuanhao == 1 && mf.mohuByLeiBool(qu2.Sd))
                {
                    t = true;
                }
                qu2 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊游戏-进入任务");
                if (xuanhao == 1 && mf.mohuByLeiBool(qu2.Sd))
                {
                    t = true;
                }
                if (t)
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
            zh.lurenSaveNameAndPas(zhanghao, pwd, this._dqinx, "jingjie");
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
            WriteLog.WriteLogFile(this._mnqName, "找到需要练级的账号"+name+" "+pwd+",xuanqu "+xuanqu+",置为登陆中");
            zhanghao.zhiweidengluzhong(this._dqinx, "jingjie",name, WriteLog.getMachineName()); ;
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
                    mf.mydelay(4000, 6000);
                }
                if (denglu==0 && tiaochuci > 0 && !mf.mohuXunHuanJianChi(kt.Sd, 20) && !mf.mohuXunHuanJianChi(kt1.Sd, 20))
                {
                    WriteLog.WriteLogFile(this._mnqName, kt.Name + " 登录成功");
                    denglu = 1;
                }
                if (denglu == 0 &&(mf.mohuXunHuanJianChi(kt.Sd,20) || mf.mohuXunHuanJianChi(kt1.Sd,20))) {
                    WriteLog.WriteLogFile(this._mnqName, "当前账号无法登陆,置为无效同时换号");
                    zhanghao.zhiweiwuxiao(this._dqinx, "jingjie", name, WriteLog.getMachineName());
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
                        mf.mytap(this._jubing, 87, 178);
                    }
                }
                FuHeSanDian xq1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("选区-服务器选区界面2");
                if (xuanqu == 1 && mf.mohuByLeiBool(xq1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, xq1.Name);
                    mf.mytap(this._jubing, 87, 178);
                    mf.mydelay(2000, 4000);
                }
                FuHeSanDian qu1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("选区-服务器选1区2");
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

        private void zhituozhuxian() {
            long kstime = MyFuncUtil.GetTimestamp();
            int yici = 0;
            int youjian = 0;
            int fuli = 0;
            int shibai = 0;
            int jinji = 0;

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
                if ((jstime - kpjishi) > 30 * 1000 && compareColor(kapingyanse1, kapingyanse2))
                {
                    //调用卡屏函数                   
                    if (panduankaping(kp1))
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
                ktsd1 = Jingjie_SanDian.GetObject().findFuHeSandianByName("特殊引导-关卡3-7");
                if ((shibai == 0 || shibai == 1) && mf.mohuByLeiBool(ktsd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ktsd1.Name);
                    break;
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
            }
        }

        private void qushufrombaidu(out int qushu,FuHeSanDian qz,int x1,int y1,int x2,int y2)
        {
            qushu = -1;
            if (mf.mohuByLeiBool(qz.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, qz.Name);
                string filename = this._dqinx + "_" + mf.GetTime() + ".bmp";
                mf.captureBmp(this._jubing, @"c:\mypic_save\", filename, x1, y1, x2, y2);
                if (mf.IsFileExist(@"c:\mypic_save\" + filename) == 1)
                {
                    string r = generalBasicShuziDemo(this._dqinx, @"c:\mypic_save\" + filename);
                    if (r != null && r != "")
                    {
                        qushu = int.Parse(r);
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
        private bool panduankaping(long kp1)
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
                string name=this._dqinx+"_"+mf.GetTime()+".bmp";
                mf.captureBmp(this._jubing, path, name);
                Thread.Sleep(10000);
                rs = true;
            }
            return rs;
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
            zhituozhuxian();
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
                    if (panduankaping(kp1))
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
            FuHeSanDian fh = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-主界面");
            while (true) {
                //mf.mytap(this._jubing, 466, 366);
                long js = MyFuncUtil.GetTimestamp();
                if ((js - ks) > 1000 * 20) {
                    break;
                }
                fh = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-主界面");
                if (mf.mohuXunHuanJianChi(fh.Sd, 15)) {
                    break;
                }
                fh = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-关卡界面");
                if (mf.mohuXunHuanJianChi(fh.Sd, 15))
                {
                    break;
                }
            }
            int dengji = -1;
            int zuanshi = -1;
            int qiangzhequan = -1;
            fh=Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-主界面");
            qushufrombaidu(out zuanshi,fh,531, 5, 574, 19);            
            FuHeSanDian fh2 = Jingjie_SanDian.GetObject().findFuHeSandianByName("界面-关卡界面");
            qushufrombaidu(out zuanshi, fh, 531, 5, 574, 19);
            if (!mf.mohuByLeiBool(fh.Sd) && !mf.mohuByLeiBool(fh2.Sd))
            {
                string filename = this._dqinx + "退出时" + mf.GetTime() + ".bmp";
                mf.captureBmp(this._jubing, @"c:\mypic_save", filename);
            }
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
            
            WriteLog.WriteLogFile(this._mnqName, "强化完结");
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
