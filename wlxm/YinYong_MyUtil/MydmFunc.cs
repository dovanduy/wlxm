using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xDM;


namespace MyUtil
{
    public class MydmFunc
    {
        private IxDm mydm;
        private int jubing=-1;
        private string moniqiname = null;
        
        //private static MydmFunc mf;

        //private static object locker = new object();
        /*private MydmFunc(IxDm mydm, int jubing)
            : base(mydm, jubing)
        {
            
           
        }*/
        
        public MydmFunc (IxDm mydm,int jubing)
        {
            this.mydm = mydm;
            this.jubing = jubing;
        }
    

        public IxDm getMyDm()
        {
            return this.mydm;
        }

        public int getJubing()
        {
            return this.jubing;
        }
        /*
        public MydmFunc()
        {
            this.mydm = new xDm(); 

        }*/
        public int suijishu(int min, int max)
        {
            Random rd = new Random();
            return rd.Next(min,max);
        }
        public int mydelay(int min, int max)
        {
            int md = suijishu(min, max);
            this.mydm.delay(md);
            return md;
            //Thread.Sleep(md * 10);
        }

        /// <summary>
        /// 鼠标左键点击 x y坐标
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void mytap(int x,int y) {
            bindWindow(this.jubing);
            mydelay(100,120);
            this.mydm.MoveTo(x, y);
            mydelay(100, 120);
            this.mydm.LeftDown();
            int r=mydelay(10, 50);
            this.mydm.LeftUp();
            mydelay(10, 120);
        }

        public void mytap2(int x, int y)
        {
            mydelay(100, 120);
            this.mydm.MoveTo(x, y);
            mydelay(100, 120);
            this.mydm.LeftClick();
        }

        public void myMove(int x, int y)
        {


            mydelay(100, 120);
            mydm.MoveTo(x, y);
            mydelay(100, 120);

        }

        public void ClientToScreen(out int myx, out int myy,out int myx1, out int myy1)
        {

            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;
            mydm.GetClientRect(getJubing(), out x1, out y1, out x2, out y2);
            
            

            myx = x1;
            myy = y1;
            myx1 = x2;
            myy1 = y2;
        }

        private void setJubing(int jb) {
            this.jubing = jb;
        }
        private void setMoniqiname(string a)
        {
            this.moniqiname = a;
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
            int ret = mydm.BindWindow(getJubing(), "gdi", "windows3", "windows", 0);
            if (ret > 0) {
                //mydm.WriteFile("cs.txt","绑定成功" + getJubing());
            }
            return ret;
        }

        public void captureBmp(int jubing,string path,string fileName) {
           //循环绑定 绑定成功才截图
            long kstime = mydm.GetTime();
            Boolean abc = false;
            while (true) {
                int res = bindWindow(jubing);
                if (res > 0)
                {
                    break;
                }
                long jstime = mydm.GetTime();
                if ((res <= 0) &&  (jstime - kstime) > 10)
                {
                    abc = true;
                    break;
                }
            }
            if (!abc) {
                int width = 0;
                int height = 0;
                mydm.GetClientSize(jubing, out width, out height);
                mydm.SetPath(path);
                mydm.Capture(0, 0, width, height, fileName);
            }
            
        }

        public void captureBmpOnce(string path, string fileName)
        {
            //循环绑定 绑定成功才截图
            int width = 0;
            int height = 0;
            mydm.GetClientSize(getJubing(), out width, out height);
            mydm.SetPath(path);
            mydm.Capture(0, 0, width, height, fileName);
            

        }

        public string suijizifu()
        {
            string uuidN = Guid.NewGuid().ToString("N");
            WriteLog.WriteLogFile(this.moniqiname, uuidN);
            return uuidN;
        }

        public char[] suijiachar(){
            string uuidN = Guid.NewGuid().ToString("N").Substring(0,5);
            char[] s = uuidN.ToCharArray();
            return s;
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
        public string myqudianquse(Int32 fir,string off,int sim,int x0,int y0,int x1,int y1){
            //适用FindMultiColor方法
            int res = bindWindow(jubing);
            if (!(res > 0) )
            {
                WriteLog.WriteLogFile("","绑定不成功 "+res);
                
            }
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
        public void myqudianqusezuobiao(Int32 fir, string off, int sim, int x0, int y0, int x1, int y1,out int ox,out int oy)
        {
            //适用FindMultiColor方法
            int res = bindWindow(jubing);
            if (!(res > 0))
            {
                WriteLog.WriteLogFile("", "绑定不成功 " + res);

            }
            string result = "-1|-1";
            string firstColor = fir.ToString("X");
            string offsetColor = off.Replace("|0x", "|");
            double isim = sim * 0.01;
            result = mydm.FindMultiColorE(x0, y0, x1, y1, firstColor, offsetColor, isim, 1);
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
        public Boolean pingmuquanhei2()
        {
            string result = "-1|-1";
            result = myqudianquse(0x000000, "13|55|0x000000,45|167|0x000000,53|203|0x000000,169|273|0x000000,310|305|0x000000,244|49|0x000000,-41|269|0x000000,-15|107|0x000000,588|312|0x000000", 90, 0, 0, 959, 539);
            string[] a1 = result.Split('|');
            string result2 = "-1|-1";
            result2 = myqudianquse(0xe6dcd0, "-29|-27|0xfffff7,766|-334|0xb5b7b8,462|-42|0x006896,316|-152|0x0a0d11,82|21|0x737573,-45|-67|0x5b5a5b,-11|-44|0x5d5d45", 90, 0, 0, 959, 539);
            string[] a2 = result2.Split('|');
            int a = suijishu(0, 10);
            if (int.Parse(a1[0]) != -1 && int.Parse(a2[0]) == -1 && a <5)
            {
                WriteLog.WriteLogFile("", "屏幕全黑无法截图");
                return true;
            }            
            return false;
        }

        public void UnBindWindow() {
            mydm.UnBindWindow();
        }
    }
}
