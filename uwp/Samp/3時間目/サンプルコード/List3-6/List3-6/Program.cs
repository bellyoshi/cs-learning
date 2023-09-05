using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List3_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 3;
            string y = "文字";

            Console.WriteLine($"値 x = {x}, y = {y}");
            Console.WriteLine("x is double の演算結果は {0}です", x is double);
            Console.WriteLine("x is int の演算結果は {0}です", x is int);
            Console.WriteLine("y as string のキャスト結果は {0} です", y as string);
        }
    }
}
