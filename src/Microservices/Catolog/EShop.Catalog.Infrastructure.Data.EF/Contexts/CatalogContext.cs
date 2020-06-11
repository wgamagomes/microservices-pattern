using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EShop.Catalog.Infrastructure.Data.Contexts
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options)
            : base(options)
        {
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
