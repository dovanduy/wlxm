using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class DuoDianZhaoSe
    {
        
        private int _fir;

        public int Fir
        {
            get { return _fir; }
            set { _fir = value; }
        }
        private string _off;

        public string Off
        {
            get { return _off; }
            set { _off = value; }
        }
        private int _sim;

        public int Sim
        {
            get { return _sim; }
            set { _sim = value; }
        }
        private int _x0;

        public int X0
        {
            get { return _x0; }
            set { _x0 = value; }
        }
        private int _y0;

        public int Y0
        {
            get { return _y0; }
            set { _y0 = value; }
        }
        private int _x1;

        public int X1
        {
            get { return _x1; }
            set { _x1 = value; }
        }
        private int _y1;

        public int Y1
        {
            get { return _y1; }
            set { _y1 = value; }
        }

        public DuoDianZhaoSe(Int32 fir, string off, int sim, int x0, int y0, int x1, int y1)
        {
            this.Fir = fir;
            this.Off = off;
            this.Sim = sim;
            this.X0 = x0;
            this.Y0 = y0;
            this.X1 = x1;
            this.Y1 = y1;
        }
        

        public bool Equals(DuoDianZhaoSe other)
        {
	        //this非空，obj如果为空，则返回false
            if (ReferenceEquals(null, other)) return false;
         
            //如果为同一对象，必然相等
            if (ReferenceEquals(this, other)) return true;
         
            //对比各个字段值
            if (!string.Equals(this._off, other.Off, StringComparison.InvariantCulture)
                || !(this._fir==other.Fir)
                || !(this._sim==other.Sim)
                || !(this._x0==other.X0)
                || !(this._x1==other.X1)
                || !(this._y0==other.Y0)
                || !(this._y1==other.Y1))
	            return false;
	     
	        //如果基类不是从Object继承，需要调用base.Equals(other)
	        //如果从Object继承，直接返回true
		    return true;
        }
 
        public override bool Equals(object obj)
        {
	        //this非空，obj如果为空，则返回false
            if (ReferenceEquals(null, obj)) return false;
         
            //如果为同一对象，必然相等
            if (ReferenceEquals(this, obj)) return true;
         
            //如果类型不同，则必然不相等
            if (obj.GetType() != this.GetType()) return false;
         
            //调用强类型对比
            return Equals((DuoDianZhaoSe)obj);
        }
 
	    //实现Equals重写同时，必须重写GetHashCode
        public override int GetHashCode()
        {
            return (this._off != null ? StringComparer.InvariantCulture.GetHashCode(this._off) : 0);
        }
 
	    //重写==操作符
        public static bool operator ==(DuoDianZhaoSe left, DuoDianZhaoSe right)
        {
            return Equals(left, right);
        }
 
	    //重写!=操作符
        public static bool operator !=(DuoDianZhaoSe left, DuoDianZhaoSe right)
        {
            return !Equals(left, right);
        }

        

    }
}
