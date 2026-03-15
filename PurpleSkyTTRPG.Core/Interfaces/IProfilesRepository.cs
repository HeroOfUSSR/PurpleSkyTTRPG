using PurpleSkyTTRPG.Core.Models;

namespace PurpleSkyTTRPG.Core.Interfaces
{
    public interface IProfilesRepository
    {
        Task<Guid> Create(Profile profile);
        Task<Guid> Delete(Guid id);
        Task<List<Profile>> Get();
        Task<Guid> Update(Profile profile);
    }
}