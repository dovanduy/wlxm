using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class YouXiEntity
    {
        private string _youxiname;

        public string Youxiname
        {
            get { return _youxiname; }
            set { _youxiname = value; }
        }

        private Version _version;

        public Version Version
        {
            get { return _version; }
            set { _version = value; }
        }

        private string _apkname;

        public string Apkname
        {
            get { return _apkname; }
            set { _apkname = value; }
        }
        private string _package;

        public string Package
        {
            get { return _package; }
            set { _package = value; }
        }
        private string _sandian;

        public string Sandian
        {
            get { return _sandian; }
            set { _sandian = value; }
        }
        private string _duodian;

        public string Duodian
        {
            get { return _duodian; }
            set { _duodian = value; }
        }
        private string _youxics;

        public string Youxics
        {
            get { return _youxics; }
            set { _youxics = value; }
        }

        private string _zidong;

        public string Zidong
        {
            get { return _zidong; }
            set { _zidong = value; }
        }

        public YouXiEntity() { }
        public YouXiEntity(string youxiname, string version,string zidong, string apkname, string package, string sandian, string duodian) {
            this._youxiname = youxiname;
            this._version = new Version(version);
            this._zidong = zidong;
            this._apkname = apkname;
            this._package = package;
            this._sandian = sandian;
            this._duodian = duodian;
        }
    }
}
