using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListReactiveProperty.ViewModels
{
    class PageNumberViewModel
    {
        public ReactiveProperty<int> PageCount { get; } = new();
        public ReactiveProperty<int> CurrentPage { get; } = new();
    }
}
