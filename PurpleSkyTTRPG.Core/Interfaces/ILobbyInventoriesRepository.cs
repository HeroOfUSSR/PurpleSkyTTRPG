using PurpleSkyTTRPG.Core.Models;

namespace PurpleSkyTTRPG.Core.Interfaces
{
    public interface ILobbyInventoriesRepository
    {
        Task<Guid> Create(LobbyInventory lobbyInventory);
        Task<Guid> Delete(Guid id);
        Task<List<LobbyInventory>> Get();
        Task<Guid> Update(LobbyInventory lobbyInventory);
    }
}