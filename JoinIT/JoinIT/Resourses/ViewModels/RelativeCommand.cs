namespace JoinIT.Resourses.ViewModels
{
    using System;
    using System.Windows.Input;
    public class RelativeCommand : ICommand
    {
        #region fields
        private readonly Action<object> actionCommand;
        private readonly Predicate<object> predicateCommand;
        #endregion
        #region constructors
        public RelativeCommand(Action<object> action) : this(action, null) { }

        public RelativeCommand(Action<object> action, Predicate<Object> predicate)
        {
            actionCommand = action;
            predicateCommand = predicate;
        }
        #endregion
        #region events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion
        #region methods
        public bool CanExecute(object parameter)
        {
            return predicateCommand == null || predicateCommand(parameter);
        }
        #endregion
        public void Execute(object parameter)
        {
            actionCommand(parameter);
        }
    }
}
