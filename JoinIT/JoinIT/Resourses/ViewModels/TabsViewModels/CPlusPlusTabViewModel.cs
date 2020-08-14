namespace JoinIT.Resourses.ViewModels.Tabs
{
    using JoinIT.Resourses.Enums;
    using Models;
    using Repositories.Instructions;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public class CPlusPlusTabViewModel : BaseTabViewModel, INotifyPropertyChanged
    {
        private List<CourseInfoModel> _courseInfoModels;

        public List<CourseInfoModel> CourseInfoModels
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

        public CPlusPlusTabViewModel(ICoursesRepository coursesRepository) : base(coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        public async Task LoadCPlusPlusDataAsync()
        {
            CourseInfoModels = await _coursesRepository.FindAsync(p => p.CourseName == CourceNames.CPlusPlus.ToString());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string info = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
