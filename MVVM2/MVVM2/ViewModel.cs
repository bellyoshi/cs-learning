using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace MVVM2;

public class ViewModel : ViewModelBase
{
    public event PropertyChangedEventHandler PropertyChanged;
    public int Counter { get; set; } 
    
    public Command UpCommand { get; private set; }
    public Command DownCommand { get; private set; }

    public ViewModel()
    {
        var observeCounter = PropertySetter.ObserveChanged(nameof(Counter));

        UpCommand = observeCounter.Select(_ => Counter < 10).ToCommand(() => Counter++);
        DownCommand = observeCounter.Select(_ => Counter > 0).ToCommand(() => Counter--);
        
 
    }
}
