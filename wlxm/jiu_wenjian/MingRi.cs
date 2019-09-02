using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xDM;
using MyUtil;
using LuciferSrcipt;
using System.Threading;
namespace fuzhu
{
    public class MingRi:youxi
    {
        private myDm mf;
        private int dqinx;
        private int jubing;
        private string mnqName;
        private int bangdingjieguo = 0;
        /// <summary>
        /// 跳过动画专用点击位置x
        /// </summary>
        private int tiaoguoyongX = 40;
        /// <summary>
        /// 跳过动画专用点击位置y
        /// </summary>
        private int tiaoguoyongY = 510;

       
        public  MingRi(xDm mydm, int dqinx,string dizhi)
        {
            this.mf = (myDm)mydm;
            this.dqinx = dqinx;
            this.jubing = MyLdcmd.getDqmoniqiJuBingByIndex(dqinx,dizhi);            
            //模拟器的名字 取值有问题 改为index
            this.mnqName = dqinx + "";
            WriteLog.WriteLogFile(this.mnqName, "明日构造函数,句柄是:" + jubing + ",模拟器index是:" + mnqName + "，thread:" + Thread.CurrentThread.ManagedThreadId);
        }
        



        
        public int getMyDqindex()
        {
            return this.dqinx;
        }

        public xDm getMyDm()
        {
            return this.mf;
        }
        public void ceshi() {
            zhuxian_break();
        }

        public void tiaoguo(string jieduan)
        {
            //情况： 自动 or 跳过
            int x = -1;
            int y = -1;
            if ("前段".Equals(jieduan) || "中段".Equals(jieduan) || "后段".Equals(jieduan))
            {
                mf.myqudianqusezuobiao(this.jubing, 0xe6e9e7, "-2|-4|0xffffff,6|-2|0xf8f5f8,10|2|0xfffbff,20|2|0xdee1de,28|5|0xffffff,43|5|0xffffff,43|-2|0xffffff,48|1|0xffffff,50|0|0xf7f7f7", 90, 0, 0, 959, 539, out x, out y);
                if (x != -1 && y != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this.jubing, x, y);
                    WriteLog.WriteLogFile(this.mnqName, "发现一个自动或跳过，选跳过");
                    mf.mydelay(200, 500);
                    mf.myqudianqusezuobiao(this.jubing, 0x75191a, "-5|-3|0x6b1010,-5|-8|0xffffff,-5|-19|0x731418,8|-19|0x701111,8|-7|0x731010,-222|-135|0x333333,-217|-135|0x333333,-217|-142|0x333333,-211|-142|0x333333", 90, 0, 0, 959, 539, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        WriteLog.WriteLogFile(this.mnqName, "是否跳过剧情，选是");
                        mf.mydelay(200, 500);
                    }
                }

                mf.myqudianqusezuobiao(this.jubing, 0x75191a, "-5|-3|0x6b1010,-5|-8|0xffffff,-5|-19|0x731418,8|-19|0x701111,8|-7|0x731010,-222|-135|0x333333,-217|-135|0x333333,-217|-142|0x333333,-211|-142|0x333333", 90, 0, 0, 959, 539, out x, out y);
                if (x != -1 && y != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this.jubing, x, y);
                    WriteLog.WriteLogFile(this.mnqName, "是否跳过剧情，选是");
                    mf.mydelay(200, 500);
                }

                mf.myqudianqusezuobiao(this.jubing, 0x9c6b5a, "0|10|0xf7e7ce,-15|7|0x92c7c8,-16|2|0x101c21,-28|2|0x977167,-28|-11|0x533c31,-3|-33|0x949992,6|-44|0x483229,11|29|0xdacdb2", 90, 0, 0, 200, 200, out x, out y);
                if (x != -1 && y != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    WriteLog.WriteLogFile(this.mnqName, "出现讲解头像-左上角,跳过,点击左下角");
                    mf.mydelay(200, 500);
                    //出现手的提示 点指向的位置
                    mf.myqudianqusezuobiao(this.jubing, 0xd5d8d5, "1|2|0xe6e6e6,6|2|0xe8e7e8,6|5|0xd7dcde,8|5|0xd7dcde,14|9|0xe0e4e5,17|10|0xd4d5d6,16|12|0xdce0d3,18|12|0xd4d3d6", 90, 0, 0, 959, 539, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x - 40, y - 30);
                        WriteLog.WriteLogFile(this.mnqName, "讲解头像出现手的提示,点指向位置");
                        mf.mydelay(200, 500);
                    }
                    //出现灰色对号的提示 点指向的位置
                    mf.myqudianqusezuobiao(this.jubing, 0x7f7c75, "12|0|0x918d80,14|5|0x969485,18|8|0x908d7e,18|1|0x343433,25|1|0x8c8a7d,31|1|0x353332,31|-6|0x908d7f,40|11|0x65625a", 90, 0, 0, 959, 539, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        WriteLog.WriteLogFile(this.mnqName, "讲解头像出现对号的提示,点指向位置");
                        mf.mydelay(200, 500);
                    }
                    //出现开始行动的提示 点指向的位置
                    mf.myqudianqusezuobiao(this.jubing, 0xadccd2, "4|0|0xf2f3f7,5|-6|0xfffbff,13|-6|0xe3f5fa,14|-12|0x0092d6,15|2|0xfdffff,-26|-6|0x008ace,-42|2|0xffffff,-49|-5|0xb6d3df", 90, 0, 0, 959, 539, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        WriteLog.WriteLogFile(this.mnqName, "讲解头像出现开始行动的提示,第一次编队战斗");
                        mf.mydelay(200, 500);
                    }
                    for (var i = 0; i < 2; i++)
                    {
                        mf.myqudianqusezuobiao(this.jubing, 0xe6e9e7, "-2|-4|0xffffff,6|-2|0xf8f5f8,10|2|0xfffbff,20|2|0xdee1de,28|5|0xffffff,43|5|0xffffff,43|-2|0xffffff,48|1|0xffffff,50|0|0xf7f7f7", 90, 0, 0, 959, 539, out x, out y);
                        if (x != -1 && y != -1)
                        {
                            mf.mydelay(10, 30);
                            mf.mytap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                            mf.mydelay(20, 50);
                        }
                        mf.mydelay(100, 2000);
                    }
                }

                mf.myqudianqusezuobiao(this.jubing, 0x7d5b50, "4|-12|0x9f7865,-8|-11|0x7b584d,-17|3|0xf8e3cb,-18|14|0x24272f,-1|29|0xf7ebce,22|12|0x6c4a3f,22|35|0x9c9b7a,1|35|0xf7ebce", 90, 110, 400, 160, 460, out x, out y);
                if (x != -1 && y != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    WriteLog.WriteLogFile(this.mnqName, "出现讲解头像-右下角,跳过,点击左下角");
                    mf.mydelay(200, 500);
                }

