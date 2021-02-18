using System;

namespace LEMV.Domain.Entities
{
    public class News : Entity
    {
        public string Subject { get; set; }
        public string Content { get; set; }

        public string Author { get; set; }
        public PublishState CurrentState { get; set; }

        protected News() { /*Entity Framework*/ }

        public News(Guid id, string subject, string content, string author)
        {
            Id = id;
            Subject = subject;
            Content = content;
            Author = author;

            CurrentState = PublishState.Draft;
        }

        public News(Guid id, string subject, string content, string author, PublishState state)
        {
            Id = id;
            Subject = subject;
            Content = content;
            Author = author;

            CurrentState = state;
        }

        public void Publish()
        {
            if (string.IsNullOrEmpty(Subject) || string.IsNullOrEmpty(Content))
                throw new InvalidOperationException();

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
    }

    public enum PublishState
    {
        Draft = 1,
        Published
    }
}
