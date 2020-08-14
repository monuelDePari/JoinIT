using JoinIT.Resourses.Enums;
using Models;
using Repositories;
using Repositories.Instructions;
using Repositories.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace JoinIT.Resourses.ViewModels.Tabs
{
    public class CPlusPlusTabViewModel : BaseTabViewModel, INotifyPropertyChanged
    {
        IEnumerable<CourseInfoModel> courseInfoModels;
        public IEnumerable<CourseInfoModel> CourseInfoModels
        {
            get
            {
                return courseInfoModels;
            }
            set
            {
                courseInfoModels = value;
                OnPropertyChanged("CourseInfoModels");
            }
        }

        public CPlusPlusTabViewModel(ICoursesRepository coursesRepository) : base(coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        public async Task LoadCPlusPlusDataAsync()
        {
            courseInfoModels =  await _coursesRepository.FindAsync(p => p.CourseName == CourceNames.CPlusPlus.ToString());
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
