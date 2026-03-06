using Microsoft.EntityFrameworkCore;
using PurpleSkyTTRPG.Core.Models;
using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Repositories
{
    public class LobbiesRepository
    {
        private readonly TTRPGDbContext _dbContext;

        public LobbiesRepository(TTRPGDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Lobby>> Get()
        {
            var lobbyEntities = await _dbContext.Lobbies
                .AsNoTracking()
                .ToListAsync();

            var lobbies = lobbyEntities
                .Select(l => Lobby.Create(l.Id, l.GmId, l.Name, l.System, l.InviteCode).Lobby)
                .ToList();

            return lobbies;
        }

        public async Task<Guid> Create(Lobby lobby)
        {
            var lobbyEntity = new LobbyEntity
            {
                Id = lobby.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                GmId = lobby.GmId,
                Name = lobby.Name,
                System = lobby.System,
                InviteCode = lobby.InviteCode,
            };

            await _dbContext.Lobbies.AddAsync(lobbyEntity);
            await _dbContext.SaveChangesAsync();

            return lobbyEntity.Id;
        }

        public async Task<Guid> Update(Lobby lobby)
        {
            await _dbContext.Lobbies
                .Where(l => l.Id == lobby.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(l => l.UpdatedAt, DateTime.UtcNow)
                    .SetProperty(l => l.Name, lobby.Name)
                    .SetProperty(l => l.System, lobby.System));

            return lobby.Id;
        }

        public async Task Delete(Guid id)
        {
            await _dbContext.Lobbies
                .Where(l => l.Id == id)
                .ExecuteDeleteAsync();
        }

    }
}
