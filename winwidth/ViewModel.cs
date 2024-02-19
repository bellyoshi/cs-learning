using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;

namespace winwidth
{
    internal class ViewModel
    {
        //reactive width
        public ReactiveProperty<double> Width { get; } = new ReactiveProperty<double>(640);

        public ReactiveProperty<string> MyTextProperty { get; }

        internal ViewModel()
        {
            MyTextProperty = new ReactiveProperty<string>("初期値");
        }
    }
}
