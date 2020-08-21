namespace JoinIT.Resources.ViewModels.TabsViewModels
{
    using Models;
    using Repositories.Instructions;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class ITBaseTabViewModel : INotifyPropertyChanged
    {
        #region Fields
        protected ICoursesRepository CoursesRepository;

        private IEnumerable<CourseInfoModel> _courseInfoModels;
        private Dictionary<string, string> _courseInfoModelsDictionary;
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
        #endregion

        #region Constructors
        public ITBaseTabViewModel(ICoursesRepository coursesRepository)
        {
            CoursesRepository = coursesRepository;
        }
        public ITBaseTabViewModel() { }
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
            if (CourseInfoModels == null)
            {
                CourseInfoModels = await CoursesRepository.FindAsync(t => t.CourseName == tabName);
            }

            if(CourseInfoModelsDictionary == null)
            {
                CourseInfoModelsDictionary = CourseInfoModelsListOfPropertiesToDictionary();
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