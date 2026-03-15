using PurpleSkyTTRPG.Core.Enum;
using PurpleSkyTTRPG.Core.Models;

namespace PurpleSkyTTRPG.Core.Interfaces
{
    public interface ICharactersRepository
    {
        Task<Guid> Create(Character character);
        Task<Guid> Delete(Guid id);
        Task<List<Character>> Get();
        Task<Guid> Update(Character character);
    }
}