namespace JoinIT.Resources.ViewModels.TabsViewModels
{
    using JoinIT.Resources.Utilities;
    using Models;
    using Repositories.Instructions;
    using System;
    using System.Threading.Tasks;

    public class CoursesTabViewModel : BaseTabViewModel
    {
        #region Fields
        private CourseInfoModel _courseModelToUpdate;
        #endregion

        #region Methods
        private async Task AddNewCourseAsync(object obj)
        {
            await CoursesRepository.AddAsync(CourseModel);
        }

        private async Task UpdateCourseAsync(object arg)
        {
            if(CourseModelToUpdate == null)
            {
                return;
            }

            CourseModelToUpdate.CourseName = CourseModel.CourseName;
            CourseModelToUpdate.AuthorName = CourseModel.AuthorName;
            CourseModelToUpdate.StartDate = CourseModel.StartDate;
            CourseModelToUpdate.EndDate = CourseModel.EndDate;

            await CoursesRepository.UpdateAsync(CourseModelToUpdate);
        }
        #endregion

        #region Constructors
        public CoursesTabViewModel(ICoursesRepository coursesRepository) : base(coursesRepository)
        {
            CoursesRepository = coursesRepository;
            _addCommand = new AsyncCommand(AddNewCourseAsync);
            CourseModel = new CourseInfoModel();
            Course.StartDate = DateTime.Now;
            Course.EndDate = DateTime.Now;
        }

        public CoursesTabViewModel(ICoursesRepository coursesRepository, CourseInfoModel courseModel) : base(coursesRepository)
        {
            CoursesRepository = coursesRepository;
            _updateCommand = new AsyncCommand(UpdateCourseAsync);
            CourseModel = courseModel;
            CourseModelToUpdate = CourseModel;
        }
        #endregion

        #region Properties
        public CourseInfoModel CourseModelToUpdate
        {
            get
            {
                return _courseModelToUpdate;
            }
            set
            {
                _courseModelToUpdate = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        private AsyncCommand _addCommand;
        private AsyncCommand _updateCommand;

        public AsyncCommand AddCommand
        {
            get
            {
                return _addCommand;
            }
            set
            {
                _addCommand = value;
                OnPropertyChanged();
            }
        }

        public AsyncCommand UpdateCommand
        {
            get
            {
                return _updateCommand;
            }
            set
            {
                _updateCommand = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}