                mf.myqudianqusezuobiao(this.jubing, 0xffffff, "0|6|0xffffff,5|6|0xffffff,5|11|0x0c0d10,-3|8|0x0e0e12,-13|7|0xbdbbbb,-18|5|0xffffff,-21|6|0x0f0e12,-15|3|0x0f1014", 90, 0, 0, 959, 539, out x, out y);
                if (x != -1 && y != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this.jubing, x, y);
                    WriteLog.WriteLogFile(this.mnqName, "发现一个跳过，选跳过");
                    mf.mydelay(200, 500);
                    mf.mydelay(2000, 5000);
                    mf.mytap(this.jubing, 635, 381);//选择是 
                    mf.mydelay(2000, 5000);
                    mf.myqudianqusezuobiao(this.jubing, 0x75191a, "-5|-3|0x6b1010,-5|-8|0xffffff,-5|-19|0x731418,8|-19|0x701111,8|-7|0x731010,-222|-135|0x333333,-217|-135|0x333333,-217|-142|0x333333,-211|-142|0x333333", 90, 0, 0, 959, 539, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        WriteLog.WriteLogFile(this.mnqName, "是否跳过剧情，选是");
                        mf.mydelay(200, 500);
                    }
                }
            }
            if ("中段".Equals(jieduan) || "后段".Equals(jieduan))
            {
                mf.myqudianqusezuobiao(this.jubing, 0xfafafa, "-42|-9|0xffffff,-22|0|0xfdfefd,-42|5|0x211818,-42|30|0xefefef,-32|41|0xe8eae8,-4|41|0xfefefe,-2|15|0x292421,6|29|0x212018", 90, 0, 0, 959, 539, out x, out y);
                if (x != -1 && y != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    WriteLog.WriteLogFile(this.mnqName, "出现PTRS头像-左上角");
                    mf.mydelay(200, 500);
                    //出现手的提示 点指向的位置
                    mf.myqudianqusezuobiao(this.jubing, 0xd1d0d1, "5|4|0xfefefe,9|4|0xf5f3f5,9|8|0xf3f3f3,14|8|0xfdfcfd,17|12|0xffffff,20|16|0xfefbfe,24|13|0xfefcfe,27|20|0xfefefe", 90, 0, 0, 959, 539, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x - 40, y - 30);
                        WriteLog.WriteLogFile(this.mnqName, "PTRS头像出现手的提示,点指向位置");
                        mf.mydelay(200, 500);
                    }
                    //出现对号的提示 点指向的位置
                    mf.myqudianqusezuobiao(this.jubing, 0x0075a5, "-3|-4|0x0879a8,-15|-4|0x0075a5,-15|-15|0x0075a5,-2|-15|0xffffff,-2|5|0xffffff,6|5|0xffffff,12|3|0xffffff,19|1|0x0075a5", 90, 0, 0, 959, 539, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        WriteLog.WriteLogFile(this.mnqName, "PTRS头像出现对号的提示,第一次确认编队");
                        mf.mydelay(200, 500);
                    }
                    //出现开始行动的提示 点指向的位置
                    mf.myqudianqusezuobiao(this.jubing, 0xadccd2, "4|0|0xf2f3f7,5|-6|0xfffbff,13|-6|0xe3f5fa,14|-12|0x0092d6,15|2|0xfdffff,-26|-6|0x008ace,-42|2|0xffffff,-49|-5|0xb6d3df", 90, 0, 0, 959, 539, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        WriteLog.WriteLogFile(this.mnqName, "PTRS头像出现开始行动的提示,第一次编队战斗");
                        mf.mydelay(200, 500);
                    }
                }


               
                mf.myqudianqusezuobiao(this.jubing, 0xd1d2d1, "0|-17|0x251d1d,-9|-17|0xe7e7e7,-11|-38|0xf8f8f8,11|-38|0xf1f4f1,19|-16|0x2a211b,31|-16|0x211818,49|-15|0xe7e7e7,46|1|0xececec", 90, 0, 0, 959, 539, out x, out y);
                if (x != -1 && y != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    WriteLog.WriteLogFile(this.mnqName, "出现PTRS头像-左下角");
                    mf.mydelay(200, 500);
                    //出现手的提示 点指向的位置
                    mf.myqudianqusezuobiao(this.jubing, 0xf6f6f6, "4|4|0xffffff,8|4|0xfffdff,8|7|0xe9e9e9,14|10|0xe4e4e4,17|12|0xe6e6e1,22|12|0xe4e0e4,22|17|0xe2dee2,36|22|0xe2e1e0", 90, 0, 0, 959, 539, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x - 40, y - 30);
                        WriteLog.WriteLogFile(this.mnqName, "PTRS头像出现手的提示,点指向位置");
                        mf.mydelay(200, 500);
                    }
                }
            }
            if ("后段".Equals(jieduan))
            {
                mf.myqudianqusezuobiao(this.jubing, 0xffffff, "-2|-4|0xfbfbfc,-2|4|0xfaf9f9,-4|10|0xd3d4d4,-4|18|0xe2e6e2,1|18|0xfbfbfb,9|18|0xffffff,-478|68|0x45464a,-466|223|0x3f4243,-425|289|0x211e23", 90, 0, 0, 959, 539, out x, out y);
                if (x != -1 && y != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this.jubing, x, y);
                    WriteLog.WriteLogFile(this.mnqName, "第一次寻访,出现skip");
                    mf.mydelay(2000, 5000);
                    mf.mydelay(6000, 7000);
                    mf.mytap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    mf.mydelay(100, 300);
                }
                mf.myqudianqusezuobiao(this.jubing, 0xf9ebd8, "-4|-1|0xddb6af,-12|-2|0x56281c,-12|-12|0x945939,2|-16|0x8e6748,2|10|0xd2b8a2,2|18|0xf1e2c8,21|21|0xb87870,6|31|0x202027", 90, 0, 0, 959, 539, out x, out y);
                if (x != -1 && y != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    WriteLog.WriteLogFile(this.mnqName, "出现战斗时讲解头像-左上角,跳过,点击左下角");
                    mf.mydelay(200, 500);
                }

                mf.myqudianqusezuobiao(this.jubing, 0xc1bebe, "-9|0|0xc0bebe,-20|0|0xc0bebe,-20|-4|0xc1bfbe,-31|4|0xc1bfbf,-38|9|0xbebcbb,-50|7|0xc2c0bf,-197|-238|0xfffeff,32|0|0xb6b2b1", 90, 0, 0, 959, 539, out x, out y);
                if (x != -1 && y != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    WriteLog.WriteLogFile(this.mnqName, "任务失败,点击画面已继续");
                    mf.mydelay(200, 500);
                }

                mf.myqudianqusezuobiao(this.jubing, 0x525552, "8|0|0x070306,8|7|0x525552,15|9|0x070405,23|66|0xffffff,24|75|0xffffff,18|75|0x040102,200|55|0xffffff,196|61|0x0c0c0b", 90, 0, 0, 959, 539, out x, out y);
                if (x != -1 && y != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    WriteLog.WriteLogFile(this.mnqName, "行动结束,点击继续");
                    mf.mydelay(200, 500);
                }

                mf.myqudianqusezuobiao(this.jubing, 0xf8f9f8, "7|0|0x313031,9|10|0x9d9f9d,172|-3|0xd6d7d6,199|-1|0x595859,282|-6|0xfdfdfd,473|298|0x313031,523|295|0xf3f1ef,525|285|0xa587b7,241|222|0x00aef6", 90, 0, 0, 959, 539, out x, out y);
                if (x != -1 && y != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this.jubing, x, y);
                    WriteLog.WriteLogFile(this.mnqName, "放弃行动后,停留在战区画面-第二级");
                    mf.mydelay(200, 500);
                }

                mf.myqudianqusezuobiao(this.jubing, 0xf9faf9, "6|-1|0x313031,7|-10|0xbabdba,304|238|0xe2ebea,286|158|0x6491ac,266|222|0x7f99ab,242|273|0x223949,286|312|0x7b7c87,348|355|0x28334a,708|251|0x731519", 90, 0, 0, 959, 539, out x, out y);
                if (x != -1 && y != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this.jubing, x, y);
                    WriteLog.WriteLogFile(this.mnqName, "放弃行动后,停留在战区画面-第一级");
                    mf.mydelay(200, 500);
                }

                mf.myqudianqusezuobiao(this.jubing, 0xc3c3c3, "-4|-5|0xc6c3c6,6|-6|0xc6c3c6,6|-2|0x555455,8|5|0xb2afb2,1|6|0x656665,-7|6|0xc6c7c6,-7|0|0x5a595a,-16|0|0x5a595a", 90, 0, 0, 959, 539, out x, out y);
                if (x != -1 && y != -1)
                {
                    int tmpx = -1;
                    int tmpy = -1;
                    mf.mydelay(100, 300);
                    mf.myqudianqusezuobiao(this.jubing, 0xab5256, "-2|-27|0x0075a5,-2|-72|0x4d9fc0,-47|-65|0x288bb3,-39|-24|0x0d6e9a,20|-17|0x852c36,-5|1|0x90272d,-20|7|0xac5559,-10|-16|0x1580ac", 90, 200, 200, 300, 350, out tmpx, out tmpy);
                    if (tmpx != -1 && tmpy != -1)
                    {
                        mf.mydelay(100, 300);
                        mf.mytap(this.jubing, 263, 409);
                        WriteLog.WriteLogFile(this.mnqName, "第一天登录,领取600红玉,领掉");
                        mf.mydelay(2000, 5000);
                        mf.mytap(this.jubing, 475, 482);
                        mf.mydelay(3000, 6000);
                    }
                    mf.mytap(this.jubing, x, y);
                    WriteLog.WriteLogFile(this.mnqName, "以活动公告界面关闭为例，-只取的右上角的X号");
                    mf.mydelay(200, 500);
                }

                mf.myqudianqusezuobiao(this.jubing, 0x7d7b6b, "-4|3|0x797668,-8|8|0x7d796d,-14|13|0x7e7c6d,-16|10|0x787669,-21|6|0x7f7c6f,-17|7|0x7a766a,-6|12|0x2c2b29,-16|27|0x7b786d", 90, 0, 0, 959, 539, out x, out y);
                if (x != -1 && y != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    WriteLog.WriteLogFile(this.mnqName, "界面下方单独的一个对号,点击跳过");
                    mf.mydelay(200, 500);
                }
            }
            
        }
        public void fuben()
        { 
        }
        public void jiangli()
        {
        }
        public Boolean chongxindenglu()
        {
            return false;
        }
        public void tiaoguo()
        {
        }
        public void richang()
        {
        }
        public void zhuxian()
        {
            WriteLog.WriteLogFile(this.mnqName, "进入到主线任务");
            bool tmp = false;
            var kstime = mf.GetTime();
            var jieduan = "前段";
            while (true) {
                
                zhuxianLinShi();
                var jstime = mf.GetTime();
                if ((jstime - kstime) > 1000 * 60 * 5) {
                    jieduan = "中段";
                }
                if ((jstime - kstime) > 1000 * 60 * 10)
                {
                    jieduan = "后段";
                }
                tiaoguo(jieduan);
                if ((jstime - kstime) > 1000 * 60 * 15) {
                    tmp = zhuxian_break();
                    if (tmp)
                    {
                        WriteLog.WriteLogFile(this.mnqName, "主线任务到达break条件,break");
                        break;
                    }
                }
                if((jstime-kstime)>1000*60*180){
                    WriteLog.WriteLogFile(this.mnqName,"主线任务时间延续到了2个半小时,break");
                    break;
                }
            }
            lingqu_youjian();
            shouci_xunfang();
            
        }

        private void zhuxianLinShi()
        {
            //出现头像 需要拖拽到指定位置
            int x = -1;
            int y = -1;
            mf.myqudianqusezuobiao(this.jubing, 0x9c6b5a, "0|10|0xf7e7ce,-15|7|0x92c7c8,-16|2|0x101c21,-28|2|0x977167,-28|-11|0x533c31,-3|-33|0x949992,6|-44|0x483229,11|29|0xdacdb2", 90, 0, 0, 959, 539, out x, out y);
            if (x != -1 && y != -1)
            {
                int x1 = -1;
                int y1 = -1;

                mf.myqudianqusezuobiao(this.jubing, 0xffa200, "-6|-6|0xffa200,-8|4|0xffa200,-2|4|0xffa200,3|5|0xffa200,5|-1|0xffa200,-34|-15|0xffa200,-64|-27|0xffa200,-9|5|0xffa200", 90, 0, 0, 959, 539, out x1, out y1);
                if (x1 != -1 && y1 != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mydrag(this.jubing, x1, y1, 445, 315);
                    mf.delay(2000);
                    mf.mydrag(this.jubing, 445, 315, 585, 317);
                    mf.delay(2000);
                    WriteLog.WriteLogFile(this.mnqName, "出现讲解头像同时需要拖拽到指定位置-第一次" + x1 + " " + y1);
                    mf.mydelay(200, 500);
                }
                mf.myqudianqusezuobiao(this.jubing, 0xffa200, "0|-9|0xfaa003,-8|-1|0xffa200,-1|7|0xffa200,9|4|0xfea406,7|-2|0xffa200,-2|13|0xffe5d6,-20|4|0x636173,11|-6|0x636375", 90, 800, 480, 840, 510, out x1, out y1);
                if (x1 != -1 && y1 != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mydrag(this.jubing, x1, y1, 445, 315);
                    mf.delay(2000);
                    mf.mydrag(this.jubing, 445, 315, 585, 317);
                    mf.delay(2000);
                    WriteLog.WriteLogFile(this.mnqName, "出现讲解头像同时需要拖拽到指定位置-第一次 修正后" + x1 + " " + y1);
                    mf.mydelay(200, 500);
                }

                mf.myqudianqusezuobiao(this.jubing, 0xffa200, "-5|10|0xfea40a,-10|12|0xaa705b,-17|3|0x6b2842,-17|-8|0xe9930f,-23|-13|0xf59c01,-29|-18|0xfea100,-30|0|0xf7ede4,-185|-125|0xffa200", 90, 0, 0, 959, 539, out x1, out y1);
                if (x1 != -1 && y1 != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mydrag(this.jubing, x1, y1, 527, 244);
                    mf.delay(2000);
                    mf.mydrag(this.jubing, 527, 244, 700, 248);
                    mf.delay(2000);
                    WriteLog.WriteLogFile(this.mnqName, "出现讲解头像同时需要拖拽到指定位置-第二次");
                    mf.mydelay(200, 500);
                }

                mf.myqudianqusezuobiao(this.jubing, 0xffa200, "2|-10|0xffa200,-7|-4|0xffa200,-6|1|0xffa200,-1|3|0xffa200,-4|16|0xffe3d6,9|19|0xffe3da,-6|20|0xffe7d9,8|-22|0xf4e5de", 90, 900, 470, 925, 520, out x1, out y1);
                if (x1 != -1 && y1 != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mydrag(this.jubing, x1, y1, 527, 244);
                    mf.delay(2000);
                    mf.mydrag(this.jubing, 527, 244, 700, 248);
                    mf.delay(2000);
                    WriteLog.WriteLogFile(this.mnqName, "出现讲解头像同时需要拖拽到指定位置-第二次 是否越界 "+x1);
                    mf.mydelay(200, 500);
                }
            }
        }

        private bool zhuxian_break()
        {
            int x = -1;
            int y = -1;
            mf.myqudianqusezuobiao(this.jubing, 0x3e3b3b, "0|-7|0x8c8e8c,5|-7|0x8c8e8c,12|-5|0x8c8e8c,12|7|0x8c8e8c,3|12|0x8c8e8c,-7|12|0x8c8e8c,-14|8|0x8c8e8c,-2|6|0x3c3938", 90, 0, 0, 959, 539, out x, out y);
            if (x != -1 && y != -1)
            {
                mf.mydelay(100, 300);
                mf.mytap(this.jubing, x, y);
                WriteLog.WriteLogFile(this.mnqName, "进入到战斗场面，选放弃战斗");
                mf.mydelay(200, 500);
                mf.mydelay(2000, 3000);
                mf.mytap(this.jubing, 716, 428);//选择放弃行动 
                mf.mydelay(2000, 3000);
                mf.myqudianqusezuobiao(this.jubing, 0x731010, "-3|-3|0xc7a09f,-13|-5|0xdcc6c6,-13|1|0xece1e1,-14|10|0xb2807f,-3|9|0xf4ecec,3|9|0xeadcdc,20|9|0x791515,22|-4|0xf1e7e7", 90, 0, 0, 959, 539, out x, out y);
                if (x != -1 && y != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this.jubing, x, y);
                    WriteLog.WriteLogFile(this.mnqName, "选放弃战斗");
                    mf.mydelay(200, 500);
                }
                int kstime = mf.GetTime();
                while (true) {
                    mf.mytap(this.jubing, tiaoguoyongX, tiaoguoyongY);//任务失败,点击画面已继续
                    mf.mydelay(6000, 7000);
                    mf.mytap(this.jubing, 31, 29);//回到主界面
                    mf.mydelay(6000, 7000);
                    mf.myqudianqusezuobiao(this.jubing, 0xc3c3c3, "-4|-5|0xc6c3c6,6|-6|0xc6c3c6,6|-2|0x555455,8|5|0xb2afb2,1|6|0x656665,-7|6|0xc6c7c6,-7|0|0x5a595a,-16|0|0x5a595a", 90, 0, 0, 959, 539, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        WriteLog.WriteLogFile(this.mnqName, "放弃战斗后--以活动公告界面关闭为例，-只取的右上角的X号");
                        mf.mydelay(200, 500);
                    }
                    mf.myqudianqusezuobiao(this.jubing, 0x7d7b6b, "-4|3|0x797668,-8|8|0x7d796d,-14|13|0x7e7c6d,-16|10|0x787669,-21|6|0x7f7c6f,-17|7|0x7a766a,-6|12|0x2c2b29,-16|27|0x7b786d", 90, 0, 0, 959, 539, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        mf.mydelay(100, 300);
                        mf.mytap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                        WriteLog.WriteLogFile(this.mnqName, "放弃战斗后--界面下方单独的一个对号,点击跳过");
                        mf.mydelay(200, 500);
                    }
                    if (panduanjiemian("主界面")){
                        break;
                    }
                    int jstime = mf.GetTime();
                    if ((jstime - kstime) > 60000 * 5) {
                        WriteLog.WriteLogFile(this.mnqName, "放弃战斗后,回到主界面失败");
                        break;
                    }
                }
                
                return true;
            }
            return false;
        }

        public void lingqu()
        {
            lingqu_youjian();
        }
        private void lingqu_youjian() {
            int x1 = -1;
            int y1 = -1;
            if (panduanjiemian("主界面"))
            {
                mf.mydelay(100, 300);
                mf.mytap(this.jubing, 146, 27);
                WriteLog.WriteLogFile(this.mnqName, "主界面进入邮件区");
                mf.mydelay(6200, 7500);
            }
            mf.myqudianqusezuobiao(this.jubing,0x88bed8, "-9|0|0xd0e6f0,-19|0|0x4b9fc4,-25|0|0x1f87b9,-26|-9|0x1c84b4,67|17|0x0778ac,74|0|0xd9eaf2,44|4|0x72b3d0,26|4|0xeff6fa", 90, 0, 0, 959, 539, out x1, out y1);
            if (x1 != -1 && y1 != -1)
            {
                mf.mydelay(100, 300);
                mf.mytap(this.jubing, x1, y1);
                WriteLog.WriteLogFile(this.mnqName, "开具领取邮件-领取所有邮件");
                mf.mydelay(5200, 6500);
                mf.mytap(this.jubing, 477, 479);//过5秒 点击空白处跳过动画
                mf.mydelay(4200, 5500);
                mf.mytap(this.jubing, 31, 29);//回到主界面
                mf.mydelay(6200, 8500);
            }
            if (panduanjiemian("主界面"))
            {
                WriteLog.WriteLogFile(this.mnqName, "准备领取累计签到的600");
                mf.mydelay(100, 300);
                mf.mytap(this.jubing, 69, 85);
                mf.mydelay(3000, 6000);
                mf.myqudianqusezuobiao(this.jubing,0x973136, "-2|98|0x4b96b9,6|-53|0x0075a5,-19|-72|0x0075a5,29|-79|0x0075a5,33|36|0x0a83be,26|112|0x58afd7,-5|132|0x37323c,-11|-1|0x9d3e43", 90, 200, 200, 300, 500, out x1, out y1);
                if (x1 != -1 && y1 != -1)
                {
                    mf.mydelay(100, 300);
                    WriteLog.WriteLogFile(this.mnqName, "600已经领过了,退出吧");
                    mf.mytap(this.jubing, 932, 53);
                    mf.mydelay(2000, 5000);
                    return;
                }
                mf.mytap(this.jubing, 257, 407);
                mf.mydelay(1000, 3000);
                WriteLog.WriteLogFile(this.mnqName, "顺利领了600");
                mf.mytap(this.jubing, 478, 478);
                mf.mydelay(2000, 5000);
                mf.mytap(this.jubing, 932, 53);
                mf.mydelay(2000, 5000);
            }
        }
        public void shouci_xunfang() {
            if (panduanjiemian("主界面"))
            {
                mf.mydelay(100, 300);
                mf.mytap(this.jubing, 880, 387);
                WriteLog.WriteLogFile(this.mnqName, "主界面进入寻访区");
                mf.mydelay(3200, 5500);
                mf.mytap(this.jubing, 916, 289);
                mf.mydelay(3200,5500);
                mf.mytap(this.jubing, 916, 289);
                WriteLog.WriteLogFile(this.mnqName, "寻访区进入600区");
                mf.mydelay(6200, 7500);
                bool tmp = false;
                while (true)
                {
                    tmp = xunfang();
                    if (tmp)
                    {
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
            mf.myqudianqusezuobiao(this.jubing, 0xffffff, "-1|-11|0x28292b,-11|8|0x212021,-11|10|0xd3cfcc,-12|9|0xc7c3bf,-13|12|0xfefbfe,-14|12|0xc4c6c5,-14|17|0xc2c2c3,-10|17|0xb9bab9", 90, 850, 10, 950, 100, out x1, out y1);
            if (x1 != -1 && y1 != -1) {
                mf.mydelay(100, 300);
                mf.mytap(this.jubing,x1, y1);
                WriteLog.WriteLogFile(this.mnqName, "寻访后出现skip");
                mf.mydelay(3000, 7000);
                mf.mytap(this.jubing,tiaoguoyongX, tiaoguoyongY);//过5秒 点击空白处跳过动画
                mf.mydelay(4000, 7000);
            }
            int x2 = -1;
            int y2 = -1;
            mf.myqudianqusezuobiao(this.jubing,0x3f3f3f, "-12|0|0x353535,-28|1|0xc6c6c7,-29|-41|0xb13a3a,-36|-30|0xb42020,-9|-32|0xe4e4e4,-4|-30|0xf3f3f3,19|0|0x343434,9|0|0x343434", 90, 0, 0, 959, 539, out x2, out y2);
            if (x2 != -1 && y2 != -1)
            {
                mf.mydelay(100, 300);
                mf.mytap(this.jubing,x2, y2);
                WriteLog.WriteLogFile(this.mnqName, "花费600寻访一次");
                mf.mydelay(200, 500);
            }
            int x3 = -1;
            int y3 = -1;
            mf.myqudianqusezuobiao(this.jubing,0x700f0d, "29|3|0xe5d2d3,-117|8|0x7c1f20,15|-13|0x6f0f11,-191|-144|0x8c8a8c,-253|-17|0x080b08,-319|11|0x110d0a,-3|-8|0xffffff", 90, 0, 0, 959, 539, out x3, out y3);
            if (x3 != -1 && y3 != -1)
            {
                mf.mydelay(100, 300);
                mf.mytap(this.jubing,x3, y3);
                WriteLog.WriteLogFile(this.mnqName, "花费600寻访一次，是否确认，是");
                mf.mydelay(200, 500);
            }
            mf.myqudianqusezuobiao(this.jubing,0x4f4c48, "-4|-4|0x080c08,64|0|0xebeaea,141|-92|0x6c6c6c,152|-88|0x8c8e8c,152|-84|0x505050,147|-84|0x4b4b4b,270|-234|0x4d5684,271|-222|0x4f5788", 90, 150, 110, 450, 380, out x3, out y3);
            if (x3 != -1 && y3 != -1)
            {
                mf.mydelay(100, 300);
                mf.mytap(this.jubing,x3, y3);
                WriteLog.WriteLogFile(this.mnqName, "出现花费能源石界面,点取消,停止寻访");
                mf.mydelay(3000, 7000);
                mf.mytap(this.jubing, x3, y3);
                mf.mydelay(3000, 7000);
                mf.mytap(this.jubing,28, 29);//过5秒 返回上一界面
                mf.mydelay(3000, 7000);
                tmp = true;
            }
            mf.myqudianqusezuobiao(this.jubing,0x0b0b0a, "-2|-6|0x8f8a86,-4|4|0x101010,2|6|0xffffff,92|-102|0xe3e0e3,150|-91|0xc0c0c0,150|-94|0x505150,173|-94|0x929292,290|-195|0xffffff,292|-214|0x7b828e", 90, 150, 110, 470, 380, out x3, out y3);
            if (x3 != -1 && y3 != -1)
            {
                mf.mydelay(100, 300);
                mf.mytap(this.jubing, x3, y3);
                WriteLog.WriteLogFile(this.mnqName, "出现花费能源石界面,点取消,停止寻访");
                mf.mydelay(3000, 7000);
                mf.mytap(this.jubing, x3, y3);
                mf.mydelay(3000, 7000);
                mf.mytap(this.jubing, 28, 29);//过5秒 返回上一界面
                mf.mydelay(3000, 7000);
                tmp = true;
            }
            if (x1 == -1 && y1 == -1 && x2 == -1 && y2 == -1 && x3 == -1 && y3 == -1) {
                mf.myqudianqusezuobiao(this.jubing, 0x000000, "57|8|0x000000,98|8|0x000000,175|9|0x000000,229|9|0x000000,274|9|0x000000,331|5|0x000000,208|9|0x000000,266|14|0x000000", 90, 30, 500, 400, 530, out x1, out y1);
                if (x1 != -1 && y1 != -1)
                {
                    mf.mydelay(1000, 3000);
                    mf.mytap(this.jubing, tiaoguoyongX, tiaoguoyongY);//过5秒 点击空白处跳过动画
                    mf.mydelay(2000, 4000);
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
                mf.mytap(this.jubing, 781, 261);
                WriteLog.WriteLogFile(this.mnqName, "主界面进入干员区-准备截图");
                mf.mydelay(4200, 7500);
                mf.mytap(this.jubing, 31, 30);
                mf.mydelay(4200, 7500);
                mf.mytap(this.jubing, 781, 261);
                mf.mydelay(4200, 7500);
                int x = -1;
                int y = -1;
                mf.myqudianqusezuobiao(this.jubing, 0xd6d7d6, "-173|4|0xfefefe,694|479|0x5e5d5a,720|368|0xd7d5d4,744|162|0xa5a2a5,396|1|0x0697d8,406|0|0x213b47,405|11|0x0a8ec9,467|1|0x5e5e5e", 90, 0, 0, 959, 539, out x, out y);
                if (x != -1 && y != -1)
                {
                    WriteLog.WriteLogFile(this.mnqName, "进入干员区成功");
                    mf.mydelay(220, 450);
                    res = 1;
                }
            }
            return res;
            
        }


        public Boolean denglu(int fenzhong)
        {
            WriteLog.WriteLogFile(this.mnqName, "进入到登录环节  " + this.jubing + "，thread:" + Thread.CurrentThread.ManagedThreadId);            
            Boolean abc = true;
            long kstime = mf.GetTime();
            int ox = -1;
            int oy = -1;
            int ox1 = -1;
            int oy1 = -1;
            while (true)
            {
                string result = "-1|-1";
                result = mf.myqudianquse(this.jubing,0xffd700, "0|-13|0xffd700,-14|-1|0xffd700,-14|10|0xffd700,4|20|0xfcd400,13|11|0xfcd400,26|11|0x000000,-1|13|0x000000", 90, 0, 0, 959, 539);
                string[] a1 = result.Split('|');
                if (int.Parse(a1[0]) != -1)
                {
                    int x = int.Parse(a1[0]);
                    int y = int.Parse(a1[1]);
                    mf.mytap(this.jubing,x,y);
                    WriteLog.WriteLogFile(this.mnqName, "找到start坐标" + x + " " + y + " " + this.jubing + "，thread:" + Thread.CurrentThread.ManagedThreadId);
                    mf.mydelay(200,300);
                }
                
                mf.myqudianqusezuobiao(this.jubing,0x525252, "-5|1|0xffffff,-12|2|0xffffff,-12|6|0xe1e1e1,-22|5|0xfefefe,59|133|0xebebeb,49|133|0xd6d6d6,46|126|0xf6f6f6,39|132|0xf8f8f8,28|134|0xb1b1b1", 90, 0, 0, 959, 539, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    WriteLog.WriteLogFile(this.mnqName, "发现游客坐标-跳出登录环节" + " " + this.jubing + "，thread:" + Thread.CurrentThread.ManagedThreadId);
                    break;
                }
                mf.myqudianqusezuobiao(this.jubing,0x131313, "-4|0|0xebeceb,-4|-3|0x201f20,3|1|0x121212,8|1|0xffffff,2|2|0x101010,7|-4|0x1a191a,-27|-110|0xa3a2a3,-15|-105|0x868686", 90, 0, 0, 959, 539, out ox1, out oy1);
                if (ox1 != -1 && oy1 != -1)
                {
                    WriteLog.WriteLogFile(this.mnqName, "有问题，延迟登录" + " " + this.jubing + "，thread:" + Thread.CurrentThread.ManagedThreadId);
                    mf.mytap(this.jubing, ox1, oy1);
                    mf.mydelay(600000,700000);
                }
                long jstime = mf.GetTime();
                if ((int.Parse(a1[0]) == -1 && (jstime - kstime) > fenzhong*60*1000))
                {
                    abc = false;
                    break;
                }
            }
            if (!abc){
                WriteLog.WriteLogFile(this.mnqName, "找寻start坐标失败");
            }
            return abc;
            
        }
        public Boolean zhuce(int fz)
        {
            WriteLog.WriteLogFile(this.mnqName, "进入到注册环节-点游客登录" + " " + this.jubing);
            Boolean abc = true;
            long kstime = mf.GetTime();
            int ox = -1;
            int oy = -1;
            while (true)
            {
                mf.myqudianqusezuobiao(this.jubing,0x525252, "-5|1|0xffffff,-12|2|0xffffff,-12|6|0xe1e1e1,-22|5|0xfefefe,59|133|0xebebeb,49|133|0xd6d6d6,46|126|0xf6f6f6,39|132|0xf8f8f8,28|134|0xb1b1b1", 90, 0, 0, 959, 539,out ox,out oy);
                if (ox != -1&& oy!=-1)
                {
                    mf.mydelay(200, 400);
                    mf.mytap(this.jubing,ox, oy);
                    mf.mydelay(2000, 3000);
                }
                long jstime = mf.GetTime();
                if ((ox== -1 && (jstime - kstime) > fz * 60 * 1000))
                {
                    abc = false;
                    break;
                }
                if (ox == -1 && oy == -1)
                {
                    int oxx = -1;
                    int oxy = -1;
                    mf.myqudianqusezuobiao(this.jubing,0x080708, "0|-7|0x3d3c3d,-6|-7|0x525252,-6|-16|0x8e8e8e,-16|0|0x080708,-15|7|0x8e8e8e,3|15|0x969696,179|44|0xdadada,170|44|0xdadada", 90, 280, 430, 500, 510, out oxx, out oxy);
                    if (oxx != -1 && oxy != -1)
                    {
                        WriteLog.WriteLogFile(this.mnqName, "找到游客登录坐标-break  " + this.jubing);
                        break;
                    }
                    mf.myqudianqusezuobiao(this.jubing,0x161516, "-5|0|0xffffff,-5|3|0xffffff,14|53|0x1f1a1c,11|59|0x242124,-22|-47|0x393839,-9|-50|0x393a39,25|-51|0x393739,-291|-89|0x4d4a4d", 90, 0, 0, 959, 539, out oxx, out oxy);
                    if (oxx != -1 && oxy != -1)
                    {
                        WriteLog.WriteLogFile(this.mnqName, "认证系统错误,跳过录入信息" + this.jubing);
                        mf.mydelay(200, 400);
                        mf.mytap(this.jubing,oxx, oxy);
                        mf.mydelay(2000, 4000);
                        mf.mytap(this.jubing, 488, 377);
                        mf.mydelay(2000, 4000);
                    }
                    mf.myqudianqusezuobiao(this.jubing,0x676467, "-8|0|0xdddbdd,-12|0|0x5f5f5f,-13|5|0x595959,-22|5|0xb8bfb8,-28|38|0xa7a7a7,-40|45|0x8b8a8b,-29|45|0x787778,-8|-15|0x525252", 90, 430, 360, 480, 430, out oxx, out oxy);
                    if (oxx != -1 && oxy != -1)
                    {
                        WriteLog.WriteLogFile(this.mnqName, "找到游客登录坐标,点击登录" + this.jubing);
                        mf.mydelay(200, 400);
                        mf.mytap(this.jubing, oxx, oxy);
                        mf.mydelay(2000, 3000);
                    }
                }
            }
            if (!abc)
            {
                WriteLog.WriteLogFile(this.mnqName, "找寻游客登录坐标失败");
            }
            WriteLog.WriteLogFile(this.mnqName, "进入到注册环节-点同意协议" + " " + this.jubing);
            kstime = mf.GetTime();
            ox = -1;
            oy = -1;
            while (true)
            {
                mf.myqudianqusezuobiao(this.jubing, 0x080708, "0|-7|0x3d3c3d,-6|-7|0x525252,-6|-16|0x8e8e8e,-16|0|0x080708,-15|7|0x8e8e8e,3|15|0x969696,179|44|0xdadada,170|44|0xdadada", 90, 280, 430, 500, 510, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    mf.delay(1000);
                    mf.mytap(this.jubing,ox, oy);
                    WriteLog.WriteLogFile(this.mnqName, "找到同意协议坐标" + ox + " " + oy + " " + this.jubing + " " + bangdingjieguo);
                    mf.mydelay(2000, 3000);
                    mf.mytap(this.jubing, 473, 501);
                    mf.mydelay(2000, 3000);
                }
                mf.myqudianqusezuobiao(this.jubing,0x21596e, "0|-5|0x22546b,-24|1|0x235e75,-6|8|0x22607d,23|0|0x22596f,-175|-45|0xffffff,-148|-46|0xf7f7f7,-121|-46|0xbebebe,-121|-78|0x3a3a3a", 90, 280, 320, 510, 550, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    mf.delay(1000);
                    mf.mytap(this.jubing, ox, oy);
                    WriteLog.WriteLogFile(this.mnqName, "已点击同意," + ox + " " + oy + " " + this.jubing + " " + bangdingjieguo);
                    mf.mydelay(2000, 3000);
                }
                if (ox == -1 && oy == -1)
                {
                    int oxx = -1;
                    int oxy = -1;
                    mf.myqudianqusezuobiao(this.jubing,0xacacac, "-11|0|0x999a99,-11|6|0xa5a6a5,-11|30|0xdc9c05,-11|37|0x795c17,-19|36|0xeba602,26|76|0xa7a6a7,71|71|0xfefefe,83|70|0xffffff", 90, 0, 0, 959, 539, out oxx, out oxy);
                    if (oxx != -1 && oxy != -1)
                    {
                        WriteLog.WriteLogFile(this.mnqName, "找到同意协议坐标-break" + this.jubing + " " + bangdingjieguo);
                        break;
                    }
                }
                long jstime = mf.GetTime();
                if ((ox == -1 && (jstime - kstime) > fz * 60 * 1000))
                {
                    abc = false;
                    break;
                }
            }
            if (!abc)
            {
                WriteLog.WriteLogFile(this.mnqName, "找寻同意协议坐标失败");
            }
            kstime = mf.GetTime();
            ox = -1;
            oy = -1;
            WriteLog.WriteLogFile(this.mnqName, "进入到注册环节-点输入姓名" + " " + this.jubing);
            while (true)
            {
                mf.myqudianqusezuobiao(this.jubing, 0xacacac, "-11|0|0x999a99,-11|6|0xa5a6a5,-11|30|0xdc9c05,-11|37|0x795c17,-19|36|0xeba602,26|76|0xa7a6a7,71|71|0xfefefe,83|70|0xffffff", 90, 0, 0, 959, 539, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    WriteLog.WriteLogFile(this.mnqName, "找到输入姓名按钮 " + ox + " " + oy);
                    mf.mydelay(3000, 4200);
                    mf.mytap(this.jubing, 483, 375);//先点击确定
                    mf.mydelay(5000, 6200);
                    mf.mytap(this.jubing, 476, 380);//先点击出现的对号提示 确保可以点开输入栏
                    mf.mydelay(3000, 4200);
                    mf.mytap(this.jubing, ox, oy);
                    mf.mydelay(2000, 3000);
                }
                mf.myqudianqusezuobiao(this.jubing,0x101010, "-4|-4|0x1d1c1d,4|-4|0x100c10,8|-7|0x1e211e,10|-9|0x1f1a1f,1|-22|0x1f1a1f,-1|-8|0xffffff,-16|6|0x0b0e0b,16|6|0x131413", 90, 460, 360, 500, 390, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    WriteLog.WriteLogFile(this.mnqName, "点确定后出现的提示 " + ox + " " + oy);
                    mf.mydelay(3000, 4200);
                    mf.mytap(this.jubing, ox, oy);
                    mf.mydelay(5000, 6200);
                    mf.mytap(this.jubing, 385, 304);//先点击出现的对号提示 确保可以点开输入栏
                    mf.mydelay(3000, 4200);
                }
                bool a = mf.myGetColor(this.jubing, 416, 487, "ffffff");
                if (a)
                {
                    WriteLog.WriteLogFile(this.mnqName, "打开了输入按钮-break" + this.jubing );
                    mf.mydelay(5000, 6000);
                    break;
                }
                long jstime = mf.GetTime();
                if ((ox == -1 && (jstime - kstime) > fz * 60 * 1000))
                {
                    abc = false;
                    break;
                }
            }
            if (!abc)
            {
                WriteLog.WriteLogFile(this.mnqName, "找寻输入姓名坐标失败");
            }
            kstime = mf.GetTime();
            ox = -1;
            oy = -1;
            WriteLog.WriteLogFile(this.mnqName, "进入到注册环节-逐个录入" + " " + this.jubing);
            while (true)
            {
                mf.myqudianqusezuobiao(this.jubing,0xffffff, "14|0|0xffffff,469|-2|0x353535,469|-10|0x212121,460|-9|0x212121,460|-3|0x353535,464|-1|0x212121,82|-114|0xf8f8f8,89|-111|0xb4b4b4", 90, 0, 0, 959, 539, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    mf.mydelay(1000, 2000);
                    ZhangHao zhanghao = new ZhangHao();
                    char[] suijichar = new char[] { '1', '2' };
                    foreach(char a in suijichar){
                        mf.myKeyPressChar(this.jubing,a.ToString());
                        mf.delay(800);
                        WriteLog.WriteLogFile(this.mnqName, "录入姓名中" + a.ToString() + this.jubing + " " + bangdingjieguo);
                    }
                    mf.mydelay(6000, 8000);
                    WriteLog.WriteLogFile(this.mnqName, "点击录入字符界面的确定 " + this.jubing);
                    mf.mytap(this.jubing,878, 490);//点击录入字符界面的确定
                    mf.mydelay(6000, 8000);
                    WriteLog.WriteLogFile(this.mnqName, "点击确定 --保存姓名  " + this.jubing);
                    mf.mytap(this.jubing,483, 379); //点击确定 --保存姓名
                    mf.mydelay(5000, 6000);
                    mf.mytap(this.jubing, 483, 379); //点击确定 --保存姓名
                    mf.mydelay(5000, 6000);
                    mf.mytap(this.jubing, 483, 379); //点击确定 --保存姓名
                    mf.mydelay(5000, 6000);
                    WriteLog.WriteLogFile(this.mnqName, "录入姓名完毕" +suijichar.ToString()+",break");
                    mf.mydelay(200, 300);
                    long kstime1 = mf.GetTime();
                    while (true) {
                        mf.myqudianqusezuobiao(this.jubing, 0xefefef, "0|-3|0x9a9a9a,-3|-3|0xf9f9f9,-6|-3|0xd5d5d5,-6|3|0x595959,-1|3|0x959595,-1|-7|0x424242,3|-4|0x6e6e6e,6|0|0xa4a4a4", 90, 460, 360, 490, 390, out ox, out oy);
                        if (ox != -1 && oy != -1)
                        {
                            mf.mydelay(2000, 3000);
                            mf.mytap(this.jubing, ox, oy);
                            mf.mydelay(2000, 3000);
                        }
                        long jstime1 = mf.GetTime();
                        if (ox == -1 && oy == -1 && ((jstime1 - kstime1) > 20 * 1000))
                        {
                            break;
                        }
                        if (((jstime1 - kstime1) > 1 * 60 * 1000))
                        {
                            abc = false;
                            break;
                        }
                    }
                    break;
                }
                long jstime = mf.GetTime();
                if ((ox == -1 && (jstime - kstime) > fz * 60 * 1000))
                {
                    abc = false;
                    break;
                }
            }
            if (!abc)
            {
                WriteLog.WriteLogFile(this.mnqName, "录入姓名失败");
            }
            return abc;
        }
        /// <summary>
        /// 启动游戏
        /// </summary>
        /// <param name="index"></param>
        /// <param name="name"></param>
        public void qidong(int index, string name)
        {
            WriteLog.WriteLogFile("", index + "----" + name + "，thread:" + Thread.CurrentThread.ManagedThreadId);
            MyLdcmd.getLdCmd().StartApp(index, name);
        }
        public void guanbi(int index, string name)
        {
            MyLdcmd.getLdCmd().StopApp(index, name);
        }
        /// <summary>
        /// 已启动判断
        /// </summary>
        /// <returns></returns>
        public Boolean yiqidong()
        {
            string a=mf.myqudianquse(this.jubing,0x4ed055, "0|11|0x10be1b,-15|12|0x00be0c,-16|-13|0x02ce0f,-9|-4|0xffffff,10|-2|0xffffff,19|6|0xffffff,19|11|0xffffff,21|-8|0x00cb0d", 90, 0, 0, 449, 800);
            
            string[] a1 = a.Split('|');

            string b = mf.myqudianquse(this.jubing, 0xf4c51f, "0|23|0x262305,-13|24|0xf4c51f,28|12|0xf4c51f,22|33|0xf4c51f", 90, 0, 0, 200, 200);

            string[] b1 = a.Split('|');

            int x1 = -1;
            int y1 = -1;
            mf.myGetClientRect(jubing, out x1, out y1);

            if (int.Parse(a1[0]) != -1 || int.Parse(b1[0]) != -1||x1<= 450)
            {
                WriteLog.WriteLogFile(this.mnqName,"游戏启动不成功，界面有微信图标");
                return false;
            }
            return true;
        }

        public Boolean panduanjiemian(string jiemian) {
            Boolean tmp = false;
            int x = -1;
            int y = -1;
            int kstime = mf.GetTime();
            if ("主界面".Equals(jiemian)) {
                while (true)
                {
                    mf.myqudianqusezuobiao(this.jubing,0xffffff, "60|-1|0xffffff,57|35|0x1e9dd2,530|211|0x323232,504|222|0xeff0ef,300|130|0xf7ebce,347|48|0x2b110a,269|16|0x7b5455,282|116|0x547279", 90, 10, 30, 600, 300, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        mf.mydelay(10, 80);
                        tmp = true;
                        break;
                    }
                    int jstime = mf.GetTime();
                    if (x == -1 && y == -1 && (jstime - kstime) > 24000) {
                        break;
                    }
                    guanbi_all();
                }
            }
            return tmp;
        }

        public void guanbi_all() {
            int x = -1;
            int y = -1;
            mf.myqudianqusezuobiao(this.jubing, 0xc3c3c3, "-4|-5|0xc6c3c6,6|-6|0xc6c3c6,6|-2|0x555455,8|5|0xb2afb2,1|6|0x656665,-7|6|0xc6c7c6,-7|0|0x5a595a,-16|0|0x5a595a", 90, 0, 0, 959, 539, out x, out y);
            if (x != -1 && y != -1)
            {
                mf.mydelay(100, 300);
                mf.mytap(this.jubing, x, y);
                WriteLog.WriteLogFile(this.mnqName, "放弃战斗后--以活动公告界面关闭为例，-只取的右上角的X号");
                mf.mydelay(200, 500);
            }
            mf.myqudianqusezuobiao(this.jubing, 0x706d5f, "0|-4|0x232421,-8|-4|0x736f5f,-9|1|0x484335,-9|4|0x292725,-3|6|0x6c6a5c,4|6|0x262524,5|2|0x2e2c26,12|2|0x252322", 90, 460, 470, 500, 500, out x, out y);
            if (x != -1 && y != -1)
            {
                mf.mydelay(100, 300);
                mf.mytap(this.jubing, x, y);
                WriteLog.WriteLogFile(this.mnqName, "放弃战斗后--界面下方单独的一个对号,点击跳过");
                mf.mydelay(200, 500);
            }
            mf.myqudianqusezuobiao(this.jubing, 0x313031, "0|-9|0xf0f0f0,-6|-9|0x313031,-6|-3|0xf1f0f1,-11|1|0xf7fbf7,-11|7|0x313031,-8|9|0x313031,-4|9|0xf8f9f8,-2|13|0x333633", 90, 20, 15, 40, 45, out x, out y);
            if (x != -1 && y != -1)
            {
                mf.mydelay(100, 300);
                mf.mytap(this.jubing, x, y);
                WriteLog.WriteLogFile(this.mnqName, "放弃战斗后--左上角后退");
                mf.mydelay(200, 500);
            }
        }
    }
}
