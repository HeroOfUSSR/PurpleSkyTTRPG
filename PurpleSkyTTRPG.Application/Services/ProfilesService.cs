using PurpleSkyTTRPG.Core.Interfaces;
using PurpleSkyTTRPG.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleSkyTTRPG.Application.Services
{
    public class ProfilesService : IProfilesService
    {
        private readonly IProfilesRepository _profilesRepository;

        public ProfilesService(IProfilesRepository profilesRepository)
        {
            _profilesRepository = profilesRepository;
        }

        public async Task<List<Profile>> GetLobbyCharactersAsync()
        {
            return await _profilesRepository.Get();
        }

        public async Task<Guid> CreateLobbyCharacterAsync(Profile profile)
        {
            return await _profilesRepository.Create(profile);
        }

        public async Task<Guid> UpdateLobbyCharacterAsync(Profile profile)
        {
            return await _profilesRepository.Update(profile);
        }

        public async Task<Guid> DeleteLobbyCharacterAsync(Guid id)
        {
            return await _profilesRepository.Delete(id);
        }
    }
}
