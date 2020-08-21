using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinIT.Resources.Utilities
{
    public class AsyncCommandWithParameter
    {
        private Func<object, Task> _execute;
        private Func<object, bool> _canExecute;

        public AsyncCommandWithParameter(Func<object, Task> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }


        public bool CanExecute(object parameter = null)
        {
            return _canExecute.Invoke(parameter);
        }

        public Task ExecuteAsync(object parameter = null)
        {
            return _execute.Invoke(parameter);
        }

        public async void Execute(object parameter = null)
        {
            await ExecuteAsync(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
