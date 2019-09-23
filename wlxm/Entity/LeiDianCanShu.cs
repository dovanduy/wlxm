using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class LeiDianCanShu
    {
        private int _dqinx;

        public int Dqinx
        {
            get { return _dqinx; }
            set { _dqinx = value; }
        }
        private int _jubing;

        public int Jubing
        {
            get { return _jubing; }
            set { _jubing = value; }
        }

        public LeiDianCanShu(int dqinx, int jubing) {
            this._dqinx = dqinx;
            this._jubing = jubing;
        }
    }
}
