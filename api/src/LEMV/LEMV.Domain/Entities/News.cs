using System;
using System.Collections.Generic;

namespace LEMV.Domain.Entities
{
    public class News : Entity
    {
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string AuthorName { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime PublishedIn { get; set; }
        public virtual MediaInfo Media { get; set; }

        public virtual int SkillId { get; set; }
        public virtual ICollection<int> AbilitieIds { get; set; }

        public News() : base()
        {

        }

        public News(int id, string title, string description, string authorName, string text, DateTime publishedIn, MediaInfo media) : base(id)
        {
            Title = title;
            Description = description;
            AuthorName = authorName;
            Text = text;
            PublishedIn = publishedIn;
            Media = media;
        }

        public News(int id, string title, string authorName) : base(id)
        {
            Title = title;
            AuthorName = authorName;
        }
    }
}