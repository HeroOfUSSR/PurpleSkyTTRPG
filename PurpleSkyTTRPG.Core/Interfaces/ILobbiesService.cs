using PurpleSkyTTRPG.Core.Models;

namespace PurpleSkyTTRPG.Core.Interfaces
{
    public interface ILobbiesService
    {
        Task<Guid> CreateLobbyAsync(Lobby newLobby);
        Task<Guid> DeleteLobbyAsync(Guid id);
        Task<List<Lobby>> GetLobbiesAsync();
        Task<Guid> UpdateLobbyAsync(Lobby newLobby);
    }
}