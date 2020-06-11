using System;

namespace EShop.Domain.Core.Entities
{
    public class Entity
    {
        public Guid Id { get; protected set; }
        public DateTime InsertedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
