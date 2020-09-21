using System.Windows;
using Prism.Events;

namespace JoinIT.Resources.ViewModels
{
    using Utilities;
    using System;

    public class StartupViewModel : ITBaseViewModel
    {
        #region Fields

        private int _selectedTabIndex;
        private RelativeCommand _openLanguageWindowCommand;
        private RelativeCommand _openCoursesWindowCommand;
        private static IApplicationCommands _applicationCommands;
        private static RelativeCommand _deleteFromDataGrid;
        private IEventAggregator _deleteFromUserControlDataGridEventAggregator;

        #endregion

        #region Constructors

        public StartupViewModel(IApplicationCommands applicationCommands, IEventAggregator eventAggregator)
        {
            ApplicationCommands = applicationCommands;
            OpenLanguageWindowCommand = new RelativeCommand(OnOpenLanguageWindow, OpenLanguageWindowCommand_CanExecute);
            OpenCoursesWindowCommand = new RelativeCommand(OnOpenCoursesWindow, OpenCoursesWindowCommand_CanExecute);
            DeleteFromDataGrid = new RelativeCommand(OnDeleteCourses);

            _deleteFromUserControlDataGridEventAggregator = eventAggregator;
        }

        #endregion

        #region Methods

        private void OnDeleteCourses(object obj)
        {
            _deleteFromUserControlDataGridEventAggregator.GetEvent<DeleteItemFromUserControlDataGridEvent>().Publish();
        }

        private void OnOpenLanguageWindow(object sender)
        {
            var handler = OpenLanguageWindowEventHandler;
            if (handler != null)
            {
                handler(null, EventArgs.Empty);
            }
        }

        private void OnOpenCoursesWindow(object sender)
        {
            var handler = OpenCoursesWindowEventHandler;
            if (handler != null)
            {
                handler(null, EventArgs.Empty);
            }
        }

        public bool OpenCoursesWindowCommand_CanExecute()
        {
            return OpenCoursesWindowEventHandler != null && !IsLoading;
        }

        public bool OpenLanguageWindowCommand_CanExecute()
        {
            return OpenLanguageWindowEventHandler != null && !IsLoading;
        }
        #endregion

        #region Properties
        public int SelectedTabIndex
        {
            get
            {
                return _selectedTabIndex;
            }
            set
            {
                _selectedTabIndex = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region AttachedProperties

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.RegisterAttached("Content", typeof(object), 
                typeof(StartupViewModel), new PropertyMetadata());

        public static object GetContent(DependencyObject obj)
        {
            return obj.GetValue(ContentProperty);
        }

        public static void SetContent(DependencyObject obj, object value)
        {
            obj.SetValue(ContentProperty, value);
        }

        #endregion

        #region Commands

        public IApplicationCommands ApplicationCommands
        {
            get
            {
                return _applicationCommands;
            }
            set
            {
                _applicationCommands = value;
                OnPropertyChanged();
            }
        }

        public RelativeCommand OpenLanguageWindowCommand
        {
            get
            {
                return _openLanguageWindowCommand;
            }
            set
            {
                _openLanguageWindowCommand = value;
                OnPropertyChanged();
            }
        }

        public RelativeCommand OpenCoursesWindowCommand
        {
            get
            {
                return _openCoursesWindowCommand;
            }
            set
            {
                _openCoursesWindowCommand = value;
                OnPropertyChanged();
            }
        }

        public RelativeCommand DeleteFromDataGrid
        {
            get
            {
                return _deleteFromDataGrid;
            }
            set
            {
                _deleteFromDataGrid = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Events

        public event EventHandler OpenLanguageWindowEventHandler;
        public event EventHandler OpenCoursesWindowEventHandler;

        #endregion
    }
}
