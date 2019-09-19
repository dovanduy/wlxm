using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Update;
namespace AutoUpdate
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (checkUpdateLoad())
            {
                Application.Exit();
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static bool checkUpdateLoad()
        {
            bool result = false;
            SoftUpdate app = new SoftUpdate(Application.ExecutablePath, "ExceTransforCsv");
            try
            {
                if (app.IsUpdate && MessageBox.Show("检查到新版本，是否更新？", "版本检查", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string path = Application.StartupPath.Replace("program", "");
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = "AutoUpdate.exe";
                    process.StartInfo.WorkingDirectory = path;//要掉用得exe路径例如:"C:\windows";               
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                result = false;
            }
            return result;
        }
    }
}
