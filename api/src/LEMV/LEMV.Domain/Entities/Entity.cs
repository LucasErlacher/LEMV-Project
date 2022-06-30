using System;

namespace LEMV.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastMofication { get; set; }

        public Entity()
        {
            CreatedAt = DateTime.Now;
        }

        public Entity(int id) : this()
        {
            Id = id;
        }
    }
}