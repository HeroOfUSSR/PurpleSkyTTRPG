using PurpleSkyTTRPG.Core.Models;

namespace PurpleSkyTTRPG.Core.Interfaces
{
    public interface ILobbyCharactersRepository
    {
        Task<Guid> Create(LobbyCharacter lobbyCharacter);
        Task Delete(Guid id);
        Task<List<LobbyCharacter>> Get();
        Task<Guid> Update(LobbyCharacter lobbyCharacter);
    }
}