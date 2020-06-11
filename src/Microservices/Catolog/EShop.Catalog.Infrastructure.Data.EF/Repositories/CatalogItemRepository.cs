using EShop.Catalog.Domain.Entities;
using EShop.Catalog.Domain.Repositories;
using EShop.Catalog.Infrastructure.Data.Contexts;

namespace EShop.Catalog.Infrastructure.Data.Repositories
{
    public class CatalogItemRepository : GenericRepository<CatalogItem>, ICatalogItemRepository
    {
        public CatalogItemRepository(CatalogContext catalogContext)
            : base(catalogContext)
        {

        }
    }
}
