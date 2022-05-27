namespace LEMV.Domain.Entities
{
    public class News : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public string UrlImage { get; set; }
        public string Text { get; set; }

        public News(int id, string title, string description, string authorname, string urlimage, string text) : base(id)
        {
            Title = title;
            Description = description;
            AuthorName = authorname;
            UrlImage = urlimage;
            Text = text;
        }

        public News(int id, string title, string authorName) : base(id)
        {
            Title = title;
            AuthorName = authorName;
        }
    }
}