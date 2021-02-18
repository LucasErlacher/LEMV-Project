namespace LEMV.Domain.Entities
{
    public class Equipment : Entity
    {
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string LocalizacaoId { get; set; }

        //ef
        public Place Localizacao { get; set; }
    }
}
