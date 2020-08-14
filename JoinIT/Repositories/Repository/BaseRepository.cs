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
        public BaseRepository(ITContext context)
        {
            DBcontext = context;
        }
        public Task AddAsync(TEntity entity)
        {
            DBcontext.Set<TEntity>().Add(entity);
            return DBcontext.SaveChangesAsync();
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            DBcontext.Set<TEntity>().AddRange(entities);
            return DBcontext.SaveChangesAsync();
        }

        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return (Task<IEnumerable<TEntity>>)DBcontext.Set<TEntity>().Where(predicate);
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return DBcontext.Set<TEntity>().FindAsync(id);
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.FromResult((IEnumerable<TEntity>)DBcontext.Set<TEntity>().ToListAsync());
        }

        public Task RemoveAsync(TEntity entity)
        {
            DBcontext.Set<TEntity>().Remove(entity);
            return DBcontext.SaveChangesAsync();
        }

        public Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            DBcontext.Set<TEntity>().RemoveRange(entities);
            return DBcontext.SaveChangesAsync();
        }

        public Task UpdateAsync(TEntity entity)
        {
            DBcontext.Entry(entity).State = EntityState.Modified;
            return DBcontext.SaveChangesAsync();
        }
        protected DbContext DBcontext;
    }
}
