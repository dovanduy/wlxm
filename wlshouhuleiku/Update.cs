using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Reflection;
using COMMON;
using System.Threading;
using System.Windows.Forms;


namespace SH_MyUtil
{
    /// <summary>  
    /// 更新完成触发的事件  
    /// </summary>  
    public delegate void UpdateState();
    /// <summary>  
    /// 程序更新  
    /// </summary> 
    public class SoftUpdate
    {
        private string download;
        private const string updateUrl = "http://192.168.4.44/update.xml";//升级配置的XML文件地址  

        #region 构造函数
        public SoftUpdate() { }

        /// <summary>  
        /// 程序更新  
        /// </summary>  
        /// <param name="file">要更新的文件</param>  
        public SoftUpdate(string file, string softName)
        {
            this.LoadFile = file;
            this.SoftName = softName;
        }
        #endregion

        #region 属性
        private string loadFile;
        private string newVerson;
        private string softName;
        private bool isUpdate;       

        /// <summary>  
        /// 或取是否需要更新  
        /// </summary>  
        public bool IsUpdate
        {
            get
            {
                checkUpdate();
                return isUpdate;
            }
        }

        /// <summary>  
        /// 要检查更新的文件  
        /// </summary>  
        public string LoadFile
        {
            get { return loadFile; }
            set { loadFile = value; }
        }

        /// <summary>  
        /// 程序集新版本  
        /// </summary>  
        public string NewVerson
        {
            get { return newVerson; }
        }

        /// <summary>  
        /// 升级的名称  
        /// </summary>  
        public string SoftName
        {
            get { return softName; }
            set { softName = value; }
        }

        private string _finalZipName = string.Empty;

        public string FinalZipName
        {
            get { return _finalZipName; }
            set { _finalZipName = value; }
        }

        #endregion

        /// <summary>  
        /// 更新完成时触发的事件  
        /// </summary>  
        public event UpdateState UpdateFinish;
        private void isFinish()
        {
            if (UpdateFinish != null)
                UpdateFinish();
        }

        /// <summary>  
        /// 下载更新  
        /// </summary>  
        public void Update()
        {
            try
            {
                if (!isUpdate)
                    return;
                WebClient wc = new WebClient();
                string filename = "";
                string exten = download.Substring(download.LastIndexOf("."));
                if (loadFile.IndexOf(@"\") == -1)
                    filename = "Update_" + Path.GetFileNameWithoutExtension(loadFile) + exten;
                else
                    filename = Path.GetDirectoryName(loadFile) + "\\Update_" + Path.GetFileNameWithoutExtension(loadFile) + exten;

                FinalZipName = filename;
                //wc.DownloadFile(download, filename);
                wc.DownloadFileAsync(new Uri(download), filename);
                wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                wc.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(wc_DownloadFileCompleted);
                //wc.Dispose();

            }
            catch
            {
                throw new Exception("更新出现错误，网络连接失败！");
            }
        }

        void wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            (sender as WebClient).Dispose();
            isFinish();
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

            //System.Diagnostics.Debug.WriteLine(e.ProgressPercentage);
            COMMON.CommonMethod.autostep = e.ProgressPercentage;
            //Thread.Sleep(100);

        }

        /// <summary>  
        /// 检查是否需要更新  
        /// </summary>  
        public void checkUpdate()
        {
            try
            {
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(updateUrl);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(stream);
                XmlNode list = xmlDoc.SelectSingleNode("Update");
                foreach (XmlNode node in list)
                {
                    if (node.Name == "Soft" && node.Attributes["Name"].Value.ToLower() == SoftName.ToLower())
                    {
                        foreach (XmlNode xml in node)
                        {
                            if (xml.Name == "Verson")
                                newVerson = xml.InnerText;
                            else
                                download = xml.InnerText;
                        }
                    }
                }

                Version ver = new Version(newVerson);
                string versons = "1.0.0.0";
                XmlDocument xmlDoc2 = new XmlDocument();
                xmlDoc2.Load(Application.StartupPath + "\\" + "program\\update.xml");
                list = xmlDoc2.SelectSingleNode("Update");
                foreach (XmlNode node in list)
                {
                    if (node.Name == "Soft" && node.Attributes["Name"].Value.ToLower() == SoftName.ToLower())
                    {
                        foreach (XmlNode xml in node)
                        {
                            if (xml.Name == "Verson")
                                versons = xml.InnerText;                            
                        }
                    }
                }
                Version verson = new Version(versons);  
                int tm = verson.CompareTo(ver);
                if (tm >= 0)
                    isUpdate = false;
                else
                    isUpdate = true;
            }
            catch (Exception ex)
            {
                throw new Exception("更新出现错误，请确认网络连接无误后重试！"+ex.Message);
            }
        }

        /// <summary>  
        /// 获取要更新的文件  
        /// </summary>  
        /// <returns></returns>  
        public override string ToString()
        {
            return this.loadFile;
        }
    }

}