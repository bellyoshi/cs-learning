using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM2;
 public class ViewModelBase : INotifyPropertyChanged
{
    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public PropertySetter PropertySetter { get; private set; }
    #endregion

    private int counter;
    public int Counter
    {
        get => counter;
        set => PropertySetter.Set(ref counter, value);
    }

    public Command UpCommand { get; private set; }
    public Command DownCommand { get; private set; }

    public ViewModelBase()
    {
        PropertySetter = new PropertySetter(this, OnPropertyChanged);

    }
}

