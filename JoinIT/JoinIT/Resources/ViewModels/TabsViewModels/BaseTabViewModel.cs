namespace JoinIT.Resources.ViewModels.TabsViewModels
{
    using Utilities.Commands;
    using Utilities.Commands.Instructions;
    using Utilities.Extensions;
    using Prism.Events;
    using Utilities;
    using Models;
    using Repositories.Instructions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class BaseTabViewModel : ITBaseViewModel
    {
        #region Fields
        private string _tabName;
        public CourseInfoModel Course;
        private KeyValuePair<string, string> _courseInfoModelKeyValuePair;
        private RelativeCommand _updateCommand;
        private Dictionary<string, string> _courseInfoModelsDictionary;
        private CourseInfoModel _selectedCourseModel;

        private IEventAggregator _eventAggregator;
        private ICollection<CourseInfoModel> _courseInfoModels;
        private ICollection<object> _selectedCoursesInfoModels;
        protected ICoursesRepository CoursesRepository;
        private readonly IApplicationCommands _applicationCommands;
        #endregion

        #region Constructors
        public BaseTabViewModel(ICoursesRepository coursesRepository, IApplicationCommands applicationCommands, IEventAggregator eventAggregator) : this()
        {
            SelectedCoursesInfoModels = new List<object>();
            SelectedCourseModel = new CourseInfoModel();
            Course = new CourseInfoModel();

            CoursesRepository = coursesRepository;
            _applicationCommands = applicationCommands;
            _eventAggregator = eventAggregator;

            UpdateCommand = new RelativeCommand(OnEditExecute);
        }

        public BaseTabViewModel()
        {
            TextChangedCommand = new AsyncCommand(OnTextChangedAsync);
            SelectedDateChangedCommand = new AsyncCommand(OnSelectedDateChangedAsync);
            DeleteSelectedCoursesCommand = new AsyncCommand(OnDeletedCoursesChangedAsync, OnDeletedCoursesChangedAsync_CanExecute);
            SelectedCourseChangedCommand = new RelativeCommand(OnSelectedCourseChanged);
            SelectedCoursesChangedCommand = new RelativeCommand(OnSelectedCoursesChangedAsync);
        }
        #endregion

        #region Methods

        public override void OnLoaded()
        {
            base.OnLoaded();

            _applicationCommands.UpdateAllCommand.RegisterCommand(UpdateCommand);

            _eventAggregator.GetEvent<DeleteItemFromUserControlDataGridEvent>().Subscribe(OnDeletedCourses);
        }

        public override void OnUnloaded()
        {
            base.OnUnloaded();

            _applicationCommands.UpdateAllCommand.UnregisterCommand(UpdateCommand);

            _eventAggregator.GetEvent<DeleteItemFromUserControlDataGridEvent>().Unsubscribe(OnDeletedCourses);
        }

        private async void OnDeletedCourses()
        {
            await OnDeletedCoursesChangedAsync(null);
        }

        private void OnEditExecute(object obj)
        {
            var handler = UpdateCourseHandler;
            if (handler != null)
            {
                handler(SelectedCourseModel, EventArgs.Empty);
            }
        }

        private void OnSelectedCoursesChangedAsync(object obj)
        {
            if (obj != null)
            {
                SelectedCoursesInfoModels = obj as ICollection<object>;
            }
        }

        private async Task OnDeletedCoursesChangedAsync(object arg)
        {
            List<CourseInfoModel> selectedCourseInfoModels = new List<CourseInfoModel>();
            foreach (var course in SelectedCoursesInfoModels)
            {
                selectedCourseInfoModels.Add((CourseInfoModel)course);
            }
            CourseInfoModels = CourseInfoModels.Except(selectedCourseInfoModels).ToList();
            await RunTaskAsync(CoursesRepository.RemoveRangeAsync(selectedCourseInfoModels));
        }

        private bool OnDeletedCoursesChangedAsync_CanExecute(object obj)
        {
            return SelectedCoursesInfoModels != null && !IsLoading;
        }

        private async Task OnTextChangedAsync(object arg)
        {
            if (arg is string)
            {
                if (CourseInfoModelKeyValuePair.Key == Course.GetPropertyName(t => t.CourseName))
                {
                    CourseInfoModels = await RunTaskAsync(CoursesRepository.FindAsync(p => p.CourseName.Contains((string)arg) && p.CourseName == _tabName));
                }
                else if (CourseInfoModelKeyValuePair.Key == Course.GetPropertyName(t => t.AuthorName))
                {
                    CourseInfoModels = await RunTaskAsync(CoursesRepository.FindAsync(p => p.AuthorName.Contains((string)arg) && p.CourseName == _tabName));
                }
            }
            else
            {
                await LoadDataAsync(_tabName);
            }
        }

        private async Task OnSelectedDateChangedAsync(object arg)
        {
            DateTime date;
            if (arg != null && DateTime.TryParse(arg.ToString(), out date))
            {
                if (CourseInfoModelKeyValuePair.Key == Course.GetPropertyName(t => t.StartDate))
                {
                    CourseInfoModels = await RunTaskAsync(CoursesRepository.FindAsync(p => p.StartDate >= date && p.CourseName == _tabName));
                }
                else if (CourseInfoModelKeyValuePair.Key == Course.GetPropertyName(t => t.EndDate))
                {
                    CourseInfoModels = await RunTaskAsync(CoursesRepository.FindAsync(p => p.EndDate >= date && p.CourseName == _tabName));
                }
            }
        }

        private void OnSelectedCourseChanged(object arg)
        {
            var handler = UpdateCourseHandler;
            if (handler != null)
            {
                handler(arg, EventArgs.Empty);
            }
        }

        public Dictionary<string, string> ConvertPropertiesListToDictionary()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            var courseInfoModelsProperties = typeof(CourseInfoModel).GetProperties();

            for (int i = 0; i < courseInfoModelsProperties.Length; i++)
            {
                if (courseInfoModelsProperties[i].Name.Equals(Course.GetPropertyName(t => t.Error)) || courseInfoModelsProperties[i].Name.Equals(Course.GetPropertyName(t => t.Id)) || courseInfoModelsProperties[i].Name.Equals("Item"))
                {
                    continue;
                }
                System.Reflection.PropertyInfo item = courseInfoModelsProperties[i];
                keyValuePairs.Add(item.Name, Regex.Replace(item.Name, "([a-z])([A-Z])", "$1 $2"));
            }

            return keyValuePairs;
        }

        public async Task LoadDataAsync(string tabName)
        {
            _tabName = tabName;
            
            if (CourseInfoModels == null)
            {
                CourseInfoModels = await RunTaskAsync(CoursesRepository.FindAsync(t => t.CourseName == tabName));
            }

            if (CourseInfoModelsDictionary == null)
            {
                CourseInfoModelsDictionary = ConvertPropertiesListToDictionary();
            }
        }
        #endregion

        #region Properties

        public CourseInfoModel SelectedCourseModel
        {
            get
            {
                return _selectedCourseModel;
            }
            set
            {
                _selectedCourseModel = value;
                OnPropertyChanged();
            }
        }
        public CourseInfoModel CourseModel
        {
            get
            {
                return Course;
            }
            set
            {
                Course = value;
                OnPropertyChanged();
            }
        }
        public ICollection<CourseInfoModel> CourseInfoModels
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
        public ICollection<object> SelectedCoursesInfoModels
        {
            get
            {
                return _selectedCoursesInfoModels;
            }
            set
            {
                _selectedCoursesInfoModels = value;
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

        public RelativeCommand UpdateCommand
        {
            get
            {
                return _updateCommand;
            }
            set
            {
                _updateCommand = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        private AsyncCommand _textChangedCommand;
        private AsyncCommand _selectedDateChangedCommand;
        private AsyncCommand _deleteSelectedCoursesCommand;
        private RelativeCommand _selectedCoursesChangedCommand;
        private RelativeCommand _selectedCourseChangedCommand;

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

        public AsyncCommand DeleteSelectedCoursesCommand
        {
            get
            {
                return _deleteSelectedCoursesCommand;
            }
            set
            {
                _deleteSelectedCoursesCommand = value;
                OnPropertyChanged();
            }
        }

        public RelativeCommand SelectedCoursesChangedCommand
        {
            get
            {
                return _selectedCoursesChangedCommand;
            }
            set
            {
                _selectedCoursesChangedCommand = value;
                OnPropertyChanged();
            }
        }

        public RelativeCommand SelectedCourseChangedCommand
        {
            get
            {
                return _selectedCourseChangedCommand;
            }
            set
            {
                _selectedCourseChangedCommand = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Events
        public event EventHandler UpdateCourseHandler;
        #endregion
    }
}
