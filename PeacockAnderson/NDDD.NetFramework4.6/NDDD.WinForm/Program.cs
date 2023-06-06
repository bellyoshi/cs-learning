using NDDD.WinForm.BackgroundWorkers;
using NDDD.WinForm.Views;
using System;
using System.Windows.Forms;

namespace NDDD.WinForm {

    /// <summary>
    /// Program
    /// </summary>
    static class Program {

        /// <summary>
        /// Log4Netのおまじない
        /// </summary>
        private static log4net.ILog _logger =
            log4net.LogManager.GetLogger(
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _logger.Debug("デバッグのログ");
            _logger.Info("インフォのログ");
            _logger.Warn("警告のログ");
            _logger.Error("エラーのログ");
            _logger.Fatal("致命的なログ");

            // タイマーのスタート
            LatestTimer.Start();

            // 画面起動
            Application.Run(new LoginView());
        }
    }
}
