using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 以下を追加
using MySample.Draw;

namespace MySample
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculate calc1 = new Calculate();
            MySample.Physics.Calculate calc2 = new MySample.Physics.Calculate();

            int ans1 = calc1.Add(1, 2);
            int ans2 = calc2.Add(3, 4);

        }
    }
}
