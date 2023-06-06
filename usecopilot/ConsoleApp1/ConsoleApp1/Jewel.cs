using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Jewel
    {
        //1～10までの和を計算
        public int Sum(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n + Sum(n - 1);
            }
        }
    }
}
