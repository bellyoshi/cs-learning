using NDDD.Domain;

namespace NDDD.WinForm.Views {

    public partial class LoginView : BaseForm {

        public LoginView() {
            InitializeComponent();
        }

        /// <summary>
        /// ログインId
        /// todo:実際はViewModelに書く
        /// todo:IDチェックやら何やかんや
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_Click(object sender, System.EventArgs e) {

            CurrentUser.LoginId = LoginTextBox.Text;
            
            // LatestViewの表示
            using (var f = new LatestView()) {
                //todo dispacher
                f.ShowDialog();
            }
        }
    }
}
