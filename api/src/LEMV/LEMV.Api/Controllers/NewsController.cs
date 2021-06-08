using LEMV.Data.Repositories;
using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LEMV.Api.Controllers
{
    public class NewsController : BaseController
    {
        private readonly NewsRepository _newsRepository;

        public NewsController(INotificator notificator, NewsRepository newsRepository) : base(notificator)
        {
            _newsRepository = newsRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_newsRepository.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var teste = await _newsRepository.GetById(id);

            if (teste == null)
                _notificator.Handle(new Domain.Notifications.Notification("Notícia não encontrada."));

            return CustomResponse(teste);
        }

        [HttpPut()]
        public async Task<IActionResult> PutAsync(News news)
        {
            var entity = _newsRepository.Update(news);
            await _newsRepository.SaveChanges();
            return CustomResponse(entity);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _newsRepository.Delete(id);
            await _newsRepository.SaveChanges();
            return CustomResponse(id);
        }

        public async Task<IActionResult> PostAsync(News news)
        {
            var entity = _newsRepository.Add(news);
            await _newsRepository.SaveChanges();
            return CustomResponse(entity);
        }
    }
}