using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // int型として使用する例
            MyData<int> intData = new MyData<int>();
            intData.PushData(5);

            // string型として使用する例
            MyData<string> strData = new MyData<string>();
            strData.PushData("Hello");
        }
    }
}
