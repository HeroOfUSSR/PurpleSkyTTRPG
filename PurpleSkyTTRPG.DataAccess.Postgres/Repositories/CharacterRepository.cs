using Microsoft.EntityFrameworkCore;
using PurpleSkyTTRPG.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Repositories
{
    public class CharacterRepository
    {
        private readonly TTRPGDbContext _dbContext;

        public CharacterRepository(TTRPGDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Character>> Get()
        {
            var characterEntities = await _dbContext.Characters
                .AsNoTracking() 
                .ToListAsync();

            var character = characterEntities
                .Select(c => Character.Create(c.Id, c.OwnerId))
            // Mapping сделать адекватный в другом методе
        }
    }
}
