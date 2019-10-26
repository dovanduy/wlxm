using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class ZhangHaoEntity
    {
        #region field
        private int _xh;

        public int Xh
        {
            get { return _xh; }
            set { _xh = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _pwd;

        public string Pwd
        {
            get { return _pwd; }
            set { _pwd = value; }
        }
        private int _xuanqu;

        public int Xuanqu
        {
            get { return _xuanqu; }
            set { _xuanqu = value; }
        }
        private int _zuanshi;

        public int Zuanshi
        {
            get { return _zuanshi; }
            set { _zuanshi = value; }
        }
        private int _qiangzhe;

        public int Qiangzhe
        {
            get { return _qiangzhe; }
            set { _qiangzhe = value; }
        }
        private string _yxbz;

        public string Yxbz
        {
            get { return _yxbz; }
            set { _yxbz = value; }
        }
        private string _yimai;

        public string Yimai
        {
            get { return _yimai; }
            set { _yimai = value; }
        }
        private DateTime _xgsj;

        public DateTime Xgsj
        {
            get { return _xgsj; }
            set { _xgsj = value; }
        }
        private string _dengluzhong;

        public string Dengluzhong
        {
            get { return _dengluzhong; }
            set { _dengluzhong = value; }
        }
        private string _pcname;

        public string Pcname
        {
            get { return _pcname; }
            set { _pcname = value; }
        }
        private string _youxi;

        public string Youxi
        {
            get { return _youxi; }
            set { _youxi = value; }
        }
        private int _dqinx;

        public int Dqinx
        {
            get { return _dqinx; }
            set { _dqinx = value; }
        }
        #endregion

        public ZhangHaoEntity(string youxi,string name,string pwd,int xuanqu,string yxbz,string yimai,string dengluzhong,int zuanshi,int qiangzhe,DateTime xgsj)  {
            this._youxi = youxi;
            this._name = name;
            this._pwd = pwd;
            this._xuanqu = xuanqu;
            this._yxbz = yxbz;
            this._yimai = yimai;
            this._dengluzhong = dengluzhong;
            this._zuanshi = zuanshi;
            this._qiangzhe = qiangzhe;
            this._xgsj = xgsj;
        }

        public ZhangHaoEntity() {
        
        }
        
    }
}
