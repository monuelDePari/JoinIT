namespace JoinIT.Resourses.ViewModels
{
    using System;
    using System.Windows.Input;
    class RelativeCommand : ICommand
    {
        private readonly Action<object> actionCommand;
        private readonly Predicate<object> predicateCommand;

        public RelativeCommand(Action<object> action) : this(action, null) { }

        public RelativeCommand(Action<object> action, Predicate<Object> predicate)
        {
            actionCommand = action;
            predicateCommand = predicate;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return predicateCommand == null || predicateCommand(parameter);
        }

        public void Execute(object parameter)
        {
            actionCommand(parameter);
        }
    }
}
