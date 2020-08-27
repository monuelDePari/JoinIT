namespace JoinIT.Resources.ViewModels.TabsViewModels
{
    using JoinIT.Resources.Utilities;
    using Models;
    using Repositories;
    using Repositories.Instructions;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Windows;

    public class ITBaseTabViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _tabName;
        private bool _isLoading;
        private CourseInfoModel _courseInfoModel;
        private KeyValuePair<string, string> _courseInfoModelKeyValuePair;
        private IEnumerable<CourseInfoModel> _courseInfoModels;
        private Dictionary<string, string> _courseInfoModelsDictionary;

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

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public ITBaseTabViewModel(ICoursesRepository coursesRepository) : this()
        {
            CoursesRepository = coursesRepository;
            _courseInfoModel = new CourseInfoModel();
        }
        public ITBaseTabViewModel()
        {
            TextChangedCommand = new AsyncCommand(OnTextChangedAsync);
            SelectedDateChangedCommand = new AsyncCommand(OnSelectedDateChangedAsync);
        }
        #endregion

        #region Methods

        public async Task<List<T>> RunTaskAsync<T>(Expression<Func<T, bool>> expression)
        {
            try
            {
                IsLoading = true;
                List<T> resultList = new List<T>();
                if (expression is Expression<Func<CourseInfoModel, bool>>)
                {
                    var courseExpression = expression as Expression<Func<CourseInfoModel, bool>>;
                    resultList = await CoursesRepository.FindAsync(courseExpression) as List<T>;
                }
                return resultList;
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task OnTextChangedAsync(object arg)
        {
            if (arg is string)
            {
                if (CourseInfoModelKeyValuePair.Key == _courseInfoModel.GetPropertyName(t => t.CourseName))
                {
                    CourseInfoModels = await RunTaskAsync<CourseInfoModel>(p => p.CourseName.Contains((string)arg) && p.CourseName == _tabName);
                }
                else if (CourseInfoModelKeyValuePair.Key == _courseInfoModel.GetPropertyName(t => t.AuthorName))
                {
                    CourseInfoModels = await RunTaskAsync<CourseInfoModel>(p => p.AuthorName.Contains((string)arg) && p.CourseName == _tabName);
                }
            }
            else
            {
                await LoadDataAsync(_tabName);
            }
        }

        private async Task OnSelectedDateChangedAsync(object arg)
        {
            if (arg is DateTime)
            {
                if (CourseInfoModelKeyValuePair.Key == _courseInfoModel.GetPropertyName(t => t.StartDate))
                {
                    CourseInfoModels = await RunTaskAsync<CourseInfoModel>(p => p.StartDate >= (DateTime)arg && p.CourseName == _tabName);
                }
                else if (CourseInfoModelKeyValuePair.Key == _courseInfoModel.GetPropertyName(t => t.EndDate))
                {
                    CourseInfoModels = await RunTaskAsync<CourseInfoModel>(p => p.EndDate >= (DateTime)arg && p.CourseName == _tabName);
                }
            }
        }

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
            _tabName = tabName;

            if (CourseInfoModels == null)
            {
                CourseInfoModels = await RunTaskAsync<CourseInfoModel>(t => t.CourseName == tabName);
            }

            if (CourseInfoModelsDictionary == null)
            {
                CourseInfoModelsDictionary = CourseInfoModelsListOfPropertiesToDictionary();
            }
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