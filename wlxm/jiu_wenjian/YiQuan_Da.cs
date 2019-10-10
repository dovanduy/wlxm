using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xDM;
using MyUtil;
using LuciferSrcipt;
using System.Threading;
using Newtonsoft.Json.Linq;
using Entity;
namespace fuzhu1
{
    public class YiQuan_Da
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
        //private int tiaoguoyongX = 100;
        /// <summary>
        /// 跳过动画专用点击位置y
        /// </summary>
        //private int tiaoguoyongY = 90;


        public YiQuan_Da(xDm mydm, int dqinx, string dizhi)
        {
            this.mf = (myDm)mydm;
            this._dqinx = dqinx;
            this._jubing = MyLdcmd.getDqmoniqiJuBingByIndex(dqinx,dizhi);            
            //模拟器的名字 取值有问题 改为index
            this._mnqName = dqinx + "";
            int r=mf.bindWindow(this._jubing);
            WriteLog.WriteLogFile(this._mnqName, "一拳构造函数,句柄是:" + _jubing + ",模拟器index是:" + _mnqName + "，thread:" + Thread.CurrentThread.ManagedThreadId + "，绑定:" + r);
        }

        public Boolean denglu(int fenzhong)
        {
            WriteLog.WriteLogFile(this._mnqName, "进入到登录环节  " + this._jubing + "，thread:" + Thread.CurrentThread.ManagedThreadId);
            Boolean abc = true;
            long kstime = mf.GetTime();
            DuoDianZhaoSe d = new DuoDianZhaoSe(0xde3421, "-5|1|0xde3126,-6|4|0xbd3429,-13|4|0xeda207,22|26|0x636167,33|26|0x55545c,46|26|0x757376,25|52|0xfb8e37,71|54|0xffdb21", 90, 45, 20, 145, 100);
            int tx = -1, ty = -1;
            mf.myqudianqusezuobiaoByLei(this._jubing, d, out tx, out ty);
            if (tx != -1 && ty != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, "发现网络连接不上");
                return false;
            }
            DuoDianZhaoSe dz = new DuoDianZhaoSe(0xea9300, "0|-19|0x8dc11f,0|16|0x1daee0,-14|16|0x1daee0,-18|0|0xdea03a,-21|-15|0x98c539,-1|-37|0x1eb9ee", 90, 0, 0, 215, 121);
            DuoDianZhaoSe dz2 = new DuoDianZhaoSe(0x353636, "4|0|0xe79941,-3|0|0xd68334,10|19|0xf8b757,8|30|0xf9be66,28|49|0x9a9a9a,33|49|0x9a9a9a", 90, 40, 30, 95, 100);
            DuoDianZhaoSe[] dd = new DuoDianZhaoSe[] { dz, dz2 };
            bool t2 = mf.myqudianqusezuobiaoXunHuan(dd, 60 * fenzhong);
            abc = t2;
            if (!abc)
            {
                WriteLog.WriteLogFile(this._mnqName, "找寻登录界面失败");
            }
            return abc;

        }
        public Boolean zhuce(int fz)
        {
            WriteLog.WriteLogFile(this._mnqName, "进入到注册环节-登录或注册" + " " + this._jubing);
            Boolean zccg = false;
            int tx = -1, ty = -1;    
            DuoDianZhaoSe dz2 = new DuoDianZhaoSe(0x353636, "4|0|0xe79941,-3|0|0xd68334,10|19|0xf8b757,8|30|0xf9be66,28|49|0x9a9a9a,33|49|0x9a9a9a", 90, 40, 30, 95, 100);
            mf.myqudianqusezuobiaoByLei(this._jubing, dz2, out tx, out ty);
            if (tx != -1 && ty != -1)
            {
                long ks = MyFuncUtil.GetTimestamp();
                while (true)
                {
                    mf.myqudianqusezuobiaoByLei(this._jubing, dz2, out tx, out ty);
                    if (tx != -1 && ty != -1) {
                        WriteLog.WriteLogFile(this._mnqName, "发现跳过实名");
                        mf.mytap(this._jubing, 80, 92);//点跳过实名
                    }
                    mf.myqudianqusezuobiao(this._jubing, 0xfffbef, "-2|-1|0xe7beba,-3|3|0xca7170,2|2|0xfdf1e7,4|0|0xca3836,-148|-2|0xcecfce,-166|-2|0xb42720", 90, 20, 0, 205, 20, out tx, out ty);
                    if (tx != -1 && ty != -1)
                    {
                        WriteLog.WriteLogFile(this._mnqName, "发现公告,关闭");
                        mf.mytap(this._jubing, tx, ty);                        
                    }
                    mf.myqudianqusezuobiao(this._jubing, 0xfeda2f, "-6|0|0xe8cc33,-9|0|0x3f2a01,-12|4|0xffd721,5|2|0x4a1800,11|3|0x743409,14|3|0xffd321", 90, 85, 90, 130, 110, out tx, out ty);
                    if (tx != -1 && ty != -1)
                    {
                        WriteLog.WriteLogFile(this._mnqName, "发现进入游戏");
                        mf.mytap(this._jubing, tx, ty);
                        mf.mydelay(4000, 8000);
                        mf.myqudianqusezuobiao(this._jubing, 0xfeda2f, "-6|0|0xe8cc33,-9|0|0x3f2a01,-12|4|0xffd721,5|2|0x4a1800,11|3|0x743409,14|3|0xffd321", 90, 85, 90, 130, 110, out tx, out ty);
                        if (tx == -1 && ty == -1)
                        {
                            zccg = true;
                            break;;
                        }
                    }
                    long jstime = MyFuncUtil.GetTimestamp();
                    if ((jstime - ks) > fz * 60 * 1000)
                    {
                        zccg = false;
                        WriteLog.WriteLogFile(this._mnqName, "注册环节-登录或注册-没有成功完成" + " " + this._jubing);
                        break;;
                    }
                }
                return zccg;
            }
            ZhangHao zhanghao = new ZhangHao();
            string name = null, pas = null;
            long kstime = MyFuncUtil.GetTimestamp();
            int td = 0;
            while (true)
            {
                zhanghao.getNameAndPw(this._dqinx, out name, out pas);
                if (name == null && pas == null)
                {
                    if (td == 0)
                    {
                        zhanghao.generateNameAndPas(this._dqinx, 7, out name, out pas);
                        mf.mytap(this._jubing, 108, 64);//点账号注册
                        mf.mydelay(2000, 4000);
                        td = 1;
                    }
                    DuoDianZhaoSe dz = new DuoDianZhaoSe(0x5ecdf3, "-2|12|0x434343,-26|23|0x959595,-26|36|0x959595,-26|45|0xa8a8a8,-26|61|0x1eb9ee,-26|74|0xeb9300", 90, 75, 15, 115, 110);
                    mf.myqudianqusezuobiaoByLei(this._jubing, dz, out tx, out ty);
                    if (tx != -1 && ty != -1)
                    {
                        WriteLog.WriteLogFile(this._mnqName,"进入到账号注册界面");
                    }
                    else
                    {
                        WriteLog.WriteLogFile(this._mnqName,"meiyou进入到账号注册界面" + this._jubing);
                        return zccg;
                    }
                    mf.mytap(this._jubing, 95, 45);
                    mf.mydelay(2000, 4000);
                    zhanghao.shuruchar(mf, this._dqinx, this._jubing, name);
                    mf.mytap(this._jubing, 91, 57);
                    mf.mydelay(2000, 4000);
                    zhanghao.shuruchar(mf, this._dqinx, this._jubing, pas);
                    mf.mydelay(2000, 4000);
                    if (mf.myGetColor(this._jubing, 136, 71, "1eb9ee"))
                    {
                        WriteLog.WriteLogFile(this._mnqName,"去掉绑定手机对号");
                        mf.mytap(this._jubing, 136, 71);
                        mf.mydelay(1000, 3000);
                    }
                    mf.mytap(this._jubing, 105, 98);
                    mf.mydelay(4000, 6000);
                    mf.myqudianqusezuobiaoByLei(this._jubing, dz, out tx, out ty);
                    if (tx != -1 && ty != -1)
                    {
                        WriteLog.WriteLogFile(this._mnqName,"上述操作完，还在账号注册界面");
                        continue;
                    }
                    while (true)
                    {
                        mf.myqudianqusezuobiaoByLei(this._jubing, dz2, out tx, out ty);
                        if (tx != -1 && ty != -1)
                        {
                            WriteLog.WriteLogFile(this._mnqName, "发现跳过实名");
                            mf.mytap(this._jubing, 80, 92);//点跳过实名
                        }
                        mf.myqudianqusezuobiao(this._jubing, 0xfffbef, "-2|-1|0xe7beba,-3|3|0xca7170,2|2|0xfdf1e7,4|0|0xca3836,-148|-2|0xcecfce,-166|-2|0xb42720", 90, 20, 0, 205, 20, out tx, out ty);
                        if (tx != -1 && ty != -1)
                        {
                            WriteLog.WriteLogFile(this._mnqName, "发现公告,关闭");
                            mf.mytap(this._jubing, tx, ty);
                        }
                        mf.myqudianqusezuobiao(this._jubing, 0xfeda2f, "-6|0|0xe8cc33,-9|0|0x3f2a01,-12|4|0xffd721,5|2|0x4a1800,11|3|0x743409,14|3|0xffd321", 90, 85, 90, 130, 110, out tx, out ty);
                        if (tx != -1 && ty != -1)
                        {
                            WriteLog.WriteLogFile(this._mnqName, "发现进入游戏");
                            mf.mytap(this._jubing, tx, ty);
                            mf.mydelay(4000, 8000);
                            mf.myqudianqusezuobiao(this._jubing, 0xfeda2f, "-6|0|0xe8cc33,-9|0|0x3f2a01,-12|4|0xffd721,5|2|0x4a1800,11|3|0x743409,14|3|0xffd321", 90, 85, 90, 130, 110, out tx, out ty);
                            if (tx == -1 && ty == -1)
                            {
                                zccg = true;
                                break;;
                            }
                        }
                        long js = MyFuncUtil.GetTimestamp();
                        if ((js - kstime) > fz * 60 * 1000)
                        {
                            WriteLog.WriteLogFile(this._mnqName, "没有能够发现进入游戏");
                            break;;
                        }
                    }
                }
                if (zccg == true) {
                    WriteLog.WriteLogFile(this._mnqName, "注册环节-登录或注册-成功完成" + " " + this._jubing);
                    break;;
                }
                long jstime = MyFuncUtil.GetTimestamp();
                if ((jstime - kstime) > fz * 60 * 1000)
                {
                    WriteLog.WriteLogFile(this._mnqName, "注册环节-登录或注册-没有成功完成" + " " + this._jubing);
                    break;;
                }
            }
            return zccg;
        }
        


        
        public int getMyDqindex()
        {
            return this._dqinx;
        }

        public xDm getMyDm()
        {
            return this.mf;
        }






        private bool panduankaping(int x,int y,int chushi=1) {
            bool rs = false;
            string yanse1 = null;
            long ks = -1;
            if (chushi == 1) {
                yanse1 = mf.myGetColorWuJbYanse(x, y);
                ks = MyFuncUtil.GetTimestamp();
            }
            string yanse2 = mf.myGetColorWuJbYanse(x, y);
            long js = MyFuncUtil.GetTimestamp();
            if ((js - ks) > 1000 * 60 * 5 && yanse2.Equals(yanse1)) {
                MyFuncUtil.mylogandxianshi("卡屏5分钟,取点x:"+x+",y:"+y);
                //截屏
                rs = true;
            }
            return rs;
        }


        private bool panduanzhandou(SanDian sd)
        {
            bool rs = false;
            long ks = -1;
            if (mf.mohuByLei(sd) == 1)
            {
                ks = MyFuncUtil.GetTimestamp();
            }
            long js = MyFuncUtil.GetTimestamp();
            if ((js - ks) > 1000 * 60 * 10)
            {
                MyFuncUtil.mylogandxianshi("10分钟未战斗");
                //截图
                rs = true; 
            }
            return rs;
        }

        public void zhuxian()
        {
            while (true) {
               /* foreach (FuHeSanDian f in YiQuan_SanDian.List_yqfhsandian)
                {
                    if (mf.mohuByLei(f.Sd)==1)
                    {
                        MyFuncUtil.mylogandxianshi(f.Name);
                        if (f.Zhidingx != -1 && f.Zhidingy != -1)
                        {
                            mf.mytap(this._jubing, f.Zhidingx, f.Zhidingy);
                            mf.mydelay(200, 1500);
                        }
                    }
                }*/
                panduankaping(457, 272);
            }

        }
    }
}
