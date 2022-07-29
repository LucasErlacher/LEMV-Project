using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;
using System;

namespace LEMV.Domain.Services
{
    public class NewsService : BaseService<News>, INewsService
    {
        public NewsService(INotificator notificator, INewsRepository newsRepository) : base(notificator, newsRepository) { }

        public override News Create(News entity)
        {
            var currentDate = DateTime.Now;

            entity.PublishedIn = currentDate;
            entity.CreatedAt = currentDate;
            entity.LastMofication = currentDate;

            return _repository.Add(entity); ;
        }
    }
}
