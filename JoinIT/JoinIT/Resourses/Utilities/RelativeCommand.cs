namespace JoinIT.Resourses.Utilities
{
    using System;
    using System.Windows.Input;
    public class RelativeCommand : ICommand
    {
        #region Fields
        private readonly Action<object> _actionCommand;
        private readonly Predicate<object> _predicateCommand;
        #endregion

        #region Constructors
        public RelativeCommand(Action<object> action) : this(action, null) { }

        public RelativeCommand(Action<object> action, Predicate<Object> predicate)
        {
            _actionCommand = action;
            _predicateCommand = predicate;
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
            return _predicateCommand == null || _predicateCommand(parameter);
        }

        public void Execute(object parameter)
        {
            _actionCommand(parameter);
        }
        #endregion
    }
}
