using Microsoft.EntityFrameworkCore;
using PurpleSkyTTRPG.Core.Interfaces;
using PurpleSkyTTRPG.Core.Models;
using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Repositories
{
    public class LobbyProfilesRepository : ILobbyProfilesRepository
    {
        private readonly TTRPGDbContext _dbContext;

        public LobbyProfilesRepository(TTRPGDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LobbyProfile>> Get()
        {
            var lobbyProfileEntities = await _dbContext.LobbyProfiles
                .AsNoTracking()
                .ToListAsync();

            var lobbiesProfiles = lobbyProfileEntities
                .Select(l => LobbyProfile.Create(l.Id, l.LobbyId, l.ProfileId).LobbyProfile)
                .ToList();

            return lobbiesProfiles;
        }

        public async Task<Guid> Create(LobbyProfile lobbyProfile)
        {
            var lobbyProfileEntity = new LobbyProfileEntity
            {
                Id = lobbyProfile.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                LobbyId = lobbyProfile.LobbyId,
                ProfileId = lobbyProfile.ProfileId,
            };

            await _dbContext.LobbyProfiles.AddAsync(lobbyProfileEntity);
            await _dbContext.SaveChangesAsync();

            return lobbyProfileEntity.Id;
        }

        public async Task<Guid> Update(LobbyProfile lobbyProfile)
        {
            await _dbContext.LobbyProfiles
                .Where(l => l.Id == lobbyProfile.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(l => l.UpdatedAt, DateTime.UtcNow)
                    .SetProperty(l => l.LobbyId, lobbyProfile.LobbyId)
                    .SetProperty(l => l.ProfileId, lobbyProfile.ProfileId));

            return lobbyProfile.Id;
        }

        public async Task Delete(Guid id)
        {
            await _dbContext.LobbyProfiles
                .Where(l => l.Id == id)
                .ExecuteDeleteAsync();
        }

    }
}
