using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List2_17
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte sNo = 127;
            int iNo = sNo;      // 暗黙的な型変換

            // iNoの値を表示
            Console.WriteLine($"iNo = {iNo}");
        }
    }
}
