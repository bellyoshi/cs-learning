using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List3_12
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            int y = 0;

            x = 3;
            y = ++x;
            Console.WriteLine($"前置インクリメント x = {x}, y = {y}");   // x = 4, y = 4

            x = 3;
            y = x++;
            Console.WriteLine($"後置インクリメント x = {x}, y = {y}");   // x = 4, y = 3

            x = 3;
            y = --x;
            Console.WriteLine($"前置デクリメント x = {x}, y = {y}");    // x = 2, y = 2 

            x = 3;
            y = x--;
            Console.WriteLine($"後置デクリメント x = {x}, y = {y}");    // x = 2, y = 3
        }
    }
}
