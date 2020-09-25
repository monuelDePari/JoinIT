namespace Repositories
{
    using System.Data.Entity;
    using Models;

    public class ITContext : DbContext
    {
        #region constructors
        public ITContext() : base("DefaultConnection")
        {
            var _ = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        #endregion
        #region data
        public DbSet<CourseInfoModel> CourseInfoModels { get; set; }
        #endregion
    }
}