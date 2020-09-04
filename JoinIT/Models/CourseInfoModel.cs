namespace Models
{
    using ServiceStack.DataAnnotations;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class CourseInfoModel : IDataErrorInfo, INotifyPropertyChanged
    {
        private string courseName;
        private string authorName;
        private DateTime startDate;
        private DateTime endDate;

        [NotMapped]
        public string this[string columnName]
        {
            get
            {
                string errorMessage = string.Empty;

                switch (columnName)
                {
                    case "CourseName":
                        if (string.IsNullOrEmpty(this.CourseName))
                        {
                            errorMessage = "This is a mandatory field!";
                        }
                        break;
                    case "StartDate":
                        if (StartDate == null)
                        {
                            errorMessage = "You must specify StartDate!";
                        }
                        else if (StartDate < DateTime.Now)
                        {
                            errorMessage = "Start Date Can not start earlier of Todays date";
                        }
                        break;
                    case "EndDate":
                        if (EndDate == null)
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
                return courseName;
            }
            set
            {
                courseName = value;
                OnPropertyChanged();

            }
        }
        public string AuthorName
        {
            get
            {
                return authorName;
            }
            set
            {
                authorName = value;
                OnPropertyChanged();
            }
        }
        [System.ComponentModel.DataAnnotations.Required]
        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
                OnPropertyChanged();
            }
        }
        [System.ComponentModel.DataAnnotations.Required]
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
                OnPropertyChanged();
            }
        }

        [NotMapped]
        public string Error
        {
            get
            {
                return null;
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
