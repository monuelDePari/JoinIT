using JoinIT.Resourses.Utilities;
using Repositories;
using Repositories.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace JoinIT.Resourses.ViewModels.Tabs
{
    public class BaseTabViewModel
    {
        protected readonly ICoursesRepository _coursesRepository;

        public BaseTabViewModel(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }


        public async Task LoadDataAsync(string tabName)
        {
            var currentTabItems = await _coursesRepository.FindAsync(t => t.CourseName == tabName);
        }
    }
}
