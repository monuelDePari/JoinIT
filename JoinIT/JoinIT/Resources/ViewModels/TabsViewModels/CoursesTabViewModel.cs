namespace JoinIT.Resources.ViewModels.TabsViewModels
{
    using JoinIT.Resources
        .Utilities;
    using Models;
    using Repositories.Instructions;
    using System;

    public class CoursesTabViewModel : BaseTabViewModel
    {
        #region Fields
        private CourseInfoModel _courseInfoModel;
        #endregion

        #region Properties
        public string CourseName
        {
            get { return _courseInfoModel.CourseName; }
            set
            {
                _courseInfoModel.CourseName = value;
                OnPropertyChanged();
            }
        }

        public string AuthorName
        {
            get { return _courseInfoModel.AuthorName; }
            set
            {
                _courseInfoModel.AuthorName = value;
                OnPropertyChanged();
            }
        }

        public DateTime StartDate
        {
            get { return _courseInfoModel.StartDate; }
            set
            {
                _courseInfoModel.StartDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get { return _courseInfoModel.EndDate.Date; }
            set
            {
                _courseInfoModel.EndDate = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Constructors
        public CoursesTabViewModel(ICoursesRepository coursesRepository) : base(coursesRepository)
        {
            CoursesRepository = coursesRepository;
            _courseInfoModel = new CourseInfoModel();
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
                return _addCommand ??
                  (_addCommand = new AsyncCommand(async () =>
                  {
                       await CoursesRepository.AddAsync(_courseInfoModel);
                  }));
            }
        }
        #endregion
    }
}

