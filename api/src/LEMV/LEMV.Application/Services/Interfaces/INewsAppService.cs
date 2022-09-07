using LEMV.Application.ViewModels;
using System.Collections.Generic;

namespace LEMV.Application.Services.Interfaces
{
    public interface INewsAppService
    {
        NewsViewModel CreateNews(NewsSaveViewModel news);
        NewsViewModel UpdateNews(NewsSaveViewModel news);
        ICollection<NewsViewModel> GetAll();
        NewsViewModel GetById(int id);
        void DeleteNews(int id);
    }
}
