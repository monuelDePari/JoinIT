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
        #region fields
        protected ICoursesRepository _coursesRepository;

        private IEnumerable<CourseInfoModel> _courseInfoModels;
        #endregion

        #region properties
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

        #region constructors
        public BaseTabViewModel(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
        #endregion

        #region methods
        public async Task LoadDataAsync(string tabName)
        {
            CourseInfoModels = await _coursesRepository.FindAsync(t => t.CourseName == tabName);
        }
        #endregion

        #region events
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
