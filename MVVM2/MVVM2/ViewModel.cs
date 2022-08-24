using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace MVVM2;

public class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public ReactiveProperty<int> Counter { get; } = new ReactiveProperty<int>();

    public ReactiveCommand UpCommand { get; private set; }
    public ReactiveCommand DownCommand { get; private set; }

    public ViewModel()
    {
        UpCommand = Counter.Select(_ => Counter.Value < 10).ToReactiveCommand();
        UpCommand.Subscribe(() => Counter.Value++);
        DownCommand = Counter.Select(_ => Counter.Value > 0).ToReactiveCommand();
        DownCommand.Subscribe(() => Counter.Value--);
    }
}
