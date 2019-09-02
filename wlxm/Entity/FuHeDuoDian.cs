using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class FuHeDuoDian
    {
        private DuoDianZhaoSe _dz;

        public DuoDianZhaoSe Dz
        {
            get { return _dz; }
            set { _dz = value; }
        }
        private int _chushix;

        public int Chushix
        {
            get { return _chushix; }
            set { _chushix = value; }
        }
        private int _chushiy;

        public int Chushiy
        {
            get { return _chushiy; }
            set { _chushiy = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _remark;

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private int _zhidingx;

        public int Zhidingx
        {
            get { return _zhidingx; }
            set { _zhidingx = value; }
        }
        private int _zhidingy;

        public int Zhidingy
        {
            get { return _zhidingy; }
            set { _zhidingy = value; }
        }
            
        private bool _zhaodao;

        public bool Zhaodao
        {
            get { return _zhaodao; }
            set { _zhaodao = value; }
        }

        private List<ZuoBiao> _listzuobiao = new List<ZuoBiao>();

        public List<ZuoBiao> Listzuobiao
        {
            get { return _listzuobiao; }
            set { _listzuobiao = value; }
        }
        public FuHeDuoDian(string name, DuoDianZhaoSe dz, int zhidingx, int zhidingy, List<ZuoBiao> listzb=null,string remark=null)
        {
            this._name = name;
            this._dz = dz;
            this._zhidingx = zhidingx;
            this._zhidingy = zhidingy;
            this._listzuobiao = listzb;
            this._remark = remark;
        }



        public FuHeDuoDian(string name, DuoDianZhaoSe dz, bool zhaodao,string remark=null)
        {
            this._name = name;
            this._dz = dz;
            this._zhaodao = zhaodao;
            this._remark = remark;
        }
    }
}
