using LEMV.Domain.Entities.Core;
using System.Collections.Generic;

namespace LEMV.Domain.Entities
{
    public class Project : Entity, IAggregateRoot
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string NomeAutor { get; set; }
        public string UrlImagem { get; set; }
        public string Texto { get; set; }
        public ICollection<ProjectStep> Manual { get; set; }

        public Project() { }

        public Project(
            int id,
            string titulo,
            string descricao,
            string nomeAutor,
            string urlImagem = "",
            string texto = "",
            ICollection<ProjectStep> manual = null) : base(id)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            NomeAutor = nomeAutor;
            UrlImagem = urlImagem;
            Texto = texto;
            Manual = manual ?? new List<ProjectStep>();
        }

        public void AdicionarPassos(ProjectStep passo)
        {
            Manual.Add(passo);
        }

        public void RemoverPassos(ProjectStep passo)
        {
            Manual.Remove(passo);
        }
    }
}