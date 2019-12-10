using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SH_MyUtil;
using System.Diagnostics;

namespace wlsh
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //处理未捕获的异常
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.Run(new Form1());
            glExitApp = true;//标志应用程序可以退出
        }
        /// <summary>
        /// 是否退出应用程序
        /// </summary>
        static bool glExitApp = false;
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            WriteLog.WriteErrorFile("IsTerminating : " + e.IsTerminating.ToString());
            WriteLog.WriteErrorFile(e.ExceptionObject.ToString());
            Application.Exit();
            while (true)
            {//循环处理，否则应用程序将会退出
                if (glExitApp)
                {//标志应用程序可以退出，否则程序退出后，进程仍然在运行
                    WriteLog.WriteErrorFile("ExitApp");
                    return;
                }
                System.Threading.Thread.Sleep(2 * 1000);
            };

        }
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            WriteLog.WriteErrorFile("Application_ThreadException:" +
                e.Exception.Message);
            WriteLog.WriteErrorFile("异常信息：" + e.Exception.Message);
            WriteLog.WriteErrorFile("异常对象：" + e.Exception.Source);
            WriteLog.WriteErrorFile("调用堆栈：\n" + e.Exception.StackTrace.Trim());
            WriteLog.WriteErrorFile("触发方法：" + e.Exception.TargetSite);
            WriteLog.WriteErrorFile(e.Exception.ToString());
            CmdStartCTIProc(Application.ExecutablePath, "cmd params");//放到捕获事件的处理代码后，重启程序，需要时加上重启的参数
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 在命令行窗口中执行
        /// </summary>
        /// <param name="sExePath"></param>
        /// <param name="sArguments"></param>
        static void CmdStartCTIProc(string sExePath, string sArguments)
        {
            Process p = new Process();
            p.StartInfo.FileName = @"C:\Program Files (x86)\默认公司名称\Sh_setup\wlsh.exe"; 
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            p.Start();
            p.StandardInput.WriteLine(sExePath + " " + sArguments);
            p.StandardInput.WriteLine("exit");
            p.Close();

            System.Threading.Thread.Sleep(2000);//必须等待，否则重启的程序还未启动完成；根据情况调整等待时间
        }
    }
}
