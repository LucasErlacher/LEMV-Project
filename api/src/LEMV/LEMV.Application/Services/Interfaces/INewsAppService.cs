using LEMV.Application.ViewModels;

namespace LEMV.Application.Services.Interfaces
{
    public interface INewsAppService
    {
        NewsViewModel CreateNews(NewsViewModel news);
    }
}
