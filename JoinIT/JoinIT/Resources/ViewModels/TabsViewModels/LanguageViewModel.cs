namespace JoinIT.Resources.ViewModels.TabsViewModels
{
    using JoinIT.Properties;
    using JoinIT.Resources.ITLocalData;
    using JoinIT.Resources.Utilities;
    using Repositories.Instructions;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class LanguageViewModel : ITBaseTabViewModel
    {
        #region Fields
        private KeyValuePair<string, string> _languagesKeyValuePair;
        private Dictionary<string, string> _languages;
        #endregion

        #region Constructors
        public LanguageViewModel(ICoursesRepository coursesRepository) : base(coursesRepository)
        {
            Languages = LanguageInfo.Languages;
        }

        #endregion

        #region Methods
        private void LanguageTabViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == this.GetPropertyName(p => p.LanguagesKeyValuePair))
            {
                Settings.Default.LanguageSetting = LanguagesKeyValuePair.Value;
                Settings.Default.Save();
            }
        }
        public void SubscribePropertyChanged()
        {
            PropertyChanged += LanguageTabViewModelOnPropertyChanged;
        }
        public void DisposePropertyChanged()
        {
            PropertyChanged -= LanguageTabViewModelOnPropertyChanged;
        }
        #endregion

        #region Properties
        public KeyValuePair<string, string> LanguagesKeyValuePair
        {
            get
            {
                return _languagesKeyValuePair;
            }
            set
            {
                _languagesKeyValuePair = value;
                OnPropertyChanged();
            }
        }

        public Dictionary<string, string> Languages
        {
            get
            {
                return _languages;
            }
            set
            {
                _languages = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
