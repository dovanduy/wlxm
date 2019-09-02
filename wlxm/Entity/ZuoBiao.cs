using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class ZuoBiao
    {
        private int _x;

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        private int _y;

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        private int _yanse;

        public int Yanse
        {
            get { return _yanse; }
            set { _yanse = value; }
        }

        public ZuoBiao(int x, int y, int yanse = -1)
        {
            this._x = x;
            this._y = y;
            this._yanse = yanse;
        }
    }
}
