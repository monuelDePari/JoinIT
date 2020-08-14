using Repositories.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinIT.Resourses.ViewModels.Tabs
{
    public class CPlusPlusTabViewModel : BaseTabViewModel
    {
        public CPlusPlusTabViewModel(ICoursesRepository coursesRepository) : base(coursesRepository)
        {
        }
    }
}
