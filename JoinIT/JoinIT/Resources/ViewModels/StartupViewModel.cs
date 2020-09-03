namespace JoinIT.Resources.ViewModels
{
    using JoinIT.Resources.Utilities;
    using System;

    public class StartupViewModel : ITBaseViewModel
    {
        #region Fields
        private RelativeCommand _openNewWindowCommand;
        #endregion

        #region Constructors
        public StartupViewModel()
        {
            OpenNewWindowCommand = new RelativeCommand(OnOpenNewLanguageWindow);
        }
        #endregion

        #region Methods
        private void OnOpenNewLanguageWindow(object sender)
        {
            var handler = OpenWindowEventHandler;
            if (handler != null)
            {
                handler(null, EventArgs.Empty);
            }
        }
        #endregion

        #region Commands
        public RelativeCommand OpenNewWindowCommand
        {
            get
            {
                return _openNewWindowCommand;
            }
            set
            {
                _openNewWindowCommand = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Events
        public event EventHandler OpenWindowEventHandler;
        #endregion
    }
}
