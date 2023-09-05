using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List2_18
{
    class Program
    {
        static void Main(string[] args)
        {
            int iNo = 127;      // 暗黙的な型変換
            sbyte sNo = (sbyte)iNo;

            // iNoの値を表示
            Console.WriteLine($"sNo = {sNo}");
        }
    }
}




