using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyUtil;
using System.Threading;
using Entity;

namespace xDM
{
    public class myDm : xDm
    {
        //private static readonly object myob = new object();
        private dmsoft mydm = new dmsoft();
        public dmsoft Mydm
        {
            get { return mydm; }
            set { mydm = value; }
        }
        //录入的x y有限制 一拳的限制 532 299 路人 687 386
        private int xianzhi_x = 532;
        private int xianzhi_y = 299;
        public int suijishu1(int min, int max)
        {
            Random rd = new Random();
            return rd.Next(min, max);
        }
        public int mydelay(int min, int max)
        {
            int md = MyFuncUtil.suijishu(min, max);
            //mydm.delay(md);
            Thread.Sleep(md);
            return md;
            //Thread.Sleep(md * 10);
        }

        new public int delay(int m)
        {
            Thread.Sleep(m);
            return 0;
        }
        public int myKeyPressChar(int jubing, string a)
        {
            int res = mydm.IsBind(jubing);
            if (res != 1)
            {
                bindWindow(jubing);
            }
            mydelay(1000, 1200);
            int i = mydm.KeyPressChar(a);
            return i;
            //Thread.Sleep(md * 10);
        }

        /// <summary>
        /// 鼠标左键点击 x y坐标
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void mytap_duokai(int jubing, int x, int y)
        {
            int x1 = MyFuncUtil.suijishu(-2, 2);
            int y1 = MyFuncUtil.suijishu(-2, 2);            
            int res = mydm.IsBind(jubing);
            if (res != 1)
            {
                //res = bindWindow(jubing);
            }
            mydelay(50, 80);
            mydm.MoveTo(x + x1, y + y1);
            mydelay(60, 120);
            mydm.LeftDown();
            mydelay(10, 50);
            mydm.LeftUp();
            mydelay(10, 120);
        }
        /// <summary>
        /// 不受边界的限制
        /// </summary>
        /// <param name="sd"></param>
        /// <param name="sim"></param>
        /// <returns></returns>
        public bool mohuByLeiBool_duokai(SanDian sd, int sim = 90)
        {
            bool tmp = false;
            bool tmp1 = this.jingqueByLeiBool(sd);
            if (tmp1 == true)
            {
                return true;
            }
            int ox = -1, oy = -1;
            myqudianqudanse_duokai(sd.Myanse1, sim, sd.Mx1, sd.My1, sd.Mx1 + 1, sd.My1 + 1, out ox, out oy);
            int rs1 = -1;
            if (ox != -1 && oy != -1)
            {
                rs1 = 1;
            }
            int rs2 = -1;
            if (sd.Mx2 != -1)
            {
                myqudianqudanse_duokai(sd.Myanse2, sim, sd.Mx2, sd.My2, sd.Mx2 + 1, sd.My2 + 1, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    rs2 = 1;
                }
            }
            int rs3 = -1;
            if (sd.Mx3 != -1)
            {
                myqudianqudanse_duokai(sd.Myanse3, sim, sd.Mx3, sd.My3, sd.Mx3 + 1, sd.My3 + 1, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    rs3 = 1;
                }
            }
            if ((rs1 == 1) && (rs2 == 1) && (rs3 == 1))
            {
                return true;
            }
            if ((rs1 == 1) && (rs2 == 1) && (sd.Myanse3 == -1))
            {
                return true;
            }
            if ((rs1 == 1) && (sd.Myanse2 == -1) && (sd.Myanse3 == -1))
            {
                return true;
            }
            return tmp;
        }

        /// <summary>
        /// 取点取单色直接返回坐标无句柄
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="off"></param>
        /// <param name="sim"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        public void myqudianqudanse_duokai(Int32 fir, int sim, int x0, int y0, int x1, int y1, out int ox, out int oy)
        {

            string result = "-1|-1";
            string firstColor = fir.ToString("X");
            double isim = sim * 0.01;
            ox = -1;
            oy = -1;           
            result = mydm.FindColorE(x0, y0, x1, y1, firstColor, isim, 1);
            string[] a1 = result.Split('|');

            if (int.Parse(a1[0]) == -1)
            {
                return;
            }
            if (int.Parse(a1[0]) != -1)
            {
                ox = int.Parse(a1[0]);
                oy = int.Parse(a1[1]);
            }
        }

        public Boolean myGetColorWuJuBing_duokai(int x, int y, string color)
        {
            bool tmp = false;
            String tmpcolor = mydm.GetColor(x, y);
            if (color.ToLower().Equals(tmpcolor.ToLower()))
            {
                tmp = true;
            }
            return tmp;
        }

