using NDDD.Domain.Exceptions;
using NDDD.WinForm.ViewModels;
using System;
using System.Windows.Forms;

namespace NDDD.WinForm.Views {

    /// <summary>
    /// LatestView
    /// </summary>
    public partial class LatestView : BaseForm {

        // ViewModelを参照する
        // インスタンス生成はFactoriesで生成する
        // 設定はSheardにて行う
        private LatestViewModel _viewModel = new LatestViewModel();
       
        /// <summary>
        /// コンストラクター
        /// </summary>
        public LatestView() {
            InitializeComponent();

            // データバインド AreaIdTextBox
            AreaIdTextBox.DataBindings.Add(
                "Text",
                _viewModel,
                nameof(_viewModel.AreaIdText));

            // データバインド MeasureDateTextBox
            MeasureDateTextBox.DataBindings.Add(
                "Text",
                _viewModel,
                    nameof(_viewModel.MeasureDateText));

            // データバインド MeasureValueTextBox
            MeasureValueTextBox.DataBindings.Add(
                "Text",
                _viewModel,
                 nameof(_viewModel.MeasureValueText));
        }

        /// <summary>
        /// ボタンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, System.EventArgs e) {
            try {
                _viewModel.Search();
            }

            // innerExceptionに例外が発生したクラスの例外を通知する
            catch(Exception ex) {


                // 下記の処理は基底クラス（BaseForm）に移行し共通化
                //MessageBoxIcon icon = MessageBoxIcon.Error;
                //string caption = "エラー";
                //var exceptionBase = ex as ExceptionBase;

                //if(exceptionBase != null) {

                //    if (exceptionBase.Kind == ExceptionBase.ExceptionKind.Info) {
                //        icon = MessageBoxIcon.Information;
                //        caption = "情報";
                //    }
                //    else if(exceptionBase.Kind==ExceptionBase.ExceptionKind.Warning) {
                //        icon = MessageBoxIcon.Warning;
                //        caption = "警告";
                //    }
                //}

                //MessageBox.Show(ex.Message,caption,MessageBoxButtons.OK,icon);


                // 基底クラスに投げる（BaseForm）
                ExceptionProc(ex);

            }
        }
    }
}
