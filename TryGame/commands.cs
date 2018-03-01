using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TryGame
{
    public class Command : ICommand
    {
        private Action _action = null;
        private bool _canExecute = false;

        public event EventHandler CanExecuteChanged;

        public Command(Action action, bool canExecute = true)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }
        public void Execute(object parameter)
        {
            _action();
        }
    }
}
