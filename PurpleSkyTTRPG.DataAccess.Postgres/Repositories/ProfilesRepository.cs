using Microsoft.EntityFrameworkCore;
using PurpleSkyTTRPG.Core.Interfaces;
using PurpleSkyTTRPG.Core.Models;
using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Repositories
{
    public class ProfilesRepository : IProfilesRepository
    {
        private readonly TTRPGDbContext _dbContext;

        public ProfilesRepository(TTRPGDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Profile>> Get()
        {
            var profileEntities = await _dbContext.Profiles
                .AsNoTracking()
                .ToListAsync();

            var profiles = profileEntities
                .Select(l => Profile.Create(l.Id, l.Login, l.PasswordHash, l.ProfileJson).Profile)
                .ToList();

            return profiles;
        }

        public async Task<Guid> Create(Profile profile)
        {
            var profileEntity = new ProfileEntity
            {
                Id = profile.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Login = profile.Login,
                PasswordHash = profile.PasswordHash,
                ProfileJson = profile.ProfileJson,
            };

            await _dbContext.Profiles.AddAsync(profileEntity);
            await _dbContext.SaveChangesAsync();

            return profileEntity.Id;
        }

        public async Task<Guid> Update(Profile profile)
        {
            await _dbContext.Profiles
                .Where(l => l.Id == profile.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(l => l.UpdatedAt, DateTime.UtcNow)
                    .SetProperty(l => l.PasswordHash, profile.PasswordHash)
                    .SetProperty(l => l.ProfileJson, profile.ProfileJson));

            return profile.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _dbContext.Profiles
                .Where(l => l.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
