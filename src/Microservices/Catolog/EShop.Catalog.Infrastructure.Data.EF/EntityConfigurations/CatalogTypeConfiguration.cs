using EShop.Catalog.Domain.Entities;
using EShop.Catalog.Infrastructure.Data.EF.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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
