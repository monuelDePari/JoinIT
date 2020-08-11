namespace Repositories
{
    using Models;
    using Repositories.Instructions;
    using System.Data.Entity;
    using System.Threading.Tasks;

    public class RepositoryCoursesAsync : RepositoryAsync<CourseInfoModel>, IRepositoryCoursesAsync
    {  
        public RepositoryCoursesAsync(DbContext dbContext) : base(dbContext) { }
    }
}
