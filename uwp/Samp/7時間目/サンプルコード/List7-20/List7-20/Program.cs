using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_20
{
    class Program
    {
        // デリゲートの定義
        private delegate int DoSomething(int x, int y);

        static void Main(string[] args)
        {
            // 匿名メソッド
            DoSomething method = delegate (int x, int y) { return x + y; };
            int ans1 = method(2, 3);
            Console.WriteLine($"2 + 3 = {ans1}");

            // 匿名メソッド
            method = delegate (int x, int y) { return x * y; };
            int ans2 = method(2, 3);
            Console.WriteLine($"2 * 3 = {ans2}");
        }
    }
}
