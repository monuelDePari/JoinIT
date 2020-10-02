namespace JoinIT.Resources.ViewModels.TabsViewModels
{
    using Utilities.Commands.Instructions;
    using Enums;
    using Prism.Events;
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
            base.OnLoaded();

            await RunTaskAsync(LoadDataAsync(CourseNames.CSharp.ToString()));
        }

        #endregion
    }
}
