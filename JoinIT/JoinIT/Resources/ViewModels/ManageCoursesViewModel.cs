namespace JoinIT.Resources.ViewModels
{
    using JoinIT.Resources.Utilities;
    using JoinIT.Resources.ViewModels.TabsViewModels;
    using Models;
    using Repositories.Instructions;
    using System;
    using System.Threading.Tasks;

    public class ManageCoursesViewModel : BaseTabViewModel
    {
        #region Methods
        private async Task SaveCourseAsync(object obj)
        {
            if (IsUpdating)
            {
                await RunTaskAsync(CoursesRepository.UpdateAsync(CourseModel));
            }
            else
            {
                await RunTaskAsync(CoursesRepository.AddAsync(CourseModel));
            }
        }
        #endregion

        #region Constructors
        public ManageCoursesViewModel(ICoursesRepository coursesRepository, CourseInfoModel courseModel = null) : base(coursesRepository)
        {
            CoursesRepository = coursesRepository;
            SaveCommand = new AsyncCommand(SaveCourseAsync);

            CourseModel = courseModel == null ? new CourseInfoModel
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            } : courseModel;
        }
        #endregion

        #region Properties
        public bool IsUpdating
        {
            get
            {
                return CourseModel != null && CourseModel.Id > 0;
            }
        }
        #endregion

        #region Commands
        private AsyncCommand _saveCommand;

        public AsyncCommand SaveCommand
        {
            get
            {
                return _saveCommand;
            }
            set
            {
                _saveCommand = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}

