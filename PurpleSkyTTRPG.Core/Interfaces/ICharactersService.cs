using PurpleSkyTTRPG.Core.Models;

namespace PurpleSkyTTRPG.Core.Interfaces
{
    public interface ICharactersService
    {
        Task<Guid> CreateCharacterAsync(Character character);
        Task<Guid> DeleteCharacterAsync(Guid id);
        Task<List<Character>> GetCharactersAsync();
        Task<Guid> UpdateCharacterAsync(Character character);
    }
}