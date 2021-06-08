using LEMV.Domain.Entities;
using System;

namespace LEMV.Application.ViewModels
{
    public class NewsViewModel
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string YoutubeUrl { get; set; }
        public Guid AuthorId { get; set; }
        public Guid LaboratoryId { get; set; }
        public PublishState CurrentState { get; set; }

        //public virtual AppUserViewModel Author { get; set; }
        //public virtual LaboratoryViewModel Laboratory { get; set; }
    }
}