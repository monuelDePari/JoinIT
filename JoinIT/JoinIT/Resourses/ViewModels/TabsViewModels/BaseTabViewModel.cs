using Models;
using Repositories.Instructions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace JoinIT.Resourses.ViewModels.TabsViewModels
{
    public class BaseTabViewModel : INotifyPropertyChanged
    {
        #region Fields
        protected ICoursesRepository _coursesRepository;

        private IEnumerable<CourseInfoModel> _courseInfoModels;
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
                OnPropertyChanged("CourseInfoModels");
            }
        }
        #endregion

        #region Constructors
        public BaseTabViewModel(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
        #endregion

        #region Methods
        public async Task LoadDataAsync(string tabName)
        {
            CourseInfoModels = await _coursesRepository.FindAsync(t => t.CourseName == tabName);
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string info = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
