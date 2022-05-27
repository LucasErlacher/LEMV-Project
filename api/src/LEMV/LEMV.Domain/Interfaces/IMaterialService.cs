using LEMV.Domain.Entities;

namespace LEMV.Domain.Interfaces
{
    public interface IMaterialService
    {
        Material Create(Material entity);
        Material Update(Material entity);
        void Delete(int id);
    }
}