        public int jingque_duokai(int mx1, int my1, int myanse1, int mx2 = -1, int my2 = -1, int myanse2 = -1, int mx3 = -1, int my3 = -1, int myanse3 = -1)
        {
            string firstColor = myanse1.ToString("X");
            bool rs1 = myGetColorWuJuBing_duokai(mx1, my1, firstColor);
            bool rs2 = false;
            if (mx2 != -1)
            {
                string secColor = myanse2.ToString("X");
                rs2 = myGetColorWuJuBing_duokai(mx2, my2, secColor);
            }
            bool rs3 = false;
            if (mx3 != -1)
            {
                string thrColor = myanse3.ToString("X");
                rs3 = myGetColorWuJuBing_duokai(mx3, my3, thrColor);
            }
            if (rs1 && rs2 && rs3)
            {
                return 1;
            }
            if (rs1 && rs2 && (myanse3 == -1))
            {
                return 1;
            }
            if (rs1 && (myanse2 == -1) && (myanse3 == -1))
            {
                return 1;
            }
            return 0;

        }
        public int mohu_duokai(int mx1, int my1, int myanse1, int mx2 = -1, int my2 = -1, int myanse2 = -1, int mx3 = -1, int my3 = -1, int myanse3 = -1, int sim = 90)
        {
            
            int ox = -1, oy = -1;
            int rs1 = -1;
            rs1 = jingque_duokai(mx1, my1, myanse1, mx2, my2, myanse2, mx3, my3, myanse3);
            if (rs1 == 1)
            {
                return 1;
            }
            myqudianqudanse_duokai(myanse1, sim, mx1, my1, mx1 + 1, my1 + 1, out ox, out oy);
            if (ox != -1 && oy != -1)
            {
                rs1 = 1;
            }
            int rs2 = -1;
            if (mx2 != -1)
            {
                myqudianqudanse_duokai(myanse2, sim, mx2, my2, mx2 + 1, my2 + 1, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    rs2 = 1;
                }
            }
            int rs3 = -1;
            if (mx3 != -1)
            {
                myqudianqudanse_duokai(myanse3, sim, mx3, my3, mx3 + 1, my3 + 1, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    rs3 = 1;
                }
            }
            if ((rs1 == 1) && (rs2 == 1) && (rs3 == 1))
            {
                return 1;
            }
            if ((rs1 == 1) && (rs2 == 1) && (myanse3 == -1))
            {
                return 1;
            }
            if ((rs1 == 1) && (myanse2 == -1) && (myanse3 == -1))
            {
                return 1;
            }
            return 0;
        }
        /// <summary>
        /// 鼠标左键点击 x y坐标
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void mytap(int jubing, int x, int y)
        {
            int x1 = MyFuncUtil.suijishu(-2, 2);
            int y1 = MyFuncUtil.suijishu(-2, 2);
            int res = mydm.IsBind(jubing);
            if (res != 1)
            {
                //res = bindWindow(jubing);
            }
            mydelay(50, 80);
            if ((x1+x < 0) || (y1+y < 0) ||
                (x1+x > xianzhi_x) || (y1+y > xianzhi_y))
            {
                WriteLog.WriteLogFile("", "出边界了.." +x + " " +y);
                return;
            }
            mydm.MoveTo(x+x1, y+y1);
            mydelay(60, 120);
            mydm.LeftDown();
            mydelay(10, 50);
            mydm.LeftUp();
            mydelay(10, 120);
        }

        

        /// <summary>
        /// 鼠标左键点击 x y坐标
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void click(int x, int y,int dlay)
        {
            int x1 = MyFuncUtil.suijishu(-2, 2);
            int y1 = MyFuncUtil.suijishu(-2, 2);            
            mydelay(50, 80);            
            mydm.MoveTo(x + x1, y + y1);
            mydelay(60, 120);
            mydm.LeftDown();
            mydelay(10, 50);
            mydm.LeftUp();
            mydelay(10, dlay);
        }

        /// <summary>
        /// 鼠标按住ctrl 鼠标中间向下滚
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void myroll()
        {
            
                //mydm.KeyDownChar("F5");
                //mydelay(100, 800);
                //mydm.KeyUpChar("F5");
            mydm.KeyPressChar("F5");
           
        }

        /// <summary>
        /// 鼠标左键点击 x y坐标 范围的随机数 上下 10
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void mysuijitap(int jubing, int x, int y)
        {
            int res = mydm.IsBind(jubing);
            if (res != 1)
            {
                //res = bindWindow(jubing);
            }
            mydelay(50, 80);
            int x1 = MyFuncUtil.suijishu(x - 10, x + 10);
            int y1 = MyFuncUtil.suijishu(y - 10, y + 10);
            if ((x1  < 0) || (y1  < 0) ||
                (x1  > xianzhi_x) || (y1 > xianzhi_y))
            {
                WriteLog.WriteLogFile("", "suijitap出边界了.." + x1 + " " + y1);
                return;
            }
            mydm.MoveTo(x1, y1);
            mydelay(60, 120);
            mydm.LeftDown();
            mydelay(10, 50);
            mydm.LeftUp();
            mydelay(10, 120);
        }

        public void mytap2(int x, int y)
        {

            mydelay(100, 120);
            mydm.MoveTo(x, y);
            mydelay(100, 120);
            mydm.LeftClick();
        }

        public void myMove(int jubing, int x, int y)
        {
            int res = mydm.IsBind(jubing);
            if (res != 1)
            {
                res = bindWindow(jubing);
            }

            mydm.MoveTo(x, y);


        }

