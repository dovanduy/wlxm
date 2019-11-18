using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using xDM;

namespace fuzhu1
{
    public class Luneng_SanDian
    {
        #region 单例模式变量
        private static readonly object obj = new object();
        private static Luneng_SanDian yqsd = null;
        #endregion
        private Luneng_SanDian()
        {

        }

        private static List<ZuoBiao> _list_zuobiao = new List<ZuoBiao>();

        public static List<ZuoBiao> List_zuobiao
        {
            get { return Luneng_SanDian._list_zuobiao; }
            set { Luneng_SanDian._list_zuobiao = value; }
        }


        private static List<SanDian> _list_yqsandian = new List<SanDian>();

        public static List<SanDian> List_yqsandian
        {
            get { return Luneng_SanDian._list_yqsandian; }
            set { Luneng_SanDian._list_yqsandian = value; }
        }


        private static List<FuHeSanDian> _list_yqfhsandian = new List<FuHeSanDian>();

        public static List<FuHeSanDian> List_yqfhsandian
        {
            get { return Luneng_SanDian._list_yqfhsandian; }
            set { Luneng_SanDian._list_yqfhsandian = value; }
        }


        

        static Luneng_SanDian()
        {
            SanDian ktsd1 = new SanDian(new int[3, 3]{
	            {   90,  177, 0xf7d9c6},
	            {   32,  361, 0x8e8dff},
	            {  640,  333, 0xa4a1dc},
            });
            FuHeSanDian ktfh1 = new FuHeSanDian("存账号-系统加载中", ktsd1);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  391,  168, 0x00aa78},
	            {  404,  168, 0x00aa78},
	            {  485,  123, 0xffcb3c},
            });
            ktfh1 = new FuHeSanDian("存账号-16.1M更新", ktsd1, 400, 228);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {   90,  177, 0xf7d9c6},
	            {   32,  361, 0x8e8dff},
	            {  640,  333, 0xa4a1dc},
            });
            ktfh1 = new FuHeSanDian("存账号-开头动画跳过", ktsd1);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            List<ZuoBiao> yk=new List<ZuoBiao>();
            yk.Add(new ZuoBiao(201,  294, 0xfeffff));
            ktsd1 = new SanDian(new int[3, 3]{
	            {  334,  327, 0x80bcf2},
	            {  409,  327, 0x9ecbf5},
	            {  294,  288, 0x4aa2e0},
            });
            ktfh1 = new FuHeSanDian("特殊存账号-游客登录选择", ktsd1, 248, 327, "点完协议点游客248,  327, 0x42cb40", yk);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            yk = new List<ZuoBiao>();
            ktsd1 = new SanDian(new int[3, 3]{
	            {  432,  238, 0x4099fa},
	            {  266,  234, 0x228afc},
	            {  312,  157, 0x010101},
            });
            ktfh1 = new FuHeSanDian("特殊存账号-出现保存信息", ktsd1, 423, 236);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            yk = new List<ZuoBiao>();
            ktsd1 = new SanDian(new int[3, 3]{
	            {  347,  226, 0x1082fe},
	            {  340,  230, 0x1c87fd},
	            {  367,  164, 0x000000},
            });
            ktfh1 = new FuHeSanDian("特殊存账号-保存成功提示", ktsd1, 341, 227);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            yk = new List<ZuoBiao>();
            ktsd1 = new SanDian(new int[3, 3]{
	            {  171,   66, 0x63efff},
	            {  124,   46, 0x59f0fc},
	            {  156,   54, 0xf7db56},
            });
            ktfh1 = new FuHeSanDian("存账号-出现公告信息", ktsd1, 662, 232);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            yk = new List<ZuoBiao>();
            ktsd1 = new SanDian(new int[3, 3]{
	            {  269,  122, 0x41384b},
	            {  377,  320, 0xffde4e},
	            {  222,  258, 0xe70286},
            });
            ktfh1 = new FuHeSanDian("登录-出现选服信息", ktsd1, 342, 326);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            yk = new List<ZuoBiao>();
            ktsd1 = new SanDian(new int[3, 3]{
	            {  158,   38, 0x7d6f2b},
	            {  435,   77, 0x009a00},
	            {  482,   78, 0xde3863},
            });
            ktfh1 = new FuHeSanDian("选区-选区界面", ktsd1);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            yk = new List<ZuoBiao>();
            ktsd1 = new SanDian(new int[3, 3]{
	            {  406,  302, 0xd301ab},
	            {  412,  296, 0xd301ab},
	            {  457,  308, 0x515172},
            });
            ktfh1 = new FuHeSanDian("选区-1号服", ktsd1,453,308);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            yk = new List<ZuoBiao>();
            ktsd1 = new SanDian(new int[3, 3]{
	            {  663,   15, 0xff3094},
	            {  548,   25, 0x9eb389},
	            {  412,  125, 0x99effa},
            });
            ktfh1 = new FuHeSanDian("选区-起名", ktsd1, 342, 326);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            yk = new List<ZuoBiao>();
            ktsd1 = new SanDian(new int[3, 3]{
	            {  612,   17, 0xe7e7ff},
	            {  578,   16, 0xe5e5fd},
	            {  656,   19, 0xe7e7ff},
            });
            ktfh1 = new FuHeSanDian("跳过-出现跳过信息", ktsd1, 661, 23);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            yk = new List<ZuoBiao>();
            ktsd1 = new SanDian(new int[3, 3]{
	            {  634,   25, 0xfefefe},
	            {  622,   19, 0xfcfcfc},
	            {  665,   21, 0x31a6e7},
            });
            ktfh1 = new FuHeSanDian("跳过-出现跳过信息2", ktsd1, 638, 23);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            yk = new List<ZuoBiao>();
            ktsd1 = new SanDian(new int[3, 3]{
	            {  400,  225, 0xffe35a},
	            {  286,  224, 0xffda42},
	            {  487,  121, 0xffcb39},
            });
            ktfh1 = new FuHeSanDian("跳过-是否跳过是", ktsd1, 395, 224);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            yk = new List<ZuoBiao>();
            ktsd1 = new SanDian(new int[3, 3]{
	            {   29,  365, 0x47426f},
	            {  554,   29, 0x101810},
	            {  605,  139, 0x333933},
            });
            ktfh1 = new FuHeSanDian("任务-出现来电", ktsd1, 583, 250);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            
        }
        /// <summary>
        /// 单例模式====双层互锁
        /// </summary>
        /// <returns></returns>
        public static Luneng_SanDian GetObject()
        {
            if (yqsd == null)
            {
                lock (obj)
                {
                    if (yqsd == null)
                    {
                        yqsd = new Luneng_SanDian();
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
    }
}
