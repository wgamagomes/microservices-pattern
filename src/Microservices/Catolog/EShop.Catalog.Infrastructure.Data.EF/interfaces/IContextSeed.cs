using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace EShop.Catalog.Infrastructure.Data.EF.interfaces
{
    public interface IContextSeed
    {
        Task SeedAsync<TOptions>(DbContext context, IOptions<TOptions> settings)
             where TOptions : class, new();
    }
}
