using LEMV.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LEMV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly INotificator _notificator;

        public BaseController(INotificator notificator)
        {
            _notificator = notificator;
        }
    }
}
