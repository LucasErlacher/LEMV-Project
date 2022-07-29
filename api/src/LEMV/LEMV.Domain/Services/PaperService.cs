using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;

namespace LEMV.Domain.Services
{
    public class PaperService : BaseService<Paper>, IPaperService
    {
        public PaperService(INotificator notificator, IPaperRepository paperRepository) : base(notificator, paperRepository) { }
    }
}
