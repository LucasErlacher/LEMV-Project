using LEMV.Application.ViewModels;
using System.Collections.Generic;

namespace LEMV.Domain.Interfaces
{
    public interface IArtifactAppService
    {
        ArtifactViewModel CreateArtifact(ArtifactSaveViewModel artifact);
        ArtifactViewModel UpdateArtifact(ArtifactSaveViewModel artifact);
        ICollection<ArtifactViewModel> GetAll();
        ArtifactViewModel GetById(int id);
        void DeleteArtifact(int id);
    }
}
