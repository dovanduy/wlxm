﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;


namespace SH_MyUtil
{
    public class ShouHu
    {
        public static int BanBenHao =13;
        private static readonly object obj = new object();
        public void wohaihuozhe() {
            WriteLog.WriteLogFile("生命的迹象 "+MyFuncUtil.suijishu(1,100));
        }
        private string[] PCNAMES = new string[] { "1HAO", "2HAO", "3HAO", "WLZHONGKONG" };
        public bool panDuanChongQi(string pcname)
        {
            SqlHelp sqh = SqlHelp.GetInstance();
            lock (obj)
            {
                try
                {
                    string pn = "";
                    switch (pcname)
                    {
                        case "1HAO":
                            pn = "hao1chanchu";
                            break;
                        case "2HAO":
                            pn = "hao2xiugai";
                            break;
                        case "3HAO":
                            pn = "hao3xiugai";
                            break;
                        case "WLZHONGKONG":
                            pn = "zkxiugai";
                            break;
                        default:
                            break;
                    }
                    if (pn == null || pn.Equals(""))
                    {
                        return false;
                    }
                    string sqlsel = "select a1.cc-a2.cc from (select xh," +
                    pn + " cc from yunxingqk where xh in( "
                    + "select max(xh) zd from yunxingqk)) a1,(select xh," + pn + " cc from yunxingqk "
                    + " where xh in(select max(xh)-1 cd from yunxingqk)) a2";
                    DataTable dt = sqh.getAll(sqlsel);
                    if (dt.Rows.Count > 0)
                    {
                        int a = (int)dt.Rows[0][0];
                        WriteLog.WriteLogFile("更新运行情况差异值 " + a);
                        if (a == 0)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public bool panDuanChongQiByUpdate(string pcname, string[] pcnames)
        {
            SqlHelp sqh = SqlHelp.GetInstance();
            lock (obj)
            {
                try
                {
                    int r = 0;
                    for (int i = 0; i < pcnames.Length; i++)
                    {
                        if (pcname.ToUpper().Equals(pcnames[i].ToUpper()))
                        {
                            r = i;
                        }
                    }
                    int r1 = 0;
                    string sqlsel = "select xh,pcxiugai from jiankong where xh in( select max(xh) zd from jiankong)";
                    DataTable dt = sqh.getAll(sqlsel);
                    if (dt.Rows.Count > 0)
                    {
                        string quan = (string)dt.Rows[0][1];
                        string[] quanzu = quan.Split('|');
                        r1 = int.Parse(quanzu[r]);
                        WriteLog.WriteLogFile("r1:" + r1);
                    }
                    int r2 = -1;
                    sqlsel = "select xh,pcxiugai from jiankong where xh in( select max(xh)-1 zd from jiankong)";
                    dt = sqh.getAll(sqlsel);
                    if (dt.Rows.Count > 0)
                    {
                        string quan = (string)dt.Rows[0][1];
                        string[] quanzu = quan.Split('|');
                        r2 = int.Parse(quanzu[r]);
                        WriteLog.WriteLogFile("r2:" + r2);
                    }
                    if (r1 == r2)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public DateTime getYunXingQkLasttime()
        {
            SqlHelp sqh = SqlHelp.GetInstance();
            lock (obj)
            {
                try
                {
                    DataTable dt = sqh.getAll("select max(gxsj) from yunxingqk ");
                    if (dt.Rows.Count > 0)
                    {
                        return (DateTime)dt.Rows[0][0];
                    }
                    return DateTime.MaxValue;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
        public void gxYunXingQk1(string youxi)
        {
            //得到运行情况后存入表
            WriteLog.WriteLogFile("得到运行情况后存入表");
            SqlHelp sqh = SqlHelp.GetInstance();
            lock (obj)
            {
                try
                {
                    YunXingQK jqqk = new YunXingQK();
                    string selsql = "select " +
                        "sum(case when  z.pcname='1hao' and z.xgsj>=convert(varchar(10),getdate(),120) then 1 else 0 end)  hao1chanshu," +
                        "sum(case when  z.pcname='2hao' and z.xgsj>=convert(varchar(10),getdate(),120) then 1 else 0 end)  hao2xiugai," +
                        "sum(case when  z.pcname='2hao' and z.zuanshi>0 and z.xgsj>=convert(varchar(10),getdate(),120) then 1 else 0 end)  hao2chanshu," +
                        "sum(case when  z.pcname='3hao' and z.xgsj>=convert(varchar(10),getdate(),120) then 1 else 0 end)  hao3xiugai," +
                        "sum(case when  z.pcname='3hao' and z.zuanshi>0 and z.xgsj>=convert(varchar(10),getdate(),120) then 1 else 0 end)  hao2chanshu," +
                        "sum(case when  z.pcname='wlzhongkong' and z.xgsj>=convert(varchar(10),getdate(),120) then 1 else 0 end)  zkxiugai," +
                        "sum(case when  z.pcname='wlzhongkong' and z.zuanshi>0 and z.xgsj>=convert(varchar(10),getdate(),120) then 1 else 0 end)  zkchanshu," +
                        "sum(case when z.zuanshi>0  then 1 else 0 end)  zuanshidayu0," +
                        "sum(case when z.zuanshi>1000  then 1 else 0 end)  zuanshidayu1000," +
                        "sum(case when z.zuanshi>3000  then 1 else 0 end)  zuanshidayu3000," +
                        "sum(case when z.qiangzhequan>0  then 1 else 0 end)  qiangzhedayu0," +
                        "sum(case when z.xgsj>=convert(varchar(10),getdate(),120) then 1 else 0 end)  zxiugai" +
                        " from zhanghao z ";
                    //where youxi='" + youxi + "'";

                    DataTable dt = sqh.getAll(selsql);
                    int a = dt.Rows.Count;
                    if (dt.Rows.Count > 0)
                    {
                        Dictionary<string, JiQiYunXing> dict = new Dictionary<string, JiQiYunXing>();
                        JiQiYunXing jq1 = new JiQiYunXing();
                        jq1.Chuchan = (int)dt.Rows[0][0];
                        dict.Add("hao1", jq1);
                        JiQiYunXing jq2 = new JiQiYunXing();
                        jq2.Xiugai = (int)dt.Rows[0][1];
                        jq2.Chuchan = (int)dt.Rows[0][2];
                        dict.Add("hao2", jq2);
                        JiQiYunXing jq3 = new JiQiYunXing();
                        jq3.Xiugai = (int)dt.Rows[0][3];
                        jq3.Chuchan = (int)dt.Rows[0][4];
                        dict.Add("hao3", jq3);
                        JiQiYunXing zk = new JiQiYunXing();
                        zk.Xiugai = (int)dt.Rows[0][5];
                        zk.Chuchan = (int)dt.Rows[0][6];
                        dict.Add("zk", zk);
                        jqqk.Jqyx = dict;
                        jqqk.Zuanshidayu0 = (int)dt.Rows[0][7];
                        jqqk.Zuanshidayu1000 = (int)dt.Rows[0][8];
                        jqqk.Zuanshidayu3000 = (int)dt.Rows[0][9];
                        jqqk.Qiangzhedayu0 = (int)dt.Rows[0][10];
                        jqqk.Xgsj = DateTime.Now;
                        jqqk.Zongxiugai = (int)dt.Rows[0][11];
                        WriteLog.WriteLogFile("当前运行机器的出产情况" + jqqk.Zongxiugai + "单独:" + jqqk.Jqyx["hao1"].Chuchan + " " + jqqk.Jqyx["hao2"].Chuchan + "  " + jqqk.Jqyx["hao3"].Chuchan + " " + jqqk.Jqyx["zk"].Chuchan);
                    }
                    string inssql = "insert into yunxingqk (hao1chanchu,hao2xiugai,hao2chanchu,hao3xiugai,hao3chanchu,zkxiugai,zkchanchu,zuanshidayu0,zuanshidayu1000,zuanshidayu3000,qiangzhedayu0,gxsj,zxiugai) values("
                        + jqqk.Jqyx["hao1"].Chuchan + "," + jqqk.Jqyx["hao2"].Xiugai + "," + jqqk.Jqyx["hao2"].Chuchan
                        + "," + jqqk.Jqyx["hao3"].Xiugai + "," + jqqk.Jqyx["hao3"].Chuchan
                        + "," + jqqk.Jqyx["zk"].Xiugai + "," + jqqk.Jqyx["zk"].Chuchan
                        + "," + jqqk.Zuanshidayu0 + "," + jqqk.Zuanshidayu1000
                        + "," + jqqk.Zuanshidayu3000 + "," + jqqk.Qiangzhedayu0 + ",'" + jqqk.Xgsj + "'," + jqqk.Zongxiugai + ")";
                    sqh.update(inssql);
                }
                catch (Exception ex)
                {
                    WriteLog.WriteLogFile("更新运行情况失败");
                    throw ex;
                }
            }
        }
        public void shouhuzhong()
        {
            MyFuncUtilNoJingTai my = new MyFuncUtilNoJingTai();
            long ks = my.GetTimestamp();
            long ks2 = my.GetTimestamp();
            long ks3 = my.GetTimestamp();
            long ks4 = my.GetTimestamp();
            long ks5 = my.GetTimestamp();
            long ks6 = my.GetTimestamp();
            long ks7 = my.GetTimestamp();
            long ks8 = my.GetTimestamp();
            long ks9 = my.GetTimestamp();
            int duokai = 0;
            int ksgx = 0;
            int ksck = 0;
            while (true)
            {
                if (ksgx == 0) {
                    System.Threading.Thread.Sleep(1000 * 10);
                    ksgx = 1;
                    WriteLog.WriteLogFile("第一次打开要更新" + System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\program\\wlxm.exe") + " " + System.Windows.Forms.Application.StartupPath + "\\program\\wlxm.exe");
                    UpdateCaoZuo sh = new UpdateCaoZuo();
                    sh.updateWlxm();
                }
                if (ksck == 0)
                {
                    System.Threading.Thread.Sleep(1000 * 30);
                    ksck = 1;
                    WriteLog.WriteLogFile("第一次打开要看否打开了wlxm" + System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\program\\wlxm.exe") + " " + System.Windows.Forms.Application.StartupPath + "\\program\\wlxm.exe");
                    bool t = false;
                    string appname = "wlxm";
                    int a = 0;
                    Process[] processes = Process.GetProcessesByName(appname);
                    foreach (Process process in processes)
                    {
                        if (a==0 && process.ProcessName == appname )
                        {
                            t = true;
                            a = 1;
                            break;
                        }
                    }
                    if (!t)
                    {
                        string appNamec = System.Windows.Forms.Application.StartupPath + "\\program\\wlxm.exe";
                        WriteLog.WriteLogFile("wlxm位置" + System.Windows.Forms.Application.StartupPath + "\\program\\wlxm.exe");
                        if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\program\\wlxm.exe"))
                        {
                            WriteLog.WriteLogFile("wlxm找到文件位置");
                            Process p = new Process();
                            p.StartInfo.FileName = appNamec;
                            //启动程序
                            p.Start();
                            ks2 = my.GetTimestamp();//关机项重新计时
                            WriteLog.WriteLogFile("结束打开wlxm");
                        }

                    }
                }
                long js = my.GetTimestamp();
                //只是说明还活着
                if ((js - ks) > 1000 * 60 * 5)
                {
                    ks = my.GetTimestamp();
                    ShouHu s = new ShouHu();
                    s.wohaihuozhe();
                }
                //长时间没有数则重启 1号机之外的机器1个半小时
                if (!MyFuncUtil.getMachineName().ToUpper().Equals("1HAO") && (js - ks2) > 1000 * 60 * 90)
                {
                    ks2 = my.GetTimestamp();
                    ShouHu s = new ShouHu();
                    bool t = s.panDuanChongQi(MyFuncUtil.getMachineName());
                    t = false;
                    if (!MyFuncUtil.getMachineName().ToLower().Equals("wlzhongkong") && t)
                    {
                        WriteLog.WriteLogFile("重启啦!!!");
                        System.Diagnostics.Process.Start("shutdown.exe", "-r -f -t 15");
                    }
                }
                //长时间没有数则重启 1号机 1个半小时
                if (MyFuncUtil.getMachineName().ToUpper().Equals("1HAO") && (js - ks2) > 1000 * 60*90)
                {
                    ks2 = my.GetTimestamp();
                    ShouHu s = new ShouHu();
                    bool t = s.panDuanChongQi(MyFuncUtil.getMachineName());
                    t = false;
                    if (!MyFuncUtil.getMachineName().ToLower().Equals("wlzhongkong") && t)
                    {
                        WriteLog.WriteLogFile("重启啦!!!");
                        System.Diagnostics.Process.Start("shutdown.exe", "-r -f -t 15");
                    }
                }
                //定时更新运行情况
                if ( (js - ks3) > 1000 * 60 * 20)
                {
                    ks3 = MyFuncUtil.GetTimestamp();
                    DateTime dt = getYunXingQkLasttime();
                    TimeSpan span = DateTime.Now.Subtract(dt);
                    //WriteLog.WriteLogFile("准备更新与上次统计相比,间隔 " + span.Minutes + "分钟");
                    if (span.Hours >= 1)
                    {
                        //WriteLog.WriteLogFile("与上次统计相比,间隔 " + span.Minutes + "分钟");
                        //gxYunXingQk("jingjieguanfang");
                    }
                }
                //检测wlxm
                if ((js - ks4) > 1000 * 60 * 10)
                {
                    ks4 = MyFuncUtil.GetTimestamp();
                    Process current = Process.GetCurrentProcess();
                    string appname = "wlxm";
                    bool t = false;
                    Process[] processes = Process.GetProcessesByName(appname);
                    int a = 0;
                    foreach (Process process in processes)
                    {
                        if (a==0 && process.ProcessName == appname)
                        {
                            t = true;
                            a = 1;
                            break;
                        }
                    }
                    if (!t)
                    {
                        ks8 = MyFuncUtil.GetTimestamp();
                        string appNamec = System.Windows.Forms.Application.StartupPath + "\\program\\wlxm.exe";
                        WriteLog.WriteLogFile("wlxm位置" + System.Windows.Forms.Application.StartupPath + "\\program\\wlxm.exe");
                        if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\program\\wlxm.exe"))
                        {
                            WriteLog.WriteLogFile("wlxm找到文件位置");
                            Process p = new Process();
                            p.StartInfo.FileName = appNamec;
                            //启动程序
                            p.Start();
                            ks2 = my.GetTimestamp();//关机项重新计时
                            WriteLog.WriteLogFile("结束打开wlxm");
                        }
                        
                    }
                }

                //检测多开器
                if ((js - ks5) > 1000 * 60 * 20)
                {
                    ks5 = MyFuncUtil.GetTimestamp();
                    Process current = Process.GetCurrentProcess();
                    string appname = "dnmultiplayer";
                    bool t = false;
                    Process[] processes = Process.GetProcessesByName(appname);
                    foreach (Process process in processes)
                    {
                        if (process.ProcessName == appname)
                        {
                            t = true;
                            duokai = 0;
                            break;
                        }
                    }
                    if (!t) {
                        System.Threading.Thread.Sleep(30000);
                        Process p = new Process();
                        p.StartInfo.FileName = @"D:\ChangZhi\dnplayer2\dnmultiplayer.exe";                        
                        //启动程序
                        p.Start();
                        WriteLog.WriteLogFile("结束打开多开器2");
                        System.Threading.Thread.Sleep(10000);
                    }
                    processes = Process.GetProcessesByName(appname);
                    foreach (Process process in processes)
                    {
                        if (process.ProcessName == appname)
                        {
                            t = true;
                            duokai = 0;
                            break;
                        }
                    }
                    if (!t) {
                        duokai++;
                    }
                    if (!MyFuncUtil.getMachineName().ToLower().Equals("wlzhongkong") && duokai>1)
                    {
                        WriteLog.WriteLogFile("dnmultiplayer不存在了");
                        //WriteLog.WriteLogFile("重启啦!!!");
                        //System.Diagnostics.Process.Start("shutdown.exe", "-r -f -t 15");
                        //WriteLog.WriteLogFile("结束打开dnmultiplayer");
                    }
                }
                //检测wlxm
                if ((js - ks6) > 1000 * 60*10)
                {
                    ks6 = MyFuncUtil.GetTimestamp();
                    UpdateCaoZuo sh = new UpdateCaoZuo();
                    sh.updateWlxm();
                }
                if ((js - ks7) > 1000 * 60 *45)
                {
                    ks7 = my.GetTimestamp();
                    ShouHu s = new ShouHu();
                    bool t = s.panDuanChongQi(MyFuncUtil.getMachineName());
                    t = false;
                    if (t)
                    {
                        ks8 = MyFuncUtil.GetTimestamp();
                        MyFuncUtil.killProcess("wlxm");
                        System.Threading.Thread.Sleep(1000 * 50);
                        string appname = "wlxm";
                        bool t1 = false;
                        Process[] processes = Process.GetProcessesByName(appname);
                        int a = 0;
                        foreach (Process process in processes)
                        {
                            if (a==0 && process.ProcessName == appname)
                            {
                                t1 = true;
                                a = 1;
                                break;
                            }
                        }
                        if (!t1)
                        {
                            string appNamec = System.Windows.Forms.Application.StartupPath + "\\program\\wlxm.exe";
                            WriteLog.WriteLogFile("wlxm位置" + System.Windows.Forms.Application.StartupPath + "\\program\\wlxm.exe");
                            if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\program\\wlxm.exe"))
                            {
                                WriteLog.WriteLogFile("wlxm找到文件位置");
                                Process p = new Process();
                                p.StartInfo.FileName = appNamec;
                                //启动程序
                                p.Start();
                                ks2 = my.GetTimestamp();//关机项重新计时
                                WriteLog.WriteLogFile("结束打开wlxm");
                            }
                        }
                    }
                 
                }

                if ((js - ks8) > 1000 * 60 * 20)
                {
                    ks8 = MyFuncUtil.GetTimestamp();
                    string dir = "C:\\mylog\\" + DateTime.Now.Year +
                    DateTime.Now.Month +
                    DateTime.Now.Day + "\\";
                    if (System.IO.Directory.Exists(dir))//文件夹是否存在          　　              
                    {
                        System.IO.FileInfo[] fis = new System.IO.DirectoryInfo(dir).GetFiles();
                        int isalive = 0;
                        if (fis != null && fis.Count() > 0)
                        {
                            for (int i1 = 0; i1 < fis.Length; i1++)
                            {
                                TimeSpan span = DateTime.Now.Subtract(fis[i1].LastWriteTime);
                                if (span.TotalMinutes > 30)
                                {
                                    isalive++;
                                }
                            }
                        }
                        if (isalive > 5)
                        {
                            WriteLog.WriteLogFile("超过5个模拟器长时间不更新了");
                            MyFuncUtil.killProcess("wlxm");
                            string appname = "wlxm";
                            Process[] processes = Process.GetProcessesByName(appname);
                            int a = 0;
                            bool t1 = false;
                            foreach (Process process in processes)
                            {
                                if (a == 0 && process.ProcessName == appname)
                                {
                                    t1 = true;
                                    a = 1;
                                    break;
                                }
                            }
                            if (!t1)
                            {
                                string appNamec = System.Windows.Forms.Application.StartupPath + "\\program\\wlxm.exe";
                                WriteLog.WriteLogFile("wlxm位置" + System.Windows.Forms.Application.StartupPath + "\\program\\wlxm.exe");
                                if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\program\\wlxm.exe"))
                                {
                                    WriteLog.WriteLogFile("wlxm找到文件位置");
                                    Process p = new Process();
                                    p.StartInfo.FileName = appNamec;
                                    //启动程序
                                    p.Start();
                                    ks2 = my.GetTimestamp();//关机项重新计时
                                    WriteLog.WriteLogFile("结束打开wlxm");
                                }
                            }
                        }
                    }
                }

                if ((js - ks9) > 1000 * 60 * 20)
                {
                    ks9 = MyFuncUtil.GetTimestamp();
                    string dir = "d:\\mylog\\" + DateTime.Now.Year +
                    DateTime.Now.Month +
                    DateTime.Now.Day + "\\";
                    if (System.IO.Directory.Exists(dir))//文件夹是否存在          　　              
                    {
                        System.IO.FileInfo[] fis = new System.IO.DirectoryInfo(dir).GetFiles();
                        int isalive = 0;
                        if (fis != null && fis.Count() > 0)
                        {
                            for (int i1 = 0; i1 < fis.Length; i1++)
                            {
                                TimeSpan span = DateTime.Now.Subtract(fis[i1].LastWriteTime);
                                if (span.TotalMinutes > 30)
                                {
                                    isalive++;
                                }
                            }
                        }
                        if (isalive > 0)
                        {
                            WriteLog.WriteLogFile("wlsh长时间不更新了");
                            MyFuncUtil.killProcess("wlsh");
                            string appname = "wlsh";
                            Process[] processes = Process.GetProcessesByName(appname);
                            int a = 0;
                            bool t1 = false;
                            foreach (Process process in processes)
                            {
                                if (a == 0 && process.ProcessName == appname)
                                {
                                    t1 = true;
                                    a = 1;
                                    break;
                                }
                            }
                            if (!t1)
                            {
                                string appNamec = System.Windows.Forms.Application.StartupPath + "\\wlsh.exe";
                                WriteLog.WriteLogFile("wlsh位置" + System.Windows.Forms.Application.StartupPath + "\\wlsh.exe");
                                if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\\wlsh.exe"))
                                {
                                    WriteLog.WriteLogFile("wlsh找到文件位置");
                                    Process p = new Process();
                                    p.StartInfo.FileName = appNamec;
                                    //启动程序
                                    p.Start();
                                    ks2 = my.GetTimestamp();//关机项重新计时
                                    WriteLog.WriteLogFile("结束打开wlsh");
                                }
                            }
                        }
                    }
                }


            }


        }


    }
}
