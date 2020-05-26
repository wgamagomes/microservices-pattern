using EShop.Domain.Core.Entities;
using EShop.Domain.Core.Repository;
using System;
using System.Linq;

namespace EShop.Catalog.Infrastructure.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        public GenericRepository()
        {

        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
