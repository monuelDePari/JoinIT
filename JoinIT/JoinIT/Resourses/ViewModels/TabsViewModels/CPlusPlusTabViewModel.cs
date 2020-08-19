namespace JoinIT.Resourses.ViewModels.TabsViewModels
{
    using Repositories.Instructions;
    using System.Collections.Generic;

    public class CPlusPlusTabViewModel : BaseTabViewModel
    {
        #region constructors
        public CPlusPlusTabViewModel(ICoursesRepository coursesRepository) : base(coursesRepository)
        {
            CoursesRepository = coursesRepository;
        }
        #endregion
    }
}
