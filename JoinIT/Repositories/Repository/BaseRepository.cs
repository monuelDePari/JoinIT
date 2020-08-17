namespace Repositories
{
    using Repositories.Repository;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        #region fields
        public DbContext DbContext;
        public DbSet<TEntity> DbSet;
        #endregion
        #region constructors
        public BaseRepository(DbContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<TEntity>();
        }
        #endregion
        #region methods
        public Task AddAsync(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            return DbContext.SaveChangesAsync();
        }
        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().AddRange(entities);
            return DbContext.SaveChangesAsync();
        }

        public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().Where(predicate).ToListAsync<TEntity>();
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return DbContext.Set<TEntity>().FindAsync(id);
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return DbContext.Set<TEntity>().ToListAsync();
        }

        public Task RemoveAsync(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            return DbContext.SaveChangesAsync();
        }

        public Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().RemoveRange(entities);
            return DbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }
        #endregion
    }
}
