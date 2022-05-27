using LEMV.Application.ViewModels;

namespace LEMV.Domain.Interfaces
{
    public interface IMaterialAppService
    {
        MaterialViewModel CreateMaterial(MaterialViewModel news);
        MaterialViewModel UpdateMaterial(MaterialViewModel news);
        void DeleteMaterial(int id);
    }
}
