using System;
using System.Collections.Generic;
using System.IO;
using Windows.UI.Xaml.Controls;

// 追加
using Windows.Storage;
using System.Text;
using WeatherApp.Models;
using System.Runtime.Serialization.Json;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WeatherApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Dictionary<string, List<City>> _city = new Dictionary<string, List<City>>();

        public MainPage()
        {
            this.InitializeComponent();

            ReadJson();
        }

        /// <summary>
        /// AssetsフォルダのJSONファイルを読み込む
        /// </summary>
        private async void ReadJson()
        {
            // Assetsからのファイル取り出し
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Prefecture.json"));
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

        /// <summary>
        /// 都道府県選択時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPrefecture_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 選択された都道府県名の取得
            var item = ((ComboBox)sender).SelectedValue.ToString();

            // 地域ComboBoxへのデータ表示
            cmbCity.ItemsSource = _city[item];
            cmbCity.DisplayMemberPath = "Name";
            cmbCity.SelectedValuePath = "Id";
        }
    }
}
