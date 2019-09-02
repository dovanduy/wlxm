using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xDM;
using System.Data;
using System.Data.SqlClient;

namespace MyUtil
{
    public class ZhangHao
    {
        private static readonly object obj = new object();
        public void zd() {
            MyFuncUtil.mylogandxianshi("开始测试");
            string connString = @"Data Source=DEEP-2019RJUDYT\SQLEXPRESS;Initial Catalog=yiquan;User ID=sa;Password=123456";
            SqlConnection conn = new SqlConnection(connString);//实例连接对象
            conn.Open();//打开数据库连接
            string sqlString = "select * from zhanghao";
            SqlCommand command = conn.CreateCommand();//通过连接对象创建数据库命令对象
            command.CommandText = sqlString;          //确定文本对象执行的SQL语句
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                string str = null;
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    str += dataReader.GetValue(i).ToString().Trim() + "\t";
                }
                str += "\n";
                MyFuncUtil.mylogandxianshi(str);
            }
            dataReader.Close();
            //数据库查询：
            SqlDataAdapter sqlDa = new SqlDataAdapter("select * from zhanghao", conn);
            DataTable dt = new DataTable();
            sqlDa.Fill(dt);
            string name = dt.Rows[0][0].ToString();
            MyFuncUtil.mylogandxianshi(name + "----");
            //数据库插入更新操作:
            //SqlCommand sqlCmd = new SqlCommand("insert into tb_scene_tb (id,scene_id) values('1','123')", conn);
            SqlCommand sqlCmd = new SqlCommand("update zhanghao set name='lisi2' where name='lisi'", conn);
            sqlCmd.ExecuteNonQuery();
            sqlDa = new SqlDataAdapter("select * from zhanghao", conn);
            dt = new DataTable();
            sqlDa.Fill(dt);
            name = dt.Rows[0][0].ToString();
            MyFuncUtil.mylogandxianshi(name + "----2");
            conn.Close();

