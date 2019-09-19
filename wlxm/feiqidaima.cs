using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wlxm
{
    class feiqidaima
    {
        /*
         * 运行 Control userpasswords2
         * netsh winsock reset 模拟器连不上 重置socket
         * 
         *   #region 防止多开
            {
                Process[] processCollection;  //AutoUpdater进程集合
 
                processCollection = Process.GetProcessesByName("AutoUpdater");
                // 如果该程序进程数量大于，则说明该程序已经运行，则弹出提示信息并提出本次操作，否则就创建该程序
                if (processCollection.Length > 1)
                {
                    //关闭后打开的
                    System.Environment.Exit(1);
                }
            }

#endregion
         * USE [yiquan]
CREATE TABLE [dbo].[zhanghao](
    [name] [varchar](50) NULL,
    [pwd] [varchar](50) NULL,
    [yxbz] [char](1) NULL,
    [dengluzhong] [char](1) NULL,
    [dqindex] [int] NULL,
    [pcname] [varchar](50) NULL,
    [img] [varchar](50) NULL,
    [imgtime] [date] NULL,
    [yimai] [char](1) NULL,
    [xgsj] [date] NULL,
    [dengji] [int] NULL,
    [qiangzhequan] [int] NULL,
    [zuanshi] [int] NULL,
    [yishangjia] [char](1) NULL,
    [xuanqu] [int] NULL,
    [youxi] [varchar](50) NULL
) ON [PRIMARY]


        IxDm dm = new xDm();
           dm.StartRunTime();
           MydmFunc my = new MydmFunc(dm);
           int jubing = MyLdcmd.getDqmoniqiJuBingByIndex(this.dqindex);
           int res = my.bindWindow(jubing, "");
           if (res <= 0)
           {
               MessageBox.Show(jubing + "句柄绑定不成功，请重试！", "提示1", MessageBoxButtons.OK);
               return;
           }
           my.bindWindow(jubing, "");
           string bmpname = dm.GetTime() + "";
           my.captureBmp(jubing, @"c:\mypic", bmpname + ".bmp");
           Thread.Sleep(2000);
           if (dm.IsFileExist(@"C:\mypic\" + bmpname + ".bmp") == 1)
           {
               myxinxitishi("ok");
               Thread.Sleep(2000);
           }
           else
           {
               myxinxitishi("截图黑屏，请重试" + jubing + " " + res);
               WriteLog.WriteLogFile("", "屏幕全黑无法截图");
           }

         * 
         * private void zhuxianrenwu() {
            var kstime = MyFuncUtil.GetTimestamp();            
            int shibai = 0;
            int zaicishibai = 0;        
            //设置战斗初始点
            zdsj = MyFuncUtil.GetTimestamp();
            //设置卡屏相关
            long kp1 = MyFuncUtil.GetTimestamp();
            long kpjishi = MyFuncUtil.GetTimestamp();
            long kp10sjishi = MyFuncUtil.GetTimestamp();
            List<ZuoBiao> kpzb = new List<ZuoBiao>();
            kpzb.Add(new ZuoBiao(220, 48));
            kpzb.Add(new ZuoBiao(407, 136));

            string[] kapingyanse1 = mf.myGetColorWuJbList(kpzb);
            string[] kapingyanse2 = mf.myGetColorWuJbList(kpzb);
            while (true)
            {
                
                tiaoguo();                           
                tedingdian();
                guangtouteding();
                jinruzhandou(out shibai);
                var jstime = MyFuncUtil.GetTimestamp();
                if ((jstime - kstime) > 60 * 1000 * 20) {
                    //20分钟重新计时
                    kstime = MyFuncUtil.GetTimestamp();
                    WriteLog.WriteLogFile(this._mnqName, "20分钟重新计时");
                }
                if ((jstime - kpjishi) > 30 * 1000 && compareColor(kapingyanse1, kapingyanse2))
                { 
                    //调用卡屏函数                   
                    if (panduankaping(kp1))
                    {
                        break;
                    }
                }
                if ((jstime - kp10sjishi) > 10 * 1000)
                {
                    kp10sjishi = MyFuncUtil.GetTimestamp();
                    kapingyanse2 = mf.myGetColorWuJbList(kpzb);
                    //WriteLog.WriteLogFile(this._mnqName, "10秒颜色 " + kapingyanse1[0] + " " + kapingyanse2[0] + "  " + kapingyanse1[1] + " " + kapingyanse2[1]);
                }
                if ((jstime - kpjishi) > 30 * 1000 && !compareColor(kapingyanse1,kapingyanse2))
                {
                    //颜色不等 30秒更新颜色 更新计时
                    WriteLog.WriteLogFile(this._mnqName, "30秒颜色不等时,更新颜色" + kapingyanse1[0] + " " + kapingyanse2[0]+"  "+ kapingyanse1[1] + " " + kapingyanse2[1]);
                    kapingyanse1 = mf.myGetColorWuJbList(kpzb);
                    kpjishi = MyFuncUtil.GetTimestamp();
                    kp1 = MyFuncUtil.GetTimestamp();
                }
                
                SanDian zdhm = YiQuan_SanDian.GetObject().findFuHeSandianByName("战斗画面").Sd;
                if (panduanzhandou(zdhm)) {
                    break;
                }
                if (panduanjiemian("战斗画面"))
                {
                    zhandouxiangguan(0,0,0);
                }
                SanDian zdsb = YiQuan_SanDian.GetObject().findFuHeSandianByName("出现战斗失败").Sd;
                if (mf.jingqueByLeiBool(zdsb))
                {
                    shibai=1;
                    if (zaicishibai > 2) {
                        break;
                    }
                }
                if (shibai==1 && zaicishibai<2) {
                    WriteLog.WriteLogFile(this._mnqName,"战斗第一次失败,进入到角色强化循环");
                    qianghua();
                    lingqu();
                    zhaozhujiemian(20 * 1000);
                    zaicishibai ++;
                }
            }
        }
        */
    }
}
