using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;

namespace LEMV.Domain.Services
{
    public class NewsService : BaseService<News>, INewsService
    {
        private readonly INewsRepository _newsRepository;

        public NewsService(INotificator notificator, INewsRepository newsRepository) : base(notificator)
        {
            _newsRepository = newsRepository;
        }

        public News Create(News entity)
        {
            _newsRepository.Create(entity);

            return entity;
        }
    }
}
