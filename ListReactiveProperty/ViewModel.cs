using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;
using System.Reactive.Linq;
using System.Configuration;

namespace ListReactiveProperty
{
    internal class ViewModel
    {
        public ObservableCollection<string> CheckInLog { get; } = [];
        public ReactiveCommand<string> CheckInCommand { get; } = new();
        public ReadOnlyReactiveProperty<string?> FileName { get; }

        public ViewModel()
        {
            this.FileName = CheckInCommand.ToReadOnlyReactiveProperty();
            CheckInCommand.Subscribe(name =>
            {
                if (string.IsNullOrEmpty(name)) return;
                CheckInLog.Add(name);
            });
        }



    }
}
