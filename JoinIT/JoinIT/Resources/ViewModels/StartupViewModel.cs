namespace JoinIT.Resources.ViewModels
{
    using JoinIT.Resources.Utilities;
    using JoinIT.Resources.Views;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class StartupViewModel : INotifyPropertyChanged
    {
        private RelativeCommand _openNewWindowCommand;

        public StartupViewModel()
        {
            OpenNewWindowCommand = new RelativeCommand(OpenNewLanguageWindow);
        }

        private void OpenNewLanguageWindow(object arg)
        {
            LanguageView languageTabView = new LanguageView();
            languageTabView.Show();
        }

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
