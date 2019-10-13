using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using xDM;

namespace fuzhu
{
    public class YiQuan_SanDian
    {
        #region 单例模式变量
        private static readonly object obj = new object();
        private static YiQuan_SanDian yqsd = null;
        #endregion
        private YiQuan_SanDian()
        {

        }

        private static List<ZuoBiao> _list_zuobiao = new List<ZuoBiao>();

        public static List<ZuoBiao> List_zuobiao
        {
            get { return YiQuan_SanDian._list_zuobiao; }
            set { YiQuan_SanDian._list_zuobiao = value; }
        }


        private static List<SanDian> _list_yqsandian = new List<SanDian>();

        public static List<SanDian> List_yqsandian
        {
            get { return YiQuan_SanDian._list_yqsandian; }
            set { YiQuan_SanDian._list_yqsandian = value; }
        }


        private static List<FuHeSanDian> _list_yqfhsandian = new List<FuHeSanDian>();

        public static List<FuHeSanDian> List_yqfhsandian
        {
            get { return YiQuan_SanDian._list_yqfhsandian; }
            set { YiQuan_SanDian._list_yqfhsandian = value; }
        }


        private static Dictionary<string, FuHeSanDian> _dict = new Dictionary<string, FuHeSanDian>();

        public static Dictionary<string, FuHeSanDian> Dict
        {
            get { return _dict; }
            set { _dict = value; }
        }

