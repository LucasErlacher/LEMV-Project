using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;

namespace LEMV.Domain.Services
{
    public class MaterialService : BaseService<Material>, IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService(INotificator notificator, IMaterialRepository materialRepository) : base(notificator)
        {
            _materialRepository = materialRepository;
        }

        public Material Create(Material entity)
        {
            return _materialRepository.Add(entity); ;
        }

        public Material Update(Material entity)
        {
            return _materialRepository.Update(entity);
        }

        public void Delete(int id)
        {
            _materialRepository.Delete(id);

            return;
        }
    }
}
