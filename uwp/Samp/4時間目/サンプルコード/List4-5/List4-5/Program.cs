using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List4_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string weekday = "Tue";
            string strMsg = string.Empty;

            switch(weekday)
            {
                case "Sun":
                    strMsg = "今日は日曜日です。";
                    break;
                case "Mon":
                    strMsg = "今日は月曜日です。";
                    break;
                case "Tue":
                    strMsg = "今日は火曜日です。";
                    break;
                case "Wed":
                    strMsg = "今日は水曜日です。";
                    break;
                case "Thu":
                    strMsg = "今日は木曜日です。";
                    break;
                case "Fri":
                    strMsg = "今日は金曜日です。";
                    break;
                case "Sat":
                    strMsg = "今日は土曜日です。";
                    break;
                default:
                    strMsg  = "そのような曜日はありません。";
                    break;
            }

            Console.Write(strMsg);
        }
    }
}
