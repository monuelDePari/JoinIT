﻿namespace JoinIT.Resourses.ViewModels
{
    using System;
    using System.Windows.Input;
    class RelativeCommand : ICommand
    {
        private Action<object> action;
        private readonly Predicate<Object> predicate;

        public RelativeCommand(Action<Object> action) : this(action, null) { }

        public RelativeCommand(Action<Object> action, Predicate<Object> predicate)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action), @"You must specify an Action<T>.");
            this.predicate = predicate;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            if (this.predicate == null)
            {
                return true;
            }
            return this.predicate(parameter);
        }

        public void Execute()
        {
            Execute(null);
        }

        public void Execute(object parameter)
        {
            this.action(parameter);
        }
    }
}
