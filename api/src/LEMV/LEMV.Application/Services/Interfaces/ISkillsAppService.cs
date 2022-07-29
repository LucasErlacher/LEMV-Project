using LEMV.Application.ViewModels;

namespace LEMV.Application.Services.Interfaces
{
    public interface ISkillsAppService
    {
        SkillViewModel CreateSkill(SkillViewModel news);
        SkillViewModel UpdateSkill(SkillViewModel news);
        void DeleteSkill(int id);
    }
}
