using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace SH_MyUtil
{
    public class UpdateCaoZuo
    {
        public void updateWlxm() {
            if (File.Exists(Application.StartupPath + "\\Update_autoUpdate.rar"))
            {
                try
                {
                    File.Delete(Application.StartupPath + "\\Update_autoUpdate.rar");
                }
                catch (Exception)
                {


                }

            }
            if (Directory.Exists(Application.StartupPath + "\\autoupload"))
            {
                try
                {
                    Directory.Delete(Application.StartupPath + "\\autoupload", true);
                }
                catch (Exception)
                {


                }
            }

            //检查服务端是否有新版本程序
            checkUpdate();
        }

        SoftUpdate app = new SoftUpdate(Application.ExecutablePath, "ExceTransforCsv");
        public void checkUpdate()
        {

            app.UpdateFinish += new UpdateState(app_UpdateFinish);
            try
            {
                if (app.IsUpdate)
                {
                    app.Update();
                }
                else
                {
                    MessageBox.Show("未检测到新版本!");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void app_UpdateFinish()
        {
            //解压下载后的文件
            string path = app.FinalZipName;
            if (File.Exists(path))
            {
                //后改的 先解压滤波zip植入ini然后再重新压缩
                string dirEcgPath = Application.StartupPath + "\\" + "autoupload";
                if (!Directory.Exists(dirEcgPath))
                {
                    Directory.CreateDirectory(dirEcgPath);
                }
                string dirEcgPath2 = Application.StartupPath + "\\" + "program";
                if (!Directory.Exists(dirEcgPath2))
                {
                    Directory.CreateDirectory(dirEcgPath2);
                }
                //开始解压压缩包
                string myref = "ref";
                MyFuncUtil.UnRarOrZip(dirEcgPath, path, true, "");
                MessageBox.Show(myref);
                try
                {

                    //复制新文件替换旧文件
                    DirectoryInfo TheFolder = new DirectoryInfo(dirEcgPath);
                    foreach (FileInfo NextFile in TheFolder.GetFiles())
                    {
                        File.Copy(NextFile.FullName, Application.StartupPath + "\\program\\" + NextFile.Name, true);
                    }
                    Directory.Delete(dirEcgPath, true);
                    File.Delete(path);
                    //覆盖完成 重新启动程序
                    path = Application.StartupPath + "\\program";
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = "开发计划.txt";
                    process.StartInfo.WorkingDirectory = path;//要掉用得exe路径例如:"C:\windows";               
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();

                    Application.Exit();
                }
                catch (Exception)
                {
                    MessageBox.Show("请关闭系统在执行更新操作!");
                    Application.Exit();
                }
            }
        }
    }
}
