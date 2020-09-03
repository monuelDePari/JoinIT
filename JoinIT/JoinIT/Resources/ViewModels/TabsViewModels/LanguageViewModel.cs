namespace JoinIT.Resources.ViewModels.TabsViewModels
{
    using JoinIT.Properties;
    using JoinIT.Resources.Utilities;
    using Repositories.Instructions;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Resources.ITConstants;
    using System.Linq;

    public class LanguageViewModel : ITBaseTabViewModel
    {
        #region Fields
        private KeyValuePair<string, string> _languagesKeyValuePair;
        private Dictionary<string, string> _languages;
        #endregion

        #region Constructors
        public LanguageViewModel(ICoursesRepository coursesRepository) : base(coursesRepository)
        {
            Languages = new Dictionary<string, string>()
            {
                { Resources.English, ITConstants.English },
                { Resources.Ukrainian, ITConstants.Ukrainian }
            };

            LanguagesKeyValuePair = new KeyValuePair<string, string>(
                Languages.FirstOrDefault(x => x.Value == Settings.Default.LanguageSetting).Key, Settings.Default.LanguageSetting);
        }

        #endregion

        #region Methods


        public void LanguageTabViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == this.GetPropertyName(p => p.LanguagesKeyValuePair))
            {
                Settings.Default.LanguageSetting = LanguagesKeyValuePair.Value;
                Settings.Default.Save();

                var handler = RestartAppEvenHandler;
                if (handler != null)
                {
                    handler(null, null);
                }
            }
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

        public event EventHandler RestartAppEvenHandler;
    }
}
