using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class SanDian
    {

        private int mx1;

        public int Mx1
        {
            get { return mx1; }
            set { mx1 = value; }
        }
        private int my1;

        public int My1
        {
            get { return my1; }
            set { my1 = value; }
        }
        private int myanse1;

        public Int32 Myanse1
        {
            get { return myanse1; }
            set { myanse1 = value; }
        }
        private int mx2;

        public int Mx2
        {
            get { return mx2; }
            set { mx2 = value; }
        }
        private int my2;

        public int My2
        {
            get { return my2; }
            set { my2 = value; }
        }
        private int myanse2;

        public int Myanse2
        {
            get { return myanse2; }
            set { myanse2 = value; }
        }
        private int mx3;

        public int Mx3
        {
            get { return mx3; }
            set { mx3 = value; }
        }
        private int my3;

        public int My3
        {
            get { return my3; }
            set { my3 = value; }
        }
        private int myanse3;

        public int Myanse3
        {
            get { return myanse3; }
            set { myanse3 = value; }
        }

        public SanDian(int mx1, int my1, int myanse1, int mx2 = -1, int my2 = -1, int myanse2 = -1, int mx3 = -1, int my3 = -1, int myanse3 = -1)
        {
            this.mx1 = mx1;
            this.my1 = my1;
            this.myanse1 = myanse1;
            this.mx2 = mx2;
            this.my2 = my2;
            this.myanse2 = myanse2;
            this.mx3 = mx3;
            this.my3 = my3;
            this.myanse3 = myanse3;
        }


        public SanDian(int[,] shuzu) {
            this.mx1 = shuzu[0,0];
            this.my1 = shuzu[0, 1];
            this.myanse1 = shuzu[0, 2];
            this.mx2 = shuzu[1, 0];
            this.my2 = shuzu[1, 1];
            this.myanse2 = shuzu[1, 2];
            this.mx3 = shuzu[2, 0];
            this.my3 = shuzu[2, 1];
            this.myanse3 = shuzu[2, 2];
        }

        public bool Equals(SanDian other)
        {
	        //this非空，obj如果为空，则返回false
            if (ReferenceEquals(null, other)) return false;
         
            //如果为同一对象，必然相等
            if (ReferenceEquals(this, other)) return true;
         
            //对比各个字段值
            if  (!(this.mx1==other.Mx1)
                || !(this.my1==other.My1)
                || !(this.myanse1==other.Myanse1)
                || !(this.mx2==other.Mx2)
                || !(this.my2==other.My2)
                || !(this.myanse2==other.Myanse2)
                || !(this.mx3==other.Mx3)
                || !(this.my3==other.My3)
                || !(this.myanse3==other.Myanse3))
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
            return Equals((SanDian)obj);
        }
 
	    //实现Equals重写同时，必须重写GetHashCode
        public override int GetHashCode()
        {
            return (this.mx1 +this.my2+this.myanse1+this.mx2 +this.my2+this.myanse2+this.mx3 +this.my3+this.myanse3);
        }
 
	    //重写==操作符
        public static bool operator ==(SanDian left, SanDian right)
        {
            return Equals(left, right);
        }
 
	    //重写!=操作符
        public static bool operator !=(SanDian left, SanDian right)
        {
            return !Equals(left, right);
        }

        

    }
}
