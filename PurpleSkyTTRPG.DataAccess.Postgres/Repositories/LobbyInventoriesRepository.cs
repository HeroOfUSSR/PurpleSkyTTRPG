using Microsoft.EntityFrameworkCore;
using PurpleSkyTTRPG.Core.Models;
using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Repositories
{
    public class LobbyInventoriesRepository
    {
        private readonly TTRPGDbContext _dbContext;

        public LobbyInventoriesRepository(TTRPGDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LobbyInventory>> Get()
        {
            var lobbyInventoryEntities = await _dbContext.LobbyInventories
                .AsNoTracking()
                .ToListAsync();

            var lobbyInventories = lobbyInventoryEntities
                .Select(l => LobbyCharacter.Create(l.Id, l.LobbyId, l.CharacterId).LobbyCharacter)
                .ToList();

            return lobbies;
        }

        public async Task<Guid> Create(LobbyInventory lobbyInventory)
        {
            var lobbyInventoryEntity = new LobbyInventoryEntity
            {
                Id = lobbyInventory.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                LobbyId = lobbyInventory.LobbyId,
                ContributorId = lobbyInventory.ContributorId,
                Name = lobbyInventory.Name,
                Description = lobbyInventory.Description,
                Weight = lobbyInventory.Weight,
            };

            await _dbContext.LobbyInventories.AddAsync(lobbyInventoryEntity);
            await _dbContext.SaveChangesAsync();

            return lobbyInventoryEntity.Id;
        }

        public async Task<Guid> Update(LobbyInventory lobbyInventory)
        {
            await _dbContext.LobbyCharacters
                .Where(l => l.Id == lobbyCharacter.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(l => l.UpdatedAt, DateTime.UtcNow)
                    .SetProperty(l => l.LobbyId, lobbyCharacter.LobbyId)
                    .SetProperty(l => l.CharacterId, lobbyCharacter.CharacterId));

            return lobbyCharacter.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _dbContext.LobbyCharacters
                .Where(l => l.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
