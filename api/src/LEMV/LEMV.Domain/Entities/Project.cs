using LEMV.Domain.Entities.Core;
using System;
using System.Collections.Generic;

namespace LEMV.Domain.Entities
{
    public class Project : Entity, IAggregateRoot
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string NomeAutor { get; set; }
        public virtual MediaInfo Media { get; set; }
        public string Texto { get; set; }
        public ICollection<ProjectStep> Manual { get; set; }
        public virtual int SkillId { get; set; }
        public virtual ICollection<int> AbilitieIds { get; set; }

        public List<string> Tags { get; set; }

        public Project() { }

        public Project(
            int id,
            string titulo,
            string descricao,
            string nomeAutor,
            MediaInfo media,
            List<string> tags,
            string texto = "",
            ICollection<ProjectStep> manual = null) : base(id)
        {

            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            NomeAutor = nomeAutor;
            Texto = texto;
            Manual = manual ?? new List<ProjectStep>();
            Media = media;
            Tags = tags;
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