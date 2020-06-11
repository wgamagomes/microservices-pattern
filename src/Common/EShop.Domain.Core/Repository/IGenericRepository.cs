using EShop.Domain.Core.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EShop.Domain.Core.Repository
{
    public interface IGenericRepository<TEntity> where TEntity: Entity
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken = default);
        void Update(TEntity entity);
        void Delete(Guid id);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
