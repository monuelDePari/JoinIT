namespace JoinIT.Resources.ViewModels.TabsViewModels
{
    using Enums;
    using Prism.Events;
    using Utilities;
    using Repositories;

    public class CSharpTabViewModel : BaseTabViewModel
    {
        #region constructors

        public CSharpTabViewModel(CoursesRepository coursesRepository, IApplicationCommands applicationCommands, IEventAggregator eventAggregator) : base(coursesRepository, applicationCommands, eventAggregator)
        {
            CoursesRepository = coursesRepository;
        }

        #endregion

        #region Methods

        public override async void OnLoaded()
        {
            await LoadDataAsync(CourseNames.CSharp.ToString());
        }

        #endregion
    }
}
