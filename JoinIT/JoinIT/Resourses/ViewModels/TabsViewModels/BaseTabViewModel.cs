namespace JoinIT.Resourses.ViewModels.TabsViewModels
{
    using Repositories.Instructions;

    public class BaseTabViewModel : ITBaseTabViewModel
    {

        #region Constructors
        public BaseTabViewModel(ICoursesRepository coursesRepository) : base(coursesRepository)
        {
            CoursesRepository = coursesRepository;
        }
        #endregion
    }
}
