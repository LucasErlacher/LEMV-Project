using LEMV.Domain.Entities;
using System.Collections.Generic;

namespace LEMV.Domain.Interfaces.Repositories
{
    public interface IFakeDatabase
    {
        ICollection<News> News { get; }
    }
}
