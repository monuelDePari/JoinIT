namespace JoinIT.Resources.ViewModels.TabsViewModels
{
    using JoinIT.Resources.Utilities;
    using Models;
    using Repositories.Instructions;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Windows;

    public class ITBaseTabViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _tabName;
        private Visibility _visibility;
        private bool _isLoaded;
        private CourseInfoModel _courseInfoModel;
        private KeyValuePair<string, string> _courseInfoModelKeyValuePair;
        private IEnumerable<CourseInfoModel> _courseInfoModels;
        private Dictionary<string, string> _courseInfoModelsDictionary;
        private Visibility _spinnerVisibility;

        protected ICoursesRepository CoursesRepository;
        #endregion

        #region Properties
        public IEnumerable<CourseInfoModel> CourseInfoModels
        {
            get
            {
                return _courseInfoModels;
            }
            set
            {
                _courseInfoModels = value;
                OnPropertyChanged();
            }
        }
        public Dictionary<string, string> CourseInfoModelsDictionary
        {
            get
            {
                return _courseInfoModelsDictionary;
            }
            set
            {
                _courseInfoModelsDictionary = value;
                OnPropertyChanged();
            }
        }
        public KeyValuePair<string, string> CourseInfoModelKeyValuePair
        {
            get
            {
                return _courseInfoModelKeyValuePair;
            }
            set
            {
                _courseInfoModelKeyValuePair = value;
                OnPropertyChanged();
            }
        }
        public Visibility Visibility
        {
            get
            {
                return _visibility;
            }
            set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility SpinnerVisibility
        {
            get
            {
                return _spinnerVisibility;
            }
            set
            {
                _spinnerVisibility = value;
                OnPropertyChanged();
            }
        }
        public bool IsLoaded
        {
            get
            {
                return _isLoaded;
            }
            set
            {
                _isLoaded = value;

                if (!_isLoaded)
                {
                    Visibility = Visibility.Collapsed;
                    SpinnerVisibility = Visibility.Visible;
                }
                else
                {
                    Visibility = Visibility.Visible;
                    SpinnerVisibility = Visibility.Collapsed;
                }

                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public ITBaseTabViewModel(ICoursesRepository coursesRepository) : this()
        {
            CoursesRepository = coursesRepository;
            _courseInfoModel = new CourseInfoModel();
            Visibility = Visibility.Collapsed;
            SpinnerVisibility = Visibility.Collapsed;
        }
        public ITBaseTabViewModel()
        {
            TextChangedCommand = new AsyncCommand(OnTextChangedAsync);
            SelectedDateChangedCommand = new AsyncCommand(OnSelectedDateChangedAsync);
        }

        private async Task OnTextChangedAsync(object arg)
        {
            IsLoaded = false;

            if (arg is string)
            {
                if (CourseInfoModelKeyValuePair.Key == _courseInfoModel.GetPropertyName(t => t.CourseName))
                {
                    CourseInfoModels = await CoursesRepository.FindAsync(p => p.CourseName.Contains((string)arg) && p.CourseName == _tabName);
                }
                else if (CourseInfoModelKeyValuePair.Key == _courseInfoModel.GetPropertyName(t => t.AuthorName))
                {
                    CourseInfoModels = await CoursesRepository.FindAsync(p => p.AuthorName.Contains((string)arg) && p.CourseName == _tabName);
                }
            }
            else
            {
                await LoadDataAsync(_tabName);
            }

            IsLoaded = true;
        }

        private async Task OnSelectedDateChangedAsync(object arg)
        {
            IsLoaded = false;

            if (arg is DateTime)
            {
                if (CourseInfoModelKeyValuePair.Key == _courseInfoModel.GetPropertyName(t => t.StartDate))
                {
                    CourseInfoModels = await CoursesRepository.FindAsync(p => p.StartDate >= (DateTime)arg && p.CourseName == _tabName);
                }
                else if (CourseInfoModelKeyValuePair.Key == _courseInfoModel.GetPropertyName(t => t.EndDate))
                {
                    CourseInfoModels = await CoursesRepository.FindAsync(p => p.EndDate >= (DateTime)arg && p.CourseName == _tabName);
                }
            }

            IsLoaded = true;
        }
        #endregion

        #region Methods
        public Dictionary<string, string> CourseInfoModelsListOfPropertiesToDictionary()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            var courseInfoModelsProperties = typeof(CourseInfoModel).GetProperties();

            for (int i = 1; i < courseInfoModelsProperties.Length; i++)
            {
                System.Reflection.PropertyInfo item = courseInfoModelsProperties[i];
                keyValuePairs.Add(item.Name.ToString(), Regex.Replace(item.Name.ToString(), "([a-z])([A-Z])", "$1 $2"));
            }

            return keyValuePairs;
        }

        public async Task LoadDataAsync(string tabName)
        {
            IsLoaded = false;
            _tabName = tabName;

            if (CourseInfoModels == null)
            {
                CourseInfoModels = await CoursesRepository.FindAsync(t => t.CourseName == tabName);
            }

            if (CourseInfoModelsDictionary == null)
            {
                CourseInfoModelsDictionary = CourseInfoModelsListOfPropertiesToDictionary();
            }
            IsLoaded = true;
        }
        #endregion

        #region Commands
        private AsyncCommand _textChangedCommand;
        private AsyncCommand _selectedDateChangedCommand;

        public AsyncCommand TextChangedCommand
        {
            get
            {
                return _textChangedCommand;
            }
            set
            {
                _textChangedCommand = value;
                OnPropertyChanged();
            }
        }

        public AsyncCommand SelectedDateChangedCommand
        {
            get
            {
                return _selectedDateChangedCommand;
            }
            set
            {
                _selectedDateChangedCommand = value;
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