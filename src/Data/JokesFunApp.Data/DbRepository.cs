namespace JokesFunApp.Data
{
    using System;
    using Common;

    using Microsoft.EntityFrameworkCore;

    using System.Linq;
    using System.Threading.Tasks;

    public class DbRepository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class
    {
        private readonly JokesFunAppContext context;
        private readonly DbSet<TEntity> dbSet;

        public DbRepository(JokesFunAppContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<TEntity>();
        }

        public Task AddAsync(TEntity entity) => this.dbSet.AddAsync(entity);

        public IQueryable<TEntity> All() => this.dbSet;

        public void Delete(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }
        
        public Task<int> SaveChangesAsync() => this.context.SaveChangesAsync();

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
