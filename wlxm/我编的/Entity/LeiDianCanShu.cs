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

        public LeiDianCanShu(int dqinx, int jubing,int waicengjubing) {
            this._dqinx = dqinx;
            this._jubing = jubing;
            this._waiCengJuBing = waicengjubing;
        }

        private int _waiCengJuBing;

        public int WaiCengJuBing
        {
            get { return _waiCengJuBing; }
            set { _waiCengJuBing = value; }
        }
    }
}
