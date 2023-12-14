using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;
using System.Reactive.Linq;

namespace MyFirstReactiveProperty.ViewModels
{
    internal class ViewModel
    {
        public ReactiveProperty<string> InputValue { get; }
        public ReactiveProperty<string?> OutputValue { get; }

        public ViewModel()
        {
            InputValue = new ReactiveProperty<string>("");
            OutputValue = InputValue.Select(x => x.ToUpper()).ToReactiveProperty();
        }
    }
}
