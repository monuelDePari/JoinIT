using Models;
using System.Data.Entity;

namespace Repositories.Repository
{
    public class ITContext : DbContext
    {
        public ITContext() : base("DefaultConnection") { }
        public DbSet<CourseInfoModel> courseInfoModels { get; set; }
    }
}