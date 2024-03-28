using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListReactiveProperty.Models;

internal class ScreenModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    //singleton
    private static readonly ScreenModel _instance = new();
    internal static ScreenModel GetInstance()
    {
        return _instance;
    }






    private bool _isFullScreen = true;
    public bool IsFullScreen
    {
        get => _isFullScreen;
        set
        {
            _isFullScreen = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsFullScreen)));
        }
    }

    private int screenIndex = 0;
    public int ScreenIndex
    {
        get => screenIndex;
        set
        {
            screenIndex = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ScreenIndex)));
        }
    }
    
}
