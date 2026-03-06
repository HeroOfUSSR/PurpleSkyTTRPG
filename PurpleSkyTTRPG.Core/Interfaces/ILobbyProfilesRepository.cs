using PurpleSkyTTRPG.Core.Models;

namespace PurpleSkyTTRPG.Core.Interfaces
{
    public interface ILobbyProfilesRepository
    {
        Task<Guid> Create(LobbyProfile lobbyProfile);
        Task Delete(Guid id);
        Task<List<LobbyProfile>> Get();
        Task<Guid> Update(LobbyProfile lobbyProfile);
    }
}