            MyFuncUtil.mylogandxianshi("结束测试");
        
        }
        public string suijizifu(int inx,int weishu)
        {
            string uuidN = Guid.NewGuid().ToString("N").Substring(0, weishu);
            WriteLog.WriteLogFile(inx+"", "生成的随机字符是"+uuidN);
            return uuidN;
        }

        public char[] changechar(string dd)
        {
            char[] s = dd.ToCharArray();
            return s;
        }

        public void getNameAndPw(int inx,out string name,out string pas) {
            myDm dm = new myDm();
            name = null;
            pas = null;
            if (dm.IsFileExist(@"c:\mylog\zhanghao.txt")!=1) {
                return;
            
            }
            string a = dm.ReadFile(@"c:\mylog\zhanghao.txt");
            string rs = null;
            string[] b = a.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string ab in b)
            {
                if (ab != null)
                {
                    string[] aa = ab.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    if (int.Parse(aa[0]) == inx && aa[3].Trim().Equals("Y"))
                    {
                        rs = aa[1] + "|" + aa[2];
                        name = aa[1];
                        pas = aa[2];
                    }
                }
            }   
        }

        public void generateNameAndPas(int inx,int weishu ,out string name,out string pas) {
            name = null; //账号是6-18位 数字字母
            pas = "a99999"; //账号是6-14位 数字字母
            name = suijizifu(inx, weishu);
            WriteLog.WriteZhangHaoFile(inx,name,pas,"Y");
        }

        public void shuruqianhuitui(myDm mf, int dqinx, int jubing)
        {
            WriteLog.WriteLogFile(dqinx + "", "输入前要回退");
            int i1 = MyFuncUtil.suijishu(15, 15);
            for (int i = 0; i < i1; i++)
            {
                mf.myKeyPressChar(jubing, "back");
                mf.mydelay(800, 1200);
            }            
            mf.mydelay(800, 1600);
        }

        public void shuruchar(myDm mf, int dqinx, int jubing, string str)
        {
            WriteLog.WriteLogFile(dqinx + "", "准备录入"+str+"中");
            char[] myshuru = changechar(str);
            shuruqianhuitui(mf, dqinx, jubing);
            foreach (char a in myshuru)
            {
                mf.myKeyPressChar(jubing, a.ToString());
                mf.mydelay(800, 1600);
                WriteLog.WriteLogFile(dqinx + "", "录入中" + a.ToString());
            }
            mf.myKeyPressChar(jubing, "tab");
            mf.mydelay(800, 1600);
        }

        public void lurenSaveNameAndPas(string name, string pwd, int dqindex,string youxi="jingjie")
        {
            SqlHelp sqh = SqlHelp.GetInstance();
            DataTable dt = sqh.getAll("select top 1 name from zhanghao where name = '" + name + "' and youxi='"+youxi+"'" );
            if (dt.Rows.Count > 0)
            {
                WriteLog.WriteLogFile(dqindex + "", "当前游戏 "+youxi+" 已存在这个账号" + name);
                return;
            }
            lock (obj)
            {
                try
                {
                    sqh.update("insert into zhanghao (name,pwd,dqindex,yxbz,yimai,dengluzhong,pcname,xgsj,youxi,xuanqu) values('"
                        + name + "','" + pwd + "'," + dqindex + ",'Y','N','N','"
                        + WriteLog.getMachineName()
                        + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','"+youxi+"',1)");
                    
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public void denglusaveNameAndPas(string name,string pwd,int dqindex)
        {
            SqlHelp sqh = SqlHelp.GetInstance();
            lock(obj)
            {
                try
                {
                    DataTable dt = sqh.getAll("select top 1 name from zhanghao where name = '" + name + "'");
                    if (dt.Rows.Count > 0)
                    {
                        sqh.update("update zhanghao set dengluzhong='Y' where name='"
                            +name+"'");                        
                    }
                    else
                    {

                        sqh.update("insert into zhanghao (name,pwd,dqindex,yxbz,yimai,dengluzhong,pcname,xgsj) values('"
                           + name + "','" + pwd + "'," + dqindex + ",'Y','N','Y','"
                           + WriteLog.getMachineName()
                           + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')");
                    }
                }
                catch (Exception ex)
                {
                
                    throw ex;
                }  
            }
        }

        public void updateXuanqu(string name, int xuanqu)
        {
            SqlHelp sqh = SqlHelp.GetInstance();
            lock (obj)
            {
                try
                {
                    DataTable dt = sqh.getAll("select top 1 name from zhanghao where name = '" + name + "'");
                    if (dt.Rows.Count > 0)
                    {
                        sqh.update("update zhanghao set dengluzhong='Y',"+
                        "xuanqu="+xuanqu+" where name='"
                            + name + "'");
                    }                    
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public void tuichusaveNameAndPas(string name,int dqindex,string pcname,int dengji,int zuanshi,int qiangzhequan)
        {
            SqlHelp sqh = SqlHelp.GetInstance();
            lock (obj)
            {
                try
                {
                    DataTable dt = sqh.getAll("select top 1 name from zhanghao where name = '" + name+
                         "'");
                    if (dt.Rows.Count > 0)
                    {
                        sqh.update("update zhanghao set dengluzhong='N' , xgsj='"
                        + DateTime.Now.ToString("yyyy-MM-dd") + "' , dengji="
                        +dengji+", zuanshi ="+zuanshi+" , qiangzhequan="+qiangzhequan+" , dengluzhong='N' "
                        +" where name='"+ name+"'");
                    }
                    else
                    {

                        WriteLog.WriteLogFile(dqindex + "", "退出时更新失败,没有找到登陆中账号");
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public void zhunbeizhanghao(int dqinx,string youxi,out string name, out string pwd,out int xuanqu,out int dengji)
        {
            //服务器上有应该登录的账号则使用指定账号登录
            name = null;
            pwd = null;
            xuanqu = -1;
            dengji = -1;
            SqlHelp sqh = SqlHelp.GetInstance();
            string dqsj = DateTime.Now.ToString("yyyy-MM-dd");
            DataTable dt = sqh.getAll("select top 1 name,pwd,isnull(xuanqu,-1),isnull(dengji,-1) from zhanghao "
                + " where (xgsj < '" + dqsj
                + "' or dengji is null) and yxbz='Y' and dengluzhong='N' "
                + " and yimai='N'  and youxi='"+youxi+"'");
            if (dt.Rows.Count > 0)
            {
                name = (string)dt.Rows[0][0];
                pwd = (string)dt.Rows[0][1];
                xuanqu = (int)dt.Rows[0][2];
                dengji = (int)dt.Rows[0][3];
            }
        }

        public void zhiweidengluzhong(int dqinx, string youxi, string name, string pcname)
        {
            //服务器上有登录账号后置为登陆中
            SqlHelp sqh = SqlHelp.GetInstance();
            lock (obj)
            {
                try
                {
                    sqh.update("update zhanghao set dengluzhong='Y'  where name='" + name + "' and youxi='"+youxi+"'");
                }
                catch (Exception ex)
                {
                    WriteLog.WriteLogFile(dqinx + "", "更新登录中账号失败");
                    throw ex;
                }
            }
        }

        public void zhiweiwuxiao(int dqinx, string youxi, string name, string pcname)
        {
            //服务器上有登录账号后置为登陆中
            SqlHelp sqh = SqlHelp.GetInstance();
            lock (obj)
            {
                try
                {
                    sqh.update("update zhanghao set yxbz='N'  where name='" + name + "' and youxi='" + youxi + "'");
                }
                catch (Exception ex)
                {
                    WriteLog.WriteLogFile(dqinx + "", "更新账号为无效失败");
                    throw ex;
                }
            }
        }
    }
}
