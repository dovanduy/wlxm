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
        public Form1()
        {
            InitializeComponent();
            qicheng();
        }
        private void qicheng(){
            ThreadStart threadStart = new ThreadStart(shzhong);//通过ThreadStart委托告诉子线程执行什么方法　
            Thread thread = new Thread(threadStart);
            thread.Name = "wodegaozhanghao";
            thread.Start();
        }
        private void shzhong() {
            long ks = MyFuncUtil.GetTimestamp();
            while (true) {
                long js = MyFuncUtil.GetTimestamp();
                if ((js - ks) > 1000 * 60 * 5) {
                    ks = MyFuncUtil.GetTimestamp();
                    ShouHu s = new ShouHu();
                    s.wohaihuozhe();
                    bool t = s.panDuanChongQi(MyFuncUtil.getMachineName());
                    if (t) {
                        System.Diagnostics.Process.Start("shutdown.exe", "-r -f -t 15");
                    }
                }
            }
        }
    }
}
