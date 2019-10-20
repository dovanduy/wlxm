using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using xDM;

namespace fuzhu
{
    public class YiQuanZhiTuo_SanDian
    {
        #region 单例模式变量
        private static readonly object obj = new object();
        private static YiQuanZhiTuo_SanDian yqsd = null;
        #endregion
        private YiQuanZhiTuo_SanDian()
        {

        }

        private static List<ZuoBiao> _list_zuobiao = new List<ZuoBiao>();

        public static List<ZuoBiao> List_zuobiao
        {
            get { return YiQuanZhiTuo_SanDian._list_zuobiao; }
            set { YiQuanZhiTuo_SanDian._list_zuobiao = value; }
        }


        private static List<SanDian> _list_yqsandian = new List<SanDian>();

        public static List<SanDian> List_yqsandian
        {
            get { return YiQuanZhiTuo_SanDian._list_yqsandian; }
            set { YiQuanZhiTuo_SanDian._list_yqsandian = value; }
        }


        private static List<FuHeSanDian> _list_yqfhsandian = new List<FuHeSanDian>();

        public static List<FuHeSanDian> List_yqfhsandian
        {
            get { return YiQuanZhiTuo_SanDian._list_yqfhsandian; }
            set { YiQuanZhiTuo_SanDian._list_yqfhsandian = value; }
        }


        private static Dictionary<string, FuHeSanDian> _dict = new Dictionary<string, FuHeSanDian>();

        public static Dictionary<string, FuHeSanDian> Dict
        {
            get { return _dict; }
            set { _dict = value; }
        }

        static YiQuanZhiTuo_SanDian()
        {
            //新增三点 10.10
            SanDian guanbisdx = new SanDian(new int[3, 3] {
	{  439,  131, 0x4d2b05},
	{  432,  160, 0xd79a16},
	{  440,  164, 0x9e421a},
});
            FuHeSanDian guanbifhx = new FuHeSanDian("开引导-领取箱子", guanbisdx, 436, 157);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);


            guanbisdx = new SanDian(new int[3, 3] {
	{  405,  276, 0xf0f0e8},
	{  439,  225, 0xffcf42},
	{  384,  226, 0xffcf42},
});
            guanbifhx = new FuHeSanDian("引导-关闭对话框wl加", guanbisdx, 246, 270);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            List<ZuoBiao> wlls = new List<ZuoBiao>();
            wlls.Add(new ZuoBiao(465, 37, 0xfffbef));
            guanbisdx = new SanDian(new int[3, 3] {
	{  175,   66, 0x865228},
	{  116,  119, 0xf3b00c},
	{  129,   33, 0xa52421},
});
            guanbifhx = new FuHeSanDian("引导-关闭对话框wl加购买花钻石", guanbisdx, 517, 9,"",wlls);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            wlls = new List<ZuoBiao>();
            wlls.Add(new ZuoBiao(417, 63, 0xfffbef));
            wlls.Add(new ZuoBiao(509, 9, 0xffbf12));
            wlls.Add(new ZuoBiao(509, 9, 0xffbf12));
            guanbisdx = new SanDian(new int[3, 3] {
	{  165,   65, 0xffde4f},
	{  122,   66, 0xffe34a},
	{  348,  112, 0x7b499c},
});
            guanbifhx = new FuHeSanDian("引导-关闭对话框wl加购买花钻石2", guanbisdx, 517, 9, "", wlls);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            wlls = new List<ZuoBiao>();
            wlls.Add(new ZuoBiao(419, 65, 0xfffbef));
            guanbisdx = new SanDian(new int[3, 3] {
	{  341,  183, 0xffcb21},
	{  208,  185, 0xffcb21},
	{  176,   66, 0xc64d31},
});
            guanbifhx = new FuHeSanDian("引导-关闭对话框wl加购买花钻石3", guanbisdx, 517, 9, "", wlls);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);


