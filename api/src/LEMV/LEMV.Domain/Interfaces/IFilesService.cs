using LEMV.Domain.Entities;
using System;
using System.IO;

namespace LEMV.Domain.Interfaces
{
    public interface IFilesService
    {
        MediaInfo Upload(string fileName, Stream fileStream);
        void Download(Guid id, Stream fileStream);
        MediaInfo Details(Guid id);
    }
}
