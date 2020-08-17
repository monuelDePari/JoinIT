namespace Models
{
    using ServiceStack.DataAnnotations;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class CourseInfoModel : INotifyPropertyChanged
    {
        private string courseName;
        private string authorName;
        private DateTime startDate;
        private DateTime endDate;
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
                OnPropertyChanged("CourseName");
                
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
                OnPropertyChanged("AuthorName");
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
                OnPropertyChanged("StartDate");
            }
        }
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
