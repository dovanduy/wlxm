using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections;
using System.Threading;
using LuciferSrcipt;
namespace MyUtil
{
    public class MyLdcmd

    {
        private static ReaderWriterLockSlim LogWriteLock = new ReaderWriterLockSlim();

        /// <summary>
        /// 模拟器安装的地址
        /// </summary>
        private static string lcddizhi = @"C:\ChangZhi\dnplayer2\";
        private static LdCmd ld;
        /// <summary>
        /// 多开器工具的地址C
        /// </summary>
        private static string appNamec = @"C:\Users\Administrator\Desktop\雷电多开器.lnk";
        /// <summary>
        /// 多开器工具的地址d
        /// </summary>
        private static string appNamed = @"D:\ChangZhi\dnplayer2\dnmultiplayer.exe";

        
        /// <summary>
        /// 模拟器路径
        /// </summary>
        public string SimulatorPath { get; set; }
        #region 单例模式变量
        private static readonly object obj = new object();
        private static MyLdcmd ldCmd = null;
        #endregion

        
        static MyLdcmd()
        {
            ld = LdCmd.GetObject();
            //ld.SimulatorPath = lcddizhi;
        }

        public static void setDizhi(string dizhi) {
            lcddizhi = dizhi;
        }

        /// <summary>
        /// 单例模式====双层互锁
        /// </summary>
        /// <returns></returns>
        public static MyLdcmd GetObject(string dizhi=@"d:\ChangZhi\dnplayer2\")
        {
            if (ldCmd == null)
            {
                lock (obj)
                {
                    if (ldCmd == null)
                    {
                        ldCmd = new MyLdcmd();
                        setDizhi(dizhi);
                        ld.SimulatorPath = lcddizhi;
                    }
                }
            }
            setDizhi(dizhi);
            ld.SimulatorPath = lcddizhi;
            return ldCmd;
        }

        public static LdCmd getLdCmd() {
            
            return ld;
        }
        /// <summary>
        /// 执行CMD窗口信息
        /// </summary>
        /// <param name="value">模拟器命令</param>
        /// <returns>执行后的信息</returns>
        private string ImplementCmd(string value)
        {
            Process p = new Process();
            //设置要启动的应用程序
            p.StartInfo.FileName = "cmd.exe";
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardInput = true;
            //输出信息
            p.StartInfo.RedirectStandardOutput = true;
            // 输出错误
            p.StartInfo.RedirectStandardError = true;
            //不显示程序窗口
            p.StartInfo.CreateNoWindow = true;
            //启动程序
            p.Start();
            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(value);
            p.StandardInput.WriteLine("exit");
            p.StandardInput.AutoFlush = true;
            //获取输出信息
            string strOuput = p.StandardOutput.ReadToEnd();
            //等待程序执行完退出进程
            p.WaitForExit();
            p.Close();
            return strOuput;
        }

        /// <summary>
        /// 保存指定模拟器的备份
        /// </summary>
        private void backUp(int ind,string path)
        {
            try
            {
                LogWriteLock.EnterWriteLock();
                lock (obj)
                {

                    ImplementCmd(
                        string.Format("{0}ldconsole backup --index {1} --file {2}",
                        SimulatorPath, ind, path + ".ldbk"));


                }
            }
            catch { }
            finally
            {
                LogWriteLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// 打开模拟器并启动程序
        /// </summary>
        /// <param name="index">模拟器序号</param>
        /// <returns></returns>
        public string Launch(int index)
        {
            lock (obj)
            {
                return ImplementCmd(
                    string.Format("{0}dnconsole modify --index {1} --resolution 600,360,160 --cpu 1 --memory 1024 --imei auto",
                    SimulatorPath,index));
            }
        }

        /// <summary>
        /// fuyuan备份
        /// </summary>
        private void restore(int ind, string seed)
        {
            
            lock (obj)
            {

                ImplementCmd(
                    string.Format("{0}ldconsole restore --index {1} --file {2}",
                    SimulatorPath, ind, seed + ".ldbk"));
                WriteLog.WriteLogFile("", string.Format("{0}ldconsole restore --index {1} --file {2}",
                    SimulatorPath, ind, seed + ".ldbk"));

            }
        }

        /// <summary>
        /// 指定模拟器改名
        /// </summary>
        private void rename(int ind, string name)
        {
            
            lock (obj)
            {

                ImplementCmd(
                    string.Format("{0}ldconsole rename --index {1} --title {2}",
                    SimulatorPath, ind, name ));
                WriteLog.WriteLogFile("", string.Format("{0}ldconsole rename --index {1} --title {2}",
                    SimulatorPath, ind, name ));

            }                        
        }

        /// <summary>
        /// 指定模拟器改名
        /// </summary>
        private void reboot(int ind)
        {

            lock (obj)
            {

                ImplementCmd(
                    string.Format("{0}ldconsole reboot --index {1}",
                    SimulatorPath, ind));
                WriteLog.WriteLogFile(""+ind, string.Format("{0}ldconsole reboot --index {1}",
                    SimulatorPath, ind));

            }
        }

        /// <summary>
        /// 传出文件
        /// </summary>
        private void pullFile(int ind, string path,string mnqname)
        {
           lock (obj)
           {
                ImplementCmd(
                string.Format("{0}ldconsole pull --index {1} --remote {2} --local {3}",
                SimulatorPath, ind, mnqname, path));
                WriteLog.WriteLogFile(ind+"", string.Format("{0}ldconsole pull --index {1} --remote {2} --local {3}",
                SimulatorPath, ind, mnqname, path));
           }
                        
        }
        /// <summary>
        /// 查看已创建的模拟器状态 PS：依次是：索引,标题,顶层窗口句柄,绑定窗口句柄,是否进入android,进程PID,VBox进程PID
        /// </summary>
        /// <returns>返回List集合</returns>
        public List<string> ListSimulator()
        {
            lock (obj)
            {
                List<string> list = new List<string>();
                string[] str = Regex.Split(ImplementCmd(
                    string.Format("{0}ldconsole list2",
                    SimulatorPath)), "\r\n", RegexOptions.IgnoreCase);
                for (int i = 4; i < (str.Length - 3); i++)
                {
                    list.Add(str[i]);
                }
                return list;
            }
        }
        /// <summary>
        /// 查看已创建的模拟器状态 PS：依次是：索引,标题,顶层窗口句柄,绑定窗口句柄,是否进入android,进程PID,VBox进程PID
        /// </summary>
        /// <returns>直接返回List集合</returns>
        public static List<String> GetListSimulator(string dizhi) 
        {
            MyLdcmd myldcmd = MyLdcmd.GetObject(dizhi);
            List<string> slist = ld.ListSimulator();
            if ((slist.Count > 0)) {
                return slist;
            }
            myldcmd.SimulatorPath = ld.SimulatorPath;
            slist = myldcmd.ListSimulator();            
            return slist;
        }
        /// <summary>
        /// 得到当前模拟器的index数组
        /// </summary>
        /// <param name="ldcmd"></param>
        /// <returns></returns>
        public static int[] getDqmoniqiIndex(string dizhi=@"d:\ChangZhi\dnplayer2\")
        {

            List<string> slist = MyLdcmd.GetListSimulator(dizhi);
            int[] result = new int[slist.Count];
            int i = 0;
            foreach (string s in slist)
            {
                string[] a = s.Split(',');
                result[i] = int.Parse(a[0]);
                i++;
            }

            return result;

        }
        /// <summary>
        /// 得到当前模拟器index+“|”+是否进入android的数组
        /// </summary>
        /// <param name="ldcmd"></param>
        /// <returns></returns>
        public static string[] getDqmoniqiJinRuAnd(string dizhi)
        {

            List<string> slist = MyLdcmd.GetListSimulator(dizhi);
            string[] result = new string[slist.Count];
            int i = 0;
            foreach (string s in slist)
            {
                string[] a = s.Split(',');
                result[i] = a[0] + "|" +a[1]+"|"+ a[4];
                i++;
            }

            return result;

        }
        /// <summary>
        /// 得到当前模拟器的外层句柄和索引
        /// </summary>
        /// <param name="ldcmd"></param>
        /// <returns></returns>
        public static string[] getDqmoniqiWaiCengJuBing(string dizhi= @"d:\ChangZhi\dnplayer2\")
        {

            List<string> slist = MyLdcmd.GetListSimulator(dizhi);
            string[] result = new string[slist.Count];
            int i = 0;
            foreach (string s in slist)
            {
                string[] a = s.Split(',');
                result[i] = a[0] + "|" + a[2];
                i++;
            }

            return result;

        }
        /// <summary>
        /// 得到当前模拟器的句柄和索引
        /// </summary>
        /// <param name="ldcmd"></param>
        /// <returns></returns>
        public static string[] getDqmoniqiJuBing(string dizhi = @"d:\ChangZhi\dnplayer2\")
        {

            List<string> slist = MyLdcmd.GetListSimulator(dizhi);
            string[] result = new string[slist.Count];
            int i = 0;
            foreach (string s in slist)
            {
                string[] a = s.Split(',');
                result[i] = a[0] + "|" + a[3];
                i++;
            }

            return result;

        }

 
       


        /// <summary>
        /// 根据索引值得到句柄
        /// </summary>
        /// <param name="dqindex"></param>
        /// <returns></returns>
        public static int getDqmoniqiJuBingByIndex(int dqindex, string dizhi = @"d:\ChangZhi\dnplayer2\")
        {

            string[] getApp = getDqmoniqiJuBing(dizhi);
            foreach (string s in getApp)
            {
                string[] b = s.Split('|');
                int zt = int.Parse(b[1]);
                int ind = int.Parse(b[0]);
                if (dqindex == ind && zt != 1)
                {

                    return zt;
                }
            }

            return -1;

        }


        /// <summary>
        /// 根据索引值得到外层窗口句柄
        /// </summary>
        /// <param name="dqindex"></param>
        /// <returns></returns>
        public static int getDqmoniqiWaiCengJuBingByIndex(int dqindex, string dizhi)
        {

            string[] getApp = getDqmoniqiWaiCengJuBing(dizhi);
            foreach (string s in getApp)
            {
                string[] b = s.Split('|');
                int zt = int.Parse(b[1]);
                int ind = int.Parse(b[0]);
                if (dqindex == ind && zt != 1)
                {

                    return zt;
                }
            }

            return -1;

        }

        /// <summary>
        /// 得到当前活动的模拟器名称组
        /// </summary>
        /// <returns></returns>
        public static string[] getDqmoniqiHuodong(string dizhi)
        {

            string[] getApp = MyLdcmd.getDqmoniqiJinRuAnd(dizhi);
            int mysize = getApp.Length;
            if (mysize <= 0) {
                mysize = 1;
            }
            
            string[] result = new string[mysize];
            int i=0;
            foreach (string s in getApp)
            {
                string[] b = s.Split('|');
                int zt = int.Parse(b[2]);
                int ind = int.Parse(b[0]);
                if ( zt == 1)
                {
                    result[i] = b[0]+"|"+b[1];
                }
                i++;
            }

            return result;

        }
        /// <summary>
        /// 仅得到活动模拟器的index
        /// </summary>
        /// <returns></returns>
        public static int[] getDqmoniqiHuodongIndex(string dizhi)
        {

            string[] getApp = MyLdcmd.getDqmoniqiJinRuAnd(dizhi);
            int mysize = getApp.Length;
            if (mysize <= 0)
            {
                mysize = 1;
            }

            int[] result = new int[mysize];
            int i = 0;
            foreach (string s in getApp)
            {
                string[] b = s.Split('|');
                int zt = int.Parse(b[2]);
                int ind = int.Parse(b[0]);
                if (zt == 1)
                {
                    result[i] = ind;

                }
                else {
                    result[i] = -1;
                }
                i++;
            }

            return result;

        }
        /// <summary>
        /// 根据模拟器的句柄得到模拟器的名字
        /// </summary>
        /// <param name="jubing"></param>
        /// <returns></returns>
        public static string getMoniqiNameByJubing(int jubing,string dizhi) {
            string[] getApp = getDqmoniqiJuBing(dizhi);
            int dqindex = -1;
            string rs = null;
            foreach (string s in getApp)
            {
                string[] b = s.Split('|');
                int zt = int.Parse(b[1]);
                int ind = int.Parse(b[0]);
                if (jubing == zt)
                {

                    dqindex= ind;
                }
            }
            string[] getApp2 = MyLdcmd.getDqmoniqiJinRuAnd(dizhi);
            foreach (string s in getApp2)
            {
                string[] b = s.Split('|');
                int zt = int.Parse(b[2]);
                int ind = int.Parse(b[0]);
                string name = b[1];
                if (dqindex == ind)
                {

                    rs = name;
                }
            }
            return rs;
        }


        /// <summary>
        /// 根据模拟器的index得到模拟器的名字
        /// </summary>
        /// <param name="dqindex"></param>
        /// <returns></returns>
        public static string getMoniqiNameByIndex(int dqindex,string dizhi) {
            string[] getApp2 = MyLdcmd.getDqmoniqiJinRuAnd(dizhi);
            string rs = null;
            foreach (string s in getApp2)
            {
                string[] b = s.Split('|');
                int zt = int.Parse(b[2]);
                int ind = int.Parse(b[0]);
                string name = b[1];
                if (dqindex == ind)
                {

                    rs = name;
                }
            }
            return rs;    
        }

        

        

        public static void myQuitAll(string dizhi)
        {
            MyLdcmd myldcmd = MyLdcmd.GetObject(dizhi);
            MyFuncUtil.killProcess("dnplayer");
            Thread.Sleep(10000);
            int[] abcd = getDqmoniqiHuodongIndex(dizhi);
            foreach (var a in abcd)
            {
                if (a == -1) continue;
                while (true)
                {
                    int[] abc = getDqmoniqiHuodongIndex(dizhi);
                    ArrayList ar = new ArrayList();//实例化一个ArrayList
                    ar.AddRange(abc);//把数组赋到Arraylist对象
                    if (ar.Contains(a))
                    {
                        MyFuncUtil.mylogandxianshi("关闭模拟器" + a);
                        ld.Quit(a);
                    }
                    if (!ar.Contains(a))
                    {
                        MyFuncUtil.mylogandxianshi("模拟器" + a + ",关闭成功");
                        break;
                    }
                }
            }
        }

        public static void myLaunch1(int index,string dizhi)
        {
            MyLdcmd myldcmd = MyLdcmd.GetObject(dizhi);
            Int64 kstime = MyFuncUtil.GetTimestamp();
            while (true)
            {
                ld.Launch(index);
                Thread.Sleep(20000);
                int[] abc = getDqmoniqiHuodongIndex(dizhi);
                if (abc.Contains(index))
                {
                    break;
                }
                Int64 jstime = MyFuncUtil.GetTimestamp();
                if ((jstime - kstime) > 1000 * 60 * 5)
                {
                    MyFuncUtil.mylogandxianshi("打开很久5分钟也没打开" + index);
                    break;
                }
            }
        }

        public static void myBackup(int index,string path,string dizhi)
        {

            MyLdcmd myldcmd = MyLdcmd.GetObject(dizhi);
            myldcmd.SimulatorPath = ld.SimulatorPath;
            myldcmd.backUp(index, path);
        }

        public static void myRename(int index, string name, string dizhi)
        {

            MyLdcmd myldcmd = MyLdcmd.GetObject(dizhi);
            myldcmd.SimulatorPath = ld.SimulatorPath;
            myldcmd.rename(index, name);
        }

        public static void myRestore(int index, string seed,string dizhi)
        {
            MyLdcmd myldcmd = MyLdcmd.GetObject(dizhi);
            myldcmd.SimulatorPath = ld.SimulatorPath;
            lock(obj){
                myldcmd.restore(index, seed);
                Thread.Sleep(1000*20);
            }
        }

        public static void myDownCpu(int index, int rate, string dizhi = @"d:\ChangZhi\dnplayer2\")
        {
            MyLdcmd myldcmd = MyLdcmd.GetObject(dizhi);
            myldcmd.SimulatorPath = ld.SimulatorPath;
            string a="";
            lock (obj)
            {
                a=ld.Downcpu(index, rate);
            }
            WriteLog.WriteLogFile(index + "", a);
        }

        public static void myReboot(int index, string dizhi = @"d:\ChangZhi\dnplayer2\")
        {
            MyLdcmd myldcmd = MyLdcmd.GetObject(dizhi);
            myldcmd.SimulatorPath = ld.SimulatorPath;

            myldcmd.reboot(index);
            
        }


        public static void myRemoveAll(string dizhi)
        {
            MyLdcmd myldcmd = MyLdcmd.GetObject(dizhi);
            while (true)
            {
                int[] moniqiIndex = getDqmoniqiIndex(dizhi);
                foreach (int i in moniqiIndex)
                {
                    if (i == 0) continue;
                    ld.RemoveSimulator(i);
                    MyFuncUtil.mylogandxianshi(i + "个模拟器开始移除");
                    Thread.Sleep(10000);
                }
                if (moniqiIndex.Length == 1) break;
            }
        }

        public static void myRemove(int dqinx, string dizhi = @"d:\ChangZhi\dnplayer2\")
        {
            MyLdcmd myldcmd = MyLdcmd.GetObject(dizhi);
            int[] moniqiIndex = getDqmoniqiIndex(dizhi);
            lock (obj)
            {
                if (moniqiIndex.Contains(dqinx))
                {
                    ld.RemoveSimulator(dqinx);
                }
            }
            WriteLog.WriteLogFile(dqinx+"",dqinx+"号模拟器已经移除");            
        }

        public static void myCopySimulator(int shuliang,string dizhi)
        {
            MyLdcmd myldcmd = MyLdcmd.GetObject(dizhi);
            int i = 0;
            while (true)
            {
                MyFuncUtil.mylogandxianshi((i++) + "个模拟器开始复制");
                int[] moniqiIndex = getDqmoniqiIndex(dizhi);
                try
                {
                    LogWriteLock.EnterWriteLock();
                    ld.CopySimulator(0);
                }
                catch { }
                finally
                {
                    LogWriteLock.ExitWriteLock();
                }                
                Thread.Sleep(40000);
                if (moniqiIndex.Length >= shuliang) break;
            }
            
        }

        /// <summary>
        /// 指定模拟器是否运行
        /// </summary>
        private string isrunning(int ind, string path)
        {
            lock (obj)
            {
                return ImplementCmd(
                    string.Format("{0}ldconsole isrunning --index {1}",
                    SimulatorPath, ind));
            }
        }
        public static string IsRunning(int index, string path, string dizhi)
        {
            MyLdcmd myldcmd = MyLdcmd.GetObject(dizhi);
            myldcmd.SimulatorPath = ld.SimulatorPath;
            string a= myldcmd.isrunning(index, path);
            string[] str = Regex.Split(a, "\r\n", RegexOptions.IgnoreCase);
            foreach(string ab in str){
                //WriteLog.WriteLogFile("", a);
            }
            return str[4];
        }



        public static void myScreencap(int index, string path, string dizhi = @"d:\ChangZhi\dnplayer2\")
        {
            MyLdcmd myldcmd = MyLdcmd.GetObject(dizhi);
            string zd = "/sdcard/screencap.png";
            string a = ld.Screencap(index, zd);
            WriteLog.WriteLogFile(index+"", a);
            Thread.Sleep(3000);
            myldcmd.SimulatorPath = ld.SimulatorPath;
            myldcmd.pullFile(index, path, zd);
         }

        public static void myScreencapLuneng(int index, string path,string sdcardpath="Pictures")
        {
            MyLdcmd myldcmd = MyLdcmd.GetObject();
            string zd = "/sdcard/"+sdcardpath;
            myldcmd.SimulatorPath = ld.SimulatorPath;
            myldcmd.pullFile(index, path, zd);
        }

        public static void mySort(string a_b)
        {
            string dizhi = null;
            if (a_b.ToLower().Equals("c"))
            {
                dizhi = @"C:\ChangZhi\dnplayer2\";
            }
            if (a_b.ToLower().Equals("d"))
            {
                dizhi = @"D:\ChangZhi\dnplayer2\";
            }
            MyLdcmd myldcmd = MyLdcmd.GetObject(dizhi);
            myldcmd.SimulatorPath = ld.SimulatorPath;
            string a = ld.SortWnd();
            WriteLog.WriteLogFile("", a);
        }

        public static void myLaunch(string dizhi,int dqinx,string apkname)
        {
            MyLdcmd myldcmd = MyLdcmd.GetObject(dizhi);
            myldcmd.SimulatorPath = ld.SimulatorPath;
            string a = myldcmd.Launch(dqinx);
            WriteLog.WriteLogFile("", a);
        }

        public static void myClearAppData(string dizhi, int dqinx, string apkname)
        {
            MyLdcmd myldcmd = MyLdcmd.GetObject(dizhi);
            myldcmd.SimulatorPath = ld.SimulatorPath;
            string a = ld.ClearAppData(dqinx, apkname);
            WriteLog.WriteLogFile("", a);
        }

        public static void ClearAndCopySimulator(string a_b)
        {
            MyFuncUtil.mylogandxianshi("关闭全部模拟器");
            string dizhi = null;
            string path = null;
            string seed = null;
            MyFuncUtil.myqiehuancd(a_b, out dizhi, out path, out seed);
            MyLdcmd myldcmd = MyLdcmd.GetObject(dizhi);
            myQuitAll(dizhi);
            Thread.Sleep(20000);
            MyFuncUtil.mylogandxianshi("删除全部模拟器");
            myRemoveAll(dizhi);
            Thread.Sleep(20000);
            MyFuncUtil.mylogandxianshi("模拟器0复原");
            myRestore(0, seed, dizhi);
            Thread.Sleep(30000);
            MyFuncUtil.mylogandxianshi("开始模拟器复制");
            int sl = 0;
            if (a_b.ToLower().Equals("c"))
            {
                sl = 19;
            }
            if (a_b.ToLower().Equals("d"))
            {
                sl = 21;
            }
            myCopySimulator(sl, dizhi);
            Thread.Sleep(20000);
        }
        /// <summary>
        /// 新建模拟器并得到新建模拟器的index
        /// </summary>
        public static int addSimulator()
        {
            int res = -1;
            MyLdcmd myldcmd = MyLdcmd.GetObject();
            lock (obj)
            {
                int[] dq = getDqmoniqiIndex();
                foreach (int a in dq) {
                    //WriteLog.WriteLogFile("", a+"号模拟器");
                }
                ld.AddSimulator();
                int[] dq2 = getDqmoniqiIndex();
                foreach (int a in dq2)
                {
                    //WriteLog.WriteLogFile("", "新增后,"+a + "号模拟器");
                }
                foreach (int a in dq2) {
                    if (!dq.Contains<int>(a)) {
                        res = a;
                        modifySimulator(res);
                        WriteLog.WriteLogFile("", res + "号模拟器是新增的");
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// 修改模拟器默认属性设置
        /// </summary>
        public static void modifySimulator(int index)
        {
            MyLdcmd myldcmd = MyLdcmd.GetObject();
            lock (obj)
            {
                myldcmd.ImplementCmd(string.Format("{0}dnconsole modify --index {1} --resolution 540,960,240 --cpu 1 --memory 1024 --imei auto", myldcmd.SimulatorPath, index));
                WriteLog.WriteLogFile(index + "", string.Format("{0}dnconsole modify --index {1} --resolution 540,960,240 --cpu 1 --memory 1024 --imei auto", myldcmd.SimulatorPath, index));
            }
        }


        /// <summary>
        /// 安装路人到模拟器
        /// </summary>
        public static void installLuren(int dqinx)
        {
            try
            {
                LogWriteLock.EnterReadLock();
                lock (obj)
                {
                    ld.InstallAPP(dqinx, @"C:\迅雷下载\android_ld_v21410_0_LE0S0N30000_idreamsky_sign.apk");
                    //MyFuncUtil.killProcess("LdBoxSVC.exe");
                }
            }
            catch (Exception ex) {
                WriteLog.WriteLogFile(dqinx+"", ex.Message);
                throw ex; }
            finally
            {
                LogWriteLock.ExitReadLock();
            }
            Thread.Sleep(1000 * 20);
        }


        /// <summary>
        /// 安装app到模拟器
        /// </summary>
        public static void installApp(int dqinx,string apppath)
        {
            try
            {
                LogWriteLock.EnterReadLock();
                lock (obj)
                {
                    ld.InstallAPP(dqinx, apppath);
                    //MyFuncUtil.killProcess("LdBoxSVC.exe");
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteLogFile(dqinx + "", ex.Message);
                throw ex;
            }
            finally
            {
                LogWriteLock.ExitReadLock();
            }
            Thread.Sleep(1000 * 20);
        }

        /// <summary>
        /// 得到模拟器所有包名 用于检测指定游戏是否安装
        /// </summary>
        public static List<string> getallApp(int dqinx)
        {
            List<string> rs = new List<string>();
            lock (obj)
            {
                string a=ld.OutputAllPackages(dqinx);
                string[] str = Regex.Split(a, "\r\n", RegexOptions.IgnoreCase);
                foreach (string ab in str)
                {
                    //WriteLog.WriteLogFile("", ab);
                    if (ab.IndexOf("package") >= 0) {
                        rs.Add(ab.Trim());
                    }
                }
            }
            return rs;
        }

        /// <summary>
        /// 路人是否安装成功
        /// </summary>
        public static bool lurenisok(int dqinx)
        {
            bool rs = false;
            List<string> ab = getallApp(dqinx);
            foreach (string a in ab)
            {
                //WriteLog.WriteLogFile("", a);
                //WriteLog.WriteLogFile("", a.Equals("package:com.idreamsky.psycho100")+"");
            }
            if (ab.Contains("package:com.idreamsky.psycho100"))
            {
                rs = true;
            }
            return rs;
        }

        /// <summary>
        /// 路人是否安装成功
        /// </summary>
        public static bool jingjieisok(int dqinx,string package)
        {
            bool rs = false;
            List<string> ab = getallApp(dqinx);
            foreach (string a in ab)
            {
                //WriteLog.WriteLogFile("", a);
                //WriteLog.WriteLogFile("", a.Equals(package) + "");
            }
            if (ab.Contains(package))
            {
                rs = true;
            }
            return rs;
        }


        public static void RunDuokaiqi(string a_b)
        {
            WriteLog.WriteLogFile("", "打开多开器");
            MyFuncUtil.killProcess("dnmultiplayer");
            Thread.Sleep(10000);
            Process p = new Process();
            if (a_b.ToLower().Equals("c"))
            {
                p.StartInfo.FileName = appNamec;
            }
            if (a_b.ToLower().Equals("d"))
            {
                p.StartInfo.FileName = appNamed;
            }            
            //启动程序
            p.Start();
            WriteLog.WriteLogFile("", "结束打开多开器2");
           
        }
    }
}
