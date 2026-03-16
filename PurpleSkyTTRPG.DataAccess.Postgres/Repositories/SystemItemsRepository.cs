using Microsoft.EntityFrameworkCore;
using PurpleSkyTTRPG.Core.Enum;
using PurpleSkyTTRPG.Core.Interfaces;
using PurpleSkyTTRPG.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Repositories
{
    public class SystemItemsRepository : ISystemItemsRepository
    {
        private readonly TTRPGDbContext _dbContext;

        public SystemItemsRepository(TTRPGDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SystemItem>> GetBySystem(GameSystem system)
        {
            var entities = await _dbContext.SystemItems
                .AsNoTracking()
                .Where(x => x.System == system)
                .ToListAsync();

            return entities
                .Select(e => SystemItem.Create(
                    e.Id, e.System, e.Name,
                    e.Description, e.Weight,
                    e.ItemTag, e.Rarity).SystemItem)
                .ToList();
        }

        public async Task<SystemItem?> GetById(Guid id)
        {
            var entity = await _dbContext.SystemItems
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null) return null;

            return SystemItem.Create(
                entity.Id, entity.System, entity.Name,
                entity.Description, entity.Weight,
                entity.ItemTag, entity.Rarity).SystemItem;
        }
    }
}
