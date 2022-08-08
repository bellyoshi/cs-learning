using NDDD.WinForm.ViewModels;

namespace NDDD.WinForm.Views
{
    public partial class LatestView : Form
    {
        private LatestViewModel _viewModel = new LatestViewModel();
        public LatestView()
        {
            InitializeComponent();

            AddDataBingings();
        }

        private void AddDataBingings()
        {
            this.AreaIDTextBox.DataBindings.Add("Text", _viewModel, "AreaIdText");
            this.MeasureDateTextBox.DataBindings.Add("Text", _viewModel, "MeasureDateText");
            this.MeasureValueTextbox.DataBindings.Add("Text", _viewModel, "MeasureValueText");
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {

        }
    }
}
