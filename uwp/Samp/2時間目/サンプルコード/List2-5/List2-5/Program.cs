using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            double chair = 7000 * 1.08;		// イスの税込み金額を計算
            double table = 10000 * 1.08;	// テーブルの税込み金額を計算

            Console.WriteLine("イスの税込み金額は{0}円です", chair);
            Console.WriteLine("テーブルの税込み金額は{0}円です。", table);
        }
    }
}
