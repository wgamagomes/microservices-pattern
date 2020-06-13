using EShop.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Catalog.Infrastructure.Data.EF.Maps
{
    public class CatalogMap : EntityTypeConfiguration<CatalogItem>
    {
        protected override void OnEntityBuild(EntityTypeBuilder<CatalogItem> builder)
        {

        }
    }
}
