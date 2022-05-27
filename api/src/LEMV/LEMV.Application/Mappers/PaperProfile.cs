using AutoMapper;
using LEMV.Application.ViewModels;
using LEMV.Domain.Entities;

namespace LEMV.Application.Mappers
{
    public class PaperProfile : Profile
    {
        public PaperProfile()
        {
            CreateMap<Paper, PaperViewModel>().ReverseMap();
        }
    }
}