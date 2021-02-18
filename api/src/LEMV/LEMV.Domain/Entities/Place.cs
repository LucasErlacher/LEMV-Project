using System;

namespace LEMV.Domain.Entities
{
    public class Place : Entity
    {
        public string Nome { get; set; }
    }

    public class HorarioFuncionamento
    {
        public int Id { get; set; }

        public DiaSemana DiaSemana { get; }
        public TimeSpan Inicio { get; }
        public TimeSpan Fim { get; }

        public int LocalId { get; set; }

        //ef
        public Place Local { get; set; }

        public HorarioFuncionamento(DiaSemana DiaSemana, TimeSpan Inicio, TimeSpan Fim)
        {
            this.DiaSemana = DiaSemana;
            this.Inicio = Inicio;
            this.Fim = Fim;
        }

        public static explicit operator HorarioFuncionamento(DiaSemana ds)
        {
            throw new NotImplementedException();
            //return new HorarioFuncionamento(ds, ini, fim);
        }
    }

    [Flags]
    public enum DiaSemana
    {
        Domingo = 1,
        Segunda = 1 << 1,
        Terca = 1 << 2,
        Quarta = 1 << 3,
        Quinta = 1 << 4,
        Sexta = 1 << 5,
        Sabado = 1 << 6
    }
}
