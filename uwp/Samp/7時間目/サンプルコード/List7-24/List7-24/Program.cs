using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_24
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 3, 4, 7, 4, 7, 32, 56, 32, 81, 83, 92 };

            // 重複を取り除いた要素を取得
            var num1 = nums.Distinct(); // 1, 3, 4, 7, 32, 56, 81, 83, 92

            // 先頭から6個の値をスキップした要素を取得する
            var num2 = nums.Skip(6);    // 32, 56, 32, 81, 83, 92

            // 先頭から80未満の値をスキップして要素を取得する
            var num3 = nums.SkipWhile(num => num < 80);     // 81, 83, 92

            // 先頭から5個の要素を取得する
            var num4 = nums.Take(5);    // 1, 3, 4, 7, 4

            // 先頭から10未満の要素を取得する
            var num5 = nums.TakeWhile(num => num < 10); // 1, 3, 4, 7, 4, 7 

            // 先頭から見て56より大きい要素を取得する
            var num6 = nums.Where(num => num > 56);     // 81, 83, 92
        }
    }
}