        public void mydrag2(int jubing, int x1, int y1, int x2, int y2)
        {
            int res = mydm.IsBind(jubing);
            if (res != 1)
            {
                //res = bindWindow(jubing);
            }
            mydelay(10, 20);
            mydm.MoveTo(x1, y1);
            mydelay(200, 300);
            mydm.LeftDown();
            mydelay(100, 200);
            int beichu = x1 >= x2 ? 10 : -10;
            int jiangex = System.Math.Abs(x1 - x2) / beichu;
            int jiangey = System.Math.Abs(y1 - y2) / beichu;
            int jiaoxiao = jiangex <= jiangey ? jiangex : jiangey;
            int dqx = -1;
            int dqy = -1;
            for (int i = 0; i < jiaoxiao; i++)
            {
                mydm.MoveTo(x1 - (i + 1) * beichu, y1 - (i + 1) * beichu);
                dqx = x1 - (i + 1) * beichu;
                dqy = y1 - (i + 1) * beichu;
                mydelay(100, 300);
            }
            int jiaoxiao2 = jiangex > jiangey ? jiangex - jiaoxiao : jiangey - jiaoxiao;
            if (jiangex > jiangey)
            {
                for (int i = 0; i < jiaoxiao2; i++)
                {
                    mydm.MoveTo(dqx - (i + 1) * beichu, dqy);
                    mydelay(100, 300);
                }
            }
            else if (jiangex < jiangey)
            {
                for (int i = 0; i < jiaoxiao2; i++)
                {
                    mydm.MoveTo(dqx, dqy - (i + 1) * beichu);
                    mydelay(100, 300);
                }
            }
            mydm.MoveTo(x2, y2);
            mydelay(100, 300);
            mydm.LeftUp();
            mydelay(100, 300);
        }
        /// <summary>
        /// 从指定坐标按下鼠标左键 开始拖鼠标 到指定坐标2结束
        /// </summary>
        /// <param name="jubing"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void mydrag(int jubing, int x1, int y1, int x2, int y2)
        {
            int res = mydm.IsBind(jubing);
            if (res != 1)
            {
                //res = bindWindow(jubing);
            }
            mydelay(10, 20);
            mydm.MoveTo(x1, y1);
            mydelay(200, 300);
            mydm.LeftDown();
            mydelay(100, 200);
            int beichu1 = x1 >= x2 ? 10 : -10;
            int beichu2 = y1 >= y2 ? 10 : -10;
            int jiangex = System.Math.Abs(x1 - x2) / beichu1;
            int jiangey = System.Math.Abs(y1 - y2) / beichu2;
            int absjiangex = System.Math.Abs(jiangex);
            int absjiangey = System.Math.Abs(jiangey);
            //MyFuncUtil.mylogandxianshi("jiangex,jiangey" + jiangex + " " + jiangey + " beichu1：" + beichu1 + " beichu2：" + beichu2);
            int jiaoxiao = absjiangex <= absjiangey ? absjiangex : absjiangey;
            //MyFuncUtil.mylogandxianshi("jiaoxiao" + jiaoxiao);
            int dqx = x1;
            int dqy = y1;
            MyFuncUtil.mylogandxianshi("x1,y1---" + x1 + " " + y1);
            for (int i = 0; i < jiaoxiao; i++)
            {
                mydm.MoveTo(x1 - (i + 1) * beichu1, y1 - (i + 1) * beichu2);
                dqx = x1 - (i + 1) * beichu1;
                dqy = y1 - (i + 1) * beichu2;
                mydelay(100, 300);
                //MyFuncUtil.mylogandxianshi("x1,y1 " + (x1 - (i + 1) * beichu1) + " " + (y1 - (i + 1) * beichu2));
                //MyFuncUtil.mylogandxianshi("dqx,dqy --"+dqx+" "+dqy);
            }
            int jiaoxiao2 = absjiangex > absjiangey ? absjiangex - absjiangey : absjiangey - absjiangex;
            if (absjiangex > absjiangey)
            {
                for (int i = 0; i < jiaoxiao2; i++)
                {
                    mydm.MoveTo(dqx - (i + 1) * beichu1, dqy);
                    mydelay(100, 300);
                    //MyFuncUtil.mylogandxianshi("dqx,dqy --" + (dqx - (i + 1) * beichu1) + " " + dqy);
                }
            }
            else if (absjiangex < absjiangey)
            {
                for (int i = 0; i < jiaoxiao2; i++)
                {
                    mydm.MoveTo(dqx, dqy - (i + 1) * beichu2);
                    mydelay(100, 300);
                    //MyFuncUtil.mylogandxianshi("dqx,dqy" + dqx + " " + (dqy - (i + 1) * beichu2));
                }
            }
            mydm.MoveTo(x2, y2);
            mydelay(100, 300);
            mydm.LeftUp();
            mydelay(100, 300);
        }

        /// <summary>
        /// 从指定坐标缓慢移动到坐标2
        /// </summary>
        /// <param name="jubing"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void mymovefromto(int jubing, int x1, int y1, int x2, int y2)
        {
            int res = mydm.IsBind(jubing);
            if (res != 1)
            {
                //res = bindWindow(jubing);
            }
            mydelay(10, 20);
            mydm.MoveTo(x1, y1);
            mydelay(200, 300);            
            int beichu1 = x1 >= x2 ? 10 : -10;
            int beichu2 = y1 >= y2 ? 10 : -10;
            int jiangex = System.Math.Abs(x1 - x2) / beichu1;
            int jiangey = System.Math.Abs(y1 - y2) / beichu2;
            int absjiangex = System.Math.Abs(jiangex);
            int absjiangey = System.Math.Abs(jiangey);
            //MyFuncUtil.mylogandxianshi("jiangex,jiangey" + jiangex + " " + jiangey + " beichu1：" + beichu1 + " beichu2：" + beichu2);
            int jiaoxiao = absjiangex <= absjiangey ? absjiangex : absjiangey;
            //MyFuncUtil.mylogandxianshi("jiaoxiao" + jiaoxiao);
            int dqx = x1;
            int dqy = y1;
            //MyFuncUtil.mylogandxianshi("x1,y1---" + x1 + " " + y1);
            for (int i = 0; i < jiaoxiao; i++)
            {
                mydm.MoveTo(x1 - (i + 1) * beichu1, y1 - (i + 1) * beichu2);
                dqx = x1 - (i + 1) * beichu1;
                dqy = y1 - (i + 1) * beichu2;
                mydelay(100, 300);
                //MyFuncUtil.mylogandxianshi("x1,y1 " + (x1 - (i + 1) * beichu1) + " " + (y1 - (i + 1) * beichu2));
                //MyFuncUtil.mylogandxianshi("dqx,dqy --"+dqx+" "+dqy);
            }
            int jiaoxiao2 = absjiangex > absjiangey ? absjiangex - absjiangey : absjiangey - absjiangex;
            if (absjiangex > absjiangey)
            {
                for (int i = 0; i < jiaoxiao2; i++)
                {
                    mydm.MoveTo(dqx - (i + 1) * beichu1, dqy);
                    mydelay(100, 300);
                }
            }
            else if (absjiangex < absjiangey)
            {
                for (int i = 0; i < jiaoxiao2; i++)
                {
                    mydm.MoveTo(dqx, dqy - (i + 1) * beichu2);
                    mydelay(100, 300);
                    //MyFuncUtil.mylogandxianshi("dqx,dqy" + dqx + " " + dqy);
                }
            }
            mydm.MoveTo(x2, y2);
            mydelay(100, 300);
        }

