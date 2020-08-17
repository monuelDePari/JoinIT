namespace JoinIT.Resourses.ViewModels.TabsViewModels
{
    using JoinIT.Resourses.Utilities;
    using Models;
    using Repositories.Instructions;
    using System;

    public class CoursesTabViewModel : BaseTabViewModel
    {
        #region Fields
        private CourseInfoModel courseInfoModel;
        #endregion

        #region Properties
        public string CourseName
        {
            get { return courseInfoModel.CourseName; }
            set
            {
                courseInfoModel.CourseName = value;
                OnPropertyChanged();
            }
        }

        public string AuthorName
        {
            get { return courseInfoModel.AuthorName; }
            set
            {
                courseInfoModel.AuthorName = value;
                OnPropertyChanged();
            }
        }

        public DateTime StartDate
        {
            get { return courseInfoModel.StartDate; }
            set
            {
                courseInfoModel.StartDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get { return courseInfoModel.EndDate.Date; }
            set
            {
                courseInfoModel.EndDate = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public CoursesTabViewModel(ICoursesRepository coursesRepository) : base(coursesRepository)
        {
            _coursesRepository = coursesRepository;
            courseInfoModel = new CourseInfoModel();
            courseInfoModel.StartDate = DateTime.Now;
            courseInfoModel.EndDate = DateTime.Now;
        }
        #endregion

        #region Commands
        private RelativeCommand addCommand;
        public RelativeCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelativeCommand(obj =>
                  {
                       _coursesRepository.AddAsync(courseInfoModel);
                  }));
            }
        }
        #endregion
    }
}

