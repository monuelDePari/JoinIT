namespace JoinIT.Resourses.ViewModels.Instructions
{
    using System;
    using System.Windows.Input;
    interface ICoursesTab
    {
        ICommand CloseCommand { get; }
        event EventHandler CloseRequested;
    }
}
