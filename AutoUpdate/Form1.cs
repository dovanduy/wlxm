using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Update;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Diagnostics;


namespace AutoUpdate
{
    public partial class Form1 : Form
    {
        
        
        public Form1()
        {

            InitializeComponent();
            //清除之前下载来的rar文件
            if (File.Exists(Application.StartupPath + "\\Update_autoUpdate.zip"))
            {
                try
                {
                    File.Delete(Application.StartupPath + "\\Update_autoUpdate.zip");
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
            timer1.Enabled = true;
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
                UnRarOrZip(dirEcgPath, path, true, "");
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
 
        
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label1.Text = "下载文件进度:" + COMMON.CommonMethod.autostep.ToString() + "%";
            this.progressBar1.Value = COMMON.CommonMethod.autostep;
            if (COMMON.CommonMethod.autostep == 100)
            {
                timer1.Enabled = false;
            }
        }

        public string unZipFile(string TargetFile, string fileDir, ref string msg)
        {
            string rootFile = "";
            msg = "";
            try
            {
                //读取压缩文件（zip文件），准备解压缩
                ZipInputStream inputstream = new ZipInputStream(File.OpenRead(TargetFile.Trim()));
                ZipEntry entry;
                string path = fileDir;
                //解压出来的文件保存路径
                string rootDir = "";
                //根目录下的第一个子文件夹的名称
                while ((entry = inputstream.GetNextEntry()) != null)
                {
                    rootDir = Path.GetDirectoryName(entry.Name);
                    //得到根目录下的第一级子文件夹的名称
                    if (rootDir.IndexOf("\\") >= 0)
                    {
                        rootDir = rootDir.Substring(0, rootDir.IndexOf("\\") + 1);
                    }
                    string dir = Path.GetDirectoryName(entry.Name);
                    //得到根目录下的第一级子文件夹下的子文件夹名称
                    string fileName = Path.GetFileName(entry.Name);
                    //根目录下的文件名称
                    if (dir != "")
                    {
                        //创建根目录下的子文件夹，不限制级别
                        if (!Directory.Exists(fileDir + "\\" + dir))
                        {
                            path = fileDir + "\\" + dir;
                            //在指定的路径创建文件夹
                            Directory.CreateDirectory(path);
                        }
                    }
                    else if (dir == "" && fileName != "")
                    {
                        //根目录下的文件
                        path = fileDir;
                        rootFile = fileName;
                    }
                    else if (dir != "" && fileName != "")
                    {
                        //根目录下的第一级子文件夹下的文件
                        if (dir.IndexOf("\\") > 0)
                        {
                            //指定文件保存路径
                            path = fileDir + "\\" + dir;
                        }
                    }
                    if (dir == rootDir)
                    {
                        //判断是不是需要保存在根目录下的文件
                        path = fileDir + "\\" + rootDir;
                    }
 
                    //以下为解压zip文件的基本步骤
                    //基本思路：遍历压缩文件里的所有文件，创建一个相同的文件
                    if (fileName != String.Empty)
                    {
                        FileStream fs = File.Create(path + "\\" + fileName);
                        int size = 2048;
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            size = inputstream.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                fs.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }
                        fs.Close();
                    }
                }
                inputstream.Close();
                msg = "解压成功！";
                return rootFile;
            }
            catch (Exception ex)
            {
                msg = "解压失败，原因：" + ex.Message;
                return "1;" + ex.Message;
            }
        }
        /// <summary>
        /// 解压RAR和ZIP文件(需存在Winrar.exe(只要自己电脑上可以解压或压缩文件就存在Winrar.exe))
        /// </summary>
        /// <param name="UnPath">解压后文件保存目录</param>
        /// <param name="rarPathName">待解压文件存放绝对路径（包括文件名称）</param>
        /// <param name="IsCover">所解压的文件是否会覆盖已存在的文件(如果不覆盖,所解压出的文件和已存在的相同名称文件不会共同存在,只保留原已存在文件)</param>
        /// <param name="PassWord">解压密码(如果不需要密码则为空)</param>
        /// <returns>true(解压成功);false(解压失败)</returns>
        public static bool UnRarOrZip(string UnPath, string rarPathName, bool IsCover, string PassWord)
        {
            if (!Directory.Exists(UnPath))
                Directory.CreateDirectory(UnPath);
            Process Process1 = new Process();
            Process1.StartInfo.FileName = "Winrar.exe";
            Process1.StartInfo.CreateNoWindow = true;
            string cmd = "";
            if (!string.IsNullOrEmpty(PassWord) && IsCover)
                //解压加密文件且覆盖已存在文件( -p密码 )
                cmd = string.Format(" x -p{0} -o+ {1} {2} -y", PassWord, rarPathName, UnPath);
            else if (!string.IsNullOrEmpty(PassWord) && !IsCover)
                //解压加密文件且不覆盖已存在文件( -p密码 )
                cmd = string.Format(" x -p{0} -o- {1} {2} -y", PassWord, rarPathName, UnPath);
            else if (IsCover)
                //覆盖命令( x -o+ 代表覆盖已存在的文件)
                cmd = string.Format(" x -o+ {0} {1} -y", rarPathName, UnPath);
            else
                //不覆盖命令( x -o- 代表不覆盖已存在的文件)
                cmd = string.Format(" x -o- {0} {1} -y", rarPathName, UnPath);
            //命令
            Process1.StartInfo.Arguments = cmd;
            Process1.Start();
            Process1.WaitForExit();//无限期等待进程 winrar.exe 退出
            //Process1.ExitCode==0指正常执行，Process1.ExitCode==1则指不正常执行
            if (Process1.ExitCode == 0)
            {
                Process1.Close();
                return true;
            }
            else
            {
                Process1.Close();
                return false;
            }

        }

        /// <summary>
        /// 压缩文件成RAR或ZIP文件(需存在Winrar.exe(只要自己电脑上可以解压或压缩文件就存在Winrar.exe))
        /// </summary>
        /// <param name="filesPath">将要压缩的文件夹或文件的绝对路径</param>
        /// <param name="rarPathName">压缩后的压缩文件保存绝对路径（包括文件名称）</param>
        /// <param name="IsCover">所压缩文件是否会覆盖已有的压缩文件(如果不覆盖,所压缩文件和已存在的相同名称的压缩文件不会共同存在,只保留原已存在压缩文件)</param>
        /// <param name="PassWord">压缩密码(如果不需要密码则为空)</param>
        /// <returns>true(压缩成功);false(压缩失败)</returns>
        public static bool CondenseRarOrZip(string filesPath, string rarPathName, bool IsCover, string PassWord)
        {
            string rarPath = Path.GetDirectoryName(rarPathName);
            if (!Directory.Exists(rarPath))
                Directory.CreateDirectory(rarPath);
            Process Process1 = new Process();
            Process1.StartInfo.FileName = "Winrar.exe";
            Process1.StartInfo.CreateNoWindow = true;
            string cmd = "";
            if (!string.IsNullOrEmpty(PassWord) && IsCover)
                //压缩加密文件且覆盖已存在压缩文件( -p密码 -o+覆盖 )
                cmd = string.Format(" a -ep1 -p{0} -o+ {1} {2} -r", PassWord, rarPathName, filesPath);
            else if (!string.IsNullOrEmpty(PassWord) && !IsCover)
                //压缩加密文件且不覆盖已存在压缩文件( -p密码 -o-不覆盖 )
                cmd = string.Format(" a -ep1 -p{0} -o- {1} {2} -r", PassWord, rarPathName, filesPath);
            else if (string.IsNullOrEmpty(PassWord) && IsCover)
                //压缩且覆盖已存在压缩文件( -o+覆盖 )
                cmd = string.Format(" a -ep1 -o+ {0} {1} -r", rarPathName, filesPath);
            else
                //压缩且不覆盖已存在压缩文件( -o-不覆盖 )
                cmd = string.Format(" a -ep1 -o- {0} {1} -r", rarPathName, filesPath);
            //命令
            Process1.StartInfo.Arguments = cmd;
            Process1.Start();
            Process1.WaitForExit();//无限期等待进程 winrar.exe 退出
            //Process1.ExitCode==0指正常执行，Process1.ExitCode==1则指不正常执行
            if (Process1.ExitCode == 0)
            {
                Process1.Close();
                return true;
            }
            else
            {
                Process1.Close();
                return false;
            }
        }
    

    }
}
