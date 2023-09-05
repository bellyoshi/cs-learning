using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List5_18
{
    class Program
    {
        static void Main(string[] args)
        {
            Sample smp = new Sample();

            smp.hensu1 = 100;   // OK
            smp.hensu2 = 200;   // NG

            smp.DoSomething1(); // OK
            smp.DoSomething2(); // NG
        }
    }
}
