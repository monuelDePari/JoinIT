namespace JoinIT.Resources.Utilities.Commands
{
    using System;
    using System.Windows.Input;

    public class RelativeCommand : ICommand
    {
        #region Fields
        private readonly Action<object> _actionCommand;
        private readonly Func<bool> _canExecuteCommand;
        #endregion

        #region Constructors
        public RelativeCommand(Action<object> action) : this(action, null) { }

        public RelativeCommand(Action<object> action, Func<bool> canExecuteCommand)
        {
            _actionCommand = action;
            _canExecuteCommand = canExecuteCommand;
        }
        #endregion

        #region Events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion

        #region Methods
        public bool CanExecute(object parameter)
        {
            if (_canExecuteCommand == null)
            {
                return true;
            }

            bool result = _canExecuteCommand.Invoke();
            return result;
        }

        public void Execute(object parameter)
        {
            _actionCommand(parameter);
        }
        #endregion
    }
}
