using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OpenWindowSample.Behaviors
{
    internal class DependencyObjectOpenWindowBehavior : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            // 新しいWindowを作成・表示
            var newWindow = new MainWindow();
            newWindow.Show();
        }
    }
}
