namespace LEMV.Domain.Entities
{
    public class News : Entity
    {
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public string AuthorName { get; protected set; }
        public string UrlImage { get; protected set; }
        public string Text { get; protected set; }

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

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetAuthor(string authorName)
        {
            AuthorName = authorName;
        }

        public void SetUrlImage(string url)
        {
            UrlImage = url;
        }
    }
}