using PurpleSkyTTRPG.Core.Models;

namespace PurpleSkyTTRPG.Core.Interfaces
{
    public interface IProfilesService
    {
        Task<List<Profile>> GetProfilesAsync();
        Task<Guid> CreateProfileAsync(Profile profile);
        Task<Guid> DeleteProfileAsync(Guid id);
        Task<Guid> UpdateProfileAsync(Profile profile);
    }
}