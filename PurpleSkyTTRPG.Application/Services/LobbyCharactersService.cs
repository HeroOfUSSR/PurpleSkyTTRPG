using PurpleSkyTTRPG.Core.Interfaces;
using PurpleSkyTTRPG.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleSkyTTRPG.Application.Services
{
    public class LobbyCharactersService : ILobbyCharactersService
    {
        private readonly ILobbyCharactersRepository _lobbyCharactersRepository;

        public LobbyCharactersService(ILobbyCharactersRepository lobbyCharactersRepository)
        {
            _lobbyCharactersRepository = lobbyCharactersRepository;
        }

        public async Task<List<LobbyCharacter>> GetLobbyCharactersAsync()
        {
            return await _lobbyCharactersRepository.Get();
        }

        public async Task<Guid> CreateLobbyCharacterAsync(LobbyCharacter lobbyCharacter)
        {
            return await _lobbyCharactersRepository.Create(lobbyCharacter);
        }

        public async Task<Guid> UpdateLobbyCharacterAsync(LobbyCharacter lobbyCharacter)
        {
            return await _lobbyCharactersRepository.Update(lobbyCharacter);
        }

        public async Task<Guid> DeleteLobbyCharacterAsync(Guid id)
        {
            return await _lobbyCharactersRepository.Delete(id);
        }
    }
}
