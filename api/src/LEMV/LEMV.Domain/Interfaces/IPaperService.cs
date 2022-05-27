using LEMV.Domain.Entities;

namespace LEMV.Domain.Interfaces
{
    public interface IPaperService
    {
        Paper Create(Paper entity);
        Paper Update(Paper entity);
        void Delete(int id);
    }
}
