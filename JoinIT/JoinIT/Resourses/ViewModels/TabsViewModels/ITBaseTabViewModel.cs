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
            if (CourseInfoModels == null)
            {
                CourseInfoModels = await _coursesRepository.FindAsync(t => t.CourseName == tabName);
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