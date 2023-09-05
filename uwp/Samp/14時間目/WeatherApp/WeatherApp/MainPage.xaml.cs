using System;
using System.Collections.Generic;
using System.IO;
using Windows.UI.Xaml.Controls;

// 追加
using Windows.Storage;
using WeatherApp.Models;
using Windows.Web.Syndication;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WeatherApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private WeatherData weatherData = new WeatherData();
        private ObservableCollection<WeatherSummary> Summary = new ObservableCollection<WeatherSummary>();
        private const string WEATHER_URL = "http://weather.livedoor.com/forecast/webservice/json/v1?city=";
        Dictionary<string, List<City>> _city = new Dictionary<string, List<City>>();


        public MainPage()
        {
            this.InitializeComponent();

            // JSONファイルの読み込み
            ReadJson();
        }

        private void cmbPrefecture_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ((ComboBox)sender).SelectedValue.ToString();

            cmbCity.ItemsSource = _city[item];
            cmbCity.DisplayMemberPath = "Name";
            cmbCity.SelectedValuePath = "Id";

        }

        private void cmbCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = ((ComboBox)sender).SelectedValue?.ToString();

            if (id == null) return;

            ReadWeatherData(id);
        }

        /// <summary>
        /// AssetsフォルダのJSONファイルを読み込む
        /// </summary>
        private async void ReadJson()
        {
            // Assetsからのファイル取り出し
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/City.json"));
            // ファイルの読み込み
            string json = await FileIO.ReadTextAsync(file);

            // jsonデータからクラスへのデシリアライズ
            List<Prefecture> pref;
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                // List<Prefecture>に変換できるシリアライザーを作成
                var serializer = new DataContractJsonSerializer(typeof(List<Prefecture>));
                // クラスにデータを読み込む
                pref = serializer.ReadObject(stream) as List<Prefecture>;
            }

            // 市町村データを取得する
            foreach (var item in pref)
            {
                // 県名と市の集まりをcityに追加
                _city.Add(item.Name, item.Cities);

            }

            // 都道府県をcmbPrefectureにセット
            cmbPrefecture.ItemsSource = pref;
            cmbPrefecture.DisplayMemberPath = "Name";
            cmbPrefecture.SelectedValuePath = "Name";
            cmbPrefecture.SelectedIndex = 0;
        }

        private async void ReadWeatherData(string id )
        {
            //var client = new SyndicationClient();
            //var feed = await client.RetrieveFeedAsync(new Uri(WEATHER_URL + id));

            //// Assetsからのファイル取り出し
            //var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/forecast.json"));
            //// ファイルの読み込み
            //string json = await FileIO.ReadTextAsync(file);

            var hc = new Windows.Web.Http.HttpClient();
            string json = await hc.GetStringAsync(new Uri(WEATHER_URL + id));

            //jsonデータからクラスへのデシリアライズ
            WeatherData weather;
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                // List<WeatherData>に変換できるシリアライザーを作成
                var serializer = new DataContractJsonSerializer(typeof(WeatherData));
                // クラスにデータを読み込む
                weather = serializer.ReadObject(stream) as WeatherData;
            }


            Summary.Clear();

            foreach (var forecast in weather.forecasts)
            {
                WeatherSummary temp = new WeatherSummary()
                {
                    DateLabel = forecast.dateLabel,
                    Telop = forecast.telop,
                    Date = forecast.date,
                    Url = forecast.image.url
                };

                Summary.Add(temp);
            }


        }



    }
}
