using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MyUtil
{
    public class SqlHelp
    {
        #region 单例模式变量
        private static readonly object obj = new object();
        private static SqlHelp mysql = null;
        private static SqlConnection conn = null;
        #endregion
        

        /*
         USE [yiquan]
         GO
            SET ANSI_NULLS ON
            GO
            SET QUOTED_IDENTIFIER ON
            GO
            SET ANSI_PADDING ON
            GO
            CREATE TABLE [dbo].[zhanghao](
            [name] [varchar](50) NULL,
            [pwd] [varchar](50) NULL,
            [yxbz] [char](1) NULL,
            [dengluzhong] [char](1) NULL,
            [dqindex] [int] NULL,
            [pcname] [varchar](50) NULL,
            [img] [varchar](50) NULL,
            [imgtime] [date] NULL,
            [daydenglu] [text] NULL,
            [yimai] [char](1) NULL
            ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

            GO

            SET ANSI_PADDING OFF
            GO
         */
        /// <summary>
        /// 单例模式====双层互锁
        /// </summary>
        /// <returns></returns>
        public static SqlHelp GetInstance()
        {
            if (mysql == null)
            {
                lock (obj)
                {
                    mysql = new SqlHelp();
                    string connString = null;
                    if (WriteLog.getMachineName().ToLower().Equals("wlzhongkong") || WriteLog.getMachineName().ToLower().Equals("wlbgs"))
                    {
                        connString = "Data Source="+WriteLog.getMachineName().ToLower()+@"\SQLEXPRESS;Initial Catalog=yiquan;User ID=sa;Password=123456";
                    }
                    else {
                        connString = @"Data Source=192.168.4.44;Initial Catalog=yiquan;User ID=sa;Password=123456";
                    }
                    conn = new SqlConnection(connString);
                }
            }
            return mysql;
        }

        public SqlConnection getConn() {
            return conn;
        }

        public SqlConnection getConn(string fuwuqi)
        {
            string connString = @"Data Source="+fuwuqi+";Initial Catalog=yiquan;User ID=sa;Password=123456";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }

        public DataTable getAll(string sql) {
            WriteLog.WriteLogFile("", sql);
            DataTable dt = new DataTable();
            lock (obj)
            {
                SqlConnection conn = getConn();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                try
                {
                    conn.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter(sql, conn);                    
                    dt = new DataTable();
                    sqlDa.Fill(dt);
                }
                catch (Exception ex)
                {
                    WriteLog.WriteLogFile("", ex.Message);
                    throw new Exception(ex.Message);
                }
                finally
                {
                    //close(conn);
                }
            }
            return dt;
        }

        public void update(string sql) {
            WriteLog.WriteLogFile("", sql);
            lock (obj){
                SqlConnection conn = getConn();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                try
                {
                    conn.Open();
                    SqlCommand sqlCmd = new SqlCommand(sql, conn);                    
                    sqlCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    WriteLog.WriteLogFile("", ex.Message);
                    throw new Exception(ex.Message);
                }
                finally
                {
                    //close(conn);
                }
            }
            
        }

        public void DoTran(string select,string update)
        {

            SqlConnection conn = getConn();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            SqlCommand myComm = new SqlCommand();
            try
            {
                myComm.Connection = conn;
                myComm.CommandText = "DECLARE @TranName VARCHAR(20) ";
                myComm.CommandText = "DECLARE @myname VARCHAR(20) ";
                myComm.CommandText += "SELECT @TranName = 'MyTransaction' ";
                myComm.CommandText += "BEGIN TRANSACTION @TranName ";
                myComm.CommandText += "USE yiquan ";
                myComm.CommandText += select;//"USE yiquan ";
                myComm.CommandText += update;// "UPDATE roysched SET royalty = royalty * 1.10 WHERE title_id LIKE 'Pc%' ";
                myComm.CommandText += "COMMIT TRANSACTION MyTransaction ";
                myComm.ExecuteNonQuery();
                
            }
            catch (Exception err)
            {
                throw new ApplicationException("事务操作出错，系统信息：" + err.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void close(SqlConnection conn) {
            if (conn != null ) {
                conn.Close();
            }
        }
        
        /* string connString = @"Data Source=DEEP-2019RJUDYT\SQLEXPRESS;Initial Catalog=yiquan;User ID=sa;Password=123456";
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
         */
    }
}
