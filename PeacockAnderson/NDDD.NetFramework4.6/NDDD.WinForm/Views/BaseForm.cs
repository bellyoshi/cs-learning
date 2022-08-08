using NDDD.Domain;
using NDDD.Domain.Exceptions;
using System;
using System.Windows.Forms;

namespace NDDD.WinForm.Views {

    /// <summary>
    /// Form用基底クラス
    /// 共通のステータスバー表示制御
    /// </summary>
    public partial class BaseForm : Form {

        /// <summary>
        /// Log4Netのおまじない
        /// </summary>
        private static log4net.ILog _logger =
            log4net.LogManager.GetLogger(
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// コンストラクター
        /// </summary>
        public BaseForm() {

            InitializeComponent();

            toolStripStatusLabel1.Visible = false;

#if DEBUG
            // デバッグビルド時の表示
            toolStripStatusLabel1.Visible = true;

#endif

            // BaseFormにStatic変数を表示させる
            UserIdLabel.Text = Shared.LoginId;

        }


        /// <summary>
        /// エラーメッセージＢｏｘの制御を行う
        /// Exceptionに継承されたExceptionKindを確認し対応したアイコンとcaptionを表示する
        /// ただし使用するには、ExceptionBaseを継承したExceptionを渡す必要がある
        /// </summary>
        /// <param name="ex"></param>
        protected void ExceptionProc(Exception ex) {

            // ログを出力 
            // 第2引数に発生元のExceptionを出力
            _logger.Error(ex.Message, ex);

            MessageBoxIcon icon = MessageBoxIcon.Error;
            string caption = "エラー";


            // ExceptionBaseを使用していない場合（Null）は処理を行わない
            var exceptionBase = ex as ExceptionBase;
            if (exceptionBase != null) {

                if (exceptionBase.Kind == ExceptionBase.ExceptionKind.Info) {
                    icon = MessageBoxIcon.Information;
                    caption = "情報";
                } else if (exceptionBase.Kind == ExceptionBase.ExceptionKind.Warning) {
                    icon = MessageBoxIcon.Warning;
                    caption = "警告";
                }
            }

            MessageBox.Show(ex.Message, caption, MessageBoxButtons.OK, icon);
        }

        /// <summary>
        /// 起動時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseForm_Load(object sender, EventArgs e) {
            _logger.Info("open:" + this.Name);
        }

        /// <summary>
        /// クローズ時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e) {
            _logger.Info("close:" + this.Name);
        }

    }
}
