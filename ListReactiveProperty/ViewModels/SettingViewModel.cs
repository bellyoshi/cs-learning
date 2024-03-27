using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using ListReactiveProperty.Models;
using ListReactiveProperty.Utils;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;


namespace ListReactiveProperty.ViewModels
{
    internal class SettingViewModel
    {
        //back color
        public ReactiveProperty<Brush> BackColor { get; } 

        private readonly DisplayModel _thatModel = DisplayModel.GetInstance();

        public ObservableCollection<Screen> DisplayOptions { get; } = new();
        public ReactiveProperty<Screen?> SelectedDisplayOption { get; } = new();
        public ReactiveCommand ChangeColorCommand { get; } = new();

        IWindowFullScreenManager? windowFullScreenManager;
        public void SetWindowFullScreenManager(IWindowFullScreenManager value)
        {
           windowFullScreenManager = value;
        }
        public SettingViewModel()
        {
            BackColor = _thatModel.ToReactivePropertyAsSynchronized(x => x.BackColor);
            ChangeColorCommand.Subscribe(_ => ShowColorDialog());

            SelectedDisplayOption.Subscribe(SelectedDisplayOption =>
            {
                SelectedDisplayChange(SelectedDisplayOption);
            }
            );

            Screen.AllScreens.ToList().ForEach(x => DisplayOptions.Add(x));
        }

        private void SelectedDisplayChange(Screen? SelectedDisplayOption)
        {
            if (windowFullScreenManager == null) return;
            if (SelectedDisplayOption == null) return;

                int index = DisplayOptions.IndexOf(SelectedDisplayOption);
                windowFullScreenManager.ScreenIndex = index;
            
        }

        private void ShowColorDialog()
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // 選択された色をReactivePropertyに設定
                var selectedColor = Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                var brush = new SolidColorBrush(Color.FromArgb(selectedColor.A, selectedColor.R, selectedColor.G, selectedColor.B));
                BackColor.Value = brush;

            }
        }

    }
}
