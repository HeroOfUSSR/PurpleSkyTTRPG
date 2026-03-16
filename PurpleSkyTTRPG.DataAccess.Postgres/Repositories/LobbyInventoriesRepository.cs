using Microsoft.EntityFrameworkCore;
using PurpleSkyTTRPG.Core.Interfaces;
using PurpleSkyTTRPG.Core.Models;
using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Repositories
{
    public class LobbyInventoriesRepository : ILobbyInventoriesRepository
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
                .Select(l => LobbyInventory.Create(l.Id, l.LobbyId, l.ContributorId, l.Name, l.Description, l.Weight).LobbyInventory)
                .ToList();

            return lobbyInventories;
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
            await _dbContext.LobbyInventories
                .Where(l => l.Id == lobbyInventory.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(l => l.UpdatedAt, DateTime.UtcNow)
                    .SetProperty(l => l.LobbyId, lobbyInventory.LobbyId)
                    .SetProperty(l => l.Name, lobbyInventory.Name)
                    .SetProperty(l => l.Description, lobbyInventory.Description)
                    .SetProperty(l => l.Weight, lobbyInventory.Weight));

            return lobbyInventory.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _dbContext.LobbyInventories
                .Where(l => l.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
