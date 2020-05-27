using MediatR;
using System;

namespace EShop.Domain.Core.Messages
{
    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; protected set; }
        public Guid Id { get; protected set; }
        public DateTime CreationDate { get; private set; }

        protected Message()
        {
            MessageType = GetType().Name;
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }
    }
}
