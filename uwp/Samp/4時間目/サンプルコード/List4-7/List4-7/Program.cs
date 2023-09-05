using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List4_7
{
    class Program
    {
        static void Main(string[] args)
        {
            string weekday = "Tue";
            string strMsg = string.Empty;

            switch (weekday)
            {
                case "Tue":
                    strMsg = "今日は火曜日です。";
                    break;
                case "火曜日":
                    strMsg = "今日は火曜日です。";
                    break;
            }

            Console.WriteLine(strMsg);
        }
    }
}
