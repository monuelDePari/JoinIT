namespace Repositories
{
    using Models;
    using Repositories.Instructions;
    using Repositories.Repository;

    public class CoursesRepository : BaseRepository<CourseInfoModel>, ICoursesRepository
    {
        #region constructors
        public CoursesRepository(ITContext context) : base(context) { }
        #endregion
    }
}
