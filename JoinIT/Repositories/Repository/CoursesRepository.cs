namespace Repositories
{
    using Models;
    using Repositories.Instructions;
    using System.Data.Entity;
    using System.Threading.Tasks;

    public class CoursesRepository : BaseRepository<CourseInfoModel>, ICoursesRepository
    {  
        public CoursesRepository(DbContext dbContext) : base(dbContext) { }
    }
}
