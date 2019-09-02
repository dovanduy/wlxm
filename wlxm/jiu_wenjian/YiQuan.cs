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
    public class YiQuan
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
        private int tiaoguoyongX = 100;
        /// <summary>
        /// 跳过动画专用点击位置y
        /// </summary>
        private int tiaoguoyongY = 90;


        public YiQuan(xDm mydm, int dqinx, string dizhi)
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
                            break;
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
                                break;
                            }
                        }
                        long js = MyFuncUtil.GetTimestamp();
                        if ((js - kstime) > fz * 60 * 1000)
                        {
                            WriteLog.WriteLogFile(this._mnqName, "没有能够发现进入游戏");
                            break;
                        }
                    }
                }
                if (zccg == true) {
                    WriteLog.WriteLogFile(this._mnqName, "注册环节-登录或注册-成功完成" + " " + this._jubing);
                    break;
                }
                long jstime = MyFuncUtil.GetTimestamp();
                if ((jstime - kstime) > fz * 60 * 1000)
                {
                    WriteLog.WriteLogFile(this._mnqName, "注册环节-登录或注册-没有成功完成" + " " + this._jubing);
                    break;
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

        public void zhuxianqian()
        {
            for (int i = 1; i < 10; i++) {
                guanbi_all();
                mf.mydelay(1000, 2000);
            }
            int x = -1, y = -1;
            DuoDianZhaoSe dz = new DuoDianZhaoSe(0xbbae90, "2|0|0xd0c1a0,4|0|0xcbbd9c,4|2|0xc9ba9a,1|4|0xb0a484,0|7|0xe9d8c8,4|8|0xd9c8b9", 90, 0, 0, 20, 20);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1) {
                WriteLog.WriteLogFile(this._mnqName, "进来后发现人物头像,左上角");
                return;
            }
            WriteLog.WriteLogFile(this._mnqName, "新账号要完成引导过程");
            long ks = MyFuncUtil.GetTimestamp();
            long ks_xs = MyFuncUtil.GetTimestamp();
            int yx = 0, tmp = 0, xs = 0,touxiang=0;
            while (true)
            {
                zhandouqian(yx, out yx);
                tedingdian(yx, out yx);
                tedingdian_guangtou(yx, out yx);
                tiaoguo(yx, out yx);
                zhandouqian_xiamianrenwu();
                long js = MyFuncUtil.GetTimestamp();
                if ((js - ks) > 1000 * 10 && xs == 0)
                {
                    WriteLog.WriteLogFile(this._mnqName,"10s,当前yx:" + yx + ",当前tmp:" + tmp);
                    if (tmp != yx)
                    {
                        tmp = yx;
                        ks = MyFuncUtil.GetTimestamp();
                    }
                    xs = 1;
                }
                if ((js - ks_xs) > 1000 * 10)
                {
                    ks_xs = MyFuncUtil.GetTimestamp();
                    xs = 0;
                }
                if ((js - ks) > 1000 * 120)
                {
                    WriteLog.WriteLogFile(this._mnqName,"69s,当前yx:" + yx + ",当前tmp:" + tmp);
                    if (tmp == yx)
                    {
                        ks = MyFuncUtil.GetTimestamp();
                        WriteLog.WriteLogFile(this._mnqName,"119秒没有有效点");
                        break;
                    }

                }
                if ((js - ks) > 1000 * 60 * 45)
                {
                    WriteLog.WriteLogFile(this._mnqName,"45分钟退出");
                    break;
                }
                dz = new DuoDianZhaoSe(0xbbae90, "2|0|0xd0c1a0,4|0|0xcbbd9c,4|2|0xc9ba9a,1|4|0xb0a484,0|7|0xe9d8c8,4|8|0xd9c8b9", 90, 0, 0, 20, 20);
                mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                if (x != -1 && y != -1)
                {
                    touxiang ++;
                }
                if (touxiang > 200) {
                    WriteLog.WriteLogFile(this._mnqName,"200头像持续200下");
                    break;
                }
            }        
        }

        private void zhandouqian(int mx, out int my)
        {
            int x = -1, y = -1;
            int yxdj = mx;
            DuoDianZhaoSe dz = new DuoDianZhaoSe(0x78786d, "0|-4|0x54b17b,-3|-3|0x61bc86,7|-5|0xd8c793,7|4|0xc29504,23|1|0x772217,21|-5|0xdc443a", 90, 150, 105, 190, 121);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"进入战斗寻人场景");
                var ks = MyFuncUtil.GetTimestamp();
                //int fangxiang = 0;
                //var yizhi = 0;                
                //var temp = 0;
                while (true)
                {
                    tiaoguo(yxdj,out yxdj);
                    dz = new DuoDianZhaoSe(0xefb294, "0|-7|0xefb294,-6|-7|0xefb294,-7|1|0xefb294,-1|6|0xefb294,5|6|0xefb294,8|4|0xd6965b", 90, 0, 0, 215, 121);
                    mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        WriteLog.WriteLogFile(this._mnqName,"发现光头提示4-战斗前");
                        mf.mytap(this._jubing, 144, 33);
                        mf.mydelay(200, 800);
                        mf.mytap(this._jubing, 158, 111);
                        mf.mydelay(200, 800);
                        mf.mytap(this._jubing, 156, 77);
                        yxdj++;
                    }
                    dz = new DuoDianZhaoSe(0xf7cf4a, "7|0|0xffcf4a,7|-2|0xfbc845,-6|-2|0xf7cf4a,9|-3|0xf7ce48,9|-1|0xceac40,8|1|0xfec345", 90, 0, 25, 25, 45);
                    mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        WriteLog.WriteLogFile(this._mnqName,"出现主线任务提示,点提示");
                        mf.mytap(this._jubing, 16, 49);
                        mf.mydelay(100, 600);
                        yxdj++;
                    }
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
                        yxdj++;
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
                        yxdj++;
                    }
                    dz = new DuoDianZhaoSe(0xf32700, "0|-3|0xcc462f,-4|0|0xcc4934,2|4|0xd15534,5|1|0xda5a3d,-2|3|0xb71f02,-1|5|0xe4b4a6", 90, 0, 0, 215, 121);
                    mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        WriteLog.WriteLogFile(this._mnqName,"发现红色拳头");
                        mf.mytap(this._jubing, x, y + 25);
                        mf.mydelay(100, 600);
                        yxdj++;
                    }
                    dz = new DuoDianZhaoSe(0xe1c610, "0|-4|0x6659ac,-3|-2|0x6659ac,3|0|0x7b6c1e,1|2|0x7b6ac2,-1|2|0x6659ac,2|0|0x8371ca", 90, 0, 0, 215, 121);
                    mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        WriteLog.WriteLogFile(this._mnqName,"发现人物招募");
                        mf.mytap(this._jubing, x, y + 25);
                        mf.mydelay(100, 600);
                        yxdj++;
                        zhandouqian_renwuzhaomo();
                    }
                    dz = new DuoDianZhaoSe(0xce8816, "0|-4|0xfcc52f,-4|-6|0x847f90,-8|-2|0x7d7b8e,-9|1|0x7d7b88,9|-1|0x585a69,8|-4|0x7b7a87", 90, 185, 95, 215, 121);
                    mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        WriteLog.WriteLogFile(this._mnqName, "发现人物招募后的黄晕++");
                        mf.mytap(this._jubing, x, y + 25);
                        mf.mydelay(100, 600);
                        yxdj++;
                        zhandouqian_renwuzhaomo();
                    }
                    dz = new DuoDianZhaoSe(0xdb3422, "-5|0|0xdd341f,-8|0|0x952124,-3|-5|0xf94028,44|8|0xf1efe2,54|8|0xf1efe2,95|5|0xa42426", 90, 50, 10, 180, 40);
                    mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        WriteLog.WriteLogFile(this._mnqName,"领取宝箱");
                        mf.mytap(this._jubing, 108, 78);
                        mf.mydelay(100, 600);
                        yxdj++;
                    }
                    var js = MyFuncUtil.GetTimestamp();
                    /*
                    if ((js - ks) > 1000 * 20 && x == -1 && (fangxiang < 3) && (yizhi == 0))
                    {
                        WriteLog.WriteLogFile(this._mnqName,"移动找拳头-右方");
                        mf.mytap(this._jubing, 158, 75);
                        mf.mydelay(100, 600);
                        fangxiang++;
                        if (fangxiang == 2)
                        {
                            yizhi = 1;
                        }
                        ks = MyFuncUtil.GetTimestamp();
                    }
                    if ((js - ks) > 1000 * 20 && x == -1 && (fangxiang > 2 && (yizhi == 1)))
                    {
                        WriteLog.WriteLogFile(this._mnqName,"移动找拳头-左方");
                        mf.mytap(this._jubing, 46, 75);
                        mf.mydelay(100, 600);
                        fangxiang--;
                        if (fangxiang == 0)
                        {
                            yizhi = 2;
                        }
                        ks = MyFuncUtil.GetTimestamp();
                    }
                    if ((yizhi == 2) && (js - ks) > 1000 * 60 * 5)
                    {
                        WriteLog.WriteLogFile(this._mnqName,"5分钟拳头没找到");
                        break;
                    }
                    if ((js - ks) > 1000 * 30)
                    {
                        ks = MyFuncUtil.GetTimestamp();
                        temp = yxdj;
                        WriteLog.WriteLogFile(this._mnqName,"30s记录yxdj");
                    }
                    if ((js - ks) > 1000 * 60)
                    {
                        if (temp == yxdj)
                        {
                            ks = MyFuncUtil.GetTimestamp();
                            //mf.mytap(this._jubing, 200, 112);
                            WriteLog.WriteLogFile(this._mnqName,"30s,yxdj不动");
                            break;
                        }
                    }*/
                    if ((js - ks) > 1000 * 60 * 10)
                    {
                        WriteLog.WriteLogFile(this._mnqName,"循环超过10min");
                        my = yxdj;
                        break;
                    }
                    if ((js - ks) > 1000 * 10)
                    {
                        dz = new DuoDianZhaoSe(0xa7927f, "2|3|0xa59a9d,8|4|0xc99d0f,22|-1|0x621d0b,23|2|0x7a2318,29|4|0xb08321,19|5|0xb4b4b4", 90, 150, 105, 190, 121);
                        mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                        if (x == -1 && y == -1)
                        {
                            my = yxdj;
                            WriteLog.WriteLogFile(this._mnqName,"离开了战斗前场景");
                            break;
                        }
                    }
                }
            }
            my = yxdj;
        }
        private void zhandouqian_renwuzhaomo() {
            var mks = MyFuncUtil.GetTimestamp();
            int x = -1, y = -1;
            while (true)
            {
                DuoDianZhaoSe dz = new DuoDianZhaoSe(0xebb498, "0|-9|0xefb294,-8|-9|0xefb294,-8|1|0xefb294,-10|7|0xe23c1f,-1|13|0xb02a1b,6|8|0xbb3818", 90, 0, 40, 30, 70);
                mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                if (x != -1 && y != -1)
                {
                    WriteLog.WriteLogFile(this._mnqName,"发现光头,开始拖动");
                    mf.mydelay(100, 600);
                    mf.mydrag(this._jubing, 14, 108, 122, 85);
                    mf.mydelay(300, 800);
                }
                tiaoguo();
                mf.mytap(this._jubing, 199, 112);
                mf.mydelay(100, 600);
                mf.mytap(this._jubing, 10, 26);
                mf.mydelay(100, 600);
                mf.mytap(this._jubing, 179, 19);
                mf.mydelay(100, 600);
                mf.mytap(this._jubing, 206, 4);
                mf.mydelay(100, 600);
                dz = new DuoDianZhaoSe(0x78786d, "0|-4|0x54b17b,-3|-3|0x61bc86,7|-5|0xd8c793,7|4|0xc29504,23|1|0x772217,21|-5|0xdc443a", 90, 150, 105, 190, 121);
                mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                long mjs = MyFuncUtil.GetTimestamp();
                if ((mjs - mks) > 1000 * 60 && x != -1 && y != -1)
                {
                    WriteLog.WriteLogFile(this._mnqName,"到战斗寻人场景,tuichu招募循环");
                    mf.mydelay(100, 600);
                    break;
                }
                if ((mjs - mks) > 1000 * 60 * 5)
                {
                    WriteLog.WriteLogFile(this._mnqName,"人物招募循环5分钟,tuichu");
                    mf.mydelay(100, 600);
                    break;
                }
            }
        }
        private void zhandouqian_xiamianrenwu() {
            int x = -1, y = -1;
            mf.myqudianqusezuobiao(this._jubing, 0xd8c8ba, "0|-7|0x7c735d,9|-8|0x373429,6|-14|0x69624f,-3|-14|0xa89d7d,0|7|0x27728c,-4|8|0x2b7692", 90, 150, 80, 190, 121, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"发现其他人物提示2-杰诺斯");
                mf.mytap(this._jubing, 202, 111);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 143, 52);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 135, 37);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 155, 74);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 177, 52);
            }
            mf.myqudianqusezuobiao(this._jubing, 0xf7dbc4, "0|-4|0x4f6676,-6|-6|0x201a1a,-4|-20|0xf8f6f4,-3|8|0x21405c,3|13|0x0b1221,-5|8|0x1f2e38", 90, 150, 80, 190, 121, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"发现其他人物提示3-女人");
                mf.mytap(this._jubing, 167, 37);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 145, 54);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 135, 37);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 155, 74);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 177, 52);
            }
            mf.myqudianqusezuobiao(this._jubing, 0xeac7af, "0|-8|0x466d44,-4|-9|0x446b42,-6|-3|0x7c8485,-4|2|0xe7c4ad,2|3|0xe7c4ad,2|9|0x360a04", 90, 150, 80, 190, 121, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"发现其他人物提示4-怒吼骑士");
                mf.mytap(this._jubing, 167, 37);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 145, 54);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 135, 37);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 155, 74);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 177, 52);
            }
        }


        private void tedingdian_guangtou(int mx, out int my) {
            int x = -1, y = -1;
            mf.myqudianqusezuobiao(this._jubing, 0xe0a587, "0|-9|0xefb294,-7|-9|0xefb294,-7|1|0xeab494,0|9|0xadbcbb,-3|11|0xffc752,3|11|0xffc752,-9|4|0xbd3410,6|4|0xde3c23", 90, 0, 0, 215, 121, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, "发现光头提示1");
                mf.mytap(this._jubing, x, y);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 205, 110);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 178, 41);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 70, 53);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 124, 37);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 28, 6);
                mf.mydelay(200, 800);
                mx++;
            }
            mf.myqudianqusezuobiao(this._jubing, 0xedb293, "0|-8|0xefb294,-6|-3|0xefb599,-10|4|0xbe3311,8|4|0xc4410e,1|12|0xad2c10,0|4|0x743f33", 90, 0, 0, 215, 121, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, "发现光头提示2");
                mf.mytap(this._jubing, 67, 64);
                mx++;
            }
            DuoDianZhaoSe dz = new DuoDianZhaoSe(0xefb294, "0|7|0xbd8367,-3|5|0xeee7df,4|5|0xece6e0,4|9|0xefb294,0|11|0xecb394,-1|18|0xce5234", 90, 0, 0, 215, 121);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, "发现光头提示3");
                mf.mytap(this._jubing, 177, 114);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 107, 105);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 123, 113);
                mx++;
            }
            dz = new DuoDianZhaoSe(0xefb294, "0|-7|0xefb294,-6|-7|0xefb294,-7|1|0xefb294,-1|6|0xefb294,5|6|0xefb294,8|4|0xd6965b", 90, 0, 0, 215, 121);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, "发现光头提示4");
                mf.mytap(this._jubing, 144, 33);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 158, 111);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 156, 77);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 11, 60);
                mx++;
            }
            dz = new DuoDianZhaoSe(0xa9725d, "0|-7|0xefb294,-6|-8|0xefb294,-5|-3|0xece6de,-5|3|0xefb294,-11|3|0xe33f1f,7|3|0xe74127", 90, 0, 0, 215, 121);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, "发现光头提示5");
                mf.mytap(this._jubing, 144, 33);
                //mf.mydelay(200, 800);
                mx++;
            }
            dz = new DuoDianZhaoSe(0xefb294, "0|-9|0xefb294,-5|-9|0xefb294,-6|5|0xefb394,-11|6|0xe64124,-3|12|0xffc752,8|12|0xcb9419", 90, 0, 0, 215, 121);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, "发现光头提示6");
                mf.mytap(this._jubing, 181, 111);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 203, 113);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 100, 49);
                mx++;
            }
            dz = new DuoDianZhaoSe(0xdda888, "0|-6|0xefb294,-5|-6|0xefb494,-4|-9|0xefb294,-7|4|0xbc3515,-1|8|0xc5c1b4,8|8|0xbc330f", 90, 0, 0, 215, 121);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, "发现光头提示7");
                mf.mytap(this._jubing, x, y);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 110, 35);
                mx++;
            }
            dz = new DuoDianZhaoSe(0xefb294, "0|-7|0xefb294,-6|-8|0xefb294,-6|-1|0xefb294,4|4|0xefb294,0|5|0xefb694,0|13|0xf8cd5b,-6|12|0xffcb4a,-9|8|0xd4351c", 90, 0, 0, 215, 121);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, "发现光头提示8");
                mf.mytap(this._jubing, 144, 51);
                //mf.mydelay(200, 800);
                mx++;
            }
            dz = new DuoDianZhaoSe(0xebb293, "8|-5|0xefb294,1|-5|0xefb294,0|6|0xefb294,-4|7|0xbd3410,-4|12|0xa41204,3|15|0xe45f47", 90, 0, 0, 215, 121);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, "发现光头提示9");
                mf.mytap(this._jubing, 204, 4);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 13, 25);
                mx++;
            }
            dz = new DuoDianZhaoSe(0xefb294, "-4|-1|0xefe7e6,-4|-8|0xefb294,0|5|0xa77361,-3|5|0xefb294,-9|5|0xbd3410,-9|15|0x940800", 90, 0, 0, 215, 121);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, "主线任务出现光头1");
                mf.mytap(this._jubing, 21, 62);
                mx++;
            }
            dz = new DuoDianZhaoSe(0xefb294, "-4|0|0xefb294,-4|7|0xe2d5cc,-3|9|0x8e7468,-6|15|0xc13015,1|15|0xefb294,9|17|0xbd3410", 90, 0, 0, 215, 121);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, "主线任务出现光头2");
                mf.mytap(this._jubing, 115, 51);
                mx++;
            }
            dz = new DuoDianZhaoSe(0xcc9276, "0|-8|0xefb294,-7|-8|0xefb294,-7|7|0xb41f0c,-10|7|0xe53821,-2|10|0xffcc50,8|10|0xc13015", 90, 0, 0, 215, 121);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, "主线任务出现光头3");
                mf.mytap(this._jubing, 115, 51);
                mx++;
            }
            dz = new DuoDianZhaoSe(0x97a09f, "-7|0|0xffc84c,-9|-3|0xb21f0a,5|-1|0xf6c23f,10|-1|0x841100,7|-4|0xbd3410,3|-7|0xefb294,-3|-7|0xefb294,-2|-10|0xefb294", 90, 0, 0, 215, 121);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, "主线任务出现光头4");
                mf.mytap(this._jubing, 187, 21);
                mx++;
            }
            dz = new DuoDianZhaoSe(0xefb294, "0|-5|0xefb294,-5|-6|0xedb292,-7|0|0xbd3310,-6|7|0xbc8624,1|7|0xfbca53,11|7|0x70180a", 90, 0, 0, 215, 121);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, "主线任务出现光头5");
                mf.mytap(this._jubing, 129, 93);
                mx++;
            }
            dz = new DuoDianZhaoSe(0xefb294, "0|-5|0xefb294,-4|7|0xb16850,-9|7|0xd93b20,-1|11|0xf5c452,5|12|0xffca4d,9|12|0xc93219", 90, 0, 0, 215, 121);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, "主线任务出现光头6");
                mf.mytap(this._jubing, 97, 75);
                mf.mydelay(2000, 4000);
                mf.mytap(this._jubing, 207, 4);
                mf.mydelay(2000, 4000);
                mf.mytap(this._jubing, 207, 4);
                mx++;
            }
            my = mx;
        }

        private void tedingdian(int mx,out int my)
        {
            int x = -1, y = -1;
            
            mf.myqudianqusezuobiao(this._jubing, 0xe0c9b6, "1|-10|0xcfbb76,-13|-10|0xe0cab7,-19|-10|0xe0c8b6,1|9|0xd4bcaa,8|15|0xd9c2b0,-3|12|0x21211e", 90, 135, 85, 180, 120, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"发现其他人物提示-开头动画人物");
                mf.mytap(this._jubing, 204, 111);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 178, 41);
                mx++;
            }
            
            mf.myqudianqusezuobiao(this._jubing, 0xf1caae, "0|-10|0xedccb3,-4|-1|0xe2dcd9,5|-2|0xf2ebe8,4|6|0xeac4a7,-3|6|0xeac3a6,-3|14|0xe1b899", 90, 150, 85, 180, 121, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"发现光头-在最下面");
                mf.mytap(this._jubing, 146, 34);
                //mf.mydelay(200, 800);  
                mx++;  
            }
            mf.myqudianqusezuobiao(this._jubing, 0xfefaee, "0|-3|0xa02522,-3|-1|0xa42421,-82|58|0xd4f0fc,-67|57|0xbcee32,-43|57|0x39c6f6,-21|57|0xc97b0e,-31|52|0x639d3a,-16|52|0x639d39", 90, 90, 0, 200, 85, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"第一次领取");
                mf.mytap(this._jubing, 135, 97);
                //mf.mydelay(200, 800);
                mx++;
            }
            DuoDianZhaoSe dz = new DuoDianZhaoSe(0xa3917c, "0|-7|0xb6abaa,-5|-8|0x5e5e5d,130|-33|0xf0ece1,126|-33|0x9b221f,133|-32|0x9b221f,54|22|0x844ea3,44|22|0x844ea3,43|30|0xaa63c9", 90, 45, 10, 200, 90);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"第二次领取");
                mf.mytap(this._jubing, 137, 97);
                //mf.mydelay(200, 800);
                mx++;
            }
            mf.myqudianqusezuobiao(this._jubing, 0x4e558f, "0|-9|0x33395b,-42|-31|0xf6b918,-46|-25|0xedb645,55|-22|0xcec7bd,81|25|0xb4a28e,78|37|0xfefdfe", 90, 5, 10, 150, 100, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"跳跃到第二关");
                mf.mytap(this._jubing, 121, 66);
                //mf.mydelay(200, 800);
                mx++;  
            }
            
            /*dz = new DuoDianZhaoSe(0x9d6751, "0|-7|0xefb294,-6|-8|0xefb294,-6|-1|0xefb294,-9|3|0xbd3410,-1|10|0xab4927,7|5|0xc23414", 90, 0, 0, 215, 121);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"发现光头提示10");
                mf.mytap(this._jubing, 121, 40);
                mx++;
            }*/
            dz = new DuoDianZhaoSe(0xfefefe, "0|-8|0x404d5d,0|-30|0x2e5ba7,0|-41|0x2e7dc1,0|-52|0xd1a773,0|-60|0xd99c1b,1|-75|0x304151,1|-84|0x2f384d,8|-79|0x213042", 90, 180, 0, 200, 95);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"招募窗口");
                mf.mytap(this._jubing, 80, 104);
                mx++;  
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 189, 51);
            }
            dz = new DuoDianZhaoSe(0x796000, "8|0|0xf63c30,8|10|0x3d4858,3|25|0x4c5e64,4|42|0xa7afb4,-2|56|0x3a4d5b,0|66|0x3c4c5f", 90, 0, 0, 25, 80);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"招募窗口第二次");
                mf.mytap(this._jubing, 80, 104);
                mx++;  
                //mf.mydelay(200, 800);
            }
            dz = new DuoDianZhaoSe(0xf63c30, "0|3|0x952117,-7|3|0xca2b20,-8|9|0x2c3344,11|29|0x213852,18|29|0x637380,25|14|0x525a6f", 90, 0, 0, 50, 40);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"招募窗口第3次");
                mf.mytap(this._jubing, 106, 107);
                mx++;  
                //mf.mydelay(200, 800);
            }
            dz = new DuoDianZhaoSe(0xf0f4f0, "-11|0|0xe0e1e0,-20|0|0xc92926,51|24|0xad0000,41|24|0xfffbef,39|35|0xbdb2ad,25|37|0x7e7876", 90, 50, 25, 145, 80);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"出现设置昵称");
                mf.mytap(this._jubing, 106, 86);
                mx++;  
                //mf.mydelay(200, 800);
            }
            dz = new DuoDianZhaoSe(0x67cef4, "0|2|0x67809f,-9|2|0xdfe3e9,-17|2|0x46648a,-17|6|0x68d0f7,4|4|0x5eb8df,11|4|0x68d0f7", 90, 20, 15, 65, 35);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"出现进入关卡");
                mf.mytap(this._jubing, 135, 95);
                mx++;  
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 138, 21);
                mf.mydelay(3000, 5000);
                mf.mytap(this._jubing, 135, 95);
            }
            dz = new DuoDianZhaoSe(0x837b5f, "0|-5|0x554e40,7|-5|0xbbae90,7|9|0x8d8e87,0|9|0xc6c4c3,-4|4|0xb6bab6,-5|-3|0xecbf07", 90, 0, 90, 25, 120);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"杰诺斯升级");
                mf.mytap(this._jubing, 192, 25);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 125, 41);
                mf.mydelay(200, 800);
                mf.mytap(this._jubing, 151, 108);
                mx++;  
            }
            dz = new DuoDianZhaoSe(0xdb3422, "-5|0|0xdd341f,-8|0|0x952124,-3|-5|0xf94028,44|8|0xf1efe2,54|8|0xf1efe2,95|5|0xa42426", 90, 50, 10, 180, 40);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"战斗场景,领取宝箱");
                mf.mytap(this._jubing, 108, 78);
                //mf.mydelay(100, 600);
                mx++;  
            }
            dz = new DuoDianZhaoSe(0xf32700, "0|-3|0xcc462f,-4|0|0xcc4934,2|4|0xd15534,5|1|0xda5a3d,-2|3|0xb71f02,-1|5|0xe4b4a6", 90, 0, 0, 215, 121);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, "发现红色拳头");
                mf.mytap(this._jubing, x, y + 25);
                mf.mydelay(100, 600);
                mx++;
            }
            FuHeDuoDian f = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("改造人主线中的红色拳头");
            mf.myqudianqusezuobiaoByLeiWuJubing(f.Dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,f.Name);
                mf.mytap(this._jubing, x, y + 25);
                mf.mydelay(100, 600);
                mx++;
            }
            f = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("改造人主线中的红色拳头-女");
            mf.myqudianqusezuobiaoByLeiWuJubing(f.Dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, f.Name);
                mf.mytap(this._jubing, x, y + 25);
                mf.mydelay(100, 600);
                mx++;
            }
            /*dz = new DuoDianZhaoSe(0xdd3418, "0|3|0xac2429,-1|5|0xa42421,-5|3|0xc32f21,35|2|0xa7aaa7,40|2|0x6a6b6a,17|2|0xd9dad9", 90, 30, 10, 85, 25);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"上阵后关闭特定窗口");
                mf.mytap(this._jubing, 179, 20);
                mf.mydelay(3000, 6000);
                mf.mytap(this._jubing, 206, 4);//关闭窗口,右上角
                mx++;  
            }*/
            dz = new DuoDianZhaoSe(0xdd3421, "-6|0|0xd83121,-6|4|0x3d0e0b,-1|4|0xb33325,6|2|0xd7d8d7,7|-1|0xfbfbfb,91|1|0xde2c29", 90, 55, 25, 165, 45);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"领取宝箱后关闭特定窗口");
                mf.mytap(this._jubing, 133, 85);
                //mf.mydelay(3000, 6000);
                //mf.mytap(this._jubing, 206, 4);//关闭窗口,右上角
                mx++;  
            }
            dz = new DuoDianZhaoSe(0x6bd6fe, "10|0|0x6bd6fe,11|2|0x7c91ad,10|5|0x45759e,20|5|0x6bd6fe,24|3|0x4f8eb6,30|3|0x6bd6fe", 90, 20, 15, 65, 30);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"通关窗口领取奖励");
                mf.mytap(this._jubing, 134, 97);
                //mf.mydelay(3000, 6000);
                //mf.mytap(this._jubing, 206, 4);//关闭窗口,右上角
                mx++;
            }
            dz = new DuoDianZhaoSe(0xdc3619, "3|3|0x9f221f,10|3|0x9c1e1f,10|-1|0xf3f3f3,17|1|0xe2e6e2,29|1|0xd4d2d4,33|4|0x9d221f", 90, 15, 0, 65, 20);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"发现一拳通关");
                mf.mytap(this._jubing, 49, 81);
                //mf.mydelay(3000, 6000);
                //mf.mytap(this._jubing, 206, 4);//关闭窗口,右上角
                mx++;
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
            mf.myqudianqusezuobiao(this._jubing, 0x443f44, "0|10|0x413e41,-16|11|0x443f44,-16|20|0x423f42,0|21|0x413e41,14|21|0x423e42,65|49|0xe9d8c8", 90, 85, 50, 180, 121, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"战斗中全屏黑,一处闪");
                mf.mytap(this._jubing, 173, 112);
                //mf.mydelay(200, 800);
            }
            my = mx;
        }

        public void tiaoguo(int mx, out int my)
        {
            int x = -1;
            int y = -1;
            mf.myqudianqusezuobiao(this._jubing, 0xfffff7, "7|0|0xfffff7,9|6|0xfffbf7,16|2|0xfffff7,-2|4|0xfffff7,-12|2|0xfffdf7,-22|5|0xfffff7", 90, 80, 95, 150, 115, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"发现对话框");
                mf.mysuijitap(this._jubing, tiaoguoyongX, tiaoguoyongY);
                //mf.mydelay(200, 800);
                mx++;
            }

            mf.myqudianqusezuobiao(this._jubing, 0x908f8b, "1|1|0x9d9c99,4|1|0xc6c5c1,8|1|0xa9a8a4,12|0|0x979793,18|0|0xc5c4bf,20|-1|0x92918d,22|0|0xa8a7a4,26|1|0xc1c0bb", 90, 85, 105, 125, 121, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"点击任意关闭");
                mf.mysuijitap(this._jubing, tiaoguoyongX, tiaoguoyongY);
                //mf.mydelay(200, 800);
                mx++;
            }
            my = mx;
        }
        
        
        public void fuben()
        { 
        }
        public void jiangli()
        {
        }
        public void tiaoguo()
        {
        }
        public void richang()
        {
        }
        

        public void zhuxian()
        {
            WriteLog.WriteLogFile(this._mnqName, "进入到主线任务");
            WriteLog.WriteLogFile(this._mnqName,"进入到主线任务");
            zhuxianrenwu();
            lingqu();
            
        }
        private void zhuxianrenwu() {
            var kstime = MyFuncUtil.GetTimestamp();
            int t1 = 0, t2 = 0;
            int shibai = 0;
            while (true)
            {
                tiaoguo(t1, out t1);
                zuorenwutishi();
                tedingdian_guangtou(t1, out t1);
                tedingdian(t1, out t1);
                zhandouqian(t1, out t1);
                var jstime = MyFuncUtil.GetTimestamp();
                if ((jstime - kstime) > 60 * 1000) {
                    t2 = 0;
                    kstime = MyFuncUtil.GetTimestamp();
                }                
                if ((jstime - kstime) > 30 * 1000)
                {
                    zhaoxiangzi_renwu();
                    zhaoxiangzi_ditu();                    
                    guanbi_all();
                }
                if ((jstime - kstime) > 40 * 1000)
                {
                    int x1 = MyFuncUtil.suijishu(0, 100);
                    int y1 = MyFuncUtil.suijishu(0, 50);
                    int x2 = MyFuncUtil.suijishu(100, 200);
                    int y2 = MyFuncUtil.suijishu(51, 100);
                    int t = mf.IsDisplayDead(x1, y1, x2, y2, 12);
                    if (t == 1) {
                        WriteLog.WriteLogFile(this._mnqName, "卡屏");
                        foreach (ZuoBiao s in YiQuan_DuoDian.List_zuobiao) {
                            mf.mytap(this._jubing, s.X, s.Y);
                            mf.mydelay(100, 800);
                        }
                    }

                }
                if (t2 == 0)
                {
                    dianjizhuxianzhixian();//点击主线或支线
                    t2 = 1;
                }
                zhandouqian_xiamianrenwu();
                jinruzhandou(out shibai);
                if (shibai == 1) {
                    WriteLog.WriteLogFile(this._mnqName,"战斗失败,tuichu主线支线任务");
                    break;
                }
                if (zhuxianbreak()) {
                    WriteLog.WriteLogFile(this._mnqName, "体力不足,tuichu主线支线任务");
                    break;
                }
            }
        }
        private bool zhuxianbreak() {
            bool tmp=false;
            //int x = -1, y = -1;
            
            return tmp;
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

        private void zhaoxiangzi_ditu()
        {
            int x = -1, y = -1;
            DuoDianZhaoSe dz = new DuoDianZhaoSe(0xf93d29, "0|-3|0xf93d29,3|-4|0xf5bb00,4|-1|0xfffdff,11|0|0xdfe0df,14|2|0xe1e2e1,18|-1|0xd5d9d5", 90, 5, 0, 35, 10);
            mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,"进入世界地图-准备找箱子");
                dz = new DuoDianZhaoSe(0xfff924, "2|0|0xfff627,2|-2|0xfff50f,-2|-2|0xfce520,-2|0|0xffdf6f,3|2|0xffe220,0|2|0xffff5d,4|3|0xffe92c", 90, 0, 0, 215, 121);
                mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                if (x != -1 && y != -1)
                {
                    WriteLog.WriteLogFile(this._mnqName,"发现黄色箱子1");
                    mf.mytap(this._jubing, x, y);
                    mf.mydelay(4000, 8000);                    
                }
                dz = new DuoDianZhaoSe(0xdaa66a, "-2|0|0x916736,-2|1|0xbb7c46,-4|1|0xd98636,2|1|0x85411e,3|-1|0xa76a3e,3|2|0x74451f", 90, 0, 0, 215, 121);
                mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                if (x != -1 && y != -1)
                {
                    WriteLog.WriteLogFile(this._mnqName,"发现黄色箱子2");
                    mf.mytap(this._jubing, x, y);
                    mf.mydelay(4000, 8000);
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

        private void zhuxianLinShi()
        {
            //出现头像 需要拖拽到指定位置
            int x = -1;
            int y = -1;
            mf.myqudianqusezuobiao(this._jubing, 0xd9c0a4, "0|-8|0x825e4c,-5|-8|0x7d594b,-7|-2|0x704d4a,-9|9|0x3fcfe4,7|9|0x295468,7|-2|0x30211d,7|-15|0x9e4b37", 90, 5, 5, 40, 40, out x, out y);
            if (x != -1 && y != -1)
            {
                int x1 = -1;
                int y1 = -1;

                mf.myqudianqusezuobiao(this._jubing, 0xffa200, "0|2|0xffa200,0|5|0xf7dfce,-6|3|0x7a7d7a,-6|-3|0x966712,0|-5|0xbcb6b8,-7|-3|0xf39b00", 90, 160, 90, 200, 121, out x1, out y1);
                if (x1 != -1 && y1 != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mydrag(this._jubing, x1, y1, 98, 72);
                    mf.delay(2000);
                    mf.myMove(this._jubing, 98, 70);
                    mf.delay(2000);
                    mf.mydrag(this._jubing, 98,72, 140, 72);
                    mf.delay(2000);
                    WriteLog.WriteLogFile(this._mnqName, "出现讲解头像同时需要拖拽到指定位置-第一次" + x1 + " " + y1);
                    mf.mydelay(200, 500);
                }

                mf.myqudianqusezuobiao(this._jubing, 0x696a73, "-1|-5|0xffa200,2|-3|0xffb83e,4|-1|0xaeb8bd,-31|-37|0x890405,-31|-32|0x8e0506,-24|-32|0x920405", 90,  60, 30, 105, 80, out x1, out y1);
                if (x1 != -1 && y1 != -1)
                {
                    mf.mydelay(100, 300);
                    mf.myMove(this._jubing, 98, 70);
                    mf.delay(2000);
                    mf.mydrag(this._jubing, 98, 72, 140, 72);
                    mf.delay(2000);
                    WriteLog.WriteLogFile(this._mnqName, "出现讲解头像同时需要拖拽到指定位置-第一次（二次拖）" + x1 + " " + y1);
                    mf.mydelay(200, 500);
                }

                mf.myqudianqusezuobiao(this._jubing, 0xffa200, "0|-4|0xcab5b2,-4|-4|0xde922b,-4|0|0x370617,-2|5|0x24221f,5|5|0x272624,4|3|0x6e4455", 90, 190, 90, 211, 121, out x1, out y1);
                if (x1 != -1 && y1 != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mydrag(this._jubing, x1, y1, 115, 55);
                    mf.delay(2000);
                    mf.myMove(this._jubing,115,56);
                    mf.delay(2000);
                    mf.mydrag(this._jubing, 115, 56, 145, 56);
                    mf.delay(2000);
                    WriteLog.WriteLogFile(this._mnqName, "出现讲解头像同时需要拖拽到指定位置-第二次");
                    mf.mydelay(200, 500);
                }
                mf.myqudianqusezuobiao(this._jubing,0xffa200, "-3|6|0x8c596b,5|6|0x825867,2|-8|0x8e707f,-3|-8|0x917c8d,-35|-9|0xf43a3f,-39|-6|0xeb363b", 90, 70, 35, 125, 65, out x1, out y1);
                if (x1 != -1 && y1 != -1)
                {
                    mf.mydelay(100, 300);                   
                    mf.myMove(this._jubing, 115, 56);
                    mf.delay(2000);
                    mf.mydrag(this._jubing, 115, 56, 145, 56);
                    mf.delay(2000);
                    WriteLog.WriteLogFile(this._mnqName, "出现讲解头像同时需要拖拽到指定位置（二次拖）-第二次");
                    mf.mydelay(200, 500);
                }
            }
        }

        private bool zhuxian_break()
        {
            int x = -1;
            int y = -1;
            mf.myqudianqusezuobiao(this._jubing, 0x8c8e8c, "-2|1|0x343841,-4|2|0x8c8e8c,-4|5|0x383c46,0|3|0x383d47,-5|6|0x373b44,185|1|0xffffff,189|1|0xffffff,170|-2|0xfcfcfc", 90, 5, 0, 210, 20, out x, out y);
            if (x != -1 && y != -1)
            {
                mf.mydelay(100, 300);
                mf.mytap(this._jubing, x, y);
                //WriteLog.WriteLogFile(this._mnqName, "进入到战斗场面，选放弃战斗");
                //mf.mydelay(200, 500);
                mf.mydelay(2000, 3000);
                mf.mytap(this._jubing, 716, 428);//选择放弃行动 
                mf.mydelay(2000, 3000);
                mf.myqudianqusezuobiao(this._jubing, 0x8c3a3a, "-8|0|0x852f32,-8|5|0x7c1d1d,6|4|0x750f11,-7|-1|0xe0cccc,3|1|0xc89fa1,6|1|0xaf7375", 90, 145, 85, 175, 110, out x, out y);
                if (x != -1 && y != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this._jubing, x, y);
                    WriteLog.WriteLogFile(this._mnqName, "选放弃战斗");
                    mf.mydelay(2000, 5000);
                    mf.mysuijitap(this._jubing, tiaoguoyongX, tiaoguoyongY);//任务失败,点击画面已继续
                    mf.mydelay(1000, 3000);
                    mf.mysuijitap(this._jubing, 162, 96);//任务失败,点击画面已继续
                    mf.mydelay(1000, 3000);
                    mf.mysuijitap(this._jubing, 200, 100);//任务失败,点击画面已继续
                    mf.mydelay(1000, 3000);                
                }
                int kstime = mf.GetTime(); 
                //mf.mytap(this._jubing, 8, 6);//回到主界面
                //mf.mydelay(1000, 3000);
                while (true) {
                    guanbi_all();
                    mf.mysuijitap(this._jubing, 200, 100);//任务失败,点击画面已继续
                    if (panduanjiemian("主界面")){
                        WriteLog.WriteLogFile(this._mnqName, "主线任务退出");
                        break;
                    }
                    int jstime = mf.GetTime();
                    if ((jstime - kstime) > 60000 * 5) {
                        WriteLog.WriteLogFile(this._mnqName, "放弃战斗后,回到主界面失败");
                        break;
                    }
                }
                
                return true;
            }
            return false;
        }
        
        
        public void ceshi()
        {
            WriteLog.WriteLogFile(this._mnqName, "进入测试" + _dqinx + " " + mf.Ver());
            int x = -1, y = -1;
            while (true)
            {
                DuoDianZhaoSe dz = new DuoDianZhaoSe(0xf32700, "0|-3|0xcc462f,-4|0|0xcc4934,2|4|0xd15534,5|1|0xda5a3d,-2|3|0xb71f02,-1|5|0xe4b4a6", 90, 0, 0, 215, 121);
                mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                if (x != -1 && y != -1)
                {
                    WriteLog.WriteLogFile(this._mnqName, "发现红色拳头");
                    //mf.mytap(this._jubing, x, y + 25);
                    mf.mydelay(100, 600);
                    break;

                }
                FuHeDuoDian f = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("改造人主线中的红色拳头");
                mf.myqudianqusezuobiaoByLeiWuJubing(f.Dz, out x, out y);
                if (x != -1 && y != -1)
                {
                    WriteLog.WriteLogFile(this._mnqName,f.Name);
                    //mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                }
            }
            mf.myUnBindWindow();
        }
        public void lingqu()
        {
            lingqu_youjian();
        }
        private void lingqu_youjian()
        {
            int x1 = -1;
            int y1 = -1;
            if (panduanjiemian("主界面"))
            {
                WriteLog.WriteLogFile(this._mnqName,"准备进入主界面!");
            }
            if (!panduanjiemian("主界面"))
            {
                WriteLog.WriteLogFile(this._mnqName,"进入主界面失败,领取不继续!");
                return;
            }
            if (panduanjiemian("主界面"))
            {
                mf.mydelay(100, 300);
                int zx = -1, zy = -1;
                int x = -1, y = -1;
                mf.myFindColor(this._jubing,0,30,55,65,"afe680",out zx,out zy);
                if (zx != -1 && zy != -1)
                {
                    WriteLog.WriteLogFile(this._mnqName,"主界面进入,点击日常完成的领取");
                    mf.mytap(this._jubing, 12, 65);
                    mf.mydelay(1000, 2000);
                    if (panduanjiemian("任务界面")) {
                        for(int i=0;i<4;i++){
                            FuHeDuoDian fh = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("任务界面可领取");
                            mf.myqudianqusezuobiaoByLeiWuJubing(fh.Dz, out x, out y);
                            if (x != -1 && y != -1)
                            {
                                WriteLog.WriteLogFile(this._mnqName,fh.Name);
                                mf.mytap(this._jubing, x, y);
                                mf.mydelay(2000, 4000);
                            }
                        }
                    }
                    mf.mytap(this._jubing, 207, 4);
                }
            }

            if (panduanjiemian("主界面"))
            {
                mf.mydelay(100, 300);
                mf.mytap(this._jubing, 22, 99);
                WriteLog.WriteLogFile(this._mnqName, "主界面进入,点击邮件区");
                mf.mydelay(3200, 5500);
                mf.myqudianqusezuobiao(this._jubing, 0xffe451, "0|-5|0xe3cb50,-6|-2|0xffdb21,-3|-1|0xe4c74f,3|-1|0x967319,4|1|0x7b3a07,5|2|0xffdb21", 90, 180, 95, 210, 121, out x1, out y1);
                if (x1 != -1 && y1 != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this._jubing, x1, y1);
                    WriteLog.WriteLogFile(this._mnqName, "开具领取邮件-领取所有邮件");
                    mf.mydelay(3200, 4500);
                    mf.mysuijitap(this._jubing, tiaoguoyongX, tiaoguoyongY);
                    mf.mydelay(3200, 4500);
                    mf.mytap(this._jubing, 207, 4);
                }
            }
            if (panduanjiemian("主界面"))
            {
                mf.mydelay(100, 300);
                mf.mytap(this._jubing, 191, 18);
                WriteLog.WriteLogFile(this._mnqName, "主界面进入,点击签到福利");
                mf.mydelay(3200, 5500);
                mf.myqudianqusezuobiao(this._jubing, 0x6a4c14, "-5|0|0xaf8d2b,-5|1|0xffde4c,-1|2|0xdec535,2|2|0x6c2710,8|2|0xffdb21,8|0|0xffdb21", 90, 180, 95, 210, 110, out x1, out y1);
                if (x1 != -1 && y1 != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this._jubing, x1, y1);
                    WriteLog.WriteLogFile(this._mnqName, "签到福利");
                    mf.mydelay(3200, 4500);
                    mf.mytap(this._jubing, 207, 4);
                }
            }
            if (panduanjiemian("主界面"))
            {
                mf.mydelay(100, 300);
                if(mf.myGetColor(this._jubing,146,17,"e7c011")){
                    mf.mytap(this._jubing, 146,17);
                }else{
                    mf.mytap(this._jubing, 130, 18);
                }
                WriteLog.WriteLogFile(this._mnqName, "主界面进入,点击忍者特训");
                mf.mydelay(3200, 5500);
                mf.myqudianqusezuobiao(this._jubing, 0xffe34a, "-8|0|0xfedf5a,-16|0|0xd3b147,-17|-7|0xffe363,-21|-2|0xc64121,-21|5|0xb27030,-15|6|0x984a2a", 90, 50, 0, 90, 25, out x1, out y1);
                if (x1 != -1 && y1 != -1)
                {
                    DuoDianZhaoSe dz1 = new DuoDianZhaoSe(0x6a4c14, "0|-2|0xa48d2a,-5|-2|0xffdb21,-3|1|0xfdd340,3|1|0xdaad2d,5|2|0xd2a82d,2|2|0x8f5516,6|-2|0xb69e38,4|0|0xeac446", 90, 0, 0, 215, 121);
                    DuoDianZhaoSe dz2 = new DuoDianZhaoSe(0x9d9c99, "7|0|0xa9a8a4,13|0|0xa6a5a1,13|-2|0xc5c4bf,20|-2|0xc6c5c0,20|0|0xacaba8,25|-1|0xc6c5c0", 90, 90, 100, 130, 121);
                    DuoDianZhaoSe[] dzz = new DuoDianZhaoSe[] { dz1, dz2 };
                    mf.myqudianqusezuobiaoXunHuanDianJi(this._jubing, dzz, 30);
                    mf.mydelay(100, 300);
                    WriteLog.WriteLogFile(this._mnqName, "领取特训碎片");
                    mf.mydelay(3200, 4500);
                    mf.mytap(this._jubing, 199, 16);
                }
            }
            if (panduanjiemian("主界面"))
            {
                mf.mydelay(100, 300);
                mf.mytap(this._jubing, 145, 18);
                WriteLog.WriteLogFile(this._mnqName, "主界面进入,点击登录奖励");
                mf.mydelay(3200, 5500);
                DuoDianZhaoSe dz1 = new DuoDianZhaoSe(0xeed445, "-3|0|0xe7cc5f,-4|-1|0x271507,-6|-1|0xffd721,-6|1|0xffd721,-3|2|0xe8bd3a,2|2|0x691f07,2|0|0x210800,4|-1|0x090100", 90, 0, 0, 215, 121);
                DuoDianZhaoSe dz2 = new DuoDianZhaoSe(0x9d9c99, "7|0|0xa9a8a4,13|0|0xa6a5a1,13|-2|0xc5c4bf,20|-2|0xc6c5c0,20|0|0xacaba8,25|-1|0xc6c5c0", 90, 90, 100, 130, 121);
                DuoDianZhaoSe[] dzz = new DuoDianZhaoSe[] { dz1, dz2 };
                mf.myqudianqusezuobiaoXunHuanDianJi(this._jubing, dzz, 30);
                mf.mydelay(100, 300);
                WriteLog.WriteLogFile(this._mnqName, "领取特训碎片");
                mf.mydelay(3200, 4500);
                mf.mytap(this._jubing, 196, 22);
            }
            /*if (panduanjiemian("主界面"))
            {
                mf.mydelay(100, 300);
                mf.mytap(this._jubing, 145, 18);
                WriteLog.WriteLogFile(this._mnqName, "主界面进入,点击超市");
                mf.mydelay(3200, 5500);
                DuoDianZhaoSe dz1 = new DuoDianZhaoSe(0xeed445, "-3|0|0xe7cc5f,-4|-1|0x271507,-6|-1|0xffd721,-6|1|0xffd721,-3|2|0xe8bd3a,2|2|0x691f07,2|0|0x210800,4|-1|0x090100", 90, 0, 0, 215, 121);
                DuoDianZhaoSe dz2 = new DuoDianZhaoSe(0x9d9c99, "7|0|0xa9a8a4,13|0|0xa6a5a1,13|-2|0xc5c4bf,20|-2|0xc6c5c0,20|0|0xacaba8,25|-1|0xc6c5c0", 90, 90, 100, 130, 121);
                DuoDianZhaoSe[] dzz = new DuoDianZhaoSe[] { dz1, dz2 };
                mf.myqudianqusezuobiaoXunHuanDianJi(this._jubing, dzz, 30);
                mf.mydelay(100, 300);
                WriteLog.WriteLogFile(this._mnqName, "超市招募券");
                mf.mydelay(3200, 4500);
                mf.mytap(this._jubing, 196, 22);
            }*/
        }
        public void qianghua()
        {
            int x = -1;
            int y = -1;
            if (panduanjiemian("主界面"))
            {
                WriteLog.WriteLogFile(this._mnqName,"准备进入主界面!");
            }
            if (!panduanjiemian("主界面"))
            {
                WriteLog.WriteLogFile(this._mnqName,"进入主界面失败,强化不继续!");
                return;
            }
            if (panduanjiemian("主界面"))
            {
                FuHeDuoDian fh = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("zjmtx");
                mf.myqudianqusezuobiaoByLeiWuJubing(fh.Dz, out x, out y);
                if (x != -1 && y != -1)
                {
                    WriteLog.WriteLogFile(this._mnqName,"找到主界面头像");
                    x = fh.Zhidingx;
                    y = fh.Zhidingy;
                    mf.mytap(this._jubing, x, y);
                    mf.mydelay(2000,4000);
                }
            }
            if (panduanjiemian("角色界面")) {
                //先搞一键上阵
                WriteLog.WriteLogFile(this._mnqName,"搞一键上阵");
                mf.mytap(this._jubing, 190, 86);
                mf.mydelay(2000,4000);
                mf.mytap(this._jubing, 194, 86);
                mf.mydelay(2000, 4000);
                mf.mytap(this._jubing, 206, 3);
                mf.mydelay(2000, 4000);
            }
            if (panduanjiemian("角色界面"))
            {
                WriteLog.WriteLogFile(this._mnqName,"升级前两个角色");
                //角色1 坐标11 108 角色2 31 109
                long ks = MyFuncUtil.GetTimestamp();
                int jl_juese = 0;
                if (jl_juese == 0)
                {
                    mf.mytap(this._jubing, 11, 108);
                    mf.mydelay(1000, 2000);
                    mf.mytap(this._jubing, 190, 26);
                    mf.mydelay(1000, 2000);
                    for (int ii = 0; ii < 2; ii++)
                    {
                        juese_jingyan();
                    }
                    jl_juese = 1;
                }
                if (jl_juese == 1)
                {
                    mf.mytap(this._jubing, 31, 108);
                    mf.mydelay(1000, 2000);
                    //mf.mytap(this._jubing, 190, 26);
                    //mf.mydelay(1000, 2000);
                    for (int ii = 0; ii < 2; ii++)
                    {
                        juese_jingyan();
                    }
                    jl_juese = 0;
                }
                mf.mytap(this._jubing, 206, 3);
                mf.mydelay(2000, 4000);
                mf.mytap(this._jubing, 206, 3);
                mf.mydelay(2000, 4000);
            }
            
        }

        private void juese_jingyan() {
            //喝经验饮料最便宜的
            int x = -1, y= -1;
            int sjy = -1, sjx = -1;
            for (int i = 0; i < 10; i++)
            {
                mf.mytap(this._jubing, 124, 42);
                mf.mydelay(1000, 2000);
                FuHeDuoDian fh = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("角色升级_经验到瓶颈");
                mf.myqudianqusezuobiaoByLeiWuJubing(fh.Dz, out x, out y);
                if (x != -1 && y != -1)
                {
                    WriteLog.WriteLogFile(this._mnqName,fh.Name);
                    sjx = fh.Zhidingx;
                    sjy = fh.Zhidingy;
                    break;
                }
                fh = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("角色升级获取徽章的关闭");
                mf.myqudianqusezuobiaoByLeiWuJubing(fh.Dz, out x, out y);
                if (x != -1 && y != -1)
                {
                    WriteLog.WriteLogFile(this._mnqName,fh.Name);
                    mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                    mf.mydelay(1000, 2000);
                    break;
                }
            }
            //喝经验饮料次便宜的
            for (int i = 0; i < 10; i++)
            {
                mf.mytap(this._jubing, 151, 42);
                mf.mydelay(1000, 2000);
                FuHeDuoDian fh = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("角色升级_经验到瓶颈");
                mf.myqudianqusezuobiaoByLeiWuJubing(fh.Dz, out x, out y);
                if (x != -1 && y != -1)
                {
                    WriteLog.WriteLogFile(this._mnqName,fh.Name);
                    sjx = fh.Zhidingx;
                    sjy = fh.Zhidingy;
                    break;
                }
                fh = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("角色升级获取徽章的关闭");
                mf.myqudianqusezuobiaoByLeiWuJubing(fh.Dz, out x, out y);
                if (x != -1 && y != -1)
                {
                    WriteLog.WriteLogFile(this._mnqName,fh.Name);
                    mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                    mf.mydelay(1000, 2000);
                    break;
                }
            }
            //喝经验饮料次次便宜的
            for (int i = 0; i < 10; i++)
            {
                mf.mytap(this._jubing, 176, 42);
                mf.mydelay(1000, 2000);
                FuHeDuoDian fh = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("角色升级_经验到瓶颈");
                mf.myqudianqusezuobiaoByLeiWuJubing(fh.Dz, out x, out y);
                if (x != -1 && y != -1)
                {
                    WriteLog.WriteLogFile(this._mnqName,fh.Name);
                    sjx = fh.Zhidingx;
                    sjy = fh.Zhidingy;
                    break;
                }
                fh = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("角色升级获取徽章的关闭");
                mf.myqudianqusezuobiaoByLeiWuJubing(fh.Dz, out x, out y);
                if (x != -1 && y != -1)
                {
                    WriteLog.WriteLogFile(this._mnqName,fh.Name);
                    mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
                    mf.mydelay(1000, 2000);
                    break;
                }
            }
            FuHeDuoDian fh1 = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("角色升级获取徽章的关闭");
            mf.myqudianqusezuobiaoByLeiWuJubing(fh1.Dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,fh1.Name);
                mf.mytap(this._jubing, fh1.Zhidingx, fh1.Zhidingy);
                mf.mydelay(1000, 2000);
            }
            fh1 = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("角色升级_经验到瓶颈");
            mf.myqudianqusezuobiaoByLeiWuJubing(fh1.Dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,fh1.Name);
                mf.mytap(this._jubing, fh1.Zhidingx, fh1.Zhidingy);
                mf.mydelay(1000, 2000);
            }            
            fh1 = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("任一点关闭角色升级后");
            mf.myqudianqusezuobiaoByLeiWuJubing(fh1.Dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,fh1.Name);
                mf.mytap(this._jubing, fh1.Zhidingx, fh1.Zhidingy);
                mf.mydelay(1000, 2000);
            }
        }
        public void shouci_xunfang() {
            if (panduanjiemian("主界面"))
            {
                mf.mydelay(100, 300);
                mf.mytap(this._jubing, 200, 88);
                WriteLog.WriteLogFile(this._mnqName, "主界面进入寻访区");
                mf.mydelay(3200, 6500);
                mf.mytap(this._jubing, 207, 66);
                //mf.mydelay(1200,3500);
                //mf.mytap(this._jubing, 207, 66);
                WriteLog.WriteLogFile(this._mnqName, "寻访区进入600区");
                mf.mydelay(1200, 3500);
                bool tmp = false;
                long ks = MyFuncUtil.GetTimestamp();
                while (true)
                {
                    tmp = xunfang();
                    if (tmp)
                    {
                        break;
                    }
                    long js = MyFuncUtil.GetTimestamp();
                    if ((js - ks) > 1000 * 60 * 10) {
                        WriteLog.WriteLogFile(this._mnqName,"寻访退出失败");
                        mf.mydelay(1000, 2000);
                        break;
                    }
                }
            }
            

        }
        private bool xunfang() {
            //遇到skip则skip
            bool tmp = false;
            int x1 = -1;
            int y1 = -1;
            mf.myqudianqusezuobiao(this._jubing, 0x7e807f, "0|-2|0xececec,-3|0|0xadacad,4|0|0x2b2b2d,2|1|0xe3e3e3,-1|2|0x252728", 90,  195, 0, 214, 15, out x1, out y1);
            if (x1 != -1 && y1 != -1) {
                //mf.mydelay(100, 300);
                mf.mytap(this._jubing,x1, y1);
                //WriteLog.WriteLogFile(this._mnqName, "寻访后出现skip");                
                int kstime = mf.GetTime();
                int x21 = -1;
                int y21 = -1;
                while (true)
                {
                    mf.mysuijitap(this._jubing, tiaoguoyongX, tiaoguoyongY);//任务失败,点击画面已继续
                    mf.myqudianqusezuobiao(this._jubing, 0xe3e3e3, "0|-4|0xe5e5e5,-10|-4|0xcbcbcb,-10|-1|0x4f4f4f,2|1|0xe6e2e6,12|1|0xd8d8d8,13|-1|0xdcdcdc", 90, 135, 95, 175, 120, out x21, out y21);
                    if (x21 != -1 && y21 != -1)
                    {
                        break;
                    }
                    int jstime = mf.GetTime();
                    if ((jstime - kstime) > 20000 )
                    {
                        //WriteLog.WriteLogFile(this._mnqName, "放弃战斗后,回到主界面失败");
                        break;
                    }
                }
            }
            int x2 = -1;
            int y2 = -1;
            mf.myqudianqusezuobiao(this._jubing, 0xe3e3e3, "0|-4|0xe5e5e5,-10|-4|0xcbcbcb,-10|-1|0x4f4f4f,2|1|0xe6e2e6,12|1|0xd8d8d8,13|-1|0xdcdcdc", 90, 135, 95, 175, 120, out x2, out y2);
            if (x2 != -1 && y2 != -1)
            {
                //mf.mydelay(100, 300);
                mf.mytap(this._jubing,x2, y2);
                //WriteLog.WriteLogFile(this._mnqName, "花费600寻访一次");
                //mf.mydelay(200, 500);
            }
            int x3 = -1;
            int y3 = -1;
            mf.myqudianqusezuobiao(this._jubing, 0xa56c6e, "0|-4|0x781115,-10|-4|0x842a29,-11|-1|0x7b1c1b,0|1|0xefe3e3,8|1|0xdfc9c9,10|1|0x740e11", 90, 140, 75, 175, 95, out x3, out y3);
            if (x3 != -1 && y3 != -1)
            {
                //mf.mydelay(100, 300);
                mf.mytap(this._jubing,x3, y3);
                //WriteLog.WriteLogFile(this._mnqName, "花费600寻访一次，是否确认，是");
                //mf.mydelay(200, 500);
            }
            mf.myqudianqusezuobiao(this._jubing, 0xaeafad, "-5|0|0xffffff,7|1|0xf0f0f0,9|1|0xbabbba,110|1|0xb17f7f,112|0|0x7a1a1a,122|0|0xcba5a5", 90, 35, 75, 175, 90, out x3, out y3);
            if (x3 != -1 && y3 != -1)
            {
                mf.mydelay(100, 300);
                mf.mytap(this._jubing,x3, y3);
                //WriteLog.WriteLogFile(this._mnqName, "出现花费能源石界面,点取消,停止寻访");
                mf.mydelay(1000, 3000);
                mf.mytap(this._jubing, x3, y3);
                mf.mydelay(1000, 3000);
                guanbi_all();//过5秒 返回上一界面
                mf.mydelay(1000, 3000);
                tmp = true;
            }
            
            int x11 = -1;
            int y11 = -1;
            if (x1 == -1 && y1 == -1 && x2 == -1 && y2 == -1 && x3 == -1 && y3 == -1) {
                mf.myqudianqusezuobiao(this._jubing, 0x000000, "13|1|0x000000,45|3|0x000000,69|3|0x000000,99|1|0x000000,117|1|0x000000", 90, 20, 110, 160, 120, out x11, out y11);
                if (x11 != -1 && y11 != -11)
                {
                    //mf.mydelay(1000, 3000);
                    mf.mysuijitap(this._jubing, tiaoguoyongX, tiaoguoyongY);//过5秒 点击空白处跳过动画
                    //mf.mydelay(2000, 4000);
                }
            }
            return tmp;
        }

        public int ganyuan_jietu()
        {
            var res = -1;
            if (panduanjiemian("主界面"))
            {
                mf.mydelay(100, 300);
                mf.mytap(this._jubing, 168, 57);
                WriteLog.WriteLogFile(this._mnqName, "主界面进入干员区-准备截图");
                mf.mydelay(4200, 7500);
                mf.mytap(this._jubing, 7, 6);
                mf.mydelay(4200, 7500);
                mf.mytap(this._jubing, 168, 57);
                mf.mydelay(4200, 7500);
                int x = -1;
                int y = -1;
                mf.myqudianqusezuobiao(this._jubing, 0x1d4d62, "2|0|0x0c84ba,-2|0|0x1075a2,13|0|0x6d6e6d,18|0|0x757675,27|0|0x747574,42|0|0x6a6a6a", 90, 125, 0, 185, 15, out x, out y);
                if (x != -1 && y != -1)
                {
                    WriteLog.WriteLogFile(this._mnqName, "进入干员区成功");
                    mf.mydelay(220, 450);
                    res = 1;
                }
            }
            return res;
            
        }


        

        public Boolean panduanjiemian(string jiemian) {
            Boolean tmp = false;
            int x = -1;
            int y = -1;
            var kstime = MyFuncUtil.GetTimestamp();
            if ("主界面".Equals(jiemian)) {
                while (true)
                {
                    DuoDianZhaoSe dz = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("zjm").Dz;
                    mf.myqudianqusezuobiaoByLeiWuJubing(dz, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        tmp = true;
                        break;
                    }                    
                    var jstime = MyFuncUtil.GetTimestamp(); 
                    if (x == -1 && y == -1 && (jstime - kstime) > 24000) {
                        break;
                    }
                    guanbi_all();
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
            int x = -1;
            int y = -1;
            mf.myqudianqusezuobiao(this._jubing, 0xffc71d, "0|-1|0xffd23e,-3|-1|0xffbd13,-5|-1|0xffbd13,-2|1|0xefbe28,3|0|0xffc71d,5|1|0xe1b533", 90, 195, 0, 215, 10, out x, out y);
            if (x != -1 && y != -1)
            {
                //mf.mydelay(100, 300);
                mf.mytap(this._jubing, x, y);
                //WriteLog.WriteLogFile(this._mnqName, "领取任务奖励-只取的右上角的X号");
                //mf.mydelay(200, 500);
            }
            mf.myqudianqusezuobiao(this._jubing, 0xfef9ee, "0|-2|0xa42523,-4|-2|0xa42421,-3|1|0xa9322e,-1|2|0xa42421,2|2|0xfefae6,2|0|0xa42421", 90, 180, 5, 200, 25, out x, out y);
            if (x != -1 && y != -1)
            {
                //mf.mydelay(100, 300);
                mf.mytap(this._jubing, x, y);
                //WriteLog.WriteLogFile(this._mnqName, "领取任务奖励-只取的右上角的X号");
                //mf.mydelay(200, 500);
            }
            mf.myqudianqusezuobiao(this._jubing,0xfffbef, "0|-3|0xda3738,2|-3|0xdc4041,3|0|0xa52421,3|3|0xa52421,0|3|0xad2421,-2|1|0xa52421", 90, 190, 5, 210, 25, out x, out y);
            if (x != -1 && y != -1)
            {
                //mf.mydelay(100, 300);
                mf.mytap(this._jubing, x, y);
                //WriteLog.WriteLogFile(this._mnqName, "忍者特训-只取的右上角的X号");
                //mf.mydelay(200, 500);
            }
            mf.myqudianqusezuobiao(this._jubing, 0xfffbef, "0|-2|0xa52625,-2|-2|0xfffdf0,-2|0|0xa52521,-4|0|0xa52421,-1|2|0xa52421,2|1|0xbb5452", 90,185, 15, 205, 30, out x, out y);
            if (x != -1 && y != -1)
            {
                //mf.mydelay(100, 300);
                mf.mytap(this._jubing, x, y);
                //WriteLog.WriteLogFile(this._mnqName, "登录福利-只取的右上角的X号");
                //mf.mydelay(200, 500);
            }
            FuHeDuoDian fh = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("右上角关闭角色界面");
            mf.myqudianqusezuobiaoByLeiWuJubing(fh.Dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,fh.Name);
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
            }
            fh = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("角色升级获取徽章的关闭");
            mf.myqudianqusezuobiaoByLeiWuJubing(fh.Dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,fh.Name);
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
            }
            fh = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("关闭体力获取界面");
            mf.myqudianqusezuobiaoByLeiWuJubing(fh.Dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,fh.Name);
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
            }
            fh = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("任一点关闭角色升级后");
            mf.myqudianqusezuobiaoByLeiWuJubing(fh.Dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName,fh.Name);
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
            }
            fh = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("离开战场仍有未领取宝箱");
            mf.myqudianqusezuobiaoByLeiWuJubing(fh.Dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, fh.Name);
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
            }
            fh = YiQuan_DuoDian.GetObject().findFuHeDuodianByName("开头萌新礼包关闭按钮");
            mf.myqudianqusezuobiaoByLeiWuJubing(fh.Dz, out x, out y);
            if (x != -1 && y != -1)
            {
                WriteLog.WriteLogFile(this._mnqName, fh.Name);
                mf.mytap(this._jubing, fh.Zhidingx, fh.Zhidingy);
            }
        }

        /// <summary>
        /// 启动游戏
        /// </summary>
        /// <param name="index"></param>
        /// <param name="name"></param>
        public void qidong(int index, string name)
        {
            
        }
        public void guanbi(int index, string name)
        {
            
        }
        /// <summary>
        /// 已启动判断
        /// </summary>
        /// <returns></returns>
        public Boolean yiqidong()
        {
            var res = false;
            int x = -1;
            int y = -1;
            if (panduanjiemian("主界面"))
            {
                mf.mydelay(2000, 5000);
                mf.mytap(this._jubing, 8, 7);//点 设置
                mf.mydelay(2000, 5000);
                mf.myqudianqusezuobiao(this._jubing, 0xe3e3e3, "-5|0|0x504f50,3|-2|0xb9b9b9,8|-1|0xa4a4a4", 90, 90, 80, 115, 95, out x, out y);
                if (x != -1 && y != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this._jubing, x, y);
                    //WriteLog.WriteLogFile(this._mnqName, "发现注销按钮");                    
                    mf.mydelay(2000, 5000);
                    mf.mytap(this._jubing, 142, 86);//确认 点确认
                }
            }
            return res;
        }

        public Boolean chongxindenglu()
        {
            
            return true;
        }
        
    }
}
