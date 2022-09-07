using LEMV.Application.ViewModels;
using System.Collections.Generic;

namespace LEMV.Application.Services.Interfaces
{
    public interface IProjectAppService
    {
        ProjectViewModel CreateProject(ProjectSaveViewModel news);
        ProjectViewModel UpdateProject(ProjectSaveViewModel news);
        ICollection<ProjectViewModel> GetAll();
        ProjectViewModel GetById(int id);
        void DeleteProject(int id);
    }
}
