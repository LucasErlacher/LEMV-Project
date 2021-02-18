using System;

namespace LEMV.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime LastMofication { get; protected set; }
    }
}
