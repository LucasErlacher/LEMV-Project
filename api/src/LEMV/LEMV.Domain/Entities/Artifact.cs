using System.Collections.Generic;

namespace LEMV.Domain.Entities
{
    public class Artifact : Entity
    {
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }

        public virtual ICollection<MediaInfo> Medias { get; set; }

        public virtual int SkillId { get; set; }
        public virtual ICollection<int> AbilitieIds { get; set; }

        public Artifact()
        {

        }

        public Artifact(int id, string title, string description) : base(id)
        {
            Title = title;
            Description = description;
        }
    }
}
