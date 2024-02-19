using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_23
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 3, 4, 7, 11, 23, 32, 56, 61, 81, 83, 92 };

            // 先頭から3番目の要素を取得
            var num1 = nums.ElementAt(2);   // 4

            // 先頭から13番目の要素を取得
            var num2 = nums.ElementAtOrDefault(12);  // 存在しないので0

            // 先頭の要素を取得する
            var num3 = nums.First();    // 1

            // 2で割った余りが0の要素のうち先頭のものを取得する
            var num4 = nums.FirstOrDefault(num => num % 2 == 0); // 4

            // 最後の要素を取得する
            var num5 = nums.Last(); // 92

            // 2で割った余りが0の要素のうち最後のものを取得する
            var num6 = nums.LastOrDefault(num => num % 2 == 0); // 92

            // 56と等しいも要素を取得する
            var num7 = nums.Single(num => num == 56);   //56

            // 57と等しい要素を取得する
            var num8 = nums.SingleOrDefault(num => num == 57);  // 存在しないので0
        }
    }
}
