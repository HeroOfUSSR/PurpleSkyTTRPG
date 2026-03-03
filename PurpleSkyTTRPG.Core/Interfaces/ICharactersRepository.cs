using PurpleSkyTTRPG.Core.Enum;
using PurpleSkyTTRPG.Core.Models;

namespace PurpleSkyTTRPG.Core.Interfaces
{
    public interface ICharactersRepository
    {
        Task<Guid> Create(Character character);
        Task Delete(Guid id);
        Task<List<Character>> Get();
        Task<Guid> Update(Guid id, DateTime createdAt, DateTime updatedAt, Guid ownerId, GameSystem system, string characterName, string dataJson, Guid? partyId);
    }
}