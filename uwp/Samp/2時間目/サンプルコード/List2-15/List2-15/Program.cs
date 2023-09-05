using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List2_15
{
    class Program
    {
        static void Main(string[] args)
        {
            // 電気の電源状態をbool型で管理
            bool lightSwitch = true;

            Console.WriteLine("電気の電源状態は{0}です。", lightSwitch);

            // 電源状態をOFFにする
            lightSwitch = false;

            Console.WriteLine("電気の電源状態は{0}です。", lightSwitch);
        }
    }
}
