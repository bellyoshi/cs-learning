using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM2;

public class Command : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public PropertySetter PropertySetter { get; private set; }

    public Command(Action execute)
    {
        PropertySetter = new PropertySetter(this, OnPropertyChanged);
        this.execute = execute;
    }

    public Command(Action execute, bool canExecute)
        : this(execute)
    {
        CanExecute = canExecute;
    }

    public Command(Action execute, IObservable<bool> canExecute)
        : this(execute)
    {
        canExecute.Subscribe(a => CanExecute = a);
    }

    private Action execute;
    public void Execute()
    {
        if (!CanExecute) return;
        execute?.Invoke();
    }

    private bool canExecute;
    public bool CanExecute
    {
        get => canExecute;
        set => PropertySetter.Set(ref canExecute, value);
    }
}

public static class CommandExtension
{
    public static Command ToCommand(this IObservable<bool> source, Action execute = null)
    {
        return new Command(execute, source);
    }
}