            wlls = new List<ZuoBiao>();
            wlls.Add(new ZuoBiao(419, 252, 0x1b0500));
            wlls.Add(new ZuoBiao(465, 35, 0xfffbf2));
            guanbisdx = new SanDian(new int[3, 3] {
	{   92,   63, 0xf7ba18},
	{  121,   32, 0xa52421},
	{  448,  253, 0xffdb21},
});
            guanbifhx = new FuHeSanDian("引导-积分奖励领取过", guanbisdx, 517, 9, "", wlls);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            wlls = new List<ZuoBiao>();
            wlls.Add(new ZuoBiao(481, 209, 0xfff6c3));
            wlls.Add(new ZuoBiao(458, 266, 0xad1008));
            SanDian new1 = new SanDian(new int[3, 3]{
	            {   42,    7, 0xfb4129},
	            {   88,    4, 0xefaa00},
	            {  479,  210, 0xfff3c6},
            });
            FuHeSanDian new2 = new FuHeSanDian("引导-布阵界面", new1,-1, -1, "", wlls);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            wlls = new List<ZuoBiao>();
            wlls.Add(new ZuoBiao(225, 210, 0xff8621));
            wlls.Add(new ZuoBiao(481, 209, 0xfff6c3));
            wlls.Add(new ZuoBiao(458, 266, 0xad1008));
            new1 = new SanDian(new int[3, 3]{
	{  264,  144, 0x4b4a53},
	{  160,   90, 0xc63523},
	{  224,  211, 0xff8621},
});
            new2 = new FuHeSanDian("引导-布阵界面出现提示有未上阵", new1, -1, -1, "", wlls);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            wlls = new List<ZuoBiao>();
            wlls.Add(new ZuoBiao(465, 36, 0xfffbf1));
            guanbisdx = new SanDian(new int[3, 3] {
	{   91,   78, 0xfcca25},
	{  212,   87, 0xff5d42},
	{  137,   79, 0x4ab200},
});
            guanbifhx = new FuHeSanDian("引导-关闭战报已经胜利", guanbisdx, 517, 9, "", wlls);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            wlls = new List<ZuoBiao>();
            wlls.Add(new ZuoBiao(466, 36, 0xfffbf5));
            guanbisdx = new SanDian(new int[3, 3]{
	{  216,   87, 0xff5d42},
	{  137,   77, 0xde1010},
	{  116,   35, 0xa52421},
});
            guanbifhx = new FuHeSanDian("引导-关闭战报已经失败", guanbisdx, 517, 9, "", wlls);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   38,   23, 0xdc3421},
	{  512,   55, 0x7b20de},
	{  523,  279, 0xfead07},
});
            guanbifhx = new FuHeSanDian("引导-关闭招募活动窗口", guanbisdx, 517, 9);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  186,   90, 0x9c69ce},
	{  292,  209, 0x8a79ab},
	{  444,  183, 0x60409a},
});
            guanbifhx = new FuHeSanDian("引导-关闭萌新礼包", guanbisdx, 459, 55);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);


            guanbisdx = new SanDian(new int[3, 3]{
	{  359,   97, 0xefb294},
	{  512,  109, 0xffb007},
	{  495,  133, 0x999089},
});
            guanbifhx = new FuHeSanDian("引导-关闭小和尚介绍来到协会竞技", guanbisdx, 375, 44);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  149,  166, 0xefb294},
	{  152,  217, 0xad2912},
	{   72,  198, 0xfffefe},
});
            guanbifhx = new FuHeSanDian("引导-关闭小和尚介绍钉头锤任务", guanbisdx, 24, 190);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   42,  117, 0xefb294},
	{  148,  147, 0xff7927},
	{  160,  146, 0xff6b13},
});
            guanbifhx = new FuHeSanDian("王磊引导-拖拽怒吼其实", guanbisdx, 24, 190);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  150,  148, 0xff8d46},
	{  137,  146, 0xff7b2b},
	{   40,  131, 0xefb294},
});
            guanbifhx = new FuHeSanDian("王磊引导-拖拽怒吼其实2", guanbisdx, 24, 190);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            wlls = new List<ZuoBiao>();
            wlls.Add(new ZuoBiao(509, 9, 0xffbf12));
            wlls.Add(new ZuoBiao(509, 9, 0xffbf12));
            guanbisdx = new SanDian(new int[3, 3]{
	{  479,  222, 0xb58239},
	{  488,  119, 0xb98a3d},
	{   41,   19, 0xde3421},
});
            guanbifhx = new FuHeSanDian("引导-超市直接关闭", guanbisdx, 508, 9);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            wlls = new List<ZuoBiao>();
            wlls.Add(new ZuoBiao(388, 73, 0xde2c29));
            guanbisdx = new SanDian(new int[3, 3]{
	{  348,  117, 0xcf4f0f},
	{  320,  119, 0x93c52d},
	{  304,  172, 0xffc310},
});
            guanbifhx = new FuHeSanDian("引导-强者券购买关闭", guanbisdx, 508, 9);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            wlls = new List<ZuoBiao>();
            wlls.Add(new ZuoBiao(389, 74, 0xde2c29));
            guanbisdx = new SanDian(new int[3, 3]{
	{  348,  123, 0xd05314},
	{  315,  123, 0xe55959},
	{  340,  202, 0xffdb21},
});
            guanbifhx = new FuHeSanDian("引导-强者券购买关闭2", guanbisdx, 508, 9);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            wlls = new List<ZuoBiao>();
            wlls.Add(new ZuoBiao(507, 274, 0xfffee8));
            guanbisdx = new SanDian(new int[3, 3]{
	{  415,  253, 0x71645a},
	{  328,  252, 0xa56608},
	{  441,  120, 0x3899af},
});
            guanbifhx = new FuHeSanDian("王磊引导-wl加打蚊女", guanbisdx, 415, 253);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            wlls = new List<ZuoBiao>();
            wlls.Add(new ZuoBiao(507, 274, 0xfffee8));
            guanbisdx = new SanDian(new int[3, 3]{
	{  415,  253, 0x71645a},
	{  328,  252, 0xa56608},
	{  441,  120, 0x3899af},
});
            guanbifhx = new FuHeSanDian("引导-wl加打蚊女", guanbisdx, 415, 253);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  441,  119, 0x3a9eaf},
	{  435,  114, 0xafafaf},
	{  440,  125, 0x173d64},
});
            guanbifhx = new FuHeSanDian("引导-wl加人物有打的提示", guanbisdx, 415, 253);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  324,  120, 0x782b36},
	{  319,  115, 0xfb9b95},
	{  316,  106, 0xe37a79},
});
            guanbifhx = new FuHeSanDian("引导-wl加打蚊女红色拳头", guanbisdx, 324, 126);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  256,   45, 0xefb294},
	{  404,   55, 0xffae05},
	{  319,   82, 0x575451},
});
            guanbifhx = new FuHeSanDian("引导-行业协会查看对手情况wl", guanbisdx, 312, 162);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   73,   16, 0xececd2},
	{   66,   14, 0xf7f4d6},
	{   69,   15, 0xbcbcac},
});
            guanbifhx = new FuHeSanDian("引导-手动改自动wl", guanbisdx, 70, 15);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  365,  103, 0xefb294},
	{  413,  133, 0x76716b},
	{  462,  158, 0xf9ab00},
});
            guanbifhx = new FuHeSanDian("引导-行业协会刚进入wl", guanbisdx, 198, 254);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  270,   37, 0xffe34a},
	{  292,   37, 0xc34121},
	{  462,   50, 0xb5aabd},
});
            guanbifhx = new FuHeSanDian("引导-忍者特训关闭wl", guanbisdx, 490, 41);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  278,   41, 0xffe342},
	{  297,   41, 0xc64121},
	{  321,   18, 0x5e150c},
});
            guanbifhx = new FuHeSanDian("引导-忍者特训关闭2wl", guanbisdx, 490, 41);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  192,   45, 0xffdf3d},
	{  286,   40, 0xffe247},
	{  496,   40, 0xa52422},
});
            guanbifhx = new FuHeSanDian("引导-忍者特训关闭3wl", guanbisdx, 490, 41);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  158,   75, 0xfded3f},
	{  112,   78, 0xffef3c},
	{  439,   57, 0xd64921},
});
            guanbifhx = new FuHeSanDian("引导-关闭萌新福利wl", guanbisdx, 510, 69);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  390,  162, 0xbe5730},
	{  390,  129, 0x5a2808},
	{  408,  129, 0xffcf4a},
});
            guanbifhx = new FuHeSanDian("引导-领取关卡宝箱wl", guanbisdx, 395, 160);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  504,  165, 0xaa391c},
	{  512,  143, 0xfff525},
	{  481,  143, 0xffff21},
});
            guanbifhx = new FuHeSanDian("引导-领取关卡宝箱2wl", guanbisdx, 503, 157);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  259,  100, 0xefb294},
	{  383,  115, 0xff7d2e},
	{  316,  126, 0xff8033},
});
            guanbifhx = new FuHeSanDian("引导-少材料一拳通关提示wl", guanbisdx, 439, 108);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  243,   94, 0xefb294},
	{  370,  115, 0xff7d2e},
	{  301,  126, 0xff8033},
});
            guanbifhx = new FuHeSanDian("引导-少材料一拳通关提示2wl", guanbisdx, 439, 108);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  219,  284, 0xbbbbbb},
	{  222,  261, 0xff8621},
	{   33,   18, 0xcb281c},
});
            guanbifhx = new FuHeSanDian("引导-招募非免费直接关wl", guanbisdx, 508, 9);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  110,  222, 0xde3210},
	{  115,  195, 0xf3ca11},
	{  348,  241, 0xf9d548},
});
            guanbifhx = new FuHeSanDian("引导-第五章开始任务wl", guanbisdx, 336, 241);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  346,  244, 0xf2c645},
	{  408,  130, 0xf7db31},
	{  148,  221, 0xf64322},
});
            guanbifhx = new FuHeSanDian("引导-第五章任务已经完成wl", guanbisdx, 333, 247);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            wlls = new List<ZuoBiao>();
            wlls.Add(new ZuoBiao(467, 44, 0xfffbef));
            wlls.Add(new ZuoBiao(509, 9, 0xffbf12));
            wlls.Add(new ZuoBiao(509, 9, 0xffbf12));
            wlls.Add(new ZuoBiao(509, 9, 0xffbf12));
            guanbisdx = new SanDian(new int[3, 3]{
	{  148,  217, 0xfa4521},
	{  449,  110, 0xf2d62c},
	{  423,  240, 0xffdb21},
});
            guanbifhx = new FuHeSanDian("引导-第五章任务出回放wl", guanbisdx);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  254,  197, 0xefb294},
	{  310,  222, 0x514e4c},
	{  400,  199, 0xffae00},
});
            guanbifhx = new FuHeSanDian("引导-光头要求锻炼技能wl", guanbisdx, 432, 280);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  372,  200, 0xefb294},
	{  426,  222, 0x66625e},
	{  499,  250, 0xffae00},
});
            guanbifhx = new FuHeSanDian("引导-光头要求去获得技能点wl", guanbisdx, 446, 267);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  328,  163, 0xeeb394},
	{  399,  179, 0x4e4b49},
	{  469,  158, 0xffae00},
});
            guanbifhx = new FuHeSanDian("引导-光头要求去获得技能点修行wl", guanbisdx, 372, 265);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  165,  248, 0xefb294},
	{  274,  258, 0xff7625},
	{  306,  242, 0xffae00},
});
            guanbifhx = new FuHeSanDian("引导-光头要求去获得技能点修行不停点wl", guanbisdx, 389, 108);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            new1 = new SanDian(new int[3, 3]{
	            {   21,  149, 0xa1d676},
	            {   27,  147, 0xa1d676},
	            {   87,  153, 0x81e207},
            });
            new2 = new FuHeSanDian("引导-日常已完成", new1, 42, 162);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            guanbisdx = new SanDian(new int[3, 3]{
	{  432,  113, 0xaf8391},
	{  430,   96, 0xaf8e8e},
	{  460,  125, 0x735256},
});
            guanbifhx = new FuHeSanDian("引导-大蚊女下雨中wl", guanbisdx, 440, 121);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  371,  198, 0xff7a29},
	{  353,  197, 0xff6e17},
	{  429,  234, 0xffae00},
});
            guanbifhx = new FuHeSanDian("引导-首领挑战开启先点地图", guanbisdx, 493, 267);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  147,  192, 0xefb294},
	{  193,  197, 0x363535},
	{  292,  179, 0xffae00},
});
            guanbifhx = new FuHeSanDian("王磊引导-wl加钉锤头", guanbisdx, 34, 184);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            wlls = new List<ZuoBiao>();
            wlls.Add(new ZuoBiao(461, 54, 0xfffaef));
            wlls.Add(new ZuoBiao(509, 9, 0xffbf12));
            wlls.Add(new ZuoBiao(509, 9, 0xffbf12));
            guanbisdx = new SanDian(new int[3, 3]{
	{  157,   69, 0xffca32},
	{   83,  145, 0xdeae5a},
	{  255,  175, 0xfbf2ea},
});
            guanbifhx = new FuHeSanDian("引导-wl加协会人物提示", guanbisdx, 509, 9);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            wlls = new List<ZuoBiao>();
            wlls.Add(new ZuoBiao(223, 204, 0xff8b29));
            wlls.Add(new ZuoBiao(509, 9, 0xffbf12));
            wlls.Add(new ZuoBiao(509, 9, 0xffbf12));
            guanbisdx = new SanDian(new int[3, 3]{
	{  347,  123, 0xd2591c},
	{  330,  174, 0xffcb21},
	{  223,  204, 0xff8b29},
});
            guanbifhx = new FuHeSanDian("引导-购买招募非免费直接关wl", guanbisdx);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            wlls = new List<ZuoBiao>();
            wlls.Add(new ZuoBiao(509, 9, 0xffbf12));
            wlls.Add(new ZuoBiao(509, 9, 0xffbf12));
            guanbisdx = new SanDian(new int[3, 3]{
	{  409,  278, 0xff7918},
	{  505,  232, 0xad18b5},
	{  499,  275, 0xffdb21},
});
            guanbifhx = new FuHeSanDian("引导-协会竞技无提示可以关wl", guanbisdx);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            wlls = new List<ZuoBiao>();
            wlls.Add(new ZuoBiao(466, 44, 0xfff8ef));
            wlls.Add(new ZuoBiao(509, 9, 0xffbf12));
            wlls.Add(new ZuoBiao(509, 9, 0xffbf12));
            guanbisdx = new SanDian(new int[3, 3]{
	{  103,  227, 0xd82f10},
	{  106,  200, 0xf4cd10},
	{  428,  238, 0xd6d6d6},
});
            guanbifhx = new FuHeSanDian("引导-第四章任务不能开始关wl", guanbisdx);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  508,   91, 0xa39aa5},
	{  516,   72, 0xa6a8ad},
	{  516,   42, 0xebb117},
});
            guanbifhx = new FuHeSanDian("引导-钉头锤角色技能wl", guanbisdx, 516, 92);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);


            wlls = new List<ZuoBiao>();
            wlls.Add(new ZuoBiao(388, 107, 0xbf9618));
            guanbisdx = new SanDian(new int[3, 3]{
	{  323,  164, 0xecb494},
	{  425,  171, 0x514e4b},
	{  476,  160, 0xffae02},
});
            guanbifhx = new FuHeSanDian("引导-钉头锤角色技能加点wl", guanbisdx, 443, 51);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   31,   20, 0x932417},
	{  515,  127, 0xa499ac},
	{  516,  116, 0xf0f2f8},
});
            guanbifhx = new FuHeSanDian("引导-角色技能限制解除wl", guanbisdx, 513, 128);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   92,   94, 0xf2aa10},
	{  282,  258, 0xffdb21},
	{  509,   67, 0xf7efe7},
});
            guanbifhx = new FuHeSanDian("引导-地表最强男人wl", guanbisdx, 509, 67);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);











            guanbisdx = new SanDian(new int[3, 3] {
	{  162,  286, 0xedcd08},
	{   50,   12, 0xcccccc},
	{  486,  267, 0xede525},
});
            guanbifhx = new FuHeSanDian("引导时-布阵", guanbisdx, 494, 271);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  139,  147, 0xff7825},
	{   47,  106, 0xecb291},
	{   35,    8, 0x681a10},
});
            guanbifhx = new FuHeSanDian("布阵界面", guanbisdx);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   94,   88, 0xebb291},
	{  193,  118, 0xff6408},
	{  203,  119, 0xff6205},
});
            guanbifhx = new FuHeSanDian("引导--介绍核心技", guanbisdx, 31, 56);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   93,  104, 0xebb291},
	{   29,   52, 0x1e160e},
	{  175,  136, 0xff7b2c},
});
            guanbifhx = new FuHeSanDian("引导--介绍核心技使用", guanbisdx, 31, 56);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  244,  153, 0xebb291},
	{  258,  167, 0xebb291},
	{  397,  111, 0x6aaf2e},
});
            guanbifhx = new FuHeSanDian("引导--核心技已激活", guanbisdx, 310, 107);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  442,   49, 0xfffcec},
	{  410,  219, 0x9e9d9b},
	{  398,  115, 0x559e16},
});
            guanbifhx = new FuHeSanDian("引导--核心技已激活--关闭", guanbisdx, 443,44);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  106,  126, 0xebb291},
	{  313,  244, 0x7d4c9e},
	{  400,  265, 0xffda25},
});
            guanbifhx = new FuHeSanDian("引导--已激活", guanbisdx, 421, 266);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  508,    9, 0xffbf18},
	{  460,  216, 0xff8623},
	{   30,   15, 0xf83d26},
});
            guanbifhx = new FuHeSanDian("引导--角色完成--关闭以后如有改动再行修改", guanbisdx, 514, 9);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   25,    9, 0xfb3f2e},
	{  497,   47, 0x4e5ea9},
	{  507,    7, 0xfdba18},
});
            guanbifhx = new FuHeSanDian("引导--角色完成--关闭以后如有改动再行修改第二步退出", guanbisdx, 514, 9);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);


            List<ZuoBiao> zdlist1 = new List<ZuoBiao>();

            guanbisdx = new SanDian(new int[3, 3]{
	{   29,   12, 0xfd4027},
	{  491,   50, 0x4e5ea9},
	{  501,  106, 0x9856c2},
});
            guanbifhx = new FuHeSanDian("引导--角色完成--关闭以后如有改动再行修改第1步退出", guanbisdx, 514, 9);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);
        /*    guanbisdx = new SanDian(new int[3, 3]{
	{   29,   13, 0xfd4028},
	{  501,    8, 0xffbe14},
	{  510,    8, 0xf8cf36},
});
            guanbifhx = new FuHeSanDian("引导--角色完成--关闭以后如有改动再行修改第2步退出", guanbisdx, 514, 9);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);*/


            
