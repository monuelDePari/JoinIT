using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JoinIT.Resourses.Utilities
{
    public class AsyncCommand : IAsyncCommand
    {
        private readonly Func<Task> _command;
        private readonly Predicate<object> _predicate;
        public AsyncCommand(Func<Task> command)
        {
            _command = command;
        }
        public AsyncCommand(Func<Task> command, Predicate<object> predicate)
        {
            _command = command;
            _predicate = predicate;
        }
        public bool CanExecute(object parameter)
        {
            return _predicate == null || _predicate(parameter);
        }
        public Task ExecuteAsync(object parameter)
        {
            return _command();
        }
        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        protected void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
