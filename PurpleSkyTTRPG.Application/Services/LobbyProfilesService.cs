using PurpleSkyTTRPG.Core.Interfaces;
using PurpleSkyTTRPG.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleSkyTTRPG.Application.Services
{
    public class LobbyProfilesService : ILobbyProfilesService
    {
        private readonly ILobbyProfilesRepository _lobbyProfilesRepository;

        public LobbyProfilesService(ILobbyProfilesRepository lobbyProfilesRepository)
        {
            _lobbyProfilesRepository = lobbyProfilesRepository;
        }

        public async Task<List<LobbyProfile>> GetLobbyCharactersAsync()
        {
            return await _lobbyProfilesRepository.Get();
        }

        public async Task<Guid> CreateLobbyCharacterAsync(LobbyProfile lobbyProfile)
        {
            return await _lobbyProfilesRepository.Create(lobbyProfile);
        }

        public async Task<Guid> UpdateLobbyCharacterAsync(LobbyProfile lobbyProfile)
        {
            return await _lobbyProfilesRepository.Update(lobbyProfile);
        }

        public async Task<Guid> DeleteLobbyCharacterAsync(Guid id)
        {
            return await _lobbyProfilesRepository.Delete(id);
        }
    }
}
