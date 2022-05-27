using LEMV.Domain.Entities;

namespace LEMV.Domain.Interfaces
{
    public interface IProjectService
    {
        Project Create(Project entity);
        Project Update(Project entity);
        void Delete(int id);
    }
}
