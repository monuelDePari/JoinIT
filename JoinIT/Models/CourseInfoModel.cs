namespace Models
{
    using ServiceStack.DataAnnotations;
    using System;
    public class CourseInfoModel
    {
        [Unique]
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string CourseName { get; set; }
        public string AuthorName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
