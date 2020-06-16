using EShop.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Catalog.Infrastructure.Data.EF.EntityConfigurations
{
    public class CatalogBrandConfiguration : EntityTypeConfiguration<CatalogBrand>
    {
        public override void Configure(EntityTypeBuilder<CatalogBrand> builder)
        {
            base.Configure(builder);

            builder.Property(cb => cb.Brand)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
