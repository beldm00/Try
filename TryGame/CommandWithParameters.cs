using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TryGame
{
    public class CommandWithParameters : ICommand
    {
        private Action<string> _paramAction = null;
        private bool _canExecute = false;

        public event EventHandler CanExecuteChanged;

        public CommandWithParameters(Action<string> action, bool canExecute = true)
        {
            _paramAction = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }
        public void Execute(object parameter)
        {
            _paramAction((string)parameter);
        }
    }
}
