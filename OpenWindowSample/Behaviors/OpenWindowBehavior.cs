using System;
using System.Windows;
using Microsoft.Xaml.Behaviors;
using OpenWindowSample.ViewModels;

namespace OpenWindowSample.Behaviors;

public class OpenWindowBehavior : Behavior<Window>
{
    protected override void OnAttached()
    {
        base.OnAttached();
        if (this.AssociatedObject.DataContext is IWindowRequester viewModel)
        {
            viewModel.WindowRequested += OnWindowRequested;
        }
    }

    protected override void OnDetaching()
    {
        if (this.AssociatedObject.DataContext is IWindowRequester viewModel)
        {
            viewModel.WindowRequested -= OnWindowRequested;
        }
        base.OnDetaching();
    }

    private void OnWindowRequested(object sender, EventArgs e)
    {
        var window = new MainWindow();

        window.DataContext = new MainViewModel();
        
        window.Show();
    }
}

public interface IWindowRequester
{
    event EventHandler WindowRequested;
}


