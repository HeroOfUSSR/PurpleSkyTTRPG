using PurpleSkyTTRPG.Core.Models;

namespace PurpleSkyTTRPG.Core.Interfaces
{
    public interface ILobbyCharacterNotesRepository
    {
        Task<Guid> Create(LobbyCharacterNote lobbyCharacterNote);
        Task<Guid> Delete(Guid id);
        Task<List<LobbyCharacterNote>> Get();
        Task<Guid> Update(LobbyCharacterNote lobbyCharacterNote);
    }
}