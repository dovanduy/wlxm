using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xDM;
namespace xinbanjeitu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IxDm dm = new xDm();
            dm.StartRunTime();
            MydmFunc my = new MydmFunc(dm);
            string a = "GxWindowClass";
            int jubing = dm.FindWindowEx(0, a, "");
            int res = my.bindWindow2(jubing, "");
            if (res <= 0)
            {
                MessageBox.Show(jubing + "句柄绑定不成功，请重试！", "提示1", MessageBoxButtons.OK);
                return;
            }
            string bmpname = dm.GetTime() + "";
            my.captureBmp(jubing, @"c:\mypic", bmpname + ".bmp");
            Thread.Sleep(2000);
            if (dm.IsFileExist(@"C:\mypic\" + bmpname + ".bmp") == 1)
            {
                Process cmd = new Process();
                cmd.StartInfo.FileName = appName;
                cmd.StartInfo.Arguments = @"C:\mypic\" + bmpname + ".bmp";
                cmd.Start();
            }
            else
            {
                myxinxitishi("截图黑屏，请重试" + jubing + " " + res);
                WriteLog.WriteLogFile("", "屏幕全黑无法截图");
            }
        }
    }
}
