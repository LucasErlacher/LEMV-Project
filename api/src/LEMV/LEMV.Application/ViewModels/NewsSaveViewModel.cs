using System.Collections.Generic;

namespace LEMV.Application.ViewModels
{
    public class NewsSaveViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public MediaInfoViewModel Media { get; set; }
        public int SkillId { get; set; }
        public ICollection<int> AbilitieIds { get; set; }
    }
}