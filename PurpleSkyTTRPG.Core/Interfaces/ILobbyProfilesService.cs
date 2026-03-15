using PurpleSkyTTRPG.Core.Models;

namespace PurpleSkyTTRPG.Core.Interfaces
{
    public interface ILobbyProfilesService
    {
        Task<Guid> CreateLobbyCharacterAsync(LobbyProfile lobbyProfile);
        Task<Guid> DeleteLobbyCharacterAsync(Guid id);
        Task<List<LobbyProfile>> GetLobbyCharactersAsync();
        Task<Guid> UpdateLobbyCharacterAsync(LobbyProfile lobbyProfile);
    }
}