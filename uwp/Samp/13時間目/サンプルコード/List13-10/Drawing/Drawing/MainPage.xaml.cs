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
        // ペン属性のインスタンス
        private InkDrawingAttributes attributes;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();

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
    }
}
