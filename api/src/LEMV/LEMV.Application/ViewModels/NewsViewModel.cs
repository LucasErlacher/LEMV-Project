﻿namespace LEMV.Application.ViewModels
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public MediaInfoViewModel Media { get; set; }
    }
}