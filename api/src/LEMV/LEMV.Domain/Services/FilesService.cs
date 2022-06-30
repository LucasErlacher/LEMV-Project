using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;
using System;
using System.IO;

namespace LEMV.Domain.Services
{
    public class FilesService : IFilesService
    {
        private readonly IFilesRepository _filesRepository;

        public FilesService(IFilesRepository filesRepository)
        {
            _filesRepository = filesRepository;
        }

        public MediaInfo Upload(string fileName, Stream fileStream)
        {
            return _filesRepository.Upload(fileName, fileStream);
        }

        public void Download(Guid id, Stream fileStream)
        {
            _filesRepository.Download(id, fileStream);
        }

        public MediaInfo Details(Guid id)
        {
            return _filesRepository.Details(id);
        }
    }
}
