using EShop.Domain.Core.Events;
using System.Threading.Tasks;

namespace EShop.Domain.Core.EventBus
{
    public interface IEventBus
    {
        Task PublishAsync(Event @event);

        void Subscribe<TEvent>() where TEvent : Event;
    }
}
