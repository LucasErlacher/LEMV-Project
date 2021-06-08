using LEMV.Domain.Interfaces;

namespace LEMV.Api.Controllers
{
    public class LaboratoryController : BaseController
    {
        public LaboratoryController(INotificator notificator) : base(notificator)
        {
        }
    }
}