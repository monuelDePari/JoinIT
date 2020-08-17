namespace JoinIT.Resourses.ViewModels
{
    using JoinIT.Resourses.ViewModels.Instructions;
    using JoinIT.Resourses.ViewModels.TabsViewModels;
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Windows.Input;
    public class StartupViewModel
    {
        #region Constructors
        public StartupViewModel()
        {
            NewCoursesTabCommand = new RelativeCommand(p => NewCoursesTab());
            CoursesTabs = new ObservableCollection<CoursesTabViewModel>();

            CoursesTabs.CollectionChanged += CoursesTabsCollectionChanged;
        }
        #endregion

        #region Commands
        public ICommand NewCoursesTabCommand { get; private set; }
        #endregion

        #region Collections
        public ObservableCollection<CoursesTabViewModel> CoursesTabs { get; private set; }
        #endregion

        #region Methods
        private void NewCoursesTab()
        {
            CoursesTabs.Add(new CoursesTabViewModel());
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
            if (sender.GetType() == typeof(ICoursesTab))
                CoursesTabs.Remove((CoursesTabViewModel)sender);
        }
        #endregion
    }
}
