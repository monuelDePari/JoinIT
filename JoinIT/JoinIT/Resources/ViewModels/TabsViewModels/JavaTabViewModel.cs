namespace JoinIT.Resources.ViewModels.TabsViewModels
{
    using Repositories;
    using Utilities;
    using Enums;
    using Prism.Events;

    public class JavaTabViewModel : BaseTabViewModel
    {
        #region Constructors

        public JavaTabViewModel(CoursesRepository coursesRepository, IApplicationCommands applicationCommands, IEventAggregator eventAggregator) : base(coursesRepository, applicationCommands, eventAggregator)
        {
            CoursesRepository = coursesRepository;
        }

        #endregion

        #region Methods

        public override async void OnLoaded()
        {
            base.OnLoaded();

            await RunTaskAsync(LoadDataAsync(CourseNames.Java.ToString()));
        }

        #endregion
    }
}
