using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp2.Model
{
    internal class ClickCount : ObservableObject
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
            set => SetProperty(ref _clickText, value);
        }
    }
}