guanbisdx = new SanDian(new int[3, 3]{
	{   71,  221, 0xfddb33},
	{  192,  227, 0xd7d7d7},
	{  296,  229, 0xfb4848},
});
            guanbifhx = new FuHeSanDian("引导--核心技已激活完毕--关闭布阵界面", guanbisdx, 510, 10);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  356,   39, 0xeacd12},
	{  368,   36, 0xe54a4a},
	{  362,   45, 0xebb411},
});
            guanbifhx = new FuHeSanDian("王磊引导--7日领取", guanbisdx, 360, 43);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  405,   36, 0xe54848},
	{  406,   36, 0xe54848},
	{  399,   42, 0xf4d6ae},
});
            guanbifhx = new FuHeSanDian("引导--次日登录", guanbisdx, 395, 41);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  435,   49, 0xaa1500},
	{  440,   33, 0xbf3a0f},
	{  440,   36, 0xd23e01},
});
            guanbifhx = new FuHeSanDian("引导--小鼓", guanbisdx, 438, 45);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

        /*    guanbisdx = new SanDian(new int[3, 3]{
	{  472,   44, 0xe56a47},
	{  480,   38, 0xc93e14},
	{  478,   38, 0xcc3f16},
});
            guanbifhx = new FuHeSanDian("引导--福利", guanbisdx, 475, 42);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);*/





            guanbisdx = new SanDian(new int[3, 3]{
	{  393,  126, 0xfeda2d},
	{  158,   54, 0xfbda56},
	{  258,   97, 0xd84b33},
});
            guanbifhx = new FuHeSanDian("引导--明日领取界面--领取", guanbisdx, 407, 124);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  393,  126, 0x482305},
	{  258,   97, 0xefc54a},
	{  165,   50, 0xfbda5f},
});
            guanbifhx = new FuHeSanDian("引导--明日领取界面--领取完毕", guanbisdx, 483, 53);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  224,   71, 0xfff260},
	{  284,   84, 0xfffc71},
	{  366,  155, 0xb63a2a},
});
            guanbifhx = new FuHeSanDian("引导--明日领取出现居合庵", guanbisdx, 515, 64);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  170,   23, 0xfff77b},
	{  412,  119, 0xffda25},
	{  272,   34, 0xffe550},
});
            guanbifhx = new FuHeSanDian("引导--7日领取界面--领取", guanbisdx, 433, 117);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  178,   22, 0xfff77b},
	{  286,   33, 0xfff66a},
	{  418,  119, 0xff8623},
});
            guanbifhx = new FuHeSanDian("引导--7日领取界面--关闭", guanbisdx, 490, 40);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   39,   11, 0xfd4027},
	{   22,   97, 0xdf5221},
	{  441,  131, 0xffda25},
});
            guanbifhx = new FuHeSanDian("引导--活动界面--英雄集结--领取", guanbisdx, 463, 134);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   39,   13, 0xfd4027},
	{   21,   98, 0xdf5221},
	{  439,  132, 0xb7b7b7},
});
            guanbifhx = new FuHeSanDian("引导--活动界面--英雄集结--领取完毕", guanbisdx, 514, 8);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   28,   12, 0xfd4027},
	{   40,   55, 0xf9d02b},
	{  459,  244, 0xffda25},
});
            guanbifhx = new FuHeSanDian("引导--福利签到界面", guanbisdx, 480, 246);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   40,   10, 0xfd4027},
	{   46,   56, 0xf9d02b},
	{  452,  248, 0xb6b6b6},
});
            guanbifhx = new FuHeSanDian("引导--福利签到界面--关闭", guanbisdx, 509, 8);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  165,   72, 0xebb291},
	{  226,  114, 0x383736},
	{  219,  127, 0xff7422},
});
            guanbifhx = new FuHeSanDian("引导--材料不足", guanbisdx, 346, 103);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  100,   49, 0xa72424},
	{  378,   18, 0xebb291},
	{  373,   94, 0x3c2004},
});
            guanbifhx = new FuHeSanDian("引导--引导一拳通关", guanbisdx, 394, 93);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  195,  233, 0x1c0b01},
	{  209,  235, 0x5e3c0f},
	{  248,  240, 0xffd01a},
});
            guanbifhx = new FuHeSanDian("引导--通关一次", guanbisdx, 214, 237);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   42,   90, 0xebb291},
	{   87,  133, 0xff7623},
	{  105,  128, 0xff670c},
});
            guanbifhx = new FuHeSanDian("引导--协会竞技开始了", guanbisdx, 280, 113);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   36,   12, 0xeb3b24},
	{   44,  238, 0xfecf5b},
	{  240,  222, 0xebb291},
});
            guanbifhx = new FuHeSanDian("引导--协会竞技界面", guanbisdx, 116, 140);
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
	{   36,   13, 0xf13d28},
	{  276,  100, 0xebb291},
	{  434,  125, 0xfcaf05},
});
            guanbifhx = new FuHeSanDian("开引导-招募点击精英招募", guanbisdx, 485, 126);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{   29,   25, 0xffebb5},
	{   94,   24, 0xffebab},
	{  150,   34, 0xf84d25},
});
            guanbifhx = new FuHeSanDian("引导-恭喜获得新角色", guanbisdx, 255, 135);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{   16,   35, 0xfddc71},
	{   86,   36, 0xfabf4c},
	{  151,   34, 0xfcc156},
});
            guanbifhx = new FuHeSanDian("引导-恭喜获得新角色--丽丽", guanbisdx, 255, 135);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);


            guanbisdx = new SanDian(new int[3, 3] {
	{  219,   59, 0xffef08},
	{  270,   73, 0xffd909},
	{  324,   79, 0xe73031},
});
            guanbifhx = new FuHeSanDian("引导-恭喜获得（物品）", guanbisdx, 255, 135);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  359,  131, 0x51e3ff},
	{  359,  132, 0x43e2ff},
	{  361,  132, 0x4fddff},
});
            guanbifhx = new FuHeSanDian("引导-攻击位置1", guanbisdx, 335, 92);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  358,  129, 0x57eeff},
	{  360,  129, 0x49e8ff},
	{  360,  131, 0x48dfff},
});
            guanbifhx = new FuHeSanDian("引导-攻击位置2", guanbisdx, 360, 131);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  388,  187, 0x49e5ff},
	{  386,  187, 0x52f0ff},
	{  386,  188, 0x59eeff},
});
            guanbifhx = new FuHeSanDian("引导-攻击位置3", guanbisdx, 385, 180);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);



            guanbisdx = new SanDian(new int[3, 3] {
	{  440,  129, 0x58eeff},
	{  441,  130, 0x4edeff},
	{  441,  131, 0x42deff},
});
            guanbifhx = new FuHeSanDian("引导-攻击位置2后", guanbisdx, 441, 130);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  387,  189, 0x50ebff},
	{  388,  189, 0x54e7ff},
	{  373,  143, 0xfb6f1d},
});
            guanbifhx = new FuHeSanDian("引导-攻击位置3后", guanbisdx, 386, 183);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);


            guanbisdx = new SanDian(new int[3, 3] {
	{  240,   34, 0xfbca25},
	{  258,   52, 0xfdbb0e},
	{  318,   58, 0xf6a40f},
});
            guanbifhx = new FuHeSanDian("引导-胜利", guanbisdx, 262, 161);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);
            guanbisdx = new SanDian(new int[3, 3] {
	{   24,   54, 0xf7db22},
	{   53,   43, 0xffe01a},
	{   87,   40, 0xffe01a},
});
            guanbifhx = new FuHeSanDian("引导-全场最佳", guanbisdx, 262, 161);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{   38,  286, 0xf2a003},
	{   25,  209, 0xe9a71a},
	{   47,  205, 0xf5c44e},
});
            guanbifhx = new FuHeSanDian("引导-剧情中有箱子需要捡取", guanbisdx, 29, 203);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{   13,  101, 0x4ee7ed},
	{   82,  104, 0x7dcf17},
	{   97,  108, 0x6ecf03},
});
            guanbifhx = new FuHeSanDian("引导-主线已完成--点击", guanbisdx, 49, 115);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);         

            List<ZuoBiao> ablist1=new List<ZuoBiao>();
            ablist1.Add(new ZuoBiao(479, 206));
            ablist1.Add(new ZuoBiao(459, 267));
           SanDian guanbi1sdx = new SanDian(new int[3, 3] {
	{   29,   60, 0xaaf012},
	{   32,    8, 0xfd4027},
	{  448,  259, 0xc91414},
});
           FuHeSanDian guanbi1fhx = new FuHeSanDian("引导-剧情--布阵-一键上阵--开始挑战", guanbi1sdx, -1, -1, "", ablist1);
           _list_yqsandian.Add(guanbi1sdx);
           _list_yqfhsandian.Add(guanbi1fhx);

            guanbisdx = new SanDian(new int[3, 3] {
	{  440,  131, 0x4debff},
	{  442,  131, 0x4ce9ff},
	{  442,  129, 0x4ce8ff},
});
            guanbifhx = new FuHeSanDian("引导-攻击螳螂", guanbisdx, 439, 128);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   38,   11, 0xfd4029},
	{  257,   57, 0x8fe22b},
	{  262,   56, 0x95e621},
});
            guanbifhx = new FuHeSanDian("引导-第5章剧情任务进行中", guanbisdx, 304, 171);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  441,  120, 0x62e9ff},
	{   22,  271, 0x701515},
	{  442,  120, 0x63eeff},
});
            guanbifhx = new FuHeSanDian("引导-打击BOSS", guanbisdx, 441, 116);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   77,  260, 0xffec47},
	{  136,  220, 0xebb291},
	{   40,  214, 0xeecdb4},
});
            guanbifhx = new FuHeSanDian("引导-一拳大招", guanbisdx, 50, 251);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  440,  120, 0x54e9ff},
	{  442,  120, 0x45deff},
	{  442,  118, 0x49deff},
});
            guanbifhx = new FuHeSanDian("引导-大蚊子变身", guanbisdx, 440, 120);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  198,   70, 0xfcd30d},
	{  253,   92, 0xffbd08},
	{  331,   85, 0xd13827},
});
            guanbifhx = new FuHeSanDian("引导-剧情奖励", guanbisdx, 273, 147);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   85,   21, 0xfdc646},
	{  147,   26, 0x8d472a},
	{  166,   24, 0x90462d},
});
            guanbifhx = new FuHeSanDian("引导-新人手册", guanbisdx);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   38,   13, 0xf74029},
	{   46,  200, 0xf5bb16},
	{  440,   69, 0xffda25},
});
            guanbifhx = new FuHeSanDian("引导-成长任务领取", guanbisdx, 480, 74);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   79,  196, 0xf8cd26},
	{   81,  196, 0x34343d},
	{   80,  195, 0x38373b},
});
            guanbifhx = new FuHeSanDian("引导-成长任务领取完毕--关闭任务界面", guanbisdx, 510, 9);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);


            List<ZuoBiao> ablist2 = new List<ZuoBiao>();
            ablist2.Add(new ZuoBiao(81, 195,0xe54848));
            ablist2.Add(new ZuoBiao(479, 206));
            guanbisdx = new SanDian(new int[3, 3]{
	{   39,   12, 0xfd4027},
	{   39,   51, 0xf1b712},
	{  442,  125, 0xff8623},
            });
            guanbifhx = new FuHeSanDian("引导-日常任务领取完毕", guanbisdx);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  354,  175, 0xebb291},
	{  392,  261, 0xffda25},
	{  289,  245, 0x341f41},
});
            guanbifhx = new FuHeSanDian("引导-激活", guanbisdx, 421, 263);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   47,  242, 0x9d3131},
	{   31,   15, 0xa8261b},
	{  484,  112, 0x9d3131},
});
            guanbifhx = new FuHeSanDian("引导-角色养成", guanbisdx, 507, 121);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  269,   29, 0xebb291},
	{  328,   64, 0x444341},
	{  519,   44, 0xa13333},
});
            guanbifhx = new FuHeSanDian("引导-角色养成--限制解除", guanbisdx, 478, 61);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  250,  181, 0xebb291},
	{  299,  217, 0xff873e},
	{  142,   28, 0xccaa3b},
});
            guanbifhx = new FuHeSanDian("引导-限制解除--点击角色", guanbisdx, 439, 274);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   27,    8, 0xf13d25},
	{   95,  189, 0xf3c942},
	{  367,  212, 0xffd01a},
});
            guanbifhx = new FuHeSanDian("引导-BOss闪电", guanbisdx, 398, 212);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  373,  183, 0xebb291},
	{  498,  284, 0xca46fb},
	{  515,  256, 0xf33f00},
});
            guanbifhx = new FuHeSanDian("引导-首领挑战1", guanbisdx, 498, 277);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  370,  177, 0xebb291},
	{  427,  208, 0xff8337},
	{  499,  281, 0xc649f8},
});
            guanbifhx = new FuHeSanDian("引导-首领挑战2", guanbisdx, 498, 277);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  302,  164, 0xebb291},
	{  353,  200, 0xff9451},
	{  505,  244, 0xf43e06},
});
            guanbifhx = new FuHeSanDian("引导-首领挑战-探索", guanbisdx, 493, 260);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   45,   79, 0xebb291},
	{  241,   83, 0x3b4f60},
	{  243,  189, 0x7bf939},
});
            guanbifhx = new FuHeSanDian("引导-首次失败提示角色养成", guanbisdx, 239, 184);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  225,   73, 0xfb7963},
	{  237,   75, 0xfb8168},
	{  309,  247, 0xbcbcbc},
});
            guanbifhx = new FuHeSanDian("引导-15级开启协会竞技", guanbisdx, 378, 36);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  225,   75, 0xf78266},
	{  312,  248, 0xffd721},
	{  387,   40, 0xa82424},
});
            guanbifhx = new FuHeSanDian("引导-15级开启协会竞技--领取", guanbisdx, 310, 245);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  272,  121, 0xf36f4e},
	{  258,  138, 0x3c332b},
	{  430,   60, 0xa82424},
});
            guanbifhx = new FuHeSanDian("引导-亲启", guanbisdx, 278, 137);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  391,   45, 0xebbcb0},
	{  407,   35, 0xe54848},
	{  405,   36, 0xe54848},
});
            guanbifhx = new FuHeSanDian("引导-主界面亲启", guanbisdx, 397, 44);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   23,   10, 0xfd4027},
	{  418,  232, 0xaf1ab7},
	{   63,  226, 0xffd01a},
});
            guanbifhx = new FuHeSanDian("引导-竞技自己打一次--非引导", guanbisdx, 43, 226);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   79,   30, 0xd5d5d5},
	{   87,   63, 0xf3b915},
	{  416,   85, 0xffd721},
});
            guanbifhx = new FuHeSanDian("引导-积分奖励领取", guanbisdx, 418, 75);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   90,   63, 0xf4ba15},
	{   78,   31, 0xd2d2d2},
	{  393,   74, 0xb6b6b6},
});
            guanbifhx = new FuHeSanDian("引导-积分奖励领取完毕", guanbisdx, 466, 39);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  419,  228, 0xa719ae},
	{  389,   37, 0xff7373},
	{   27,   10, 0xf13d25},
});
            guanbifhx = new FuHeSanDian("引导-协会竞技奖励", guanbisdx, 376, 49);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  243,   70, 0xfdde08},
	{  295,   74, 0xf14848},
	{  329,   81, 0xdd2e2e},
});
            guanbifhx = new FuHeSanDian("引导-历史最高", guanbisdx, 273, 113);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  205,   77, 0xffe348},
	{  338,  105, 0xb1d3f5},
	{  267,  139, 0xffdb28},
});
            guanbifhx = new FuHeSanDian("引导-胜负已分", guanbisdx, 273, 113);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{   27,   11, 0xee3c25},
	{  113,  204, 0xebb291},
	{  478,  227, 0xa518ac},
});
            guanbifhx = new FuHeSanDian("引导-竞技提示", guanbisdx, 312, 230);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);

            guanbisdx = new SanDian(new int[3, 3]{
	{  380,   47, 0x81c1e3},
	{  366,   88, 0xebb291},
	{  488,  128, 0x6d6863},
});
            guanbifhx = new FuHeSanDian("引导-竞技排行榜提示", guanbisdx, 358, 134);
            _list_yqsandian.Add(guanbisdx);
            _list_yqfhsandian.Add(guanbifhx);





































            SanDian guanbisd1 = new SanDian(new int[3, 3] { { 136, 106, 0xe79941 }, { 232, 223, 0x9b9b9b }, { 302, 231, 0xe79000 } });
            FuHeSanDian guanbifh1 = new FuHeSanDian("引导-关闭实名认证", guanbisd1, 209, 225);
            _list_yqsandian.Add(guanbisd1);
            _list_yqfhsandian.Add(guanbifh1);

            SanDian guanbisd2 = new SanDian(new int[3, 3] {
	            {   64,   25, 0xb02525},
	            {  247,   27, 0xffaf15},
	            {  476,   29, 0xfffbef},
            });
            FuHeSanDian guanbifh2 = new FuHeSanDian("引导-关闭公告", guanbisd2, 475, 29);
            _list_yqsandian.Add(guanbisd2);
            _list_yqfhsandian.Add(guanbifh2);

            SanDian sd1 = new SanDian(new int[3, 3]{
	            {  267,   56, 0x3dc2f0},
	            {  237,  198, 0xa4def2},
	            {  242,  241, 0xe79100},
            });
            FuHeSanDian fh1 = new FuHeSanDian("引导-新账号注册", sd1, 228, 105);
            _list_yqsandian.Add(sd1);
            _list_yqfhsandian.Add(fh1);
            SanDian sd2 = new SanDian(new int[3, 3]{
	            {  264,  241, 0xffd722},
	            {  239,  241, 0x361400},
	            {  258,  267, 0xf4f4f4},
            });
            FuHeSanDian fh2 = new FuHeSanDian("引导-进入游戏", sd2, 260, 241);
            _list_yqsandian.Add(sd2);
            _list_yqfhsandian.Add(fh2);
            SanDian sd3 = new SanDian(new int[3, 3]{
	            {  284,  177, 0x1eaedf},
	            {  242,  204, 0x8fc31f},
	            {  323,  208, 0xf39800},
            });
            FuHeSanDian fh3 = new FuHeSanDian("引导-登录或注册", sd3, 300, 208, "选账号注册");
            _list_yqsandian.Add(sd3);
            _list_yqfhsandian.Add(fh3);
            SanDian sd4 = new SanDian(new int[3, 3]{
	            {  261,  160, 0x95c331},
	            {  316,  196, 0x1eafe1},
	            {  269,   65, 0x1eb9ee},
            });
            FuHeSanDian fh4 = new FuHeSanDian("引导-账号切换后选新账号", sd4, 276, 198);
            _list_yqsandian.Add(sd4);
            _list_yqfhsandian.Add(fh4);
            SanDian sd5 = new SanDian(new int[3, 3]{
	            {  297,  119, 0x8bbe1e},
	            {  312,  158, 0xea9300},
	            {  325,  203, 0x1dacde},
            });
            FuHeSanDian fh5 = new FuHeSanDian("引导-首次进入登录或注册", sd5);
            _list_yqsandian.Add(sd5);
            _list_yqfhsandian.Add(fh5);

            //主线开始
            SanDian ktsd1 = new SanDian(new int[3, 3]{
	            {  226,   86, 0xefb294},
	            {  382,   99, 0xffae00},
	            {  420,  276, 0x833a24},
            });
            FuHeSanDian ktfh1 = new FuHeSanDian("引导-战斗超人画像1", ktsd1, 433, 114
);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);


            SanDian ktsd2 = new SanDian(new int[3, 3]{
	            {  371,  195, 0xefb294},
	            {  496,  245, 0xffad02},
	            {  508,  272, 0xffcc43},
            });
            FuHeSanDian ktfh2 = new FuHeSanDian("引导-战斗超人画像2", ktsd2, 505, 274);
            _list_yqsandian.Add(ktsd2);
            _list_yqfhsandian.Add(ktfh2);

            SanDian ktsd3 = new SanDian(new int[3, 3]{
	            {  228,   88, 0xefb294},
	            {  440,  103, 0x56f0ff},
	            {  404,  248, 0x252828},
            });
            FuHeSanDian ktfh3 = new FuHeSanDian("引导-战斗超人画像3", ktsd3, 440, 103);
            _list_yqsandian.Add(ktsd3);
            _list_yqfhsandian.Add(ktfh3);

            SanDian ktsd4 = new SanDian(new int[3, 3]{
	            {  323,  191, 0xefb294},
	            {  411,  288, 0x916a4a},
	            {  503,  276, 0x986c56},
            });
            FuHeSanDian ktfh4 = new FuHeSanDian("引导-骑士画像1", ktsd4, 508, 269);
            _list_yqsandian.Add(ktsd4);
            _list_yqfhsandian.Add(ktfh4);

            SanDian ktsd5 = new SanDian(new int[3, 3]{
	            {  250,  116, 0xefb294},
	            {  171,  134, 0x58e7ff},
	            {  509,  278, 0x855c47},
            });
            FuHeSanDian ktfh5 = new FuHeSanDian("引导-骑士画像2", ktsd5, 171, 134);
            _list_yqsandian.Add(ktsd5);
            _list_yqfhsandian.Add(ktfh5);

            SanDian ktsd6 = new SanDian(new int[3, 3]{
	            {  413,  240, 0xe3ccb9},
	            {  410,  259, 0xe1cab7},
	            {  435,  112, 0x38355e},
            });
            FuHeSanDian ktfh6 = new FuHeSanDian("引导-爆炸头1", ktsd6, 511, 274);
            _list_yqsandian.Add(ktsd6);
            _list_yqfhsandian.Add(ktfh6);

            SanDian ktsd7 = new SanDian(new int[3, 3]{
	            {  419,  244, 0xe9d1bf},
	            {  398,  238, 0xe8d0be},
	            {  441,  103, 0x54edff},
            });
            FuHeSanDian ktfh7 = new FuHeSanDian("引导-爆炸头2", ktsd7, 438, 108);
            _list_yqsandian.Add(ktsd7);
            _list_yqfhsandian.Add(ktfh7);

            SanDian ktsd8 = new SanDian(new int[3, 3]{
	            {  412,  238, 0xeecab0},
	            {  360,   86, 0x4bdfff},
	            {  492,  274, 0x60130d},
            });
            FuHeSanDian ktfh8 = new FuHeSanDian("引导-一拳光头", ktsd8, 360, 86);
            _list_yqsandian.Add(ktsd8);
            _list_yqfhsandian.Add(ktfh8);

            SanDian ktsd9 = new SanDian(new int[3, 3]{
	            {  288,  150, 0xefb294},
	            {  167,   54, 0x85c931},
	            {  178,  222, 0xff4521},
            });
            FuHeSanDian ktfh9 = new FuHeSanDian("引导-第一章", ktsd9, 170, 154);
            _list_yqsandian.Add(ktsd9);
            _list_yqfhsandian.Add(ktfh9);

            SanDian ktsd10 = new SanDian(new int[3, 3]{
	            {  432,  113, 0xb3a31f},
	            {  152,  212, 0xfe4526},
	            {  321,   63, 0x9991c2},
            });
            FuHeSanDian ktfh10 = new FuHeSanDian("引导-第一章完成", ktsd10, 340, 238);
            _list_yqsandian.Add(ktsd10);
            _list_yqfhsandian.Add(ktfh10);

            SanDian ktsd11 = new SanDian(new int[3, 3]{
	            {  135,   30, 0xefb294},
	            {  360,   56, 0x4ee4ff},
	            {  411,  250, 0xebc5a9},
            });
            FuHeSanDian ktfh11 = new FuHeSanDian("引导-第2章打巨人", ktsd11, 360, 56);
            _list_yqsandian.Add(ktsd11);
            _list_yqfhsandian.Add(ktfh11);


            SanDian ktsd12 = new SanDian(new int[3, 3]{
	            {  372,  188, 0xefb294},
	            {  361,  229, 0x9a6b26},
	            {  439,  277, 0xd7dbda},
            });
            FuHeSanDian ktfh12 = new FuHeSanDian("引导-领取任务奖励", ktsd12, 441, 273);
            _list_yqsandian.Add(ktsd12);
            _list_yqfhsandian.Add(ktfh12);

            SanDian ktsd13 = new SanDian(new int[3, 3]{
	            {  202,  247, 0xff6f19},
	            {  113,  212, 0xefb294},
	            {  293,   80, 0x991e22},
            });
            FuHeSanDian ktfh13 = new FuHeSanDian("引导-光头提示有强者券", ktsd13, 284, 273);
            _list_yqsandian.Add(ktsd13);
            _list_yqfhsandian.Add(ktfh13);

            SanDian ktsd14 = new SanDian(new int[3, 3]{
	            {  309,  109, 0x01f901},
	            {  254,  174, 0xb9b69c},
	            {  302,  176, 0xc6c6e7},
            });
            FuHeSanDian ktfh14 = new FuHeSanDian("引导-提示解锁招募和探索", ktsd13, 284, 273);
            _list_yqsandian.Add(ktsd14);
            _list_yqfhsandian.Add(ktfh14);

            SanDian zxsd3 = new SanDian(new int[3, 3]{
	            {  404,  245, 0xe1cab7},
	            {  398,  284, 0x373734},
	            {  418,  292, 0x6b635a},
            });
            FuHeSanDian zxfh3 = new FuHeSanDian("引导-爆炸头画像", zxsd3, -1, -1, "");
            _list_yqsandian.Add(zxsd3);
            _list_yqfhsandian.Add(zxfh3);
            SanDian zxsd4 = new SanDian(new int[3, 3]{
	            {  405,  236, 0xecc8ae},
	            {  402,  262, 0xeac3a7},
	            {  412,  291, 0xc1b9ac},
            });
            List<ZuoBiao> zxzblist2 = new List<ZuoBiao>();
            zxzblist2.Add(new ZuoBiao(358, 85));
            FuHeSanDian zxfh4 = new FuHeSanDian("引导-光头画像", zxsd4, -1, -1, "", zxzblist2);
            _list_yqsandian.Add(zxsd4);
            _list_yqfhsandian.Add(zxfh4);
            SanDian zxsd5 = new SanDian(new int[3, 3]{
	            {  437,  116, 0xc5c5c5},
	            {  410,  125, 0xcfbd40},
	            {  449,  120, 0x7a6313},
            });
            FuHeSanDian zxfh5 = new FuHeSanDian("引导-章节的已完成", zxsd5, 339, 244);
            _list_yqsandian.Add(zxsd5);
            _list_yqfhsandian.Add(zxfh5);
            SanDian zxsd6 = new SanDian(new int[3, 3]{
	            {  263,   59, 0x94db21},
	            {  278,   59, 0x97e027},
	            {  292,   58, 0x9ddc31},
            });
            FuHeSanDian zxfh6 = new FuHeSanDian("引导-章节的进行中", zxsd6, 295, 161);
            _list_yqsandian.Add(zxsd6);
            _list_yqfhsandian.Add(zxfh6);
            SanDian zxsd7 = new SanDian(new int[3, 3]{
	            {  130,   89, 0xbab3aa},
	            {  327,   59, 0x958cb6},
	            {  375,  243, 0xffcf18},
            });
            FuHeSanDian zxfh7 = new FuHeSanDian("引导-第二章开始任务", zxsd7, 341, 239);
            _list_yqsandian.Add(zxsd7);
            _list_yqfhsandian.Add(zxfh7);

            SanDian gtsd1 = new SanDian(new int[3, 3]{
	            {  280,  164, 0xefb294},
	            {  348,  191, 0xff8338},
	            {  350,  201, 0xff7c2d},
            });
            FuHeSanDian gtfh1 = new FuHeSanDian("引导-光头-招募开始", gtsd1, 344, 82);
            _list_yqsandian.Add(gtsd1);
            _list_yqfhsandian.Add(gtfh1);

            SanDian gtsd2 = new SanDian(new int[3, 3]{
	            {  356,  242, 0xefb294},
	            {  427,  268, 0xf0e2d2},
	            {  472,  266, 0xff7827},
            });
            FuHeSanDian gtfh2 = new FuHeSanDian("引导-光头-招募杰诺斯", gtsd2, 264, 262);
            _list_yqsandian.Add(gtsd2);
            _list_yqfhsandian.Add(gtfh2);

            SanDian zxsd8 = new SanDian(new int[3, 3]{
	            {   72,  249, 0x445b7d},
	            {  115,  249, 0x445b7d},
	            {  229,  268, 0xff8621},
            });
            FuHeSanDian zxfh8 = new FuHeSanDian("引导-任务招募", zxsd8, 194, 261);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            zxsd8 = new SanDian(new int[3, 3] {
	{   36,   13, 0xf13d28},
	{  276,  100, 0xebb291},
	{  434,  125, 0xfcaf05},
});
            zxfh8 = new FuHeSanDian("引导-招募点击精英招募", zxsd8, 485, 126);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            zxsd8 = new SanDian(new int[3, 3] {
	{  509,   71, 0x214a99},
	{  511,  124, 0xfed520},
	{  199,  261, 0x340602},
});
            zxfh8 = new FuHeSanDian("引导-招募点击精英招募---招募一次", zxsd8, 190, 263);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            zxsd8 = new SanDian(new int[3, 3] {
	{  359,  130, 0x59eaff},
	{  358,  130, 0x53f0ff},
	{  168,  101, 0xebb291},
});
            zxfh8 = new FuHeSanDian("引导-攻击前排", zxsd8, 359, 130);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            zxsd8 = new SanDian(new int[3, 3] {
	{  373,  178, 0xebb291},
	{  419,  213, 0x504e4c},
	{  423,  213, 0x444341},
});
            zxfh8 = new FuHeSanDian("引导-丽丽的绝技", zxsd8, 504, 273);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            zxsd8 = new SanDian(new int[3, 3] {
	{  410,   90, 0x54e4ff},
	{  410,   90, 0x54e4ff},
	{  411,   91, 0x48e1ff},
});
            zxfh8 = new FuHeSanDian("引导-后排位置1", zxsd8, 407, 89);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            zxsd8 = new SanDian(new int[3, 3] {
	{  484,  186, 0x5fecfe},
	{  484,  188, 0x65fdfe},
	{  469,  135, 0xf77024},
});
            zxfh8 = new FuHeSanDian("引导-后排位置2", zxsd8, 485, 186);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            zxsd8 = new SanDian(new int[3, 3] {
	{   41,   60, 0xef4545},
	{   55,   91, 0xfffcec},
	{   42,  117, 0xfffcec},
});
            zxfh8 = new FuHeSanDian("引导-首领登场", zxsd8, 485, 186);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            zxsd8 = new SanDian(new int[3, 3] {
	{  159,   45, 0xd0d0d0},
	{  504,  115, 0x8042a8},
	{   29,  267, 0xdbcbbc},
});
            zxfh8 = new FuHeSanDian("引导-第一次进入养成", zxsd8, 476, 63);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            zxsd8 = new SanDian(new int[3, 3] {
	{  354,  263, 0x230a00},
	{  406,  266, 0xffd31d},
	{  415,  256, 0xe54848},
});
            zxfh8 = new FuHeSanDian("引导-界限突破-普通", zxsd8, 373, 263);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            zxsd8 = new SanDian(new int[3, 3] {
	{  161,  223, 0xebb291},
	{  408,  266, 0xffd01a},
	{  377,   63, 0xe1d797},
});
            zxfh8 = new FuHeSanDian("引导-界限突破-提示", zxsd8, 373, 263);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);


            zxsd8 = new SanDian(new int[3, 3] {
	{  215,   64, 0xffef08},
	{  290,   81, 0xe42f2f},
	{  264,  125, 0xf6de00},
});
            zxfh8 = new FuHeSanDian("引导-界限突破成功", zxsd8, 373, 263);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            zxsd8 = new SanDian(new int[3, 3] {
	{  317,   13, 0xebb291},
	{  399,   47, 0xff6103},
	{  406,   49, 0xff711c},
});
            zxfh8 = new FuHeSanDian("引导-界限突破成功--返回", zxsd8, 510, 9);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            zxsd8 = new SanDian(new int[3, 3] {
	{  358,  133, 0x53eeff},
	{  360,  133, 0x4be0ff},
	{  360,  135, 0x46ddff},
});
            zxfh8 = new FuHeSanDian("引导-打击位置前排中间", zxsd8, 359, 132);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);
           /* zxsd8 = new SanDian(new int[3, 3] {
	{  386,  187, 0x5ef1ff},
	{  387,  187, 0x5eedff},
	{  387,  189, 0x65fdff},
});
            zxfh8 = new FuHeSanDian("引导-打击位置前排下", zxsd8, 389, 186);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);*/

            zxsd8 = new SanDian(new int[3, 3]{
	{  330,   89, 0x3a84c7},
	{  330,   91, 0x3a88ca},
	{  330,   93, 0x2d75b3},
});
            zxfh8 = new FuHeSanDian("引导-打击位置前排上", zxsd8, 332, 91);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            zxsd8 = new SanDian(new int[3, 3]{
	{  440,  128, 0x51eeff},
	{  440,  130, 0x51e7ff},
	{  442,  130, 0x42dfff},
});
            zxfh8 = new FuHeSanDian("引导-打击位置后排中间", zxsd8, 441, 130);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            zxsd8 = new SanDian(new int[3, 3]{
	{  312,   63, 0x6859af},
	{  313,   71, 0xf3cf0c},
	{  313,   77, 0x6e5fb5},
});
            zxfh8 = new FuHeSanDian("引导-对话", zxsd8, 309, 135);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            zxsd8 = new SanDian(new int[3, 3]{
	{  256,   49, 0x0a243d},
	{  376,   44, 0xbc7acc},
	{  378,   35, 0xfd4200},
});
            zxfh8 = new FuHeSanDian("引导-精英关卡开启--点击精英关卡", zxsd8, 344, 47);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            zxsd8 = new SanDian(new int[3, 3]{
	{  268,   12, 0x695921},
	{  291,   15, 0x695b29},
	{  421,  277, 0xe9d8c8},
});
            zxfh8 = new FuHeSanDian("引导-海底王--首攻", zxsd8, 426, 272);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            zxsd8 = new SanDian(new int[3, 3]{
	{   36,   82, 0xfdcc48},
	{    8,  138, 0x7ba95a},
	{    8,  172, 0xa79554},
});
            zxfh8 = new FuHeSanDian("引导-支线任务出现--点击", zxsd8, 30, 171);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            zxsd8 = new SanDian(new int[3, 3]{
	{  463,  159, 0xb02f30},
	{  282,   48, 0xf4d42e},
	{  134,   47, 0xf5db2f},
});
            zxfh8 = new FuHeSanDian("引导-3章完成-4章不够", zxsd8, 510, 9);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            zxsd8 = new SanDian(new int[3, 3]{
	{   39,   15, 0xfc4027},
	{   53,   52, 0xf4ba16},
	{  123,  164, 0x68a140},
});
            zxfh8 = new FuHeSanDian("引导-点击金币", zxsd8, 464, 182);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);

            zxsd8 = new SanDian(new int[3, 3]{
	{   39,   15, 0xfc4027},
	{   53,   52, 0xf4ba16},
	{  123,  164, 0x68a140},
});
            zxfh8 = new FuHeSanDian("引导-点击金币", zxsd8, 464, 182);
            _list_yqsandian.Add(zxsd8);
            _list_yqfhsandian.Add(zxfh8);






            SanDian zxsd9 = new SanDian(new int[3, 3]{
	            {  332,  184, 0xe8d3c0},
	            {  209,  183, 0x42c5f5},
	            {  303,  253, 0xffd51d},
            });
            FuHeSanDian zxfh9 = new FuHeSanDian("引导-招募莉莉", zxsd9, 269, 261);
            _list_yqsandian.Add(zxsd9);
            _list_yqfhsandian.Add(zxfh9);

            SanDian zxsd10 = new SanDian(new int[3, 3]{
	            {  281,  212, 0xffdb21},
	            {  335,  142, 0xd40e0e},
	            {  165,   82, 0xde3021},
            });
            FuHeSanDian zxfh10 = new FuHeSanDian("引导-设置昵称", zxsd10, 271, 212);
            _list_yqsandian.Add(zxsd10);
            _list_yqfhsandian.Add(zxfh10);

            SanDian zxsd11 = new SanDian(new int[3, 3]{
	            {  305,  164, 0xefb294},
	            {  308,  189, 0xeab391},
	            {  460,  189, 0xffb838},
            });
            FuHeSanDian zxfh11 = new FuHeSanDian("引导-光头探索", zxsd11, 495, 263);
            _list_yqsandian.Add(zxsd11);
            _list_yqfhsandian.Add(zxfh11);


            SanDian zxsd12 = new SanDian(new int[3, 3]{
	            {  248,  177, 0xdedcca},
	            {  273,  198, 0xbd3410},
	            {  362,  201, 0xcbbfb2},
            });
            FuHeSanDian zxfh12 = new FuHeSanDian("引导-进入关卡", zxsd12, 310, 103);
            _list_yqsandian.Add(zxsd12);
            _list_yqfhsandian.Add(zxfh12);

           
            SanDian ydsd1 = new SanDian(new int[3, 3]{
	            {  374,  240, 0xffcf18},
	            {  462,   52, 0xa02320},
	            {  510,   11, 0x54410c},
            });
            FuHeSanDian ydfh1 = new FuHeSanDian("引导-关卡界面", ydsd1, 339, 236);
            _list_yqsandian.Add(ydsd1);
            _list_yqfhsandian.Add(ydfh1);

            SanDian ydsd2 = new SanDian(new int[3, 3]{
	            {  165,   60, 0xcd2d1f},
	            {  192,   58, 0xdad8da},
	            {  307,  201, 0xffcf18},
            });
            FuHeSanDian ydfh2 = new FuHeSanDian("引导-宝箱领取", ydsd2, 272, 194);
            _list_yqsandian.Add(ydsd2);
            _list_yqfhsandian.Add(ydfh2);

            /*List<ZuoBiao> ydlist1 = new List<ZuoBiao>();
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
            FuHeSanDian ydfh3 = new FuHeSanDian("引导-角色养成", ydsd3, 480, 64, "", ydlist1);
            _list_yqsandian.Add(ydsd3);
            _list_yqfhsandian.Add(ydfh3);*/

            List<ZuoBiao> ydlist2 = new List<ZuoBiao>();
            ydlist2.Add(new ZuoBiao(494, 279));
            SanDian ydsd4 = new SanDian(new int[3, 3]{
	            {  314,   72, 0x806ec6},
	            {  314,  135, 0x937252},
	            {  321,   69, 0xf3d10f},
            });
            FuHeSanDian ydfh4 = new FuHeSanDian("引导-招募骑士", ydsd4, 310, 133, "", ydlist2);
            _list_yqsandian.Add(ydsd4);
            _list_yqfhsandian.Add(ydfh4);

            SanDian ydsd5 = new SanDian(new int[3, 3]{
	            {  158,  168, 0xffefde},
	            {  345,  227, 0x9e9143},
	            {  252,  119, 0x212233},
            });
            FuHeSanDian ydfh5 = new FuHeSanDian("引导-骑士上阵", ydsd5);
            _list_yqsandian.Add(ydsd5);
            _list_yqfhsandian.Add(ydfh5);

            SanDian ydsd6 = new SanDian(new int[3, 3]{
	            {  276,   53, 0xfdb00e},
	            {  101,   45, 0xb1251e},
	            {  347,  226, 0xe6e2d7},
            });
            FuHeSanDian ydfh6 = new FuHeSanDian("引导-关闭核心技", ydsd6, 441, 48);
            _list_yqsandian.Add(ydsd6);
            _list_yqfhsandian.Add(ydfh6);

            SanDian ydsd7 = new SanDian(new int[3, 3]{
	            {   75,    4, 0xefae00},
	            {  217,  268, 0xcd594a},
	            {  334,  267, 0xcd594a},
            });
            FuHeSanDian ydfh7 = new FuHeSanDian("引导-关闭布阵", ydsd7, 510, 11);
            _list_yqsandian.Add(ydsd7);
            _list_yqfhsandian.Add(ydfh7);

            SanDian ydsd71 = new SanDian(new int[3, 3]{
	            {   42,  262, 0xdab892},
	            {   73,    8, 0xefb600},
	            {  445,  263, 0xc01110},
            });
            FuHeSanDian ydfh71 = new FuHeSanDian("引导-钉头上阵", ydsd71, 479, 210);
            _list_yqsandian.Add(ydsd71);
            _list_yqfhsandian.Add(ydfh71);

            SanDian ydsd8 = new SanDian(new int[3, 3]{
	            {  156,   78, 0xdd3321},
	            {  158,   90, 0xc03421},
	            {  182,   88, 0xe6e6e6},
            });
            FuHeSanDian ydfh8 = new FuHeSanDian("引导-关闭离开关卡", ydsd8, 320, 208, "引导-取得提示两个字");
            _list_yqsandian.Add(ydsd8);
            _list_yqfhsandian.Add(ydfh8);

            SanDian new11 = new SanDian(new int[3, 3]{
	            {  242,  138, 0x57565d},
	            {  220,  140, 0x5a5860},
	            {  315,  138, 0x9b9795},
            });
            FuHeSanDian new22 = new FuHeSanDian("引导-关闭离开关卡-全得到", new11, 320, 208);
            _list_yqsandian.Add(new11);
            _list_yqfhsandian.Add(new22);

            SanDian ydsd9 = new SanDian(new int[3, 3]{
	            {  100,    2, 0xefaa00},
	            {   44,    3, 0xf0aa00},
	            {   32,   84, 0xf9cf4a},
            });
            FuHeSanDian ydfh9 = new FuHeSanDian("引导-地图主线任务地底人", ydsd9, 48, 117);
            _list_yqsandian.Add(ydsd9);
            _list_yqfhsandian.Add(ydfh9);

            List<ZuoBiao> ydlist3 = new List<ZuoBiao>();
            ydlist3.Add(new ZuoBiao(122, 197));
            SanDian ydsd10 = new SanDian(new int[3, 3]{
	            {   89,   28, 0x9d221f},
	            {  267,   32, 0xf3aa17},
	            {  481,   34, 0xa53735},
            });
            FuHeSanDian ydfh10 = new FuHeSanDian("引导-一拳通关", ydsd10, 478, 32, "", ydlist3);
            _list_yqsandian.Add(ydsd10);
            _list_yqfhsandian.Add(ydfh10);

            SanDian ydsd11 = new SanDian(new int[3, 3]{
	            {  372,  195, 0xefb294},
	            {  468,  222, 0xff6509},
	            {  517,  196, 0xffb006},
            });
            FuHeSanDian ydfh11 = new FuHeSanDian("引导-黑屏普通攻击", ydsd11, 431, 277);
            _list_yqsandian.Add(ydsd11);
            _list_yqfhsandian.Add(ydfh11);

            SanDian ydsd12 = new SanDian(new int[3, 3]{
	            {  224,   53, 0xffb610},
	            {  215,  237, 0xffd920},
	            {  354,  236, 0xd5d5d5},
            });
            FuHeSanDian ydfh12 = new FuHeSanDian("引导-一拳通关完成关闭", ydsd12, 443, 50);
            _list_yqsandian.Add(ydsd12);
            _list_yqfhsandian.Add(ydfh12);

            SanDian ydsd13 = new SanDian(new int[3, 3]{
	            {  465,  127, 0x7e5b13},
	            {   67,   48, 0xf6c221},
	            {   43,   13, 0xe63b25},
            });
            FuHeSanDian ydfh13 = new FuHeSanDian("引导-支线完成领取", ydsd13, 458, 123);
            _list_yqsandian.Add(ydsd13);
            _list_yqfhsandian.Add(ydfh13);


            /* List<ZuoBiao> zdlist1 = new List<ZuoBiao>();
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
             FuHeSanDian kdfh1 = new FuHeSanDian("引导-卡点-战斗不打", kdsd1, 387, 185, "", zdlist1);
             _list_yqsandian.Add(kdsd1);
             _list_yqfhsandian.Add(kdfh1);*/



            SanDian zdhmsd2 = new SanDian(new int[3, 3]{
	            {   69,   11, 0xa4a789},
	            {   69,   15, 0xb9b6a1},
	            {   79,   10, 0x494d52},
            });
            FuHeSanDian zdhmfh2 = new FuHeSanDian("引导-战斗手动开", zdhmsd2, 71, 14);
            _list_yqsandian.Add(zdhmsd2);
            _list_yqfhsandian.Add(zdhmfh2);

            SanDian zdhmsd3 = new SanDian(new int[3, 3]{
	            {   49,    9, 0xe3ddbd},
	            {   47,   17, 0xfffbd6},
	            {   41,   18, 0xdad7d2},
            });
            FuHeSanDian zdhmfh3 = new FuHeSanDian("引导-战斗1倍速", zdhmsd3, 44, 11);
            _list_yqsandian.Add(zdhmsd3);
            _list_yqfhsandian.Add(zdhmfh3);

            SanDian zdhmsd4 = new SanDian(new int[3, 3]{
	            {  186,  183, 0xefb294},
	            {  188,  195, 0xefb294},
	            {  240,  213, 0xff9b5c},
            });
            FuHeSanDian zdhmfh4 = new FuHeSanDian("引导-战斗介绍1", zdhmsd4, 505, 272);
            _list_yqsandian.Add(zdhmsd4);
            _list_yqfhsandian.Add(zdhmfh4);

            SanDian zdhmsd5 = new SanDian(new int[3, 3]{
	            {  304,  188, 0xe9b394},
	            {  356,  201, 0xffbd91},
	            {  389,  214, 0xff5952},
            });
            FuHeSanDian zdhmfh5 = new FuHeSanDian("引导-战斗介绍2", zdhmsd5, 505, 272);
            _list_yqsandian.Add(zdhmsd5);
            _list_yqfhsandian.Add(zdhmfh5);

            SanDian zdhmsd6 = new SanDian(new int[3, 3]{
	            {  371,  148, 0xefb294},
	            {  424,  170, 0xffc59d},
	            {  508,  157, 0xff731e},
            });
            FuHeSanDian zdhmfh6 = new FuHeSanDian("引导-战斗介绍3", zdhmsd6, 505, 272);
            _list_yqsandian.Add(zdhmsd6);
            _list_yqfhsandian.Add(zdhmfh6);

            SanDian zdhmsd7 = new SanDian(new int[3, 3]{
	            {  410,  243, 0xc5b798},
	            {  410,  261, 0xd5c5b6},
	            {  301,   45, 0x84959c},
            });
            FuHeSanDian zdhmfh7 = new FuHeSanDian("引导-战斗介绍4", zdhmsd7, 505, 272);
            _list_yqsandian.Add(zdhmsd7);
            _list_yqfhsandian.Add(zdhmfh7);

            SanDian zdhmsd8 = new SanDian(new int[3, 3]{
	            {  169,  119, 0xefb294},
	            {  292,  132, 0xff9f64},
	            {  359,  131, 0x51e1ff},
            });
            FuHeSanDian zdhmfh8 = new FuHeSanDian("引导-战斗介绍5", zdhmsd8, 359, 131);
            _list_yqsandian.Add(zdhmsd8);
            _list_yqfhsandian.Add(zdhmfh8);

            SanDian zdhmsd9 = new SanDian(new int[3, 3]{
	            {  409,  245, 0x84a4b3},
	            {  410,   89, 0x58ebff},
	            {  356,  213, 0x312b2b},
            });
            FuHeSanDian zdhmfh9 = new FuHeSanDian("引导-战斗介绍6", zdhmsd9, 506, 276);
            _list_yqsandian.Add(zdhmsd9);
            _list_yqfhsandian.Add(zdhmfh9);

            new1 = new SanDian(new int[3, 3]{
	            {  337,  156, 0xffd338},
	            {  328,  129, 0x6c3b0e},
	            {  349,  128, 0xe5ba44},
            });
            new2 = new FuHeSanDian("引导-第一关领取宝箱", new1, 338, 156);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);
            _dict.Add(new2.Name, new2);

            new1 = new SanDian(new int[3, 3]{
	            {  370,  196, 0xefb294},
	            {  424,  215, 0x746f69},
	            {  417,  262, 0xecd2bc},
            });
            new2 = new FuHeSanDian("引导-战斗介绍8", new1, 506, 276);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);
            _dict.Add(new2.Name, new2);

            new1 = new SanDian(new int[3, 3]{
	            {  336,  196, 0xefb294},
	            {  447,  214, 0xff8c45},
	            {  442,  234, 0xff8439},
            });
            new2 = new FuHeSanDian("引导-第一关角色升级", new1, 396, 276);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  218,  111, 0xefb294},
	            {  215,  130, 0xefb294},
	            {  371,  121, 0xffae00},
            });
            new2 = new FuHeSanDian("引导-第一关角色升级第二步", new1, 267, 276);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

           /* new1 = new SanDian(new int[3, 3]{
	            {  408,  253, 0xf9dec7},
	            {  410,  217, 0xbeb4ad},
	            {  352,  216, 0x1c1818},
            });
            new2 = new FuHeSanDian("引导-战斗画面女人单打", new1, 360, 135);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);*/

            new1 = new SanDian(new int[3, 3]{
	            {   96,  105, 0xefb294},
	            {  197,  120, 0xff8c45},
	            {  212,  129, 0xffcba7},
            });
            new2 = new FuHeSanDian("引导-核心技光头对话", new1, 239, 243);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  252,  180, 0xbfa190},
	            {  320,  193, 0xffcaa4},
	            {  314,   76, 0xffdb73},
            });
            new2 = new FuHeSanDian("引导-核心技光头对话2", new1, 239, 243);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  373,  211, 0xedb396},
	            {  323,  159, 0xe7a618},
	            {  489,  233, 0xff680d},
            });
            new2 = new FuHeSanDian("引导-第一关关底领宝箱", new1, 325, 160);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  371,   92, 0xefb294},
	            {  375,  130, 0xad2c11},
	            {  514,   96, 0xffb823},
            });
            new2 = new FuHeSanDian("引导-第二关开启", new1, 312, 101);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);


            new1 = new SanDian(new int[3, 3]{
	            {   27,   15, 0x1053ae},
	            {   52,    9, 0xe9e9e9},
	            {   58,   14, 0x020302},
            });
            new2 = new FuHeSanDian("引导-第二关无人区界面", new1, 312, 101);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  409,  232, 0x466d44},
	            {  406,  256, 0x9d7a68},
	            {  294,    9, 0xffd954},
            });
            new2 = new FuHeSanDian("引导-战斗画面骑士怒吼", new1, 508, 276);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	{  197,   91, 0x56edff},
	{  197,   92, 0x57e8ff},
	{  197,   93, 0x47e2ff},
});
            new2 = new FuHeSanDian("引导-无证骑士加载莉莉", new1, 197, 90);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	{  173,  131, 0x51e6ff},
	{  173,  132, 0x53dfff},
	{  173,  133, 0x4ae1ff},
});
            new2 = new FuHeSanDian("引导-无证骑士加载杰诺斯", new1, 171, 131);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);


            new1 = new SanDian(new int[3, 3]{
	            {  413,  241, 0xaba07f},
	            {  406,  259, 0xe6d5c5},
	            {  264,   92, 0x7a2617},
            });
            new2 = new FuHeSanDian("引导-战斗画面男人第二关", new1, 199, 92);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  126,   63, 0xefb294},
	            {  251,   81, 0xff8a42},
	            {   69,   15, 0xb9b6a1},
            });
            new2 = new FuHeSanDian("引导-自动战斗打开光头提示", new1);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  188,  172, 0xefb294},
	            {  272,  202, 0xff9f63},
	            {  332,  179, 0xffb10b},
            });
            new2 = new FuHeSanDian("引导-自动战斗集火光头提示", new1, 387, 184);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  147,  234, 0xecc443},
	            {  116,  242, 0xffd345},
	            {  275,  229, 0xdc5847},
            });
            new2 = new FuHeSanDian("引导-发现地底王", new1);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  103,  100, 0xeeb294},
	            {  188,  126, 0xff6c14},
	            {  260,  103, 0xffae0b},
            });
            new2 = new FuHeSanDian("引导-开启第二关的精英关卡", new1, 315, 109);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  367,  199, 0x9d8a7b},
	            {  452,  230, 0xff670d},
	            {  473,  229, 0xff924f},
            });
            new2 = new FuHeSanDian("引导-试试一拳通关", new1, 444, 276);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  359,  158, 0xecaa1b},
	            {  364,  128, 0x8f6120},
	            {  353,  129, 0xd6a935},
            });
            new2 = new FuHeSanDian("引导-第一精英关领取宝箱", new1, 359, 158);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  243,  147, 0xd64d29},
	            {  230,  139, 0xf7d739},
	            {  377,  165, 0x731010},
            });
            new2 = new FuHeSanDian("引导-地图事件触发", new1);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {   28,   10, 0xfa3e29},
	            {   82,    9, 0xd9d9d9},
	            {   31,   24, 0xc92c1e},
            });
            new2 = new FuHeSanDian("引导-判断地图界面", new1);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  321,  189, 0x604b13},
	            {  319,  177, 0x33d014},
	            {  325,  159, 0xc23001},
            });
            new2 = new FuHeSanDian("引导-加1倍速开启", new1);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {   16,  106, 0x5cd6d7},
	            {   93,  106, 0x64bd0d},
	            {   93,  115, 0xb8b7b7},
            });
            new2 = new FuHeSanDian("引导-第三章任务完成直接领", new1, 41, 116);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {   23,  105, 0x4ce1e8},
	            {   69,  117, 0xe7e7e7},
	            {   93,  119, 0xcfcfcf},
            });
            new2 = new FuHeSanDian("引导-任务领完继续背头侠", new1, 41, 116);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  244,  208, 0xd89f86},
	            {  329,  229, 0xff690f},
	            {  398,  201, 0xffae00},
            });
            new2 = new FuHeSanDian("引导-每日任务光头开启", new1, 308, 277);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {   21,  149, 0xa1d676},
	            {   27,  147, 0xa1d676},
	            {   87,  153, 0x81e207},
            });

            new2 = new FuHeSanDian("引导-日常已完成", new1, 42, 162);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	{   38,   10, 0xfd4029},
	{   45,   50, 0xf4ba15},
	{  442,  126, 0xffda25},
});

            new2 = new FuHeSanDian("引导-日常界面--领取", new1, 462, 124);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	{   49,   49, 0xf5bc17},
	{  440,  126, 0xff8623},
	{  507,    8, 0xffbe14},
});

            new2 = new FuHeSanDian("引导-日常界面--领取完毕--关闭", new1, 509, 8);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);


            new1 = new SanDian(new int[3, 3]{
	            {  105,   10, 0xadaa93},
	            {  101,   12, 0xbfc0a9},
	            {   98,   17, 0xe4e0cb},
            });
            new2 = new FuHeSanDian("引导-战斗中可跳过", new1, 97, 15);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {   45,  107, 0xe7b294},
	            {   97,  130, 0xff9859},
	            {  195,  117, 0xffae00},
            });
            new2 = new FuHeSanDian("引导-协会竞技光头", new1, 282, 117);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  243,  246, 0xe5b49a},
	            {  334,  259, 0xff9654},
	            {  395,  247, 0xffae00},
            });
            new2 = new FuHeSanDian("引导-协会竞技光头2", new1, 104, 156);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  369,  106, 0xebb392},
	            {  501,  127, 0x6d6863},
	            {  520,  109, 0xfab105},
            });
            new2 = new FuHeSanDian("引导-协会竞技光头3", new1, 295, 283);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  249,   61, 0xefb294},
	            {  314,   81, 0x504d4b},
	            {  388,  102, 0xffa608},
            });
            new2 = new FuHeSanDian("引导-协会竞技光头4", new1, 314, 161);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  280,   50, 0xefb294},
	            {  389,   67, 0x373736},
	            {  420,   94, 0xffab11},
            });
            new2 = new FuHeSanDian("引导-协会竞技光头5", new1, 460, 55);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  119,  221, 0xefb294},
	            {  255,  240, 0x76716b},
	            {  271,  223, 0xffad04},
            });
            new2 = new FuHeSanDian("引导-协会竞技光头6", new1, 310, 230);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);



            new1 = new SanDian(new int[3, 3]{
	            {   53,  106, 0xefb294},
	            {  122,  137, 0xff8438},
	            {  205,  109, 0xffae06},
            });
            new2 = new FuHeSanDian("引导-战斗失败出现光头", new1, 238, 186);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {   30,  206, 0xa48545},
	            {   40,  209, 0x6b4208},
	            {   38,  192, 0xcca744},
            });
            new2 = new FuHeSanDian("引导-战斗街道左侧的箱子", new1, 30, 207);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  440,   82, 0xefebde},
	            {  124,  218, 0xfb4420},
	            {  329,  149, 0x9a93c3},
            });
            new2 = new FuHeSanDian("引导-第四章孤高改造人", new1, 330, 239);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {   56,    9, 0xcd301f},
	            {   63,   19, 0x7a7c7a},
	            {  135,   30, 0xefaa00},
            });
            new2 = new FuHeSanDian("引导-第四章-通用剧情界面", new1);
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  491,  254, 0x90939d},
	            {  471,  280, 0x92909f},
	            {  517,  274, 0xa9a7b0},
            });
            new2 = new FuHeSanDian("引导-布阵卡死点", new1, 493, 279, "引导-与角色头像-强化开始一起用");
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            new1 = new SanDian(new int[3, 3]{
	            {  316,  148, 0xe0eaf8},
	            {  316,  160, 0x818b9a},
	            {  315,  110, 0xe67f7d},
            });
            new2 = new FuHeSanDian("引导-第四章剧情打红色蚊女", new1, 326, 134, "");
            _list_yqsandian.Add(new1);
            _list_yqfhsandian.Add(new2);

            //对话框
            SanDian dhsd1 = new SanDian(new int[3, 3]{
	            {  208,  228, 0xfffff7},
	            {  253,  230, 0xfffff7},
	            {  387,  227, 0xfffff7},
            });
            FuHeSanDian dhfh1 = new FuHeSanDian("引导-空白对话框", dhsd1, 434, 238);
            _list_yqsandian.Add(dhsd1);
            _list_yqfhsandian.Add(dhfh1);

            dhsd1 = new SanDian(new int[3, 3]{
	{  285,  255, 0xfdfdf5},
	{  461,  269, 0xffd74b},
	{  424,  252, 0xfdfdf5},
});
            dhfh1 = new FuHeSanDian("引导-空白对话框--疫苗人细框", dhsd1, 434, 238);
            _list_yqsandian.Add(dhsd1);
            _list_yqfhsandian.Add(dhfh1);



            dhsd1 = new SanDian(new int[3, 3]{
	            {  252,  278, 0xaeada9},
	            {  234,  279, 0xd5d4cf},
	            {  264,  279, 0xacaca8},
            });
            dhfh1 = new FuHeSanDian("引导-跳过", dhsd1, 498, 12);
            _list_yqsandian.Add(dhsd1);
            _list_yqfhsandian.Add(dhfh1);

            dhsd1 = new SanDian(new int[3, 3]{
	{  253,  143, 0xebb291},
	{  310,  178, 0xff7523},
	{  342,  179, 0xff6e17},
});
            dhfh1 = new FuHeSanDian("引导-经验饮料", dhsd1, 310, 98);
            _list_yqsandian.Add(dhsd1);
            _list_yqfhsandian.Add(dhfh1);









            //见到就关系列
            SanDian jdgsd1 = new SanDian(new int[3, 3]{
	            {  405,  281, 0x6bdb39},
	            {  460,  264, 0x6bd63e},
	            {  517,    9, 0xffca33},
            });
            FuHeSanDian jdgfh1 = new FuHeSanDian("引导-出现截屏保存", jdgsd1, 517, 9, "引导-怒吼骑士的保存屏幕");
            _list_yqsandian.Add(jdgsd1);
            _list_yqfhsandian.Add(jdgfh1);



            SanDian jdgsd3 = new SanDian(new int[3, 3]{
	            {  217,  118, 0x697fd0},
	            {  276,  119, 0x139895},
	            {  283,  188, 0x5683e2},
            });
            FuHeSanDian jdgfh3 = new FuHeSanDian("引导-掌趣窗口", jdgsd3, 376, 58);
            _list_yqsandian.Add(jdgsd3);
            _list_yqfhsandian.Add(jdgfh3);

            SanDian jdgsd4 = new SanDian(new int[3, 3]{
	            {  428,  239, 0xffdb21},
	            {  206,   94, 0xfe626c},
	            {  450,  114, 0xf0d02a},
            });
            FuHeSanDian jdgfh4 = new FuHeSanDian("引导-章节任务回放", jdgsd4, 468, 44);
            _list_yqsandian.Add(jdgsd4);
            _list_yqfhsandian.Add(jdgfh4);



            SanDian jdgsd5 = new SanDian(new int[3, 3]{
	{   96,  189, 0xffda24},
	{  103,  198, 0x421801},
	{  124,  196, 0x502e12},
});
            FuHeSanDian jdgfh5 = new FuHeSanDian("引导-一拳通关一次", jdgsd5, 120, 196);
            _list_yqsandian.Add(jdgsd5);
            _list_yqfhsandian.Add(jdgfh5);


             jdgsd5 = new SanDian(new int[3, 3]{
	            {   97,   46, 0x310a08},
	            {  182,   44, 0xc3c5c3},
	            {  425,   50, 0xffae00},
            });
             jdgfh5 = new FuHeSanDian("引导-一拳通关关闭", jdgsd5, 443, 50);
            _list_yqsandian.Add(jdgsd5);
            _list_yqfhsandian.Add(jdgfh5);
            
            jdgsd5 = new SanDian(new int[3, 3]{
	{  315,  138, 0x027bc3},
	{  160,   90, 0xc13525},
	{  296,  210, 0xffda25},
});
            jdgfh5 = new FuHeSanDian("引导-一拳通关出现钻石--3次关闭", jdgsd5);
            _list_yqsandian.Add(jdgsd5);
            _list_yqfhsandian.Add(jdgfh5);



            SanDian jdgsd6 = new SanDian(new int[3, 3]{
	            {  494,   12, 0x949fa2},
	            {  499,   13, 0x889296},
	            {  512,   13, 0x90999d},
            });
            FuHeSanDian jdgfh6 = new FuHeSanDian("引导-右上角的跳过", jdgsd6, 512, 13);
            _list_yqsandian.Add(jdgsd6);
            _list_yqfhsandian.Add(jdgfh6);

            //任务系列
            SanDian rwsd1 = new SanDian(new int[3, 3]{
	            {   27,  105, 0x44c9d5},
	            {   23,  104, 0x46cfda},
	            {   13,  105, 0x3eb3c3},
            });
            FuHeSanDian rwfh1 = new FuHeSanDian("引导-有主线任务", rwsd1, 35, 119, "引导-排除红色拳头的乱跑");
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
            FuHeSanDian rwfh3 = new FuHeSanDian("引导-领取关卡宝箱", rwsd3, 280, 189);
            _list_yqsandian.Add(rwsd3);
            _list_yqfhsandian.Add(rwfh3);

            SanDian rwsd4 = new SanDian(new int[3, 3]{
	            {   47,   22, 0x000100},
	            {  366,  239, 0xffcf1a},
	            {  194,   87, 0xf5616b},
            });
            FuHeSanDian rwfh4 = new FuHeSanDian("引导-开始第三章任务", rwsd4, 338, 240);
            _list_yqsandian.Add(rwsd4);
            _list_yqfhsandian.Add(rwfh4);

            SanDian rwsd5 = new SanDian(new int[3, 3]{
	            {  379,   50, 0x82a9bf},
	            {  519,    5, 0xac0000},
	            {  407,  266, 0xf3801f},
            });
            FuHeSanDian rwfh5 = new FuHeSanDian("引导-协会竞技", rwsd5, 379, 50);
            _list_yqsandian.Add(rwsd5);
            _list_yqfhsandian.Add(rwfh5);

            List<ZuoBiao> ydlist4 = new List<ZuoBiao>();
            ydlist4.Add(new ZuoBiao(422, 256, 0xe2c13f));
            SanDian rwsd6 = new SanDian(new int[3, 3]{
	            {  405,  253, 0x6d4d17},
	            {  102,   73, 0xb67e17},
	            {   54,   31, 0xb72a1d},
            });
            FuHeSanDian rwfh6 = new FuHeSanDian("引导-协会竞技一键领取", rwsd6, 415, 77, "", ydlist4);
            _list_yqsandian.Add(rwsd6);
            _list_yqfhsandian.Add(rwfh6);

            SanDian rwsd61 = new SanDian(new int[3, 3]{
	            {  434,   75, 0xb5b6b5},
	            {  120,   32, 0xa52421},
	            {   89,   81, 0xefae08},
            });
            FuHeSanDian rwfh61 = new FuHeSanDian("引导-协会竞技一键领取可以关闭", rwsd61, 467, 40, "", ydlist4);
            _list_yqsandian.Add(rwsd61);
            _list_yqfhsandian.Add(rwfh61);


            SanDian rwsd62 = new SanDian(new int[3, 3]{
	            {   94,  139, 0xf7bc17},
	            {   51,   37, 0xa32321},
	            {  151,  201, 0xad18b5},
            });
            FuHeSanDian rwfh62 = new FuHeSanDian("引导-协会竞技一键领取可以关闭-再次打开", rwsd62, 467, 40);
            _list_yqsandian.Add(rwsd62);
            _list_yqfhsandian.Add(rwfh62);

            SanDian rwsd7 = new SanDian(new int[3, 3]{
	            {   29,  147, 0x7c7142},
	            {   13,  147, 0xbfab64},
	            {   59,  149, 0xcab66b},
            });
            FuHeSanDian rwfh7 = new FuHeSanDian("引导-钉头锤特定点", rwsd7, 44, 152);
            _list_yqsandian.Add(rwsd7);
            _list_yqfhsandian.Add(rwfh7);

            SanDian rwsd71 = new SanDian(new int[3, 3]{
	            {  148,  136, 0xefb294},
	            {  268,  168, 0xff9655},
	            {  264,  198, 0xffae00},
            });
            FuHeSanDian rwfh71 = new FuHeSanDian("引导-钉头锤光头提示", rwsd71, 44, 152);
            _list_yqsandian.Add(rwsd71);
            _list_yqfhsandian.Add(rwfh71);

            SanDian rwsd72 = new SanDian(new int[3, 3]{
	            {  151,  149, 0xefb294},
	            {  305,  154, 0xffae00},
	            {  259,  174, 0x68635f},
            });
            FuHeSanDian rwfh72 = new FuHeSanDian("引导-钉头锤光头提示2", rwsd72, 44, 152);
            _list_yqsandian.Add(rwsd72);
            _list_yqfhsandian.Add(rwfh72);

            SanDian rwsd73 = new SanDian(new int[3, 3]{
	            {  147,  167, 0xefb294},
	            {  288,  195, 0xff7a29},
	            {  299,  173, 0xffae07},
            });
            FuHeSanDian rwfh73 = new FuHeSanDian("引导-钉头锤光头提示3", rwsd73, 39, 179);
            _list_yqsandian.Add(rwsd73);
            _list_yqfhsandian.Add(rwfh73);

            SanDian rwsd74 = new SanDian(new int[3, 3]{
	            {  153,  169, 0xefb594},
	            {  276,  188, 0x8f887f},
	            {  306,  175, 0xffae04},
            });
            FuHeSanDian rwfh74 = new FuHeSanDian("引导-钉头锤光头提示4", rwsd74, 39, 179);
            _list_yqsandian.Add(rwsd74);
            _list_yqfhsandian.Add(rwfh74);

            SanDian rwsd75 = new SanDian(new int[3, 3]{
	            {  137,   28, 0xfdc875},
	            {  369,   61, 0xa17154},
	            {  360,  230, 0xfeb73c},
            });
            FuHeSanDian rwfh75 = new FuHeSanDian("引导-获得钉头锤", rwsd75);
            _list_yqsandian.Add(rwsd75);
            _list_yqfhsandian.Add(rwfh75);

            SanDian rwsd76 = new SanDian(new int[3, 3]{
	            {   19,  147, 0xc0ab64},
	            {   35,  148, 0xa79454},
	            {   58,  150, 0xf3dd87},
            });
            FuHeSanDian rwfh76 = new FuHeSanDian("引导-获得钉头锤后支线任务判断", rwsd76);
            _list_yqsandian.Add(rwsd76);
            _list_yqfhsandian.Add(rwfh76);

            SanDian rwsd8 = new SanDian(new int[3, 3]{
	            {  424,  200, 0xa28009},
	            {   69,  107, 0xefae08},
	            {  473,  160, 0xa72f31},
            });
            FuHeSanDian rwfh8 = new FuHeSanDian("引导-剧情任务第四章未解锁", rwsd8, 517, 7);
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
	{  433,   42, 0xaf781d},
	{  247,  143, 0xebb291},
	{  225,  181, 0xd22610},
});
            FuHeSanDian qhfh1 = new FuHeSanDian("第一次升级", qhsd1, 311, 98);
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
            FuHeSanDian qhfh3 = new FuHeSanDian("角色头像-养成角色可关闭", qhsd3, 513, 10);
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
            FuHeSanDian qhfh41 = new FuHeSanDian("角色头像-养成角色经验可用", qhsd41, 313, 103);
            _list_yqsandian.Add(qhsd41);
            _list_yqfhsandian.Add(qhfh41);

            SanDian qhsd5 = new SanDian(new int[3, 3]{
	            {  403,  263, 0xffcf1a},
	            {  367,  263, 0x290f00},
	            {  311,   60, 0x63cf1b},
            });
            FuHeSanDian qhfh5 = new FuHeSanDian("角色头像-徽章缺少", qhsd5, 375, 265);
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
            FuHeSanDian qhfh6 = new FuHeSanDian("角色头像-徽章获取仅前往", qhsd6, 444, 50);
            _list_yqsandian.Add(qhsd6);
            _list_yqfhsandian.Add(qhfh6);

            SanDian qhsd7 = new SanDian(new int[3, 3]{
	            {  392,   96, 0xf4d232},
	            {  338,   95, 0xfffbef},
	            {  103,   45, 0xb52821},
            });
            FuHeSanDian qhfh7 = new FuHeSanDian("角色头像-徽章获取有一拳", qhsd7, 444, 50);
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
            FuHeSanDian qhfh8 = new FuHeSanDian("引导-角色头像-出现光头", qhsd8, -1, -1, "引导-一拳通关的光头", jstx1);
            _list_yqsandian.Add(qhsd8);
            _list_yqfhsandian.Add(qhfh8);
            //界面系列
            SanDian jmsd1 = new SanDian(new int[3, 3]{
	            {  346,   11, 0xefcc21},
	            {  150,   30, 0xf8bf4a},
	            {  508,  294, 0xf6c200},
            });
            FuHeSanDian jmfh1 = new FuHeSanDian("引导-主界面", jmsd1);
            _list_yqsandian.Add(jmsd1);
            _list_yqfhsandian.Add(jmfh1);

            SanDian jmsd2 = new SanDian(new int[3, 3]{
	            {   40,   17, 0xf73f29},
	            {  282,   13, 0x2cd4fe},
	            {  509,  270, 0xffc53e},
            });
            FuHeSanDian jmfh2 = new FuHeSanDian("引导-背包界面", jmsd2);
            _list_yqsandian.Add(jmsd2);
            _list_yqfhsandian.Add(jmfh2);

            SanDian jmsd3 = new SanDian(new int[3, 3]{
	            {   49,   17, 0x932e2f},
	            {   69,   18, 0x888b97},
	            {  131,   31, 0xbb7d08},
            });
            FuHeSanDian jmfh3 = new FuHeSanDian("引导-跳过的剧情界面", jmsd3);
            _list_yqsandian.Add(jmsd3);
            _list_yqfhsandian.Add(jmfh3);

            SanDian jmsd31 = new SanDian(new int[3, 3]{
	            {   43,   13, 0x822e2a},
	            {   54,   20, 0xa42f28},
	            {  498,   12, 0xb2babf},
            });
            FuHeSanDian jmfh31 = new FuHeSanDian("引导-跳过的剧情界面3章", jmsd31, 499, 13);
            _list_yqsandian.Add(jmsd31);
            _list_yqfhsandian.Add(jmfh31);


            SanDian jmsd4 = new SanDian(new int[3, 3]{
	{   25,   11, 0x1096e0},
	{  102,   29, 0xebb291},
	{  296,   75, 0xf32906},
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
            FuHeSanDian lqfh1 = new FuHeSanDian("引导-领取新手指引", lqsd1, 396, 48);
            _list_yqsandian.Add(lqsd1);
            _list_yqfhsandian.Add(lqfh1);

            /*SanDian lqsd2 = new SanDian(new int[3, 3]{
	            {  269,   55, 0xfffbf7},
	            {  378,   35, 0xffffef},
	            {  342,  249, 0xffcf1b},
            });
            FuHeSanDian lqfh2 = new FuHeSanDian("引导-领取新手指引关闭", lqsd2, 378, 37);
            _list_yqsandian.Add(lqsd2);
            _list_yqfhsandian.Add(lqfh2);*/

            SanDian lqsd3 = new SanDian(new int[3, 3]{
	            {  357,   43, 0x96471c},
	            {  352,   45, 0xedd29d},
	            {  370,   38, 0xefa4a1},
            });
            FuHeSanDian lqfh3 = new FuHeSanDian("引导-领取8日登录", lqsd3);
            _list_yqsandian.Add(lqsd3);
            _list_yqfhsandian.Add(lqfh3);

            SanDian lqsd4 = new SanDian(new int[3, 3]{
	            {  395,   48, 0x7756ad},
	            {  407,   37, 0xe74d4a},
	            {  402,   48, 0x5c2d15},
            });
            FuHeSanDian lqfh4 = new FuHeSanDian("引导-领取登录有礼", lqsd4);
            _list_yqsandian.Add(lqsd4);
            _list_yqfhsandian.Add(lqfh4);

            SanDian lqsd41 = new SanDian(new int[3, 3]{
	            {  409,   77, 0xcd4430},
	            {  463,  126, 0xf7efe7},
	            {  466,  254, 0xa93526},
            });
            FuHeSanDian lqfh41 = new FuHeSanDian("引导-领取登录有礼的关闭", lqsd41, 484, 56);
            _list_yqsandian.Add(lqsd41);
            _list_yqfhsandian.Add(lqfh41);


            SanDian lqsd42 = new SanDian(new int[3, 3]{
	            {  485,   39, 0xf7efe7},
	            {  426,  236, 0xffffff},
	            {  327,  252, 0xd65cf7},
            });
            FuHeSanDian lqfh42 = new FuHeSanDian("引导-领取登录有礼sr后出现的新关闭", lqsd42, 484, 40);
            _list_yqsandian.Add(lqsd42);
            _list_yqfhsandian.Add(lqfh42);

           /* SanDian lqsd5 = new SanDian(new int[3, 3]{
	            {  358,   46, 0x7a2214},
	            {  358,   39, 0xebd114},
	            {  362,   50, 0x705645},
            });
            FuHeSanDian lqfh5 = new FuHeSanDian("引导-领取忍者特训", lqsd5);
            _list_yqsandian.Add(lqsd5);
            _list_yqfhsandian.Add(lqfh5);*/

            SanDian lqsd6 = new SanDian(new int[3, 3]{
	            {   55,  246, 0xad290e},
	            {   49,  242, 0xfefbf2},
	            {   61,  241, 0x962f2a},
            });
            FuHeSanDian lqfh6 = new FuHeSanDian("引导-领取邮件", lqsd6, 56, 246);
            _list_yqsandian.Add(lqsd6);
            _list_yqfhsandian.Add(lqfh6);

            SanDian lqsd7 = new SanDian(new int[3, 3]{
	            {  398,   45, 0xd5d1c6},
	            {  396,   35, 0xf3eeb7},
	            {  406,   36, 0xe7494a},
            });
            FuHeSanDian lqfh7 = new FuHeSanDian("引导-领取次日登录", lqsd7, 397, 41);
            _list_yqsandian.Add(lqsd7);
            _list_yqfhsandian.Add(lqfh7);


            //特定的点 例如背包
           /* SanDian tdsd1 = new SanDian(new int[3, 3]{
	            {  394,  274, 0xefeff1},
	            {  388,  286, 0xedecee},
	            {  386,  265, 0x58b045},
            });
            FuHeSanDian tdfh1 = new FuHeSanDian("引导-主界面特定点背包", tdsd1, 391, 282);
            _list_yqsandian.Add(tdsd1);
            _list_yqfhsandian.Add(tdfh1);*/

            //数字截屏
            SanDian szsd1 = new SanDian(new int[3, 3]{
	            {  342,   72, 0xd6aa9c},
	            {  359,   55, 0x7b4d9c},
	            {  396,   58, 0xb04ad3},
            });
            FuHeSanDian szfh1 = new FuHeSanDian("引导-背包里的强者券", szsd1);
            _list_yqsandian.Add(szsd1);
            _list_yqfhsandian.Add(szfh1);
        }
        /// <summary>
        /// 单例模式====双层互锁
        /// </summary>
        /// <returns></returns>
        public static YiQuanZhiTuo_SanDian GetObject()
        {
            if (yqsd == null)
            {
                lock (obj)
                {
                    if (yqsd == null)
                    {
                        yqsd = new YiQuanZhiTuo_SanDian();
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
        public Dictionary<String, FuHeSanDian> getYiQuanDict()
        {
            return _dict;
        }
    }
}
