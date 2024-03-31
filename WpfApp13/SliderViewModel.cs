using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;

namespace WpfApp13
{
    interface ISliderViewModel
    {
        public ReactiveProperty<double> RequiredValue { get; }
    }
    public class SliderViewModel : ISliderViewModel
    {
        public ReactiveProperty<double> RequiredValue { get; } = new ();



        public SliderViewModel()
        {
            RequiredValue.Subscribe(value =>
            {

                Debug.WriteLine($"ここで処理: {value}");

            });


        }
    }
}
