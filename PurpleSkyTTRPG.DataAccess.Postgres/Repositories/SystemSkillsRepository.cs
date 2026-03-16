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
    public class SystemSkillsRepository : ISystemSkillsRepository
    {
        private readonly TTRPGDbContext _dbContext;

        public SystemSkillsRepository(TTRPGDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SystemSkill>> GetBySystem(GameSystem system)
        {
            var entities = await _dbContext.SystemSkills
                .AsNoTracking()
                .Where(x => x.System == system)
                .ToListAsync();

            return entities
                .Select(e => SystemSkill.Create(
                    e.Id, e.System, e.Name, e.Description).SystemSkill)
                .ToList();
        }
    }
}
