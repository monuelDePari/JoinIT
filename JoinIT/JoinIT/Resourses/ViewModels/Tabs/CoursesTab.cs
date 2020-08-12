namespace JoinIT.Resourses.ViewModels.Tabs
{
    using JoinIT.Resourses.ViewModels.Instructions;
    using System;
    using System.Windows.Input;

    public abstract class CoursesTab : ICoursesTab
    {
        public string TabName { get; set; }

        public ICommand CloseCommand { get; private set; }

        public event EventHandler CloseRequested;
        public CoursesTab()
        {
            CloseCommand = new RelativeCommand(p => OnCloseExecuted());
        }

        private void OnCloseExecuted()
        {
            var handler = CloseRequested;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
