namespace JoinIT.Resources.ViewModels
{
    using JoinIT.Resources.Utilities;
    using JoinIT.Resources.ViewModels.TabsViewModels;
    using System;

    public class StartupViewModel : ITBaseTabViewModel
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
        private void OnOpenNewLanguageWindow(object o)
        {
            var handler = OpenWindowEventHandler;
            if (handler != null)
            {
                handler(null, null);
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