        static YiQuan_SanDian()
        {
            //新增三点 10.10
            List<ZuoBiao> zb = new List<ZuoBiao>();
            zb.Add(new ZuoBiao(439, 131, 0x4d2b05));
            zb.Add(new ZuoBiao(439, 131, 0x4d2b05));
            SanDian guanbisdx = new SanDian(new int[3, 3] {
	{  439,  131, 0x4d2b05},
	{  432,  160, 0xd79a16},
	{  440,  164, 0x9e421a},
});
            FuHeSanDian guanbifhx = new FuHeSanDian("开引导-领取箱子", guanbisdx, 436, 157,"",zb);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  485,  265, 0xf7f44a},
	{  485,  278, 0xe8e414},
	{  505,  268, 0xebb81e},
});
            guanbifhx = new FuHeSanDian("引导时-布阵", guanbisdx, 490, 280);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{   47,  286, 0xe69700},
	{   64,  282, 0x5c786a},
	{   85,  288, 0xe6a507},
});
            guanbifhx = new FuHeSanDian("开引导-领取战斗场奖励1", guanbisdx, 66, 283);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  141,  286, 0xedc900},
	{  106,  287, 0xedb607},
	{  120,  284, 0x4c5399},
});
            guanbifhx = new FuHeSanDian("开引导-领取战斗场奖励2", guanbisdx, 121, 283);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  163,  284, 0xeded16},
	{  189,  287, 0x5e2607},
	{  176,  291, 0xedd97d},
});
            guanbifhx = new FuHeSanDian("开引导-领取战斗场奖励3", guanbisdx, 180, 283);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{   19,  104, 0x256a8c},
	{   12,  105, 0x225276},
	{    7,  105, 0x2e88a3},
});
            guanbifhx = new FuHeSanDian("引导时-主线任务", guanbisdx, 46, 118);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  424,  239, 0xffdb21},
	{  450,  116, 0xf0ce2a},
	{  470,   42, 0xba615b},
});
            guanbifhx = new FuHeSanDian("开引导-关闭领取奖励", guanbisdx, 467, 45);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            /*guanbisdx = new SanDian(new int[3, 3] {
	{  466,   42, 0xfffbf5},
	{  114,  196, 0xf7c90e},
	{  430,  241, 0xcfcfcf},
});
            guanbifhx = new FuHeSanDian("开引导-关闭孤高改造人", guanbisdx, 466, 45);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);*/

            guanbisdx = new SanDian(new int[3, 3]{
	{  368,  134, 0xefb294},
	{  416,  254, 0xd3c1b2},
	{  403,  222, 0x998f70},
});
            guanbifhx = new FuHeSanDian("开引导-战斗攻击特技", guanbisdx, 453, 273);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  307,  174, 0xefb294},
	{  284,  207, 0xc33218},
	{  458,  185, 0xffae00},
});
            guanbifhx = new FuHeSanDian("开引导-探索圈", guanbisdx, 495, 263);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);


            guanbisdx = new SanDian(new int[3, 3]{
	{  250,  156, 0xefb294},
	{  256,  215, 0xffc94f},
	{  288,   93, 0x087594},
});
            guanbifhx = new FuHeSanDian("开引导-进入关卡1", guanbisdx, 308, 110);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  309,  172, 0xefb294},
	{  351,  200, 0xff914c},
	{  383,  214, 0xff736b},
});
            guanbifhx = new FuHeSanDian("开引导-战意化为能力", guanbisdx, 446, 274);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  143,   53, 0x68d0f7},
	{  291,   49, 0x67a1e7},
	{  364,  239, 0xffcf18},
});
            guanbifhx = new FuHeSanDian("开引导-进入关卡1卡住", guanbisdx, 336, 235);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  406,  239, 0xe9d1be},
	{  462,  267, 0xd65009},
	{  402,  285, 0x393936},
});
            guanbifhx = new FuHeSanDian("开引导-开头动画超人111", guanbisdx, 443, 106);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   15,  106, 0x45c7d2},
	{   95,   85, 0xefaa39},
	{  507,    9, 0xffbd18},
});
            guanbifhx = new FuHeSanDian("开引导-继续搞主线", guanbisdx, 443, 106);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  218,   61, 0xa52421},
	{  243,  190, 0xffdb21},
	{  409,   66, 0xa52421},
});
            guanbifhx = new FuHeSanDian("开引导-继续搞宝箱", guanbisdx, 264, 193);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  364,  138, 0xefb294},
	{  352,  170, 0xb42a11},
	{  428,  171, 0xff8941},
});
            guanbifhx = new FuHeSanDian("开引导-战斗中引导绝技", guanbisdx, 453, 273);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  270,  118, 0x2c2d2c},
	{  266,  113, 0xfefefe},
	{  213,  177, 0x51ddfe},
});
            guanbifhx = new FuHeSanDian("开引导-发现sr女人", guanbisdx, 265, 261);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  312,   61, 0x6659ac},
	{  308,   73, 0x6959af},
	{  307,  115, 0x568a56},
});
            guanbifhx = new FuHeSanDian("开引导-发现sr战斗骑士", guanbisdx, 311, 130);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   91,   30, 0xefb294},
	{   59,   68, 0xe74020},
	{  285,  143, 0x293431},
});
            guanbifhx = new FuHeSanDian("开引导-发现洪拳加引导", guanbisdx, 285, 143);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  177,   68, 0xf3606b},
	{  426,  237, 0xffdb21},
	{  312,  186, 0xbaf032},
});
            guanbifhx = new FuHeSanDian("开引导-关闭已完成关卡2", guanbisdx, 467, 45);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  108,  200, 0xefb294},
	{   96,  237, 0xbe3411},
	{  207,  246, 0xffae79},
});
            guanbifhx = new FuHeSanDian("开引导-发现强者招募11", guanbisdx, 283, 279);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  332,  238, 0x2f2007},
	{  107,  226, 0xf43e1e},
	{  441,  184, 0xd6cfc6},
});
            guanbifhx = new FuHeSanDian("开引导-进入关卡地底人选进入", guanbisdx, 338, 237);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  408,  243, 0xe2cbb8},
	{  367,  226, 0xe1cab7},
	{  424,  290, 0xdac2b1},
});
            guanbifhx = new FuHeSanDian("开引导-开头动画搞打击1", guanbisdx, 501, 271);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  433,  273, 0x2e2a25},
	{  480,   22, 0x671b12},
	{  341,   21, 0x692d09},
});
            guanbifhx = new FuHeSanDian("开引导-出现引导点一个1", guanbisdx, 433, 273);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);





            SanDian guanbisd1 = new SanDian(new int[3, 3] { { 136, 106, 0xe79941 }, { 232, 223, 0x9b9b9b }, { 302, 231, 0xe79000 } });
            FuHeSanDian guanbifh1 = new FuHeSanDian("关闭实名认证", guanbisd1, 209, 225);
            _list_yqsandian.Add(guanbisd1);
            _list_yqfhsandian.Add(guanbifh1);

            SanDian guanbisd2 = new SanDian(new int[3, 3] {
	            {   64,   25, 0xb02525},
	            {  247,   27, 0xffaf15},
	            {  476,   29, 0xfffbef},
            });
            FuHeSanDian guanbifh2 = new FuHeSanDian("关闭公告", guanbisd2, 475, 29);
            _list_yqsandian.Add(guanbisd2);
            _list_yqfhsandian.Add(guanbifh2);

            SanDian sd1 = new SanDian(new int[3, 3]{
	            {  267,   56, 0x3dc2f0},
	            {  237,  198, 0xa4def2},
	            {  242,  241, 0xe79100},
            });
            FuHeSanDian fh1 = new FuHeSanDian("新账号注册", sd1, 228, 105);
            _list_yqsandian.Add(sd1);
            _list_yqfhsandian.Add(fh1);
            SanDian sd2 = new SanDian(new int[3, 3]{
	            {  264,  241, 0xffd722},
	            {  239,  241, 0x361400},
	            {  258,  267, 0xf4f4f4},
            });
            FuHeSanDian fh2 = new FuHeSanDian("进入游戏", sd2, 260, 241);
            _list_yqsandian.Add(sd2);
            _list_yqfhsandian.Add(fh2);
            SanDian sd3 = new SanDian(new int[3, 3]{
	            {  284,  177, 0x1eaedf},
	            {  242,  204, 0x8fc31f},
	            {  323,  208, 0xf39800},
            });
            FuHeSanDian fh3 = new FuHeSanDian("登录或注册", sd3, 300, 208,"选账号注册");
            _list_yqsandian.Add(sd3);
            _list_yqfhsandian.Add(fh3);
            SanDian sd4 = new SanDian(new int[3, 3]{
	            {  261,  160, 0x95c331},
	            {  316,  196, 0x1eafe1},
	            {  269,   65, 0x1eb9ee},
            });
            FuHeSanDian fh4 = new FuHeSanDian("账号切换后选新账号", sd4, 276, 198);
            _list_yqsandian.Add(sd4);
            _list_yqfhsandian.Add(fh4);
            SanDian sd5 = new SanDian(new int[3, 3]{
	            {  297,  119, 0x8bbe1e},
	            {  312,  158, 0xea9300},
	            {  325,  203, 0x1dacde},
            });
            FuHeSanDian fh5 = new FuHeSanDian("首次进入登录或注册", sd5);
            _list_yqsandian.Add(sd5);
            _list_yqfhsandian.Add(fh5);
            
            //主线开始
            SanDian ktsd1 = new SanDian(new int[3, 3]{
	            {  226,   86, 0xefb294},
	            {  382,   99, 0xffae00},
	            {  420,  276, 0x833a24},
            });
            FuHeSanDian ktfh1 = new FuHeSanDian("开头的战斗超人画像1", ktsd1);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);


            SanDian ktsd2 = new SanDian(new int[3, 3]{
	            {  371,  195, 0xefb294},
	            {  496,  245, 0xffad02},
	            {  508,  272, 0xffcc43},
            });
            FuHeSanDian ktfh2 = new FuHeSanDian("开头的战斗超人画像2", ktsd2,505,274);
            _list_yqsandian.Add(ktsd2);
            _list_yqfhsandian.Add(ktfh2);

            SanDian ktsd3 = new SanDian(new int[3, 3]{
	            {  228,   88, 0xefb294},
	            {  440,  103, 0x56f0ff},
	            {  404,  248, 0x252828},
            });
            FuHeSanDian ktfh3 = new FuHeSanDian("开头的战斗超人画像3", ktsd3, 440, 103);
            _list_yqsandian.Add(ktsd3);
            _list_yqfhsandian.Add(ktfh3);

            SanDian ktsd4 = new SanDian(new int[3, 3]{
	            {  323,  191, 0xefb294},
	            {  411,  288, 0x916a4a},
	            {  503,  276, 0x986c56},
            });
            FuHeSanDian ktfh4 = new FuHeSanDian("开头的骑士画像1", ktsd4,508, 269);
            _list_yqsandian.Add(ktsd4);
            _list_yqfhsandian.Add(ktfh4);

            SanDian ktsd5 = new SanDian(new int[3, 3]{
	            {  250,  116, 0xefb294},
	            {  171,  134, 0x58e7ff},
	            {  509,  278, 0x855c47},
            });
            FuHeSanDian ktfh5 = new FuHeSanDian("开头的骑士画像2", ktsd5, 171, 134);
            _list_yqsandian.Add(ktsd5);
            _list_yqfhsandian.Add(ktfh5);

            SanDian ktsd6 = new SanDian(new int[3, 3]{
	            {  413,  240, 0xe3ccb9},
	            {  410,  259, 0xe1cab7},
	            {  435,  112, 0x38355e},
            });
            FuHeSanDian ktfh6 = new FuHeSanDian("开头的爆炸头1", ktsd6, 511, 274);
            _list_yqsandian.Add(ktsd6);
            _list_yqfhsandian.Add(ktfh6);

            SanDian ktsd7 = new SanDian(new int[3, 3]{
	            {  419,  244, 0xe9d1bf},
	            {  398,  238, 0xe8d0be},
	            {  441,  103, 0x54edff},
            });
            FuHeSanDian ktfh7 = new FuHeSanDian("开头的爆炸头2", ktsd7, 438, 108);
            _list_yqsandian.Add(ktsd7);
            _list_yqfhsandian.Add(ktfh7);

            SanDian ktsd8 = new SanDian(new int[3, 3]{
	            {  412,  238, 0xeecab0},
	            {  360,   86, 0x4bdfff},
	            {  492,  274, 0x60130d},
            });
            FuHeSanDian ktfh8 = new FuHeSanDian("开头的一拳光头", ktsd8, 360, 86);
            _list_yqsandian.Add(ktsd8);
            _list_yqfhsandian.Add(ktfh8);

            SanDian ktsd9 = new SanDian(new int[3, 3]{
	            {  288,  150, 0xefb294},
	            {  167,   54, 0x85c931},
	            {  178,  222, 0xff4521},
            });
            FuHeSanDian ktfh9 = new FuHeSanDian("开头的第一章", ktsd9, 170, 154);
            _list_yqsandian.Add(ktsd9);
            _list_yqfhsandian.Add(ktfh9);

            SanDian ktsd10 = new SanDian(new int[3, 3]{
	            {  432,  113, 0xb3a31f},
	            {  152,  212, 0xfe4526},
	            {  321,   63, 0x9991c2},
            });
            FuHeSanDian ktfh10 = new FuHeSanDian("开头的第一章完成", ktsd10, 340, 238);
            _list_yqsandian.Add(ktsd10);
            _list_yqfhsandian.Add(ktfh10);

            SanDian ktsd11 = new SanDian(new int[3, 3]{
	            {  135,   30, 0xefb294},
	            {  360,   56, 0x4ee4ff},
	            {  411,  250, 0xebc5a9},
            });
            FuHeSanDian ktfh11 = new FuHeSanDian("开头的第2章打巨人", ktsd11, 360, 56);
            _list_yqsandian.Add(ktsd11);
            _list_yqfhsandian.Add(ktfh11);


            SanDian ktsd12 = new SanDian(new int[3, 3]{
	            {  372,  188, 0xefb294},
	            {  361,  229, 0x9a6b26},
	            {  439,  277, 0xd7dbda},
            });
            FuHeSanDian ktfh12 = new FuHeSanDian("开头领取任务奖励", ktsd12, 441, 273);
            _list_yqsandian.Add(ktsd12);
            _list_yqfhsandian.Add(ktfh12);

            SanDian ktsd13 = new SanDian(new int[3, 3]{
	            {  202,  247, 0xff6f19},
	            {  113,  212, 0xefb294},
	            {  293,   80, 0x991e22},
            });
            FuHeSanDian ktfh13 = new FuHeSanDian("开头光头提示有强者券", ktsd13, 284, 273);
            _list_yqsandian.Add(ktsd13);
            _list_yqfhsandian.Add(ktfh13);

            SanDian ktsd14 = new SanDian(new int[3, 3]{
	            {  309,  109, 0x01f901},
	            {  254,  174, 0xb9b69c},
	            {  302,  176, 0xc6c6e7},
            });
            FuHeSanDian ktfh14 = new FuHeSanDian("提示解锁招募和探索", ktsd13, 284, 273);
            _list_yqsandian.Add(ktsd14);
            _list_yqfhsandian.Add(ktfh14);

            SanDian zxsd3 = new SanDian(new int[3, 3]{
	            {  404,  245, 0xe1cab7},
	            {  398,  284, 0x373734},
	            {  418,  292, 0x6b635a},
            });
            FuHeSanDian zxfh3 = new FuHeSanDian("开头的爆炸头画像", zxsd3, -1, -1, "");
            _list_yqsandian.Add(zxsd3);
            _list_yqfhsandian.Add(zxfh3);
            SanDian zxsd4 = new SanDian(new int[3, 3]{
	            {  405,  236, 0xecc8ae},
	            {  402,  262, 0xeac3a7},
	            {  412,  291, 0xc1b9ac},
            });
            List<ZuoBiao> zxzblist2 = new List<ZuoBiao>();
            zxzblist2.Add(new ZuoBiao(358, 85));
            FuHeSanDian zxfh4 = new FuHeSanDian("开头的光头画像", zxsd4, -1, -1, "", zxzblist2);
            _list_yqsandian.Add(zxsd4);
            _list_yqfhsandian.Add(zxfh4);
            SanDian zxsd5 = new SanDian(new int[3, 3]{
	            {  437,  116, 0xc5c5c5},
	            {  410,  125, 0xcfbd40},
	            {  449,  120, 0x7a6313},
            });
            FuHeSanDian zxfh5 = new FuHeSanDian("章节的已完成", zxsd5, 339, 244);
            _list_yqsandian.Add(zxsd5);
            _list_yqfhsandian.Add(zxfh5);
            SanDian zxsd6 = new SanDian(new int[3, 3]{
	            {  263,   59, 0x94db21},
	            {  278,   59, 0x97e027},
	            {  292,   58, 0x9ddc31},
            });
            FuHeSanDian zxfh6 = new FuHeSanDian("章节的进行中", zxsd6, 295, 161);
            _list_yqsandian.Add(zxsd6);
            _list_yqfhsandian.Add(zxfh6);
            SanDian zxsd7 = new SanDian(new int[3, 3]{
	            {  130,   89, 0xbab3aa},
	            {  327,   59, 0x958cb6},
	            {  375,  243, 0xffcf18},
            });
            FuHeSanDian zxfh7 = new FuHeSanDian("第二章开始任务", zxsd7, 341, 239);
            _list_yqsandian.Add(zxsd7);
            _list_yqfhsandian.Add(zxfh7);

            SanDian gtsd1 = new SanDian(new int[3, 3]{
	            {  280,  164, 0xefb294},
	            {  348,  191, 0xff8338},
	            {  350,  201, 0xff7c2d},
            });
            FuHeSanDian gtfh1 = new FuHeSanDian("光头-招募开始", gtsd1, 344, 82);
            _list_yqsandian.Add(gtsd1);
            _list_yqfhsandian.Add(gtfh1);

            SanDian gtsd2 = new SanDian(new int[3, 3]{
	            {  356,  242, 0xefb294},
	            {  427,  268, 0xf0e2d2},
	            {  472,  266, 0xff7827},
            });
            FuHeSanDian gtfh2 = new FuHeSanDian("光头-招募男人", gtsd2, 264, 262);
            _list_yqsandian.Add(gtsd2);
            _list_yqfhsandian.Add(gtfh2);

            SanDian zxsd8 = new SanDian(new int[3, 3]{
	            {   72,  249, 0x445b7d},
	            {  115,  249, 0x445b7d},
	            {  229,  268, 0xff8621},
            });
            FuHeSanDian zxfh8 = new FuHeSanDian("引导时-任务招募", zxsd8, 194, 261);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            SanDian zxsd9 = new SanDian(new int[3, 3]{
	            {  332,  184, 0xe8d3c0},
	            {  209,  183, 0x42c5f5},
	            {  303,  253, 0xffd51d},
            });
            FuHeSanDian zxfh9 = new FuHeSanDian("引导时-女人招募", zxsd9, 269, 261);
            _list_yqsandian.Add(zxsd9);
            _list_yqfhsandian.Add(zxfh9);

            SanDian zxsd10 = new SanDian(new int[3, 3]{
	            {  281,  212, 0xffdb21},
	            {  335,  142, 0xd40e0e},
	            {  165,   82, 0xde3021},
            });
            FuHeSanDian zxfh10 = new FuHeSanDian("引导时-设置昵称", zxsd10, 271, 212);
            _list_yqsandian.Add(zxsd10);
            _list_yqfhsandian.Add(zxfh10);

            SanDian zxsd11 = new SanDian(new int[3, 3]{
	            {  305,  164, 0xefb294},
	            {  308,  189, 0xeab391},
	            {  460,  189, 0xffb838},
            });
            FuHeSanDian zxfh11 = new FuHeSanDian("引导时-光头探索", zxsd11, 495, 263);
            _list_yqsandian.Add(zxsd11);
            _list_yqfhsandian.Add(zxfh11);


            SanDian zxsd12 = new SanDian(new int[3, 3]{
	            {  248,  177, 0xdedcca},
	            {  273,  198, 0xbd3410},
	            {  362,  201, 0xcbbfb2},
            });
            FuHeSanDian zxfh12 = new FuHeSanDian("引导时-进入关卡", zxsd12, 310, 103);
            _list_yqsandian.Add(zxsd12);
            _list_yqfhsandian.Add(zxfh12);

            List<ZuoBiao> gklist1 = new List<ZuoBiao>();
            gklist1.Add(new ZuoBiao(338, 51));
            SanDian ydsd1 = new SanDian(new int[3, 3]{
	            {  374,  240, 0xffcf18},
	            {  462,   52, 0xa02320},
	            {  510,   11, 0x54410c},
            });
            FuHeSanDian ydfh1 = new FuHeSanDian("引导时-关卡界面", ydsd1, 339, 236, "", gklist1);
            _list_yqsandian.Add(ydsd1);
            _list_yqfhsandian.Add(ydfh1);

            SanDian ydsd2 = new SanDian(new int[3, 3]{
	            {  165,   60, 0xcd2d1f},
	            {  192,   58, 0xdad8da},
	            {  307,  201, 0xffcf18},
            });
            FuHeSanDian ydfh2 = new FuHeSanDian("引导时-宝箱领取", ydsd2, 272, 194);
            _list_yqsandian.Add(ydsd2);
            _list_yqfhsandian.Add(ydfh2);

            List<ZuoBiao> ydlist1 = new List<ZuoBiao>();
            ydlist1.Add(new ZuoBiao(463, 127, 0xf7d146));
            ydlist1.Add(new ZuoBiao(463, 182, 0xf7d146));
            ydlist1.Add(new ZuoBiao(463, 238, 0xf7d146));
            ydlist1.Add(new ZuoBiao(372, 265));
            ydlist1.Add(new ZuoBiao(510, 9));
            SanDian ydsd3 = new SanDian(new int[3, 3]{
	            {  262,    9, 0xf0d62a},
	            {  100,    4, 0xe1a000},
	            {  372,   14, 0xd04042},
            });
            FuHeSanDian ydfh3 = new FuHeSanDian("引导时-角色养成", ydsd3, 480, 64, "", ydlist1);
            _list_yqsandian.Add(ydsd3);
            _list_yqfhsandian.Add(ydfh3);

            List<ZuoBiao> ydlist2 = new List<ZuoBiao>();
            ydlist2.Add(new ZuoBiao(494, 279));
            SanDian ydsd4 = new SanDian(new int[3, 3]{
	            {  314,   72, 0x806ec6},
	            {  314,  135, 0x937252},
	            {  321,   69, 0xf3d10f},
            });
            FuHeSanDian ydfh4 = new FuHeSanDian("引导时-招募骑士", ydsd4, 310, 133, "", ydlist2);
            _list_yqsandian.Add(ydsd4);
            _list_yqfhsandian.Add(ydfh4);

            SanDian ydsd5 = new SanDian(new int[3, 3]{
	            {  158,  168, 0xffefde},
	            {  345,  227, 0x9e9143},
	            {  252,  119, 0x212233},
            });
            FuHeSanDian ydfh5 = new FuHeSanDian("引导时-骑士上阵", ydsd5);
            _list_yqsandian.Add(ydsd5);
            _list_yqfhsandian.Add(ydfh5);

            SanDian ydsd6 = new SanDian(new int[3, 3]{
	            {  276,   53, 0xfdb00e},
	            {  101,   45, 0xb1251e},
	            {  347,  226, 0xe6e2d7},
            });
            FuHeSanDian ydfh6 = new FuHeSanDian("引导时-关闭核心技", ydsd6,441,48);
            _list_yqsandian.Add(ydsd6);
            _list_yqfhsandian.Add(ydfh6);

            SanDian ydsd7 = new SanDian(new int[3, 3]{
	            {   75,    4, 0xefae00},
	            {  217,  268, 0xcd594a},
	            {  334,  267, 0xcd594a},
            });
            FuHeSanDian ydfh7 = new FuHeSanDian("引导时-关闭布阵", ydsd7, 510, 11);
            _list_yqsandian.Add(ydsd7);
            _list_yqfhsandian.Add(ydfh7);

            SanDian ydsd71 = new SanDian(new int[3, 3]{
	            {   42,  262, 0xdab892},
	            {   73,    8, 0xefb600},
	            {  445,  263, 0xc01110},
            });
            FuHeSanDian ydfh71 = new FuHeSanDian("引导时-钉头上阵", ydsd71, 479, 210);
            _list_yqsandian.Add(ydsd71);
            _list_yqfhsandian.Add(ydfh71);

            SanDian ydsd8 = new SanDian(new int[3, 3]{
	            {  156,   78, 0xdd3321},
	            {  158,   90, 0xc03421},
	            {  182,   88, 0xe6e6e6},
            });
            FuHeSanDian ydfh8 = new FuHeSanDian("引导时-关闭离开关卡", ydsd8, 320, 208,"取得提示两个字");
            _list_yqsandian.Add(ydsd8);
            _list_yqfhsandian.Add(ydfh8);

            SanDian new11 = new SanDian(new int[3, 3]{
	            {  242,  138, 0x57565d},
	            {  220,  140, 0x5a5860},
	            {  315,  138, 0x9b9795},
            });
            FuHeSanDian new22 = new FuHeSanDian("关闭离开关卡-全得到", new11, 320, 208);
            _list_yqsandian.Add(new11);
            _list_yqfhsandian.Add(new22);

            SanDian ydsd9 = new SanDian(new int[3, 3]{
	            {  100,    2, 0xefaa00},
	            {   44,    3, 0xf0aa00},
	            {   32,   84, 0xf9cf4a},
            });
            FuHeSanDian ydfh9 = new FuHeSanDian("引导时-地图主线任务地底人", ydsd9, 48, 117);
            _list_yqsandian.Add(ydsd9);
            _list_yqfhsandian.Add(ydfh9);

            List<ZuoBiao> ydlist3 = new List<ZuoBiao>();
            ydlist3.Add(new ZuoBiao(122, 197));
            SanDian ydsd10 = new SanDian(new int[3, 3]{
	            {   89,   28, 0x9d221f},
	            {  267,   32, 0xf3aa17},
	            {  481,   34, 0xa53735},
            });
            FuHeSanDian ydfh10 = new FuHeSanDian("引导时-一拳通关", ydsd10, 478, 32, "", ydlist3);
            _list_yqsandian.Add(ydsd10);
            _list_yqfhsandian.Add(ydfh10);

            SanDian ydsd11 = new SanDian(new int[3, 3]{
	            {  372,  195, 0xefb294},
	            {  468,  222, 0xff6509},
	            {  517,  196, 0xffb006},
            });
            FuHeSanDian ydfh11 = new FuHeSanDian("引导时-黑屏普通攻击", ydsd11, 431, 277);
            _list_yqsandian.Add(ydsd11);
            _list_yqfhsandian.Add(ydfh11);

            SanDian ydsd12 = new SanDian(new int[3, 3]{
	            {  224,   53, 0xffb610},
	            {  215,  237, 0xffd920},
	            {  354,  236, 0xd5d5d5},
            });
            FuHeSanDian ydfh12 = new FuHeSanDian("引导时-一拳通关完成关闭", ydsd12, 443, 50);
            _list_yqsandian.Add(ydsd12);
            _list_yqfhsandian.Add(ydfh12);

            SanDian ydsd13 = new SanDian(new int[3, 3]{
	            {  465,  127, 0x7e5b13},
	            {   67,   48, 0xf6c221},
	            {   43,   13, 0xe63b25},
            });
            FuHeSanDian ydfh13 = new FuHeSanDian("引导时-支线完成领取", ydsd13, 458,123);
            _list_yqsandian.Add(ydsd13);
            _list_yqfhsandian.Add(ydfh13);


            List<ZuoBiao> zdlist1 = new List<ZuoBiao>();
            zdlist1.Add(new ZuoBiao(449, 266));
            zdlist1.Add(new ZuoBiao(360, 132));
            zdlist1.Add(new ZuoBiao(449, 266));
            zdlist1.Add(new ZuoBiao(389, 199));
            zdlist1.Add(new ZuoBiao(449, 266));
            zdlist1.Add(new ZuoBiao(337, 90));
            zdlist1.Add(new ZuoBiao(449, 266));
            zdlist1.Add(new ZuoBiao(442, 130));
            zdlist1.Add(new ZuoBiao(449, 266));
            zdlist1.Add(new ZuoBiao(486, 189));
            zdlist1.Add(new ZuoBiao(449, 266));
            zdlist1.Add(new ZuoBiao(411, 91));
            zdlist1.Add(new ZuoBiao(510, 276));
            zdlist1.Add(new ZuoBiao(171, 132));
            zdlist1.Add(new ZuoBiao(510, 276));
            zdlist1.Add(new ZuoBiao(199, 89));
            SanDian kdsd1 = new SanDian(new int[3, 3]{
	            {   91,   14, 0xe6e2cf},
	            {  294,   11, 0xffd852},
	            {  369,  276, 0xffc53a},
            });
            FuHeSanDian kdfh1 = new FuHeSanDian("卡点-战斗不打", kdsd1, 387, 185, "", zdlist1);
            _list_yqsandian.Add(kdsd1);
            _list_yqfhsandian.Add(kdfh1);

            SanDian zdhmsd1 = new SanDian(new int[3, 3]{
	            {  295,   11, 0xffda58},
	            {   15,   37, 0xfce751},
	            {   11,   56, 0x8889a0},
            });
            FuHeSanDian zdhmfh1 = new FuHeSanDian("战斗画面", zdhmsd1, 387, 185);
            _list_yqsandian.Add(zdhmsd1);
            _list_yqfhsandian.Add(zdhmfh1);

            SanDian zdhmsd2 = new SanDian(new int[3, 3]{
	            {   69,   11, 0xa4a789},
	            {   69,   15, 0xb9b6a1},
	            {   79,   10, 0x494d52},
            });
            FuHeSanDian zdhmfh2 = new FuHeSanDian("战斗手动开", zdhmsd2, 71, 14);
            _list_yqsandian.Add(zdhmsd2);
            _list_yqfhsandian.Add(zdhmfh2);

            SanDian zdhmsd3 = new SanDian(new int[3, 3]{
	            {   49,    9, 0xe3ddbd},
	            {   47,   17, 0xfffbd6},
	            {   41,   18, 0xdad7d2},
            });
            FuHeSanDian zdhmfh3 = new FuHeSanDian("战斗1倍速", zdhmsd3, 44, 11);
            _list_yqsandian.Add(zdhmsd3);
            _list_yqfhsandian.Add(zdhmfh3);

            SanDian zdhmsd4 = new SanDian(new int[3, 3]{
	            {  186,  183, 0xefb294},
	            {  188,  195, 0xefb294},
	            {  240,  213, 0xff9b5c},
            });
            FuHeSanDian zdhmfh4 = new FuHeSanDian("战斗介绍1", zdhmsd4, 505, 272);
            _list_yqsandian.Add(zdhmsd4);
            _list_yqfhsandian.Add(zdhmfh4);

            SanDian zdhmsd5 = new SanDian(new int[3, 3]{
	            {  304,  188, 0xe9b394},
	            {  356,  201, 0xffbd91},
	            {  389,  214, 0xff5952},
            });
            FuHeSanDian zdhmfh5 = new FuHeSanDian("战斗介绍2", zdhmsd5, 505, 272);
            _list_yqsandian.Add(zdhmsd5);
            _list_yqfhsandian.Add(zdhmfh5);

            SanDian zdhmsd6 = new SanDian(new int[3, 3]{
	            {  371,  148, 0xefb294},
	            {  424,  170, 0xffc59d},
	            {  508,  157, 0xff731e},
            });
            FuHeSanDian zdhmfh6 = new FuHeSanDian("战斗介绍3", zdhmsd6, 505, 272);
            _list_yqsandian.Add(zdhmsd6);
            _list_yqfhsandian.Add(zdhmfh6);

            SanDian zdhmsd7 = new SanDian(new int[3, 3]{
	            {  410,  243, 0xc5b798},
	            {  410,  261, 0xd5c5b6},
	            {  301,   45, 0x84959c},
            });
            FuHeSanDian zdhmfh7 = new FuHeSanDian("战斗介绍4", zdhmsd7, 505, 272);
            _list_yqsandian.Add(zdhmsd7);
            _list_yqfhsandian.Add(zdhmfh7);

            SanDian zdhmsd8 = new SanDian(new int[3, 3]{
	            {  169,  119, 0xefb294},
	            {  292,  132, 0xff9f64},
	            {  359,  131, 0x51e1ff},
            });
            FuHeSanDian zdhmfh8 = new FuHeSanDian("战斗介绍5", zdhmsd8, 359, 131);
            _list_yqsandian.Add(zdhmsd8);
            _list_yqfhsandian.Add(zdhmfh8);

            SanDian zdhmsd9 = new SanDian(new int[3, 3]{
	            {  409,  245, 0x84a4b3},
	            {  410,   89, 0x58ebff},
	            {  356,  213, 0x312b2b},
            });
            FuHeSanDian zdhmfh9 = new FuHeSanDian("战斗介绍6", zdhmsd9, 506, 276);
            _list_yqsandian.Add(zdhmsd9);
            _list_yqfhsandian.Add(zdhmfh9);

            SanDian new1 = new SanDian(new int[3, 3]{
	            {  337,  156, 0xffd338},
	            {  328,  129, 0x6c3b0e},
	            {  349,  128, 0xe5ba44},
            });
            FuHeSanDian new2 = new FuHeSanDian("第一关领取宝箱", new1, 338, 156);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);
            _dict.Add(new2.Name,new2);

            new1 = new SanDian(new int[3, 3]{
	            {  370,  196, 0xefb294},
	            {  424,  215, 0x746f69},
	            {  417,  262, 0xecd2bc},
            });
            new2 = new FuHeSanDian("战斗介绍8", new1, 506, 276);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);
            _dict.Add(new2.Name, new2);

            new1 = new SanDian(new int[3, 3]{
	            {  336,  196, 0xefb294},
	            {  447,  214, 0xff8c45},
	            {  442,  234, 0xff8439},
            });
            new2 = new FuHeSanDian("第一关角色升级", new1, 396, 276);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  218,  111, 0xefb294},
	            {  215,  130, 0xefb294},
	            {  371,  121, 0xffae00},
            });
            new2 = new FuHeSanDian("第一关角色升级第二步", new1, 267, 276);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  408,  253, 0xf9dec7},
	            {  410,  217, 0xbeb4ad},
	            {  352,  216, 0x1c1818},
            });
            new2 = new FuHeSanDian("战斗画面女人单打", new1, 360, 135);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {   96,  105, 0xefb294},
	            {  197,  120, 0xff8c45},
	            {  212,  129, 0xffcba7},
            });
            new2 = new FuHeSanDian("核心技光头对话", new1, 239, 243);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  252,  180, 0xbfa190},
	            {  320,  193, 0xffcaa4},
	            {  314,   76, 0xffdb73},
            });
            new2 = new FuHeSanDian("核心技光头对话2", new1, 239, 243);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  373,  211, 0xedb396},
	            {  323,  159, 0xe7a618},
	            {  489,  233, 0xff680d},
            });
            new2 = new FuHeSanDian("第一关关底领宝箱", new1, 325, 160);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  371,   92, 0xefb294},
	            {  375,  130, 0xad2c11},
	            {  514,   96, 0xffb823},
            });
            new2 = new FuHeSanDian("第二关开启", new1, 312, 101);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);


            new1 = new SanDian(new int[3, 3]{
	            {   27,   15, 0x1053ae},
	            {   52,    9, 0xe9e9e9},
	            {   58,   14, 0x020302},
            });
            new2 = new FuHeSanDian("第二关无人区界面", new1, 312, 101);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  409,  232, 0x466d44},
	            {  406,  256, 0x9d7a68},
	            {  294,    9, 0xffd954},
            });
            new2 = new FuHeSanDian("战斗画面骑士怒吼", new1, 508, 276);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  404,  225, 0x4a7248},
	            {  402,  257, 0xe7c4ad},
	            {  198,   92, 0x4ddbff},
            });
            new2 = new FuHeSanDian("战斗画面骑士怒吼给女人", new1, 199, 92);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  413,  241, 0xaba07f},
	            {  406,  259, 0xe6d5c5},
	            {  264,   92, 0x7a2617},
            });
            new2 = new FuHeSanDian("战斗画面男人第二关", new1, 199, 92);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  126,   63, 0xefb294},
	            {  251,   81, 0xff8a42},
	            {   69,   15, 0xb9b6a1},
            });
            new2 = new FuHeSanDian("自动战斗打开光头提示", new1);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  188,  172, 0xefb294},
	            {  272,  202, 0xff9f63},
	            {  332,  179, 0xffb10b},
            });
            new2 = new FuHeSanDian("自动战斗集火光头提示", new1);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  147,  234, 0xecc443},
	            {  116,  242, 0xffd345},
	            {  275,  229, 0xdc5847},
            });
            new2 = new FuHeSanDian("发现地底王", new1);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  103,  100, 0xeeb294},
	            {  188,  126, 0xff6c14},
	            {  260,  103, 0xffae0b},
            });
            new2 = new FuHeSanDian("开启第二关的精英关卡", new1,315,109);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  367,  199, 0x9d8a7b},
	            {  452,  230, 0xff670d},
	            {  473,  229, 0xff924f},
            });
            new2 = new FuHeSanDian("试试一拳通关", new1, 444, 276);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  359,  158, 0xecaa1b},
	            {  364,  128, 0x8f6120},
	            {  353,  129, 0xd6a935},
            });
            new2 = new FuHeSanDian("第一精英关领取宝箱", new1, 359, 158);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  243,  147, 0xd64d29},
	            {  230,  139, 0xf7d739},
	            {  377,  165, 0x731010},
            });
            new2 = new FuHeSanDian("地图事件触发", new1);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {   28,   10, 0xfa3e29},
	            {   82,    9, 0xd9d9d9},
	            {   31,   24, 0xc92c1e},
            });
            new2 = new FuHeSanDian("判断地图界面", new1);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  321,  189, 0x604b13},
	            {  319,  177, 0x33d014},
	            {  325,  159, 0xc23001},
            });
            new2 = new FuHeSanDian("加1倍速开启", new1);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {   16,  106, 0x5cd6d7},
	            {   93,  106, 0x64bd0d},
	            {   93,  115, 0xb8b7b7},
            });
            new2 = new FuHeSanDian("第三章任务完成直接领", new1,41,116);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {   23,  105, 0x4ce1e8},
	            {   69,  117, 0xe7e7e7},
	            {   93,  119, 0xcfcfcf},
            });
            new2 = new FuHeSanDian("任务领完继续背头侠", new1, 41, 116);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  244,  208, 0xd89f86},
	            {  329,  229, 0xff690f},
	            {  398,  201, 0xffae00},
            });
            new2 = new FuHeSanDian("每日任务光头开启", new1, 308, 277);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {   21,  149, 0xa1d676},
	            {   27,  147, 0xa1d676},
	            {   87,  153, 0x81e207},
            });
            new2 = new FuHeSanDian("日常已完成", new1, 42, 162);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  105,   10, 0xadaa93},
	            {  101,   12, 0xbfc0a9},
	            {   98,   17, 0xe4e0cb},
            });
            new2 = new FuHeSanDian("战斗中可跳过", new1, 97, 15);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {   45,  107, 0xe7b294},
	            {   97,  130, 0xff9859},
	            {  195,  117, 0xffae00},
            });
            new2 = new FuHeSanDian("协会竞技光头", new1, 282, 117);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  243,  246, 0xe5b49a},
	            {  334,  259, 0xff9654},
	            {  395,  247, 0xffae00},
            });
            new2 = new FuHeSanDian("协会竞技光头2", new1, 104, 156);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  369,  106, 0xebb392},
	            {  501,  127, 0x6d6863},
	            {  520,  109, 0xfab105},
            });
            new2 = new FuHeSanDian("协会竞技光头3", new1, 295, 283);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  249,   61, 0xefb294},
	            {  314,   81, 0x504d4b},
	            {  388,  102, 0xffa608},
            });
            new2 = new FuHeSanDian("协会竞技光头4", new1, 314, 161);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  280,   50, 0xefb294},
	            {  389,   67, 0x373736},
	            {  420,   94, 0xffab11},
            });
            new2 = new FuHeSanDian("协会竞技光头5", new1, 460, 55);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  119,  221, 0xefb294},
	            {  255,  240, 0x76716b},
	            {  271,  223, 0xffad04},
            });
            new2 = new FuHeSanDian("协会竞技光头6", new1, 310, 230);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {   42,    7, 0xfb4129},
	            {   88,    4, 0xefaa00},
	            {  479,  210, 0xfff3c6},
            });
            new2 = new FuHeSanDian("布阵界面", new1);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {   53,  106, 0xefb294},
	            {  122,  137, 0xff8438},
	            {  205,  109, 0xffae06},
            });
            new2 = new FuHeSanDian("战斗失败出现光头", new1,238,186);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {   30,  206, 0xa48545},
	            {   40,  209, 0x6b4208},
	            {   38,  192, 0xcca744},
            });
            new2 = new FuHeSanDian("战斗街道左侧的箱子", new1, 30, 207);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  440,   82, 0xefebde},
	            {  124,  218, 0xfb4420},
	            {  329,  149, 0x9a93c3},
            });
            new2 = new FuHeSanDian("第四章孤高改造人", new1, 330, 239);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {   56,    9, 0xcd301f},
	            {   63,   19, 0x7a7c7a},
	            {  135,   30, 0xefaa00},
            });
            new2 = new FuHeSanDian("第四章-通用剧情界面", new1);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  491,  254, 0x90939d},
	            {  471,  280, 0x92909f},
	            {  517,  274, 0xa9a7b0},
            });
            new2 = new FuHeSanDian("布阵卡死点", new1, 493, 279, "与角色头像-强化开始一起用");
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  316,  148, 0xe0eaf8},
	            {  316,  160, 0x818b9a},
	            {  315,  110, 0xe67f7d},
            });
            new2 = new FuHeSanDian("第四章剧情打红色蚊女", new1, 326, 134, "");
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            //对话框
            SanDian dhsd1 = new SanDian(new int[3, 3]{
	            {  208,  228, 0xfffff7},
	            {  253,  230, 0xfffff7},
	            {  387,  227, 0xfffff7},
            });
            FuHeSanDian dhfh1 = new FuHeSanDian("空白对话框", dhsd1);
            _list_yqsandian.Add(dhsd1);
            _list_yqfhsandian.Add(dhfh1);
            SanDian dhsd2 = new SanDian(new int[3, 3]{
	            {  177,  242, 0xfffff7},
	            {  210,  241, 0xfffff7},
	            {  291,  240, 0xfffff7},
            });
            FuHeSanDian dhfh2 = new FuHeSanDian("空白对话框2", dhsd2);
            _list_yqsandian.Add(dhsd2);
            _list_yqfhsandian.Add(dhfh2);
            SanDian dhsd3 = new SanDian(new int[3, 3]{
	            {  252,  278, 0xaeada9},
	            {  234,  279, 0xd5d4cf},
	            {  264,  279, 0xacaca8},
            });
            FuHeSanDian dhfh3 = new FuHeSanDian("点击任意继续", dhsd3);
            _list_yqsandian.Add(dhsd3);
            _list_yqfhsandian.Add(dhfh3);
            SanDian dhsd4 = new SanDian(new int[3, 3]{
	            {  250,  278, 0xcac8c6},
	            {  237,  280, 0xc9c8c3},
	            {  268,  280, 0xb5b2b1},
            });
            FuHeSanDian dhfh4 = new FuHeSanDian("点击任意继续2", dhsd4);
            _list_yqsandian.Add(dhsd4);
            _list_yqfhsandian.Add(dhfh4);
            SanDian dhsd5 = new SanDian(new int[3, 3]{
	            {  261,  282, 0xe8e7e2},
	            {  278,  282, 0xd1d1cc},
	            {  297,  282, 0xfdfcf6},
            });
            FuHeSanDian dhfh5 = new FuHeSanDian("点击任意继续3", dhsd5);
            _list_yqsandian.Add(dhsd5);
            _list_yqfhsandian.Add(dhfh5);

            SanDian dhsd6 = new SanDian(new int[3, 3]{
	            {  252,  276, 0xbfbfba},
	            {  235,  277, 0x61605e},
	            {  296,  277, 0xb6b5b1},
            });
            FuHeSanDian dhfh6 = new FuHeSanDian("点击任意继续4", dhsd6);
            _list_yqsandian.Add(dhsd6);
            _list_yqfhsandian.Add(dhfh6);

            SanDian dhsd7 = new SanDian(new int[3, 3]{
	            {  277,  278, 0xc4c3be},
	            {  253,  278, 0x8f8e8b},
	            {  242,  282, 0xe0dfda},
            });
            FuHeSanDian dhfh7 = new FuHeSanDian("点击任意继续5", dhsd7);
            _list_yqsandian.Add(dhsd7);
            _list_yqfhsandian.Add(dhfh7);

            //见到就关系列
            SanDian jdgsd1 = new SanDian(new int[3, 3]{
	            {  405,  281, 0x6bdb39},
	            {  460,  264, 0x6bd63e},
	            {  517,    9, 0xffca33},
            });
            FuHeSanDian jdgfh1 = new FuHeSanDian("出现截屏保存", jdgsd1,517,9,"怒吼骑士的保存屏幕");
            _list_yqsandian.Add(jdgsd1);
            _list_yqfhsandian.Add(jdgfh1);

            SanDian jdgsd2 = new SanDian(new int[3, 3]{
	            {  506,    8, 0xffbd16},
	            {  502,    2, 0xb50000},
	            {  524,    9, 0xe5cd4c},
            });
            FuHeSanDian jdgfh2 = new FuHeSanDian("角色关闭窗口", jdgsd2, 517, 9, "卡在角色关闭上-出现很多不能见到就关");
            _list_yqsandian.Add(jdgsd2);
            _list_yqfhsandian.Add(jdgfh2);

            SanDian jdgsd3 = new SanDian(new int[3, 3]{
	            {  217,  118, 0x697fd0},
	            {  276,  119, 0x139895},
	            {  283,  188, 0x5683e2},
            });
            FuHeSanDian jdgfh3 = new FuHeSanDian("掌趣窗口", jdgsd3, 376, 58);
            _list_yqsandian.Add(jdgsd3);
            _list_yqfhsandian.Add(jdgfh3);

            SanDian jdgsd4 = new SanDian(new int[3, 3]{
	            {  428,  239, 0xffdb21},
	            {  206,   94, 0xfe626c},
	            {  450,  114, 0xf0d02a},
            });
            FuHeSanDian jdgfh4 = new FuHeSanDian("章节任务回放", jdgsd4, 468, 44);
            _list_yqsandian.Add(jdgsd4);
            _list_yqfhsandian.Add(jdgfh4);

            SanDian jdgsd5 = new SanDian(new int[3, 3]{
	            {   97,   46, 0x310a08},
	            {  182,   44, 0xc3c5c3},
	            {  425,   50, 0xffae00},
            });
            FuHeSanDian jdgfh5 = new FuHeSanDian("一拳通关关闭", jdgsd5, 443, 50);
            _list_yqsandian.Add(jdgsd5);
            _list_yqfhsandian.Add(jdgfh5);

            SanDian jdgsd6 = new SanDian(new int[3, 3]{
	            {  494,   12, 0x949fa2},
	            {  499,   13, 0x889296},
	            {  512,   13, 0x90999d},
            });
            FuHeSanDian jdgfh6 = new FuHeSanDian("右上角的跳过", jdgsd6, 512, 13);
            _list_yqsandian.Add(jdgsd6);
            _list_yqfhsandian.Add(jdgfh6);

            //任务系列
            SanDian rwsd1 = new SanDian(new int[3, 3]{
	            {   27,  105, 0x44c9d5},
	            {   23,  104, 0x46cfda},
	            {   13,  105, 0x3eb3c3},
            });
            FuHeSanDian rwfh1 = new FuHeSanDian("有主线任务", rwsd1, 35, 119, "排除红色拳头的乱跑");
            _list_yqsandian.Add(rwsd1);
            _list_yqfhsandian.Add(rwfh1);

            SanDian rwsd2 = new SanDian(new int[3, 3]{
	            {  284,   79, 0x84a6e7},
	            {  224,  141, 0xfff8df},
	            {  502,   66, 0x9c2f21},
            });
            FuHeSanDian rwfh2 = new FuHeSanDian("出现战斗失败", rwsd2, 268, 267, "跳出循环准备升级");
            _list_yqsandian.Add(rwsd2);
            _list_yqfhsandian.Add(rwfh2);

            SanDian rwsd3 = new SanDian(new int[3, 3]{
	            {  441,  205, 0x26262c},
	            {  216,   61, 0xa52421},
	            {  280,  189, 0xffdb21},
            });
            FuHeSanDian rwfh3 = new FuHeSanDian("领取关卡宝箱", rwsd3, 280, 189);
            _list_yqsandian.Add(rwsd3);
            _list_yqfhsandian.Add(rwfh3);

            SanDian rwsd4 = new SanDian(new int[3, 3]{
	            {   47,   22, 0x000100},
	            {  366,  239, 0xffcf1a},
	            {  194,   87, 0xf5616b},
            });
            FuHeSanDian rwfh4 = new FuHeSanDian("开始第三章任务", rwsd4, 338, 240 );
            _list_yqsandian.Add(rwsd4);
            _list_yqfhsandian.Add(rwfh4);

            SanDian rwsd5 = new SanDian(new int[3, 3]{
	            {  379,   50, 0x82a9bf},
	            {  519,    5, 0xac0000},
	            {  407,  266, 0xf3801f},
            });
            FuHeSanDian rwfh5 = new FuHeSanDian("协会竞技", rwsd5, 379, 50);
            _list_yqsandian.Add(rwsd5);
            _list_yqfhsandian.Add(rwfh5);

            List<ZuoBiao> ydlist4 = new List<ZuoBiao>();
            ydlist4.Add(new ZuoBiao(422, 256, 0xe2c13f));
            SanDian rwsd6 = new SanDian(new int[3, 3]{
	            {  405,  253, 0x6d4d17},
	            {  102,   73, 0xb67e17},
	            {   54,   31, 0xb72a1d},
            });
            FuHeSanDian rwfh6 = new FuHeSanDian("协会竞技一键领取", rwsd6, 415, 77, "",ydlist4);
            _list_yqsandian.Add(rwsd6);
            _list_yqfhsandian.Add(rwfh6);

            SanDian rwsd61 = new SanDian(new int[3, 3]{
	            {  434,   75, 0xb5b6b5},
	            {  120,   32, 0xa52421},
	            {   89,   81, 0xefae08},
            });
            FuHeSanDian rwfh61 = new FuHeSanDian("协会竞技一键领取可以关闭", rwsd61, 467, 40, "", ydlist4);
            _list_yqsandian.Add(rwsd61);
            _list_yqfhsandian.Add(rwfh61);


            SanDian rwsd62 = new SanDian(new int[3, 3]{
	            {   94,  139, 0xf7bc17},
	            {   51,   37, 0xa32321},
	            {  151,  201, 0xad18b5},
            });
            FuHeSanDian rwfh62 = new FuHeSanDian("协会竞技一键领取可以关闭-再次打开", rwsd62, 467, 40);
            _list_yqsandian.Add(rwsd62);
            _list_yqfhsandian.Add(rwfh62);

            SanDian rwsd7 = new SanDian(new int[3, 3]{
	            {   29,  147, 0x7c7142},
	            {   13,  147, 0xbfab64},
	            {   59,  149, 0xcab66b},
            });
            FuHeSanDian rwfh7 = new FuHeSanDian("钉头锤特定点", rwsd7, 44, 152);
            _list_yqsandian.Add(rwsd7);
            _list_yqfhsandian.Add(rwfh7);

            SanDian rwsd71 = new SanDian(new int[3, 3]{
	            {  148,  136, 0xefb294},
	            {  268,  168, 0xff9655},
	            {  264,  198, 0xffae00},
            });
            FuHeSanDian rwfh71 = new FuHeSanDian("钉头锤光头提示", rwsd71, 44, 152);
            _list_yqsandian.Add(rwsd71);
            _list_yqfhsandian.Add(rwfh71);

            SanDian rwsd72 = new SanDian(new int[3, 3]{
	            {  151,  149, 0xefb294},
	            {  305,  154, 0xffae00},
	            {  259,  174, 0x68635f},
            });
            FuHeSanDian rwfh72 = new FuHeSanDian("钉头锤光头提示2", rwsd72, 44, 152);
            _list_yqsandian.Add(rwsd72);
            _list_yqfhsandian.Add(rwfh72);

            SanDian rwsd73 = new SanDian(new int[3, 3]{
	            {  147,  167, 0xefb294},
	            {  288,  195, 0xff7a29},
	            {  299,  173, 0xffae07},
            });
            FuHeSanDian rwfh73 = new FuHeSanDian("钉头锤光头提示3", rwsd73, 39, 179);
            _list_yqsandian.Add(rwsd73);
            _list_yqfhsandian.Add(rwfh73);

            SanDian rwsd74 = new SanDian(new int[3, 3]{
	            {  153,  169, 0xefb594},
	            {  276,  188, 0x8f887f},
	            {  306,  175, 0xffae04},
            });
            FuHeSanDian rwfh74 = new FuHeSanDian("钉头锤光头提示4", rwsd74, 39, 179);
            _list_yqsandian.Add(rwsd74);
            _list_yqfhsandian.Add(rwfh74);

            SanDian rwsd75 = new SanDian(new int[3, 3]{
	            {  137,   28, 0xfdc875},
	            {  369,   61, 0xa17154},
	            {  360,  230, 0xfeb73c},
            });
            FuHeSanDian rwfh75 = new FuHeSanDian("获得钉头锤", rwsd75);
            _list_yqsandian.Add(rwsd75);
            _list_yqfhsandian.Add(rwfh75);

            SanDian rwsd76 = new SanDian(new int[3, 3]{
	            {   19,  147, 0xc0ab64},
	            {   35,  148, 0xa79454},
	            {   58,  150, 0xf3dd87},
            });
            FuHeSanDian rwfh76 = new FuHeSanDian("获得钉头锤后支线任务判断", rwsd76);
            _list_yqsandian.Add(rwsd76);
            _list_yqfhsandian.Add(rwfh76);

            SanDian rwsd8 = new SanDian(new int[3, 3]{
	            {  424,  200, 0xa28009},
	            {   69,  107, 0xefae08},
	            {  473,  160, 0xa72f31},
            });
            FuHeSanDian rwfh8 = new FuHeSanDian("剧情任务第四章未解锁", rwsd8, 517, 7);
            _list_yqsandian.Add(rwsd8);
            _list_yqfhsandian.Add(rwfh8);

            SanDian rwsd9 = new SanDian(new int[3, 3]{
	            {  188,   54, 0xef9118},
	            {  386,  229, 0xbdcfde},
	            {  235,  104, 0x9d3fe4},
            });
            FuHeSanDian rwfh9 = new FuHeSanDian("体力获取小窗口先关闭", rwsd9, 421, 58);
            _list_yqsandian.Add(rwsd9);
            _list_yqfhsandian.Add(rwfh9);


            SanDian rwsd10 = new SanDian(new int[3, 3]{
	            {   39,   12, 0xff4129},
	            {   55,   51, 0xf7be18},
	            {  477,  128, 0xffdb21},
            });
            FuHeSanDian rwfh10 = new FuHeSanDian("支线领取第1个", rwsd10, 460, 127);
            _list_yqsandian.Add(rwsd10);
            _list_yqfhsandian.Add(rwfh10);

            SanDian rwsd11 = new SanDian(new int[3, 3]{
	            {  463,  180, 0xf2d243},
	            {   55,   53, 0xf7bb17},
	            {   38,   16, 0xfe4129},
            });
            FuHeSanDian rwfh11 = new FuHeSanDian("支线领取第2个", rwsd11, 460, 185);
            _list_yqsandian.Add(rwsd11);
            _list_yqfhsandian.Add(rwfh11);
            //强化系列
            SanDian qhsd1 = new SanDian(new int[3, 3]{
	            {  392,  277, 0x448a5d},
	            {  380,  277, 0x347044},
	            {  380,  287, 0x67690f},
            });
            FuHeSanDian qhfh1 = new FuHeSanDian("角色头像-强化开始", qhsd1,392,280);
            _list_yqsandian.Add(qhsd1);
            _list_yqfhsandian.Add(qhfh1);

            SanDian qhsd2 = new SanDian(new int[3, 3]{
	            {  469,  213, 0xfff3c6},
	            {  263,   10, 0xffe02a},
	            {  469,   60, 0x8ce7ff},
            });
            FuHeSanDian qhfh2 = new FuHeSanDian("角色头像-进入角色界面", qhsd2, 438, 278);
            _list_yqsandian.Add(qhsd2);
            _list_yqfhsandian.Add(qhfh2);

            SanDian qhsd21 = new SanDian(new int[3, 3]{
	            {  439,  275, 0x4aa370},
	            {  427,  272, 0x62c48d},
	            {  437,  290, 0xfefefe},
            });
            FuHeSanDian qhfh21 = new FuHeSanDian("角色头像-主界面上进入角色界面", qhsd21, 443, 278);
            _list_yqsandian.Add(qhsd21);
            _list_yqfhsandian.Add(qhfh21);

            SanDian qhsd3 = new SanDian(new int[3, 3]{
	            {  339,   15, 0xf8d710},
	            {   29,   13, 0xe53925},
	            {  452,  221, 0xcebad6},
            });
            FuHeSanDian qhfh3 = new FuHeSanDian("角色头像-养成角色可关闭", qhsd3,513,10);
            _list_yqsandian.Add(qhsd3);
            _list_yqfhsandian.Add(qhfh3);

            SanDian qhsd4 = new SanDian(new int[3, 3]{
	            {  415,  256, 0xe7494a},
	            {  443,   63, 0xceff30},
	            {  521,   41, 0xf7be18},
            });
            FuHeSanDian qhfh4 = new FuHeSanDian("角色头像-养成角色经验到顶", qhsd4);
            _list_yqsandian.Add(qhsd4);
            _list_yqfhsandian.Add(qhfh4);

            SanDian qhsd41 = new SanDian(new int[3, 3]{
	            {  426,  221, 0xcebad6},
	            {  293,   63, 0xa5660e},
	            {  288,  221, 0xcebad6},
            });
            FuHeSanDian qhfh41 = new FuHeSanDian("角色头像-养成角色经验可用", qhsd41,313,103);
            _list_yqsandian.Add(qhsd41);
            _list_yqfhsandian.Add(qhfh41);

            SanDian qhsd5 = new SanDian(new int[3, 3]{
	            {  403,  263, 0xffcf1a},
	            {  367,  263, 0x290f00},
	            {  311,   60, 0x63cf1b},
            });
            FuHeSanDian qhfh5 = new FuHeSanDian("角色头像-徽章缺少", qhsd5,375,265);
            _list_yqsandian.Add(qhsd5);
            _list_yqfhsandian.Add(qhfh5);

            /*SanDian qhsd50 = new SanDian(new int[3, 3]{
	            {  342,  263, 0xffdb21},
	            {  370,  182, 0xf8e96e},
	            {  304,   59, 0x5dbf1f},
            });
            FuHeSanDian qhfh50 = new FuHeSanDian("角色头像-徽章缺少的界面判断", qhsd50);
            _list_yqsandian.Add(qhsd50);
            _list_yqfhsandian.Add(qhfh50);*/


            SanDian qhsd51 = new SanDian(new int[3, 3]{
	            {  217,  238, 0xffdb21},
	            {  182,  234, 0xffdb21},
	            {  365,   54, 0xffb610},
            });
            FuHeSanDian qhfh51 = new FuHeSanDian("角色头像-一拳通关动画", qhsd51);
            _list_yqsandian.Add(qhsd51);
            _list_yqfhsandian.Add(qhfh51);


            SanDian qhsd52 = new SanDian(new int[3, 3]{
	            {  253,  109, 0xf7d74b},
	            {  201,  109, 0xf57323},
	            {  338,  105, 0xf77521},
            });
            FuHeSanDian qhfh52 = new FuHeSanDian("角色头像-一拳通关动画完成", qhsd52);
            _list_yqsandian.Add(qhsd52);
            _list_yqfhsandian.Add(qhfh52);

            SanDian qhsd6 = new SanDian(new int[3, 3]{
	            {  406,   91, 0xffd01b},
	            {  248,  101, 0xfffbef},
	            {   99,   49, 0xb12625},
            });
            FuHeSanDian qhfh6 = new FuHeSanDian("角色头像-徽章获取仅前往", qhsd6,444,50);
            _list_yqsandian.Add(qhsd6);
            _list_yqfhsandian.Add(qhfh6);

            SanDian qhsd7 = new SanDian(new int[3, 3]{
	            {  392,   96, 0xf4d232},
	            {  338,   95, 0xfffbef},
	            {  103,   45, 0xb52821},
            });
            FuHeSanDian qhfh7 = new FuHeSanDian("角色头像-徽章获取有一拳", qhsd7,444,50);
            _list_yqsandian.Add(qhsd7);
            _list_yqfhsandian.Add(qhfh7);

            List<ZuoBiao> jstx1 = new List<ZuoBiao>();
            jstx1.Add(new ZuoBiao(431, 109));
            jstx1.Add(new ZuoBiao(369, 113));
            jstx1.Add(new ZuoBiao(315, 113));
            jstx1.Add(new ZuoBiao(442, 105));
            jstx1.Add(new ZuoBiao(398, 105));
            jstx1.Add(new ZuoBiao(353, 105));
            jstx1.Add(new ZuoBiao(296, 111));
            SanDian qhsd8 = new SanDian(new int[3, 3]{
	            {  444,   63, 0x1a1c20},
	            {  342,  265, 0x69570d},
	            {  377,  181, 0x645a09},
            });
            FuHeSanDian qhfh8 = new FuHeSanDian("角色头像-出现光头", qhsd8, -1, -1,"一拳通关的光头",jstx1);
            _list_yqsandian.Add(qhsd8);
            _list_yqfhsandian.Add(qhfh8);
            //界面系列
            SanDian jmsd1 = new SanDian(new int[3, 3]{
	            {  346,   11, 0xefcc21},
	            {  150,   30, 0xf8bf4a},
	            {  508,  294, 0xf6c200},
            });
            FuHeSanDian jmfh1 = new FuHeSanDian("主界面", jmsd1);
            _list_yqsandian.Add(jmsd1);
            _list_yqfhsandian.Add(jmfh1);

            SanDian jmsd2 = new SanDian(new int[3, 3]{
	            {   40,   17, 0xf73f29},
	            {  282,   13, 0x2cd4fe},
	            {  509,  270, 0xffc53e},
            });
            FuHeSanDian jmfh2 = new FuHeSanDian("背包界面", jmsd2);
            _list_yqsandian.Add(jmsd2);
            _list_yqfhsandian.Add(jmfh2);

            SanDian jmsd3 = new SanDian(new int[3, 3]{
	            {   49,   17, 0x932e2f},
	            {   69,   18, 0x888b97},
	            {  131,   31, 0xbb7d08},
            });
            FuHeSanDian jmfh3 = new FuHeSanDian("跳过的剧情界面", jmsd3);
            _list_yqsandian.Add(jmsd3);
            _list_yqfhsandian.Add(jmfh3);

            SanDian jmsd31 = new SanDian(new int[3, 3]{
	            {   43,   13, 0x822e2a},
	            {   54,   20, 0xa42f28},
	            {  498,   12, 0xb2babf},
            });
            FuHeSanDian jmfh31 = new FuHeSanDian("跳过的剧情界面3章", jmsd31,499,13);
            _list_yqsandian.Add(jmsd31);
            _list_yqfhsandian.Add(jmfh31);

            SanDian jmsd4 = new SanDian(new int[3, 3]{
	            {   24,   19, 0x114fa1},
	            {   49,   12, 0x5b5b5b},
	            {   67,    7, 0x070707},
            });
            FuHeSanDian jmfh4 = new FuHeSanDian("第一关繁华街道界面", jmsd4);
            _list_yqsandian.Add(jmsd4);
            _list_yqfhsandian.Add(jmfh4);

            //领取系列
            SanDian lqsd1 = new SanDian(new int[3, 3]{
	            {  396,   48, 0xfbe1d5},
	            {  406,   46, 0xf9f0db},
	            {  406,   36, 0xe7494a},
            });
            FuHeSanDian lqfh1 = new FuHeSanDian("领取新手指引", lqsd1,396,48);
            _list_yqsandian.Add(lqsd1);
            _list_yqfhsandian.Add(lqfh1);

            SanDian lqsd2 = new SanDian(new int[3, 3]{
	            {  269,   55, 0xfffbf7},
	            {  378,   35, 0xffffef},
	            {  342,  249, 0xffcf1b},
            });
            FuHeSanDian lqfh2 = new FuHeSanDian("领取新手指引关闭", lqsd2, 378, 37);
            _list_yqsandian.Add(lqsd2);
            _list_yqfhsandian.Add(lqfh2);

            SanDian lqsd3 = new SanDian(new int[3, 3]{
	            {  357,   43, 0x96471c},
	            {  352,   45, 0xedd29d},
	            {  370,   38, 0xefa4a1},
            });
            FuHeSanDian lqfh3 = new FuHeSanDian("领取8日登录", lqsd3);
            _list_yqsandian.Add(lqsd3);
            _list_yqfhsandian.Add(lqfh3);

            SanDian lqsd4 = new SanDian(new int[3, 3]{
	            {  395,   48, 0x7756ad},
	            {  407,   37, 0xe74d4a},
	            {  402,   48, 0x5c2d15},
            });
            FuHeSanDian lqfh4 = new FuHeSanDian("领取登录有礼", lqsd4);
            _list_yqsandian.Add(lqsd4);
            _list_yqfhsandian.Add(lqfh4);

            SanDian lqsd41 = new SanDian(new int[3, 3]{
	            {  409,   77, 0xcd4430},
	            {  463,  126, 0xf7efe7},
	            {  466,  254, 0xa93526},
            });
            FuHeSanDian lqfh41 = new FuHeSanDian("领取登录有礼的关闭", lqsd41,484,56);
            _list_yqsandian.Add(lqsd41);
            _list_yqfhsandian.Add(lqfh41);


            SanDian lqsd42 = new SanDian(new int[3, 3]{
	            {  485,   39, 0xf7efe7},
	            {  426,  236, 0xffffff},
	            {  327,  252, 0xd65cf7},
            });
            FuHeSanDian lqfh42 = new FuHeSanDian("领取登录有礼sr后出现的新关闭", lqsd42, 484, 40);
            _list_yqsandian.Add(lqsd42);
            _list_yqfhsandian.Add(lqfh42);

            SanDian lqsd5 = new SanDian(new int[3, 3]{
	            {  358,   46, 0x7a2214},
	            {  358,   39, 0xebd114},
	            {  362,   50, 0x705645},
            });
            FuHeSanDian lqfh5 = new FuHeSanDian("领取忍者特训", lqsd5);
            _list_yqsandian.Add(lqsd5);
            _list_yqfhsandian.Add(lqfh5);

            SanDian lqsd6 = new SanDian(new int[3, 3]{
	            {   55,  246, 0xad290e},
	            {   49,  242, 0xfefbf2},
	            {   61,  241, 0x962f2a},
            });
            FuHeSanDian lqfh6 = new FuHeSanDian("领取邮件", lqsd6,56,246);
            _list_yqsandian.Add(lqsd6);
            _list_yqfhsandian.Add(lqfh6);

            SanDian lqsd7 = new SanDian(new int[3, 3]{
	            {  398,   45, 0xd5d1c6},
	            {  396,   35, 0xf3eeb7},
	            {  406,   36, 0xe7494a},
            });
            FuHeSanDian lqfh7 = new FuHeSanDian("领取次日登录", lqsd7,397,41);
            _list_yqsandian.Add(lqsd7);
            _list_yqfhsandian.Add(lqfh7);


            //特定的点 例如背包
            SanDian tdsd1 = new SanDian(new int[3, 3]{
	            {  394,  274, 0xefeff1},
	            {  388,  286, 0xedecee},
	            {  386,  265, 0x58b045},
            });
            FuHeSanDian tdfh1 = new FuHeSanDian("主界面特定点背包", tdsd1,391,282);
            _list_yqsandian.Add(tdsd1);
            _list_yqfhsandian.Add(tdfh1);

            //数字截屏
            SanDian szsd1 = new SanDian(new int[3, 3]{
	            {  342,   72, 0xd6aa9c},
	            {  359,   55, 0x7b4d9c},
	            {  396,   58, 0xb04ad3},
            });
            FuHeSanDian szfh1 = new FuHeSanDian("背包里的强者券", szsd1);
            _list_yqsandian.Add(szsd1);
            _list_yqfhsandian.Add(szfh1);
        }
        /// <summary>
        /// 单例模式====双层互锁
        /// </summary>
        /// <returns></returns>
        public static YiQuan_SanDian GetObject()
        {
            if (yqsd == null)
            {
                lock (obj)
                {
                    if (yqsd == null)
                    {
                        yqsd = new YiQuan_SanDian();
                    }
                }
            }
            return yqsd;
        }


        public void addDuodian(DuoDianZhaoSe dz)
        {

        }
        public void delDuodian(DuoDianZhaoSe dz)
        {

        }
        public SanDian findDuodian(SanDian dz)
        {
            return _list_yqsandian.Find(d => d == dz
                );
        }

        public FuHeSanDian findFuHeDuodian(FuHeSanDian fh)
        {
            return _list_yqfhsandian.Find(f => fh.Sd == f.Sd
                && fh.Name.Equals(f.Name)
                );
        }

        public FuHeSanDian findFuHeSandianByName(string name)
        {
            return _list_yqfhsandian.Find(f => name.Equals(f.Name)
                );
        }
        public List<FuHeSanDian> findListFuHeSandianByName(string nameindex)
        {
            return _list_yqfhsandian.FindAll(f => f.Name.IndexOf(nameindex) == 0
                );
        }

        public List<FuHeSanDian> findAllFuHeSandian()
        {
            return _list_yqfhsandian;
        }
        public Dictionary<String,FuHeSanDian> getYiQuanDict()
        {
            return  _dict;
        }
    }
}
