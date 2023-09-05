using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class WeatherSummary
    {
        public string DateLabel { get; set; }   // 予報日（今日、明日、明後日）
        public string Telop { get; set; }       // 天気（晴れ、曇りなど）
        public string Date { get; set; }        // 予報日
        public string Url { get; set; }         // 天気アイコンのURL
    }
}