        public Boolean myGetColor(int jubing, int x, int y, string color)
        {
            if ((x < 0) || (y < 0) ||
                (x > xianzhi_x) || (y > xianzhi_y))
            {
                WriteLog.WriteLogFile("", "myGetColor出边界了..");
                return false;
            }
            bool tmp = false;
            String tmpcolor = mydm.GetColor(x, y);
            //MyFuncUtil.mylogandxianshi(tmpcolor);
            //if ("ffffff".Equals(tmpcolor))
            if (color.ToLower().Equals(tmpcolor.ToLower()))
            {
                tmp = true;
            }
            return tmp;
        }
        public string myGetColorWuJbYanse(int x, int y)
        {

            if ((x < 0) || (y < 0) ||
                (x > xianzhi_x) || (y > xianzhi_y))
            {
                WriteLog.WriteLogFile("", "myGetColorWuJbYanse出边界了..");
                return "";
            }
            String tmpcolor = mydm.GetColor(x, y);
            //MyFuncUtil.mylogandxianshi(tmpcolor);
            //if ("ffffff".Equals(tmpcolor))
            
            return tmpcolor;
        }

        public bool myGetColorWuJuYouYanSe(int x, int y,int yanse)
        {


            string tmpcolor = mydm.GetColor(x, y);
            string tmpcolor2 = yanse.ToString("X");
            if ((x < 0) || (y < 0) ||
                (x > xianzhi_x) || (y > xianzhi_y))
            {
                WriteLog.WriteLogFile("", "myGetColorWuJuYouYanSe出边界了..");
                return false;
            }
            return tmpcolor.ToLower().Equals(tmpcolor2.ToLower());
        }

        public string[] myGetColorWuJbList(List<ZuoBiao> lb)
        {
            List<String> mycolor = new List<string>();
            foreach (ZuoBiao z in lb) {
                if ((z.X < 0) || (z.Y < 0) ||
                (z.X > xianzhi_x) || (z.Y > xianzhi_y))
                {
                    WriteLog.WriteLogFile("", "myGetColorWuJbList出边界了..");
                    break;
                }
                String tmpcolor = mydm.GetColor(z.X, z.Y);
                mycolor.Add(tmpcolor);
            }
            if (mycolor != null && mycolor.Count > 0)
            {
                return mycolor.ToArray();
            }
            return null;
        }


        public Boolean myGetColorWuJuBing(int x, int y, string color)
        {
            if ((x < 0) || (y < 0) ||
                (x > xianzhi_x) || (y > xianzhi_y))
            {
                WriteLog.WriteLogFile("", "myGetColorWuJuBing出边界了..");
                return false;
            }
            bool tmp = false;
            String tmpcolor = mydm.GetColor(x, y);
            if (color.ToLower().Equals(tmpcolor.ToLower()))
            {
                tmp = true;
            }
            return tmp;
        }

        public void myFindColor(int jubing, int x1, int y1, int x2, int y2, string color, out int zx, out int zy)
        {
            int res = mydm.IsBind(jubing);
            if (res != 1)
            {
                bindWindow(jubing);
            }
            zx = -1;
            zy = -1;
            mydm.FindColor(x1, y1, x2, y2, color, 0.9, 1, out zx, out zy);
            //MyFuncUtil.mylogandxianshi(tmpcolor);
            //if ("ffffff".Equals(tmpcolor
        }

        public void myFindColorWuJubing(int x1, int y1, int x2, int y2, int color, out int zx, out int zy)
        {
            
            zx = -1;
            zy = -1;
            string c = color.ToString("X");
            mydm.FindColor(x1, y1, x2, y2, c, 0.9, 1, out zx, out zy);
            //MyFuncUtil.mylogandxianshi(tmpcolor);
            //if ("ffffff".Equals(tmpcolor
        }

        public void ClientToScreen(int jubing, out int myx, out int myy, out int myx1, out int myy1)
        {
            int res = mydm.IsBind(jubing);
            if (res != 1)
            {
                bindWindow(jubing);
            }
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;
            mydm.GetClientRect(jubing, out x1, out y1, out x2, out y2);
            myx = x1;
            myy = y1;
            myx1 = x2;
            myy1 = y2;
        }


        public void myGetClientRect(int jubing, out int width, out int height)
        {
            width = -1;
            height = -1;
            int res = mydm.IsBind(jubing);
            if (res != 1)
            {
                bindWindow(jubing);
            }
            mydm.GetClientSize(jubing, out width, out height);
        }

        /*private void initJubing(int jb, string a)
        {
            if (jb > 0)
            {
                setJubing(jb);
                return;
            }
            if (a != null)
            {
                setMoniqiname(a);
            }
        }

        private int getJubing() {
            if (this.jubing != -1) {
                return this.jubing;
            }
            int i = mydm.FindWindow("", moniqiname);
            int j = mydm.FindWindowEx(i, "", "");
            return j;
        }*/

        public int bindWindow(int jb)
        {
            int ret = mydm.BindWindow(jb, "gdi", "windows3", "windows", 1);
            //同时绑定本体
            ret = this.BindWindow(jb, "gdi", "windows3", "windows", 1);
            return ret;
        }

        public int captureBmp(int jubing, string path, string fileName)
        {
            //循环绑定 绑定成功才截图
            int res = mydm.IsBind(jubing);
            if (res != 1)
            {
                bindWindow(jubing);
            }
            int width = 0;
            int height = 0;
            mydm.GetClientSize(jubing, out width, out height);
            mydm.SetPath(path);
            res = mydm.Capture(0, 0, width, height, fileName);
            return res;
        }



        public int captureBmp(int jubing, string path, string fileName,int x1,int y1,int x2,int y2)
        {
            //循环绑定 绑定成功才截图
            int res = mydm.IsBind(jubing);
            if (res != 1)
            {
                //bindWindow(jubing);
            }
            int width = 0;
            int height = 0;
            mydm.GetClientSize(jubing, out width, out height);
            if (x1 < 0 || x2 > width || y1 < 0 || y2 > height) {
                return 0;
            }
            if ((x1 < 0) || (y1 < 0) ||
                (x1 > xianzhi_x) || (y1 > xianzhi_y) ||
                (x2 < 0) || (y2 < 0) ||
                (x2 > xianzhi_x) || (y2 > xianzhi_y))
            {
                WriteLog.WriteLogFile("", "captureBmp.." + x1 + " " + y1);
                return 0;
            }
            mydm.SetPath(path);
            res = mydm.Capture(x1, y1, x2, y2, fileName);
            return res;
        }



