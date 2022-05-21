using System;

namespace LEMV.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime LastMofication { get; protected set; }

        public Entity()
        {
        }

        public Entity(int id)
        {
            Id = id;
        }
    }
}