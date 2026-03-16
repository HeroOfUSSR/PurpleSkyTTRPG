using PurpleSkyTTRPG.Core.Enum;
using PurpleSkyTTRPG.Core.Models;

namespace PurpleSkyTTRPG.Core.Interfaces
{
    public interface ISystemSkillsRepository
    {
        Task<List<SystemSkill>> GetBySystem(GameSystem system);
    }
}