namespace Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    public class AsyncRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext DBcontext;
        public AsyncRepository(DbContext context)
        {
            DBcontext = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            DBcontext.Set<TEntity>().Add(entity);
            await DBcontext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            DBcontext.Set<TEntity>().AddRange(entities);
            await DBcontext.SaveChangesAsync();
        }

        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return (Task<IEnumerable<TEntity>>)DBcontext.Set<TEntity>().Where(predicate);
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return DBcontext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DBcontext.Set<TEntity>().ToListAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            DBcontext.Set<TEntity>().Remove(entity);
            await DBcontext.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            DBcontext.Set<TEntity>().RemoveRange(entities);
            await DBcontext.SaveChangesAsync();
        }

        Task IAsyncRepository<TEntity>.UpdateAsync(TEntity entity)
        {
            DBcontext.Entry(entity).State = EntityState.Modified;
            return DBcontext.SaveChangesAsync();
        }
    }
}
