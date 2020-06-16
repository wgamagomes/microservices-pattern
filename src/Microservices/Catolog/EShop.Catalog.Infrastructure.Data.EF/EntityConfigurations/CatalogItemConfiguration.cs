using EShop.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Catalog.Infrastructure.Data.EF.EntityConfigurations
{
    public class CatalogItemConfiguration : EntityTypeConfiguration<CatalogItem>
    {
        public override void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            base.Configure(builder);

            builder.Property(ci => ci.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(ci => ci.Price)
                .HasColumnType("decimal(5,2)")
                .IsRequired(true);

            builder.Property(ci => ci.PictureFileName)
                .IsRequired(false);

            builder.Ignore(ci => ci.PictureUri);

            builder.HasOne(ci => ci.CatalogBrand)
                .WithMany()
                .HasForeignKey(ci => ci.CatalogBrandId);

            builder.HasOne(ci => ci.CatalogType)
                .WithMany()
                .HasForeignKey(ci => ci.CatalogTypeId);
        }
    }
}
