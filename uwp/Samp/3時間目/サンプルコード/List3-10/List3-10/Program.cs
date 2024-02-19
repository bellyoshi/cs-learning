using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List3_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string strVal = null;

            string result = strVal ?? "default value";

            Console.WriteLine($"result = {result}");    // result = defalt value
        }
    }
}
