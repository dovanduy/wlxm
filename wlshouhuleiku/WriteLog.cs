using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Threading;

namespace SH_MyUtil
{
    public class WriteLog
    {

        private static ReaderWriterLockSlim LogWriteLock = new ReaderWriterLockSlim();
        /// <summary>
        /// 写入日志文件
        /// </summary>
        /// <param name="input"></param>
        public static void WriteLogFile(string input)
        {
            string dir = "d:\\mylog\\" + DateTime.Now.Year+
                    DateTime.Now.Month +
                    DateTime.Now.Day+"\\";
            ///指定日志文件的目录
            string fname2 = dir +
            DateTime.Now.Year + '-' +
            DateTime.Now.Month + '-' +
            DateTime.Now.Day + "_LogFile" + ".txt";
            if (!Directory.Exists(dir))//如果不存在就创建file文件夹　　             　　              
            {
                Directory.CreateDirectory(dir); 
            }

            if (!File.Exists(fname2))
            {
                //不存在文件
                File.Create(fname2).Dispose();//创建该文件
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


                using (StreamWriter log = new StreamWriter(fname2, true))
                {
                    //FileStream fs = new FileStream(url, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);FileMode.Append

                    ///设置写数据流的起始位置为文件流的末尾
                    log.BaseStream.Seek(0, SeekOrigin.End);

                    ///写入“Log Entry : ”
                    log.Write("\n\rLog Entry : ");

                    ///写入当前主机名 模拟器名字并换行
                    //log.Write("{0} {1} \t", getMachineName(), moniqi);
                    ///写入当前系统时间并换行
                    log.Write("{0} {1}  \n\r",   DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                    ///写入日志内容并换行
                    log.Write("{0}  \n\r", input);

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


        

        

        
    }
}
