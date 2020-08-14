namespace Repositories
{
    using Models;
    using Repositories.Instructions;
    using Repositories.Repository;
    using System.Data.Entity;
    using Unity;

    public class CoursesRepository : BaseRepository<CourseInfoModel>, ICoursesRepository
    { 
        public CoursesRepository(ITContext context) : base(context) { }
    }
}
