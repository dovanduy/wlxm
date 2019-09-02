﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using xDM;

namespace fuzhu
{
    public class TongYong_SanDian
    {
        #region 单例模式变量
        private static readonly object obj = new object();
        private static TongYong_SanDian yqsd = null;
        #endregion
        private TongYong_SanDian()
        {
            SanDian ktsd1 = new SanDian(new int[3, 3]{
	            {  332,  164, 0xf4c51f},
	            {  178,  183, 0x9aa1a8},
	            { 1177,   15, 0x4a5e6f},
            });
            FuHeSanDian ktfh1 = new FuHeSanDian("雷电首页截图", ktsd1);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);

            ktsd1 = new SanDian(new int[3, 3]{
	            {  166,  105, 0xf4c51f},
	            {   91,   83, 0x4096e8},
	            {  469,   38, 0xcbcdd0},
            });
            ktfh1 = new FuHeSanDian("雷电首页截图-路人", ktsd1);
            _list_yqsandian.Add(ktsd1);
            _list_yqfhsandian.Add(ktfh1);
        }

        private static List<ZuoBiao> _list_zuobiao = new List<ZuoBiao>();

        public static List<ZuoBiao> List_zuobiao
        {
            get { return TongYong_SanDian._list_zuobiao; }
            set { TongYong_SanDian._list_zuobiao = value; }
        }


        private static List<SanDian> _list_yqsandian = new List<SanDian>();

        public static List<SanDian> List_yqsandian
        {
            get { return TongYong_SanDian._list_yqsandian; }
            set { TongYong_SanDian._list_yqsandian = value; }
        }


        private static List<FuHeSanDian> _list_yqfhsandian = new List<FuHeSanDian>();

        public static List<FuHeSanDian> List_yqfhsandian
        {
            get { return TongYong_SanDian._list_yqfhsandian; }
            set { TongYong_SanDian._list_yqfhsandian = value; }
        }


        private static Dictionary<string, FuHeSanDian> _dict = new Dictionary<string, FuHeSanDian>();

        public static Dictionary<string, FuHeSanDian> Dict
        {
            get { return _dict; }
            set { _dict = value; }
        }

        static TongYong_SanDian()
        {
            
        }
        /// <summary>
        /// 单例模式====双层互锁
        /// </summary>
        /// <returns></returns>
        public static TongYong_SanDian GetObject()
        {
            if (yqsd == null)
            {
                lock (obj)
                {
                    if (yqsd == null)
                    {
                        yqsd = new TongYong_SanDian();
                    }
                }
            }
            return yqsd;
        }
                
        public FuHeSanDian findFuHeSandianByName(string name)
        {
            return _list_yqfhsandian.Find(f => name.Equals(f.Name)
                );
        }

        public Dictionary<String,FuHeSanDian> getYiQuanDict()
        {
            return  _dict;
        }
    }
}