        //x1, y1, x2, y2,first_color,offset_color,sim, dir,intX,intY
        /// <summary>
        /// 取点取色 直接从触动精灵取色器复制
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="off"></param>
        /// <param name="sim"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        public string myqudianquse(int jubing, Int32 fir, string off, int sim, int x0, int y0, int x1, int y1)
        {
            //适用FindMultiColor方法
            int res = mydm.IsBind(jubing);
            if (res != 1)
            {
                bindWindow(jubing);
            }
            if ((x0 < 0) || (y0 < 0) ||
                (x0 > xianzhi_x) || (y0 > xianzhi_y)||
                (x1 < 0) || (y1 < 0) ||
                (x1 > xianzhi_x) || (y1 > xianzhi_y))
            {
                WriteLog.WriteLogFile("", "myqudianquse出边界了..");
                return "";
            }
            mydelay(1000, 1500);
            string result = "-1|-1";
            string firstColor = fir.ToString("X");
            string offsetColor = off.Replace("|0x", "|");
            double isim = sim * 0.01;
            result = mydm.FindMultiColorE(x0, y0, x1, y1, firstColor, offsetColor, isim, 1);
            return result;
        }

        /// <summary>
        /// 取点取色直接返回坐标
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="off"></param>
        /// <param name="sim"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        public void myqudianqusezuobiao(int jubing, Int32 fir, string off, int sim, int x0, int y0, int x1, int y1, out int ox, out int oy)
        {
            ox = -1;
            oy = -1;
            if ((x0 < 0) || (y0 < 0) ||
                (x0 > xianzhi_x) || (y0 > xianzhi_y) ||
                (x1 < 0) || (y1 < 0) ||
                (x1 > xianzhi_x) || (y1 > xianzhi_y))
            {
                WriteLog.WriteLogFile("", "myqudianqusezuobiao.." + x0 + " " + y0);
                return;
            }
            //适用FindMultiColor方法
            int res = mydm.IsBind(jubing);
            if (res != 1)
            {
                //res=bindWindow(jubing);
            }
            string result = "-1|-1";
            string firstColor = fir.ToString("X");
            //MyFuncUtil.mylogandxianshi(firstColor);
            string offsetColor = off.Replace("|0x", "|");
            double isim = sim * 0.01;
            result = mydm.FindMultiColorE(x0, y0, x1, y1, firstColor, offsetColor, isim, 1);
            string[] a1 = result.Split('|');
            if (int.Parse(a1[0]) == -1)
            {
                return;
            }
            if (int.Parse(a1[0]) != -1)
            {
                ox = int.Parse(a1[0]);
                oy = int.Parse(a1[1]);
            }
        }

        /// <summary>
        /// 取点取色直接返回坐标不用句柄
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="off"></param>
        /// <param name="sim"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        public void myqudianqusezuobiaowujubing(Int32 fir, string off, int sim, int x0, int y0, int x1, int y1, out int ox, out int oy)
        {

            ox = -1;
            oy = -1;
            if ((x0 < 0) || (y0 < 0) ||
                (x0 > xianzhi_x) || (y0 > xianzhi_y) ||
                (x1 < 0) || (y1 < 0) ||
                (x1 > xianzhi_x) || (y1 > xianzhi_y))
            {
                WriteLog.WriteLogFile("", "myqudianqusezuobiaowujubing.." + x0 + " " + y0);
                return;
            }
            string result = "-1|-1";
            string firstColor = fir.ToString("X");
            //MyFuncUtil.mylogandxianshi(firstColor);
            string offsetColor = off.Replace("|0x", "|");
            double isim = sim * 0.01;
            result = mydm.FindMultiColorE(x0, y0, x1, y1, firstColor, offsetColor, isim, 1);
            string[] a1 = result.Split('|');
            if (int.Parse(a1[0]) == -1)
            {
                return;
            }
            if (int.Parse(a1[0]) != -1)
            {
                ox = int.Parse(a1[0]);
                oy = int.Parse(a1[1]);
            }
        }

        /// <summary>
        /// 取点取单色直接返回坐标无句柄
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="off"></param>
        /// <param name="sim"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        public void myqudianqudanse(Int32 fir, int sim, int x0, int y0, int x1, int y1, out int ox, out int oy)
        {
            ox = -1;
            oy = -1;
            if ((x0 < 0) || (y0 < 0) ||
                (x0 > xianzhi_x) || (y0 > xianzhi_y) ||
                (x1< 0) || (y1 < 0) ||
                (x1 > xianzhi_x) || (y1 > xianzhi_y))
            {
                WriteLog.WriteLogFile("", "mohumyqudianqudanse.." + x0 + " " + y0);
                return;
            }
            string result = "-1|-1";
            string firstColor = fir.ToString("X");
            double isim = sim * 0.01;
            
            if ((x0 < 0) || (y0 < 0) ||
                (x0 > xianzhi_x) || (y0 > xianzhi_y) ||
                (x1 < 0) || (y1 < 0) ||
                (x1 > xianzhi_x) || (y1 > xianzhi_y))
            {
                WriteLog.WriteLogFile("", "myqudianquse无句柄出边界了.."+x0+" "+x1+" "+y0+" "+y1);
                return;
            }
            result = mydm.FindColorE(x0, y0, x1, y1, firstColor, isim, 1);
            string[] a1 = result.Split('|');
            
            if (int.Parse(a1[0]) == -1)
            {
                return;
            }
            if (int.Parse(a1[0]) != -1)
            {
                ox = int.Parse(a1[0]);
                oy = int.Parse(a1[1]);
            }
        }

