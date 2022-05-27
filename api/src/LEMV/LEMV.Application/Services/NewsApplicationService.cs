using AutoMapper;
using LEMV.Application.Services.Interfaces;
using LEMV.Application.ViewModels;
using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;

namespace LEMV.Application.Services
{
    public class NewsAppService : INewsAppService
    {
        private readonly IMapper _mapper;
        private readonly INewsService _service;
        private readonly INewsRepository _newsRepository;

        public NewsAppService(IMapper mapper, INewsService service, INewsRepository newsRepository)
        {
            _mapper = mapper;
            _service = service;
            _newsRepository = newsRepository;
        }

        public NewsViewModel CreateNews(NewsViewModel news)
        {
            var entity = _mapper.Map<News>(news);

            entity = _service.Create(entity);

            return _mapper.Map<NewsViewModel>(entity);
        }

        public NewsViewModel UpdateNews(NewsViewModel news)
        {
            var entity = _mapper.Map<News>(news);

            entity = _service.Update(entity);

            return _mapper.Map<NewsViewModel>(entity);
        }

        public void DeleteNews(int id)
        {
            _service.Delete(id);
        }
    }
}