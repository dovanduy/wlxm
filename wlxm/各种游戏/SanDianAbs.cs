using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace fuzhu
{
    public abstract class SanDianAbs
    {

        public FuHeSanDian findFuHeSandianByName(string name)
        {
            return findAllFuHeSandian().Find(f => name.Equals(f.Name)
                );
        }
        public List<FuHeSanDian> findListFuHeSandianByName(string nameindex)
        {
            return findAllFuHeSandian().FindAll(f => f.Name.IndexOf(nameindex) == 0
                );
        }
        public abstract List<FuHeSanDian> findAllFuHeSandian();
               
    }
}
