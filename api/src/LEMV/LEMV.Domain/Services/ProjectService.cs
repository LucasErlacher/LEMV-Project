using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;

namespace LEMV.Domain.Services
{
    public class ProjectService : BaseService<Project>, IProjectService
    {
        public ProjectService(INotificator notificator) : base(notificator)
        {
        }

        public bool RequestProject(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
