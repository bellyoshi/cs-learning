using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List3_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            int y = 6;
            int ans = 0;
            bool ans2 = true;

            Console.WriteLine($"値 x = {x}, y = {y}");

            // x と y の AND演算結果を ans に代入
            ans = x & y;
            Console.WriteLine($"x & y = {ans}");    // 2

            // x と y の OR演算結果を ans に代入
            ans = x | y;
            Console.WriteLine($"x | y = {ans}");    // 14

            // x と y の XOR演算結果を ans に代入
            ans = x ^ y;
            Console.WriteLine($"x ^ y = {ans}");    // 12

            // ans2 の NOT演算結果を ans2 に代入
            ans2 = !ans2;
            Console.WriteLine($"!x = {ans2}");      // false
        }
    }
}
