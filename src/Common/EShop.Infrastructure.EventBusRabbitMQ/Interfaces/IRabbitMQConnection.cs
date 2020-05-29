using RabbitMQ.Client;

namespace EShop.Infrastructure.EventBusRabbitMQ.Interfaces
{
    public interface IRabbitMQConnection
    {
        bool IsConnected { get; }
        IModel CreateModel();
    }
}

