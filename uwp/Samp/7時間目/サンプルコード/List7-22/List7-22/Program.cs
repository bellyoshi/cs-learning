using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_22
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // クエリ式
            var query1 = from num in nums
                         where num % 2 == 0
                         select num;

            // メソッド構文
            var query2 = nums.Where(num => num % 2 == 0);

            // query1の結果を表示
            foreach (int num in query1)
            {
                Console.WriteLine(num);
            }

            // query2の結果を表示
            foreach (int num in query2)
            {
                Console.WriteLine(num);
            }
        }
    }
}
