using LEMV.Application.ViewModels;
using System;
using System.IO;

namespace LEMV.Application.Services.Interfaces
{
    public interface IFilesAppService
    {
        MediaInfoViewModel Upload(string fileName, Stream fileStream);
        MediaInfoViewModel Download(Guid id, Stream fileStream);
    }
}
