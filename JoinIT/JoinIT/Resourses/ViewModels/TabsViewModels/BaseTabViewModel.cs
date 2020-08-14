using Repositories.Instructions;
using System.Threading.Tasks;

namespace JoinIT.Resourses.ViewModels.Tabs
{
    public class BaseTabViewModel
    {
        protected ICoursesRepository _coursesRepository;

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
