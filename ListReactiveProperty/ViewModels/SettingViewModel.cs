using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListReactiveProperty.Models;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;


namespace ListReactiveProperty.ViewModels
{
    internal class SettingViewModel
    {
        //back color
        public ReactiveProperty<System.Drawing.Color> BackColor { get; }

        private readonly ThatModel _thatModel = ThatModel.GetInstance();

        public SettingViewModel()
        {
            BackColor = _thatModel.ToReactivePropertyAsSynchronized(x => x.BackColor);
        }

    }
}
