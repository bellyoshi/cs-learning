using NDDD.WinForm.ViewModels;
using NDDD.Infrastructure.Fake;

namespace NDDD.WinForm.Views
{
    public partial class LatestView : Form
    {
        private LatestViewModel _viewModel = new LatestViewModel(new MeasureFake());
        public LatestView()
        {
            InitializeComponent();

            AddDataBingings();
        }

        private void AddDataBingings()
        {
            this.AreaIDTextBox.DataBindings.Add("Text", _viewModel, nameof(_viewModel.AreaIdText));
            this.MeasureDateTextBox.DataBindings.Add("Text", _viewModel,nameof(_viewModel.MeasureDateText));
            this.MeasureValueTextbox.DataBindings.Add("Text", _viewModel, nameof(_viewModel.MeasureValueText));
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            _viewModel.Search();
        }
    }
}
