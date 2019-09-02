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
namespace fuzhu1
{
    public class Luneng
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




        public Luneng(xDm mydm, int dqinx, string dizhi = @"d:\ChangZhi\dnplayer2\")
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
            youkehaohuizong();
        }

        public void youkehaohuizong() {
            int wancheng = youkehaodenglu();
            if (wancheng == -1)
            {
                WriteLog.WriteLogFile(this._mnqName, "存账号过程不顺利");
                return;
            }
            string timestamp = mf.GetTime() + "";
            int delete = youkehaosave(timestamp);
            if (delete != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, "准备删除过程中创建的文件");
                string mydir = @"c:\mypic\" + timestamp + @"\quick_user";
                if (!Directory.Exists(mydir))//如果不存在return　　             　　              
                {
                    WriteLog.WriteLogFile(this._mnqName, "找不到过程中创建的文件夹"+mydir);
                    return;
                }
                DirectoryInfo TheFolder = new DirectoryInfo(mydir);
                foreach (FileInfo myfile in TheFolder.GetFiles())
                {
                    if (!File.Exists(@"d:\lunengpic\" + this._dqinx+"_"+timestamp + ".jpg"))
                    {
                        myfile.MoveTo(@"d:\lunengpic\" + this._dqinx + "_" + timestamp + ".jpg");
                    }
                }
                TheFolder.Delete();
                DirectoryInfo TheFolder2 = new DirectoryInfo(@"c:\mypic\" + timestamp);
                TheFolder2.Delete();
                File.Delete(@"C:\mypic\" + timestamp + ".jpg");
                WriteLog.WriteLogFile(this._mnqName, "删除过程中创建的文件完毕");
            }
        }

        public int youkehaodenglu() {
            WriteLog.WriteLogFile(this._mnqName, "准备开始存账号");
            long ks = MyFuncUtil.GetTimestamp();
            var wancheng = -1;
            int xf = 0;
            int xuan1 = 0;
            while (true)
            {
                long js = MyFuncUtil.GetTimestamp();
                List<FuHeSanDian> ls = Luneng_SanDian.GetObject().findListFuHeSandianByName("存账号");
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
                FuHeSanDian yk = Luneng_SanDian.GetObject().findFuHeSandianByName("特殊存账号-游客登录选择");
                if (mf.mohuByLeiBool(yk.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, yk.Name);
                    if (yk.Zhidingx != -1 && yk.Zhidingy != -1)
                    {
                        mf.mytap(this._jubing, yk.Zhidingx, yk.Zhidingy);
                    }
                    mf.mydelay(2000, 3000);
                    ZuoBiao xy = yk.Listzuobiao.First();
                    if (mf.mohu(248, 327, 0x42cb40) == 1 && mf.mohu(xy.X, xy.Y, xy.Yanse) == 1)
                    {
                        WriteLog.WriteLogFile(this._mnqName, yk.Name+"准备进入循环");
                        mf.mytap(this._jubing, 233, 294);
                        mf.mydelay(2000, 3000);
                        long ks1 = MyFuncUtil.GetTimestamp();
                        List<SanDian> sd = new List<SanDian>();
                        int yici = 0;
                        ls = Luneng_SanDian.GetObject().findListFuHeSandianByName("特殊存账号");
                        if (ls != null && ls.Count > 0)
                        {
                            foreach (FuHeSanDian fh in ls)
                            {
                                sd.Add(fh.Sd);
                            }
                        }
                        while (true)
                        {
                            if (yici == 0) {
                                WriteLog.WriteLogFile(this._mnqName, yk.Name + "已经进入循环");
                                yici = 1;
                            }
                            ls = Luneng_SanDian.GetObject().findListFuHeSandianByName("特殊存账号");
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
                            if (!mf.mohuqubiaoXunHuan(sd.ToArray(), 15))
                            {
                                WriteLog.WriteLogFile(this._mnqName, yk.Name + "15秒无相关信息退出循环");
                                break;
                            }
                            long js1 = MyFuncUtil.GetTimestamp();
                            if ((js1 - ks1) / 1000 > 60 *5)
                            {
                                WriteLog.WriteLogFile(this._mnqName, "5分钟超时");
                                break;
                            }
                        }
                    }
                }
                //出现登录-出现选服信息 超过10s
                FuHeSanDian dlxf = Luneng_SanDian.GetObject().findFuHeSandianByName("登录-出现选服信息");
                bool t = mf.mohuXunHuanJianChi(dlxf.Sd, 60);
                if (xf==0 && t)
                {
                    WriteLog.WriteLogFile(this._mnqName, dlxf.Name);
                    mf.mytap(this._jubing, 412, 276);
                    mf.mydelay(2000, 4000);
                    FuHeSanDian xq = Luneng_SanDian.GetObject().findFuHeSandianByName("选区-选区界面");
                    if (mf.mohuByLeiBool(xq.Sd)) {
                        WriteLog.WriteLogFile(this._mnqName, xq.Name);
                        mf.mytap(this._jubing, 167, 155);            
                    }
                }
                FuHeSanDian xq1 = Luneng_SanDian.GetObject().findFuHeSandianByName("选区-选区界面");
                if (xuan1==0 && mf.mohuByLeiBool(xq1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, xq1.Name);
                    mf.mytap(this._jubing, 167, 155);
                    mf.mydelay(2000, 4000);
                }
                FuHeSanDian qu1 = Luneng_SanDian.GetObject().findFuHeSandianByName("选区-1号服");
                if (mf.mohuByLeiBool(qu1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, qu1.Name);
                    xuan1 = 1;
                    mf.mytap(this._jubing, qu1.Zhidingx, qu1.Zhidingy);                    
                    mf.mydelay(2000, 4000);
                    t = mf.mohuXunHuanJianChi(dlxf.Sd, 60);
                    if (t)
                    {
                        WriteLog.WriteLogFile(this._mnqName, dlxf.Name + "选服成功");
                        mf.mytap(this._jubing, 345, 324);
                        mf.mydelay(2000, 4000);
                        xf = 1;
                    }
                }
                t = mf.mohuXunHuanJianChi(dlxf.Sd, 60);
                if (xf == 1 && t)
                {
                    WriteLog.WriteLogFile(this._mnqName, dlxf.Name + "选服成功2");
                    mf.mytap(this._jubing, 345, 324);
                    mf.mydelay(2000, 4000);
                }
                FuHeSanDian qm = Luneng_SanDian.GetObject().findFuHeSandianByName("选区-起名");
                if (mf.mohuByLeiBool(qm.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, qm.Name);
                    mf.mytap(this._jubing, 550, 329);
                    mf.mydelay(2000, 4000);
                    if (xf==2 && mf.mohuByLeiBool(qm.Sd)) {
                        mf.mytap(this._jubing, 413, 124);
                    }
                    xf = 2;
                }
                List<FuHeSanDian> tg = Luneng_SanDian.GetObject().findListFuHeSandianByName("跳过");
                if (tg != null && tg.Count > 0)
                {
                    foreach (FuHeSanDian fh in tg)
                    {
                        if (xf == 2 && mf.mohuByLeiBool(fh.Sd))
                        {
                            WriteLog.WriteLogFile(this._mnqName, fh.Name);
                            if (fh.Zhidingx != -1 && fh.Zhidingy != -1)
                            {
                                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                            }
                        }
                    }
                }
                FuHeSanDian ld = Luneng_SanDian.GetObject().findFuHeSandianByName("任务-出现来电");
                if (mf.mohuByLeiBool(ld.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, ld.Name);
                    mf.mytap(this._jubing, ld.Zhidingx, ld.Zhidingy);
                    mf.mydelay(6000, 8000);
                    wancheng = 1;
                    break;
                }
                if ((js - ks) / 1000 > 60 * 15)
                {
                    WriteLog.WriteLogFile(this._mnqName, "15分钟超时");
                    break;
                }
            }
            WriteLog.WriteLogFile(this._mnqName, "结束存账号的游戏点击过程");
            if (wancheng == -1)
            {
                //WriteLog.WriteLogFile(this._mnqName, "游戏过程不顺利");
                //return;
            }
            return wancheng;
        }

        public int youkehaosave(string timestamp) {
            WriteLog.WriteLogFile(this._mnqName, "准备保存账号");
            int delete = -1;
            string mydir1=@"c:\mypic\"+timestamp;
            MyLdcmd.myScreencapLuneng(this._dqinx, mydir1);
            string mydir = @"c:\mypic\" + timestamp + @"\quick_user";
            if (!Directory.Exists(mydir))//如果不存在return　　             　　              
            {
                WriteLog.WriteLogFile(this._mnqName, "复制失败" + mydir);
                return delete;
            }            
            Bitmap f = null;
            DirectoryInfo TheFolder = new DirectoryInfo(mydir);
            foreach (FileInfo myfile in TheFolder.GetFiles())
            {
                f=MyFuncUtil.ReadImageFile(mydir+"//"+myfile);
            }
            if (f != null) {
                WriteLog.WriteLogFile(this._mnqName, "");
                Bitmap g = MyFuncUtil.KiCut(f, 185, 535, 370, 130);
                g.Save(@"C:\mypic\" + timestamp+".jpg");
                g.Dispose();
            }
            if (File.Exists(@"C:\mypic\" + timestamp + ".jpg"))
            {
                delete=1;
                List<string> rs=generalBaiduShibie(this._dqinx, @"C:\mypic\" + timestamp + ".jpg");
                if (rs != null && rs.Count > 0)
                {
                    string name = null, pwd = null;
                    foreach (string a in rs)
                    {
                        WriteLog.WriteLogFile(this._mnqName, a);
                        if (a.IndexOf("用户名") >= 0) {
                            name = a.Trim().Substring(4).Trim();
                        }
                        if (a.IndexOf("登录密码") >= 0)
                        {
                            pwd = a.Trim().Substring(5).Trim();
                            if (pwd.IndexOf(" ") == 1) {
                                pwd = pwd.Substring(2);
                            }
                        }
                    }
                    
                    ZhangHao zh = new ZhangHao();
                    zh.lurenSaveNameAndPas(name, pwd, this._dqinx);
                }
            }
            return delete;
        }

        public Boolean denglu(int fenzhong)
        {
            WriteLog.WriteLogFile(this._mnqName, "进入到登录环节  " + this._jubing + "，thread:" + Thread.CurrentThread.ManagedThreadId);
            Boolean abc = true;
            long kstime = mf.GetTime();
            FuHeSanDian d1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("关闭实名认证");
            FuHeSanDian d2 = YiQuan_SanDian.GetObject().findFuHeSandianByName("关闭公告");
            if (mf.mohuByLeiBool(d1.Sd)) {
                WriteLog.WriteLogFile(this._mnqName, d1.Name);
                mf.mytap(this._jubing, d1.Zhidingx, d1.Zhidingy);
            }
            if (mf.mohuByLeiBool(d2.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, d2.Name);
                mf.mytap(this._jubing, d2.Zhidingx, d2.Zhidingy);
            }
            FuHeSanDian d3 = YiQuan_SanDian.GetObject().findFuHeSandianByName("登录或注册");
            FuHeSanDian d4 = YiQuan_SanDian.GetObject().findFuHeSandianByName("进入游戏");
            FuHeSanDian d5 = YiQuan_SanDian.GetObject().findFuHeSandianByName("首次进入登录或注册");
            SanDian[] sdzu = new SanDian[] { d1.Sd, d2.Sd,d3.Sd, d4.Sd, d5.Sd };
            abc = mf.mohuqubiaoXunHuan(sdzu, 60 * fenzhong);
            return abc;

        }
        
        public Boolean zhuce(int fz,out int dengji,out int xuanqu)
        {
            Boolean zccg = true;
            dengji = -1;
            xuanqu = -1;
            WriteLog.WriteLogFile(this._mnqName, "进入到注册环节-登录或注册" + " " + this._jubing);
            string name = null;
            string pwd = null;
            ZhangHao zhanghao = new ZhangHao();
            zhanghao.zhunbeizhanghao(this._dqinx,"路人",out name, out pwd,out xuanqu,out dengji);
            int zhucele = 0;
            long ks = MyFuncUtil.GetTimestamp();
            long ks1 = MyFuncUtil.GetTimestamp();
            int yici = 0;
            while (true) {
                //有公告则关闭
                //有跳过实名则关闭
                FuHeSanDian d1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("关闭实名认证");
                FuHeSanDian d2 = YiQuan_SanDian.GetObject().findFuHeSandianByName("关闭公告");
                FuHeSanDian[] dzu = new FuHeSanDian[] { d1, d2};
                foreach (FuHeSanDian f in dzu)
                {
                    if (mf.mohuByLeiBool(f.Sd))
                    {
                        WriteLog.WriteLogFile(this._mnqName, f.Name);
                        mf.mytap(this._jubing, f.Zhidingx, f.Zhidingy);                        
                    }
                }
                FuHeSanDian d3 = YiQuan_SanDian.GetObject().findFuHeSandianByName("账号切换后选新账号");
                if (mf.mohuByLeiBool(d3.Sd))
                {
                    if (yici == 0)
                    {
                        WriteLog.WriteLogFile(this._mnqName, d3.Name);
                        mf.mytap(this._jubing, d3.Zhidingx,d3.Zhidingy);
                        yici = 1;
                        ks1 = MyFuncUtil.GetTimestamp();
                    }
                }
                FuHeSanDian d5 = YiQuan_SanDian.GetObject().findFuHeSandianByName("登录或注册");
                if (mf.mohuByLeiBool(d5.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, d5.Name);
                    break;
                }
                FuHeSanDian d4 = YiQuan_SanDian.GetObject().findFuHeSandianByName("进入游戏");
                if (mf.mohuByLeiBool(d4.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName,d4.Name);
                    mf.mytap(this._jubing, 509, 55);                    
                }
                FuHeSanDian d6 = YiQuan_SanDian.GetObject().findFuHeSandianByName("首次进入登录或注册");
                if (mf.mohuByLeiBool(d6.Sd) && yici == 0)
                {
                    WriteLog.WriteLogFile(this._mnqName, d6.Name);
                    break;
                }
                long jstime = MyFuncUtil.GetTimestamp();
                if ((jstime - ks1) > 20 * 1000)
                {
                    yici = 0;
                }
                if ((jstime - ks) > fz * 60 * 1000)
                {
                    zccg = false;
                    WriteLog.WriteLogFile(this._mnqName, "注册环节-登录或注册-没有成功完成" + " " + this._jubing);
                    break;
                }
            }
            if (!zccg)
            {
                return zccg;
            }
            ks = MyFuncUtil.GetTimestamp();
            WriteLog.WriteLogFile(this._mnqName, "进入到注册或登录界面");
            int dianyici = 0;
            while (true)
            {
                if (name != null && pwd != null)
                {
                    FuHeSanDian d = YiQuan_SanDian.GetObject().findFuHeSandianByName("登录或注册");
                    if (mf.mohuByLeiBool(d.Sd))
                    {
                        mf.mytap(this._jubing, 220, 104);
                        mf.mydelay(2000, 4000);
                        zhanghao.shuruchar(mf, this._dqinx, this._jubing, name);
                        mf.mytap(this._jubing, 223, 136);
                        mf.mydelay(2000, 4000);
                        zhanghao.shuruchar(mf, this._dqinx, this._jubing, pwd);
                        mf.mydelay(2000, 4000);
                        mf.mytap(this._jubing, 268, 176);
                        mf.mydelay(2000, 4000);
                        if (!mf.mohuByLeiBool(d.Sd))
                        {
                            WriteLog.WriteLogFile(this._mnqName, d.Name + "登录成功");
                            zhucele = 1;
                            break;
                        }
                    }
                    FuHeSanDian d6 = YiQuan_SanDian.GetObject().findFuHeSandianByName("首次进入登录或注册");
                    if (mf.mohuByLeiBool(d6.Sd) && dianyici == 0)
                    {
                        throw new Exception("出错了,新模拟器不应该数据库有账号");
                    }
                }
                else
                {
                    //注册后登录
                    FuHeSanDian d6 = YiQuan_SanDian.GetObject().findFuHeSandianByName("首次进入登录或注册");
                    if (mf.mohuByLeiBool(d6.Sd) && dianyici == 0)
                    {
                        WriteLog.WriteLogFile(this._mnqName, d6.Name+"点注册");
                        mf.mytap(this._jubing, 268, 159);
                        dianyici = 1;
                    }
                    if (dianyici == 0)
                    {
                        WriteLog.WriteLogFile(this._mnqName, "点一次注册");
                        mf.mytap(this._jubing, 301, 209);
                        mf.mydelay(2000, 4000);
                        dianyici = 1;
                    }
                    FuHeSanDian d = YiQuan_SanDian.GetObject().findFuHeSandianByName("新账号注册");
                    if (mf.mohuByLeiBool(d.Sd))
                    {
                        WriteLog.WriteLogFile(this._mnqName, d.Name);
                        zhanghao.generateNameAndPas(this._dqinx, 7, out name, out pwd);
                        mf.mydelay(2000, 4000);
                        mf.mytap(this._jubing, 230, 112);
                        mf.mydelay(2000, 4000);
                        zhanghao.shuruchar(mf, this._dqinx, this._jubing, name);
                        mf.mytap(this._jubing, 232, 140);
                        mf.mydelay(2000, 4000);
                        zhanghao.shuruchar(mf, this._dqinx, this._jubing, pwd);
                        mf.mydelay(4000, 6000);
                        if (mf.fanwei(333,  169,342,  179,0x1eb9ee )==1)
                        {
                            WriteLog.WriteLogFile(this._mnqName, "去掉绑定手机对号");
                            mf.mytap(this._jubing, 337, 175);
                            mf.mydelay(1000, 3000);
                        }
                        mf.mytap(this._jubing, 266, 239);
                        mf.mydelay(4000, 6000);
                        d = YiQuan_SanDian.GetObject().findFuHeSandianByName("新账号注册");
                        if (!mf.mohuByLeiBool(d.Sd))
                        {
                            WriteLog.WriteLogFile(this._mnqName, d.Name + "注册成功");
                            zhucele = 1;
                            break;
                        }
                        else {
                            name = null;
                            pwd = null;
                            WriteLog.WriteLogFile(this._mnqName,"账号可能已被占用");
                        }
                    }                    
                }
                long jstime = MyFuncUtil.GetTimestamp();                
                if ((jstime - ks) > fz * 60 * 1000)
                {
                    zccg = false;
                    WriteLog.WriteLogFile(this._mnqName, "注册环节-登录或注册-没有成功完成" + " " + this._jubing);
                    break;
                }
            }
            if (!zccg)
            {
                return zccg;
            }
            if (zhucele == 1) {
                //新账号或老账号存入数据库
                zhanghao.denglusaveNameAndPas(name, pwd, this._dqinx);
            } 
            //成功后关闭实名 开始选区 默认区不动
            ks = MyFuncUtil.GetTimestamp();
            WriteLog.WriteLogFile(this._mnqName, "存完账号,准备进入游戏环节" + " " + this._jubing);
            int jl = 0;
            int qushuyici = 0;
            int guanbi = 0;
            while (true) {
                FuHeSanDian d1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("关闭实名认证");
                FuHeSanDian d2 = YiQuan_SanDian.GetObject().findFuHeSandianByName("关闭公告");
                FuHeSanDian[] dzu = new FuHeSanDian[] { d1, d2 };
                foreach (FuHeSanDian f in dzu)
                {
                    if (mf.mohuByLeiBool(f.Sd))
                    {
                        WriteLog.WriteLogFile(this._mnqName, f.Name + "关闭" + guanbi+"次");
                        mf.mytap(this._jubing, f.Zhidingx, f.Zhidingy);
                        guanbi++;
                    }
                }
                FuHeSanDian d4 = YiQuan_SanDian.GetObject().findFuHeSandianByName("进入游戏");
                if (guanbi>1 && mf.mohuByLeiBool(d4.Sd) &&(xuanqu == -1) && (qushuyici == 0))
                {
                    
                    qushufrombaidu(out xuanqu, d4, 229, 207, 285, 225);
                    if (xuanqu != -1)
                    {
                        qushuyici = 1;
                    }
                }
                if ((xuanqu != -1) && mf.mohuByLeiBool(d4.Sd))
                {
                    mf.mytap(this._jubing, 275, 240);
                    mf.mydelay(1000, 3000);
                    jl = 1;
                }
                SanDian[] sdzu = new SanDian[] { d1.Sd, d2.Sd, d4.Sd, };
                if (jl==1 && !mf.mohuqubiaoXunHuan(sdzu, 20 * 1)) {
                    WriteLog.WriteLogFile(this._mnqName, "20s全不在,进去了");                    
                    zccg = true;
                    break;
                }
                long jstime = MyFuncUtil.GetTimestamp();
                if ((jstime - ks) > fz * 60 * 1000)
                {
                    zccg = false;
                    WriteLog.WriteLogFile(this._mnqName, "进入游戏环节-没有成功完成");
                    break;
                }
            }
            if ((xuanqu != -1) && (qushuyici == 1))
            {
                //更新选区
                zhanghao.updateXuanqu(name, xuanqu);
            }
            return zccg;
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
                    string r = generalBasicDemo(this._dqinx, @"c:\mypic_save\" + filename);
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

        
        

        private void tedingdian()
        {
            FuHeSanDian fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("开头的战斗超人画像");
            if (mf.mohuByLeiBool(fhzd1.Sd)) {
                if (fhzd1.Listzuobiao.Count > 0) {
                    foreach (ZuoBiao z in fhzd1.Listzuobiao) {
                        mf.mytap(this._jubing, z.X, z.Y);
                        mf.mydelay(10,80);
                    }
                }
            }
            FuHeSanDian fhzd2 = YiQuan_SanDian.GetObject().findFuHeSandianByName("开头的骑士画像");
            if (mf.mohuByLeiBool(fhzd2.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, "开头的骑士画像" + fhzd2.Listzuobiao.Count);
                if (fhzd2.Listzuobiao.Count > 0)
                {
                    foreach (ZuoBiao z in fhzd2.Listzuobiao)
                    {
                        mf.mytap(this._jubing, z.X, z.Y);
                        mf.mydelay(10, 80);
                    }
                }
            }
            FuHeSanDian fhzd3 = YiQuan_SanDian.GetObject().findFuHeSandianByName("开头的爆炸头画像");
            if (mf.mohuByLeiBool(fhzd3.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, "开头的爆炸头画像" + fhzd3.Listzuobiao.Count);
                if (fhzd3.Listzuobiao.Count > 0)
                {
                    foreach (ZuoBiao z in fhzd3.Listzuobiao)
                    {
                        mf.mytap(this._jubing, z.X, z.Y);
                        mf.mydelay(10, 80);
                    }
                }
            }
            FuHeSanDian fhzd4 = YiQuan_SanDian.GetObject().findFuHeSandianByName("开头的光头画像");
            if (mf.mohuByLeiBool(fhzd4.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, "开头的光头画像" + fhzd4.Listzuobiao.Count);
                if (fhzd4.Listzuobiao.Count > 0)
                {
                    foreach (ZuoBiao z in fhzd4.Listzuobiao)
                    {
                        mf.mytap(this._jubing, z.X, z.Y);
                        mf.mydelay(10, 80);
                    }
                }
            }

            FuHeSanDian fhzd5 = YiQuan_SanDian.GetObject().findFuHeSandianByName("章节的已完成");
            if (mf.mohuByLeiBool(fhzd5.Sd))
            {
                mf.mytap(this._jubing, fhzd5.Zhidingx, fhzd5.Zhidingy);
                mf.mydelay(10, 80);
                   
            }

            FuHeSanDian fhzd6 = YiQuan_SanDian.GetObject().findFuHeSandianByName("章节的进行中");
            if (mf.mohuByLeiBool(fhzd6.Sd))
            {
                mf.mytap(this._jubing, fhzd6.Zhidingx, fhzd6.Zhidingy);
                mf.mydelay(10, 80);

            }
            FuHeSanDian fhzd7 = YiQuan_SanDian.GetObject().findFuHeSandianByName("第二章开始任务");
            if (mf.mohuByLeiBool(fhzd7.Sd))
            {
                mf.mytap(this._jubing, fhzd7.Zhidingx, fhzd7.Zhidingy);
                mf.mydelay(10, 80);

            }

            fhzd7 = YiQuan_SanDian.GetObject().findFuHeSandianByName("开始第三章任务");
            if (mf.mohuByLeiBool(fhzd7.Sd))
            {
                mf.mytap(this._jubing, fhzd7.Zhidingx, fhzd7.Zhidingy);
                mf.mydelay(10, 80);

            }

            fhzd7 = YiQuan_SanDian.GetObject().findFuHeSandianByName("协会竞技");
            if (mf.mohuByLeiBool(fhzd7.Sd))
            {
                mf.mytap(this._jubing, 507, 11);
                mf.mydelay(100, 800);
                fhzd7 = YiQuan_SanDian.GetObject().findFuHeSandianByName("协会竞技");
                if (mf.mohuByLeiBool(fhzd7.Sd))
                {
                    mf.mytap(this._jubing, fhzd7.Zhidingx, fhzd7.Zhidingy);
                    mf.mydelay(10, 80);
                }
            }

            fhzd7 = YiQuan_SanDian.GetObject().findFuHeSandianByName("协会竞技一键领取");
            if (mf.mohuByLeiBool(fhzd7.Sd))
            {
                mf.mydelay(10, 80);
                fhzd7 = YiQuan_SanDian.GetObject().findFuHeSandianByName("协会竞技一键领取可以关闭");
                if (mf.mohuByLeiBool(fhzd7.Sd))
                {
                    mf.mytap(this._jubing, fhzd7.Zhidingx, fhzd7.Zhidingy);
                    mf.mydelay(10, 80);
                    return;
                }
                mf.mytap(this._jubing, fhzd7.Zhidingx, fhzd7.Zhidingy);
                mf.mydelay(10, 80);
                if (fhzd7.Listzuobiao != null)
                {
                    foreach (ZuoBiao z in fhzd7.Listzuobiao)
                    {
                        mf.mydelay(300, 1000);
                        if (z.Yanse != -1)
                        {
                            if (mf.myGetColorWuJuYouYanSe(z.X, z.Y, z.Yanse))
                            {
                                mf.mytap(this._jubing, z.X, z.Y);
                            }
                        }
                        else
                        {
                            mf.mytap(this._jubing, z.X, z.Y);
                        }
                    }
                }

            }
            fhzd7 = YiQuan_SanDian.GetObject().findFuHeSandianByName("钉头锤特定点");
            if (mf.mohuByLeiBool(fhzd7.Sd))
            {
                mf.mytap(this._jubing, fhzd7.Zhidingx, fhzd7.Zhidingy);
                mf.mydelay(10, 80);

            }
            fhzd7 = YiQuan_SanDian.GetObject().findFuHeSandianByName("剧情任务第四章未解锁");
            if (mf.mohuByLeiBool(fhzd7.Sd))
            {
                mf.mytap(this._jubing, fhzd7.Zhidingx, fhzd7.Zhidingy);
                mf.mydelay(10, 80);

            }
            fhzd7 = YiQuan_SanDian.GetObject().findFuHeSandianByName("体力获取小窗口先关闭");
            if (mf.mohuByLeiBool(fhzd7.Sd))
            {
                mf.mytap(this._jubing, fhzd7.Zhidingx, fhzd7.Zhidingy);
                mf.mydelay(10, 80);

            }
            fhzd7 = YiQuan_SanDian.GetObject().findFuHeSandianByName("支线领取第1个");
            if (mf.mohuByLeiBool(fhzd7.Sd))
            {
                mf.mytap(this._jubing, fhzd7.Zhidingx, fhzd7.Zhidingy);
                mf.mydelay(10, 80);

            }
            fhzd7 = YiQuan_SanDian.GetObject().findFuHeSandianByName("支线领取第2个");
            if (mf.mohuByLeiBool(fhzd7.Sd))
            {
                mf.mytap(this._jubing, fhzd7.Zhidingx, fhzd7.Zhidingy);
                mf.mydelay(10, 80);

            }
            int x = -1, y = -1;
            mf.myqudianqusezuobiao(this._jubing, 0xf1caae, "0|-10|0xedccb3,-4|-1|0xe2dcd9,5|-2|0xf2ebe8,4|6|0xeac4a7,-3|6|0xeac3a6,-3|14|0xe1b899", 90, 150, 85, 180, 121, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"发现光头-在最下面");
                mf.mytap(this._jubing, 146, 34);
                //mf.mydelay(200, 800);  
                  
            }
            mf.myqudianqusezuobiao(this._jubing, 0xfefaee, "0|-3|0xa02522,-3|-1|0xa42421,-82|58|0xd4f0fc,-67|57|0xbcee32,-43|57|0x39c6f6,-21|57|0xc97b0e,-31|52|0x639d3a,-16|52|0x639d39", 90, 90, 0, 200, 85, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"第一次领取");
                mf.mytap(this._jubing, 135, 97);
                //mf.mydelay(200, 800);
                
            }
            
            mf.myqudianqusezuobiao(this._jubing, 0xfffbef, "-25|1|0xffb618,-89|1|0xffb610,-91|74|0xffdb21,-100|74|0x63521d,-108|77|0xffcf18,-85|77|0xbd9131", 90, 65, 15, 185, 105, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"一拳通关关闭");
                mf.mytap(this._jubing, 180, 20);
                //mf.mydelay(200, 800);
            }
            mf.myqudianqusezuobiao(this._jubing, 0xf0ecf0, "-7|0|0xca2e1e,-12|0|0xfe4129,-12|4|0xdd3421,-15|-3|0xefab00,8|-2|0xf0b000,12|-4|0xeea900", 90, 0, 0, 40, 15, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"发现任务领取窗口-只取左上角");
                mf.mytap(this._jubing, 186, 52);
                //mf.mydelay(200, 800);
            }
            mf.myqudianqusezuobiao(this._jubing, 0xd73722, "-6|0|0xe73521,-6|-3|0xff4129,-9|-4|0xf1ad00,5|-3|0xffffff,11|-2|0xefaa00,19|-3|0xab7208", 90,  0, 0, 45, 15, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"发现超市窗口直接关-只取左上角");
                mf.mytap(this._jubing, 206, 4);
                //mf.mydelay(200, 800);
            }
            mf.myqudianqusezuobiao(this._jubing, 0xffc71d, "9|1|0x320303,-29|2|0xf9d50e,-42|2|0x5d6667,-55|2|0xcd2f39,-67|2|0xf9d50e,-90|1|0x2cd4fe", 90, 105, 0, 215, 10, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"发现角色养成窗口直接关-只取左上角");
                mf.mytap(this._jubing, 206, 4);
                //mf.mydelay(200, 800);
            }
            
        }

        public void tiaoguo()
        {
            FuHeSanDian je = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色关闭窗口");
            FuHeSanDian dh = YiQuan_SanDian.GetObject().findFuHeSandianByName("空白对话框");
            FuHeSanDian tg = YiQuan_SanDian.GetObject().findFuHeSandianByName("右上角的跳过");
            FuHeSanDian jq = YiQuan_SanDian.GetObject().findFuHeSandianByName("跳过的剧情界面");
            FuHeSanDian jq2 = YiQuan_SanDian.GetObject().findFuHeSandianByName("跳过的剧情界面3章");
            
            if (mf.mohuByLeiBool(jq.Sd) && mf.mohuByLeiBool(tg.Sd))
            {
                mf.mytap(this._jubing, tg.Zhidingx, tg.Zhidingy);
            }
            if (mf.mohuByLeiBool(jq2.Sd))
            {
                mf.mytap(this._jubing, jq2.Zhidingx, jq2.Zhidingy);
            }
            if (mf.mohuByLeiBool(dh.Sd) && !mf.mohuByLeiBool(je.Sd))
            {
                mf.mysuijitap(this._jubing, tiaoguoyongX, tiaoguoyongY);
            }
            FuHeSanDian dh2 = YiQuan_SanDian.GetObject().findFuHeSandianByName("空白对话框2");
            if (mf.mohuByLeiBool(dh2.Sd) && !mf.mohuByLeiBool(je.Sd))
            {
                mf.mysuijitap(this._jubing, tiaoguoyongX, tiaoguoyongY);
            }
            FuHeSanDian dh3 = YiQuan_SanDian.GetObject().findFuHeSandianByName("点击任意继续");
            if (mf.jingqueByLeiBool(dh3.Sd)){
                mf.mysuijitap(this._jubing, tiaoguoyongX, tiaoguoyongY);
            }
            dh3 = YiQuan_SanDian.GetObject().findFuHeSandianByName("点击任意继续2");
            if (mf.jingqueByLeiBool(dh3.Sd))
            {
                mf.mysuijitap(this._jubing, tiaoguoyongX, tiaoguoyongY);
            }
            dh3 = YiQuan_SanDian.GetObject().findFuHeSandianByName("点击任意继续3");
            if (mf.jingqueByLeiBool(dh3.Sd))
            {
                mf.mysuijitap(this._jubing, tiaoguoyongX, tiaoguoyongY);
            }
            dh3 = YiQuan_SanDian.GetObject().findFuHeSandianByName("点击任意继续4");
            if (mf.jingqueByLeiBool(dh3.Sd))
            {
                mf.mysuijitap(this._jubing, tiaoguoyongX, tiaoguoyongY);
            }
            dh3 = YiQuan_SanDian.GetObject().findFuHeSandianByName("点击任意继续5");
            if (mf.jingqueByLeiBool(dh3.Sd))
            {
                mf.mysuijitap(this._jubing, tiaoguoyongX, tiaoguoyongY);
            }
            dh3 = YiQuan_SanDian.GetObject().findFuHeSandianByName("出现截屏保存");
            if (mf.jingqueByLeiBool(dh3.Sd))
            {
                mf.mytap(this._jubing, dh3.Zhidingx, dh3.Zhidingy);
            }
            dh3 = YiQuan_SanDian.GetObject().findFuHeSandianByName("点击任意继续4");
            if (mf.jingqueByLeiBool(dh3.Sd))
            {
                mf.mytap(this._jubing, dh3.Zhidingx, dh3.Zhidingy);
            }
            dh3 = YiQuan_SanDian.GetObject().findFuHeSandianByName("掌趣窗口");
            if (mf.jingqueByLeiBool(dh3.Sd))
            {
                mf.mytap(this._jubing, dh3.Zhidingx, dh3.Zhidingy);
            }
            dh3 = YiQuan_SanDian.GetObject().findFuHeSandianByName("章节任务回放");
            if (mf.jingqueByLeiBool(dh3.Sd))
            {
                mf.mytap(this._jubing, dh3.Zhidingx, dh3.Zhidingy);
            }
        }

        private void guangtouteding() {
            FuHeDuoDian fh1 = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("光头界面1");
            FuHeDuoDian fh2 = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("光头界面2");
            FuHeDuoDian fh21 = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("光头界面3");
            FuHeDuoDian fh22 = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("光头界面4");            
            FuHeDuoDian fh = mf.fuHeDuoDianShuZu(new FuHeDuoDian[] { fh1, fh2, fh21, fh22});
            if (fh != null)
            {
                List<ZuoBiao> kpzb = new List<ZuoBiao>();
                kpzb.Add(new ZuoBiao(220, 48));
                kpzb.Add(new ZuoBiao(407, 136));

                string[] kapingyanse1 = mf.myGetColorWuJbList(kpzb);
                string[] kapingyanse2 = kapingyanse1;
                WriteLog.WriteLogFile(this._mnqName, fh.Name);
                if (fh.Listzuobiao!= null) {
                    foreach (ZuoBiao z in fh.Listzuobiao) {
                        mf.mytap(this._jubing, z.X, z.Y);
                        mf.mydelay(100,800);
                        kapingyanse2 = mf.myGetColorWuJbList(kpzb);
                        if (!compareColor(kapingyanse1, kapingyanse2)) {
                            break;
                        }
                    }
                }
            }
            int x=-1,y=-1;
            FuHeDuoDian hq = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("类似光头红色拳头");
            mf.myqudianqusezuobiaoByLeiWuJubing(hq.Dz, out x, out y);
            if (x != -1 && y != -1)
            {
                FuHeSanDian sd = YiQuan_SanDian.GetObject().findFuHeSandianByName("有主线任务");
                if (mf.mohuByLeiBool(sd.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, sd.Name + sd.Zhidingx + " " + sd.Zhidingy);
                    mf.mydelay(100, 600);
                    mf.mytap(this._jubing, sd.Zhidingx, sd.Zhidingy);
                    mf.mydelay(100, 800);
                    return;
                }
                List<ZuoBiao> kpzb = new List<ZuoBiao>();
                kpzb.Add(new ZuoBiao(220, 48));
                kpzb.Add(new ZuoBiao(407, 136));

                string[] kapingyanse1 = mf.myGetColorWuJbList(kpzb);
                string[] kapingyanse2 = kapingyanse1;
                WriteLog.WriteLogFile(this._mnqName, hq.Name+x+" "+y);
                mf.mytap(this._jubing, x, y+30);
                mf.mydelay(300, 1000);
                if (hq.Listzuobiao != null)
                {
                    foreach (ZuoBiao z in hq.Listzuobiao)
                    {
                        mf.mydelay(300, 1000);
                        kapingyanse2 = mf.myGetColorWuJbList(kpzb);
                        if (!compareColor(kapingyanse1, kapingyanse2))
                        {
                            break;
                        }
                        mf.mytap(this._jubing, z.X, z.Y);
                    }
                }
                
            }

            FuHeDuoDian zx = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("支线已完成");
            mf.myqudianqusezuobiaoByLeiWuJubing(zx.Dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, zx.Name);
                mf.mytap(this._jubing, x+10, y+10);
                mf.mydelay(300, 1000);
                for (int i = 0; i < 4; i++)
                {
                    zx = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("支线完成领取");
                    mf.myqudianqusezuobiaoByLeiWuJubing(zx.Dz, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        mf.mytap(this._jubing, x, y);
                        mf.mydelay(300, 1000);
                    }
                    FuHeSanDian sd = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-支线完成领取");
                    if (mf.mohuByLeiBool(sd.Sd))
                    {
                        WriteLog.WriteLogFile(this._mnqName, sd.Name + sd.Zhidingx + " " + sd.Zhidingy);
                        mf.mydelay(100, 600);
                        mf.mytap(this._jubing, sd.Zhidingx, sd.Zhidingy);
                        mf.mydelay(100, 800);
                    }
                    sd = YiQuan_SanDian.GetObject().findFuHeSandianByName("支线领取第1个");
                    if (mf.mohuByLeiBool(sd.Sd))
                    {
                        mf.mytap(this._jubing, sd.Zhidingx, sd.Zhidingy);
                        mf.mydelay(10, 80);

                    }
                    sd = YiQuan_SanDian.GetObject().findFuHeSandianByName("支线领取第2个");
                    if (mf.mohuByLeiBool(sd.Sd))
                    {
                        mf.mytap(this._jubing, sd.Zhidingx, sd.Zhidingy);
                        mf.mydelay(10, 80);

                    }
                    FuHeSanDian dh12 = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色关闭窗口");
                    if (mf.mohuByLeiBool(dh12.Sd)) {
                        mf.mytap(this._jubing, dh12.Zhidingx, dh12.Zhidingy);
                        mf.mydelay(300, 1000);
                    }
                }
            }

            FuHeDuoDian zx2 = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("钉头锤领取");
            mf.myqudianqusezuobiaoByLeiWuJubing(zx2.Dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, zx2.Name);
                mf.mytap(this._jubing, x + 10, y + 10);
                mf.mydelay(300, 1000);
            }

            FuHeDuoDian zx3 = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("关卡宝箱领取");
            mf.myqudianqusezuobiaoByLeiWuJubing(zx3.Dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, zx3.Name);
                mf.mytap(this._jubing, x, y + 20);
                mf.mydelay(300, 1000);
            }

            FuHeSanDian dh17 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-钉头上阵");
            if (mf.mohuByLeiBool(dh17.Sd)) {
                WriteLog.WriteLogFile(this._mnqName, dh17.Name);
                mf.mytap(this._jubing, dh17.Zhidingx, dh17.Zhidingy);
                mf.mydelay(300, 1000);
            }

            FuHeSanDian zx1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("领取关卡宝箱");
            if (mf.mohuByLeiBool(zx1.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, zx1.Name);
                mf.mytap(this._jubing, zx1.Zhidingx, zx1.Zhidingy);
                mf.mydelay(300, 1000);
            }
        }

        private void yindaoshizuo() {
            FuHeSanDian dh1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-任务招募");
            FuHeSanDian dh2 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-女人招募");
            FuHeSanDian dh3 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-设置昵称");
            FuHeSanDian dh4 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-关卡界面");
            FuHeSanDian dh5 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-宝箱领取");
            //FuHeSanDian dh6 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-角色养成");
            FuHeSanDian dh7 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-招募骑士");
            FuHeSanDian dh8 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-地图主线任务地底人");
            FuHeSanDian dh9 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-关闭核心技");
            FuHeSanDian dh10 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-关闭布阵");
            FuHeSanDian dh11 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-关闭离开关卡");
            FuHeSanDian dh12 = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色关闭窗口");
            FuHeSanDian dh13 = YiQuan_SanDian.GetObject().findFuHeSandianByName("有主线任务");
            FuHeSanDian dh14 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-一拳通关");
            FuHeSanDian dh15 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-黑屏普通攻击");
            FuHeSanDian dh16 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-一拳通关完成关闭");
            
            FuHeSanDian dh = mf.fuHeSanDianShuZu(new FuHeSanDian[] { dh1, dh2, dh3, dh4, dh5, dh7, dh8, dh9, dh10, dh11, dh12, dh13, dh14, dh15, dh16 });
            if (dh != null)
            {
                WriteLog.WriteLogFile(this._mnqName,dh.Name);
                mf.mytap(this._jubing, dh.Zhidingx, dh.Zhidingy);
                if (dh.Listzuobiao != null) {
                    foreach (ZuoBiao z in dh.Listzuobiao) {
                        mf.mytap(this._jubing, z.X, z.Y);
                        mf.mydelay(300,1000);
                    }
                }
            }

            FuHeSanDian qs = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-骑士上阵");
            if (mf.mohuByLeiBool(qs.Sd)) {
                WriteLog.WriteLogFile(this._mnqName, qs.Name);
                mf.mydelay(100, 600);
                mf.mydrag(this._jubing, 41, 266, 290, 210);
                mf.mydelay(100, 800);
            }

            FuHeSanDian zd = YiQuan_SanDian.GetObject().findFuHeSandianByName("卡点-战斗不打");
            if (mf.mohuByLeiBool(zd.Sd))
            {
                FuHeSanDian sd = YiQuan_SanDian.GetObject().findFuHeSandianByName("战斗手动开");
                if (mf.mohuByLeiBool(sd.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, sd.Name + sd.Zhidingx + " " + sd.Zhidingy);
                    mf.mydelay(100, 600);
                    mf.mytap(this._jubing,sd.Zhidingx, sd.Zhidingy);
                    mf.mydelay(100, 800);
                    return;
                }
                WriteLog.WriteLogFile(this._mnqName, zd.Name);
                mf.mytap(this._jubing, zd.Zhidingx, zd.Zhidingy);
                if (zd.Listzuobiao != null)
                {
                    foreach (ZuoBiao z in zd.Listzuobiao)
                    {
                        mf.mytap(this._jubing, z.X, z.Y);
                        mf.mydelay(300, 1000);
                    }
                }
            }

            FuHeSanDian jsyc = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-角色养成");
            if (mf.mohuByLeiBool(jsyc.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, jsyc.Name);
                mf.mytap(this._jubing, jsyc.Zhidingx, jsyc.Zhidingy);
                if (jsyc.Listzuobiao != null)
                {
                    foreach (ZuoBiao z in jsyc.Listzuobiao)
                    {
                        mf.mydelay(300, 1000);
                        if (z.Yanse != -1)
                        {
                            if (mf.myGetColorWuJuYouYanSe(z.X, z.Y, z.Yanse))
                            {
                                mf.mytap(this._jubing, z.X, z.Y);
                            }
                        }
                        else
                        {
                            mf.mytap(this._jubing, z.X, z.Y);
                        }
                    }
                }
                
            }

            zd = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-支线完成领取");
            if (mf.mohuByLeiBool(zd.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, zd.Name);
                mf.mytap(this._jubing, zd.Zhidingx, zd.Zhidingy);                
            }

            if ((dh == null) && (!mf.mohuByLeiBool(qs.Sd)) && (!mf.mohuByLeiBool(zd.Sd) && (!mf.mohuByLeiBool(jsyc.Sd))))
            {
                guanbi_all();
            }
        }

        private void yindaoshizuo_xian()
        {
            
            FuHeSanDian dh13 = YiQuan_SanDian.GetObject().findFuHeSandianByName("有主线任务");
            
            FuHeSanDian dh = mf.fuHeSanDianShuZu(new FuHeSanDian[] { dh13 });
            if (dh != null)
            {
                WriteLog.WriteLogFile(this._mnqName, dh.Name);
                mf.mytap(this._jubing, dh.Zhidingx, dh.Zhidingy);
                if (dh.Listzuobiao != null)
                {
                    foreach (ZuoBiao z in dh.Listzuobiao)
                    {
                        mf.mytap(this._jubing, z.X, z.Y);
                        mf.mydelay(300, 1000);
                    }
                }
            }

            FuHeSanDian zd = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-支线完成领取");
            if (mf.mohuByLeiBool(zd.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, zd.Name);
                mf.mytap(this._jubing, zd.Zhidingx, zd.Zhidingy);
            }
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
                yindaoshizuo();
            }
            if ((kp2 - kp1) > 1000 * 20)
            {
                yindaoshizuo_xian();
            }
            if ((kp2 - kp1) > 1000 * 60*5)
            {
                WriteLog.WriteLogFile(this._mnqName,"卡屏5分钟");
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


        public void zhuxian()
        {
            WriteLog.WriteLogFile(this._mnqName, "进入到主线任务");
            dijibieks();            
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
                tedingdian();
                guangtouteding();
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
                
                SanDian zdhm = YiQuan_SanDian.GetObject().findFuHeSandianByName("战斗画面").Sd;
                if (panduanzhandou(zdhm)) {
                    break;
                }
                if (panduanjiemian("战斗画面"))
                {
                    zhandouxiangguan(0,0,0);
                }
                SanDian zdsb = YiQuan_SanDian.GetObject().findFuHeSandianByName("出现战斗失败").Sd;
                if (mf.jingqueByLeiBool(zdsb))
                {
                    shibai=1;
                    if (zaicishibai > 2) {
                        break;
                    }
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

        
        public void quitdq()
        {
            int dengji = -1;
            int zuanshi = -1;
            int qiangzhequan = -1;
            zhaozhujiemian(20 * 1000);
            bool tmp = jinrujueseqianghua();
            if (tmp)
            {
                string filename = this._dqinx + "_" + mf.GetTime() + ".bmp";
                mf.captureBmp(this._jubing, @"c:\mypic_save\", filename, 123, 34, 173, 55);
                if (mf.IsFileExist(@"c:\mypic_save\" + filename) == 1)
                {
                    string r=generalBasicDemo(this._dqinx, @"c:\mypic_save\" + filename);
                    if (r != null && r!= "") {
                        dengji = int.Parse(r);
                    }
                }
            }
            zhaozhujiemian(20 * 1000);
            if (panduanjiemian("主界面")) {
                string filename = this._dqinx + "_" + mf.GetTime() + ".bmp";
                mf.captureBmp(this._jubing, @"c:\mypic_save\", filename, 360, 0, 414, 21);
                if (mf.IsFileExist(@"c:\mypic_save\" + filename) == 1)
                {
                    string r = generalBasicDemo(this._dqinx, @"c:\mypic_save\" + filename);
                    if (r != null && r != "")
                    {
                        zuanshi = int.Parse(r);
                    }
                }
            }            
            zhaozhujiemian(20 * 1000);
            if (panduanjiemian("主界面"))
            {
                FuHeSanDian beibao = YiQuan_SanDian.GetObject().findFuHeSandianByName("主界面特定点背包");
                if (mf.mohuByLeiBool(beibao.Sd)) {
                    WriteLog.WriteLogFile(this._mnqName, beibao.Name);
                    mf.mytap(this._jubing, beibao.Zhidingx,beibao.Zhidingy);
                    mf.mydelay(2000, 4000);
                }
                if (panduanjiemian("背包界面"))
                {
                    FuHeSanDian qz = YiQuan_SanDian.GetObject().findFuHeSandianByName("背包里的强者券");
                    quqiangzhequan(out qiangzhequan, qz);
                    if (!mf.mohuByLeiBool(qz.Sd))
                    {
                        mf.mytap(this._jubing, 50, 134);
                        mf.mydelay(2000, 4000);
                        quqiangzhequan(out qiangzhequan, qz);
                        if (!mf.mohuByLeiBool(qz.Sd))
                        {
                            FuHeDuoDian ddqz = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("强者招募券");
                            int x=-1,y=-1;
                            mf.myqudianqusezuobiaoByLei(this._jubing, ddqz.Dz, out x, out y);
                            if (x != -1 && y != -1) {
                                mf.mytap(this._jubing, x, y);
                                mf.mydelay(4000, 6000);
                            }
                            quqiangzhequan(out qiangzhequan, qz);
                        }
                    }
                }
            }
            ZhangHao zhanghao = new ZhangHao();
            zhanghao.tuichusaveNameAndPas(this._dqinx, WriteLog.getMachineName(),dengji,zuanshi,qiangzhequan);
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
                    string r = generalBasicDemo(this._dqinx, @"c:\mypic_save\" + filename);
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

        public void zhaoxiangzi_ditu()
        {
            WriteLog.WriteLogFile(this._mnqName, "地图事件开始");
            if (panduanjiemian("判断地图界面")) {
                WriteLog.WriteLogFile(this._mnqName, "判断地图界面");
                mf.mydelay(1000, 2000);
                for (int i = 0; i < 2; i++)
                {
                    mf.myMove(this._jubing, 299, 286);
                    mf.mydelay(1000, 2000);
                    //按住ctrl 鼠标中间往下滚
                    mf.myroll();
                    mf.mydelay(2000, 4000);
                }
                FuHeSanDian sd = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-关卡界面");
                if (mf.mohuByLeiBool(sd.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, sd.Name);
                    mf.mytap(this._jubing, 456, 53);
                    mf.mydelay(2000, 3000);
                }
                if (panduanjiemian("判断地图界面"))
                {
                    WriteLog.WriteLogFile(this._mnqName, "缩小后，再次进入判断地图界面");
                    mf.mytap(this._jubing, 226, 151);//强者券
                    mf.mydelay(6000, 8000);
                    mf.mytap(this._jubing, 299, 286);
                    mf.mydelay(4000, 6000);
                }
                if (panduanjiemian("判断地图界面"))
                {
                    mf.mydelay(1000, 3000);
                    for (int j = 0; j < 2; j++)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (j == 0)
                            {
                                mf.mytap(this._jubing, 319, 155);
                            }
                            if (j == 1)
                            {
                                mf.mytap(this._jubing, 253, 54);
                            }
                            sd = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-宝箱领取");
                            if (mf.mohuByLeiBool(sd.Sd))
                            {
                                WriteLog.WriteLogFile(this._mnqName, sd.Name);
                                mf.mytap(this._jubing, sd.Zhidingx, sd.Zhidingy);
                                mf.mydelay(2000, 4000);
                                tiaoguo();
                            }
                        }
                    }
                }
            }
            WriteLog.WriteLogFile(this._mnqName, "地图事件结束");
            long ks = MyFuncUtil.GetTimestamp();
            while (true)
            {
                mf.mytap(this._jubing, 44, 119);//开主线
                mf.mydelay(2000, 4000);
                if (!panduanjiemian("判断地图界面")){
                    break;//需要至少点3次
                }
                if (panduanjiemian("主界面")) {
                    break;
                }
                long js = MyFuncUtil.GetTimestamp();
                if ((js - ks) > 1000 * 30)
                {
                    guanbi_all();
                }
                if ((js - ks) > 1000 * 60) {
                    break;
                }
            }
        }

        private void zhaoxiangzi_renwu() {
            int x = -1, y = -1;
            DuoDianZhaoSe dz = new DuoDianZhaoSe(0x2f8551, "0|4|0xfbc8b3,6|5|0x627e56,6|-3|0xe5cac2,-5|5|0x19482a,0|7|0xffffff,5|7|0xa17a18", 90, 150, 100, 170, 121);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"进入战斗寻人场景-准备找箱子");
                dz = new DuoDianZhaoSe(0x9b7d5a, "2|-4|0xf8da25,-7|-4|0xf2c027,-7|2|0xffeb53,-1|3|0xe9a61a,4|4|0x653a07,4|-5|0xffff27", 90, 0, 0, 215, 121);
                mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                if (x != -1 && y != -1)
                {
                    WriteLog.WriteLogFile(this._mnqName,"发现黄色箱子");
                    mf.mytap(this._jubing, x, y);
                    mf.mydelay(3000, 6000);
                    dz = new DuoDianZhaoSe(0xdb3422, "-5|0|0xdd341f,-8|0|0x952124,-3|-5|0xf94028,44|8|0xf1efe2,54|8|0xf1efe2,95|5|0xa42426", 90, 50, 10, 180, 40);
                    mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        WriteLog.WriteLogFile(this._mnqName,"领取宝箱");
                        mf.mytap(this._jubing, 108, 78);
                        mf.mydelay(100, 600);
                    }
                }
                dz = new DuoDianZhaoSe(0xebe2be, "0|-9|0xb48f3a,-5|-9|0x61321a,-5|1|0xffe98c,0|4|0xeaa71b,2|6|0xf2ad1a,-1|6|0xb95913", 90, 0, 0, 215, 121);
                mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                if (x != -1 && y != -1)
                {
                    WriteLog.WriteLogFile(this._mnqName,"发现黄色箱子2");
                    mf.mytap(this._jubing, x, y);
                    mf.mydelay(3000, 6000);
                    dz = new DuoDianZhaoSe(0xdb3422, "-5|0|0xdd341f,-8|0|0x952124,-3|-5|0xf94028,44|8|0xf1efe2,54|8|0xf1efe2,95|5|0xa42426", 90, 50, 10, 180, 40);
                    mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        WriteLog.WriteLogFile(this._mnqName,"领取宝箱");
                        mf.mytap(this._jubing, 108, 78);
                        mf.mydelay(100, 600);
                    }
                }
                dz = new DuoDianZhaoSe( 0xf5b426, "0|-7|0xe1cda5,-6|-3|0xfff28e,-6|0|0xffd73f,-1|0|0xf5b426,7|0|0x956206,1|3|0xa73420", 90, 0, 0, 215, 121);
                mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                if (x != -1 && y != -1)
                {
                    WriteLog.WriteLogFile(this._mnqName,"发现黄色箱子3");
                    mf.mytap(this._jubing, x, y);
                    mf.mydelay(3000, 6000);
                    dz = new DuoDianZhaoSe(0xdb3422, "-5|0|0xdd341f,-8|0|0x952124,-3|-5|0xf94028,44|8|0xf1efe2,54|8|0xf1efe2,95|5|0xa42426", 90, 50, 10, 180, 40);
                    mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        WriteLog.WriteLogFile(this._mnqName,"领取宝箱");
                        mf.mytap(this._jubing, 108, 78);
                        mf.mydelay(100, 600);
                    }
                }
            }
        }

       

        
        
        
   

        private void dijibieks() {
            WriteLog.WriteLogFile(this._mnqName, "进入低级别ks" + _dqinx + " " + mf.Ver());
            int shangzhen = 0;
            int zidongzhandou = 0;
            int putonggongji = 0;
            int didiwang = 0;
            int yiquantongguan = 0;
            int kaishiditu = 0;
            int kai1beisu = 0;
            int mrkaiqiq = 0;
            int guanyindaojueseyangcheng = 0;
            int dingtou = -1;
            int xiehuijingji = 0;
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
                var jstime = MyFuncUtil.GetTimestamp();
                if ((jstime - kstime) > 60 * 1000 * 20)
                {
                    //20分钟重新计时
                    kstime = MyFuncUtil.GetTimestamp();
                    WriteLog.WriteLogFile(this._mnqName, "20分钟重新计时");
                }
                if ((jstime - kpjishi) > 30 * 1000 && compareColor(kapingyanse1, kapingyanse2))
                {
                    //调用卡屏函数  和卡屏引导函数                 
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
                    //WriteLog.WriteLogFile(this._mnqName, "30秒颜色不等时,更新颜色" + kapingyanse1[0] + " " + kapingyanse2[0] + "  " + kapingyanse1[1] + " " + kapingyanse2[1]);
                    kapingyanse1 = mf.myGetColorWuJbList(kpzb);
                    kpjishi = MyFuncUtil.GetTimestamp();
                    kp1 = MyFuncUtil.GetTimestamp();
                }

                SanDian zdhm = YiQuan_SanDian.GetObject().findFuHeSandianByName("战斗画面").Sd;
                if (panduanzhandou(zdhm))
                {
                    break;
                }

                SanDian zdsb = YiQuan_SanDian.GetObject().findFuHeSandianByName("出现战斗失败").Sd;
                if (mf.jingqueByLeiBool(zdsb))
                {
                    shibai = 1;
                    if (zaicishibai > 2)
                    {
                        break;
                    }
                }
                if (shibai == 1 && zaicishibai < 2)
                {
                    WriteLog.WriteLogFile(this._mnqName, "战斗第一次失败,进入到角色强化循环");
                    zhaozhujiemian(20 * 1000);
                    qianghua();
                    lingqu();
                    zhaozhujiemian(20 * 1000);
                    zaicishibai++;
                }
                //特定点相关
                FuHeSanDian fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("开头的战斗超人画像1");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, 298, 156);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("开头的战斗超人画像2");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("开头的战斗超人画像3");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("开头的骑士画像1");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("开头的骑士画像2");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("开头的爆炸头1");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("开头的爆炸头2");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("开头的一拳光头");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("开头的第一章");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("开头的第一章完成");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("章节的进行中");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("第二章开始任务");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("开头的第2章打巨人");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("开头领取任务奖励");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("开头光头提示有强者券");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("光头-招募开始");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-任务招募");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    if (mf.myGetColorWuJuYouYanSe(280, 105, 0xefb294))
                    {
                        WriteLog.WriteLogFile(this._mnqName, "11");
                        mf.mytap(this._jubing, 480, 126);
                    }
                    else
                    {
                        mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                    }
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("光头-招募男人");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-女人招募");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-设置昵称");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-光头探索");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-进入关卡");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-关卡界面");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    compareSandianAndtap(fhzd1, 2000, () => mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy),
                        () =>
                        {
                            if (mf.mohu(141, 180, 0x363536) == 1)
                            {
                                WriteLog.WriteLogFile(this._mnqName, "第1关精英");
                                mf.mytap(this._jubing, 349, 53);
                            }
                            else
                            {
                                WriteLog.WriteLogFile(this._mnqName, "第1次关闭");
                                mf.mytap(this._jubing, 456, 53);
                            }
                        });
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("第一关繁华街道界面");
                FuHeSanDian fhzd2 = YiQuan_SanDian.GetObject().findFuHeSandianByName("第二关无人区界面");

                if (mf.mohuByLeiBool(fhzd1.Sd) || mf.mohuByLeiBool(fhzd2.Sd) || zhandou_jiedao())
                {
                    int x = -1, y = -1;
                    FuHeDuoDian hq = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("类似光头红色拳头");
                    mf.myqudianqusezuobiaoByLeiWuJubing(hq.Dz, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        WriteLog.WriteLogFile(this._mnqName, hq.Name + x + " " + y);
                        mf.mytap(this._jubing, x, y + 50);
                    }
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("战斗介绍1");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("战斗介绍2");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("战斗介绍3");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("战斗介绍4");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    compareSandianAndtap(fhzd1, 2000, () => mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy),
                        () =>
                        {
                            if (mf.myGetColorWuJuYouYanSe(335, 91, 0x50deff))
                            {
                                WriteLog.WriteLogFile(this._mnqName, "战斗介绍4打前排第一个");
                                mf.mytap(this._jubing, 336, 88);
                            }
                            if (mf.myGetColorWuJuYouYanSe(387, 187, 0x5ee9ff))
                            {
                                WriteLog.WriteLogFile(this._mnqName, "战斗介绍4打前排第二个");
                                mf.mytap(this._jubing, 387, 187);
                            }
                            mf.mytap(this._jubing, 358, 128);
                        });
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("战斗介绍5");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("战斗介绍6");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    compareSandianAndtap(fhzd1, 2000, () => mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy),
                        () => mf.mytap(this._jubing, 408, 87));
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("战斗介绍8");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("第一关繁华街道界面");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    Dictionary<String, FuHeSanDian> dc = YiQuan_SanDian.GetObject().getYiQuanDict();
                    fhzd1 = dc["第一关领取宝箱"];
                    if (mf.mohuByLeiBool(fhzd1.Sd))
                    {
                        mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                    };
                }
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-宝箱领取");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("第一关角色升级");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("第一关角色升级第二步");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-角色养成");
                if (guanyindaojueseyangcheng == 0 && mf.mohuByLeiBool(fhzd1.Sd))
                {
                    int tx = fhzd1.Zhidingx;
                    int ty = fhzd1.Zhidingy;
                    fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("剧情任务第四章未解锁");
                    if (mf.mohuByLeiBool(fhzd1.Sd))
                    {
                        mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                        mf.mydelay(1000, 1500);
                    }
                    fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-徽章缺少");
                    if (mf.mohuByLeiBool(fhzd1.Sd))
                    {
                        mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                    }
                    fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-角色养成");
                    compareSandianAndtap(fhzd1, 2000, () =>
                    {
                        if (mf.mohu(480, 64, 0x3f3e3f) != 1)
                        {
                            mf.mytap(this._jubing, tx, ty);
                        }
                    },
                        () => mf.mytap(this._jubing, 510, 9));
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-养成角色经验可用");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("第一关繁华街道界面");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-招募骑士");
                    if (mf.mohuByLeiBool(fhzd1.Sd))
                    {
                        mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                        shangzhen = 1;
                    };
                }
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-骑士上阵");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, fhzd1.Name);
                    mf.mydelay(100, 600);
                    mf.mydrag(this._jubing, 41, 266, 290, 210);
                    mf.mydelay(100, 800);
                    shangzhen = 0;
                }
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("第一关繁华街道界面");
                if (mf.mohuByLeiBool(fhzd1.Sd) && shangzhen == 1)
                {
                    mf.mytap(this._jubing, 494, 277);
                }
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("核心技光头对话");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("核心技光头对话2");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-关闭核心技");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-关闭布阵");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    compareSandianAndtap(fhzd1, 2000, () => mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy),
                        () => mf.mytap(this._jubing, 30, 58)
                        );
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("第一关繁华街道界面");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("第一关关底领宝箱");
                    if (mf.mohuByLeiBool(fhzd1.Sd))
                    {
                        mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                    };
                }
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-关闭离开关卡");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("关闭离开关卡-全得到");
                    if (mf.mohuByLeiBool(fhzd1.Sd))
                    {
                        mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                    }
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("第二关开启");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                }
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("战斗画面骑士怒吼");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("战斗画面骑士怒吼给女人");
                    if (mf.mohuByLeiBool(fhzd1.Sd))
                    {
                        mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                    }
                    fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("战斗画面骑士怒吼");
                    if (mf.mohuByLeiBool(fhzd1.Sd))
                    {
                        mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                    }
                }

                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("自动战斗打开光头提示");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    zidongzhandou = 1;
                };

                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-黑屏普通攻击");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, 431, 275);
                    putonggongji = 1;
                };

                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("发现地底王");
                if (mf.mohuByLeiBool(fhzd1.Sd) && didiwang == 0)
                {
                    didiwang = 1;
                    mf.mytap(this._jubing, 268, 284);
                    WriteLog.WriteLogFile(this._mnqName, "打地底王前先升级");
                    zhaozhujiemian(20 * 1000);
                    qianghua();
                    zhaozhujiemian(20 * 1000);
                    mf.mytap(this._jubing, 44, 119);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("开启第二关的精英关卡");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("试试一拳通关");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-一拳通关");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    if (yiquantongguan == 0)
                    {
                        mf.mytap(this._jubing, 116, 194);
                    }
                    else
                    {
                        mf.mytap(this._jubing, 478, 32);
                    }
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-一拳通关完成关闭");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                    yiquantongguan = 1;
                    kaishiditu = 1;
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("第一精英关领取宝箱");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                    kaishiditu = 1;
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("地图事件触发");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    zhaoxiangzi_ditu();
                    kaishiditu = 0;
                    kai1beisu = 1;
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("判断地图界面");
                if (mf.mohuByLeiBool(fhzd1.Sd) && kaishiditu == 1)
                {
                    zhaoxiangzi_ditu();
                    kaishiditu = 0;
                    kai1beisu = 1;
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("加1倍速开启");
                if (mf.mohuByLeiBool(fhzd1.Sd) && kaishiditu == 1)//1拳后开1倍速
                {
                    kai1beisu = 1;
                    WriteLog.WriteLogFile(this._mnqName, "开启1倍速");
                };
                //地图事件后
                //做任务 第三章开始
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("开始第三章任务");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("第三章任务完成直接领");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("日常已完成");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                    kai1beisu = 1;
                    guanyindaojueseyangcheng = 1; //关引导角色养成
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("有主线任务");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("任务领完继续背头侠");
                    if (mf.mohuByLeiBool(fhzd1.Sd) && mrkaiqiq == 0)
                    {
                        mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                    };
                }
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("体力获取小窗口先关闭");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("领取登录有礼的关闭");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("每日任务光头开启");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                    mrkaiqiq = 1;//大背头侠任务提示不再有效
                    //关 引导时-角色养成  
                    guanyindaojueseyangcheng = 1;
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-支线完成领取");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    compareSandianAndtap(fhzd1, 2000, () => mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy),
                        () =>
                        {
                            if (mf.mohu(489, 183, 0xfeda21) == 1)
                            {
                                mf.mytap(this._jubing, 489, 183);
                            }
                            if (mf.mohu(491, 238, 0xfeda21) == 1)
                            {
                                mf.mytap(this._jubing, 491, 238);
                            }
                            mf.mytap(this._jubing, 512, 8);
                        }
                        );
                    guanyindaojueseyangcheng = 0;
                    //打开引导时角色养成
                };

                //钉头锤任务系列
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("钉头锤光头提示");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                    mrkaiqiq = 1;//大背头侠任务提示不再有效
                    //关 引导时-角色养成  
                    guanyindaojueseyangcheng = 1;
                    dingtou = 0;
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("钉头锤光头提示2");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                    mrkaiqiq = 1;//大背头侠任务提示不再有效
                    //关 引导时-角色养成  
                    guanyindaojueseyangcheng = 1;
                    dingtou = 0;
                };

                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("钉头锤光头提示3");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                    mrkaiqiq = 1;//大背头侠任务提示不再有效
                    //关 引导时-角色养成  
                    guanyindaojueseyangcheng = 1;
                    dingtou = 0;
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("钉头锤光头提示4");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                    mrkaiqiq = 1;//大背头侠任务提示不再有效
                    //关 引导时-角色养成  
                    guanyindaojueseyangcheng = 1;
                    dingtou = 0;
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("钉头锤特定点");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                    mrkaiqiq = 1;//大背头侠任务提示不再有效
                    //关 引导时-角色养成  
                    guanyindaojueseyangcheng = 1;
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("获得钉头锤");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, "获得钉头锤升级");
                    zhaozhujiemian(20 * 1000);
                    qianghua();
                    zhaozhujiemian(20 * 1000);
                    mrkaiqiq = 0;
                    mf.mytap(this._jubing, 44, 119);
                    dingtou = -1;
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("获得钉头锤后支线任务判断");
                if (dingtou == 0 && mf.mohuByLeiBool(fhzd1.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, "获得钉头锤升级");
                    zhaozhujiemian(20 * 1000);
                    qianghua();
                    zhaozhujiemian(20 * 1000);
                    mrkaiqiq = 0;
                    mf.mytap(this._jubing, 44, 119);
                    dingtou = -1;
                };
                //协会竞技系列
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("协会竞技光头");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("协会竞技光头2");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("协会竞技光头3");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("协会竞技光头4");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("协会竞技光头5");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("协会竞技光头6");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    compareSandianAndtap(fhzd1, 2000, () => mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy),
                    () => xiehuijingji = 1);
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("协会竞技");
                if (xiehuijingji == 1 && mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                    xiehuijingji = 2;
                };
                if (xiehuijingji == 4 && mf.mohuByLeiBool(fhzd1.Sd))
                {
                    mf.mytap(this._jubing, 512, 10);
                    mf.mydelay(3000, 4000);
                    mf.mytap(this._jubing, 512, 10);
                    mf.mydelay(3000, 4000);
                    mrkaiqiq = 0;
                    fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("有主线任务");
                    if (mf.mohuByLeiBool(fhzd1.Sd))
                    {
                        mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                    }
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("协会竞技一键领取");
                if (xiehuijingji == 2 && mf.mohuByLeiBool(fhzd1.Sd))
                {
                    if (mf.mohu(435, 79, 0xffd620) == 1)
                    {
                        mf.mytap(this._jubing, 435, 79);
                        mf.mydelay(2000, 3000);
                    }
                    if (mf.mohu(438, 126, 0xfece18) == 1)
                    {
                        mf.mytap(this._jubing, 438, 126);
                        mf.mydelay(2000, 3000);
                    }
                    xiehuijingji = 3;
                    fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("协会竞技一键领取可以关闭");
                    if (mf.mohuByLeiBool(fhzd1.Sd))
                    {
                        mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                        mf.mydelay(2000, 3000);
                    };
                    fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("协会竞技");
                    if (mf.mohuByLeiBool(fhzd1.Sd))
                    {
                        xiehuijingji = 4;
                    }
                };
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("协会竞技一键领取可以关闭");
                if (xiehuijingji == 3 && mf.mohuByLeiBool(fhzd1.Sd))
                {
                    compareSandianAndtap(fhzd1, 2000, () =>
                    mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy),
                    () =>
                    {
                        fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("协会竞技");
                        if (mf.mohuByLeiBool(fhzd1.Sd))
                        {
                            xiehuijingji = 4;
                        }
                    });
                };
                if (panduanjiemian("布阵界面"))
                {
                    if (mf.mohu(57, 240, 0xc3c7c3) == 1)
                    {
                        mf.mytap(this._jubing, fhzd1.Zhidingx, fhzd1.Zhidingy);
                        mf.mydelay(2000, 3000);
                        mf.mytap(this._jubing, 463, 267);
                    }
                    else
                    {
                        mf.mytap(this._jubing, 463, 267);
                    }
                }

                zhandouxiangguan(zidongzhandou, putonggongji, kai1beisu);
                tiaoguo();

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
        private void zhandouxiangguan(int zidongzhandou, int putonggongji,int kai1beisu)
        {
            if (panduanjiemian("战斗画面"))
            {
                WriteLog.WriteLogFile(this._mnqName, zidongzhandou +" "+ putonggongji + " " + kai1beisu);
                FuHeSanDian sd = YiQuan_SanDian.GetObject().findFuHeSandianByName("战斗手动开");
                if (zidongzhandou == 1 && mf.mohuByLeiBool(sd.Sd))
                {
                    WriteLog.WriteLogFile(this._mnqName, sd.Name + sd.Zhidingx + " " + sd.Zhidingy);
                    mf.mydelay(100, 600);
                    mf.mytap(this._jubing, sd.Zhidingx, sd.Zhidingy);
                    mf.mydelay(100, 800);
                }
                if ((putonggongji == 1) && (mf.fanwei(420, 286, 440, 294, 0xbad0e3) == 1))
                {

                    WriteLog.WriteLogFile(this._mnqName, "普通攻击开");
                    mf.mytap(this._jubing, 431, 274);
                    mf.mydelay(100, 800);
                }
                sd = YiQuan_SanDian.GetObject().findFuHeSandianByName("战斗1倍速");
                if ((kai1beisu == 1) && (mf.mohuByLeiBool(sd.Sd)))
                {
                    WriteLog.WriteLogFile(this._mnqName, sd.Name + sd.Zhidingx + " " + sd.Zhidingy);
                    mf.mytap(this._jubing, sd.Zhidingx, sd.Zhidingy);
                }
                sd = YiQuan_SanDian.GetObject().findFuHeSandianByName("自动战斗集火光头提示");
                if (mf.mohuByLeiBool(sd.Sd))
                {
                    mf.mytap(this._jubing, 387, 189);
                }
                FuHeSanDian fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("战斗画面男人第二关");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    if (mf.fanwei(490, 287, 516, 296, 0x94efff) == 1)
                    {
                        WriteLog.WriteLogFile(this._mnqName, "可以用绝技");
                        mf.mytap(this._jubing, 507, 275);
                        zhandouxuanren();
                    }
                    zhandouxuanren();
                }
                fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("战斗画面女人单打");
                if (mf.mohuByLeiBool(fhzd1.Sd))
                {
                    if (mf.fanwei(490, 287, 516, 296, 0x94efff) == 1)
                    {
                        WriteLog.WriteLogFile(this._mnqName, "可以用绝技");
                        mf.mytap(this._jubing, 507, 275);
                        zhandouxuanren();
                    }
                    zhandouxuanren();
                };
                sd = YiQuan_SanDian.GetObject().findFuHeSandianByName("战斗中可跳过");
                if (mf.mohuByLeiBool(sd.Sd))
                {
                    mf.mytap(this._jubing, sd.Zhidingx, sd.Zhidingy);
                }
            }
            //战斗倍速问题
        }
        private bool zhandou_jiedao() {
            FuHeSanDian fhzd1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-强化开始");
            FuHeSanDian fhzd2 = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色关闭窗口");
            if (mf.mohuByLeiBool(fhzd1.Sd) && (mf.mohuByLeiBool(fhzd2.Sd))) {
                return true;
            }
            return false;
        }

        private void zuozhuxian() {
            FuHeSanDian fhzd2 = YiQuan_SanDian.GetObject().findFuHeSandianByName("有主线任务");
            if (mf.mohuByLeiBool(fhzd2.Sd))
            {
                
            }
        }

        public void lingqu()
        {
            WriteLog.WriteLogFile(this._mnqName, "进入到领取环节");
            lingqu_youjian();
        }
        private void lingqu_youjian()
        {
            zhaozhujiemian(20 * 1000);
            if (!panduanjiemian("主界面"))
            {
                WriteLog.WriteLogFile(this._mnqName,"进入主界面失败,领取不继续!");
                return;
            }
            FuHeSanDian fh = YiQuan_SanDian.GetObject().findFuHeSandianByName("领取新手指引");
            if (mf.mohuByLeiBool(fh.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, fh.Name);
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                mf.mydelay(2000, 4000);
                mf.mytap(this._jubing, 280, 136);
                mf.mydelay(100, 800);
                mf.mydelay(2000, 4000);
                mf.mytap(this._jubing, 326, 247);
                mf.mydelay(2000, 4000);
                mf.mytap(this._jubing, 326, 247);
                mf.mydelay(2000, 4000);
                mf.mytap(this._jubing, 378, 37);
            }
            zhaozhujiemian(20 * 1000);
            if (!panduanjiemian("主界面"))
            {
                WriteLog.WriteLogFile(this._mnqName, "进入主界面失败,领取不继续!");
                return;
            }
            fh = YiQuan_SanDian.GetObject().findFuHeSandianByName("领取登录有礼");
            if (mf.mohuByLeiBool(fh.Sd))
            {
                for (int i = 0; i < 3; i++) {
                    if (mf.myGetColorWuJuYouYanSe(419, 125, 0xffcf1b))
                    {
                        mf.mytap(this._jubing, 419, 125);
                        mf.mydelay(2000, 4000);
                        mf.mytap(this._jubing, 419, 125);
                    }
                    if (mf.myGetColorWuJuYouYanSe(420, 182, 0xffcf18))
                    {
                        mf.mytap(this._jubing, 420, 182);
                        mf.mydelay(2000, 4000);
                        mf.mytap(this._jubing, 420, 182);
                    }
                }
            }
            zhaozhujiemian(20 * 1000);
            if (!panduanjiemian("主界面"))
            {
                WriteLog.WriteLogFile(this._mnqName, "进入主界面失败,领取不继续!");
                return;
            }
            fh = YiQuan_SanDian.GetObject().findFuHeSandianByName("领取邮件");
            if (mf.mohuByLeiBool(fh.Sd))
            {
                for (int i = 0; i < 3; i++)
                {
                    if (mf.myGetColorWuJuYouYanSe(493, 264, 0xffdb21))
                    {
                        mf.mytap(this._jubing, 493, 264);
                        mf.mydelay(2000, 4000);                        
                    }
                }
            }
            zhaozhujiemian(20 * 1000);
            if (!panduanjiemian("主界面"))
            {
                WriteLog.WriteLogFile(this._mnqName, "进入主界面失败,领取不继续!");
                return;
            }
            fh = YiQuan_SanDian.GetObject().findFuHeSandianByName("领取次日登录");
            if (mf.mohuByLeiBool(fh.Sd))
            {
                for (int i = 0; i < 3; i++)
                {
                    if (mf.myGetColorWuJuYouYanSe(419, 125, 0xffcf1b))
                    {
                        mf.mytap(this._jubing, 419, 125);
                        mf.mydelay(2000, 4000);
                        mf.mytap(this._jubing, 419, 125);
                    }
                    if (mf.myGetColorWuJuYouYanSe(420, 182, 0xffcf18))
                    {
                        mf.mytap(this._jubing, 420, 182);
                        mf.mydelay(2000, 4000);
                        mf.mytap(this._jubing, 420, 182);
                    }
                }
            }
        }
        public void qianghua()
        {
            WriteLog.WriteLogFile(this._mnqName, "进去强化");
            long ks = MyFuncUtil.GetTimestamp();
            bool tmp = jinrujueseqianghua();
            if (!tmp) {
                return;
            }
            //等级低无卡片 进入角色养成
            mf.mytap(this._jubing, 480, 62);
            mf.mydelay(2000, 4000);
            FuHeSanDian yc = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-出现光头");
            if (mf.mohuByLeiBool(yc.Sd))
            {
                List<ZuoBiao> kpzb = new List<ZuoBiao>();
                kpzb.Add(new ZuoBiao(220, 48));
                kpzb.Add(new ZuoBiao(407, 136));
                WriteLog.WriteLogFile(this._mnqName, yc.Name);
                string[] kapingyanse1 = mf.myGetColorWuJbList(kpzb);
                string[] kapingyanse2 = kapingyanse1;
                if (yc.Listzuobiao != null)
                {
                    foreach (ZuoBiao z in yc.Listzuobiao)
                    {
                        mf.mytap(this._jubing, z.X, z.Y);
                        mf.mydelay(1000, 2000);
                        kapingyanse2 = mf.myGetColorWuJbList(kpzb);
                        if (!compareColor(kapingyanse1, kapingyanse2))
                        {
                            break;
                        }
                    }
                }
                mf.mytap(this._jubing, 444, 50);
                mf.mydelay(1000, 2000);
                mf.mytap(this._jubing, 444, 50);
                mf.mydelay(1000, 2000);
            }
            yc = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-养成角色可关闭");
            if (mf.mohuByLeiBool(yc.Sd))
            {
                mf.mytap(this._jubing, 27, 266);
                mf.mydelay(800, 2000);
                jibieshengji();
                mf.mydelay(800, 2000);
                mf.mytap(this._jubing, 76, 266);
                mf.mydelay(800, 2000);
                jibieshengji();
                mf.mydelay(800, 2000);
                if (mf.mohu(136, 269, 0x423744) != 1) //第三个角色可升级不是黑色框
                {
                    WriteLog.WriteLogFile(this._mnqName, "第3个角色可升级");
                    mf.mytap(this._jubing, 135, 266);
                    mf.mydelay(800, 2000);
                    jibieshengji();
                    mf.mydelay(800, 2000);
                }
                if (mf.mohu(186, 279, 0x443f46) != 1) //第4个角色可升级不是黑色框
                {
                    WriteLog.WriteLogFile(this._mnqName, "第4个角色可升级");
                    mf.mytap(this._jubing, 170, 266);//第4个角色可升级不是黑色框
                    mf.mydelay(800, 2000);
                    jibieshengji();
                    mf.mydelay(800, 2000);
                }
            }
            WriteLog.WriteLogFile(this._mnqName, "强化完结");
        }

       

        private void jibieshengji()
        {
            //喝经验饮料
            int yaotiao = 0;
            for (int j = 0; j < 3; j++)
            {
                int zuobx = -1, zuoby = -1;
                if (j == 0) {
                    zuobx = 313;
                    zuoby = 100;
                }
                if (j == 1)
                {
                    zuobx = 372;
                    zuoby = 107;
                }
                if (j == 2)
                {
                    zuobx = 433;
                    zuoby = 101;
                }
                int cishu = MyFuncUtil.suijishu(4, 8);
                int dianjishu = 0;
                long ks = MyFuncUtil.GetTimestamp();
                while(true)
                {
                    FuHeSanDian yc = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-养成角色经验到顶");
                    if (mf.mohuByLeiBool(yc.Sd))
                    {
                        WriteLog.WriteLogFile(this._mnqName, yc.Name);
                        mf.mytap(this._jubing, 371, 266);
                        mf.mydelay(1000, 2000);
                        mf.mytap(this._jubing, tiaoguoyongX, tiaoguoyongY);
                    }
                    yc = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-养成角色经验可用");
                    if (mf.mohuByLeiBool(yc.Sd))
                    {
                        mf.mytap(this._jubing, zuobx, zuoby);
                        mf.mydelay(1000, 2000);
                        dianjishu++;
                        if (dianjishu > cishu) {
                            break;
                        }
                    }
                    yc = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-徽章获取仅前往");
                    if (mf.mohuByLeiBool(yc.Sd))
                    {
                        WriteLog.WriteLogFile(this._mnqName, yc.Name);
                        mf.mytap(this._jubing, 444, 50);
                        mf.mydelay(1000, 2000);
                        break;
                    }
                    yc = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-出现光头");
                    if (mf.mohuByLeiBool(yc.Sd))
                    {
                        List<ZuoBiao> kpzb = new List<ZuoBiao>();
                        kpzb.Add(new ZuoBiao(220, 48));
                        kpzb.Add(new ZuoBiao(407, 136));
                        WriteLog.WriteLogFile(this._mnqName, yc.Name);
                        string[] kapingyanse1 = mf.myGetColorWuJbList(kpzb);
                        string[] kapingyanse2 = kapingyanse1;
                        if (yc.Listzuobiao != null)
                        {
                            foreach (ZuoBiao z in yc.Listzuobiao)
                            {
                                mf.mytap(this._jubing, z.X, z.Y);
                                mf.mydelay(1000, 2000);
                                kapingyanse2 = mf.myGetColorWuJbList(kpzb);
                                if (!compareColor(kapingyanse1, kapingyanse2))
                                {
                                    break;
                                }
                            }
                        }
                        mf.mytap(this._jubing, 444, 50);
                        mf.mydelay(1000, 2000);
                        mf.mytap(this._jubing, 444, 50);
                        mf.mydelay(1000, 2000);
                    }
                    yc = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-徽章获取有一拳");
                    if (mf.mohuByLeiBool(yc.Sd))
                    {
                        WriteLog.WriteLogFile(this._mnqName, yc.Name);
                        mf.mytap(this._jubing, 444, 50);
                        mf.mydelay(1000, 2000);
                    }
                    long js = MyFuncUtil.GetTimestamp();
                    if ((js - ks) > 1000 * 30) {
                        break;
                    }
                    FuHeSanDian hz1 = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-徽章缺少");
                    if (mf.mohuByLeiBool(hz1.Sd))
                    {
                        yaotiao = 1;
                        break;
                    }
                    tiaoguo();
                }
                if (yaotiao == 1) {
                    break;
                }
            }
            //开始搞徽章
            FuHeSanDian hz = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-徽章缺少");
            if (mf.mohuByLeiBool(hz.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, hz.Name);
                for(int i=0;i<3;i++){
                    int mx = -1;
                    int my = -1;
                    mf.fanweiyoufanhui(288, 125, 464, 134, 0xeb8985, out mx, out my);
                    if (mx != -1 && my != -1)
                    {
                        mf.mytap(this._jubing, mx, my - 20);
                        mf.mydelay(1000, 2000);
                        hz = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-徽章获取仅前往");
                        if (mf.mohuByLeiBool(hz.Sd))
                        {
                            WriteLog.WriteLogFile(this._mnqName, hz.Name);
                            mf.mytap(this._jubing, 444, 50);
                            mf.mydelay(1000, 2000);
                            break;
                        }
                        FuHeSanDian yc = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-出现光头");
                        if (mf.mohuByLeiBool(yc.Sd))
                        {
                            List<ZuoBiao> kpzb = new List<ZuoBiao>();
                            kpzb.Add(new ZuoBiao(220, 48));
                            kpzb.Add(new ZuoBiao(407, 136));
                            WriteLog.WriteLogFile(this._mnqName, yc.Name);
                            string[] kapingyanse1 = mf.myGetColorWuJbList(kpzb);
                            string[] kapingyanse2 = kapingyanse1;
                            if (yc.Listzuobiao != null)
                            {
                                foreach (ZuoBiao z in yc.Listzuobiao)
                                {
                                    mf.mytap(this._jubing, z.X, z.Y);
                                    mf.mydelay(1000, 2000);
                                    kapingyanse2 = mf.myGetColorWuJbList(kpzb);
                                    if (!compareColor(kapingyanse1, kapingyanse2))
                                    {
                                        break;
                                    }
                                }
                            }                            
                            mf.mytap(this._jubing, 444, 50);
                            mf.mydelay(1000, 2000);
                            mf.mytap(this._jubing, 444, 50);
                            mf.mydelay(1000, 2000);
                        }
                        yc = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-徽章获取有一拳");
                        if (mf.mohuByLeiBool(yc.Sd))
                        {
                            WriteLog.WriteLogFile(this._mnqName, yc.Name);
                            if (mf.mohu(378, 94, 0x5b4112) == 1)
                            {
                                mf.mytap(this._jubing, 373, 94);
                                mf.mydelay(1000, 2000);
                            }
                            if (mf.mohu(378, 144, 0x5e4513) == 1)
                            {
                                mf.mytap(this._jubing, 373, 144);
                                mf.mydelay(1000, 2000);
                            }
                            if (mf.mohu(378, 194, 0x5e4513) == 1)
                            {
                                mf.mytap(this._jubing, 373, 194);
                                mf.mydelay(1000, 2000);
                            }
                            FuHeSanDian dh = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-一拳通关动画");
                            if (mf.mohuByLeiBool(dh.Sd))
                            {
                                WriteLog.WriteLogFile(this._mnqName, dh.Name);
                                if (mf.mohu(327, 238, 0xd7d7d7) == 1)
                                {
                                    //不可10次
                                }
                                for (int j = 0; j < 10; j++)
                                {
                                    if (mf.mohu(219, 236, 0xffe13d) == 1)//可1次
                                    {
                                        mf.mytap(this._jubing, 211, 238);
                                    }
                                    FuHeSanDian tg = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-一拳通关动画完成");
                                    if (mf.mohu(172, 85, 0xb11f20) == 1 && mf.mohuByLeiBool(tg.Sd))
                                    {
                                        WriteLog.WriteLogFile(this._mnqName, tg.Name + "到顶了");
                                        break;
                                    }
                                    mf.mydelay(2000, 4000);
                                }
                                //关闭动画
                                FuHeSanDian mdh = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-一拳通关动画完成");
                                SanDian[] sdz = new SanDian[] { mdh.Sd };
                                mf.mohuqubiaoXunHuan(sdz, 60);
                                mf.mytap(this._jubing, 445, 50);
                                mf.mydelay(1000, 2000);
                                tiaoguo();
                            }
                        }
                    }
                    FuHeSanDian yc2 = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-养成角色经验到顶");
                    if (mf.mohuByLeiBool(yc2.Sd))
                    {
                        WriteLog.WriteLogFile(this._mnqName, yc2.Name);
                        mf.mytap(this._jubing, 371, 266);
                        mf.mydelay(1000, 2000);
                        mf.mytap(this._jubing, tiaoguoyongX, tiaoguoyongY);
                    }
                }

            }
            
        }


        private bool jinrujueseqianghua() {
            long ks = MyFuncUtil.GetTimestamp();
            bool tmp = false;
            WriteLog.WriteLogFile(this._mnqName, "准备进入角色强化界面");
            while (true)
            {
                FuHeSanDian fh = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-强化开始");
                FuHeSanDian fh2 = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-主界面上进入角色界面");
                if (mf.mohuByLeiBool(fh.Sd))
                {
                    mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                    mf.mydelay(100, 800);
                }
                if (mf.mohuByLeiBool(fh2.Sd))
                {
                    mf.mytap(this._jubing, fh2.Zhidingx, fh2.Zhidingy);
                    mf.mydelay(100, 800);
                }
                fh = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-进入角色界面");
                if (mf.mohuByLeiBool(fh.Sd))
                {
                    mf.mydelay(2000, 2500);
                    if (mf.mohuByLeiBool(fh.Sd))
                    {
                        WriteLog.WriteLogFile(this._mnqName, fh.Name);
                        tmp = true;
                        break;
                    }
                }
                guanbi_all();
                long js = MyFuncUtil.GetTimestamp();
                if ((js - ks) > 1000 * 20)
                {
                    WriteLog.WriteLogFile(this._mnqName, "没有进入到角色第一界面");
                    tmp = false;
                    break;
                }
            }
            return tmp;
        }
        

        public Boolean panduanjiemian(string jiemian) {
            Boolean tmp = false;
            int x = -1;
            int y = -1;
            var kstime = MyFuncUtil.GetTimestamp();
            if ("主界面".Equals(jiemian)) {
                SanDian sd = YiQuan_SanDian.GetObject().findFuHeSandianByName("主界面").Sd;
                if (mf.mohuByLeiBool(sd))
                {
                    tmp = true;
                }                 
            }
            if ("背包界面".Equals(jiemian))
            {
                SanDian sd = YiQuan_SanDian.GetObject().findFuHeSandianByName("背包界面").Sd;
                if (mf.mohuByLeiBool(sd))
                {
                    tmp = true;
                } 
            }
            if ("战斗画面".Equals(jiemian))
            {
                SanDian sd = YiQuan_SanDian.GetObject().findFuHeSandianByName("战斗画面").Sd;
                if (mf.mohuByLeiBool(sd))
                {
                    tmp = true;                       
                } 
            }
            if ("跳过的剧情界面".Equals(jiemian))
            {
                SanDian sd = YiQuan_SanDian.GetObject().findFuHeSandianByName("跳过的剧情界面").Sd;
                if (mf.mohuByLeiBool(sd))
                {
                    tmp = true;
                }
            }
            if ("判断地图界面".Equals(jiemian))
            {
                SanDian sd = YiQuan_SanDian.GetObject().findFuHeSandianByName("判断地图界面").Sd;
                if (mf.mohuByLeiBool(sd))
                {
                    tmp = true;
                }
            }
            if ("布阵界面".Equals(jiemian))
            {
                SanDian sd = YiQuan_SanDian.GetObject().findFuHeSandianByName("布阵界面").Sd;
                if (mf.mohuByLeiBool(sd))
                {
                    tmp = true;
                }
            }


            if ("角色界面".Equals(jiemian))
            {
                while (true)
                {
                    DuoDianZhaoSe dz = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("jsjm").Dz;
                    mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        tmp = true;
                        break;
                    }
                    var jstime = MyFuncUtil.GetTimestamp();
                    if (x == -1 && y == -1 && (jstime - kstime) > 6000)
                    {
                        break;
                    }
                }
            }
            if ("任务界面".Equals(jiemian))
            {
                while (true)
                {
                    DuoDianZhaoSe dz = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("任务界面").Dz;
                    mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        tmp = true;
                        break;
                    }
                    var jstime = MyFuncUtil.GetTimestamp();
                    if (x == -1 && y == -1 && (jstime - kstime) > 6000)
                    {
                        break;
                    }
                }
            }
            if ("战斗后失败".Equals(jiemian))
            {
                while (true)
                {
                    DuoDianZhaoSe dz = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("战斗后失败").Dz;
                    mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        tmp = true;
                        break;
                    }
                    var jstime = MyFuncUtil.GetTimestamp();
                    if (x == -1 && y == -1 && (jstime - kstime) > 6000)
                    {
                        break;
                    }
                }
            }
            return tmp;
        }

        public void guanbi_all() {
            FuHeSanDian fh = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色关闭窗口");
            if (mf.mohuByLeiBool(fh.Sd)) {
                WriteLog.WriteLogFile(this._mnqName, "关闭all" + fh.Name);
                mf.mytap(this._jubing,fh.Zhidingx, fh.Zhidingy);
            }
            fh = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-养成角色可关闭");
            if (mf.mohuByLeiBool(fh.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, "关闭all" + fh.Name);
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
            }
            fh = YiQuan_SanDian.GetObject().findFuHeSandianByName("引导时-关闭离开关卡");
            if (mf.mohuByLeiBool(fh.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, "关闭all" + fh.Name);
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
            }
            fh = YiQuan_SanDian.GetObject().findFuHeSandianByName("角色头像-徽章获取仅前往");
            if (mf.mohuByLeiBool(fh.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, "关闭all" + fh.Name);
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
            }
            fh = YiQuan_SanDian.GetObject().findFuHeSandianByName("领取新手指引关闭");
            if (mf.mohuByLeiBool(fh.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, "关闭all" + fh.Name);
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
            }
            fh = YiQuan_SanDian.GetObject().findFuHeSandianByName("领取登录有礼的关闭");
            if (mf.mohuByLeiBool(fh.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, "关闭all" + fh.Name);
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
            }
            fh = YiQuan_SanDian.GetObject().findFuHeSandianByName("领取登录有礼sr后出现的新关闭");
            if (mf.mohuByLeiBool(fh.Sd))
            {
                WriteLog.WriteLogFile(this._mnqName, "关闭all" + fh.Name);
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
            }
            fh = YiQuan_SanDian.GetObject().findFuHeSandianByName("体力获取小窗口先关闭");
            if (mf.mohuByLeiBool(fh.Sd))
            {
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);

            }
            fh = YiQuan_SanDian.GetObject().findFuHeSandianByName("一拳通关关闭");
            if (mf.mohuByLeiBool(fh.Sd))
            {
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);

            }
            tiaoguo();
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

        public string generalBasicDemo(int ind, string path)
        {
            WriteLog.WriteLogFile(ind + "", "进入到数字识别");            
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
            WriteLog.WriteLogFile(ind + "", "进入到路能账号文字识别");
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
    }
}
