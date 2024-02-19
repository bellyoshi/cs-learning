using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List2_14
{
    class Program
    {
        static void Main(string[] args)
        {
            var no = 100;
            var longNo = 922337203685477507;
            var doubleNo = 3.14159;

            // 各変数のデータ型を表示
            Console.WriteLine(no.GetType());        // System.Int32（int型）
            Console.WriteLine(longNo.GetType());    // System.Int64（long型）
            Console.WriteLine(doubleNo.GetType());  // System.Double（Double型）
        }
    }
}
