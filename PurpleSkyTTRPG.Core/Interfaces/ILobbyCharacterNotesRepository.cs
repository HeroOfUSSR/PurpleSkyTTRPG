using PurpleSkyTTRPG.Core.Models;

namespace PurpleSkyTTRPG.Core.Interfaces
{
    public interface ILobbyCharacterNotesRepository
    {
        Task<Guid> Create(LobbyCharacterNote lobbyCharacterNote);
        Task Delete(Guid id);
        Task<List<LobbyCharacterNote>> Get();
        Task<Guid> Update(LobbyCharacterNote lobbyCharacterNote);
    }
}