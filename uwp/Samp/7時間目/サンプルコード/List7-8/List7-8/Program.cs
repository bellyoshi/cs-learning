using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> iData = new List<int>();

            // データを追加する
            iData.Add(3);
            iData.Add(4);
            iData.Add(5);
            iData.Add(6);
            iData.Add(7);

            iData.ForEach(WriteLine);
        }

        static void WriteLine(int num)
        {
            Console.WriteLine(num);
        }
    }
}
