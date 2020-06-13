using EShop.Domain.Core.Entities;
using EShop.Domain.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EShop.Catalog.Infrastructure.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        private DbContext _dbContext;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public void Delete(Guid id)
        {
            Delete(_dbSet.Where(e => e.Id == id).ToArray());
        }

        public virtual void Delete(params TEntity[] entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
