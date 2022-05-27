using LEMV.Domain.Entities.Core;
using System.Collections.Generic;

namespace LEMV.Domain.Entities
{
    public class ProjectStep : IAggregate
    {
        public int Ordem { get; set; }
        public string NomeEtapa { get; set; }
        public string Descricao { get; set; }
        public ICollection<string> Materiais { get; set; }

        public ProjectStep()
        {
        }

        public ProjectStep(int ordem, string nomeEtapa, string descricao, ICollection<string> materiais = null)
        {
            Ordem = ordem;
            NomeEtapa = nomeEtapa;
            Descricao = descricao;
            Materiais = materiais ?? new List<string>();
        }

        public void AdicionarMateriais(string materiais)
        {
            Materiais.Add(materiais);
        }

        public void RemoverMateriais(string materiais)
        {
            Materiais.Remove(materiais);
        }
    }
}