using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp2.View
{
    internal class AddCounterCommand : ICommand
    {
        public AddCounterCommand(Action func)
        {
            this.func = func;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            func();
        }

        private Action func;

        public event EventHandler CanExecuteChanged;
    }
}
