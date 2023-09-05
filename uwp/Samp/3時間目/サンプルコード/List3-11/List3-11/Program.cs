using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List3_11
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 3;
            int y = 5;

            Console.WriteLine($"値 x = {x}, y = {y}");
            Console.WriteLine("x += 3 の演算結果は {0} です。", x += 3);
            Console.WriteLine("x -= 2 の演算結果は {0} です。", x -= 2);
            Console.WriteLine("x *= 2 の演算結果は {0} です。", x *= 2);
            Console.WriteLine("x /= 2 の演算結果は {0} です。", x /= 2);
        }
    }
}
