using System.Collections.Generic;

namespace LEMV.Domain.Entities
{
    public class Artifact : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Resume { get; set; }
        public virtual string Description { get; set; }

        public virtual ICollection<MediaInfo> Medias { get; set; }

        public virtual int SkillId { get; set; }
        public virtual ICollection<int> AbilitieIds { get; set; }

        public List<string> Tags { get; set; }

        public Artifact()
        {

        }

        public Artifact(int id, string name, string description, List<string> tags, string resume) : base(id)
        {
            Name = name;
            Description = description;
            Tags = tags;
            Resume = resume;

        }
    }
}
