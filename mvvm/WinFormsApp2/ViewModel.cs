using Reactive.Bindings;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace WinFormsApp2;

public class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public ReactiveProperty<int> Counter { get; } = new ReactiveProperty<int>();

    public ReactiveCommand UpCommand { get; private set; }
    public ReactiveCommand DownCommand { get; private set; }

    public ReactiveCommand MessageCommand { get; private set; }

    public ViewModel()
    {
        UpCommand = Counter.Select(_ => Counter.Value < 10).ToReactiveCommand();
        UpCommand.Subscribe(() => Counter.Value++);
        DownCommand = Counter.Select(_ => Counter.Value > 0).ToReactiveCommand();
        DownCommand.Subscribe(() => Counter.Value--);
        var commandSource = new Subject<bool>();
        MessageCommand = commandSource.ToReactiveCommand(true);
        MessageCommand.Subscribe(() => MessageBox.Show("Hello"));

    }
}


