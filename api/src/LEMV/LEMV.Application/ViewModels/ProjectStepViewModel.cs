using System.Collections.Generic;

namespace LEMV.Application.ViewModels
{
    public class ProjectStepViewModel
    {
        public int Ordem { get; set; }
        public string NomeEtapa { get; set; }
        public string Descricao { get; set; }
        public ICollection<string> Materiais { get; set; }
    }
}
