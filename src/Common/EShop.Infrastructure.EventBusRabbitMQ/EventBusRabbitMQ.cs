using EShop.Domain.Core.EventBus;
using EShop.Domain.Core.Events;
using EShop.Infrastructure.EventBusRabbitMQ.Interfaces;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Infrastructure.EventBusRabbitMQ
{
    public class EventBusRabbitMQ : IEventBus
    {
        private readonly IRabbitMQConnection _rabbitMQConnection;
        private readonly int _retryCount;
        const string BROKER_NAME = "event_bus";

        public EventBusRabbitMQ(IRabbitMQConnection rabbitMQConnection, int retryCount = 5)
        {
            _rabbitMQConnection = rabbitMQConnection;
            _retryCount = retryCount;
        }

        public Task PublishAsync(Event @event)
        {
            return Task.Run(() =>
            {
                var policy = GetRetryPolicy(_retryCount, (ex, time) =>
                {
                    //Log the exception here when RabbitMQ channel could not publish message
                });

                using (var channel = _rabbitMQConnection.GetChannel())
                {
                    channel.ExchangeDeclare(exchange: BROKER_NAME, type: ExchangeType.Direct);

                    policy.Execute(() => BasicPublish(@event, channel));
                }
            });
        }

        private void BasicPublish(Event @event, IModel channel)
        {
            var eventName = @event.GetType().Name;
            var message = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(message);

            var properties = channel.CreateBasicProperties();
            properties.DeliveryMode = 2; 

            channel.BasicPublish(
                exchange: BROKER_NAME,
                routingKey: eventName,
                mandatory: true,
                basicProperties: properties,
                body: body);
        }

        private RetryPolicy GetRetryPolicy(int retryCount, Action<Exception, TimeSpan> onRetry)
        {
            return RetryPolicy.Handle<BrokerUnreachableException>()
                .Or<SocketException>()
                .WaitAndRetry(retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), onRetry);
        }

        public void Subscribe<TEvent>() where TEvent : Event
        {
            throw new System.NotImplementedException();
        }
    }
}
