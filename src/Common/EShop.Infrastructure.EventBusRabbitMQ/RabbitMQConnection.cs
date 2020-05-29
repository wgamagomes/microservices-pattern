using EShop.Infrastructure.EventBusRabbitMQ.Interfaces;
using Polly;
using Polly.Retry;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.IO;
using System.Net.Sockets;

namespace EShop.Infrastructure.EventBusRabbitMQ
{
    public class RabbitMQConnection: IRabbitMQConnection
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly int _retryCount;
        private static IConnection _connection;
        private bool _disposed;

        public RabbitMQConnection(IConnectionFactory connectionFactory, int retryCount = 5)
        {
            _connectionFactory = connectionFactory;
            _retryCount = retryCount;
        }

        public bool IsConnected
        {
            get
            {
                return _connection != null && _connection.IsOpen && !_disposed;
            }
        }

        public IModel CreateModel()
        {
            if (!IsConnected)
                TryConnect();

            return _connection.CreateModel();
        }

        private bool TryConnect()
        {
            var policy = RetryPolicy.Handle<SocketException>()
                .Or<BrokerUnreachableException>()
                .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                {
                    //Log exception here when RabbitMQ Client could not connect to server
                }
            );

            policy.Execute(() =>
            {
                _connection = _connectionFactory
                      .CreateConnection();
            });

            return IsConnected;
        }

        public void Dispose()
        {
            if (_disposed) return;

            _disposed = true;

            try
            {
                _connection.Dispose();
            }
            catch (IOException)
            {
                //Log critical error here
            }
        }
    }
}

