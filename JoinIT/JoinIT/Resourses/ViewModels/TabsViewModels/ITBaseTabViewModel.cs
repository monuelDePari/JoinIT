namespace JoinIT.Resourses.ViewModels.TabsViewModels
{
    using JoinIT.Resourses.Converters;
    using Models;
    using Repositories.Instructions;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
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
        public async Task LoadDataAsync(string tabName)
        {
            if (CourseInfoModels == null)
            {
                CourseInfoModels = await CoursesRepository.FindAsync(t => t.CourseName == tabName);
                CourseInfoModelsDictionary = CoursesInfoModelsConverter.CourseInfoModelsListToDictionary(CourseInfoModels.ToList());
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