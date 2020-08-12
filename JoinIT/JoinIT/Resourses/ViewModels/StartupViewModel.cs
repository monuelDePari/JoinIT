namespace JoinIT.Resourses.ViewModels
{
    using JoinIT.Resourses.ViewModels.Instructions;
    using JoinIT.Resourses.ViewModels.Tabs;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Windows.Input;
    class StartupViewModel
    {
        public StartupViewModel()
        {
            NewCoursesTabCommand = new RelativeCommand(p => NewCoursesTab());
            CoursesTabs = new ObservableCollection<ICoursesTab>();

            CoursesTabs.CollectionChanged += CoursesTabsCollectionChanged;
        }
        public ICommand NewCoursesTabCommand { get; private set; }
        public ObservableCollection<ICoursesTab> CoursesTabs { get; private set; }
        private void NewCoursesTab()
        {
            CoursesTabs.Add(new CourseTab());
        }

        private void CoursesTabsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ICoursesTab coursesTab;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    coursesTab = (ICoursesTab)e.NewItems[0];
                    coursesTab.CloseRequested += OnTabCloseRequested;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    coursesTab = (ICoursesTab)e.OldItems[0];
                    coursesTab.CloseRequested -= OnTabCloseRequested;
                    break;
            }
        }

        private void OnTabCloseRequested(object sender, EventArgs e)
        {
            CoursesTabs.Remove((ICoursesTab)sender);
        }
    }
}
