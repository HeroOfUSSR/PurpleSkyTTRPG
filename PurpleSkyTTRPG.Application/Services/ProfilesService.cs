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

        public async Task<List<Profile>> GetProfilesAsync()
        {
            return await _profilesRepository.Get();
        }

        public async Task<Guid> CreateProfileAsync(Profile profile)
        {
            return await _profilesRepository.Create(profile);
        }

        public async Task<Guid> UpdateProfileAsync(Profile profile)
        {
            return await _profilesRepository.Update(profile);
        }

        public async Task<Guid> DeleteProfileAsync(Guid id)
        {
            return await _profilesRepository.Delete(id);
        }
    }
}
