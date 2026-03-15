using PurpleSkyTTRPG.Core.Models;

namespace PurpleSkyTTRPG.Core.Interfaces
{
    public interface ILobbyCharactersService
    {
        Task<Guid> CreateLobbyCharacterAsync(LobbyCharacter lobbyCharacter);
        Task<Guid> DeleteLobbyCharacterAsync(Guid id);
        Task<List<LobbyCharacter>> GetLobbyCharactersAsync();
        Task<Guid> UpdateLobbyCharacterAsync(LobbyCharacter lobbyCharacter);
    }
}