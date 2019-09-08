using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class YunXingQK
    {
        private int _xh;

        public int Xh
        {
            get { return _xh; }
            set { _xh = value; }
        }
        private Dictionary<string, JiQiYunXing> _jqyx;

        public Dictionary<string, JiQiYunXing> Jqyx
        {
            get { return _jqyx; }
            set { _jqyx = value; }
        }
        private int _zuanshidayu0;

        public int Zuanshidayu0
        {
            get { return _zuanshidayu0; }
            set { _zuanshidayu0 = value; }
        }
        private int _qiangzhedayu0;

        public int Qiangzhedayu0
        {
            get { return _qiangzhedayu0; }
            set { _qiangzhedayu0 = value; }
        }
        private DateTime _xgsj;

        public DateTime Xgsj
        {
            get { return _xgsj; }
            set { _xgsj = value; }
        }

        private int _zuanshidayu1000;

        public int Zuanshidayu1000
        {
            get { return _zuanshidayu1000; }
            set { _zuanshidayu1000 = value; }
        }
        private int _zuanshidayu3000;

        public int Zuanshidayu3000
        {
            get { return _zuanshidayu3000; }
            set { _zuanshidayu3000 = value; }
        }
    }
}
