using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace WpfApp13;
public class SliderClickMoveBehavior : Behavior<Slider>
{
    protected override void OnAttached()
    {
        base.OnAttached();
        this.AssociatedObject.PreviewMouseLeftButtonDown += OnPreviewMouseLeftButtonDown;
    }

    protected override void OnDetaching()
    {
        this.AssociatedObject.PreviewMouseLeftButtonDown -= OnPreviewMouseLeftButtonDown;
        base.OnDetaching();
    }

    private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var slider = sender as Slider;
        if (slider == null)
        {
            return;
        }
        var point = e.GetPosition(slider);
        double value = (point.X / slider.ActualWidth) * (slider.Maximum - slider.Minimum) + slider.Minimum;

        // DataContextをViewModelとして取得し、RequiredValueを更新します。
        if (slider.DataContext is SliderViewModel viewModel)
        {
            viewModel.RequiredValue.Value = value;
            slider.Value = value;
        }

        e.Handled = true;
    }

}
