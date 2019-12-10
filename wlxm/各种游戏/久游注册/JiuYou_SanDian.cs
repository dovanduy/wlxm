using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using xDM;

namespace fuzhu
{
    public class JiuYou_SanDian : SanDianAbs
    {
        #region 单例模式变量
        private static readonly object obj = new object();
        private static JiuYou_SanDian yqsd = null;
        #endregion
        private JiuYou_SanDian()
        {

        }

        private static List<ZuoBiao> _list_zuobiao = new List<ZuoBiao>();

        public static List<ZuoBiao> List_zuobiao
        {
            get { return JiuYou_SanDian._list_zuobiao; }
            set { JiuYou_SanDian._list_zuobiao = value; }
        }


        private static List<SanDian> _list_yqsandian = new List<SanDian>();

        public static List<SanDian> List_yqsandian
        {
            get { return JiuYou_SanDian._list_yqsandian; }
            set { JiuYou_SanDian._list_yqsandian = value; }
        }


        private static List<FuHeSanDian> _list_yqfhsandian = new List<FuHeSanDian>();

        public static List<FuHeSanDian> List_yqfhsandian
        {
            get { return JiuYou_SanDian._list_yqfhsandian; }
            set { JiuYou_SanDian._list_yqfhsandian = value; }
        }


        private static Dictionary<string, FuHeSanDian> _dict = new Dictionary<string, FuHeSanDian>();

        public static Dictionary<string, FuHeSanDian> Dict
        {
            get { return _dict; }
            set { _dict = value; }
        }

