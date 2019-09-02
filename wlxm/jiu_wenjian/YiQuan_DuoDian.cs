using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using xDM;

namespace fuzhu1
{
    public class YiQuan_DuoDian
    {
        #region 单例模式变量
        private static readonly object obj = new object();
        private static YiQuan_DuoDian yqdd = null;
        #endregion
        private YiQuan_DuoDian() {
        
        }

        private static List<ZuoBiao> _list_zuobiao = new List<ZuoBiao>();

        public static List<ZuoBiao> List_zuobiao
        {
            get { return YiQuan_DuoDian._list_zuobiao; }
            set { YiQuan_DuoDian._list_zuobiao = value; }
        }


        private static List<DuoDianZhaoSe> _list_yqduodian = null;

        public static List<DuoDianZhaoSe> List_yqduodian
        {
            get { return YiQuan_DuoDian._list_yqduodian; }
            set { YiQuan_DuoDian._list_yqduodian = value; }
        }


        private static List<FuHeDuoDian> _list_yqfhduodian = null;

        public static List<FuHeDuoDian> List_yqfhduodian
        {
            get { return YiQuan_DuoDian._list_yqfhduodian; }
            set { YiQuan_DuoDian._list_yqfhduodian = value; }
        }


        static YiQuan_DuoDian()
        {
            _list_zuobiao.Add(new ZuoBiao( 18,106));
            _list_zuobiao.Add(new ZuoBiao ( 204, 110 ));
            _list_yqduodian = new List<DuoDianZhaoSe>();
            _list_yqfhduodian = new List<FuHeDuoDian>();

            //赋值开始
            List<ZuoBiao> ls0 = new List<ZuoBiao>();
            ls0.Add(new ZuoBiao(174, 155));
            ls0.Add(new ZuoBiao(438, 277));
            ls0.Add(new ZuoBiao(345, 80));
            ls0.Add(new ZuoBiao(268, 263));
            ls0.Add(new ZuoBiao(482, 125));
            ls0.Add(new ZuoBiao(491, 267));
            ls0.Add(new ZuoBiao(280, 132));
            ls0.Add(new ZuoBiao(361, 132));
            ls0.Add(new ZuoBiao(412, 90));
            ls0.Add(new ZuoBiao(340, 155));
            ls0.Add(new ZuoBiao(395, 276));
            ls0.Add(new ZuoBiao(313, 97));
            ls0.Add(new ZuoBiao(510, 9));
            ls0.Add(new ZuoBiao(391, 188));
            ls0.Add(new ZuoBiao(31, 58));
            ls0.Add(new ZuoBiao(491, 267));
            ls0.Add(new ZuoBiao(280, 132));
            ls0.Add(new ZuoBiao(361, 132));
            ls0.Add(new ZuoBiao(412, 90));
            ls0.Add(new ZuoBiao(340, 155));
            ls0.Add(new ZuoBiao(171, 135));
            ls0.Add(new ZuoBiao(73, 12));
            ls0.Add(new ZuoBiao(242, 190));
            ls0.Add(new ZuoBiao(318, 232));
            ls0.Add(new ZuoBiao(461, 54));
            ls0.Add(new ZuoBiao(305, 277));
            ls0.Add(new ZuoBiao(43, 178));
            ls0.Add(new ZuoBiao(395, 104, 0x6c675a));
            DuoDianZhaoSe dz0 = new DuoDianZhaoSe(0xab988d, "0|32|0xffd258,-17|32|0xab1c0b,11|40|0xb02914,25|8|0xebac8e", 90, 0, 0, 532, 299);
            FuHeDuoDian fh0 = new FuHeDuoDian("光头界面1",dz0,-1,-1,ls0);
            _list_yqduodian.Add(dz0);
            _list_yqfhduodian.Add(fh0);

            DuoDianZhaoSe dz1 = new DuoDianZhaoSe(0xefb294, "-11|22|0xefb294,-21|36|0xcc331e,3|50|0xffcb52,9|41|0x2e3332", 90, 0, 0, 532, 299);
            FuHeDuoDian fh1 = new FuHeDuoDian("光头界面2", dz1, -1, -1, ls0);
            _list_yqduodian.Add(dz1);
            _list_yqfhduodian.Add(fh1);

            DuoDianZhaoSe dz11 = new DuoDianZhaoSe(0xefb294, "-24|17|0xbd3410,-6|31|0x9b7838,15|36|0xffcb4e,1|45|0x93651c", 90, 0, 0, 532, 299);
            FuHeDuoDian fh11 = new FuHeDuoDian("光头界面3", dz11, -1, -1, ls0);
            _list_yqduodian.Add(dz11);
            _list_yqfhduodian.Add(fh11);

            DuoDianZhaoSe dz12 = new DuoDianZhaoSe(0xefb294, "-24|34|0xd5351c,9|47|0xffc94d,-3|49|0xaf291a,19|19|0xc78261", 90, 0, 0, 532, 299);
            FuHeDuoDian fh12 = new FuHeDuoDian("光头界面4", dz12, -1, -1, ls0);
            _list_yqduodian.Add(dz12);
            _list_yqfhduodian.Add(fh12);

            DuoDianZhaoSe dz2 = new DuoDianZhaoSe(0xf2a726, "-190|-1|0xec9812,-292|-266|0xbdb9aa,-106|-265|0xb9bcc6,-297|-261|0xb7b9ac", 90, 0, 0, 532, 299);
            FuHeDuoDian fh2 = new FuHeDuoDian("类似光头战斗未自动", dz2, -1, -1, ls0);
            _list_yqduodian.Add(dz2);
            _list_yqfhduodian.Add(fh2);

            /*DuoDianZhaoSe dz21 = new DuoDianZhaoSe(0x524f42, "0|7|0xfedf6a,-211|-4|0xbcbcbb,-211|0|0xfdfbf5,-207|0|0xe9eae5", 90, 0, 0, 532, 299);
            FuHeDuoDian fh21 = new FuHeDuoDian("类似光头战斗未自动2", dz21, -1, -1, ls0);
            _list_yqduodian.Add(dz21);
            _list_yqfhduodian.Add(fh21);*/
           
            
            DuoDianZhaoSe dz3 = new DuoDianZhaoSe(0xf3270d, "-5|0|0xf32a00,-5|-5|0xf32a00,-12|-2|0x410a03,-7|5|0x5b0d08", 90, 0, 0, 532, 240);
            FuHeDuoDian fh3 = new FuHeDuoDian("类似光头红色拳头", dz3, -1, -1, ls0);
            _list_yqduodian.Add(dz3);
            _list_yqfhduodian.Add(fh3);

            
            //其他多点
            DuoDianZhaoSe rcdz1 = new DuoDianZhaoSe(0x69b509, "-9|0|0x529f09,10|0|0x6fc507,-69|-1|0xabe27e,-80|-1|0x97ca6f", 90, 0, 90, 110, 160);
            FuHeDuoDian rcfh1 = new FuHeDuoDian("支线已完成", rcdz1, -1, -1);
            _list_yqduodian.Add(rcdz1);
            _list_yqfhduodian.Add(rcfh1);

            DuoDianZhaoSe rcdz2 = new DuoDianZhaoSe(0xffdb21, "-8|6|0xfbda3c,5|9|0xb9972a,17|9|0xffda24,9|10|0x925b20", 90, 333, 96, 509, 268);
            FuHeDuoDian rcfh2 = new FuHeDuoDian("支线完成领取", rcdz2, -1, -1);
            _list_yqduodian.Add(rcdz2);
            _list_yqfhduodian.Add(rcfh2);

            DuoDianZhaoSe rcdz3 = new DuoDianZhaoSe( 0xcbb66c, "4|2|0xead580,40|1|0xe3ce84,51|-1|0xf3de87,56|3|0x968449",  90, 0, 90, 110, 160);
            FuHeDuoDian rcfh3 = new FuHeDuoDian("钉头锤领取", rcdz3, -1, -1);
            _list_yqduodian.Add(rcdz3);
            _list_yqfhduodian.Add(rcfh3);

            DuoDianZhaoSe rcdz4 = new DuoDianZhaoSe(0x89591d, "10|3|0x5d330a,13|21|0x7d570a,-4|21|0xfffff7,-9|28|0xffff9e", 90, 0, 0, 532, 299);
            FuHeDuoDian rcfh4 = new FuHeDuoDian("关卡宝箱领取", rcdz4, -1, -1);
            _list_yqduodian.Add(rcdz4);
            _list_yqfhduodian.Add(rcfh4);

            DuoDianZhaoSe rcdz5 = new DuoDianZhaoSe(0x8551a6, "-13|10|0xd0a094,-18|-1|0xe28745,-25|9|0x342832,-27|20|0xc070e1,-6|19|0xb5341f,-17|3|0x982e20", 90,92,   29, 293,  285);
            FuHeDuoDian rcfh5 = new FuHeDuoDian("强者招募券", rcdz5, -1, -1);
            _list_yqduodian.Add(rcdz5);
            _list_yqfhduodian.Add(rcfh5);


            /*DuoDianZhaoSe rcdz6 = new DuoDianZhaoSe(0xe97370, "0|-1|0xec8d89,1|-2|0xe86865,1|-4|0xeb8985,2|-5|0xe9726f,2|-6|0xe64e4d,2|-7|0xe96e6c", 90, 286, 124, 465, 135);
            FuHeDuoDian rcfh6 = new FuHeDuoDian("徽章界面判断后是缺少", rcdz6, -1, -1);
            _list_yqduodian.Add(rcdz6);
            _list_yqfhduodian.Add(rcfh6);*/
        }
        /// <summary>
        /// 单例模式====双层互锁
        /// </summary>
        /// <returns></returns>
        public static YiQuan_DuoDian GetObject()
        {
            if (yqdd == null)
            {
                lock (obj)
                {
                    if (yqdd == null)
                    {
                        yqdd = new YiQuan_DuoDian();
                    }
                }
            }
            return yqdd;
        }


        public void addDuodian(DuoDianZhaoSe dz) {
        
        }
        public void delDuodian(DuoDianZhaoSe dz)
        {

        }
        public DuoDianZhaoSe findDuodian(DuoDianZhaoSe dz)
        {
            return _list_yqduodian.Find(d => d == dz
                );
        }

        public FuHeDuoDian findFuHeDuodian(FuHeDuoDian fh)
        {
            return _list_yqfhduodian.Find(f => fh.Dz == f.Dz
                && fh.Name.Equals(f.Name)
                );
        }

        public FuHeDuoDian findFuHeDuodianByName(string name)
        {
            return _list_yqfhduodian.Find(f => name.Equals(f.Name)
                );
        }
    }
}
