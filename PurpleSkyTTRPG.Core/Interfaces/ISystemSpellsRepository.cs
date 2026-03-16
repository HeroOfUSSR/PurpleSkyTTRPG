using PurpleSkyTTRPG.Core.Enum;
using PurpleSkyTTRPG.Core.Models;

namespace PurpleSkyTTRPG.Core.Interfaces
{
    public interface ISystemSpellsRepository
    {
        Task<List<SystemSpell>> GetBySystem(GameSystem system);
    }
}