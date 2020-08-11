namespace JoinIT.Resourses.ViewModels.Instructions
{
    using System;
    using System.Windows.Input;
    interface ICoursesTab
    {
        string TabName { get; set; }
        ICommand CloseCommand { get; }
        event EventHandler CloseRequested;
    }
}
