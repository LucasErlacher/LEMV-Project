using LEMV.Domain.Entities.Core;
using System;

namespace LEMV.Domain.Entities
{
    public class News : Entity
    {
        public string Subject { get; protected set; }
        public string Content { get; protected set; }
        public string YoutubeUrl { get; set; }
        public Guid AuthorId { get; protected set; }
        public Guid LaboratoryId { get; protected set; }
        public PublishState CurrentState { get; protected set; }

        public virtual AppUser Author { get; protected set; }
        public virtual Laboratory Laboratory { get; protected set; }

        protected News()
        {
            /*Entity Framework*/
        }

        public News(Guid id, string subject, string content, Guid authorId, Guid labId) : base(id)
        {
            Subject = subject;
            Content = content;
            AuthorId = authorId;
            LaboratoryId = labId;

            CurrentState = PublishState.Draft;
        }

        public News(Guid id, string subject, string content, Guid authorId, Guid labId, PublishState state) : base(id)
        {
            Subject = subject;
            Content = content;
            AuthorId = authorId;
            LaboratoryId = labId;

            CurrentState = state;
        }

        public void Publish()
        {
            if (string.IsNullOrEmpty(Subject) || string.IsNullOrEmpty(Content))
                throw new ArgumentNullException();

            CurrentState = PublishState.Published;
        }

        public void Hide()
        {
            if (CurrentState == PublishState.Published)
                CurrentState = PublishState.Draft;
        }

        public bool IsPublished()
        {
            return CurrentState == PublishState.Published;
        }

        public void ChangeSubject(string subject)
        {
            if (string.IsNullOrEmpty(subject))
                throw new ArgumentNullException();

            Subject = subject;
        }

        public void ChangeContent(string content)
        {
            Content = content;
        }

        public void SetMediaUrl(string url)
        {
            YoutubeUrl = url;
        }
    }

    public enum PublishState
    {
        Draft = 1,
        Published
    }
}