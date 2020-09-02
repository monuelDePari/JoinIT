namespace JoinIT.Resources.ViewModels
{
    using JoinIT.Resources.Utilities;
    using JoinIT.Resources.Views;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class StartupViewModel : INotifyPropertyChanged
    {
        #region Fields
        private RelativeCommand _openNewWindowCommand;
        #endregion

        #region Constructors
        public StartupViewModel()
        {
            OpenNewWindowCommand = new RelativeCommand(OpenNewLanguageWindow);
        }
        #endregion

        #region Methods
        private void OpenNewLanguageWindow(object arg)
        {
            LanguageView languageTabView = new LanguageView();
            languageTabView.Show();
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
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string info = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
