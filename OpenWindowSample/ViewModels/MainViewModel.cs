using OpenWindowSample.Behaviors;
using Reactive.Bindings;
using System;

namespace OpenWindowSample.ViewModels
{
    public class MainViewModel : IWindowRequester
    {
        public event EventHandler? WindowRequested;
        public ReactiveCommand OpenNewWindowCommand { get; }

        public MainViewModel()
        {
            OpenNewWindowCommand = new ReactiveCommand();
            OpenNewWindowCommand.Subscribe(_ => RequestNewWindow());
        }

        private void RequestNewWindow()
        {
            WindowRequested?.Invoke(this, new());
        }
    }
}
