using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace wlxm
{
    public partial class Form2 : Form
    {
        private static Form2 fr = new Form2();
        private delegate void changeText(string result);
        private Form2()
        {
            InitializeComponent();
            Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.PointToScreen(p);
            this.Location = p;
        }

        public static Form2 getInstance(){
            if (fr == null)
            {
                fr = new Form2();
            }
            return fr;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.label1.Text = "";
            Thread.Sleep(3000);
            //this.Close();//记得关闭此弹出框哦。OK
        }
        

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        public void CalcFinished(string result)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new changeText(CalcFinished), result);
            }
            else
            {
                this.label1.Text = result.ToString();
            }
        }
    }
}
