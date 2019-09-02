using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class FuHeSanDian
    {
        private SanDian _sd;

        public SanDian Sd
        {
          get { return _sd; }
          set { _sd = value; }
        }

        
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
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

        private string _dianhanyi;

        public string Dianhanyi
        {
            get { return _dianhanyi; }
            set { _dianhanyi = value; }
        }

        private List<ZuoBiao> _listzuobiao = new List<ZuoBiao>();

        public List<ZuoBiao> Listzuobiao
        {
            get { return _listzuobiao; }
            set { _listzuobiao = value; }
        }

        public FuHeSanDian(string name, SanDian sd, int zhidingx=-1, int zhidingy=-1,string dianhanyi=null,List<ZuoBiao> listzuobiao =null)
        {
            this._name = name;
            this._sd = sd;
            this._zhidingx = zhidingx;
            this._zhidingy = zhidingy;
            this._dianhanyi = dianhanyi;
            this._listzuobiao = listzuobiao;
        }
    }
}
