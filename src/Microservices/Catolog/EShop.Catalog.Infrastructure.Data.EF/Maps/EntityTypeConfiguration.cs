using EShop.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Catalog.Infrastructure.Data.EF.Maps
{
    public abstract class EntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            //Configure here the generic map
            OnEntityBuild(builder);
        }

        protected abstract void OnEntityBuild(EntityTypeBuilder<TEntity> builder);
    }
}
