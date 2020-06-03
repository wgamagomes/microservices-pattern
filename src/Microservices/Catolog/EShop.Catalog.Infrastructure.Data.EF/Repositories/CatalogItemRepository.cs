using EShop.Catalog.Domain.Entities;
using EShop.Catalog.Domain.Repositories;

namespace EShop.Catalog.Infrastructure.Data.Repositories
{
    public class CatalogItemRepository: GenericRepository<CatalogItem>, ICatalogItemRepository
    {
    }
}
