using System;

namespace LEMV.Domain.Entities
{
    public abstract class Entity
    {
        public string Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime UltimaModificacao { get; set; }
    }
}
