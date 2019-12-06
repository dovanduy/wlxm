using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xDM;
using MyUtil;
using Entity;

namespace YouXi
{
    public class MyYouXi
    {
        /*
         包括内容：
         * 1apkname package version 封装的大漠函数
         */
        private YouXiEntity _youxiEntity;

        public YouXiEntity YouxiEntity
        {
            get { return _youxiEntity; }
            set { _youxiEntity = value; }
        }

        //三点相关
        private static List<ZuoBiao> _list_zuobiao = new List<ZuoBiao>();

        public static List<ZuoBiao> List_zuobiao
        {
          get { return MyYouXi._list_zuobiao; }
          set { MyYouXi._list_zuobiao = value; }
        }

        


        private static List<SanDian> _list_yqsandian = new List<SanDian>();

        public static List<SanDian> List_yqsandian
        {
            get { return MyYouXi._list_yqsandian; }
            set { MyYouXi._list_yqsandian = value; }
        }


        private static List<FuHeSanDian> _list_yqfhsandian = new List<FuHeSanDian>();

        public static List<FuHeSanDian> List_yqfhsandian
        {
            get { return MyYouXi._list_yqfhsandian; }
            set { MyYouXi._list_yqfhsandian = value; }
        }


        private static Dictionary<string, FuHeSanDian> _dict = new Dictionary<string, FuHeSanDian>();

        public static Dictionary<string, FuHeSanDian> Dict
        {
            get { return _dict; }
            set { _dict = value; }
        }

        static MyYouXi()
        {
            WriteLog.WriteLogFile("", "进入父类静态函数"); 

        }

        public List<FuHeSanDian> findAllFuHeSandian()
        {
            return _list_yqfhsandian;
        }

        public FuHeSanDian findFuHeSandianByName(string name)
        {
            return findAllFuHeSandian().Find(f => name.Equals(f.Name)
                );
        }
        public List<FuHeSanDian> findListFuHeSandianByName(string nameindex)
        {
            return findAllFuHeSandian().FindAll(f => f.Name.IndexOf(nameindex) == 0
                );
        }

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

        public MyYouXi(xDm mydm, int dqinx, int jubing)
        {
            this.mf = (myDm)mydm;
            this._dqinx = dqinx;
            this._jubing = jubing;
            //模拟器的名字 取值有问题 改为index
            this._mnqName = dqinx + "";
            int r = -1;
            if (jubing > 0)
            {
                r = mf.bindWindow(this._jubing);
            }
            WriteLog.WriteLogFile(this._mnqName, this._youxiEntity.Youxiname + "构造函数,句柄是:" + _jubing + ",模拟器index是:" + _mnqName + "，绑定:" + r);
        }

        public void mainprogramm() { }

        //已经封装的函数



        private int xianzhi_x = 687;
        private int xianzhi_y = 386;
        /// <summary>
        /// 鼠标左键点击 x y坐标
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void click(int x, int y, int pianyix = 0, int pianyiy = 0)
        {
            int x1 = MyFuncUtil.suijishu(-2, 2);
            int y1 = MyFuncUtil.suijishu(-2, 2);
            mf.mydelay(50, 80);
            if ((x1 + x + pianyix < 0) || (y1 + y + pianyiy < 0) ||
                (x1 + x + pianyix > xianzhi_x) || (y1 + y + pianyiy > xianzhi_y))
            {
                WriteLog.WriteLogFile("", "出边界了.." + x + " " + y);
                return;
            }
            mf.Mydm.MoveTo(x + x1 + pianyix, y + y1 + pianyiy);
            mf.mydelay(60, 120);
            mf.Mydm.LeftDown();
            mf.mydelay(10, 50);
            mf.Mydm.LeftUp();
            mf.mydelay(10, 120);
        }

        /// <summary>
        /// 间隔多少毫秒
        /// </summary>
        public void msleep(int jg)
        {
            mf.mydelay(jg, jg);
        }

        public int mohu(int mx1, int my1, int myanse1, int mx2 = -1, int my2 = -1, int myanse2 = -1, int mx3 = -1, int my3 = -1, int myanse3 = -1, int sim = 90)
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
            rs1 = mf.jingque(mx1, my1, myanse1, mx2, my2, myanse2, mx3, my3, myanse3);
            if (rs1 == 1)
            {
                return 1;
            }
            mf.myqudianqudanse(myanse1, sim, mx1, my1, mx1 + 1, my1 + 1, out ox, out oy);
            if (ox != -1 && oy != -1)
            {
                rs1 = 1;
            }
            int rs2 = -1;
            if (mx2 != -1)
            {
                mf.myqudianqudanse(myanse2, sim, mx2, my2, mx2 + 1, my2 + 1, out ox, out oy);
                if (ox != -1 && oy != -1)
                {
                    rs2 = 1;
                }
            }
            int rs3 = -1;
            if (mx3 != -1)
            {
                mf.myqudianqudanse(myanse3, sim, mx3, my3, mx3 + 1, my3 + 1, out ox, out oy);
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
        /// 从指定坐标按下鼠标左键 开始拖鼠标 到指定坐标2结束
        /// </summary>
        /// <param name="jubing"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void touch(int x1, int y1, int x2, int y2)
        {
            //int res = mf.IsBind(jubing);
            //if (res != 1)
            {
                //res = bindWindow(jubing);
            }
            mf.mydelay(10, 20);
            mf.Mydm.MoveTo(x1, y1);
            mf.mydelay(200, 300);
            mf.Mydm.LeftDown();
            mf.mydelay(100, 200);
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
                mf.Mydm.MoveTo(x1 - (i + 1) * beichu1, y1 - (i + 1) * beichu2);
                dqx = x1 - (i + 1) * beichu1;
                dqy = y1 - (i + 1) * beichu2;
                mf.mydelay(100, 300);
                //MyFuncUtil.mylogandxianshi("x1,y1 " + (x1 - (i + 1) * beichu1) + " " + (y1 - (i + 1) * beichu2));
                //MyFuncUtil.mylogandxianshi("dqx,dqy --"+dqx+" "+dqy);
            }
            int jiaoxiao2 = absjiangex > absjiangey ? absjiangex - absjiangey : absjiangey - absjiangex;
            if (absjiangex > absjiangey)
            {
                for (int i = 0; i < jiaoxiao2; i++)
                {
                    mf.Mydm.MoveTo(dqx - (i + 1) * beichu1, dqy);
                    mf.mydelay(100, 300);
                    //MyFuncUtil.mylogandxianshi("dqx,dqy --" + (dqx - (i + 1) * beichu1) + " " + dqy);
                }
            }
            else if (absjiangex < absjiangey)
            {
                for (int i = 0; i < jiaoxiao2; i++)
                {
                    mf.Mydm.MoveTo(dqx, dqy - (i + 1) * beichu2);
                    mf.mydelay(100, 300);
                    //MyFuncUtil.mylogandxianshi("dqx,dqy" + dqx + " " + (dqy - (i + 1) * beichu2));
                }
            }
            mf.Mydm.MoveTo(x2, y2);
            mf.mydelay(500, 2000);
            mf.Mydm.LeftUp();
            mf.mydelay(100, 300);
        }

    }
}
