using AutoMapper;
using LEMV.Application.ViewModels;
using LEMV.Domain.Entities;

namespace LEMV.Application.Mappers
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<News, NewsViewModel>();

            CreateMap<NewsViewModel, News>()
                .ConstructUsing(x => new News(x.Id, x.Subject, x.Content, x.AuthorId, x.LaboratoryId, x.CurrentState));
        }
    }
}