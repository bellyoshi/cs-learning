using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_25
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 3, 9, 2, 4 };

            // 要素の平均値を取得
            double num1 = nums.Average();   // 4

            // 要素数を取得
            int num2 = nums.Count();    // 5

            // 要素の最小値を取得
            int num3 = nums.Min();      // 2

            // 要素の最大値を取得
            int num4 = nums.Max();      // 9

            // 要素の合計を取得
            int num5 = nums.Sum();      // 20
        }
    }
}
