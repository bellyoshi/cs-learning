using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List5_10
{
    class Sample
    {
        // 値渡しの例
        public void ShowID1(int id)
        {
            id = 3;
        }

        // 参照渡しの例
        public void ShowID2(ref int id)
        {
            id = 5;
        }
    }
}
