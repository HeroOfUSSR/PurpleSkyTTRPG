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
    public class SystemSpellsRepository : ISystemSpellsRepository
    {
        private readonly TTRPGDbContext _dbContext;

        public SystemSpellsRepository(TTRPGDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SystemSpell>> GetBySystem(GameSystem system)
        {
            var entities = await _dbContext.SystemSpells
                .AsNoTracking()
                .Where(x => x.System == system)
                .ToListAsync();

            return entities
                .Select(e => SystemSpell.Create(
                    e.Id, e.System, e.Name, e.Description).SystemSpell)
                .ToList();
        }
    }
}
