using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using SH_MyUtil;
namespace wlsh
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 主线程 定时显示运行时间
        /// </summary>
        private Thread thread;
        private delegate void changeText(string result);
        public Form1()
        {
            InitializeComponent();
            qicheng();
        }
        private void qicheng(){
            ShouHu sh = new ShouHu();
            ThreadStart threadStart = new ThreadStart(sh.shouhuzhong);//通过ThreadStart委托告诉子线程执行什么方法　
            Thread thread = new Thread(threadStart);
            thread.Name = "wodegaozhanghao";
            thread.Start();
            ThreadStart threadStart2 = new ThreadStart(foo);
            this.thread = new Thread(threadStart2);
            this.thread.Start();

            this.label2.ForeColor = Color.Red;
            this.label2.Text = ShouHu.BanBenHao.ToString();   
        }
       
        private void foo()
        {

            var ks = MyFuncUtil.GetTimestamp();
            var ks_gxyunxing = MyFuncUtil.GetTimestamp();
            var ks_cqyunxing = MyFuncUtil.GetTimestamp();
            var i = 1;
            string zidong = "";
            while (true)
            {
                Thread.Sleep(1000);
                var js = MyFuncUtil.GetTimestamp();
                i++;
                //MyFuncUtil.SecondToHour(+i + (js - ks) / 1000+" "
                CalcFinished("程序已运行:" + MyFuncUtil.SecondToHour(js - ks) + zidong);
                this.label1.ForeColor = Color.Red;                
            }
        }
        private void CalcFinished(string result)
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

        private void wodeceshi_Click(object sender, EventArgs e)
        {
            UpdateCaoZuo sh = new UpdateCaoZuo();
            sh.updateWlxm();
        }
        
    }
}
