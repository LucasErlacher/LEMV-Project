using LEMV.Application.Services.Interfaces;
using LEMV.Application.ViewModels;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;
using LEMV.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace LEMV.Api.Controllers
{
    public class NewsController : BaseController
    {
        private readonly INewsAppService _newsApp;
        private readonly INewsRepository _newsRepository;

        public NewsController(INotificator notificator, INewsAppService newsApp, INewsRepository newsRepository) : base(notificator)
        {
            _newsApp = newsApp;
            _newsRepository = newsRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_newsRepository.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var teste = _newsRepository.GetById(id);

            if (teste == null)
                _notificator.Handle(new Notification("Notícia não encontrada."));

            return CustomResponse(teste);
        }

        [HttpPost()]
        public IActionResult PostAsync(NewsViewModel news)
        {
            NewsViewModel result = _newsApp.CreateNews(news);

            return CustomResponse(result);
        }

        [HttpPut()]
        public IActionResult PutAsync(NewsViewModel news)
        {
            return CustomResponse(news);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(int id)
        {
            return CustomResponse(id);
        }
    }
}