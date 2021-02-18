using System;

namespace LEMV.Domain.Entities
{
    public class Project : Entity
    {
        public string[] Responsaveis { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public bool Disponivel { get; set; }

        public string LocalizacaoId { get; set; }

        public DateTime UltimoEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public string LocatarioId { get; set; }

        //ef
        //TODO: Definir o tipo (UserIdentity?)
        public int Locatario { get; set; }
        public Place Localizacao { get; set; }
    }
}