using PurpleSkyTTRPG.Core.Enum;
using PurpleSkyTTRPG.Core.Interfaces;
using PurpleSkyTTRPG.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.Application.Services
{
    public class CharactersService : ICharactersService
    {
        private readonly ICharactersRepository _charactersRepository;

        public CharactersService(ICharactersRepository charactersRepository)
        {
            _charactersRepository = charactersRepository;
        }

        public async Task<List<Character>> GetCharactersAsync()
        {
            return await _charactersRepository.Get();
        }

        public async Task<Guid> CreateCharacterAsync(Character character)
        {
            return await _charactersRepository.Create(character);
        }

        public async Task<Guid> UpdateCharacterAsync(Character character)
        {
            return await _charactersRepository.Update(character);
        }

        public async Task<Guid> DeleteCharacterAsync(Guid id)
        {
            return await _charactersRepository.Delete(id);
        }
    }
}
