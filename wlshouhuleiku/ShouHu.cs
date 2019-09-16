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
    }
}
