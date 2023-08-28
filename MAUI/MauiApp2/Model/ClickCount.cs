using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.Model
{
    internal class ClickCount : INotifyPropertyChanged
    {
        private int _count;

        public int Count
        {
            get => _count;
            set
            {
                if (value == 1)
                    ClickText = $"Clicked {value} time";
                else
                    ClickText = $"Clicked {value} times";

                _count = value;
            }
        }

        private string _clickText = "Click me";

        public string ClickText
        {
            get => _clickText;
            set => _ = SetField(ref _clickText, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
