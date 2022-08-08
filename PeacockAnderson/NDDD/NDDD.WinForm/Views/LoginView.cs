using NDDD.Domain;

namespace NDDD.WinForm.Views {

    /// <summary>
    /// ログイン画面
    /// </summary>
    public partial class LoginView : BaseForm {

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LoginView() {
            InitializeComponent();
        }

        /// <summary>
        /// ログインId
        /// 実際はViewModelに書く
        /// IDチェックやら何やかんや
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_Click(object sender, System.EventArgs e) {

            Shared.LoginId = LoginTextBox.Text;
            
            // LatestViewの表示
            using (var f = new LatestView()) {
                f.ShowDialog();
            }
        }
    }
}
