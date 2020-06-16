using EShop.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Catalog.Infrastructure.Data.EF.EntityConfigurations
{
    public class CatalogTypeConfiguration : EntityTypeConfiguration<CatalogType>
    {
        protected override void OnEntityBuild(EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogType");

            builder.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
