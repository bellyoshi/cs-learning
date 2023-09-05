using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 追加
using Windows.UI.Input.Inking;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Drawing
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // 極細のペンサイズ
        private const int MINIMUM_PEN_SIZE = 2;
        // ペンの拡大率
        private const int SIZE_RATE = 2;

        // ペン属性のインスタンス
        private InkDrawingAttributes attributes;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();

            // ComboBoxに表示する項目の作成
            var colorNames = new List<FillColor>()
            {
                new FillColor { ColorName = "Black", DrawingColor= Windows.UI.Colors.Black },
                new FillColor { ColorName = "Red" , DrawingColor =Windows.UI.Colors.Red },
                new FillColor { ColorName = "Yellow" , DrawingColor = Windows.UI.Colors.Yellow },
                new FillColor { ColorName = "Orange" , DrawingColor = Windows.UI.Colors.Orange },
                new FillColor { ColorName = "Blue" , DrawingColor = Windows.UI.Colors.Blue },
                new FillColor { ColorName = "Purple" , DrawingColor = Windows.UI.Colors.Purple },
            };

            // 作成した色をComboBoxにセット
            cmbPenColors.ItemsSource = colorNames;
            cmbPenColors.DisplayMemberPath = "ColorName";
            cmbPenColors.SelectedValuePath = "DrawingColor";
            cmbPenColors.SelectedIndex = 0;

            // 初期化処理の実行
            InitializePen();
        }

        /// <summary>
        /// ペンの初期化処理
        /// </summary>
        private void InitializePen()
        {            
            // インク属性のインスタンスを生成
            attributes = new InkDrawingAttributes();

            // 描画属性を作成する
            int penSize = 2;
            attributes.Color = Windows.UI.Colors.Black;     // ペンの色
            attributes.FitToCurve = true;                   // フィットトゥカーブ
            attributes.IgnorePressure = true;               // ペンの圧力を使用するかどうか
            attributes.PenTip = PenTipShape.Circle;         // ペン先の形状
            attributes.Size = new Size(penSize, penSize);   // ペンのサイズ

            // インクキャンバスに属性を設定する
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(attributes);

            // マウスとペンによる描画を許可する
            inkCanvas.InkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Mouse | Windows.UI.Core.CoreInputDeviceTypes.Pen;
        }

        /// <summary>
        /// ペン先の形状変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPenStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (attributes == null) return;

            if (cmbPenStyle.SelectedIndex == 0)
            {
                attributes.PenTip = PenTipShape.Circle;     // ペン先の形状を●にする
            }
            else
            {
                attributes.PenTip = PenTipShape.Rectangle;  // ペン先の形状を■にする
            }

            // インクキャンバスに属性を設定する
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(attributes);
        }

        /// <summary>
        /// ペンの色変更時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPenColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (attributes == null) return;

            // 選択された色の取得
            var selectedColor = ((ComboBox)sender).SelectedValue;

            // InkCanvasの属性に色をセット
            attributes.Color = (Windows.UI.Color)selectedColor;

            // インクキャンバスの属性を更新する
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(attributes);
        }

        /// <summary>
        /// ペンの太さ変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPenSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (attributes == null) return;

            // 選択されたペンの太さに合わせたサイズを算出する
            int penSize = MINIMUM_PEN_SIZE + cmbPenSize.SelectedIndex * SIZE_RATE;

            // ペンのサイズを設定する
            attributes.Size = new Size(penSize, penSize);

            // インクキャンバスの属性を更新する
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(attributes);
        }
    }

    /// <summary>
    /// 色選択ComboBoxに表示する色の名前と色を管理するクラス
    /// </summary>
    class FillColor
    {
        public string ColorName { get; set; }
        public Windows.UI.Color DrawingColor { get; set; }
    }
}
