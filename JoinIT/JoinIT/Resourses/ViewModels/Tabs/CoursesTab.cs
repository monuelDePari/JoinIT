namespace JoinIT.Resourses.ViewModels.Tabs
{
    using JoinIT.Resourses.ViewModels.Instructions;
    using System;
    using System.Windows.Input;

    public abstract class CoursesTab : ICoursesTab
    {
        public string TabName { get; set; }

        public ICommand CloseCommand { get; }

        public event EventHandler CloseRequested;
        public CoursesTab()
        {
            CloseCommand = new RelativeCommand(p => CloseRequested?.Invoke(this, EventArgs.Empty));
        }
    }
}
