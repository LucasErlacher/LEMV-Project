using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;

namespace LEMV.Domain.Services
{
    public class ProjectService : BaseService, IProjectService
    {
        public ProjectService(INotificator notificator) : base(notificator)
        {
        }

        public void Add(Project project)
        {
            throw new System.NotImplementedException();
        }

        public void Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Project project)
        {
            throw new System.NotImplementedException();
        }
    }
}
