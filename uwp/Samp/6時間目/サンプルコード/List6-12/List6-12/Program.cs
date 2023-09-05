using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List6_12
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMath math = new MyMath();

            int ans1 = math.Add(2, 3);
            int ans2 = math.Add(2, 3, 4);
            double ans3 = math.Add(3.1, 5.7);
        }
    }
}
