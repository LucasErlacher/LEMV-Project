using LEMV.Application.ViewModels;

namespace LEMV.Application.Services.Interfaces
{
    public interface IProjectAppService
    {
        ProjetoViewModel CreateProject(ProjetoViewModel news);
        ProjetoViewModel UpdateProject(ProjetoViewModel news);
        void DeleteProject(int id);
    }
}
