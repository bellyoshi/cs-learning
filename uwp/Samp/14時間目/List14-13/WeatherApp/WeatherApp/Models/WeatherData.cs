using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WeatherApp.Models
{
    // 天気予報管理クラス
    [DataContract]
    public class WeatherData
    {
        [DataMember]
        public List<Forecast> forecasts { get; set; }   // 都道府県天気予報
    }

    // 予報日毎の府県天気予報管理クラス 
    [DataContract]
    public class Forecast
    {
        // 予報日（今日、明日、明後日）
        [DataMember]
        public string dateLabel { get; set; }
        // 天気（晴れ、曇りなど）
        [DataMember]
        public string telop { get; set; }
        // 予報日
        [DataMember]
        public string date { get; set; }
        // 天気予報とイメージ
        [DataMember]
        public FImage image { get; set; }
    }

    // 天気予報とイメージ管理クラス
    [DataContract]
    public class FImage
    {
        // 天気（晴れ、曇りなど）
        [DataMember]
        public string title { get; set; }
        // 天気アイコンのURL
        [DataMember]
        public string url { get; set; }
        // 天気アイコンの幅
        [DataMember]
        public int width { get; set; }
        // 天気アイコンの高さ
        [DataMember]
        public int height { get; set; }
    }
}
