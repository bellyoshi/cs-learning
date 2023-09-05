using MauiApp2.Model;
using MauiApp2.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.ViewModel
{
    internal class MainPageViewModel
    {
        public string Text { get; set; } = "Initial Text";

        public ClickCount ClickCount { get; set; } = new();

        public AddCounterCommand AddCounterCommand { get; set; }

        public MainPageViewModel()
        {
            AddCounterCommand = new AddCounterCommand(() =>
            {
                ClickCount.Count++;
            });
        }
    }
}
