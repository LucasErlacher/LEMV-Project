using System;

namespace LEMV.Domain.Entities
{
    public class MediaInfo
    {
        public Guid FileId { get; set; }
        public string FileName { get; set; }
        public string Format { get; set; }
        public double Size { get; set; } //In Megabytes

        public MediaInfo()
        {

        }

        public MediaInfo(Guid fileId, string fileName, string format, double sizeMegabytes)
        {
            FileId = fileId;
            FileName = fileName;
            Format = format;
            Size = sizeMegabytes;
        }
    }
}
