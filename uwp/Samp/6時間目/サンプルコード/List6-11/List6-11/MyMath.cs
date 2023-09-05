using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List6_11
{
    class MyMath
    {
        /// <summary>
        /// 2つの値を足し算するメソッド
        /// </summary>
        public int Add(int x, int y)
        {
            return x + y;
        }

        /// <summary>
        /// 3つの値を足し算するメソッド
        /// </summary>
        public int Add(int x, int y, int z)
        {
            return x + y + z;
        }

        /// <summary>
        /// 2つの値を足し算するメソッド(double型)
        /// </summary>
        public double Add(double x, double y)
        {
            return x + y;
        }
    }
}
