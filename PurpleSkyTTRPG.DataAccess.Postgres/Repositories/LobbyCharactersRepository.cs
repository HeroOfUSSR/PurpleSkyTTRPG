using Microsoft.EntityFrameworkCore;
using PurpleSkyTTRPG.Core.Interfaces;
using PurpleSkyTTRPG.Core.Models;
using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Repositories
{
    public class LobbyCharactersRepository : ILobbyCharactersRepository
    {
        private readonly TTRPGDbContext _dbContext;

        public LobbyCharactersRepository(TTRPGDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LobbyCharacter>> Get()
        {
            var lobbyCharacterEntities = await _dbContext.LobbyCharacters
                .AsNoTracking()
                .ToListAsync();

            var lobbies = lobbyCharacterEntities
                .Select(l => LobbyCharacter.Create(l.Id, l.LobbyId, l.CharacterId).LobbyCharacter)
                .ToList();

            return lobbies;
        }

        public async Task<Guid> Create(LobbyCharacter lobbyCharacter)
        {
            var lobbyCharacterEntity = new LobbyCharacterEntity
            {
                Id = lobbyCharacter.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                LobbyId = lobbyCharacter.LobbyId,
                CharacterId = lobbyCharacter.CharacterId,
            };

            await _dbContext.LobbyCharacters.AddAsync(lobbyCharacterEntity);
            await _dbContext.SaveChangesAsync();

            return lobbyCharacterEntity.Id;
        }

        public async Task<Guid> Update(LobbyCharacter lobbyCharacter)
        {
            await _dbContext.LobbyCharacters
                .Where(l => l.Id == lobbyCharacter.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(l => l.UpdatedAt, DateTime.UtcNow)
                    .SetProperty(l => l.LobbyId, lobbyCharacter.LobbyId)
                    .SetProperty(l => l.CharacterId, lobbyCharacter.CharacterId));

            return lobbyCharacter.Id;
        }

        public async Task Delete(Guid id)
        {
            await _dbContext.LobbyCharacters
                .Where(l => l.Id == id)
                .ExecuteDeleteAsync();
        }

    }
}
