using LEMV.Domain.Entities;
using System;
using System.IO;

namespace LEMV.Domain.Interfaces.Repositories
{
    public interface IFilesRepository
    {
        MediaInfo Upload(string fileName, Stream fileStream);
        void Download(Guid id, Stream fileStream);
        MediaInfo Details(Guid id);
    }
}
