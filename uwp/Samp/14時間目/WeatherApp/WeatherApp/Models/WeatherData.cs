using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    // 天気予報管理クラス
    [DataContract]
    public class WeatherData
    {
        //[DataMember]
        //public List<PinpointLocation> pinpointLocations { get; set; }   // ピンポイント予報
        //[DataMember]
        //public string link { get; set; }    // データ地域に該当する天気情報のURL
        [DataMember]
        public List<Forecast> forecasts { get; set; }   // 都道府県天気予報の予報日毎配列
        //[DataMember]
        //public Location location { get; set; }  // 予報を発表した地域を定義
        //[DataMember]
        //public string publicTime { get; set; }  // 予報の発表日時
        //[DataMember]
        //public Copyright copyright { get; set; }    //
        //[DataMember]
        //public string title { get; set; }   // タイトル
        //[DataMember]
        //public Description description { get; set; }    // 天気概要分
    }

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
        //[DataMember]
        //public TemparatureData temperature { get; set; }
        [DataMember]
        public FImage image { get; set; }
    }

    [DataContract]
    public class TemparatureData
    {
        [DataMember]
        public Temparature min { get; set; }
        [DataMember]
        public Temparature max { get; set; }
    }

    [DataContract]
    public class Temparature
    {
        [DataMember]
        public string celsius { get; set; }
        [DataMember]
        public string fahrenheit { get; set; }
    }

    [DataContract]
    public class FImage
    {
        // 天気アイコンの幅
        [DataMember]
        public int width { get; set; }
        // 天気アイコンのURL
        [DataMember]
        public string url { get; set; }
        // 天気（晴れ、曇りなど）
        [DataMember]
        public string title { get; set; }
        //// データの地域に該当する天気情報のURL
        //public string Link { get; set; }
        // 天気アイコンの高さ
        [DataMember]
        public int height { get; set; }
    }

    [DataContract]
    public class Location
    {
        // 1次細分区名
        [DataMember]
        public string city { get; set; }
        // 地方名
        [DataMember]
        public string area { get; set; }
        // 都道府県名
        [DataMember]
        public string prefecture { get; set; }
    }

    [DataContract]
    public class PinpointLocation
    {
        // 対応するlivedoor 天気情報のURL
        [DataMember]
        public string link { get; set; }
        // 地域名
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class Copyright
    {
        // livedoor 天気情報で使用している気象データの配信元
        [DataMember]
        public Provider provider { get; set; }
        // livedoorの天気情報のURL
        [DataMember]
        public string link { get; set; }
        // コピーライトの文言
        [DataMember]
        public string title { get; set; }
        // livedoor 天気情報へのURL、アイコンなど
        public Image image { get; set; }
    }

    [DataContract]
    public class Provider
    {
        [DataMember]
        public string link { get; set; }
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class Image
    {
        [DataMember]
        public int width { get; set; }
        [DataMember]
        public string link { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public int height { get; set; }
    }

    [DataContract]
    public class Description
    {
        // 天気概要情報
        [DataMember]
        public string text { get; set; }
        // 天気概要発表時刻
        [DataMember]
        public string publicTime { get; set; }
    }
}
