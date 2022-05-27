using AutoMapper;
using LEMV.Application.Services.Interfaces;
using LEMV.Application.ViewModels;
using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;

namespace LEMV.Application.Services
{
    public class ProjectAppService : IProjectAppService
    {
        private readonly IMapper _mapper;
        private readonly IProjectService _service;

        public ProjectAppService(IMapper mapper, IProjectService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public ProjetoViewModel CreateProject(ProjetoViewModel news)
        {
            var entity = _mapper.Map<Project>(news);

            entity = _service.Create(entity);

            return _mapper.Map<ProjetoViewModel>(entity);
        }

        public ProjetoViewModel UpdateProject(ProjetoViewModel news)
        {
            var entity = _mapper.Map<Project>(news);

            entity = _service.Update(entity);

            return _mapper.Map<ProjetoViewModel>(entity);
        }

        public void DeleteProject(int id)
        {
            _service.Delete(id);
        }
    }
}