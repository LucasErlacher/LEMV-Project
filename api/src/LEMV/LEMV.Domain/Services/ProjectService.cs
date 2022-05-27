using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;

namespace LEMV.Domain.Services
{
    public class ProjectService : BaseService<Project>, IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(INotificator notificator, IProjectRepository projectRepository) : base(notificator)
        {
            _projectRepository = projectRepository;
        }

        public Project Create(Project entity)
        {
            return _projectRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _projectRepository.Delete(id);
            return;
        }

        public Project Update(Project entity)
        {
            return _projectRepository.Update(entity);
        }
    }
}
