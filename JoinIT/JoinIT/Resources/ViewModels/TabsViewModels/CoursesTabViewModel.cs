namespace JoinIT.Resources.ViewModels.TabsViewModels
{
    using JoinIT.Resources.Utilities;
    using Models;
    using Repositories.Instructions;
    using System;
    using System.ComponentModel;
    using System.Threading.Tasks;

    public class CoursesTabViewModel : BaseTabViewModel
    {
        #region Fields
        private CourseInfoModel _courseInfoModel;
        #endregion

        #region Properties
        public CourseInfoModel CourseModel
        {
            get
            {
                return _courseInfoModel;
            }
            set
            {
                _courseInfoModel = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods
        private async Task AddNewCourseAsync(object obj)
        {
            await CoursesRepository.AddAsync(CourseModel);
        }
        #endregion

        #region Constructors
        public CoursesTabViewModel(ICoursesRepository coursesRepository) : base(coursesRepository)
        {
            CoursesRepository = coursesRepository;
            _addCommand = new AsyncCommand(AddNewCourseAsync);
            CourseModel = new CourseInfoModel();
            _courseInfoModel.StartDate = DateTime.Now;
            _courseInfoModel.EndDate = DateTime.Now;
        }
        #endregion

        #region Commands
        private AsyncCommand _addCommand;
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
        #endregion
    }
}

