namespace JoinIT.Resourses.ViewModels.TabsViewModels
{
    using Repositories.Instructions;

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
