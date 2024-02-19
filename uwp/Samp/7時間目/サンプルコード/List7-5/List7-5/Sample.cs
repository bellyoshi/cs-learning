using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_5
{
    class Sample<T> where T : IComparable
    {
        public bool IsGreater(T x, T y)
        {
            if (x.CompareTo(y) > 0)
            {
                return true;
            }

            return false;
        }
    }
}
