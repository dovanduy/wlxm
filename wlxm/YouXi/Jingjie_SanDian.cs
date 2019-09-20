using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using xDM;

namespace fuzhu
{
    public class Jingjie_SanDian
    {
        #region 单例模式变量
        private static readonly object obj = new object();
        private static Jingjie_SanDian yqsd = null;
        #endregion
        private Jingjie_SanDian()
        {

        }

        private static List<ZuoBiao> _list_zuobiao = new List<ZuoBiao>();

        public static List<ZuoBiao> List_zuobiao
        {
            get { return Jingjie_SanDian._list_zuobiao; }
            set { Jingjie_SanDian._list_zuobiao = value; }
        }


        private static List<SanDian> _list_yqsandian = new List<SanDian>();

        public static List<SanDian> List_yqsandian
        {
            get { return Jingjie_SanDian._list_yqsandian; }
            set { Jingjie_SanDian._list_yqsandian = value; }
        }


        private static List<FuHeSanDian> _list_yqfhsandian = new List<FuHeSanDian>();

        public static List<FuHeSanDian> List_yqfhsandian
        {
            get { return Jingjie_SanDian._list_yqfhsandian; }
            set { Jingjie_SanDian._list_yqfhsandian = value; }
        }


        

        static Jingjie_SanDian()
        {
            SanDian ktsd1 = new SanDian(new int[3, 3]{
	            {  237,   62, 0xf1f1f1},
	            {  196,   60, 0xfff200},
	            {  500,  320, 0xcec50a},
            });
            FuHeSanDian ktfh1 = new FuHeSanDian("特殊存账号-新号首界面", ktsd1, 466, 320);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  345,  246, 0xc68341},
	            {  347,  183, 0xc7838a},
	            {  477,  117, 0x9fb8df},
            });
            ktfh1 = new FuHeSanDian("特殊存账号-用户下载", ktsd1, 337, 244, "准备下载更新");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  184,   66, 0x949399},
	            {  471,  258, 0xfff400},
	            {  249,  318, 0xfbfca5},
            });
            ktfh1 = new FuHeSanDian("特殊存账号-用户名密码界面", ktsd1, 351, 260,"此界面要保存账号密码");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  371,  262, 0xfff400},
	            {  251,  320, 0xf3e902},
	            {  510,   67, 0xe0d706},
            });
            ktfh1 = new FuHeSanDian("特殊存账号-用户名密码重新录", ktsd1, 351, 260, "此界面要重新录入");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  494,   69, 0x77787c},
	            {  366,  308, 0x76777b},
	            {  366,  266, 0xb4b030},
            });
            ktfh1 = new FuHeSanDian("存账号-跳过绑定手机", ktsd1,497,66);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  387,   52, 0xfff400},
	            {  379,  109, 0xc3c3c6},
	            {  366,  318, 0xb4b030},
            });
            ktfh1 = new FuHeSanDian("存账号-跳过实名认证", ktsd1, 475, 52);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  209,   33, 0xfaf0e2},
	            {  371,  104, 0xde911b},
	            {  513,   25, 0xf8e8d2},
            });
            ktfh1 = new FuHeSanDian("存账号-不再弹出掏钱", ktsd1, 513, 25);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  106,  162, 0xedc892},
	            {  361,   71, 0x000000},
	            {  587,   69, 0x51588e},
            });
            ktfh1 = new FuHeSanDian("存账号-关闭公告", ktsd1, 587, 69);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  624,  241, 0xeeccaa},
	            {  177,   38, 0x555c99},
	            {  588,  334, 0xffc86d},
            });
            ktfh1 = new FuHeSanDian("存账号-关闭公告3", ktsd1, 587, 69);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  317,  300, 0xf8f9fa},
	            {  317,  305, 0xf8f9fa},
	            {  353,  302, 0xd1d3de},
            });
            ktfh1 = new FuHeSanDian("选区-当前为1区", ktsd1, 617, 298,"暂时不用这个标记");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {   27,   17, 0x6dbeff},
	            {  649,   13, 0x6f788f},
	            {  399,   85, 0xe6ae80},
            });
            ktfh1 = new FuHeSanDian("选区-服务器选区界面", ktsd1,-1,-1,"当前为87,141");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  256,   99, 0xbfe5fb},
	            {  256,  105, 0xb7dcf3},
	            {  182,  101, 0xfb2827},
            });
            ktfh1 = new FuHeSanDian("选区-服务器选1区", ktsd1, 293,106);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  641,   10, 0xc1d0e0},
	            {  641,   14, 0xb1c8e3},
	            {  656,   13, 0xb6c8d8},
            });
            ktfh1 = new FuHeSanDian("游戏-跳过", ktsd1, 646, 14);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {   14,   12, 0x97b0e3},
	            {  316,   10, 0xcdd8ed},
	            {  362,  333, 0x565f88},
            });
            ktfh1 = new FuHeSanDian("特殊游戏-开始战斗", ktsd1, -1, -1,"跳出存账号循环");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {   25,   14, 0x66aaee},
	            {  118,   10, 0xd6f2fd},
	            {   92,   13, 0xd3effb},
            });
            ktfh1 = new FuHeSanDian("特殊游戏-进入任务", ktsd1, -1, -1, "跳出存账号循环");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  372,  265, 0xb4b030},
	            {  224,  318, 0xf1e703},
	            {  507,  318, 0xfbf001},
            });
            ktfh1 = new FuHeSanDian("登录-输入账号", ktsd1, 336, 267, "跳出存账号循环");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            //需要更正的
            ktsd1 = new SanDian(new int[3, 3]{
	            {  381,  269, 0xb4b030},
	            {  182,  321, 0xc8c988},
	            {  507,  321, 0xfff600},
            });
            ktfh1 = new FuHeSanDian("特殊存账号-新号首界面2", ktsd1, 477, 68);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  345,  246, 0xc68341},
	            {  347,  183, 0xc7838a},
	            {  477,  117, 0x9fb8df},
            });
            ktfh1 = new FuHeSanDian("特殊存账号-用户下载2", ktsd1, 337, 244, "准备下载更新");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  332,  265, 0x737373},
	            {  487,  323, 0xc7be0b},
	            {  510,   67, 0xc8c10b},
            });
            ktfh1 = new FuHeSanDian("特殊存账号-用户名密码重新录2", ktsd1, 351, 260, "此界面要重新录入");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  241,   74, 0xd2d2d5},
	            {  264,  190, 0x23252d},
	            {  317,  263, 0xb4b030},
            });
            ktfh1 = new FuHeSanDian("存账号-跳过绑定手机2", ktsd1, 497, 66);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  462,   50, 0x939299},
	            {  384,  315, 0xb4b030},
	            {  277,   53, 0xfbf300},
            });
            ktfh1 = new FuHeSanDian("存账号-跳过实名认证2", ktsd1, 475, 52);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  507,   30, 0xfefaf4},
	            {  496,   28, 0xdc932d},
	            {  160,   41, 0xcdcdcc},
            });
            ktfh1 = new FuHeSanDian("存账号-不再弹出掏钱2", ktsd1, 513, 25);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  587,   67, 0x526295},
	            {  390,   68, 0x030303},
	            {  105,  162, 0xe3bf90},
            });
            ktfh1 = new FuHeSanDian("存账号-关闭公告2", ktsd1, 587, 69);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{   55,   55, 0xe8231e},
	{  557,   28, 0xdce8fa},
	{  671,   31, 0x3f496f},
});
            ktfh1 = new FuHeSanDian("选区-出现进入游戏", ktsd1, 617, 298);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {   23,   17, 0x68bcfe},
	            {  638,   14, 0xaecff9},
	            {  393,   57, 0xb2b8c4},
            });
            ktfh1 = new FuHeSanDian("选区-服务器选区界面2", ktsd1, -1, -1, "当前为87,141");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  256,  105, 0xa5c7df},
	            {  256,  101, 0xa6c9e3},
	            {   25,   10, 0x508fe3},
            });
            ktfh1 = new FuHeSanDian("选区-服务器选1区2", ktsd1, 293, 106);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);


            ktsd1 = new SanDian(new int[3, 3]{
	{  343,   90, 0x1eb9ee},
	{  392,  152, 0x8cbf1f},
	{  386,  206, 0xe99200},
});
            ktfh1 = new FuHeSanDian("登录-选择登录注册", ktsd1, 346, 204, "344,  256 ");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  344,   75, 0x7ad5f5},
	{  257,  252, 0x1eb9ee},
	{  364,  305, 0xea9200},
});
            ktfh1 = new FuHeSanDian("登录-注册账号", ktsd1, 425, 142, "434,  225, 0x1eb9ee");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  342,   88, 0x1eb9ee},
	{  281,  250, 0x1eaee0},
	{  268,  196, 0x959595},
});
            ktfh1 = new FuHeSanDian("登录-登录账号", ktsd1, 346, 251, "434,  225, 0x1eb9ee");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  442,  211, 0x1eb0e3},
	{  334,  280, 0x96c62d},
	{  442,  279, 0xf39800},
});
            ktfh1 = new FuHeSanDian("登录-登录账号2", ktsd1, 346, 225, "368,  229, 0x1daddf");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  430,  208, 0x8bbe1e},
	{  430,  258, 0x1daddf},
	{  256,  156, 0x707070},
});
            ktfh1 = new FuHeSanDian("登录-选择新账号", ktsd1, 346, 261);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  206,  197, 0xf8b551},
	{  208,  231, 0xf8b551},
	{  180,  138, 0xe79941},
});
            ktfh1 = new FuHeSanDian("登录-实名认证", ktsd1, 258, 291);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  576,  211, 0xeeccaa},
	{  613,  256, 0xbf7788},
	{  575,   47, 0x555699},
});
            ktfh1 = new FuHeSanDian("登录-公告", ktsd1, 588, 68);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  621,  301, 0xa6d1de},
	{  664,   24, 0xffffff},
	{   46,   53, 0xd6535d},
});
            ktfh1 = new FuHeSanDian("登录-进入游戏", ktsd1, 622, 306, "选区 429,  303 ");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  276,  358, 0xfa2625},
	{  360,  357, 0xf7d34a},
	{  444,  357, 0x52ed94},
});
            ktfh1 = new FuHeSanDian("选区-选区界面", ktsd1,-1,-1," 84, 140");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  250,  100, 0xc1e6fc},
	{  250,  105, 0xc1e6fc},
	{  259,  102, 0x9bbcd8},
});
            ktfh1 = new FuHeSanDian("选区-选区界面中的1区", ktsd1, 283, 103);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);











            //新加的
           // ktsd1 = new SanDian(new int[3, 3]{
	         //   {   29,  360, 0x6b93df},
	        //    {   82,   13, 0xa3b9cc},
            //{   22,   17, 0x68bdfe},
            //});
            //ktfh1 = new FuHeSanDian("引导-关闭角色界面", ktsd1, 642, 15);
            //_list_yqsandian.Add(ktsd1);
            //_list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  117,   11, 0xd0ebf7},
	{  329,   14, 0xa52501},
	{  421,   14, 0xc09551},
});
            ktfh1 = new FuHeSanDian("界面-关卡界面", ktsd1, -1, -1, "截图");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {   22,   26, 0xecc2b2},
	            {  327,   14, 0xf5c9a7},
	            {  480,  359, 0x6e6e97},
            });
            ktfh1 = new FuHeSanDian("界面-主界面", ktsd1,-1,-1,"邮件661 173 福利 569 48");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{   67,  339, 0x3f60a8},
	{  112,  337, 0x3555a6},
	{   47,   55, 0xd7e4e8},
});
            ktfh1 = new FuHeSanDian("邮件-搞邮件", ktsd1, 185, 335, "一键领取");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {   36,   41, 0xd9a177},
	            {  422,   14, 0xe3b76e},
	            {  646,   44, 0xf1c362},
            });
            ktfh1 = new FuHeSanDian("福利-升级有礼", ktsd1, 111, 195, "  471,  161, 0xc48141  470,  244, 0xc38545  642,   43");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);


            ktsd1 = new SanDian(new int[3, 3]{
	            {   24,  212, 0xe17539},
	            {   48,  202, 0xb6b7c0},
	            {  648,   13, 0xc5d8f7},
            });
            ktfh1 = new FuHeSanDian("引导-第一次出现花", ktsd1, 645, 12);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  187,  206, 0xfe9435},
	            {  130,  193, 0xfcdf68},
	            {  290,  294, 0x21284a},
            });
            ktfh1 = new FuHeSanDian("引导-主线3-3", ktsd1, 206, 241);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  323,  105, 0xb3cafb},
	            {  299,  101, 0xbbd2f7},
	            {  383,  108, 0xa7c3f7},
            });
            ktfh1 = new FuHeSanDian("引导-获取物品", ktsd1, 359, 360);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);


            ktsd1 = new SanDian(new int[3, 3]{
	{   75,   86, 0xe77539},
	{  419,   67, 0xffe46f},
	{  190,   69, 0xffd55d},
});
            ktfh1 = new FuHeSanDian("引导-停在角色界面四个角色", ktsd1, 649, 12);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  444,  252, 0xce964a},
	            {  483,  110, 0xaecdd9},
	            {  509,   84, 0x664520},
            });
            ktfh1 = new FuHeSanDian("特殊引导-上阵人数不足", ktsd1, 283, 250);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  572,  173, 0xf3c9a9},
	{  508,   83, 0xffab4e},
	{  566,   86, 0xe1763c},
});
            ktfh1 = new FuHeSanDian("特殊引导-第五个人数", ktsd1, -1, -1);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  633,   41, 0xa3b8e3},
	{  148,   80, 0xffccaa},
	{  495,   84, 0xf06395},
});
            ktfh1 = new FuHeSanDian("特殊引导-第3天送啥", ktsd1, 287, 317);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);


            ktsd1 = new SanDian(new int[3, 3]{
	{  280,  101, 0xb0c0cb},
	{  135,  193, 0xf9e380},
	{  569,  171, 0x577db7},
});
            ktfh1 = new FuHeSanDian("引导-明日登录送第3天送啥", ktsd1, 600, 126);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);


            ktsd1 = new SanDian(new int[3, 3]{
	{  371,  157, 0xfe9634},
	{  304,  291, 0xffeb83},
	{  450,   58, 0xbababa},
});
            ktfh1 = new FuHeSanDian("引导-关卡3-5", ktsd1, 373, 191);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  295,   96, 0xdee4ef},
	{  211,  251, 0x709fec},
	{  470,  247, 0xbbd0e5},
});
            ktfh1 = new FuHeSanDian("特殊引导-战斗失败", ktsd1, 350, 365);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  370,  240, 0xd6c7b5},
	{  501,  250, 0xa49f5a},
	{  473,   48, 0xfe9435},
});
            ktfh1 = new FuHeSanDian("引导-进入精英关卡", ktsd1, 645, 353);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{   80,  188, 0xf7e3cf},
	{  203,  199, 0xcebf49},
	{  170,  134, 0x000810},
});
            ktfh1 = new FuHeSanDian("引导-进入精英关卡1", ktsd1, 170, 130);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{   72,    8, 0x90a4b6},
	{  452,  247, 0xf8d8c6},
	{  572,  338, 0xe2e2e3},
});
            ktfh1 = new FuHeSanDian("引导-进入精英关卡1开始", ktsd1, 641, 337);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  473,  129, 0xe7d747},
	{  390,  126, 0x292829},
	{  188,  117, 0xffba52},
});
            ktfh1 = new FuHeSanDian("引导-精英关获得材料", ktsd1, 648, 14);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  143,  276, 0x292829},
	{  194,  271, 0xb0a84c},
	{  276,  279, 0xe6d543},
});
            ktfh1 = new FuHeSanDian("引导-黑猫提示获得材料", ktsd1, 648, 14);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  180,  148, 0xd1c3bb},
	{  311,  227, 0x010911},
	{  561,  356, 0x213356},
});
            ktfh1 = new FuHeSanDian("引导-精英关卡2或打普通关卡", ktsd1, 564, 350);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  304,  111, 0xfbf2c3},
	            {  341,  198, 0x4ccac1},
	            {  414,  269, 0xc59a51},
            });
            ktfh1 = new FuHeSanDian("引导-明天送10抽", ktsd1, 508, 114);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  635,  362, 0xffffff},
	            {  341,   69, 0xdb3d58},
	            {  352,  278, 0xd5e0de},
            });
            ktfh1 = new FuHeSanDian("引导-单个对话无跳过", ktsd1, 388, 367);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  149,  293, 0x435074},
	{  353,  301, 0xa6aab0},
	{  636,  362, 0xffffff},
});
            ktfh1 = new FuHeSanDian("引导-单个对话无跳过2", ktsd1, 388, 367);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  303,  274, 0x292829},
	{  375,  273, 0xcac055},
	{  354,  274, 0xcbbd45},
});
            ktfh1 = new FuHeSanDian("引导-黑猫角色再次加强", ktsd1, 482, 363);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  138,   78, 0xffeeaf},
	{  354,  355, 0xac562f},
	{  621,   54, 0xb99f80},
});
            ktfh1 = new FuHeSanDian("引导-首充送礼", ktsd1, 621, 55);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  469,  101, 0x1e242c},
	{  367,  192, 0xffe372},
	{  522,  189, 0x4a2818},
});
            ktfh1 = new FuHeSanDian("引导-关卡3-6", ktsd1, 467, 97);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  448,   90, 0xffeb84},
	{  534,  204, 0x000810},
	{  581,  289, 0x4a2818},
});
            ktfh1 = new FuHeSanDian("特殊引导-关卡3-7", ktsd1, 646, 14);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  369,  193, 0xffe984},
	{  517,  190, 0x000810},
	{  463,  104, 0x000810},
});
            ktfh1 = new FuHeSanDian("特殊引导-关卡3-6", ktsd1, 646, 14,"小人在3-6");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);


            ktsd1 = new SanDian(new int[3, 3]{
	{  436,  109, 0xffd963},
	{  420,  177, 0xffee84},
	{   42,  349, 0x4d7ede},
});
            ktfh1 = new FuHeSanDian("引导-战斗胜利3", ktsd1, 325, 357);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{   42,  260, 0xf03143},
	{   34,  271, 0x5a6caa},
	{  102,  364, 0xffffd6},
});
            ktfh1 = new FuHeSanDian("引导-关卡一件领取", ktsd1, 34, 274);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  344,  318, 0xb87c3e},
	{  318,   50, 0x62839a},
	{  381,   52, 0x689eca},
});
            ktfh1 = new FuHeSanDian("引导-关卡一件领取2", ktsd1, 344, 315);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  302,  317, 0xce9a5a},
	{  367,  316, 0xd19c5f},
	{  540,   51, 0xbcd8fa},
});
            ktfh1 = new FuHeSanDian("引导-关卡一件领取3", ktsd1, 339, 314);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  418,   12, 0xddb45f},
	{  513,   15, 0xcaeff5},
	{  638,   15, 0xa6c8ff},
});
            ktfh1 = new FuHeSanDian("特殊引导-关卡界面关闭", ktsd1, 645, 13);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  272,  150, 0xacb5bf},
	{  427,  153, 0xfefefe},
	{  343,  186, 0xddb26f},
});
            ktfh1 = new FuHeSanDian("特殊引导-账号被顶", ktsd1, 347, 185);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  104,  192, 0xfee06f},
	{  278,  290, 0x000810},
	{  208,  255, 0x000810},
});
            ktfh1 = new FuHeSanDian("引导-关卡3-3..2", ktsd1, 203, 252);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  387,  129, 0x292829},
	{  475,  126, 0xfae641},
	{  475,  141, 0xf5f6f8},
});
            ktfh1 = new FuHeSanDian("引导-黑猫精英关卡2", ktsd1, 646, 11);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  222,  181, 0xffe8dd},
	{  372,  144, 0x353838},
	{  217,  320, 0xff878c},
});
            ktfh1 = new FuHeSanDian("引导-8日送礼3", ktsd1, 569, 61);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  559,  338, 0xc67942},
	{  351,  143, 0xf9f7f5},
	{  553,   77, 0x6a85c7},
});
            ktfh1 = new FuHeSanDian("引导-送礼得ssr", ktsd1, 338, 354);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  484,   45, 0xf8d2c1},
	{  486,   38, 0xeecbbf},
	{  480,   54, 0xab6421},
});
            ktfh1 = new FuHeSanDian("特殊引导-首充不打开", ktsd1, 338, 354);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  168,  219, 0x496957},
	{  291,  244, 0xb8b155},
	{  363,  185, 0xe4c1b0},
});
            ktfh1 = new FuHeSanDian("引导-得sr任意位置返回", ktsd1, 355, 369);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  337,  203, 0x47536f},
	{  333,  174, 0x293454},
	{  591,  305, 0x5e74b3},
});
            ktfh1 = new FuHeSanDian("特殊引导-空邮箱返回", ktsd1, 645, 15);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);


            ktsd1 = new SanDian(new int[3, 3]{
	{  584,   94, 0xf1ca86},
	{   55,  106, 0xfee38b},
	{  255,  345, 0xeaba6b},
});
            ktfh1 = new FuHeSanDian("界面-集结石界面", ktsd1, 645, 15);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  249,  317, 0x30a976},
	{  260,  317, 0x2c8d66},
	{  291,  332, 0xed2e3e},
});
            ktfh1 = new FuHeSanDian("特殊引导-集结石中免费", ktsd1, 242, 341);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  638,   15, 0xa6c8ff},
	{  656,   21, 0xa7bbda},
	{  511,   13, 0xaad2fc},
});
            ktfh1 = new FuHeSanDian("特殊引导-右上角关闭钮集结石", ktsd1, 645, 15);
            //_list_yqsandian.Add(ktsd1);
            //_list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  355,  266, 0x3a4ea8},
	{  466,  235, 0xb5c1d9},
	{  411,  117, 0x406a9b},
});
            ktfh1 = new FuHeSanDian("引导-关闭购买集结石", ktsd1, 458, 116);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  426,  251, 0xca8f45},
	{  292,  250, 0x3857ac},
	{  364,  158, 0xa9acb6},
});
            ktfh1 = new FuHeSanDian("引导-不降低分辨率", ktsd1, 280, 252);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  447,  104, 0x040a14},
	{  352,  191, 0xfcd666},
	{  518,  188, 0x492a1c},
});
            ktfh1 = new FuHeSanDian("特殊引导-关卡3-6第二次", ktsd1, 461, 97,"小人在第3-6");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  471,   87, 0xc56672},
	{  356,  190, 0xffce69},
	{  519,  190, 0x4a2818},
});
            ktfh1 = new FuHeSanDian("特殊引导-关卡3-6第3次", ktsd1, 461, 97, "小人在第3-6");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  249,  117, 0xffddc9},
	{  521,  169, 0xd8b9fe},
	{  507,  299, 0xc3e7ff},
});
            ktfh1 = new FuHeSanDian("引导-关闭领取提示露琪亚", ktsd1, 586, 135);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  548,  194, 0xdc707a},
	{  448,   90, 0xffeb84},
	{  579,  289, 0x000810},
});
            ktfh1 = new FuHeSanDian("特殊引导-关卡3-7第二次", ktsd1, 534, 197, "小人在第3-7");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{   27,  281, 0xf7c8ae},
	{   27,  100, 0xe37539},
	{   31,  156, 0x363736},
});
            ktfh1 = new FuHeSanDian("界面-角色界面有5人", ktsd1, 643, 13, "有5个人物时间停超过6s则关");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  372,   60, 0xc0d1f8},
	{   32,  360, 0xb5d1f1},
	{   26,   18, 0x6dc3ff},
});
            ktfh1 = new FuHeSanDian("界面-角色强化", ktsd1);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  548,  342, 0xbe9f7d},
	{  581,  344, 0xcf9449},
	{  525,  351, 0xce8f48},
});
            ktfh1 = new FuHeSanDian("强化-装束界面的一键强化", ktsd1,554,343);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);


            ktsd1 = new SanDian(new int[3, 3]{
	{  520,  190, 0xffcb65},
	{  547,  193, 0x040a14},
	{  342,  355, 0xde9070},
});
            ktfh1 = new FuHeSanDian("特殊引导-主关卡3-8", ktsd1,595,302);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  605,  304, 0x000810},
	{  520,  190, 0xffca63},
	{  474,   91, 0xffd55d},
});
            ktfh1 = new FuHeSanDian("特殊引导-主关卡3-8-2次", ktsd1, 595, 302);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{   48,  280, 0x674777},
	{  149,   48, 0xb5deed},
	{  160,   67, 0xb2e4fb},
});
            ktfh1 = new FuHeSanDian("引导-获得sr", ktsd1,375,367);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  241,  228, 0xd94e71},
	{  230,   97, 0xf9d8a2},
	{  466,  231, 0xabe4fc},
});
            ktfh1 = new FuHeSanDian("特殊引导-体力终结", ktsd1, 499, 104);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  305,  290, 0xffeb85},
	{  222,  241, 0xffe37a},
	{  132,  192, 0xfdd06a},
});
            ktfh1 = new FuHeSanDian("关卡-3消耗体力", ktsd1,-1,-1,"取点已经完成3-3，3-2,3-1");
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  488,  340, 0x3860b1},
	{  663,   55, 0xfcda63},
	{  498,  178, 0xab2a02},
});
            ktfh1 = new FuHeSanDian("关卡-3具体消耗界面", ktsd1);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  222,   81, 0xf8e4b6},
	{  427,  116, 0xbd489b},
	{  469,  186, 0xf7b65f},
});
            ktfh1 = new FuHeSanDian("引导-幸运娃娃机", ktsd1,549,112);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);


            ktsd1 = new SanDian(new int[3, 3]{
	{   20,  366, 0xbfc8d8},
	{  318,  377, 0x40bd51},
	{  318,  381, 0xfae03c},
});
            ktfh1 = new FuHeSanDian("引导-战斗打开自动", ktsd1, 24, 362);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);


            ktsd1 = new SanDian(new int[3, 3]{
	{   28,  331, 0xa9bcd5},
	{  318,  377, 0x40bd51},
	{  318,  381, 0xfae03c},
});
            ktfh1 = new FuHeSanDian("引导-战斗打开X2", ktsd1, 24, 327);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  318,  377, 0x40bd51},
	{  391,  376, 0x3cb84d},
	{  318,  382, 0xffde3b},
});
            ktfh1 = new FuHeSanDian("界面-战斗界面", ktsd1);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{   49,   51, 0x218982},
	{   50,  106, 0x218a83},
	{   48,  363, 0x2e4467},
});
            ktfh1 = new FuHeSanDian("界面-角色界面", ktsd1,649,15);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  113,  132, 0xb8e1fc},
	{  536,  321, 0xb2cff2},
	{  229,  325, 0xf5f1ef},
});
            ktfh1 = new FuHeSanDian("特殊引导-领取满月礼", ktsd1,415,278);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  292,  211, 0xad414a},
	{  291,  225, 0xf7f7f7},
	{  276,  284, 0xd9c3b4},
});
            ktfh1 = new FuHeSanDian("特殊引导-8天3选1", ktsd1, 633, 38);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  251,   41, 0x6f7ef4},
	{  341,   92, 0xec765d},
	{  160,   93, 0xffccaa},
});
            ktfh1 = new FuHeSanDian("特殊引导-2天送礼", ktsd1, 295, 319);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  337,  201, 0x37c1b2},
	{  458,  229, 0x112255},
	{  265,  274, 0xce4859},
});
            ktfh1 = new FuHeSanDian("引导-2天送礼后提醒", ktsd1, 508, 113);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);


            ktsd1 = new SanDian(new int[3, 3]{
	{  392,  160, 0x4c5580},
	{  270,  132, 0xeabd9d},
	{  568,  293, 0xecfdff},
});
            ktfh1 = new FuHeSanDian("引导-1天送礼后提醒", ktsd1, 599, 128);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  347,  197, 0x216e74},
	{  481,  297, 0x6bccfd},
	{  173,  261, 0x222d55},
});
            ktfh1 = new FuHeSanDian("引导-1天送礼后提醒2", ktsd1, 509, 114);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  129,  219, 0xbb8aee},
	{  317,  133, 0xff444a},
	{  544,  267, 0xeaf3fb},
});
            ktfh1 = new FuHeSanDian("引导-版本热点", ktsd1, 551, 112);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	{  539,   47, 0xef6349},
	{  502,   83, 0xe54466},
	{  155,   84, 0xffccaa},
});
            ktfh1 = new FuHeSanDian("特殊引导-2天送礼2", ktsd1, 291, 321);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            //志拓
            ktsd1 = new SanDian(new int[3, 3]{
	            {  152,   88, 0xffc559},
	            {  130,  191, 0xffaa52},
	            {   78,    9, 0xd5f1fc}
            });
            FuHeSanDian ss = new FuHeSanDian("引导-主关卡1-1", ktsd1, 164, 123);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);


            ktsd1 = new SanDian(new int[3, 3]{
	            {  237,  137, 0xffc559},
	            {  487,  332, 0x595959},
	            {  557,  336, 0xefefef},
            });
            ss = new FuHeSanDian("引导-主关卡--挑战", ktsd1, 633, 335);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  641,   13, 0xa9c2de},
	{  657,   13, 0xbdc9dd},
	{  670,   13, 0xcbcdce},
            });
            ss = new FuHeSanDian("引导-跳过1", ktsd1, 649, 12);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  667,   13, 0xcee1e2},
	{  672,   13, 0xd8dee1},
	{  636,  372, 0xd1d4d7},
            });
            ss = new FuHeSanDian("引导-跳过1.1", ktsd1, 649, 12);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	          {  297,  219, 0xffaa4a},
	{  563,  280, 0xfaffff},
	{  591,  382, 0xffffff},
            });
            ss = new FuHeSanDian("引导-发大招", ktsd1, 568, 342);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  637,   13, 0xc1d6ea},
	{  665,   13, 0xccdce5},
	{  670,   13, 0xced8dd},
            });
            ss = new FuHeSanDian("引导-跳过2", ktsd1, 649, 12);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  637,   13, 0xc1cfde},
	{  665,   13, 0xcbd5db},
	{  670,   13, 0xced3d5},
            });
            ss = new FuHeSanDian("引导-跳过3", ktsd1, 649, 12);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  637,   13, 0xbfcddd},
	{  665,   13, 0xc9d1d7},
	{  670,   13, 0xcccdce},
            });
            ss = new FuHeSanDian("引导-跳过4", ktsd1, 649, 12);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  665,   13, 0xcad7e1},
	{  670,   13, 0xccd4d9},
	{  636,  362, 0xffffff},
            });
            ss = new FuHeSanDian("引导-跳过5", ktsd1, 649, 12);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	          {  664,   13, 0xbfcfcf},
	{  670,   13, 0xd0d0d0},
	{  636,  372, 0xc9cdd2},
            });
            ss = new FuHeSanDian("引导-跳过6", ktsd1, 649, 12);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);


            ktsd1 = new SanDian(new int[3, 3]{
	         {  664,   13, 0xc8dada},
	{  670,   13, 0xd9dbdc},
	{  636,  371, 0xe0e4e7},
            });
            ss = new FuHeSanDian("引导-跳过7", ktsd1, 649, 12);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	        {  664,   13, 0xc4d8d6},
	{  670,   13, 0xd6d8d6},
	{  636,  372, 0xd5d8db},

            });
            ss = new FuHeSanDian("引导-跳过8", ktsd1, 649, 12);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  387,  230, 0xf7d3c6},
	{  415,  237, 0xfefdfd},
	{  640,  265, 0xfbfefd},

            });
            ss = new FuHeSanDian("引导-拥有死神之力", ktsd1, 642, 347);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);


            ktsd1 = new SanDian(new int[3, 3]{
	            {  444,  105, 0xffe784},
	{  518,  103, 0xffef84},
	{  650,  110, 0xa72622},
            });
            ss = new FuHeSanDian("引导-战斗胜利1", ktsd1, 633, 335);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  440,  109, 0xffef8a},
	{  419,  174, 0xffba52},
	{  545,  131, 0xda4139},
            });
            ss = new FuHeSanDian("引导-战斗胜利2", ktsd1, 633, 335);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  290,   33, 0xf3ef9d},
	{  335,   40, 0xf7f4e1},
	{  510,   31, 0xffffff},
            });
            ss = new FuHeSanDian("引导-战队升级", ktsd1, 339, 191);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);


            ktsd1 = new SanDian(new int[3, 3]{
	            {  340,  188, 0xfe8a36},
	{  183,  135, 0xffd36d},
	{  531,  136, 0x4a2818},
            });
            ss = new FuHeSanDian("引导-主线关卡1-2", ktsd1, 337, 224);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);


            ktsd1 = new SanDian(new int[3, 3]{
	            {   19,   12, 0x53371b},
	{  269,  154, 0xe7efff},
	{  219,  221, 0xeaeefe},

            });
            ss = new FuHeSanDian("引导-对话", ktsd1, 633, 335);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  378,  285, 0xf9fbfd},
	            {  500,  271, 0xccc14d},
	            {  510,  270, 0xfeea40},
            });
            ss = new FuHeSanDian("引导-邀请朽木", ktsd1, 577, 358);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  236,  317, 0xe64839},
	{  251,   54, 0xfefafa},
	{  458,  315, 0xe94731},
            });
            ss = new FuHeSanDian("特殊引导-集结--购买1次", ktsd1, 239, 335);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  539,   81, 0x758fd8},
	{  439,  340, 0xfdeb86},
	{  595,  310, 0xccfbff},
            });
            ss = new FuHeSanDian("引导-招募到朽木", ktsd1, 406, 182);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  380,   86, 0xa6ebff},
	{  340,   82, 0xdff3fe},
	{  443,   95, 0x53aff7},
            });
            ss = new FuHeSanDian("引导-恭喜获得--朽木", ktsd1, 577, 358);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);


            ktsd1 = new SanDian(new int[3, 3]{
	            {  241,   51, 0xf9dfec},
	{   84,   15, 0xb1cada},
	{  666,   32, 0xedf6ff},
            });
            ss = new FuHeSanDian("引导-返回1", ktsd1, 648, 16);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  241,   51, 0xf9dfec},
	{   84,   15, 0xb1cada},
	{  663,   36, 0xffffff},
            });
            ss = new FuHeSanDian("引导-返回2", ktsd1, 648, 16);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {   65,   11, 0xcce7f3},
	{   84,   11, 0xc9e4f1},
	{  664,   34, 0xffffff},
            });
            ss = new FuHeSanDian("引导-返回3", ktsd1, 648, 16);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);
            
            ktsd1 = new SanDian(new int[3, 3]{
	            {  429,  270, 0xfff9f5},
	{  659,  373, 0xffffff},
	{  626,  382, 0xfcf982},
            });
            ss = new FuHeSanDian("引导-继续进行", ktsd1, 647, 348);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  157,  137, 0xffed82},
	{  321,  237, 0xffd974},
	{  551,   88, 0xffc559},
            });
            ss = new FuHeSanDian("引导-主线1-3", ktsd1, 532, 130);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	          {  414,  163, 0xfefdfd},
	{  592,  132, 0xffffff},
	{  608,  356, 0x8d1021},
            });
            ss = new FuHeSanDian("引导-布阵界面添加朽木", ktsd1, 575, 93);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	{  506,  179, 0xf7d7ce},
	{  509,  184, 0xedd7ca},
	{  536,  165, 0xbbc4e3},
});
            ktfh1 = new FuHeSanDian("引导-4角色上阵", ktsd1, 511, 171);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  506,  106, 0xf3f9f7},
	{  584,  109, 0xf3f7f4},
	{  609,  356, 0x8c1021},
            });
            ss = new FuHeSanDian("引导-都已上阵--开战", ktsd1, 567, 358);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {   59,   79, 0xfefbe4},
	{  135,   67, 0xfffbe7},
	{  195,   43, 0xefebe2},
            });
            ss = new FuHeSanDian("引导-boss出现", ktsd1, 577, 358);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  347,  252, 0xffffff},
	{  549,  365, 0xfae268},
	{  636,  279, 0xf2fcfe},
            });
            ss = new FuHeSanDian("引导-不要犹豫", ktsd1, 643, 350);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  340,  246, 0xfcfdfe},
	{  393,  257, 0xf2d3c1},
	{  623,  366, 0xfee978},
            });
            ss = new FuHeSanDian("引导-朽木放大招", ktsd1, 566, 346);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  433,   76, 0xf7f7f7},
	{   92,  108, 0xffffff},
	{   91,  149, 0xffc559},
            });
            ss = new FuHeSanDian("引导-主线2-1", ktsd1, 113, 193);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  312,  241, 0xc39a70},
	{  337,  264, 0xdfe6eb},
	{  563,  280, 0xf9ffff},
            });
            ss = new FuHeSanDian("引导-就这样打出去", ktsd1, 565, 349);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  521,  381, 0xfcdc4a},
	{  521,  382, 0xffda49},
	{  521,  382, 0xffda49},
            });
            ss = new FuHeSanDian("引导-位置3可放大招", ktsd1, 494, 347);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  594,  382, 0xffdc49},
	{  594,  381, 0xfcdf4b},
	{  594,  382, 0xffdc49},

            });
            ss = new FuHeSanDian("引导-位置2可放大招", ktsd1, 563, 340);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  667,  382, 0xffdb45},
	{  667,  381, 0xfcdd47},
	{  667,  382, 0xffdb45},
            });
            ss = new FuHeSanDian("引导-位置1可放大招", ktsd1, 640, 347);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  543,   76, 0x7491d7},
	{  457,  338, 0xffe06e},
	{  594,  311, 0xcefbff},
            });
            ss = new FuHeSanDian("引导-招募友", ktsd1, 393, 182);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  312,  249, 0x292829},
	{  310,  285, 0x292829},
	{  496,  347, 0xee3450},
            });
            ss = new FuHeSanDian("引导-角色升品功能开放", ktsd1, 484, 360);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);


            ktsd1 = new SanDian(new int[3, 3]{
	            {   52,   37, 0xef3042},
	{  623,   53, 0xf13243},
	{  515,  336, 0xc69142},
            });
            ss = new FuHeSanDian("引导-升品", ktsd1, 495, 347);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  301,   67, 0xf9f7b8},
	{  353,   75, 0xfef3df},
	{  421,   84, 0xefe793},
            });
            ss = new FuHeSanDian("引导-升品成功", ktsd1, 577, 358);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {   52,   91, 0xf23344},
	{   42,  126, 0xffffff},
	{  151,  240, 0xfcffff},
            });
            ss = new FuHeSanDian("引导-提高露琪亚", ktsd1, 28, 108);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {   51,   90, 0xf63a4b},
	{  622,   53, 0xf23344},
	{  464,  344, 0xc68642},
            });
            ss = new FuHeSanDian("引导-升品露琪亚", ktsd1, 496, 345);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {   52,   36, 0x0f3b37},
	{   52,   91, 0x164047},
	{  670,   56, 0xffffff},
            });
            ss = new FuHeSanDian("引导-升品返回", ktsd1, 642, 16);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  383,  251, 0xe7cbad},
	{  395,  292, 0xffc373},
	{  660,  368, 0xffffff},
            });
            ss = new FuHeSanDian("引导-击败修理卡", ktsd1, 644, 346);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  104,  193, 0xffdd6b},
	{  200,  251, 0xffc459},
	{  321,  201, 0x21284a},
            });
            ss = new FuHeSanDian("引导-主线2-2", ktsd1, 207, 283);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  436,  146, 0xe7cbad},
	{  653,  108, 0xffffff},
	{  605,  354, 0x811118},
            });
            ss = new FuHeSanDian("引导-上阵第三个人物", ktsd1, 644, 99);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {   30,  179, 0xe7cbad},
	{   86,  209, 0xe7edf7},
	{  315,  207, 0xcfd3e6},
            });
            ss = new FuHeSanDian("引导-提示拖动底板", ktsd1, 642, 16);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {   45,  202, 0xfec671},
	{  131,  221, 0xdd2d34},
	{  173,  220, 0xda2c32},
            });
            ss = new FuHeSanDian("互换位置", ktsd1);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  507,  106, 0xf3f8f7},
	{  575,  106, 0xf3f8f7},
	{  643,  106, 0xf3f8f7},
            });
            ss = new FuHeSanDian("引导-开战", ktsd1, 573, 361);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  132,  191, 0xffbc55},
	{  227,  287, 0xffd773},
	{  339,  158, 0xffc259},
            });
            ss = new FuHeSanDian("引导-主线2-3", ktsd1, 329, 203);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  198,  211, 0xf7d3c6},
	{  565,  324, 0x764f24},
	{  406,  338, 0xa89e5d},
            });
            ss = new FuHeSanDian("引导-超绝技能", ktsd1, 434, 340);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  349,  227, 0xfefeff},
	{  500,  315, 0xffffff},
	{  492,  364, 0x53fdff},
            });
            ss = new FuHeSanDian("使用超绝技能", ktsd1);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {   20,    9, 0xffaa52},
	{  286,  248, 0x272927},
	{  512,  379, 0xffffff},
            });
            ss = new FuHeSanDian("引导-角色升星", ktsd1, 482, 358);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {   46,  356, 0xf43e65},
	{   50,  385, 0xffffff},
	{   56,  384, 0xffffff},
            });
            ss = new FuHeSanDian("引导-角色预览", ktsd1, 29, 363);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	          {  386,  139, 0xf3f3ff},
	{  425,  148, 0x292829},
	{  667,  134, 0xffffff},
            });
            ss = new FuHeSanDian("引导-升星", ktsd1, 649, 113);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {   52,   36, 0xf33445},
	{  637,   97, 0xedba73},
	{  623,   96, 0xf13243},
            });
            ss = new FuHeSanDian("引导-升星激活", ktsd1, 546, 343);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  303,   43, 0xfff8b7},
	{  354,   48, 0xfff9ee},
	{  422,   61, 0xefeb94},
            });
            ss = new FuHeSanDian("引导-升星成功", ktsd1, 642, 16);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  384,   60, 0xfcfdfe},
	{  519,   66, 0xddcf48},
	{  660,   34, 0xffffff},
            });
            ss = new FuHeSanDian("引导-返回--主线关卡", ktsd1, 643, 11);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  199,  287, 0xffd870},
	{  320,  203, 0xffc059},
	{  439,   55, 0xffc15a},
            });
            ss = new FuHeSanDian("引导-主线2-4", ktsd1, 435, 111);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  636,  326, 0x392729},
	{  566,  325, 0xffaa4a},
	{  431,  382, 0xffffff},
            });
            ss = new FuHeSanDian("灵子剑雨", ktsd1);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  319,  204, 0xffdd78},
	{  418,  115, 0xffd965},
	{  579,  148, 0xffc359}
            });
            ss = new FuHeSanDian("引导-主线2-5", ktsd1, 565, 160);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  280,  152, 0xf0f3fa},
	{  226,  168, 0xd47034},
	{  576,  354, 0x30394a},
            });
            ss = new FuHeSanDian("引导-任意键继续", ktsd1, 642, 16);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  286,  250, 0x26282a},
	{  309,  283, 0x292829},
	{  500,  384, 0xffffff},
            });
            ss = new FuHeSanDian("引导-角色点击", ktsd1, 482, 355);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {   52,   36, 0xf33445},
	{  623,   54, 0xee3040},
	{  442,  236, 0xffffff},
            });
            ss = new FuHeSanDian("引导-升级--小白帽", ktsd1, 426, 212);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  111,  191, 0xfcfcfe},
	{  235,  207, 0xf4e242},
	{  372,  204, 0xf8e540},
            });
            ss = new FuHeSanDian("引导-黑猫提醒----升级界面", ktsd1, 296, 253);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {   53,   37, 0xef3342},
	{  623,   54, 0xee3040},
	{   46,  357, 0x92acca},

            });
            ss = new FuHeSanDian("特殊引导-升5级", ktsd1, 559, 342);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	          {   64,   12, 0xb7d0e1},
	{  421,   17, 0xb07e47},
	{  657,   42, 0xffffff},
            });
            ss = new FuHeSanDian("引导-返回", ktsd1, 646, 13);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  176,   43, 0xffc459},
	{  127,  153, 0xe5e5e5},
	{  362,  177, 0xf7f7f7}
            });
            ss = new FuHeSanDian("引导-主线3-1", ktsd1, 189, 110);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  188,   78, 0xf7cbad},
	{  173,  105, 0xffd862},
	{   95,  158, 0xffc559},
            });
            ss = new FuHeSanDian("引导-主线3-2", ktsd1, 111, 197);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  267,  269, 0xf1f5fa},
	{  292,  277, 0x4a4539},
	{  513,  378, 0xffffff},
            });
            ss = new FuHeSanDian("引导-角色---碎片合成", ktsd1, 483, 361);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);
            
            ktsd1 = new SanDian(new int[3, 3]{
	            {   92,  145, 0xffffff},
	            {  109,  216, 0xf4f5f6},
	            {  183,  215, 0xf3f7fb},
            });
            ss = new FuHeSanDian("引导-合成", ktsd1, 89, 121);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  349,  112, 0xed7d3c},
	{  543,   96, 0x4a5895},
	{  456,  337, 0xfada6a},
            });
            ss = new FuHeSanDian("引导-花出现", ktsd1, 89, 121);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  349,  112, 0xed7d3c},
	{  543,   96, 0x4a5895},
	{  456,  337, 0xfada6a},
            });
            ss = new FuHeSanDian("引导-4张图都有", ktsd1, 89, 121);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);


            ktsd1 = new SanDian(new int[3, 3]{
	            {   93,  172, 0xfca4ff},
	{  108,  204, 0xf5f8ff},
	{  182,  213, 0xfdfaf8},
            });
            ss = new FuHeSanDian("引导-介绍", ktsd1, 89, 121);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {   51,   35, 0xf6394b},
	{  638,  185, 0xe6b56e},
	{  476,  232, 0xffffde},
            });
            ss = new FuHeSanDian("引导-羁绊", ktsd1, 480, 228);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	          {  112,  192, 0xf3f5fe},
	{  157,  206, 0x292b29},
	{  174,  217, 0xffffff},
            });
            ss = new FuHeSanDian("引导-开启日常", ktsd1, 89, 121);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  681,  346, 0xfe3b42},
	{  662,  382, 0xffffff},
	{  677,  382, 0xffffff},
            });
            ss = new FuHeSanDian("引导-继续主线通关", ktsd1, 643, 348);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	          {  173,   70, 0xffc85d},
	{  121,  191, 0x4a2818},
	{  374,  190, 0x4a2818},
            });
            ss = new FuHeSanDian("引导-3-1", ktsd1, 179, 84);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  246,  127, 0xffc559},
	{  489,  332, 0x595959},
	{  580,  337, 0x5b5b5b},
            });
            ss = new FuHeSanDian("引导-挑战--竖手指", ktsd1, 641, 332);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {   98,  153, 0xffc559},
	{  341,  103, 0xf5f8ff},
	{  661,   34, 0xffffff},
            });
            ss = new FuHeSanDian("引导-返回--通关界面", ktsd1, 647, 11);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	             {   21,    8, 0xffaa52},
	            {  629,  379, 0xffffa6},
	            {  651,  336, 0x191d22},
            });
            ss = new FuHeSanDian("特殊引导-进击--目的开启每日奖励", ktsd1, 641, 344);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  499,  174, 0xf8d8cf},
	{  501,  174, 0xf5d8cd},
	{  504,  174, 0xf7d9ce},
            });
            ss = new FuHeSanDian("引导-上阵", ktsd1, 503, 172);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  497,  174, 0x27c3a5},
	{  504,  174, 0x21c4b4},
	{  504,  187, 0x50c2af},
            });
            ss = new FuHeSanDian("引导-已上阵---开战", ktsd1, 567, 361);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  498,  121, 0xfbd567},
	            {  666,  114, 0x21c7ad},
	            {  527,  174, 0x22bdab},
            });
            ss = new FuHeSanDian("引导-已上阵---开战2", ktsd1, 567, 361);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {   13,  363, 0xb4bfd8},
	{  130,  283, 0xffc373},
	{  181,  292, 0xd1c652},
            });
            ss = new FuHeSanDian("引导-自动战斗引导", ktsd1, 305, 324);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  112,  267, 0xffc36b},
	{  178,  272, 0xccbf43},
	{   40,  382, 0xffffff},
            });
            ss = new FuHeSanDian("引导-自动战斗开启", ktsd1, 17, 364);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  308,  267, 0x292829},
	{  339,  269, 0xfcf8f5},
	{  501,  383, 0xffffff},
            });
            ss = new FuHeSanDian("引导-角色装束开启", ktsd1, 480, 356);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {   69,   11, 0xb9d2e1},
	{  636,  180, 0xeffafd},
	{  669,  218, 0xffffff},
            });
            ss = new FuHeSanDian("引导-点击装束", ktsd1, 645, 199);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  623,  183, 0xee3040},
	{  440,   56, 0xf13243},
	{  623,  191, 0xe7be83},
            });
            ss = new FuHeSanDian("引导-一键强化", ktsd1, 534, 347);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  190,  232, 0xfcfcfe},
	{  232,  242, 0x292829},
	{  263,  239, 0x5374c8},
            });
            ss = new FuHeSanDian("引导-黑猫", ktsd1, 641, 344);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	             {   21,    8, 0xffaa52},
	            {  629,  379, 0xffffa6},
	            {  651,  336, 0x191d22},
            });
            ss = new FuHeSanDian("引导-强化完毕线返回----以后单独走角色模块", ktsd1, 647, 11);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	             {  195,  241, 0xffdc6f},
	{  283,  256, 0xffc459},
	{  369,  187, 0x4a2818},
            });
            ss = new FuHeSanDian("引导-主线3-4", ktsd1, 290, 286);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  633,   37, 0xd4e8f5},
	{  339,   41, 0x697bf1},
	{  268,  317, 0xbd7542},
            });
            ss = new FuHeSanDian("特殊引导-每日奖励开启----可以换号", ktsd1, 291, 324);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);

            ktsd1 = new SanDian(new int[3, 3]{
	           {  293,  183, 0x395aad},
	{  329,  148, 0xeaecf2},
	{  398,  186, 0xd6a151}
            });
            ss = new FuHeSanDian("引导-点击跳过过快造成---是否离开--取消", ktsd1, 268, 185);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ss);
        }
        /// <summary>
        /// 单例模式====双层互锁
        /// </summary>
        /// <returns></returns>
        public static Jingjie_SanDian GetObject()
        {
            if (yqsd == null)
            {
                lock (obj)
                {
                    if (yqsd == null)
                    {
                        yqsd = new Jingjie_SanDian();
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
            return _list_yqfhsandian.FindAll(f => f.Name.IndexOf(nameindex)==0
                );
        }

        public List<string> findListShiFouChongMing()
        {
            List<string> sr=new List<string>();
            foreach(FuHeSanDian s in _list_yqfhsandian){
                sr.Add(s.Name);
            }
            List<string> sr2=sr.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();
            return sr2;
        }
    }
}
