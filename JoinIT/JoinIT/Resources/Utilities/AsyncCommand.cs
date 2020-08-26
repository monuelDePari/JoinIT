namespace JoinIT.Resources.Utilities
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;


    public class AsyncCommand : IAsyncCommand
    {
        #region Fields
        private readonly Func<object, Task> _command;
        private readonly Predicate<object> _predicate;
        #endregion

        #region Constructors
        public AsyncCommand(Func<object, Task> command)
        {
            _command = command;
        }
        public AsyncCommand(Func<object, Task> command, Predicate<object> predicate)
        {
            _command = command;
            _predicate = predicate;
        }
        #endregion

        #region Methods
        public bool CanExecute(object parameter)
        {
            return _predicate == null || _predicate(parameter);
        }
        public async Task ExecuteAsync(object parameter)
        {
            await _command.Invoke(parameter);
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
        #endregion
    }
}
