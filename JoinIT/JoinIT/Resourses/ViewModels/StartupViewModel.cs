namespace JoinIT.Resourses.ViewModels
{
    using JoinIT.Resourses.ViewModels.Instructions;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    class StartupViewModel
    {
        public StartupViewModel()
        {
            NewCoursesTabCommand = new RelativeCommand(p => NewCoursesTab());
            CoursesTabs = new ObservableCollection<ICoursesTab>();
        }
        public ICommand NewCoursesTabCommand { get; }
        public ICollection<ICoursesTab> CoursesTabs { get; }
        private void NewCoursesTab()
        {

        }
    }
}
