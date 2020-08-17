namespace JoinIT.Resourses.ViewModels.TabsViewModels
{
    using Repositories.Instructions;

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
