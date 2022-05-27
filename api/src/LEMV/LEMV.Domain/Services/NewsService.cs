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
            return _newsRepository.Add(entity); ;
        }

        public News Update(News entity)
        {
            return _newsRepository.Update(entity);
        }

        public void Delete(int id)
        {
            _newsRepository.Delete(id);

            return;
        }
    }
}
