using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fuzhu
{
    interface youxi
    {
        Boolean denglu(int fenzhong, ref string name, ref string pwd);
        Boolean zhuce(int fz);
        void ceshi();
        void zhuxian(string name,long myhourhaomiao);
        void richang();
        void jiangli();
        void fuben();
        void tiaoguo();
        void lingqu();
        void qidong(int index,string name);
        void guanbi(int index, string name);
        Boolean yiqidong();
        Boolean panduanjiemian(string jiemian);
        Boolean chongxindenglu();
        void guanbi_all();        
    }
}
