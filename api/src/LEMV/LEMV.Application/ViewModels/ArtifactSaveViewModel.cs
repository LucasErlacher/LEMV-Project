using System.Collections.Generic;

namespace LEMV.Application.ViewModels
{
    public class ArtifactSaveViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Resume { get; set; }
        public ICollection<MediaInfoViewModel> Medias { get; set; }
        public int SkillId { get; set; }
        public ICollection<int> AbilitieIds { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}
