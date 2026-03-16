using PurpleSkyTTRPG.Core.Enum;
using PurpleSkyTTRPG.Core.Models;

namespace PurpleSkyTTRPG.Core.Interfaces
{
    public interface ISystemItemsRepository
    {
        Task<SystemItem?> GetById(Guid id);
        Task<List<SystemItem>> GetBySystem(GameSystem system);
    }
}