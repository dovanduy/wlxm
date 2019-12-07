using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xDM;
using System.Data;
using System.Data.SqlClient;
using System.Management;
using Entity;

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
            //WriteLog.WriteZhangHaoFile(inx,name,pas,"Y");
        }

        public void shuruqianhuitui(myDm mf, int dqinx, int jubing)
        {
            WriteLog.WriteLogFile(dqinx + "", "输入前要回退");
            int i1 = MyFuncUtil.suijishu(15, 15);
            for (int i = 0; i < i1; i++)
            {
                mf.myKeyPressChar(jubing, "back");
                mf.mydelay(2, 5);
            }            
            mf.mydelay(800,1200);
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

        public void denglusaveNameAndPas(string name,string pwd,int dqindex,string youxiname)
        {
            SqlHelp sqh = SqlHelp.GetInstance();
            lock(obj)
            {
                try
                {
                    DataTable dt = sqh.getAll("select top 1 name from zhanghao where name = '" + name + "' and youxi='"+youxiname+"'");
                    if (dt.Rows.Count > 0)
                    {
                        sqh.update("update zhanghao set dengluzhong='Y' where name='"
                            +name+"'");                        
                    }
                    else
                    {

                        sqh.update("insert into zhanghao (name,pwd,dqindex,yxbz,yimai,dengluzhong,pcname,xgsj,youxi) values('"
                           + name + "','" + pwd + "'," + dqindex + ",'Y','N','Y','"
                           + WriteLog.getMachineName()
                           + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','"+youxiname+"')");
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

        public void tuichusaveNameAndPas(string name,int dqindex,string youxi,string pcname,int dengji,int zuanshi,int qiangzhequan)
        {
            WriteLog.WriteLogFile(dqindex+"", "name " + name + ",pcname " + pcname+",强者券 " + qiangzhequan + ",钻石 " + zuanshi+ ",等级 " +dengji);
            SqlHelp sqh = SqlHelp.GetInstance();
            lock (obj)
            {
                try
                {
                    DataTable dt = sqh.getAll("select top 1 name from zhanghao where name = '" + name+
                         "' and youxi='"+youxi+"'");
                    if (dt.Rows.Count > 0)
                    {
                        if (dengji != -1 && zuanshi != -1 && qiangzhequan != -1)
                        {
                            sqh.update("update zhanghao set xgsj='"
                            + DateTime.Now.ToString("yyyy-MM-dd") + "' , dengji="
                            + dengji + ", zuanshi =" + zuanshi + " , qiangzhequan=" + qiangzhequan + " , dengluzhong='N' "
                            + " where name='" + name + "' and youxi='" + youxi + "'");
                        }
                        else if (zuanshi != -1 && qiangzhequan == -1)
                        {
                            sqh.update("update zhanghao set xgsj='"
                            + DateTime.Now.ToString("yyyy-MM-dd") + "',  zuanshi =" + zuanshi + " , dengluzhong='N' "
                            + " where name='" + name + "' and youxi='" + youxi + "'");
                        }
                        else if (zuanshi != -1 && qiangzhequan!=-1)
                        {
                            sqh.update("update zhanghao set xgsj='"
                            + DateTime.Now.ToString("yyyy-MM-dd") + "',  zuanshi =" + zuanshi + " , qiangzhequan=" + qiangzhequan + " , dengluzhong='N' "
                            + " where name='" + name + "' and youxi='" + youxi + "'");
                        }
                        else
                        {
                            sqh.update("update zhanghao set xgsj='"
                            + DateTime.Now.ToString("yyyy-MM-dd") + "', dengluzhong='N' "
                            + " where name='" + name + "' and youxi='" + youxi + "'");
                        }
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

        public void zhunbeizhanghao(int dqinx,string youxi,out string name, out string pwd,out int xuanqu,out int dengji,out string jieduan)
        {
            //服务器上有应该登录的账号则使用指定账号登录
            WriteLog.WriteLogFile(dqinx + "", "开始找需要练级的账号");
            name = "";
            pwd = null;
            xuanqu = -1;
            dengji = -1;
            jieduan = "";
            SqlHelp sqh = SqlHelp.GetInstance();
            string dqsj = DateTime.Now.ToString("yyyy-MM-dd");
            lock (obj)
            {
                DataTable dt = sqh.getAll("select top 1 name,pwd,isnull(xuanqu,-1),isnull(dengji,-1),isnull(jieduan,'') from zhanghao where yxbz='Y' and yimai='N' and dengluzhong='Y' and pcname='"

                    + WriteLog.getMachineName() + "' and dqindex=" + dqinx + " and youxi='" + youxi + "' order by xuanqu desc")
                    ;
                if (dt.Rows.Count > 0)
                {
                    name = (string)dt.Rows[0][0];
                    pwd = (string)dt.Rows[0][1];
                    xuanqu = (int)dt.Rows[0][2];
                    dengji = (int)dt.Rows[0][3];
                    jieduan = (string)dt.Rows[0][4];
                    WriteLog.WriteLogFile(dqinx + "", "找到需要练级的账号" + name + " " + pwd + ",xuanqu " + xuanqu + "并置为登录中");
                    return;
                }
                string updatesql="update zhanghao with (UPDLOCK) set dengluzhong='Y',pcname='"+WriteLog.getMachineName()+"', dqindex="+dqinx
                +" where name=(select top 1 name from zhanghao "
                    + " where xgsj < '" + dqsj
                    + "'  and yxbz='Y' and dengluzhong='N' "
                    + " and yimai='N'  and youxi='" + youxi + "' order by xuanqu desc)";
                sqh.update(updatesql);
                dt = sqh.getAll("select top 1 name,pwd,isnull(xuanqu,-1),isnull(dengji,-1),isnull(jieduan,'') from zhanghao where yxbz='Y' and yimai='N' and dengluzhong='Y' and pcname='"

                    + WriteLog.getMachineName() + "' and dqindex=" + dqinx + " and youxi='" + youxi + "'")
                    ;
                if (dt.Rows.Count > 0)
                {
                    name = (string)dt.Rows[0][0];
                    pwd = (string)dt.Rows[0][1];
                    xuanqu = (int)dt.Rows[0][2];
                    dengji = (int)dt.Rows[0][3];
                    jieduan = (string)dt.Rows[0][4];
                    WriteLog.WriteLogFile(dqinx+"", "找到需要练级的账号" + name + " " + pwd + ",xuanqu " + xuanqu+"并置为登录中");
                }
            }
        }
         
        public void zhiweidengluzhong(int dqinx, string youxi, string name)
        {
            //服务器上有登录账号后置为登陆中
            SqlHelp sqh = SqlHelp.GetInstance();
            WriteLog.WriteLogFile(dqinx + "", "置为登陆中" + name );
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

        public void zhiweidengluzhongN(int dqinx,string youxi, string name, string pcname)
        {
            //服务器上有登录账号后置为登陆中
            SqlHelp sqh = SqlHelp.GetInstance();
            lock (obj)
            {
                try
                {
                    string dqsj = DateTime.Now.ToString("yyyy-MM-dd");
                    sqh.update("update zhanghao set dengluzhong='N',xgsj='" + dqsj + "',dqindex="+dqinx+" where name='" + name + "' and youxi='" + youxi + "'");
                }
                catch (Exception ex)
                {
                    WriteLog.WriteLogFile("", "所有账号置为N更新失败");
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

        public void gengxinjieduan(int dqinx, string youxi, string name, string jieduan="zhuxian")
        {
            //服务器上有登录账号后置为登陆中
            SqlHelp sqh = SqlHelp.GetInstance();
            lock (obj)
            {
                try
                {
                    sqh.update("update zhanghao set jieduan='"+jieduan+"'  where name='" + name + "' and youxi='" + youxi + "'");
                }
                catch (Exception ex)
                {
                    WriteLog.WriteLogFile(dqinx + "", "更新账号的阶段是zhuxian还是denglu,更新失败");
                    throw ex;
                }
            }
        }

        public void updateIp(int dqinx, string youxi, string name, string ip)
        {
            //服务器上有登录账号后置为登陆中
            SqlHelp sqh = SqlHelp.GetInstance();
            lock (obj)
            {
                if (ip.Trim().Length > 20) {
                    ip = ip.Trim().Substring(0, 20);
                }
                try
                {
                    sqh.update("update zhanghao set ip='" + ip  + "'  where name='" + name + "' and youxi='" + youxi + "'");
                }
                catch (Exception ex)
                {
                    WriteLog.WriteLogFile(dqinx + "", "更新账号的ip,更新失败"+ex.Message);
                    throw ex;
                }
            }
        }

        public bool panduanIpKeYong(int dqinx, string youxi,string ip)
        {
            //服务器上有登录账号后置为登陆中
            SqlHelp sqh = SqlHelp.GetInstance();
            lock (obj)
            {
                try
                {
                    DataTable dt = sqh.getAll("select name,isnull(ip,'') from zhanghao where ip='"

                    + ip + "' and youxi='" + youxi + "' and yxbz='Y' and dengluzhong='Y' and xgsj='"+DateTime.Now.ToString("yyyy-MM-dd")+"'")
                    ;
                    if (dt.Rows.Count > 0)
                    {

                        WriteLog.WriteLogFile(dqinx + "", "找到需要练级的账号" + dt.Rows[0][0] + " " + dt.Rows[0][1] + "为相同ip:"+ip);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    WriteLog.WriteLogFile(dqinx + "", "更新账号的ip,更新失败");
                    throw ex;
                }
                return false;
            }
        }

        public void getZhanghaoXinxi(int dqinx,string youxi, string zhanghao,string xinxi,out int ox)
        {
            //服务器上有登录账号后置为登陆中
            SqlHelp sqh = SqlHelp.GetInstance();
            ox = -1;
            WriteLog.WriteLogFile(dqinx + "", "取到账号" + zhanghao + "相关信息");
            lock (obj)
            {
                try
                {
                    DataTable dt = sqh.getAll("select isnull(" + xinxi + ",-1) from zhanghao where name='"

                    + zhanghao + "'and youxi='" + youxi + "'")
                    ;
                    if (dt.Rows.Count > 0)
                    {
                        ox = (int)dt.Rows[0][0];
                        WriteLog.WriteLogFile(dqinx + "", "找到需要练级的账号" + zhanghao + " " + xinxi + ", " + ox );
                    }
                }
                catch (Exception ex)
                {
                    WriteLog.WriteLogFile(dqinx + "", "更新登录中账号失败");
                    throw ex;
                }
            }
        }

        public Dictionary<string,string> getZhanghaoXinxiForDaochu(string youxi, string zhanghao)
        {
            //服务器上有登录账号后置为登陆中
            SqlHelp sqh = SqlHelp.GetInstance();
            Dictionary<string, string> rs = new Dictionary<string, string>();
            try
            {
                DataTable dt = sqh.getAll("select zhanghao,pwd,youxi,isnull(zuanshi,-1),isnull(qiangzhequan,-1),isnull(xuanqu,-1) from zhanghao where name='"

                + zhanghao + "'and youxi='" + youxi + "' and yxbz='Y' and yimai='N'")
                ;
                if (dt.Rows.Count > 0)
                {
                    rs.Add("youxi",youxi);
                    rs.Add("zhanghao", zhanghao);
                    rs.Add("pwd", (string)dt.Rows[0][2]);
                    rs.Add("zuanshi", (int)dt.Rows[0][3]+"");
                    rs.Add("qiangzhequan", (int)dt.Rows[0][4]+"");
                    rs.Add("xuanqu", (int)dt.Rows[0][5]+"");
                    WriteLog.WriteLogFile("", "找到需要上架的账号" + zhanghao + " " );
                }

            }
            catch (Exception ex)
            {
                WriteLog.WriteLogFile("", "取得账号信息失败");
                throw ex;
            }
            
            return rs;
        }

        public int getJiuYouZhangHaoCount(int dqinx, string youxi = "jiuyouzhuce")
        {
            SqlHelp sqh = SqlHelp.GetInstance();
            DataTable dt = sqh.getAll("select count(*) from zhanghao where youxi='" + youxi + "'");
            int r = 0;
            if (dt.Rows.Count > 0)
            {
                r = (int)dt.Rows[0][0];
                WriteLog.WriteLogFile(dqinx + "", "当前游戏 " + youxi + " 存在"+r+"个账号");
            }
            return r;
        }

        public string getJiuYouPwdFromList(int dqinx, List<string> pwdlist,string youxi = "jiuyouzhuce") {
            int r = getJiuYouZhangHaoCount(dqinx, youxi);
            string rs = "999999";
            int inx = r / 3000;
            List<string> pwdlist2 = pwdlist;
            if (inx > pwdlist.Count)
            {
                for (int i = 0; i < 100; i++) {
                    pwdlist.AddRange(pwdlist2);
                    if (inx < pwdlist.Count)
                    { break; }
                }
            }
            if (inx < pwdlist.Count)
            {
                rs = pwdlist[inx];
            }           
            return rs;
        }

        public void saveipfirst(int dqinx, string ip,out bool yiyong)
        {
            SqlHelp sqh = SqlHelp.GetInstance();
            DataTable dt = sqh.getAll("select shiyong from ipqk where rq='"

                    + DateTime.Now.ToString("yyyy-MM-dd") + "'and ip='" + ip + "'");
            yiyong = false;
            if (dt.Rows.Count > 0)
            {
                yiyong = true;
                int ox = (int)dt.Rows[0][0];
                WriteLog.WriteLogFile(dqinx + "", "这个ip今天已经用过" + ip + "，" + ox + "次,又碰到了");
                lock (obj)
                {
                    try
                    {
                        sqh.update("update ipqk set shiyong=" + (ox + 1) + " where ip='" + ip + "' and rq='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
            else
            {
                lock (obj)
                {
                    try
                    {
                        sqh.update("insert into ipqk (rq,pcname,ip,shiyong) values("+
                        "'" + DateTime.Now.ToString("yyyy-MM-dd") + "','"
                            + WriteLog.getMachineName() + "','" + ip + "',"+1+" )");
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// 更新运行情况表 改善的运行情况
        /// </summary>
        /// <param name="youxi"></param>
        public void updateYunXingQk(string[] pcnames)
        {
            //得到运行情况后存入表
            WriteLog.WriteLogFile("", "得到运行情况后存入表");
            SqlHelp sqh = SqlHelp.GetInstance();
            lock (obj)
            {
                try
                {
                    YunXingQK jqqk = new YunXingQK();
                    string selsql = "select ";
                    foreach(string pc in pcnames){
                        selsql = selsql + "sum(case when  z.pcname='"+pc+"' and z.xgsj>=convert(varchar(10),getdate(),120) then 1 else 0 end) "+"a"+pc +",";
                    }
                    selsql = selsql +
                         "sum(case when z.zuanshi>0  and z.xgsj>=convert(varchar(10),getdate(),120) then z.zuanshi else 0 end)  zuanshi," +
                         "sum(case when z.qiangzhequan>0  and z.xgsj>=convert(varchar(10),getdate(),120) then z.qiangzhequan else 0 end)  qiangzhe," +
                         "sum(case when z.xgsj>=convert(varchar(10),getdate(),120) then 1 else 0 end)  zxiugai  from zhanghao z where yxbz='Y'";  
                    DataTable dt = sqh.getAll(selsql);
                    int a = dt.Rows.Count;
                    StringBuilder pcyunxing = new StringBuilder();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < pcnames.Length-1; i++) {
                            pcyunxing.Append(dt.Rows[0][i]+"|");

                        }
                        pcyunxing.Append(dt.Rows[0][pcnames.Length - 1]);
                        jqqk.Zuanshidayu0 = (int)dt.Rows[0][pcnames.Length];
                        jqqk.Qiangzhedayu0 = (int)dt.Rows[0][pcnames.Length + 1];
                        jqqk.Xgsj = DateTime.Now;
                        jqqk.Zongxiugai = (int)dt.Rows[0][pcnames.Length + 2];
                        WriteLog.WriteLogFile("", "当前运行机器的出产情况" + pcyunxing.ToString());
                    }
                    string inssql = "insert into jiankong (zxiugai,pcxiugai,zuanshidayu0,qiangzhedayu0,gxsj) values("
                        + jqqk.Zongxiugai
                        + ",'" + pcyunxing.ToString()
                        + "'," + jqqk.Zuanshidayu0 
                        + "," +jqqk.Qiangzhedayu0 
                        + ",'" + jqqk.Xgsj+ "')";
                    sqh.update(inssql);
                }
                catch (Exception ex)
                {
                    WriteLog.WriteLogFile("", "更新运行情况失败");
                    throw ex;
                }
            }
        }
        
        /// <summary>
        /// 更新运行情况表
        /// </summary>
        /// <param name="youxi"></param>
        public void gxYunXingQk()
        {
            //得到运行情况后存入表
            WriteLog.WriteLogFile("", "得到运行情况后存入表");
            SqlHelp sqh = SqlHelp.GetInstance();
            lock (obj)
            {
                try
                {
                    YunXingQK jqqk = new YunXingQK();
                    string selsql = "select "+
                        "sum(case when  z.pcname='1hao' and z.xgsj>=convert(varchar(10),getdate(),120) then 1 else 0 end)  hao1chanshu,"+
                        "sum(case when  z.pcname='2hao' and z.xgsj>=convert(varchar(10),getdate(),120) then 1 else 0 end)  hao2xiugai,"+
                        "sum(case when  z.pcname='2hao' and z.zuanshi>0 and z.xgsj>=convert(varchar(10),getdate(),120) then 1 else 0 end)  hao2chanshu,"+
                        "sum(case when  z.pcname='3hao' and z.xgsj>=convert(varchar(10),getdate(),120) then 1 else 0 end)  hao3xiugai,"+
                        "sum(case when  z.pcname='3hao' and z.zuanshi>0 and z.xgsj>=convert(varchar(10),getdate(),120) then 1 else 0 end)  hao2chanshu,"+
                        "sum(case when  z.pcname='wlzhongkong' and z.xgsj>=convert(varchar(10),getdate(),120) then 1 else 0 end)  zkxiugai,"+
                        "sum(case when  z.pcname='wlzhongkong' and z.zuanshi>0 and z.xgsj>=convert(varchar(10),getdate(),120) then 1 else 0 end)  zkchanshu,"+
                        "sum(case when z.zuanshi>0  then 1 else 0 end)  zuanshidayu0,"+
                        "sum(case when z.zuanshi>1000  then 1 else 0 end)  zuanshidayu1000,"+
                        "sum(case when z.zuanshi>3000  then 1 else 0 end)  zuanshidayu3000,"+
                        "sum(case when z.qiangzhequan>0  then 1 else 0 end)  qiangzhedayu0,"+
                        "sum(case when z.xgsj>=convert(varchar(10),getdate(),120) then 1 else 0 end)  zxiugai" +
                        " from zhanghao z where yxbz='Y' and yimai='N'";

                    DataTable dt = sqh.getAll(selsql);
                    int a = dt.Rows.Count;
                    if (dt.Rows.Count > 0)
                    {
                        Dictionary<string, JiQiYunXing> dict = new Dictionary<string, JiQiYunXing>();
                        JiQiYunXing jq1=new JiQiYunXing();
                        jq1.Chuchan=(int)dt.Rows[0][0];
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
                        WriteLog.WriteLogFile("", "当前运行机器的出产情况" + jqqk.Zongxiugai+"单独:"+jqqk.Jqyx["hao1"].Chuchan + " " + jqqk.Jqyx["hao2"].Chuchan + "  " + jqqk.Jqyx["hao3"].Chuchan + " " + jqqk.Jqyx["zk"].Chuchan);
                    }
                    string inssql = "insert into yunxingqk (hao1chanchu,hao2xiugai,hao2chanchu,hao3xiugai,hao3chanchu,zkxiugai,zkchanchu,zuanshidayu0,zuanshidayu1000,zuanshidayu3000,qiangzhedayu0,gxsj,zxiugai) values("
                        +jqqk.Jqyx["hao1"].Chuchan+","+jqqk.Jqyx["hao2"].Xiugai+","+jqqk.Jqyx["hao2"].Chuchan 
                        +","+jqqk.Jqyx["hao3"].Xiugai+","+jqqk.Jqyx["hao3"].Chuchan 
                        +","+jqqk.Jqyx["zk"].Xiugai+","+jqqk.Jqyx["zk"].Chuchan 
                        +","+jqqk.Zuanshidayu0+","+jqqk.Zuanshidayu1000 
                        +","+jqqk.Zuanshidayu3000+","+jqqk.Qiangzhedayu0+",'"+ jqqk.Xgsj+"',"+jqqk.Zongxiugai+")";
                    sqh.update(inssql);
                }
                catch (Exception ex)
                {
                    WriteLog.WriteLogFile("", "更新运行情况失败");
                    throw ex;
                }
            }
        }
        /// <summary>
        /// 得到运行情况
        /// </summary>
        /// <param name="youxi"></param>
        public List<YunXingQK> getYunXingQk()
        {
            //得到运行情况后存入表
            WriteLog.WriteLogFile("", "得到运行情况后显示在前台");
            SqlHelp sqh = SqlHelp.GetInstance();
            List<YunXingQK> rs = new List<YunXingQK>();
            try
            {
                string selsql = "select top 10 a.* from yunxingqk a order by a.xh desc";
                DataTable dt = sqh.getAll(selsql);
                int a = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++) {
                        YunXingQK jqqk = new YunXingQK();
                        jqqk.Xh = (int)dt.Rows[i][0];
                        Dictionary<string, JiQiYunXing> dict = new Dictionary<string, JiQiYunXing>();
                        JiQiYunXing jq1 = new JiQiYunXing();
                        jqqk.Zongxiugai = (int)dt.Rows[i][1];
                        jq1.Chuchan = (int)dt.Rows[i][2];
                        dict.Add("hao1", jq1);
                        JiQiYunXing jq2 = new JiQiYunXing();
                        jq2.Xiugai = (int)dt.Rows[i][3];
                        jq2.Chuchan = (int)dt.Rows[i][4];
                        dict.Add("hao2", jq2);
                        JiQiYunXing jq3 = new JiQiYunXing();
                        jq3.Xiugai = (int)dt.Rows[i][5];
                        jq3.Chuchan = (int)dt.Rows[i][6];
                        dict.Add("hao3", jq3);
                        JiQiYunXing zk = new JiQiYunXing();
                        zk.Xiugai = (int)dt.Rows[i][7];
                        zk.Chuchan = (int)dt.Rows[i][8];
                        dict.Add("zk", zk);
                        jqqk.Jqyx = dict;
                        jqqk.Xgsj = (DateTime)dt.Rows[i][13];                        
                        rs.Add(jqqk);
                    } 
                }                
            }
            catch (Exception ex)
            {
                WriteLog.WriteLogFile("", "得到运行情况失败");
                throw ex;
            }
            return rs;
            
        }

        /// <summary>
        /// 得到更新的运行情况
        /// </summary>
        /// <param name="youxi"></param>
        public List<YunXingQK> getUpdateQk()
        {
            //得到运行情况后存入表
            WriteLog.WriteLogFile("", "得到运行情况后显示在前台-update");
            SqlHelp sqh = SqlHelp.GetInstance();
            List<YunXingQK> rs = new List<YunXingQK>();
            try
            {
                string selsql = "select top 72 a.* from jiankong a order by a.xh desc";
                DataTable dt = sqh.getAll(selsql);
                int a = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        YunXingQK jqqk = new YunXingQK();
                        jqqk.Xh = (int)dt.Rows[i][0];
                        jqqk.Zongxiugai = (int)dt.Rows[i][1];
                        jqqk.Pcall = (string)dt.Rows[i][2];
                        jqqk.Zuanshidayu0 = (int)dt.Rows[i][3];
                        jqqk.Qiangzhedayu0 = (int)dt.Rows[i][4];
                        jqqk.Xgsj = (DateTime)dt.Rows[i][5];  
                        rs.Add(jqqk);
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteLogFile("", "得到运行情况失败");
                throw ex;
            }
            return rs;

        }

        /// <summary>
        /// 得到已卖情况
        /// </summary>
        /// <param name="youxi"></param>
        public List<Object[]> getPcYiMai(string youxi)
        {
            //得到运行情况后存入表
            WriteLog.WriteLogFile("", "得到运行情况后显示在前台-已卖");
            SqlHelp sqh = SqlHelp.GetInstance();
            List<Object[]> rs = new List<Object[]>();
            try
            {
                string selsql = "select pcname,COUNT(name) from zhanghao where yxbz='Y' and yimai='Y' and youxi='"+youxi +"' group by pcname";
                DataTable dt = sqh.getAll(selsql);
                int a = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Object[] obj = new Object[] { (string)dt.Rows[i][0], (int)dt.Rows[i][1] };
                        rs.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteLogFile("", "得到运行情况失败");
                throw ex;
            }
            return rs;

        }

        /// <summary>
        /// 得到可卖情况
        /// </summary>
        /// <param name="youxi"></param>
        public List<Object[]> getPcKeMai(string youxi)
        {
            //得到运行情况后存入表
            WriteLog.WriteLogFile("", "得到运行情况后显示在前台-可卖");
            SqlHelp sqh = SqlHelp.GetInstance();
            List<Object[]> rs = new List<Object[]>();
            try
            {
                string selsql = "select pcname,COUNT(name) from zhanghao where yxbz='Y' and yimai='N' and youxi='" + youxi + "' group by pcname";
                DataTable dt = sqh.getAll(selsql);
                int a = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Object[] obj = new Object[] { (string)dt.Rows[i][0], (int)dt.Rows[i][1] };
                        rs.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteLogFile("", "得到运行情况失败");
                throw ex;
            }
            return rs;

        }

        /// <summary>
        /// 得到导出情况
        /// </summary>
        /// <param name="youxi"></param>
        public List<string> getDaoChuShuLiang(string youxi,int shuliang=0,int zuanshi=-1,int qiangzhequan=-1)
        {
            //得到运行情况后存入表
            WriteLog.WriteLogFile("", "得到导出数量");
            SqlHelp sqh = SqlHelp.GetInstance();
            List<string> rs = new List<string>();
            try
            {
                string selsql="";
                if (zuanshi > 0 && qiangzhequan > 0)
                { selsql = "select name from zhanghao where yxbz='Y' and yimai='N' and youxi='" + youxi + "' and zuanshi>" + zuanshi + "and qiangzhequan>" + qiangzhequan; }
                else { selsql = "select name from zhanghao where yxbz='Y' and yimai='N' and youxi='" + youxi + "'"; }
                if (shuliang > 0) {
                    selsql = "select top " + shuliang + selsql.Substring(6);
                }
                DataTable dt = sqh.getAll(selsql);
                int a = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        rs.Add((string)dt.Rows[i][0]);
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteLogFile("", "得到要导出的账号失败");
                throw ex;
            }
            return rs;

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

        public DateTime getYunXingUpdateLasttime()
        {
            SqlHelp sqh = SqlHelp.GetInstance();
            lock (obj)
            {
                try
                {
                    DataTable dt = sqh.getAll("select max(gxsj) from jiankong ");
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

        public bool panDuanChongQiByUpdate(string pcname,string[] pcnames)
        {
            SqlHelp sqh = SqlHelp.GetInstance();
            lock (obj)
            {
                try
                {
                    int r = 0;
                    for (int i = 0; i < pcnames.Length; i++) {
                        if (pcname.ToUpper().Equals(pcnames[i].ToUpper())) {
                            r = i;
                        }
                    }
                    int r1 = 0;
                    string sqlsel = "select xh,pcxiugai from jiankong where xh in( select max(xh) zd from jiankong)";
                    DataTable dt = sqh.getAll(sqlsel);
                    if (dt.Rows.Count > 0)
                    {
                        string quan = (string)dt.Rows[0][1];
                        string[] quanzu=quan.Split('|');
                        r1 = int.Parse(quanzu[r]);
                        WriteLog.WriteLogFile("", "r1:"+r1);
                    }
                    int r2 = -1;
                    sqlsel = "select xh,pcxiugai from jiankong where xh in( select max(xh)-1 zd from jiankong)";
                    dt = sqh.getAll(sqlsel);
                    if (dt.Rows.Count > 0)
                    {
                        string quan = (string)dt.Rows[0][1];
                        string[] quanzu = quan.Split('|');
                        r2 = int.Parse(quanzu[r]);
                        WriteLog.WriteLogFile("", "r2:" + r2);
                    }
                    if (r1 == r2) {
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

        public bool panDuanChongQi(string pcname) {
            SqlHelp sqh = SqlHelp.GetInstance();
            lock (obj)
            {
                try
                {
                    string pn = "";
                    switch (pcname){
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
                    if (pn == null || pn.Equals("")) {
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
                        WriteLog.WriteLogFile("", "更新运行情况差异值 "+a);
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


        public void shutdown(string ip)
        {

            ConnectionOptions options = new ConnectionOptions();
            options.Username = "administrator";
            options.Password = "";
            ManagementScope scope = new ManagementScope("\\\\" + ip + "\\root\\cimv2", options);
            try
            {
                //用给定管理者用户名和口令连接远程的计算机
                scope.Connect();
                ObjectQuery oq = new ObjectQuery("select * from win32_OperatingSystem");
                ManagementObjectSearcher query1 = new ManagementObjectSearcher(scope, oq);
                ManagementObjectCollection queryCollection1 = query1.Get();
                foreach (ManagementObject mo in queryCollection1)
                {
                    string[] ss = { "" };
                    
                    mo.InvokeMethod("Reboot", ss);
                    WriteLog.WriteLogFile("", "连接" + ip + "出错");
                    
                }
            }
            catch (Exception er)
            {
                WriteLog.WriteLogFile("", "连接" + ip + "出错，出错信息为：" + er.Message);

            }


            
        }

        public List<ZhangHaoEntity> getZhangHaoList(string youxi, string yimai="", string yxbz="", int xuanqu=-1, string pcname="") {
            SqlHelp sqh = SqlHelp.GetInstance();
            //string dqsj1 = DateTime.Now.ToString("yyyy-MM-dd");
            List<ZhangHaoEntity> rs=new List<ZhangHaoEntity>();
            lock (obj)
            {
                string sql = "select name,pwd,isnull(xuanqu,-1),yimai,yxbz,isnull(zuanshi,-1),isnull(qiangzhequan,-1),pcname,xgsj from zhanghao where  youxi='"

                    + youxi + "'";
                if (yimai != null && !"".Equals(yimai)) {
                    sql += " and yimai='" + yimai + "' ";
                }
                if (yxbz != null && !"".Equals(yxbz))
                {
                    sql += " and yxbz='" + yxbz + "' ";
                }
                if (yxbz != null && xuanqu != -1)
                {
                    sql += " and xuanqu=" + xuanqu + " ";
                }
                if (pcname != null && !"".Equals(pcname))
                {
                    sql += " and pcname='" + pcname + "' ";
                }
                DataTable dt = sqh.getAll(sql);
                if (dt.Rows.Count > 0)
                {
                    //name,pwd,isnull(xuanqu,-1),yimai,yxbz,isnull(zuanshi,-1),isnull(qiangzhe,-1),pcname,xgsj
                    foreach(DataRow r in dt.Rows){
                        ZhangHaoEntity zhe=new ZhangHaoEntity();
                        zhe.Name=(string)r[0];
                        zhe.Pwd=(string)r[1];
                        zhe.Xuanqu=(int)r[2];
                        zhe.Yimai=(string)r[3];
                        zhe.Yxbz=(string)r[4];
                        zhe.Zuanshi=(int)r[5];
                        zhe.Qiangzhe=(int)r[6];
                        zhe.Pcname=(string)r[7];
                        zhe.Xgsj = (DateTime)r[8];
                        zhe.Youxi = youxi;
                        rs.Add(zhe);
                        //WriteLog.WriteLogFile("", "找到需要练级的账号" + name + " " + pwd + ",xuanqu " + xuanqu + "并置为登录中");
                    }
                }
            }
            return rs;
        }

        public List<ZhangHaoEntity> getZhangHaoListShuLiang(string youxi, int shuliang = 0, int zuanshi = -1, int qiangzhequan = -1)
        {
            SqlHelp sqh = SqlHelp.GetInstance();
            string dqsj = DateTime.Now.ToString("yyyy-MM-dd");
            List<ZhangHaoEntity> rs = new List<ZhangHaoEntity>();
            lock (obj)
            {
                string selsql1 = "";
                if (zuanshi > 0 && qiangzhequan > 0)
                { selsql1 = "select name from zhanghao where yxbz='Y' and yimai='N' and youxi='" + youxi + "' and zuanshi>" + zuanshi + "and qiangzhequan>" + qiangzhequan; }
                else { selsql1 = "select name from zhanghao where yxbz='Y' and yimai='N' and youxi='" + youxi + "'"; }
                if (shuliang > 0)
                {
                    selsql1 = "select top " + shuliang + selsql1.Substring(6);
                }

                string updatesql = "update zhanghao with (UPDLOCK) set yxbz='N',yimai='Y' "
                + " where name in ( " + selsql1+" )";
                sqh.update(updatesql);

                string selsql = "";
                if (zuanshi > 0 && qiangzhequan > 0)
                { selsql = "select name,pwd,isnull(xuanqu,-1),isnull(zuanshi,-1),isnull(qiangzhequan,-1) from zhanghao where yxbz='N' and yimai='Y' and youxi='" + youxi + "' and zuanshi>" + zuanshi + "and qiangzhequan>" + qiangzhequan; }
                else { selsql = "select name,pwd,isnull(xuanqu,-1),isnull(zuanshi,-1),isnull(qiangzhequan,-1) from zhanghao where yxbz='N' and yimai='Y' and youxi='" + youxi + "'"; }
                string selcha = selsql;
                if (shuliang > 0)
                {
                    selcha = "select top " + shuliang + selsql.Substring(6);
                }
                DataTable dt = sqh.getAll(selcha);
                if (dt.Rows.Count > 0)
                {
                    //name,pwd,isnull(xuanqu,-1),yimai,yxbz,isnull(zuanshi,-1),isnull(qiangzhe,-1),pcname,xgsj
                    foreach (DataRow r in dt.Rows)
                    {
                        ZhangHaoEntity zhe = new ZhangHaoEntity();
                        zhe.Name = (string)r[0];
                        zhe.Pwd = (string)r[1];
                        zhe.Xuanqu = (int)r[2];                       
                        zhe.Zuanshi = (int)r[3];
                        zhe.Qiangzhe = (int)r[4];
                        zhe.Youxi = youxi;
                        rs.Add(zhe);
                        //WriteLog.WriteLogFile("", "找到需要练级的账号" + name + " " + pwd + ",xuanqu " + xuanqu + "并置为登录中");
                    }
                }
                if (zuanshi > 0 && qiangzhequan > 0)
                { selsql = "select name from zhanghao where yxbz='N' and yimai='Y' and youxi='" + youxi + "' and zuanshi>" + zuanshi + "and qiangzhequan>" + qiangzhequan; }
                else { selsql = "select name from zhanghao where yxbz='N' and yimai='Y' and youxi='" + youxi + "'"; }
                selcha = selsql;
                if (shuliang > 0)
                {
                    selcha = "select top " + shuliang + " name " + selcha.Substring(6);
                }
                updatesql = "update zhanghao with (UPDLOCK) set yxbz='Y' "
                + " where name in ( " + selcha + " )";
                sqh.update(updatesql);

            }
            return rs;
        }

        public void updateYiMai(string youxi, string name)
        {
            //服务器上有登录账号后置为登陆中
            SqlHelp sqh = SqlHelp.GetInstance();
            lock (obj)
            {
                try
                {
                    sqh.update("update zhanghao with (UPDLOCK) set yimai='Y'  where name='" + name + "' and youxi='" + youxi + "'");
                }
                catch (Exception ex)
                {
                    WriteLog.WriteLogFile("", "更新账号的已卖标志,更新失败" + ex.Message);
                    throw ex;
                }
            }
        }
    }
}
