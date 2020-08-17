namespace JoinIT.Resourses.ViewModels.TabsViewModels
{
    using JoinIT.Resourses.Enums;
    using Models;
    using Repositories.Instructions;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public class CPlusPlusTabViewModel : BaseTabViewModel
    {
        #region constructors
        public CPlusPlusTabViewModel(ICoursesRepository coursesRepository) : base(coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
        #endregion
    }
}
