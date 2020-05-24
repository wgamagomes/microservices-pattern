using EShop.Domain.Core.Entities;
using System;
using System.Linq;

namespace EShop.Domain.Core.Repository
{
    public interface IGenericRepository<TEntity> where TEntity: Entity
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(Guid id);   
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);      
    }
}