        /// <summary>
        /// 按照类来取点取色直接返回坐标
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="off"></param>
        /// <param name="sim"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        public void myqudianqusezuobiaoByLei(int jubing, DuoDianZhaoSe dz, out int ox, out int oy)
        {
            //适用FindMultiColor方法
            int res = mydm.IsBind(jubing);
            if (res != 1)
            {
                //bindWindow(jubing);
            }
            string result = "-1|-1";
            string firstColor = dz.Fir.ToString("X");
            string offsetColor = dz.Off.Replace("|0x", "|");
            double isim = dz.Sim * 0.01;
            result = mydm.FindMultiColorE(dz.X0, dz.Y0, dz.X1, dz.Y1, firstColor, offsetColor, isim, 1);
            string[] a1 = result.Split('|');
            ox = -1;
            oy = -1;
            if (int.Parse(a1[0]) == -1)
            {
                return;
            }
            if (int.Parse(a1[0]) != -1)
            {
                ox = int.Parse(a1[0]);
                oy = int.Parse(a1[1]);
            }
        }

        /// <summary>
        /// 按照类来取点取色直接返回坐标
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="off"></param>
        /// <param name="sim"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        public void myqudianqusezuobiaoByLeiWuJubing(DuoDianZhaoSe dz, out int ox, out int oy)
        {
            string result = "-1|-1";
            string firstColor = dz.Fir.ToString("X");
            string offsetColor = dz.Off.Replace("|0x", "|");
            double isim = dz.Sim * 0.01;
            result = mydm.FindMultiColorE(dz.X0, dz.Y0, dz.X1, dz.Y1, firstColor, offsetColor, isim, 1);
            string[] a1 = result.Split('|');
            ox = -1;
            oy = -1;
            if (int.Parse(a1[0]) == -1)
            {
                return;
            }
            if (int.Parse(a1[0]) != -1)
            {
                ox = int.Parse(a1[0]);
                oy = int.Parse(a1[1]);
            }
        }

        /// <summary>
        /// 按照类来取点取色 循环判断是否成功
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="off"></param>
        /// <param name="sim"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        public bool myqudianqusezuobiaoXunHuanDianJi(int jb, DuoDianZhaoSe[] dz, int miao)
        {
            //适用FindMultiColor方法            
            int x = -1;
            int y = -1;
            long ks = MyFuncUtil.GetTimestamp();
            var rs = false;
            while (true)
            {
                long js = MyFuncUtil.GetTimestamp();
                if ((js - ks) / 1000 > miao)
                {
                    break;
                }
                int d = 0;
                foreach (DuoDianZhaoSe dza in dz)
                {
                    myqudianqusezuobiaoByLeiWuJubing(dza, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        mytap(jb, x, y);
                        mydelay(100, 800);
                    }
                    if (x == -1 && y == -1)
                    {
                        d = 1;
                        break;
                    }
                }
                if (d == 1)
                {
                    rs = true;
                    break;
                }
            }
            return rs;
        }

        /// <summary>
        /// 按照类来取点取色 循环判断是否成功
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="off"></param>
        /// <param name="sim"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        public bool myqudianqusezuobiaoXunHuan(DuoDianZhaoSe[] dz, int miao)
        {
            //适用FindMultiColor方法            
            int x = -1;
            int y = -1;
            long ks = MyFuncUtil.GetTimestamp();
            var rs = false;
            while (true)
            {
                long js = MyFuncUtil.GetTimestamp();
                if ((js - ks) / 1000 > miao)
                {
                    break;
                }
                int d = 0;
                foreach (DuoDianZhaoSe dza in dz)
                {
                    myqudianqusezuobiaoByLeiWuJubing(dza, out x, out y);
                    if (x != -1 && y != -1)
                    {
                        d = 1;
                        break;
                    }
                }
                if (d == 1)
                {
                    rs = true;
                    break;
                }
            }
            return rs;
        }

        /// <summary>
        /// 按照类的组来取点取色 是否成功
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="off"></param>
        /// <param name="sim"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        public bool myqudianqusezuobiaoShuZu(DuoDianZhaoSe[] dz)
        {
            //适用FindMultiColor方法            
            int x = -1;
            int y = -1;
            var rs = false;
            int d = 0;
            foreach (DuoDianZhaoSe dza in dz)
            {
                myqudianqusezuobiaoByLeiWuJubing(dza, out x, out y);
                if (x != -1 && y != -1)
                {
                    d = 1;
                    break;
                }
            }
            if (d == 1)
            {
                rs = true;

            }
            return rs;
        }


        /// <summary>
        /// 按照复合类的组来取点取色 是否成功
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="off"></param>
        /// <param name="sim"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        public FuHeDuoDian fuHeDuoDianShuZu(FuHeDuoDian[] fh)
        {
            //适用FindMultiColor方法            
            int x = -1;
            int y = -1;
            FuHeDuoDian rs = null;
            FuHeDuoDian d = null;
            foreach (FuHeDuoDian fha in fh)
            {
                myqudianqusezuobiaoByLeiWuJubing(fha.Dz, out x, out y);
                if (x != -1 && y != -1)
                {
                    d = fha;
                    break;
                }
            }
            if (d != null)
            {
                return d;

            }
            return rs;
        }

