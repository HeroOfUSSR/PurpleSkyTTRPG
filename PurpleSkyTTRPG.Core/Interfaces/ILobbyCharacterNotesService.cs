using PurpleSkyTTRPG.Core.Models;

namespace PurpleSkyTTRPG.Core.Interfaces
{
    public interface ILobbyCharacterNotesService
    {
        Task<Guid> CreateCharacterAsync(LobbyCharacterNote lobbyCharacterNote);
        Task<Guid> DeleteLobbyCharacterNoteAsync(Guid id);
        Task<List<LobbyCharacterNote>> GetCharactersAsync();
        Task<Guid> UpdateLobbyCharacterNoteAsync(LobbyCharacterNote lobbyCharacterNote);
    }
}