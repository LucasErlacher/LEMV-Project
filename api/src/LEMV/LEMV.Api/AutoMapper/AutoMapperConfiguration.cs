using AutoMapper;
using LEMV.Api.ViewModels;
using LEMV.Domain.Entities;

namespace LEMV.Api.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Project, ProjectViewModel>().ReverseMap();
        }
    }
}
