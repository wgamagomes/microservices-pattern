using EShop.Domain.Core.Events;

namespace EShop.Domain.Core.EventBus
{
    public interface IEventBus
    {
        void Publish(Event @event);

        void Subscribe<TEvent>() where TEvent : Event;
    }
}
