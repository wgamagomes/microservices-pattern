using EShop.Domain.Core.Commands;
using System.Threading.Tasks;

namespace EShop.Domain.Core.EventBus
{
    public interface IBus
    {
        Task Send<TCommand>(TCommand command) where TCommand : Command;
    }
}
