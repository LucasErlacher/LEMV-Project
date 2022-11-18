using System.Collections.Generic;

namespace LEMV.Application.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string NomeAutor { get; set; }
        public string Texto { get; set; }
        public MediaInfoViewModel Media { get; set; }
        public ICollection<ProjectStepViewModel> Manual { get; set; }
        public SkillViewModel Skill { get; set; }

        public ICollection<string> Tags { get; set; }
    }
}
