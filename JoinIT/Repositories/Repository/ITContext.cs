using Models;
using System.Data.Entity;

namespace Repositories.Repository
{
    public class ITContext : DbContext
    {
        public ITContext() : base("DefaultConnection")
        {
            var _ = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public DbSet<CourseInfoModel> courseInfoModels { get; set; }
    }
}