using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using xDM;

namespace fuzhu
{
    public class Jingjie_DuoDian
    {
        #region 单例模式变量
        private static readonly object obj = new object();
        private static Jingjie_DuoDian yqdd = null;
        #endregion
        private Jingjie_DuoDian() {
        
        }

        private static List<ZuoBiao> _list_zuobiao = new List<ZuoBiao>();

        public static List<ZuoBiao> List_zuobiao
        {
            get { return Jingjie_DuoDian._list_zuobiao; }
            set { Jingjie_DuoDian._list_zuobiao = value; }
        }


        private static List<DuoDianZhaoSe> _list_yqduodian = new List<DuoDianZhaoSe>();

        public static List<DuoDianZhaoSe> List_yqduodian
        {
            get { return Jingjie_DuoDian._list_yqduodian; }
            set { Jingjie_DuoDian._list_yqduodian = value; }
        }


        private static List<FuHeDuoDian> _list_yqfhduodian = new List<FuHeDuoDian>();

        public static List<FuHeDuoDian> List_yqfhduodian
        {
            get { return Jingjie_DuoDian._list_yqfhduodian; }
            set { Jingjie_DuoDian._list_yqfhduodian = value; }
        }


        static Jingjie_DuoDian()
        {
            DuoDianZhaoSe sz = new DuoDianZhaoSe(0xbed4e7, "-12|-2|0xc6daea,-18|5|0xadc4d9,-2|-4|0xa0b8ce,4|2|0x9cb5cf,11|0|0xc4d8d6,17|0|0xd6d8d6", 90, 617, 1, 678, 23);
            FuHeDuoDian sz1 = new FuHeDuoDian("跳过", sz, -1, -1);
            _list_yqduodian.Add(sz);
            _list_yqfhduodian.Add(sz1);
        }
        /// <summary>
        /// 单例模式====双层互锁
        /// </summary>
        /// <returns></returns>
        public static Jingjie_DuoDian GetObject()
        {
            if (yqdd == null)
            {
                lock (obj)
                {
                    if (yqdd == null)
                    {
                        yqdd = new Jingjie_DuoDian();
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
