using EShop.Domain.Core.EventBus;
using EShop.Domain.Core.Events;

namespace EShop.Infrastructure.EventBusRabbitMQ
{
    public class EventBusRabbitMQ : IEventBus
    {
        public void Publish(Event @event)
        {
            throw new System.NotImplementedException();
        }

        public void Subscribe<TEvent>() where TEvent : Event
        {
            throw new System.NotImplementedException();
        }
    }
}
