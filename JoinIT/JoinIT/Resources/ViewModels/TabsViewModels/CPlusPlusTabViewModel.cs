namespace JoinIT.Resources.ViewModels.TabsViewModels
{
    using Enums;
    using Prism.Events;
    using Utilities;
    using Repositories.Instructions;

    public class CPlusPlusTabViewModel : BaseTabViewModel
    {
        #region constructors

        public CPlusPlusTabViewModel(ICoursesRepository coursesRepository, IApplicationCommands applicationCommands, IEventAggregator eventAggregator) : base(coursesRepository, applicationCommands, eventAggregator)
        {
            CoursesRepository = coursesRepository;
        }

        #endregion

        #region Methods

        public override async void OnLoaded()
        {
            base.OnLoaded();

            await RunTaskAsync(LoadDataAsync(CourseNames.CPlusPlus.ToString()));
        }

        #endregion
    }
}
