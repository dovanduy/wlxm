using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xDM;
using Entity;
namespace fuzhu
{
    public class YouXiFactory
    {
        private object youcr = null;
        public object CreateYouXiCs(string brand, xDm mydm, int dqinx, int jubing)
        {
            switch (brand)
            {
                case "jiuyou":
                    youcr = new JiuYouZhuCe(mydm, dqinx, jubing);
                    break;
                default:
                    break;
            }
            return youcr;
        }
        private SanDianAbs youcr1 = null;
        public SanDianAbs CreateYouXiSanDian(string brand)
        {
            switch (brand)
            {
                case "tongyongsandian":
                    youcr1 = TongYong_SanDian.GetObject();
                    break;
                case "jiuyouzhuce":
                    youcr1 = JiuYou_SanDian.GetObject();
                    break;
                default:
                    break;
            }
            return youcr1;
        }
        

    }
}
