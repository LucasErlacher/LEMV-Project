namespace LEMV.Domain.Entities
{
    public class Project : Entity
    {
        public object[] Imagens { get; set; }

        public string Nome { get; set; }
        public string Autor { get; set; }
        public string ComoUsar { get; set; }
    }
}