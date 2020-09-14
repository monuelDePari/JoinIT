namespace Repositories
{
    using Models;
    using Repositories.Instructions;
    using Repositories.Repository;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    public class CoursesRepository : BaseRepository<CourseInfoModel>, ICoursesRepository
    {
        private ITContext _context;
        public new Task UpdateAsync(CourseInfoModel entity)
        {
            var local = _context.Set<CourseInfoModel>().Local.FirstOrDefault(t => t.Id == entity.Id);
            local.CourseName = entity.CourseName;
            local.AuthorName = entity.AuthorName;
            local.StartDate = entity.StartDate;
            local.EndDate = entity.EndDate;
            _context.Entry(local).State = EntityState.Modified;
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
