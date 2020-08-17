namespace JoinIT.Resourses.ViewModels.TabsViewModels
{
    using Models;
    using Repositories.Instructions;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public class ITBaseTabViewModel : INotifyPropertyChanged
    {
        #region Fields
        protected ICoursesRepository _coursesRepository;

        protected IEnumerable<CourseInfoModel> _courseInfoModels;
        #endregion

        #region Properties
        public bool IsLoaded { get; private set; }

        public IEnumerable<CourseInfoModel> CourseInfoModels
        {
            get
            {
                return _courseInfoModels;
            }
            set
            {
                _courseInfoModels = value;
                OnPropertyChanged("CourseInfoModels");
            }
        }
        #endregion

        #region Constructors
        public ITBaseTabViewModel(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
        #endregion

        #region Methods
        public async Task LoadDataAsync(string tabName)
        {
            if (!IsLoaded)
            {
                CourseInfoModels = await _coursesRepository.FindAsync(t => t.CourseName == tabName);
                IsLoaded = true;
            }
        }
        public async Task LoadDataAsync()
        {
            if (!IsLoaded)
            {
                CourseInfoModels = await _coursesRepository.GetAllAsync();
                IsLoaded = true;
            }
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string info = "")
        {
            if (PropertyChanged != null)
            {
                IsLoaded = false;
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
