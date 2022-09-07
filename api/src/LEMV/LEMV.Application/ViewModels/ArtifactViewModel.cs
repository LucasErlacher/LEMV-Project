using System.Collections.Generic;

namespace LEMV.Application.ViewModels
{
    public class ArtifactViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<MediaInfoViewModel> Medias { get; set; }
        public SkillViewModel Skill { get; set; }
    }
}
