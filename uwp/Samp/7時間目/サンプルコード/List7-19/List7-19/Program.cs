using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_19
{
    class Program
    {
        // デリゲートの定義
        private delegate int DoSomething(int x, int y);

        static void Main(string[] args)
        {
            DoSomething method = new DoSomething(Add);
            int ans1 = method(2, 3);
            Console.WriteLine($"2 + 3 = {ans1}");

            method = new DoSomething(Mul);
            int ans2 = method(2, 3);
            Console.WriteLine($"2 * 3 = {ans2}");
        }

        // 足し算をする
        private static int Add(int x, int y)
        {
            return x + y;
        }

        // かけ算をする
        private static int Mul(int x, int y)
        {
            return x * y;
        }
    }
}
