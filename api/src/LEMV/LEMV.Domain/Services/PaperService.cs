using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;

namespace LEMV.Domain.Services
{
    public class PaperService : BaseService<Paper>, IPaperService
    {
        private readonly IPaperRepository _paperRepository;

        public PaperService(INotificator notificator, IPaperRepository paperRepository) : base(notificator)
        {
            _paperRepository = paperRepository;
        }

        public Paper Create(Paper entity)
        {
            return _paperRepository.Add(entity); ;
        }

        public Paper Update(Paper entity)
        {
            return _paperRepository.Update(entity);
        }

        public void Delete(int id)
        {
            _paperRepository.Delete(id);

            return;
        }
    }
}
