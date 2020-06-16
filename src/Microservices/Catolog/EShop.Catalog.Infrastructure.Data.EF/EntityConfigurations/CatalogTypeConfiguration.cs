using EShop.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Catalog.Infrastructure.Data.EF.EntityConfigurations
{
    public class CatalogTypeConfiguration : EntityTypeConfiguration<CatalogType>
    {
        public override void Configure(EntityTypeBuilder<CatalogType> builder)
        {
            base.Configure(builder);

            builder.Property(ct => ct.Type)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
