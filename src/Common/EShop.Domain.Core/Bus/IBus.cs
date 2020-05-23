using EShop.Domain.Core.Commands;
using System.Threading.Tasks;

namespace EShop.Domain.Core.Bus
{
    public interface IBus
    {
        Task Send<TCommand>(TCommand command) where TCommand : Command;
    }
}
