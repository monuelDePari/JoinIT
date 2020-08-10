namespace Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    class Repository<TEntity> : IAsyncRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext dBcontext;
        public Repository(DbContext context)
        {
            dBcontext = context;
        }

        public async Task Add(TEntity entity)
        {
            dBcontext.Set<TEntity>().Add(entity);
            await dBcontext.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            dBcontext.Set<TEntity>().AddRange(entities);
            await dBcontext.SaveChangesAsync();
        }

        public Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate) => (Task<IEnumerable<TEntity>>)dBcontext.Set<TEntity>().Where(predicate);

        public Task<TEntity> GetById(int id) => dBcontext.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dBcontext.Set<TEntity>().ToListAsync();
        }

        public async Task Remove(TEntity entity)
        {
            dBcontext.Set<TEntity>().Remove(entity);
            await dBcontext.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<TEntity> entities)
        {
            dBcontext.Set<TEntity>().RemoveRange(entities);
            await dBcontext.SaveChangesAsync();
        }

        Task IAsyncRepository<TEntity>.Update(TEntity entity)
        {
            dBcontext.Entry(entity).State = EntityState.Modified;
            return dBcontext.SaveChangesAsync();
        }
    }
}
