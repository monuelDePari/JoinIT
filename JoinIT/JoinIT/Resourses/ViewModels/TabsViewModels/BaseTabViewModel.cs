using Models;
using Repositories.Instructions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace JoinIT.Resourses.ViewModels.TabsViewModels
{
    public class BaseTabViewModel : ITBaseTabViewModel
    {

        #region Constructors
        public BaseTabViewModel(ICoursesRepository coursesRepository) : base(coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
        #endregion
    }
}
