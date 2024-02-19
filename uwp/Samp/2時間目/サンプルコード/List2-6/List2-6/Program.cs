using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            const double TAX = 1.08;

            double chair = 7000 * TAX;
            double table = 10000 * TAX;

            Console.WriteLine("イスの税込み金額は{0}円です", chair);
            Console.WriteLine("テーブルの税込み金額は{0}円です。", table);
        }
    }
}
