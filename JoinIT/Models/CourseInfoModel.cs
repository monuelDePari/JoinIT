namespace Models
{
    using ServiceStack.DataAnnotations;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class CourseInfoModel : IDataErrorInfo, INotifyPropertyChanged
    {
        private string _courseName;
        private string _authorName;
        private DateTime _startDate;
        private DateTime _endDate;

        [NotMapped]
        public string this[string columnName]
        {
            get
            {
                string errorMessage = string.Empty;

                switch (columnName)
                {
                    case "CourseName":
                        if (string.IsNullOrEmpty(CourseName))
                        {
                            errorMessage = "This is a mandatory field!";
                        }
                        break;
                    case "StartDate":
                        if (StartDate.Equals(default(DateTime)))
                        {
                            errorMessage = "You must specify StartDate!";
                        }
                        else if (StartDate < DateTime.Now)
                        {
                            errorMessage = "Start Date Can not start earlier of Todays date";
                        }
                        break;
                    case "EndDate":
                        if (EndDate.Equals(default(DateTime)))
                        {
                            errorMessage = "You must specify EndDate!";
                        }
                        else if (EndDate < StartDate)
                        {
                            errorMessage = "End Date must be later than Start Date";
                        }
                        break;
                    default:
                        break;
                }

                return errorMessage;
            }
        }

        [Unique]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(30, MinimumLength = 2)]
        public string CourseName
        {
            get
            {
                return _courseName;
            }
            set
            {
                _courseName = value;
                OnPropertyChanged();

            }
        }

        public string AuthorName
        {
            get
            {
                return _authorName;
            }
            set
            {
                _authorName = value;
                OnPropertyChanged();
            }
        }

        [System.ComponentModel.DataAnnotations.Required]
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }

        [System.ComponentModel.DataAnnotations.Required]
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
                OnPropertyChanged();
            }
        }

        [NotMapped]
        public string Error
        {
            get
            {
                var modelErrors = new StringBuilder();

                foreach (var prop in GetType().GetProperties())
                {
                    string error = this[prop.Name];

                    if (!string.IsNullOrEmpty(error))
                    {
                        modelErrors.Append(error);
                    }
                }

                return modelErrors.ToString();
            }
        }

        public CourseInfoModel() { }

        public CourseInfoModel(CourseInfoModel courseInfoModel)
        {
            if (courseInfoModel != null)
            {
                Id = courseInfoModel.Id;
                CourseName = courseInfoModel.CourseName;
                AuthorName = courseInfoModel.AuthorName;
                StartDate = courseInfoModel.StartDate;
                EndDate = courseInfoModel.EndDate;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
