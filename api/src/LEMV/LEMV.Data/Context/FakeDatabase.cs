using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace LEMV.Data.Context
{
    public class FakeDatabase : IFakeDatabase
    {
        ICollection<News> _news { get; set; }


        //Interface
        ICollection<News> IFakeDatabase.News => _news;

        public FakeDatabase()
        {
            _news = new List<News>();
        }
    }
}
