namespace JoinIT.Resources.ViewModels
{
    using JoinIT.Resources.Utilities;
    using System;

    public class StartupViewModel : ITBaseViewModel
    {
        #region Fields
        private RelativeCommand _openLanguageWindowCommand;
        private RelativeCommand _openCoursesWindowCommand;
        #endregion

        #region Constructors
        public StartupViewModel()
        {
            OpenLanguageWindowCommand = new RelativeCommand(OnOpenLanguageWindow, OpenLanguageWindowCommand_CanExecute);
            OpenCoursesWindowCommand = new RelativeCommand(OnOpenCoursesWindow, OpenCoursesWindowCommand_CanExecute);
        }
        #endregion

        #region Methods
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

        #region Commands
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
        #endregion

        #region Events
        public event EventHandler OpenLanguageWindowEventHandler;
        public event EventHandler OpenCoursesWindowEventHandler;
        #endregion
    }
}