        public Boolean pingmuquanhei(int jubing)
        {
            string result = "-1|-1";
            result = myqudianquse(jubing, 0x000000, "13|55|0x000000,45|167|0x000000,53|203|0x000000,169|273|0x000000,310|305|0x000000,244|49|0x000000,-41|269|0x000000,-15|107|0x000000,588|312|0x000000", 90, 0, 0, 959, 539);
            string[] a1 = result.Split('|');
            string result2 = "-1|-1";
            result2 = myqudianquse(jubing, 0xe6dcd0, "-29|-27|0xfffff7,766|-334|0xb5b7b8,462|-42|0x006896,316|-152|0x0a0d11,82|21|0x737573,-45|-67|0x5b5a5b,-11|-44|0x5d5d45", 90, 0, 0, 959, 539);
            string[] a2 = result2.Split('|');
            int a = MyFuncUtil.suijishu(0, 10);
            if (int.Parse(a1[0]) != -1 && int.Parse(a2[0]) == -1 && a < 5)
            {
                WriteLog.WriteLogFile("", "屏幕全黑无法截图");
                return true;
            }
            return false;
        }
        public void myUnBindWindow()
        {
            mydm.UnBindWindow();
        }
        public int mohu(int mx1, int my1, int myanse1, int mx2=-1, int my2=-1, int myanse2=-1, int mx3=-1, int my3=-1, int myanse3=-1,int sim=90)
        {
            if ((mx1 < 0) || (my1 < 0) ||
                (mx1 > xianzhi_x) || (my1 > xianzhi_y) ||
                (mx1 + 1 < 0) || (my1 + 1 < 0) ||
                (mx1 + 1 > xianzhi_x) || (my1 + 1 > xianzhi_y))
            {
                WriteLog.WriteLogFile("", "mohu无句柄出边界了.." + mx1 + " " + my1);
                return 0;
            }
            
            int ox = -1, oy = -1;
            int rs1 = -1;
            rs1 = jingque(mx1, my1, myanse1, mx2, my2, myanse2, mx3, my3, myanse3);
            if (rs1 == 1) {
                return 1;
            }
            myqudianqudanse(myanse1, sim, mx1, my1, mx1 + 1, my1 + 1, out ox, out oy);
            if (ox != -1 && oy != -1)
            {
                rs1 = 1;
            }
            int rs2 = -1;
            if (mx2 != -1)
            {
                myqudianqudanse(myanse2, sim, mx2, my2, mx2 + 1, my2 + 1, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    rs2 = 1;
                }
            }
            int rs3 = -1;
            if (mx3 != -1)
            {
                myqudianqudanse(myanse3, sim, mx3, my3, mx3 + 1, my3 + 1, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    rs3 = 1;
                }
            }
            if ((rs1 == 1) && (rs2 == 1) && (rs3 == 1))
            {
                return 1;
            }
            if ((rs1 == 1) && (rs2 == 1) && (myanse3 == -1))
            {
                return 1;
            }
            if ((rs1 == 1) && (myanse2 == -1) && (myanse3 == -1))
            {
                return 1;
            }
            return 0;
        }

        public int mohuByLei(SanDian sd,int sim=90)
        {
            if ((sd.Mx1 < 0) || (sd.My1 < 0) ||
                (sd.Mx1 > xianzhi_x) || (sd.My1 > xianzhi_y) ||
                (sd.Mx1 + 1 < 0) || (sd.My1 + 1 < 0) ||
                (sd.My1 + 1 > xianzhi_x) || (sd.My1 + 1 > xianzhi_y))
            {
                WriteLog.WriteLogFile("", "mohuByLei无句柄出边界了.." + sd.Mx1 + " " + sd.My1);
                return 0;
            }
            int ox = -1, oy = -1;
            myqudianqudanse(sd.Myanse1, sim, sd.Mx1, sd.My1, sd.Mx1 + 1, sd.My1 + 1, out ox, out oy);
            int rs1 = -1;
            if (ox != -1 && oy != -1)
            {
                rs1 = 1;
            }
            int rs2 = -1;
            if (sd.Mx2 != -1)
            {
                myqudianqudanse(sd.Myanse2, sim, sd.Mx2, sd.My2, sd.Mx2 + 1, sd.My2 + 1, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    rs2 = 1;
                }
            }
            int rs3 = -1;
            if (sd.Mx3 != -1)
            {
                myqudianqudanse(sd.Myanse3, sim, sd.Mx3, sd.My3, sd.Mx3 + 1, sd.My3 + 1, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    rs3 = 1;
                }
            }
            if ((rs1 == 1) && (rs2 == 1) && (rs3 == 1))
            {
                return 1;
            }
            if ((rs1 == 1) && (rs2 == 1) && (sd.Myanse3 == -1))
            {
                return 1;
            }
            if ((rs1 == 1) && (sd.Myanse2 == -1) && (sd.Myanse3 == -1))
            {
                return 1;
            }
            return 0;
        }

        public bool mohuByLeiBool(SanDian sd,int sim=90)
        {
            bool tmp = false;
            bool tmp1 = this.jingqueByLeiBool(sd);
            if (tmp1==true)
            {
                return true;
            }
            int ox = -1, oy = -1;
            if ((sd.Mx1 < 0) || (sd.My1 < 0) ||
                (sd.Mx1 > xianzhi_x) || (sd.My1 > xianzhi_y) ||
                (sd.Mx1 + 1 < 0) || (sd.My1+1 < 0) ||
                (sd.My1 + 1 > xianzhi_x) || (sd.My1+1 > xianzhi_y))
            {
                WriteLog.WriteLogFile("", "mohuByLeiBool无句柄出边界了.."+sd.Mx1+" "+sd.My1);
                return false;
            }
            myqudianqudanse(sd.Myanse1, sim, sd.Mx1, sd.My1, sd.Mx1 + 1, sd.My1 + 1, out ox, out oy);
            int rs1 = -1;
            if (ox != -1 && oy != -1)
            {
                rs1 = 1;
            }
            int rs2 = -1;
            if (sd.Mx2 != -1)
            {
                myqudianqudanse(sd.Myanse2, sim, sd.Mx2, sd.My2, sd.Mx2 + 1, sd.My2 + 1, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    rs2 = 1;
                }
            }
            int rs3 = -1;
            if (sd.Mx3 != -1)
            {
                myqudianqudanse(sd.Myanse3, sim, sd.Mx3, sd.My3, sd.Mx3 + 1, sd.My3 + 1, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    rs3 = 1;
                }
            }
            if ((rs1 == 1) && (rs2 == 1) && (rs3 == 1))
            {
                return true;
            }
            if ((rs1 == 1) && (rs2 == 1) && (sd.Myanse3 == -1))
            {
                return true;
            }
            if ((rs1 == 1) && (sd.Myanse2 == -1) && (sd.Myanse3 == -1))
            {
                return true;
            }
            return tmp;
        }

        /// <summary>
        /// 按照复合类的组来取点取色 是否成功
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="off"></param>
        /// <param name="sim"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        public FuHeSanDian fuHeSanDianShuZu(FuHeSanDian[] fh)
        {
            FuHeSanDian rs = null;
            FuHeSanDian d = null;
            foreach (FuHeSanDian fha in fh)
            {
                if (mohuByLeiBool(fha.Sd))
                {
                    d = fha;
                    break;
                }
            }
            if (d != null)
            {
                return d;

            }
            return rs;
        }

