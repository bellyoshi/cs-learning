using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 100;
            int ans = 0;


            // 100を右に2ビットシフト
            ans = number >> 2;

            Console.WriteLine($"100を右に2ビットシフトした値は{ans}です。");
        }
    }
}
