using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces.Repositories;
using LiteDB;
using System;
using System.IO;

namespace LEMV.Data.Repositories
{
    public class FilesRepository : IFilesRepository, IDisposable
    {
        private readonly LiteDatabase _db;

        public FilesRepository(LiteDatabase db)
        {
            _db = db;
        }

        public MediaInfo Upload(string fileName, Stream fileStream)
        {
            fileStream.Position = 0;
            var fileMetadata = _db.FileStorage.Upload(Guid.NewGuid().ToString(), fileName, fileStream);

            return new MediaInfo(
                Guid.Parse(fileMetadata.Id),
                fileMetadata.Filename,
                fileMetadata.MimeType,
                fileMetadata.Length
            );
        }

        public void Download(Guid id, Stream fileStream)
        {
            _db.FileStorage.Download(id.ToString(), fileStream);
        }

        public MediaInfo Details(Guid id)
        {
            var result = _db.FileStorage.FindById(id.ToString());

            return new MediaInfo(
                Guid.Parse(result.Id),
                result.Filename,
                result.MimeType,
                result.Length
            );
        }

        public void Dispose()
        {
            if (_db != null)
                _db.Dispose();
        }
    }
}
