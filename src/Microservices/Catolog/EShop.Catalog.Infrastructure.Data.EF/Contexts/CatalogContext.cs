using EShop.Catalog.Infrastructure.Data.EF.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace EShop.Catalog.Infrastructure.Data.Contexts
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CatalogBrandConfiguration());
            builder.ApplyConfiguration(new CatalogItemConfiguration());
            builder.ApplyConfiguration(new CatalogTypeConfiguration());
        }
    }









    //    public class CatalogContextFactory : IDesignTimeDbContextFactory<CatalogContext>
    //    {
    //        public CatalogContext CreateDbContext(string[] args)
    //        {
    //            var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>();

    //            optionsBuilder.UseSqlServer("");

    //            return new CatalogContext(optionsBuilder.Options);
    //        }
    //    }
}
