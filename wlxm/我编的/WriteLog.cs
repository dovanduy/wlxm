using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Threading;

namespace MyUtil
{
    public class WriteLog
    {

        private static ReaderWriterLockSlim LogWriteLock = new ReaderWriterLockSlim();
        /// <summary>
        /// 写入日志文件
        /// </summary>
        /// <param name="input"></param>
        public static void WriteLogFile(string moniqi,string input)
        {
            MyFuncUtil.myxinxitishi(moniqi+" "+input);
            string dir = "C:\\mylog\\" + DateTime.Now.Year+
                    DateTime.Now.Month +
                    DateTime.Now.Day+"\\";
            ///指定日志文件的目录
            string fname2 = dir +
            DateTime.Now.Year + '-' +
            DateTime.Now.Month + '-' +
            DateTime.Now.Day + "_LogFile" + ".txt";
            string fname = dir+moniqi+"_LogFile" + ".txt";
            if (!Directory.Exists(dir))//如果不存在就创建file文件夹　　             　　              
            {
                Directory.CreateDirectory(dir); 
            }

            if (!File.Exists(fname))
            {
                //不存在文件
                File.Create(fname).Dispose();//创建该文件
            }

            /**/
            ///判断文件是否存在以及是否大于2K
            /* if (finfo.Length > 1024 * 1024 * 10)
            {
            /**/
            //文件超过10MB则重命名
            /* File.Move(fname, Directory.GetCurrentDirectory() + DateTime.Now.TimeOfDay + "\\LogFile.txt");
            //删除该文件
            //finfo.Delete();
            }*/
            try
            {
                LogWriteLock.EnterWriteLock();


                using (StreamWriter log = new StreamWriter(fname, true))
                {
                    //FileStream fs = new FileStream(url, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);FileMode.Append

                    ///设置写数据流的起始位置为文件流的末尾
                    log.BaseStream.Seek(0, SeekOrigin.End);

                    ///写入“Log Entry : ”
                    log.Write("\n\rLog Entry : ");

                    ///写入当前主机名 模拟器名字并换行
                    //log.Write("{0} {1} \t", getMachineName(), moniqi);
                    ///写入当前系统时间并换行
                    log.Write("{0} {1} {2}  \n\r", moniqi + "__", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                    ///写入日志内容并换行
                    log.Write("{0} {1}  \n\r", moniqi+"__",input);

                    //清空缓冲区
                    log.Flush();
                    //关闭流
                    log.Close();
                }
            }
            catch (Exception) { }
            finally {
                LogWriteLock.ExitWriteLock();
            }
        }


        /// <summary>
        /// 写入错误日志文件
        /// </summary>
        /// <param name="input"></param>
        public static void WriteErrorFile(string moniqi, string input)
        {
            string dir = "C:\\mylog\\";
            ///指定日志文件的目录
            string fname = dir +
            DateTime.Now.Year + '-' +
            DateTime.Now.Month + '-' +
            DateTime.Now.Day + "_LogError" + ".txt";

            if (!Directory.Exists(dir))//如果不存在就创建file文件夹　　             　　              
            {
                Directory.CreateDirectory(dir);
            }

            if (!File.Exists(fname))
            {
                //不存在文件
                File.Create(fname).Dispose();//创建该文件
            }

            /**/
            ///判断文件是否存在以及是否大于2K
            /* if (finfo.Length > 1024 * 1024 * 10)
            {
            /**/
            //文件超过10MB则重命名
            /* File.Move(fname, Directory.GetCurrentDirectory() + DateTime.Now.TimeOfDay + "\\LogFile.txt");
            //删除该文件
            //finfo.Delete();
            }*/
            try
            {
                LogWriteLock.EnterWriteLock();


                using (StreamWriter log = new StreamWriter(fname, true))
                {
                    //FileStream fs = new FileStream(url, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);FileMode.Append

                    ///设置写数据流的起始位置为文件流的末尾
                    log.BaseStream.Seek(0, SeekOrigin.End);

                    ///写入“Log Entry : ”
                    log.Write("\n\rLog Entry : ");

                    ///写入当前主机名 模拟器名字并换行
                    log.Write("{0} {1} \t", getMachineName(), moniqi);
                    ///写入当前系统时间并换行
                    log.Write("{0} {1} \n\r", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                    ///写入日志内容并换行
                    log.Write(input + "\n\r");

                    //清空缓冲区
                    log.Flush();
                    //关闭流
                    log.Close();
                }
            }
            catch (Exception) { }
            finally
            {
                LogWriteLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// 写入账号信息文件
        /// </summary>
        /// <param name="input"></param>
        public static void WriteZhangHaoFile(int dqinx, string username,string password,string yxbz)
        {
            string dir = "C:\\mylog\\";
            ///指定日志文件的目录
            string fname = dir + "zhanghao" + ".txt";

            if (!Directory.Exists(dir))//如果不存在就创建file文件夹　　             　　              
            {
                Directory.CreateDirectory(dir);
            }

            if (!File.Exists(fname))
            {
                //不存在文件
                File.Create(fname).Dispose();//创建该文件
            }

            /**/
            ///判断文件是否存在以及是否大于2K
            /* if (finfo.Length > 1024 * 1024 * 10)
            {
            /**/
            //文件超过10MB则重命名
            /* File.Move(fname, Directory.GetCurrentDirectory() + DateTime.Now.TimeOfDay + "\\LogFile.txt");
            //删除该文件
            //finfo.Delete();
            }*/
            try
            {
                LogWriteLock.EnterWriteLock();


                using (StreamWriter log = new StreamWriter(fname, true))
                {
                    //FileStream fs = new FileStream(url, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);FileMode.Append

                    ///设置写数据流的起始位置为文件流的末尾
                    log.BaseStream.Seek(0, SeekOrigin.End);
                    

                    ///写入当前主机名 模拟器名字并换行
                    log.Write("{0} {1} {2} {3} \n\r", dqinx+"|",username+"|",password+"|",yxbz);
                    
                    

                    //清空缓冲区
                    log.Flush();
                    //关闭流
                    log.Close();
                }
            }
            catch (Exception) { }
            finally
            {
                LogWriteLock.ExitWriteLock();
            }
        }


        /// <summary>
        /// 将异常打印到LOG文件
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="LogAddress">日志文件地址</param>
        public static void WriteLogErr(Exception ex, string LogAddress = "")
        {
            //如果日志文件为空，则默认在Debug目录下新建 YYYY-mm-dd_Log.log文件
            if (LogAddress == "")
            {
                ///指定日志文件的目录
                LogAddress = "C:\\mylog\\" +
                DateTime.Now.Year + '-' +
                DateTime.Now.Month + '-' +
                DateTime.Now.Day + "_Log.log";
            }

            FileInfo finfo = new FileInfo(LogAddress);

            if (!finfo.Exists)
            {
                FileStream fs;
                fs = File.Create(LogAddress);
                fs.Close();
                finfo = new FileInfo(LogAddress);
            }

            //把异常信息输出到文件
            StreamWriter sw = new StreamWriter(LogAddress, true);
            sw.WriteLine("当前时间：" + DateTime.Now.ToString());
            sw.WriteLine("异常信息：" + ex.Message);
            sw.WriteLine("异常对象：" + ex.Source);
            sw.WriteLine("调用堆栈：\n" + ex.StackTrace.Trim());
            sw.WriteLine("触发方法：" + ex.TargetSite);
            sw.WriteLine();
            sw.Close();
        }

        /// <summary>
        /// 得到电脑主机名字
        /// </summary>
        /// <returns></returns>
        public static string getMachineName() {
            return Environment.MachineName;
        }

        
    }
}
