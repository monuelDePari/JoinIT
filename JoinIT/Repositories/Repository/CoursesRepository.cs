namespace Repositories
{
    using System.Diagnostics.CodeAnalysis;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;
    using Models;
    using Instructions;

    [ExcludeFromCodeCoverage]
    public class CoursesRepository : BaseRepository<CourseInfoModel>, ICoursesRepository
    {
        private readonly ITContext _context;
        public override Task UpdateAsync(CourseInfoModel entity)
        {
            var local = _context.CourseInfoModels.FirstOrDefault(t => t.Id == entity.Id);
            local.CourseName = entity.CourseName;
            local.AuthorName = entity.AuthorName;
            local.StartDate = entity.StartDate;
            local.EndDate = entity.EndDate;

            _context.Set<CourseInfoModel>().AddOrUpdate(local);
            return _context.SaveChangesAsync();
        }

        #region constructors
        public CoursesRepository(ITContext context) : base(context)
        {
            _context = context;
        }
        #endregion
    }
}
