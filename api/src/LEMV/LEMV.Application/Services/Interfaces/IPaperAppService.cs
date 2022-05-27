using LEMV.Application.ViewModels;

namespace LEMV.Domain.Interfaces
{
    public interface IPaperAppService
    {
        PaperViewModel CreatePaper(PaperViewModel news);
        PaperViewModel UpdatePaper(PaperViewModel news);
        void DeletePaper(int id);
    }
}
