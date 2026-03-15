using PurpleSkyTTRPG.Core.Models;

namespace PurpleSkyTTRPG.Core.Interfaces
{
    public interface IProfilesService
    {
        Task<Guid> CreateLobbyCharacterAsync(Profile profile);
        Task<Guid> DeleteLobbyCharacterAsync(Guid id);
        Task<List<Profile>> GetLobbyCharactersAsync();
        Task<Guid> UpdateLobbyCharacterAsync(Profile profile);
    }
}