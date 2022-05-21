using LEMV.Domain.Entities.Core;
using System;
using System.Collections.Generic;

namespace LEMV.Domain.Entities
{
    public class Laboratory : Entity
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public bool Active { get; protected set; }

        public virtual ICollection<AppUser> Membros { get; protected set; }

        protected Laboratory() : base()
        {
        }

        public Laboratory(int id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
            Active = true;
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException();

            Name = name;
        }

        public void ChangeDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException();

            Description = description;
        }

        public void Activate()
        {
            if (!Active)
                Active = true;
        }

        public void Disable()
        {
            if (Active)
                Active = false;
        }

        public bool IsActive()
        {
            return Active;
        }
    }
}