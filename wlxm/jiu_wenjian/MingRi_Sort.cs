using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xDM;
using MyUtil;
using LuciferSrcipt;
using System.Threading;
using Newtonsoft.Json.Linq;
namespace fuzhu
{
    public class MingRi_Sort:youxi
    {
        private myDm mf;
        private int dqinx;
        private int jubing;
        private string mnqName;
        private int bangdingjieguo = 0;
        /// <summary>
        /// 跳过动画专用点击位置x
        /// </summary>
        private int tiaoguoyongX = 90;
        /// <summary>
        /// 跳过动画专用点击位置y
        /// </summary>
        private int tiaoguoyongY = 100;

       
        public  MingRi_Sort(xDm mydm, int dqinx,string dizhi)
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
            MyFuncUtil.mylogandxianshi("进入测试" + dqinx);
            int x = -1;
            int y = -1;
            while (true)
            {
                mf.myqudianqusezuobiao(this.jubing, 0xd9c0a4, "0|-8|0x825e4c,-5|-8|0x7d594b,-7|-2|0x704d4a,-9|9|0x3fcfe4,7|9|0x295468,7|-2|0x30211d,7|-15|0x9e4b37", 90, 5, 5, 40, 40, out x, out y);
                if (x != -1 && y != -1)
                {
                    //mf.mydelay(100, 300);
                    //mf.mysuijitap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    //WriteLog.WriteLogFile(this.mnqName, "出现讲解头像-左上角,跳过,点击左下角");
                    //mf.mydelay(200, 500);
                    //出现手的提示 点指向的位置
                    mf.myqudianqusezuobiao(this.jubing, 0xbcc2c4, "2|1|0xe2e5e6,4|3|0xcdcdcf,9|1|0xa5a7a8,9|4|0xb1b0b3,8|5|0xc3c5c6,11|8|0xc8c9cb,11|4|0x929695,7|9|0xb7b9b9", 90, 0, 0, 215, 121, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x - 6, y - 5);
                        MyFuncUtil.mylogandxianshi("4" + dqinx);
                        //WriteLog.WriteLogFile(this.mnqName, "讲解头像出现手的提示,点指向位置");
                        //mf.mydelay(200, 500);
                    }
                    mf.myqudianqusezuobiao(this.jubing, 0xdbe7e9, "4|-5|0xeff3ef,-7|-5|0x32556c,-9|0|0x93a2a5,-14|2|0x647574", 90, 40, 90, 70, 110, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        MyFuncUtil.mylogandxianshi("3" + dqinx);
                        //WriteLog.WriteLogFile(this.mnqName, "讲解头像出现手的提示,点指向位置");
                        //mf.mydelay(200, 500);
                    }
                    mf.myqudianqusezuobiao(this.jubing, 0xf6f6f6, "0|-4|0xfaf8fa,-6|-4|0xc0332c,-6|2|0xbf3c39,8|2|0xd63c31,8|-1|0xc8383c", 90, 135, 60, 165, 85, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        MyFuncUtil.mylogandxianshi("2" + dqinx);
                        //WriteLog.WriteLogFile(this.mnqName, "讲解头像出现手的提示,点指向位置");
                        //mf.mydelay(200, 500);
                    }
                    mf.myqudianqusezuobiao(this.jubing, 0x3f575d, "0|-5|0x0b0c0f,-2|-7|0xbab9bb,-3|-2|0x2e261f,6|-1|0x3f565c,4|5|0x7b8b8f", 90, 70, 40, 90, 65, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        MyFuncUtil.mylogandxianshi("1" + dqinx);
                        //WriteLog.WriteLogFile(this.mnqName, "讲解头像出现手的提示,点指向位置");
                        //mf.mydelay(200, 500);
                    }
                }
            }
        
        }

        public void tiaoguo(string jieduan)
        {
            //情况： 自动 or 跳过
            int x = -1;
            int y = -1;
            if ("前段".Equals(jieduan) || "中段".Equals(jieduan) || "后段".Equals(jieduan))
            {
                mf.myqudianqusezuobiao(this.jubing, 0xf4f4f4, "-6|1|0xcccecd,-18|1|0xfafafa,-26|1|0xafafaf,-28|-1|0xacaead,-28|2|0x818382,-21|2|0xc8cbc7,3|1|0xffffff", 90, 170, 5, 210, 20, out x, out y);
                if (x != -1 && y != -1)
                {
                    //mf.mydelay(100, 300);
                    mf.mytap(this.jubing, x, y);
                    //WriteLog.WriteLogFile(this.mnqName, "发现一个自动或跳过，选跳过");
                    //mf.mydelay(2000, 4000);
                    mf.myqudianqusezuobiao(this.jubing, 0x852d2d, "0|-2|0xffffff,-1|-5|0x6d1619,-5|0|0x7e1e1e,0|4|0x7b2020,7|-1|0x731517,25|-3|0x731010", 90, 120, 60, 190, 110, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        //WriteLog.WriteLogFile(this.mnqName, "是否跳过剧情，选是");
                        //mf.mydelay(200, 500);
                    }
                }

                mf.myqudianqusezuobiao(this.jubing, 0x852d2d, "0|-2|0xffffff,-1|-5|0x6d1619,-5|0|0x7e1e1e,0|4|0x7b2020,7|-1|0x731517,25|-3|0x731010", 90, 120, 60, 190, 110, out x, out y);
                if (x != -1 && y != -1)
                {
                    //mf.mydelay(100, 300);
                    mf.mytap(this.jubing, x, y);
                    //WriteLog.WriteLogFile(this.mnqName, "是否跳过剧情，选是");
                    //mf.mydelay(200, 500);
                }

                

                mf.myqudianqusezuobiao(this.jubing, 0xd9c0a4, "0|-8|0x825e4c,-5|-8|0x7d594b,-7|-2|0x704d4a,-9|9|0x3fcfe4,7|9|0x295468,7|-2|0x30211d,7|-15|0x9e4b37", 90, 5, 5, 40, 40, out x, out y);
                if (x != -1 && y != -1)
                {
                    //mf.mydelay(100, 300);
                    //mf.mysuijitap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    //WriteLog.WriteLogFile(this.mnqName, "出现讲解头像-左上角,跳过,点击左下角");
                    //mf.mydelay(200, 500);
                    //出现手的提示 点指向的位置
                    mf.myqudianqusezuobiao(this.jubing, 0xbcc2c4, "2|1|0xe2e5e6,4|3|0xcdcdcf,9|1|0xa5a7a8,9|4|0xb1b0b3,8|5|0xc3c5c6,11|8|0xc8c9cb,11|4|0x929695,7|9|0xb7b9b9", 90, 0, 0, 215, 121, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x - 6, y - 5);
                        //WriteLog.WriteLogFile(this.mnqName, "讲解头像出现手的提示,点指向位置");
                        //mf.mydelay(200, 500);
                    }
                    mf.myqudianqusezuobiao(this.jubing, 0xdbe7e9, "4|-5|0xeff3ef,-7|-5|0x32556c,-9|0|0x93a2a5,-14|2|0x647574", 90, 40, 90, 70, 110, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x , y );
                        //WriteLog.WriteLogFile(this.mnqName, "讲解头像出现手的提示,点指向位置");
                        //mf.mydelay(200, 500);
                    }
                    mf.myqudianqusezuobiao(this.jubing, 0xf6f6f6, "0|-4|0xfaf8fa,-6|-4|0xc0332c,-6|2|0xbf3c39,8|2|0xd63c31,8|-1|0xc8383c", 90, 135, 60, 165, 85,out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        //WriteLog.WriteLogFile(this.mnqName, "讲解头像出现手的提示,点指向位置");
                        //mf.mydelay(200, 500);
                    }
                    mf.myqudianqusezuobiao(this.jubing,  0x3f575d, "0|-5|0x0b0c0f,-2|-7|0xbab9bb,-3|-2|0x2e261f,6|-1|0x3f565c,4|5|0x7b8b8f", 90,  70, 40, 90, 65, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        //MyFuncUtil.mylogandxianshi("出现了" + dqinx);
                        //WriteLog.WriteLogFile(this.mnqName, "讲解头像出现手的提示,点指向位置");
                        //mf.mydelay(200, 500);
                    }
                    //出现灰色对号的提示 点指向的位置
                    mf.myqudianqusezuobiao(this.jubing, 0xa7a59a, "-2|-1|0x959286,3|-2|0xdeded4,0|-4|0x3c3b3b,-2|-4|0x343333", 90, 100, 100, 115, 115, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        //WriteLog.WriteLogFile(this.mnqName, "讲解头像出现对号的提示,点指向位置");
                        //mf.mydelay(200, 500);
                    }
                    //出现开始行动的提示 点指向的位置
                    mf.myqudianqusezuobiao(this.jubing,0x008ac5, "-7|0|0x297292,-12|2|0x0083b9,-6|2|0xc4cccf,5|3|0xedfbfc", 90, 180, 100, 210, 120, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        //WriteLog.WriteLogFile(this.mnqName, "讲解头像出现开始行动的提示,第一次编队战斗");
                        //mf.mydelay(200, 500);
                    }
                    mf.myqudianqusezuobiao(this.jubing, 0x4a0800, "0|-6|0x4a0a01,-5|0|0x621700,1|10|0xc2a59a,-8|12|0x973000,-1|14|0x6d1d00", 90, 170, 75, 195, 110, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        //WriteLog.WriteLogFile(this.mnqName, "讲解头像出现开始行动的提示,第一次编队战斗");
                        //mf.mydelay(200, 500);
                        long ks = MyFuncUtil.GetTimestamp();
                        while (true)
                        {
                            mf.mysuijitap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                            mf.myqudianqusezuobiao(this.jubing, 0xf4d2d3, "-2|-1|0x4d6622,4|-1|0x2b4906,2|3|0xfae4e1,2|-8|0x424c6a,-5|-10|0x69718a", 90,  5, 5, 40, 40, out x, out y);
                            if (x != -1 && y != -1)
                            {
                                break;
                            }
                            long js = MyFuncUtil.GetTimestamp();
                            if (js - ks > 10000)
                            {
                                break;
                            }
                        }
                    }
                }
                mf.myqudianqusezuobiao(this.jubing, 0xd9c0a4, "0|-8|0x825e4c,-5|-8|0x7d594b,-7|-2|0x704d4a,-9|9|0x3fcfe4,7|9|0x295468,7|-2|0x30211d,7|-15|0x9e4b37", 90, 5, 5, 40, 40, out x, out y);
                if (x != -1 && y != -1)
                {
                    //mf.mydelay(100, 300);
                    mf.mysuijitap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    //WriteLog.WriteLogFile(this.mnqName, "出现讲解头像-左上角,跳过,点击左下角");
                    //mf.mydelay(200, 500);
                }
                mf.myqudianqusezuobiao(this.jubing, 0xf7e7ce, "0|-5|0x815747,-3|-3|0x735844,3|0|0x80a7a8,-8|0|0x635553,-8|-15|0x666565,9|-13|0xc1ad9d", 90, 15, 75, 45, 110, out x, out y);
                if (x != -1 && y != -1)
                {
                    //mf.mydelay(100, 300);
                    mf.mysuijitap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    //WriteLog.WriteLogFile(this.mnqName, "出现讲解头像左下角,跳过,点击左下角");
                    //mf.mydelay(200, 500);
                }

                mf.myqudianqusezuobiao(this.jubing, 0xcbcacc, "-3|0|0xdcdedc,2|1|0xf3eff3,7|0|0xffffff,4|1|0xbcbcbc,3|-1|0x0f0f13,-1|-2|0x626264", 90, 190, 0, 210, 20, out x, out y);
                if (x != -1 && y != -1)
                {
                    //mf.mydelay(100, 300);
                    mf.mytap(this.jubing, x, y);
                    //WriteLog.WriteLogFile(this.mnqName, "发现一个跳过，选跳过");
                    //mf.mydelay(200, 500);
                    //mf.mydelay(2000, 5000);
                    //mf.mytap(this.jubing, 635, 381);//选择是 
                    //mf.mydelay(2000, 5000);                    
                }
            }
            if ("中段".Equals(jieduan) || "后段".Equals(jieduan))
            {
                
                mf.myqudianqusezuobiao(this.jubing, 0xf9f9f9, "1|-4|0xe4e3e3,11|-4|0xe5e4e4,11|2|0xcbcdc9,13|8|0xd0d0d0,13|15|0xf0f0f0,2|15|0xe2e3e2,2|10|0xf7fbf7", 90, 10, 5, 35, 40, out x, out y);
                if (x != -1 && y != -1)
                {
                    //mf.mydelay(100, 300);
                    //mf.mysuijitap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    //WriteLog.WriteLogFile(this.mnqName, "出现PTRS头像-左上角");
                    //mf.mydelay(200, 500);
                    //出现手的提示 点指向的位置
                    mf.myqudianqusezuobiao(this.jubing, 0xe8e4e7, "-5|0|0x888888,-11|0|0x3f3e3f,-12|-7|0xb7474a,-21|-7|0xebebeb,-21|1|0xebebeb,-14|8|0xffffff,0|8|0xffffff,15|0|0xf1d524", 90, 120, 90, 180, 121, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        //WriteLog.WriteLogFile(this.mnqName, "PTRS头像出现手的提示,点指向位置,点击第一次寻访");
                        //mf.mydelay(200, 500);
                    }
                    mf.myqudianqusezuobiao(this.jubing, 0xffffff, "0|-4|0xffffff,0|5|0xeaeaea,8|5|0xf6f6f6,12|-11|0xffffff,-13|-7|0xffffff,17|23|0xf8f8f8,21|26|0xe6e3e6,22|24|0xc3c3c3", 90, 70, 15, 125, 75, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        //WriteLog.WriteLogFile(this.mnqName, "PTRS头像出现手的提示,点指向位置,点击+号");
                        //mf.mydelay(200, 500);
                    }
                    mf.myqudianqusezuobiao(this.jubing, 0xd8d8d8, "5|-2|0xb2b0b1,5|3|0xd9d9d9,9|3|0xa2a0a2,10|6|0x8b8b8b,7|6|0xd1d1d1,4|7|0xa3a5a3,3|4|0x494546", 90, 0, 0, 215, 121, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x-10, y-10);
                        //WriteLog.WriteLogFile(this.mnqName, "PTRS头像出现手的提示,点指向位置,单纯的手");
                        //mf.mydelay(200, 500);
                    }
                    //出现对号的提示 点指向的位置
                    mf.myqudianqusezuobiao(this.jubing, 0x0175a5, "-7|0|0x0075a5,-10|-5|0x0075a5,-9|-9|0xffffff,0|-9|0xffffff,8|-4|0x0075a5,6|-1|0x0075a5", 90, 175, 90, 215, 121, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        //WriteLog.WriteLogFile(this.mnqName, "PTRS头像出现对号的提示,第一次确认编队");
                        //mf.mydelay(200, 500);
                    }
                    //选地图标志
                    mf.myqudianqusezuobiao(this.jubing,0x456e86, "-5|-6|0x6493ac,4|-6|0x5986a0,4|-14|0x7295a5,-8|-15|0x699cb3,-1|17|0xefefef,8|17|0xdedfe2", 90, 50, 35, 85, 85, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        //WriteLog.WriteLogFile(this.mnqName, "PTRS头像出现选地图");
                        //mf.mydelay(200, 500);
                    }
                    //出现开始行动的提示 点指向的位置
                    mf.myqudianqusezuobiao(this.jubing, 0xe1e9ec, "-3|0|0x4e6b7e,-11|0|0x0073ad,-11|-4|0x0096d8,0|-4|0x0099dc,2|-2|0x2990c2,3|1|0x076d9e", 90, 180, 100, 210, 121, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        //WriteLog.WriteLogFile(this.mnqName, "PTRS头像出现开始行动的提示,第一次编队战斗");
                        //mf.mydelay(200, 500);
                    }
                    //出现开始行动的提示 点指向的位置
                    mf.myqudianqusezuobiao(this.jubing,0x804b44, "0|-6|0x5a1d15,-7|-6|0x7b2200,-7|4|0xfef8fa,4|4|0xdacac6", 90, 170, 70, 195, 100, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        //WriteLog.WriteLogFile(this.mnqName, "PTRS头像出现开始行动的提示,第一次编队战斗");
                        //mf.mydelay(200, 500);
                    }
                }
                mf.myqudianqusezuobiao(this.jubing, 0xf9f9f9, "1|-4|0xe4e3e3,11|-4|0xe5e4e4,11|2|0xcbcdc9,13|8|0xd0d0d0,13|15|0xf0f0f0,2|15|0xe2e3e2,2|10|0xf7fbf7", 90, 10, 5, 35, 40, out x, out y);
                if (x != -1 && y != -1)
                {
                    //mf.mydelay(100, 300);
                    mf.mysuijitap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    //WriteLog.WriteLogFile(this.mnqName, "出现PTRS头像-左上角");
                    //mf.mydelay(200, 500);
                }

                mf.myqudianqusezuobiao(this.jubing, 0x7e807f, "0|-2|0xececec,0|-3|0xfdfdfd,-3|0|0xacacad,-2|1|0xbdbebe,2|1|0xe3e3e3,3|0|0xc6c7c7", 90, 195, 0, 215, 15, out x, out y);
                if (x != -1 && y != -1)
                {
                    //mf.mydelay(100, 300);
                    mf.mytap(this.jubing, x, y);
                    //WriteLog.WriteLogFile(this.mnqName, "第一次寻访,出现skip");
                    //mf.mydelay(2000, 5000);
                    //mf.mydelay(6000, 7000);
                    //mf.mytap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    //mf.mydelay(100, 300);
                    long ks = MyFuncUtil.GetTimestamp();
                    while (true)
                    {
                        mf.mysuijitap(this.jubing,tiaoguoyongX, tiaoguoyongY);
                        mf.myqudianqusezuobiao(this.jubing, 0xd9c0a4, "0|-8|0x825e4c,-5|-8|0x7d594b,-7|-2|0x704d4a,-9|9|0x3fcfe4,7|9|0x295468,7|-2|0x30211d,7|-15|0x9e4b37", 90, 5, 5, 40, 40, out x, out y);
                        if (x != -1 && y != -1)
                        {
                            break;
                        }
                        long js = MyFuncUtil.GetTimestamp();
                        if (js - ks > 10000) {
                            break;
                        }
                    }
                }

                

                mf.myqudianqusezuobiao(this.jubing, 0xb5b2b5, "-1|2|0xffffff,0|8|0xd6d4d6,-7|8|0xfefefe,-7|1|0xf0f2f0,-7|-12|0xfdfdfd,3|-12|0xfdfdfd", 90, 15, 75, 40, 115, out x, out y);
                if (x != -1 && y != -1)
                {
                    //mf.mydelay(100, 300);
                    //mf.mytap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    //WriteLog.WriteLogFile(this.mnqName, "出现PTRS头像-左下角");
                    //mf.mydelay(200, 500);
                    //出现手的提示 点指向的位置
                    mf.myqudianqusezuobiao(this.jubing, 0xd8d8d8, "5|-2|0xb2b0b1,5|3|0xd9d9d9,9|3|0xa2a0a2,10|6|0x8b8b8b,7|6|0xd1d1d1,4|7|0xa3a5a3,3|4|0x494546", 90, 0, 0, 215, 121, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x - 8, y - 10);
                        //WriteLog.WriteLogFile(this.mnqName, "PTRS头像出现手的提示,点指向位置,单纯的手");
                        //mf.mydelay(200, 500);
                    }
                    mf.myqudianqusezuobiao(this.jubing, 0x5f5f5f, "-6|0|0xf7f5f7,9|0|0xffffff,10|-3|0xffffff,13|-3|0x867277,-11|2|0x887276,-3|3|0x6e211c", 90, 85, 45, 130, 75, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        //WriteLog.WriteLogFile(this.mnqName, "PTRS头像出现选一号区域标志");
                        //mf.mydelay(200, 500);
                    }
                    mf.myqudianqusezuobiao(this.jubing,0xeeeeee, "0|-8|0xa6a5a6,-2|-4|0xf3f3f3,-3|3|0xdcdbdc,3|3|0xcdcccd", 90, 5, 30, 25, 55, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        //mf.mydelay(100, 300);
                        mf.mytap(this.jubing, x, y);
                        //WriteLog.WriteLogFile(this.mnqName, "PTRS头像出现选一号区域标志");
                        //mf.mydelay(200, 500);
                    }
                }

                mf.myqudianqusezuobiao(this.jubing, 0xb5b2b5, "-1|2|0xffffff,0|8|0xd6d4d6,-7|8|0xfefefe,-7|1|0xf0f2f0,-7|-12|0xfdfdfd,3|-12|0xfdfdfd", 90, 15, 75, 40, 115, out x, out y);
                if (x != -1 && y != -1)
                {
                    //mf.mydelay(100, 300);
                    mf.mytap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    //WriteLog.WriteLogFile(this.mnqName, "出现PTRS头像-左下角");
                    //mf.mydelay(200, 500);
                }
            }
            if ("前段".Equals(jieduan) || "中段".Equals(jieduan) )
            {
                mf.mytap(this.jubing, tiaoguoyongX, tiaoguoyongY);
            }

            if ("后段".Equals(jieduan))
            {

                mf.myqudianqusezuobiao(this.jubing, 0x181c29, "3|-2|0x9a684b,-8|0|0x7b5942,-5|8|0xf7e9de,-5|10|0x39201e,0|8|0x55332e,0|14|0xf4e2cb,-1|16|0xefdfc6", 90, 5, 5, 35, 35, out x, out y);
                if (x != -1 && y != -1)
                {
                    //mf.mydelay(100, 300);
                    mf.mysuijitap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    //WriteLog.WriteLogFile(this.mnqName, "出现战斗时讲解头像-左上角,跳过,点击左下角");
                    //mf.mydelay(200, 500);
                }

                mf.myqudianqusezuobiao(this.jubing, 0xf4d2d3, "-2|-1|0x4d6622,4|-1|0x2b4906,2|3|0xfae4e1,2|-8|0x424c6a,-5|-10|0x69718a", 90, 5, 5, 40, 40, out x, out y);
                if (x != -1 && y != -1)
                {
                    //mf.mydelay(100, 300);
                    mf.mysuijitap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    //WriteLog.WriteLogFile(this.mnqName, "出现战斗时讲解头像-左上角,跳过,点击左下角 -新头像");
                    //mf.mydelay(200, 500);
                }

                /*mf.myqudianqusezuobiao(this.jubing, 0xc1bebe, "-9|0|0xc0bebe,-20|0|0xc0bebe,-20|-4|0xc1bfbe,-31|4|0xc1bfbf,-38|9|0xbebcbb,-50|7|0xc2c0bf,-197|-238|0xfffeff,32|0|0xb6b2b1", 90, 0, 0, 959, 539, out x, out y);
                if (x != -1 && y != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    WriteLog.WriteLogFile(this.mnqName, "任务失败,点击画面已继续");
                    mf.mydelay(200, 500);
                }

                mf.myqudianqusezuobiao(this.jubing, 0xffffff, "-6|0|0xffffff,-15|0|0xffffff,-21|-4|0xffffff,-35|-3|0xffffff,-44|0|0xfefefe,-44|-8|0xfcfcfc,-29|-7|0xe9e9e8", 90, 0, 90, 65, 115, out x, out y);
                if (x != -1 && y != -1)
                {
                    //mf.mydelay(100, 300);
                    mf.mytap(this.jubing, tiaoguoyongX, tiaoguoyongY);
                    //WriteLog.WriteLogFile(this.mnqName, "行动结束,点击继续");
                    //mf.mydelay(200, 500);
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
                }*/
            }
            
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
            WriteLog.WriteLogFile(this.mnqName, "进入到主线任务");
            bool tmp = false;
            var kstime = mf.GetTime();
            var jieduan = "前段";
            while (true) {
                
                zhuxianLinShi();
                var jstime = mf.GetTime();
                if ((jstime - kstime) > 1000 * 60 * 3) {
                    jieduan = "中段";
                }
                if ((jstime - kstime) > 1000 * 60 * 6)
                {
                    jieduan = "后段";
                }
                tiaoguo(jieduan);
                if ((jstime - kstime) > 1000 * 60 * 6) {
                    tmp = zhuxian_break();
                    if (tmp)
                    {
                        WriteLog.WriteLogFile(this.mnqName, "主线任务运行时间" + MyFuncUtil.SecondToHour(jstime - kstime) + "到达break条件,break");
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
            mf.myqudianqusezuobiao(this.jubing, 0xd9c0a4, "0|-8|0x825e4c,-5|-8|0x7d594b,-7|-2|0x704d4a,-9|9|0x3fcfe4,7|9|0x295468,7|-2|0x30211d,7|-15|0x9e4b37", 90, 5, 5, 40, 40, out x, out y);
            if (x != -1 && y != -1)
            {
                int x1 = -1;
                int y1 = -1;

                mf.myqudianqusezuobiao(this.jubing, 0xffa200, "0|2|0xffa200,0|5|0xf7dfce,-6|3|0x7a7d7a,-6|-3|0x966712,0|-5|0xbcb6b8,-7|-3|0xf39b00", 90, 160, 90, 200, 121, out x1, out y1);
                if (x1 != -1 && y1 != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mydrag(this.jubing, x1, y1, 98, 72);
                    mf.delay(2000);
                    mf.myMove(this.jubing, 98, 70);
                    mf.delay(2000);
                    mf.mydrag(this.jubing, 98,72, 140, 72);
                    mf.delay(2000);
                    WriteLog.WriteLogFile(this.mnqName, "出现讲解头像同时需要拖拽到指定位置-第一次" + x1 + " " + y1);
                    mf.mydelay(200, 500);
                }

                mf.myqudianqusezuobiao(this.jubing, 0x696a73, "-1|-5|0xffa200,2|-3|0xffb83e,4|-1|0xaeb8bd,-31|-37|0x890405,-31|-32|0x8e0506,-24|-32|0x920405", 90,  60, 30, 105, 80, out x1, out y1);
                if (x1 != -1 && y1 != -1)
                {
                    mf.mydelay(100, 300);
                    mf.myMove(this.jubing, 98, 70);
                    mf.delay(2000);
                    mf.mydrag(this.jubing, 98, 72, 140, 72);
                    mf.delay(2000);
                    WriteLog.WriteLogFile(this.mnqName, "出现讲解头像同时需要拖拽到指定位置-第一次（二次拖）" + x1 + " " + y1);
                    mf.mydelay(200, 500);
                }

                mf.myqudianqusezuobiao(this.jubing, 0xffa200, "0|-4|0xcab5b2,-4|-4|0xde922b,-4|0|0x370617,-2|5|0x24221f,5|5|0x272624,4|3|0x6e4455", 90, 190, 90, 211, 121, out x1, out y1);
                if (x1 != -1 && y1 != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mydrag(this.jubing, x1, y1, 115, 55);
                    mf.delay(2000);
                    mf.myMove(this.jubing,115,56);
                    mf.delay(2000);
                    mf.mydrag(this.jubing, 115, 56, 145, 56);
                    mf.delay(2000);
                    WriteLog.WriteLogFile(this.mnqName, "出现讲解头像同时需要拖拽到指定位置-第二次");
                    mf.mydelay(200, 500);
                }
                mf.myqudianqusezuobiao(this.jubing,0xffa200, "-3|6|0x8c596b,5|6|0x825867,2|-8|0x8e707f,-3|-8|0x917c8d,-35|-9|0xf43a3f,-39|-6|0xeb363b", 90, 70, 35, 125, 65, out x1, out y1);
                if (x1 != -1 && y1 != -1)
                {
                    mf.mydelay(100, 300);                   
                    mf.myMove(this.jubing, 115, 56);
                    mf.delay(2000);
                    mf.mydrag(this.jubing, 115, 56, 145, 56);
                    mf.delay(2000);
                    WriteLog.WriteLogFile(this.mnqName, "出现讲解头像同时需要拖拽到指定位置（二次拖）-第二次");
                    mf.mydelay(200, 500);
                }
            }
        }

        private bool zhuxian_break()
        {
            int x = -1;
            int y = -1;
            mf.myqudianqusezuobiao(this.jubing, 0x8c8e8c, "-2|1|0x343841,-4|2|0x8c8e8c,-4|5|0x383c46,0|3|0x383d47,-5|6|0x373b44,185|1|0xffffff,189|1|0xffffff,170|-2|0xfcfcfc", 90, 5, 0, 210, 20, out x, out y);
            if (x != -1 && y != -1)
            {
                mf.mydelay(100, 300);
                mf.mytap(this.jubing, x, y);
                //WriteLog.WriteLogFile(this.mnqName, "进入到战斗场面，选放弃战斗");
                //mf.mydelay(200, 500);
                mf.mydelay(2000, 3000);
                mf.mytap(this.jubing, 716, 428);//选择放弃行动 
                mf.mydelay(2000, 3000);
                mf.myqudianqusezuobiao(this.jubing, 0x8c3a3a, "-8|0|0x852f32,-8|5|0x7c1d1d,6|4|0x750f11,-7|-1|0xe0cccc,3|1|0xc89fa1,6|1|0xaf7375", 90, 145, 85, 175, 110, out x, out y);
                if (x != -1 && y != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this.jubing, x, y);
                    WriteLog.WriteLogFile(this.mnqName, "选放弃战斗");
                    mf.mydelay(2000, 5000);
                    mf.mysuijitap(this.jubing, tiaoguoyongX, tiaoguoyongY);//任务失败,点击画面已继续
                    mf.mydelay(1000, 3000);
                    mf.mysuijitap(this.jubing, 162, 96);//任务失败,点击画面已继续
                    mf.mydelay(1000, 3000);
                    mf.mysuijitap(this.jubing, 200, 100);//任务失败,点击画面已继续
                    mf.mydelay(1000, 3000);                
                }
                int kstime = mf.GetTime(); 
                //mf.mytap(this.jubing, 8, 6);//回到主界面
                //mf.mydelay(1000, 3000);
                while (true) {
                    guanbi_all();
                    mf.mysuijitap(this.jubing, 200, 100);//任务失败,点击画面已继续
                    if (panduanjiemian("主界面")){
                        WriteLog.WriteLogFile(this.mnqName, "主线任务退出");
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
                mf.mytap(this.jubing, 33, 7);
                WriteLog.WriteLogFile(this.mnqName, "主界面进入,点击邮件区");
                mf.mydelay(6200, 7500);
            }
            mf.myqudianqusezuobiao(this.jubing, 0x2f90be, "-4|0|0x1079a9,-3|-3|0x2389b8,8|-3|0x157faa,8|0|0x1d8cba,16|0|0x3394be,19|-3|0x2288b7", 90, 170, 95, 210, 120, out x1, out y1);
            if (x1 != -1 && y1 != -1)
            {
                mf.mydelay(100, 300);
                mf.mytap(this.jubing, x1, y1);
                WriteLog.WriteLogFile(this.mnqName, "开具领取邮件-领取所有邮件");
                mf.mydelay(5200, 6500);
                mf.mytap(this.jubing, 108, 109);
                mf.mydelay(4200, 5500);                
                guanbi_all();//回到主界面
                mf.mydelay(6200, 8500);
            }
            if (panduanjiemian("主界面"))
            {
                WriteLog.WriteLogFile(this.mnqName, "准备领取累计签到的600");
                mf.mydelay(100, 300);
                mf.mytap(this.jubing, 16, 19);
                mf.mydelay(3000, 6000);                
                mf.mytap(this.jubing, 54, 96);
                mf.mydelay(3000, 6000);
                mf.mytap(this.jubing, 107, 109);
                mf.mydelay(1000, 3000);
                guanbi_all();
                mf.mydelay(1000, 3000);
                guanbi_all();
            }
        }
        public void shouci_xunfang() {
            if (panduanjiemian("主界面"))
            {
                mf.mydelay(100, 300);
                mf.mytap(this.jubing, 200, 88);
                WriteLog.WriteLogFile(this.mnqName, "主界面进入寻访区");
                mf.mydelay(3200, 6500);
                mf.mytap(this.jubing, 207, 66);
                //mf.mydelay(1200,3500);
                //mf.mytap(this.jubing, 207, 66);
                WriteLog.WriteLogFile(this.mnqName, "寻访区进入600区");
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
                        WriteLog.WriteLogFile(this.mnqName,"寻访退出失败");
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
            mf.myqudianqusezuobiao(this.jubing, 0x7e807f, "0|-2|0xececec,-3|0|0xadacad,4|0|0x2b2b2d,2|1|0xe3e3e3,-1|2|0x252728", 90,  195, 0, 214, 15, out x1, out y1);
            if (x1 != -1 && y1 != -1) {
                //mf.mydelay(100, 300);
                mf.mytap(this.jubing,x1, y1);
                //WriteLog.WriteLogFile(this.mnqName, "寻访后出现skip");                
                int kstime = mf.GetTime();
                int x21 = -1;
                int y21 = -1;
                while (true)
                {
                    mf.mysuijitap(this.jubing, tiaoguoyongX, tiaoguoyongY);//任务失败,点击画面已继续
                    mf.myqudianqusezuobiao(this.jubing, 0xe3e3e3, "0|-4|0xe5e5e5,-10|-4|0xcbcbcb,-10|-1|0x4f4f4f,2|1|0xe6e2e6,12|1|0xd8d8d8,13|-1|0xdcdcdc", 90, 135, 95, 175, 120, out x21, out y21);
                    if (x21 != -1 && y21 != -1)
                    {
                        break;
                    }
                    int jstime = mf.GetTime();
                    if ((jstime - kstime) > 20000 )
                    {
                        //WriteLog.WriteLogFile(this.mnqName, "放弃战斗后,回到主界面失败");
                        break;
                    }
                }
            }
            int x2 = -1;
            int y2 = -1;
            mf.myqudianqusezuobiao(this.jubing, 0xe3e3e3, "0|-4|0xe5e5e5,-10|-4|0xcbcbcb,-10|-1|0x4f4f4f,2|1|0xe6e2e6,12|1|0xd8d8d8,13|-1|0xdcdcdc", 90, 135, 95, 175, 120, out x2, out y2);
            if (x2 != -1 && y2 != -1)
            {
                //mf.mydelay(100, 300);
                mf.mytap(this.jubing,x2, y2);
                //WriteLog.WriteLogFile(this.mnqName, "花费600寻访一次");
                //mf.mydelay(200, 500);
            }
            int x3 = -1;
            int y3 = -1;
            mf.myqudianqusezuobiao(this.jubing, 0xa56c6e, "0|-4|0x781115,-10|-4|0x842a29,-11|-1|0x7b1c1b,0|1|0xefe3e3,8|1|0xdfc9c9,10|1|0x740e11", 90, 140, 75, 175, 95, out x3, out y3);
            if (x3 != -1 && y3 != -1)
            {
                //mf.mydelay(100, 300);
                mf.mytap(this.jubing,x3, y3);
                //WriteLog.WriteLogFile(this.mnqName, "花费600寻访一次，是否确认，是");
                //mf.mydelay(200, 500);
            }
            mf.myqudianqusezuobiao(this.jubing, 0xaeafad, "-5|0|0xffffff,7|1|0xf0f0f0,9|1|0xbabbba,110|1|0xb17f7f,112|0|0x7a1a1a,122|0|0xcba5a5", 90, 35, 75, 175, 90, out x3, out y3);
            if (x3 != -1 && y3 != -1)
            {
                mf.mydelay(100, 300);
                mf.mytap(this.jubing,x3, y3);
                //WriteLog.WriteLogFile(this.mnqName, "出现花费能源石界面,点取消,停止寻访");
                mf.mydelay(1000, 3000);
                mf.mytap(this.jubing, x3, y3);
                mf.mydelay(1000, 3000);
                guanbi_all();//过5秒 返回上一界面
                mf.mydelay(1000, 3000);
                tmp = true;
            }
            
            int x11 = -1;
            int y11 = -1;
            if (x1 == -1 && y1 == -1 && x2 == -1 && y2 == -1 && x3 == -1 && y3 == -1) {
                mf.myqudianqusezuobiao(this.jubing, 0x000000, "13|1|0x000000,45|3|0x000000,69|3|0x000000,99|1|0x000000,117|1|0x000000", 90, 20, 110, 160, 120, out x11, out y11);
                if (x11 != -1 && y11 != -11)
                {
                    //mf.mydelay(1000, 3000);
                    mf.mysuijitap(this.jubing, tiaoguoyongX, tiaoguoyongY);//过5秒 点击空白处跳过动画
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
                mf.mytap(this.jubing, 168, 57);
                WriteLog.WriteLogFile(this.mnqName, "主界面进入干员区-准备截图");
                mf.mydelay(4200, 7500);
                mf.mytap(this.jubing, 7, 6);
                mf.mydelay(4200, 7500);
                mf.mytap(this.jubing, 168, 57);
                mf.mydelay(4200, 7500);
                int x = -1;
                int y = -1;
                mf.myqudianqusezuobiao(this.jubing, 0x1d4d62, "2|0|0x0c84ba,-2|0|0x1075a2,13|0|0x6d6e6d,18|0|0x757675,27|0|0x747574,42|0|0x6a6a6a", 90, 125, 0, 185, 15, out x, out y);
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
            //int ox1 = -1;
            //int oy1 = -1;
            while (true)
            {
                string result = "-1|-1";
                result = mf.myqudianquse(this.jubing, 0x493d00, "0|-4|0xffd700,3|-2|0xffd700,-4|0|0xf1cb00,-1|3|0xf5ce00,3|2|0xecc700,-2|5|0x5b4d00,4|4|0x5e4f00,4|-4|0x534600", 90, 100, 110, 115, 121);
                string[] a1 = result.Split('|');
                if (int.Parse(a1[0]) != -1)
                {
                    int x = int.Parse(a1[0]);
                    int y = int.Parse(a1[1]);
                    mf.mytap(this.jubing,x,y);
                    WriteLog.WriteLogFile(this.mnqName, "找到start坐标" + x + " " + y + " " + this.jubing + "，thread:" + Thread.CurrentThread.ManagedThreadId);
                    mf.mydelay(200,300);
                }
                //直接点击登录吧
                mf.mytap(this.jubing, 108, 114);
                mf.mydelay(1000, 3000);
                mf.myqudianqusezuobiao(jubing, 0xcecece, "0|-3|0x525252,-6|-3|0x525252,-6|3|0x525352,-11|0|0x525252,-124|28|0xebebeb,-133|28|0xd1d2d1,-140|29|0xffffff,40|29|0x717271", 90, 0, 80, 190, 121, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    WriteLog.WriteLogFile(this.mnqName, "发现游客坐标-跳出登录环节" + " " + this.jubing + "，thread:" + Thread.CurrentThread.ManagedThreadId);
                    break;
                }
                mf.myqudianqusezuobiao(this.jubing, 0xb9b8b9, "5|0|0x6f6f6f,5|3|0x525252,2|10|0x3d3e3d,-7|10|0x898989,-7|16|0x525352,6|16|0x898989", 90, 95, 85, 112, 102, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    WriteLog.WriteLogFile(this.mnqName, "发现直接登录-跳出登录环节" + " " + this.jubing + "，thread:" + Thread.CurrentThread.ManagedThreadId);
                    break;
                }
                /*mf.myqudianqusezuobiao(this.jubing,0x131313, "-4|0|0xebeceb,-4|-3|0x201f20,3|1|0x121212,8|1|0xffffff,2|2|0x101010,7|-4|0x1a191a,-27|-110|0xa3a2a3,-15|-105|0x868686", 90, 0, 0, 959, 539, out ox1, out oy1);
                if (ox1 != -1 && oy1 != -1)
                {
                    WriteLog.WriteLogFile(this.mnqName, "有问题，延迟登录" + " " + this.jubing + "，thread:" + Thread.CurrentThread.ManagedThreadId);
                    mf.mytap(this.jubing, ox1, oy1);
                    mf.mydelay(600000,700000);
                }*/
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
                mf.myqudianqusezuobiao(jubing, 0xcecece, "0|-3|0x525252,-6|-3|0x525252,-6|3|0x525352,-11|0|0x525252,-124|28|0xebebeb,-133|28|0xd1d2d1,-140|29|0xffffff,40|29|0x717271", 90, 0, 80, 190, 121, out ox, out oy);
                if (ox != -1 && oy != -1)
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
                    mf.myqudianqusezuobiao(this.jubing, 0x2c2b2c, "11|0|0xefefef,14|0|0x252525,18|0|0x858483,25|0|0x4b4a4b,35|0|0x313031,41|0|0x201f1a", 90, 60, 100, 110, 105, out oxx, out oxy);
                    if (oxx != -1 && oxy != -1)
                    {
                        WriteLog.WriteLogFile(this.mnqName, "找到同意协议-break  " + this.jubing);
                        break;
                    }
                    mf.myqudianqusezuobiao(this.jubing,0xffffff, "0|-5|0xe9e9e9,-4|-5|0x0e110e,-2|-2|0x1d1d1d,-2|2|0x1b1a1b,3|2|0x1f1d1f,3|-5|0x100c10", 90, 100, 80, 112, 90, out oxx, out oxy);
                    if (oxx != -1 && oxy != -1)
                    {
                        WriteLog.WriteLogFile(this.mnqName, "认证系统错误,跳过录入信息" + this.jubing);
                        mf.mydelay(200, 400);
                        mf.mytap(this.jubing,oxx, oxy);
                        mf.mydelay(2000, 4000);
                        mf.mytap(this.jubing, 107, 85);
                        mf.mydelay(2000, 4000);
                    }
                    mf.myqudianqusezuobiao(this.jubing,0xb9b8b9, "5|0|0x6f6f6f,5|3|0x525252,2|10|0x3d3e3d,-7|10|0x898989,-7|16|0x525352,6|16|0x898989", 90, 95, 85, 112, 102, out oxx, out oxy);
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
                return false;
            }
            WriteLog.WriteLogFile(this.mnqName, "进入到注册环节-点同意协议" + " " + this.jubing);
            kstime = mf.GetTime();
            ox = -1;
            oy = -1;
            while (true)
            {
                mf.myqudianqusezuobiao(this.jubing, 0x2c2b2c, "11|0|0xefefef,14|0|0x252525,18|0|0x858483,25|0|0x4b4a4b,35|0|0x313031,41|0|0x201f1a", 90, 60, 100, 110, 105, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    mf.delay(1000);
                    mf.mytap(this.jubing,ox, oy);
                    WriteLog.WriteLogFile(this.mnqName, "找到同意协议坐标" + ox + " " + oy + " " + this.jubing + " " + bangdingjieguo);
                    mf.mydelay(2000, 3000);
                    mf.mytap(this.jubing, 108, 114);
                    mf.mydelay(2000, 3000);
                }
                mf.myqudianqusezuobiao(this.jubing, 0x5e8799, "-6|-2|0x23576c,7|-2|0x23576c,7|-10|0x757574,1|-10|0x7b796e,-5|-10|0x807f7c,-10|-10|0xb8b7b8", 90, 90, 100, 120, 113, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    mf.delay(1000);
                    mf.mytap(this.jubing, ox, oy);
                    WriteLog.WriteLogFile(this.mnqName, "已点击同意," + ox + " " + oy + " " + this.jubing + " " + bangdingjieguo);
                    mf.mydelay(2000, 3000);
                }
                mf.myqudianqusezuobiao(this.jubing, 0x5e8799, "-4|0|0x255e77,5|-1|0x4b778b,5|3|0x256787,0|2|0x266683", 90,95, 100, 120, 120, out ox, out oy);
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
                    mf.myqudianqusezuobiao(this.jubing, 0xeaeaea, "7|0|0x424242,8|-16|0x494749,1|-16|0x4d494d,-4|-16|0x494749,-9|-16|0x9f9e9f,-15|-16|0x777877", 90, 90, 68, 115, 86, out oxx, out oxy);
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
                return abc;
            }
            kstime = mf.GetTime();
            ox = -1;
            oy = -1;
            WriteLog.WriteLogFile(this.mnqName, "进入到注册环节-点输入姓名" + " " + this.jubing);
            while (true)
            {
                mf.myqudianqusezuobiao(this.jubing, 0xeaeaea, "7|0|0x424242,8|-16|0x494749,1|-16|0x4d494d,-4|-16|0x494749,-9|-16|0x9f9e9f,-15|-16|0x777877", 90, 90, 68, 115, 86, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    WriteLog.WriteLogFile(this.mnqName, "找到输入姓名按钮 " + ox + " " + oy);
                    mf.mydelay(3000, 4200);
                    mf.mytap(this.jubing, 107, 86);//先点击确定
                    mf.mydelay(5000, 6200);
                    mf.mytap(this.jubing, 107, 86);//先点击出现的对号提示 确保可以点开输入栏
                    mf.mydelay(3000, 4200);
                    mf.mytap(this.jubing, 91, 70);
                    mf.mydelay(2000, 3000);
                }
                mf.myqudianqusezuobiao(this.jubing,0x131213, "-1|-1|0x1d1d1d,3|-1|0xffffff,2|-2|0x1f1f1f,1|-6|0x110f11,-3|-6|0x120e12,-3|2|0x181618", 90, 80, 0, 110, 90, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    WriteLog.WriteLogFile(this.mnqName, "点确定后出现的提示 " + ox + " " + oy);
                    mf.mydelay(3000, 4200);
                    mf.mytap(this.jubing, ox, oy);
                    mf.mydelay(5000, 6200);
                    mf.mytap(this.jubing, 91, 70);//先点击出现的对号提示 确保可以点开输入栏
                    mf.mydelay(3000, 4200);
                }
                bool a = mf.myGetColor(this.jubing, 15, 109, "ffffff");
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
                return abc;
            }
            kstime = mf.GetTime();
            ox = -1;
            oy = -1;
            WriteLog.WriteLogFile(this.mnqName, "进入到注册环节-逐个录入" + " " + this.jubing);
            while (true)
            {
                mf.myqudianqusezuobiao(this.jubing, 0xffffff, "10|1|0xffffff,36|1|0xffffff,62|1|0xffffff,82|2|0xffffff", 90, 20, 107, 105, 110, out ox, out oy);
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
                    mf.mytap(this.jubing,197, 119);//点击录入字符界面的确定
                    mf.mydelay(6000, 8000);
                    WriteLog.WriteLogFile(this.mnqName, "点击确定 --保存姓名  " + this.jubing);
                    mf.mytap(this.jubing,108, 86); //点击确定 --保存姓名
                    mf.mydelay(5000, 6000);
                    mf.mytap(this.jubing, 108, 86); //点击确定 --保存姓名
                    mf.mydelay(5000, 6000);
                    mf.mytap(this.jubing, 108, 86); //点击确定 --保存姓名
                    mf.mydelay(5000, 6000);
                    WriteLog.WriteLogFile(this.mnqName, "录入姓名完毕" +suijichar.ToString()+",break");
                    mf.mydelay(200, 300);
                    long kstime1 = mf.GetTime();
                    while (true) {
                        mf.myqudianqusezuobiao(this.jubing, 0xd0d0d0, "-2|0|0xe4e4e4,-2|-1|0xeaeaea,1|-1|0xf6f6f6,3|0|0x414141", 90, 100, 80, 115, 90, out ox, out oy);
                        if (ox != -1 && oy != -1)
                        {
                            //WriteLog.WriteLogFile(this.mnqName, "点击注册确定按钮" + this.jubing);
                            mf.mydelay(200, 300);
                            mf.mytap(this.jubing, ox, oy); //点击确定 --保存姓名
                            mf.mydelay(1000, 2000);
                        }
                        mf.myqudianqusezuobiao(this.jubing, 0xf4f4f4, "-6|1|0xcccecd,-18|1|0xfafafa,-26|1|0xafafaf,-28|-1|0xacaead,-28|2|0x818382,-21|2|0xc8cbc7,3|1|0xffffff", 90, 170, 5, 210, 20, out ox, out oy);
                        if (ox != -1 && oy != -1)
                        {
                            WriteLog.WriteLogFile(this.mnqName, "注册完毕,进入到主线任务" + this.jubing);
                            mf.mydelay(200, 300);
                            break;
                        }
                        long jstime1 = mf.GetTime();                        
                        if (ox == -1 && oy == -1 && ((jstime1 - kstime1) > 1 * 60 * 1000))
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
                return abc;
            }
            return abc;
        }
        

        public Boolean panduanjiemian(string jiemian) {
            Boolean tmp = false;
            int x = -1;
            int y = -1;
            int kstime = mf.GetTime();
            if ("主界面".Equals(jiemian)) {
                
                while (true)
                {
                    mf.myqudianqusezuobiao(this.jubing, 0xfbfbfa, "-99|5|0xf7ebce,-103|2|0x7faab0,-101|-7|0xa8b39f,-169|-13|0x91c9e0,-164|-13|0x0097de,-164|-28|0xffffff,-154|-27|0xb1b2ae,-143|-26|0xffffff", 90, 0, 0, 180, 50, out x, out y);
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
            mf.myqudianqusezuobiao(this.jubing, 0xc0bfc0, "0|-4|0x5a595a,-1|-1|0xc5c2c5,-1|1|0xbfbfbf,-4|1|0x5a595a,0|3|0x5a595a,1|1|0xc6c3c6", 90, 200, 0, 214, 20, out x, out y);
            if (x != -1 && y != -1)
            {
                //mf.mydelay(100, 300);
                mf.mytap(this.jubing, x, y);
                //WriteLog.WriteLogFile(this.mnqName, "放弃战斗后--以活动公告界面关闭为例，-只取的右上角的X号");
                //mf.mydelay(200, 500);
            }
            mf.myqudianqusezuobiao(this.jubing, 0xc5c2c5, "-1|1|0xc4c2c4,-2|-1|0xc5c6c5,-2|2|0xb8bbb8,1|2|0xbfc0bf,1|-1|0xb9bdb9,-1|-2|0x5a595a,-3|1|0x5a595a,-1|3|0x5a595a", 90,  190, 0, 214, 25, out x, out y);
            if (x != -1 && y != -1)
            {
                //mf.mydelay(100, 300);
                mf.mytap(this.jubing, x, y);
                //WriteLog.WriteLogFile(this.mnqName, "放弃战斗后--以活动公告界面关闭为例，-只取的右上角的X号");
                //mf.mydelay(200, 500);
            }
            mf.myqudianqusezuobiao(this.jubing, 0x736f64, "0|-4|0x212020,-2|-1|0x777467,-2|2|0x7b7b7b,3|2|0x2c2a2a,5|0|0x41403c,5|-3|0x646157", 90, 100, 100, 120, 120, out x, out y);
            if (x != -1 && y != -1)
            {
                //mf.mydelay(100, 300);
                mf.mytap(this.jubing, x, y);
                //WriteLog.WriteLogFile(this.mnqName, "放弃战斗后--界面下方单独的一个对号,点击跳过");
                //mf.mydelay(200, 500);
            }
            mf.myqudianqusezuobiao(this.jubing,0xa7a59a, "-2|-1|0x959286,1|-1|0xb4b1a6,3|-3|0xd6d6cd,0|1|0x8f8d7e,0|-4|0x3c3b3b",  90, 100, 100, 120, 120, out x, out y);
            if (x != -1 && y != -1)
            {
                //mf.mydelay(100, 300);
                mf.mytap(this.jubing, x, y);
                //WriteLog.WriteLogFile(this.mnqName, "放弃战斗后--界面下方单独的一个对号,点击跳过");
                //mf.mydelay(200, 500);
            }
            mf.myqudianqusezuobiao(this.jubing,0x686558, "-2|0|0x232220,3|-2|0x58564c,1|-4|0x1d1c1c,-2|2|0x232221,3|2|0x242222,2|-6|0x58564d", 90, 95, 95, 120, 120, out x, out y);
            if (x != -1 && y != -1)
            {
                //mf.mydelay(100, 300);
                mf.mytap(this.jubing, x, y);
                //WriteLog.WriteLogFile(this.mnqName, "领取600一个对号,点击跳过");
                //mf.mydelay(200, 500);
            }
            mf.myqudianqusezuobiao(this.jubing, 0x313031, "-2|0|0xe0e4e0,-1|-1|0xe5e6e5,0|-2|0xe4e5e4,-1|1|0x868486,-2|2|0x313031", 90, 0, 0, 15, 15, out x, out y);
            if (x != -1 && y != -1)
            {
                //mf.mydelay(100, 300);
                mf.mytap(this.jubing, x, y);
                //WriteLog.WriteLogFile(this.mnqName, "放弃战斗后--左上角后退");
                //mf.mydelay(200, 500);
            }
            mf.myqudianqusezuobiao(this.jubing,  0x6e6e6e, "-2|0|0xffffff,1|-1|0x7b7a7b,1|1|0xdad9da,4|1|0xffffff,-1|2|0xffffff", 90, 0, 0, 15, 15, out x, out y);
            if (x != -1 && y != -1)
            {
                //mf.mydelay(100, 300);
                mf.mytap(this.jubing, x, y);
                //WriteLog.WriteLogFile(this.mnqName, "邮箱--左上角后退");
                //mf.mydelay(200, 500);
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
                mf.mytap(this.jubing, 8, 7);//点 设置
                mf.mydelay(2000, 5000);
                mf.myqudianqusezuobiao(this.jubing, 0xe3e3e3, "-5|0|0x504f50,3|-2|0xb9b9b9,8|-1|0xa4a4a4", 90, 90, 80, 115, 95, out x, out y);
                if (x != -1 && y != -1)
                {
                    mf.mydelay(100, 300);
                    mf.mytap(this.jubing, x, y);
                    //WriteLog.WriteLogFile(this.mnqName, "发现注销按钮");                    
                    mf.mydelay(2000, 5000);
                    mf.mytap(this.jubing, 142, 86);//确认 点确认
                }
            }
            return res;
        }

        public Boolean chongxindenglu()
        {
            
            return true;
        }
        public string generalBasicDemo(int ind, string path)
        {
            StringBuilder rd = new StringBuilder();
            BaiDuShiTu bd = new BaiDuShiTu();
            JObject rs = bd.GeneralBasic(path);
            var shu = 0;
            var txts = (from obj in (JArray)rs.Root["words_result"]
                        select (string)obj["words"]);
            foreach (var r in txts)
            {
                WriteLog.WriteLogFile(ind + "", r);
                if (r.ToString().IndexOf("凯尔希") > -1)
                {
                    rd.Append("凯尔希");
                    rd.Append("__");
                    shu++;
                }
                if (r.ToString().IndexOf("星熊") > -1)
                {
                    rd.Append("星熊");
                    rd.Append("__");
                    shu++;
                }
                if (r.ToString().IndexOf("银灰") > -1)
                {
                    rd.Append("银灰");
                    rd.Append("__");
                    shu++;
                }
                if (r.ToString().IndexOf("能天使") > -1)
                {
                    rd.Append("能天使");
                    rd.Append("__");
                    shu++;
                }
                if (r.ToString().IndexOf("夜莺") > -1)
                {
                    rd.Append("夜莺");
                    rd.Append("__");
                    shu++;
                }
                if (r.ToString().IndexOf("闪灵") > -1)
                {
                    rd.Append("闪灵");
                    rd.Append("__");
                    shu++;
                }
                if (r.ToString().IndexOf("推进之王") > -1)
                {
                    rd.Append("推进之王");
                    rd.Append("__");
                    shu++;
                }
                if (r.ToString().IndexOf("塞雷娅") > -1)
                {
                    rd.Append("塞雷娅");
                    rd.Append("__");
                    shu++;
                }
                if (r.ToString().IndexOf("艾雅法拉") > -1)
                {
                    rd.Append("艾雅法拉");
                    rd.Append("__");
                    shu++;
                }
                if (r.ToString().IndexOf("安洁莉娜") > -1)
                {
                    rd.Append("安洁莉娜");
                    rd.Append("__");
                    shu++;
                }
                if (r.ToString().IndexOf("伊芙利特") > -1)
                {
                    rd.Append("伊芙利特");
                    rd.Append("__");
                    shu++;
                }
                if (r.ToString().IndexOf("陈") > -1)
                {
                    rd.Append("陈");
                    rd.Append("__");
                    shu++;
                }
                if (r.ToString().IndexOf("鞘中赤红") > -1)
                {
                    rd.Append("鞘中赤红");
                    rd.Append("__");
                    shu++;
                }
            }
            if (shu <= 1)
            {
                return "";
            }
            return rd.ToString();
        }
    }
}
