namespace LEMV.Domain.Entities
{
    public class Paper : Entity
    {
        public string Title { get; set; }
        public string Resume { get; set; }
        public string Img { get; set; }

        public Paper()
        {

        }

        public Paper(int id, string title, string resume, string img) : base(id)
        {
            Title = title;
            Resume = resume;
            Img = img;
        }
    }
}
