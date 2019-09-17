using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace SH_MyUtil
{
    public class ShouHu
    {
        public static int BanBenHao = 2;
        private static readonly object obj = new object();
        public void wohaihuozhe() {
            WriteLog.WriteLogFile("生命的迹象 "+MyFuncUtil.suijishu(1,100));
        }

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
        public void gxYunXingQk(string youxi)
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
                        " from zhanghao z where youxi='" + youxi + "'";

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
            while (true)
            {
                long js = my.GetTimestamp();
                if ((js - ks) > 1000 * 60 * 5)
                {
                    ks = my.GetTimestamp();
                    ShouHu s = new ShouHu();
                    s.wohaihuozhe();
                }
                if ((js - ks2) > 1000 * 60 * 90)
                {
                    ks2 = my.GetTimestamp();
                    ShouHu s = new ShouHu();
                    bool t = s.panDuanChongQi(MyFuncUtil.getMachineName());
                    if (!MyFuncUtil.getMachineName().ToLower().Equals("wlzhongkong") && t)
                    {
                        WriteLog.WriteLogFile("重启啦!!!");
                        System.Diagnostics.Process.Start("shutdown.exe", "-r -f -t 15");
                    }
                }
                if ( (js - ks3) > 1000 * 60 * 20)
                {
                    ks3 = MyFuncUtil.GetTimestamp();
                    DateTime dt = getYunXingQkLasttime();
                    TimeSpan span = DateTime.Now.Subtract(dt);
                    WriteLog.WriteLogFile("准备更新与上次统计相比,间隔 " + span.Minutes + "分钟");
                    if (span.Hours >= 1 || span.Minutes > 45)
                    {
                        WriteLog.WriteLogFile("与上次统计相比,间隔 " + span.Minutes + "分钟");
                        gxYunXingQk("jingjieguanfang");
                    }
                }
            }
        }

    }
}