        /// <summary>
        /// 按照类来取点取色 循环判断是否成功
        /// </summary>
        /// <param name="fir"></param>
        /// <param name="off"></param>
        /// <param name="sim"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        public bool mohuqubiaoXunHuan(SanDian[] sd, int miao)
        {
            //适用FindMultiColor方法            
            long ks = MyFuncUtil.GetTimestamp();
            var rs = false;
            while (true)
            {
                long js = MyFuncUtil.GetTimestamp();
                if ((js - ks) / 1000 > miao)
                {
                    break;
                }
                int d = 0;
                foreach (SanDian dza in sd)
                {
                    if ((mohuByLei(dza) == 1)&&((js - ks) / 1000 > 3))
                    {
                        d = 1;
                        break;
                    }
                }
                if (d == 1)
                {
                    rs = true;
                    break;
                }
            }
            return rs;
        }


        /// <summary>
        /// 一个三点类出现超过6s
        /// </summary>
        /// <param name="sd"></param>
        /// <param name="miao"></param>
        /// <returns></returns>
        public bool mohuXunHuanJianChi(SanDian sd, int miao)
        {
            //适用FindMultiColor方法            
            long ks = MyFuncUtil.GetTimestamp();
            var rs = false;
            var cx = 0;
            while (true)
            {
                long js = MyFuncUtil.GetTimestamp();
                if ((js - ks) / 1000 > miao)
                {
                    break;
                }
                if (cx==0 && (mohuByLei(sd) == 1) && ((js - ks) / 1000 > 2))
                {
                    ks = MyFuncUtil.GetTimestamp();
                    cx = 1;
                }
                if (cx==1 &&(mohuByLei(sd) == 1) && ((js - ks) / 1000 > 4))
                {
                    ks = MyFuncUtil.GetTimestamp();
                    rs = true;
                    break;
                }
                if (cx == 0 && (mohuByLei(sd) == 1) && ((js - ks) / 1000 > 6))
                {
                    ks = MyFuncUtil.GetTimestamp();
                    rs = true;
                    break;
                }
                if (mohuByLei(sd) != 1)
                {
                    break;
                }
            }
            return rs;
        }

        

        public int jingque(int mx1, int my1, int myanse1, int mx2=-1, int my2=-1, int myanse2=-1, int mx3=-1, int my3=-1, int myanse3=-1)
        {
            string firstColor = myanse1.ToString("X");
            bool rs1 = myGetColorWuJuBing(mx1, my1, firstColor);
            bool rs2 = false;
            if (mx2 != -1)
            {
                string secColor = myanse2.ToString("X");
                rs2 = myGetColorWuJuBing(mx2, my2, secColor);
            }
            bool rs3 = false;
            if (mx3 != -1)
            {
                string thrColor = myanse3.ToString("X");
                rs3 = myGetColorWuJuBing(mx3, my3, thrColor);
            }
            if (rs1  && rs2&& rs3)
            {
                return 1;
            }
            if (rs1&& rs2  && (myanse3 == -1))
            {
                return 1;
            }
            if (rs1 && (myanse2 == -1) && (myanse3 == -1))
            {
                return 1;
            }
            return 0;

        }

        public int jingqueByLei(SanDian sd)
        {
            string firstColor = sd.Myanse1.ToString("X");
            bool rs1 = myGetColorWuJuBing(sd.Mx1, sd.My1, firstColor);
            bool rs2 = false;
            if (sd.Mx2 != -1)
            {
                string secColor = sd.Myanse2.ToString("X");
                rs2 = myGetColorWuJuBing(sd.Mx2, sd.My2, secColor);
            }
            bool rs3 = false;
            if (sd.Mx3 != -1)
            {
                string thrColor = sd.Myanse3.ToString("X");
                rs3 = myGetColorWuJuBing(sd.Mx3, sd.My3, thrColor);
            }
            if (rs1 && rs2 && rs3)
            {
                return 1;
            }
            if (rs1 && rs2 && (sd.Myanse3 == -1))
            {
                return 1;
            }
            if (rs1 && (sd.Myanse2 == -1) && (sd.Myanse3 == -1))
            {
                return 1;
            }
            return 0;

        }

        public bool jingqueByLeiBool(SanDian sd)
        {
            bool tmp = false;
            string firstColor = sd.Myanse1.ToString("X");
            bool rs1 = myGetColorWuJuBing(sd.Mx1, sd.My1, firstColor);            
            bool rs2 = false;
            if (sd.Mx2 != -1)
            {
                string secColor = sd.Myanse2.ToString("X");
                rs2 = myGetColorWuJuBing(sd.Mx2, sd.My2, secColor);
            }
            bool rs3 = false;
            if (sd.Mx3 != -1)
            {
                string thrColor = sd.Myanse3.ToString("X");
                rs3 = myGetColorWuJuBing(sd.Mx3, sd.My3, thrColor);
            }
            if (rs1 && rs2 && rs3)
            {
                return true;
            }
            if (rs1 && rs2 && (sd.Myanse3 == -1))
            {
                return true;
            }
            if (rs1 && (sd.Myanse2 == -1) && (sd.Myanse3 == -1))
            {
                return true;
            }            
            return tmp;
        }
        public int fanwei(int fx1, int fy1, int fx1_, int fy1_, int fyanse1)
        {
            int zx=-1,zy=-1;
            myFindColorWuJubing(fx1,fy1,fx1_,fy1_,fyanse1,out zx,out zy);
            if(zx!=-1 && zy!=-1){
                return 1;
            }
            return 0;
        }

        public void fanweiyoufanhui(int fx1, int fy1, int fx1_, int fy1_, int fyanse1,out int x,out int y)
        {
            int zx = -1, zy = -1;
            x = -1;
            y = -1;
            myFindColorWuJubing(fx1, fy1, fx1_, fy1_, fyanse1, out zx, out zy);
            if (zx != -1 && zy != -1)
            {
                x = zx; 
                y = zy;
            }
        }
    }
}