        static JiuYou_SanDian()
        {
            

            //新增三点 10.10
            List<ZuoBiao> zb = new List<ZuoBiao>();
            SanDian guanbisdx = new SanDian(new int[3, 3] {
	{  119,  115, 0xf9746f},
	{  500,   71, 0xfba7a7},
	{  467,   65, 0xfaa7a7},
});
            FuHeSanDian guanbifhx = new FuHeSanDian("注册-打开九游后第一界面", guanbisdx, 483, 60);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  318,  693, 0xa95b27},
	{  177,  279, 0xffd53e},
	{  311,  333, 0x1a1008},
});
            guanbifhx = new FuHeSanDian("注册-打开九游后先关广告", guanbisdx, 268, 842,"掌上三国");
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  271,  531, 0x5f2923},
	{  312,  692, 0x7b2e23},
	{  270,  842, 0xffffff},
});
            guanbifhx = new FuHeSanDian("注册-打开九游后先关广告2", guanbisdx, 268, 842, "另外一个广告");
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  295,  845, 0xffffff},
	{  301,  698, 0x000000},
	{  250,  693, 0xffe362},
});
            guanbifhx = new FuHeSanDian("注册-打开九游后先关广告3", guanbisdx, 268, 842, "另外一个广告");
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  328,  684, 0x98222d},
	{  270,  842, 0xffffff},
	{  279,  834, 0xefefef},
});
            guanbifhx = new FuHeSanDian("注册-打开九游后先关广告4", guanbisdx, 268, 842, "另外一个广告");
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  274,  703, 0x973835},
	{  269,  842, 0xffffff},
	{  403,  444, 0x051817},
});
            guanbifhx = new FuHeSanDian("注册-打开九游后先关广告5", guanbisdx, 268, 842, "另外一个广告");
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  270,  842, 0xffffff},
	{  295,  844, 0xffffff},
	{  267,  868, 0xffffff},
});
            guanbifhx = new FuHeSanDian("特殊注册-打开九游后先关广告6", guanbisdx, 268, 842, "另外一个广告");
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  129,  514, 0xfb8f16},
	{   53,  724, 0x3bd7bb},
	{   57,  880, 0x42dabf},
});
            guanbifhx = new FuHeSanDian("注册-错碰后先关", guanbisdx, 178, 601);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{   21,   70, 0xffffff},
	{  148,  921, 0xf67b29},
	{  434,  914, 0xf67b29},
});
            guanbifhx = new FuHeSanDian("注册-错碰后先关1", guanbisdx, 28, 68);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   21,   70, 0xffffff},
	{  193,   73, 0xf67d29},
	{  387,   75, 0xf67d29},
});
            guanbifhx = new FuHeSanDian("注册-错碰后先关2", guanbisdx, 28, 68);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   21,   69, 0xffffff},
	{  204,   63, 0xf67d29},
	{  532,   77, 0xf67d29},
});
            guanbifhx = new FuHeSanDian("注册-错碰后先关3", guanbisdx, 28, 68);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);


            guanbisdx = new SanDian(new int[3, 3] {
	{  396,  370, 0x3b87fe},
	{  503,  902, 0xf74c31},
	{  485,  922, 0xcccccc},
});
            guanbifhx = new FuHeSanDian("注册-可以点击右下角的我", guanbisdx,  487,  919);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  299,  388, 0xffef66},
	{  178,  409, 0xff7e28},
	{  173,  364, 0xf6b614},
});
            guanbifhx = new FuHeSanDian("注册-跳过领金币提示", guanbisdx, 118, 77);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{   83,  163, 0xff9034},
	{   37,  162, 0xff9034},
	{  433,  196, 0x4d4d4d},
});
            guanbifhx = new FuHeSanDian("注册-点击我准备注册", guanbisdx, 128, 173);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  121,  397, 0xff8400},
	{  457,  389, 0xffb45f},
	{  438,  607, 0x696969},
});
            guanbifhx = new FuHeSanDian("注册-跳转到账号注册1", guanbisdx, 407, 605);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  339,  506, 0xfa911c},
	{  387,  683, 0x6e6e6e},
	{  148,  326, 0xff8400},
});
            guanbifhx = new FuHeSanDian("注册-跳转到账号注册2", guanbisdx, 415, 683);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  425,  555, 0x009688},
	{  356,  564, 0x009688},
	{  208,  494, 0x1f1f1f},
});
            guanbifhx = new FuHeSanDian("注册-无响应选等待", guanbisdx, 337, 557);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  327,  535, 0x07988b},
	{  433,  532, 0x009688},
	{  269,  843, 0x666666},
});
            guanbifhx = new FuHeSanDian("注册-无响应选等待2", guanbisdx, 337, 557);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  110,   76, 0xffffff},
	{  490,  378, 0x555555},
	{  489,  576, 0x555555},
});
            guanbifhx = new FuHeSanDian("注册-Uc协议后退", guanbisdx, 21, 70);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  278,  314, 0xff6600},
	{  413,  712, 0xfb8d13},
	{  208,  460, 0xff9011},
});
            guanbifhx = new FuHeSanDian("注册-版本更新选关闭", guanbisdx, 170, 700);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  228,  427, 0x898989},
	{  183,  318, 0xff8400},
	{  325,  507, 0xfa911b},
});
            guanbifhx = new FuHeSanDian("特殊注册-输入完密码", guanbisdx, 325, 507);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  354,  563, 0xf78b42},
	{  316,  510, 0xfa9019},
	{  108,  431, 0x86868c},
});
            guanbifhx = new FuHeSanDian("特殊注册-输入密码", guanbisdx, 322, 432);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  108,  432, 0x86868c},
	{  112,  421, 0x75757a},
	{  101,  423, 0x76767b},
});
            guanbifhx = new FuHeSanDian("特殊注册-输入密码2", guanbisdx, -1, -1,"监控小锁");
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  295,  475, 0xfa911b},
	{  453,  317, 0xff8d0b},
	{  260,  404, 0x8c8c8c},
});
            guanbifhx = new FuHeSanDian("特殊注册-搞验证", guanbisdx, 286, 402, "339,  364, 0xffffff  459,  424, 0xffffff 验证码的左上 右下坐标");
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  387,  253, 0xf9f9f9},
	{  130,  253, 0xf9f9f9},
	{  390,  410, 0xf9f9f9},
});
            guanbifhx = new FuHeSanDian("特殊注册-搞验证2刷新中", guanbisdx);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{   92,  459, 0x777777},
	{  533,  118, 0xf67b29},
	{  534,   42, 0xf67b29},
});
            guanbifhx = new FuHeSanDian("特殊注册-搞验证2", guanbisdx, -1, -1, "74,  207, 0xf9f9f9  465,  432, 0xf9f9f9  验证码的左上 右下坐标");
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  109,  401, 0x86868c},
	{  173,  325, 0xff8400},
	{  329,  548, 0xf99321},
});
            guanbifhx = new FuHeSanDian("特殊注册-搞成功存账号", guanbisdx, 453, 316, "148, 378, 407, 428");
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

        }

        
        /// <summary>
        /// 单例模式====双层互锁
        /// </summary>
        /// <returns></returns>
        public static JiuYou_SanDian GetObject()
        {
            if (yqsd == null)
            {
                lock (obj)
                {
                    if (yqsd == null)
                    {
                        yqsd = new JiuYou_SanDian();
                    }
                }
            }
            return yqsd;
        }



        /*
                public FuHeSanDian findFuHeSandianByName(string name)
                {
                    return _list_yqfhsandian.Find(f => name.Equals(f.Name)
                        );
                }
                public List<FuHeSanDian> findListFuHeSandianByName(string nameindex)
                {
                    return _list_yqfhsandian.FindAll(f => f.Name.IndexOf(nameindex) == 0
                        );
                }*/
        public override List<FuHeSanDian> findAllFuHeSandian()
        {
            return _list_yqfhsandian;
        }
        
    }
}
