using NDDD.WinForm.ViewModels;
using NDDD.Infrastructure.Fake;
using NDDD.Infrastructure;

namespace NDDD.WinForm.Views
{
    public partial class LatestView : Form
    {
        private readonly LatestViewModel _viewModel = new ();
        public LatestView()
        {
            InitializeComponent();

            AddDataBingings();

            DebugModeDisp();
        }

        private void DebugModeDisp()
        {
            toolStripStatusLabel1.Visible = false;
#if DEBUG
            toolStripStatusLabel1.Visible = true;
#endif
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
