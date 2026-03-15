using PurpleSkyTTRPG.Core.Models;

namespace PurpleSkyTTRPG.Core.Interfaces
{
    public interface ILobbiesRepository
    {
        Task<Guid> Create(Lobby lobby);
        Task<Guid> Delete(Guid id);
        Task<List<Lobby>> Get();
        Task<Guid> Update(Lobby lobby);
    }
}