using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List4_8
{
    class Program
    {
        static void Main(string[] args)
        {
            string weekday = "火曜日";
            string strMsg = string.Empty;

            switch (weekday)
            {
                case "Sun":
                case "日曜日":
                    strMsg = "今日は日曜日です。";
                    break;
                case "Mon":
                case "月曜日":
                    strMsg = "今日は月曜日です。";
                    break;
                case "Tue":
                case "火曜日":
                    strMsg = "今日は火曜日です。";
                    break;
                case "Wed":
                case "水曜日":
                    strMsg = "今日は水曜日です。";
                    break;
                case "Thu":
                case "木曜日":
                    strMsg = "今日は木曜日です。";
                    break;
                case "Fri":
                case "金曜日":
                    strMsg = "今日は金曜日です。";
                    break;
                case "Sat":
                case "土曜日":
                    strMsg = "今日は土曜日です。";
                    break;
                default:
                    strMsg = "そのような曜日はありません。";
                    break;
            }

            Console.WriteLine(strMsg);
        }
    }
}
