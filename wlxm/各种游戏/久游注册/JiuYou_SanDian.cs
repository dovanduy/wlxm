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
	{  269,  842, 0xffffff},
	{  260,  834, 0xf5f5f5},
	{  291,  856, 0xfcfcfc},
});
            guanbifhx = new FuHeSanDian("注册-打开九游后先关广告", guanbisdx, 268, 842);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  483,  918, 0xcccccc},
	{  483,  945, 0xa3a3a3},
	{   64,  917, 0xfea119},
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
	{  354,  563, 0xf78b42},
	{  316,  510, 0xfa9019},
	{  108,  431, 0x86868c},
});
            guanbifhx = new FuHeSanDian("特殊注册-输入密码", guanbisdx, 322, 432);
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
