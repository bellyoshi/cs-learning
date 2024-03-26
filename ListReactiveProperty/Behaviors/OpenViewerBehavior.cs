using ListReactiveProperty.Windows;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ListReactiveProperty.Behaviors
{
    internal class OpenViewerBehavior : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            var dispacher = new Utils.WindowDispacher(App.Container);
            dispacher.ShowViewerWindow();

        }
    }


}
