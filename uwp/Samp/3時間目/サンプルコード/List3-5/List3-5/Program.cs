using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List3_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 2;
            int y = 3;

            Console.WriteLine($"値 x = {x}, y = {y}");
            Console.WriteLine("x == y の演算結果は {0} です", x == y);
            Console.WriteLine("x != y の演算結果は {0} です", x != y);
            Console.WriteLine("x > y  の演算結果は {0} です", x > y);
            Console.WriteLine("x < y  の演算結果は {0} です", x < y);
            Console.WriteLine("x >= y の演算結果は {0} です", x >= y);
            Console.WriteLine("x <= y の演算結果は {0} です", x <= y);
        }
    }
}
