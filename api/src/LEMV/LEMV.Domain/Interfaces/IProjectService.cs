using LEMV.Domain.Entities;

namespace LEMV.Domain.Interfaces
{
    public interface IProjectService
    {
        void Add(Project project);
        void Update(Project project);
        void Get(int id);
        void Remove(int id);
    }
}
