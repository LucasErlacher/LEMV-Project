using System;
using System.Collections.Generic;

namespace LEMV.Domain.Entities
{
    public class News : Entity
    {
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string AuthorName { get; set; }
        public virtual DateTime PublishedIn { get; set; }
        public virtual MediaInfo Media { get; set; }
        public virtual string UrlImage { get; set; }

        public virtual string Resume { get; set; }

        public virtual int SkillId { get; set; }
        public virtual ICollection<int> AbilitieIds { get; set; }
        public List<string> Tags { get; set; }

        public News() : base()
        {

        }

        public News(int id, string title, string description, string authorName, DateTime publishedIn, MediaInfo media, List<string> tags, string urlImage, string resume) : base(id)
        {
            Title = title;
            Description = description;
            AuthorName = authorName;
            PublishedIn = publishedIn;
            Media = media;
            Tags = tags;
            UrlImage = urlImage;
            Resume = resume;
        }

        public News(int id, string title, string authorName) : base(id)
        {
            Title = title;
            AuthorName = authorName;
        }
    }
}