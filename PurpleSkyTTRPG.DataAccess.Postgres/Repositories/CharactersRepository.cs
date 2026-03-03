using Microsoft.EntityFrameworkCore;
using PurpleSkyTTRPG.Core.Enum;
using PurpleSkyTTRPG.Core.Interfaces;
using PurpleSkyTTRPG.Core.Models;
using PurpleSkyTTRPG.DataAccess.Postgres.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Repositories
{
    public class CharactersRepository : ICharactersRepository
    {
        private readonly TTRPGDbContext _dbContext;

        public CharactersRepository(TTRPGDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Character>> Get()
        {
            var characterEntities = await _dbContext.Characters
                .AsNoTracking()
                .ToListAsync();

            var characters = characterEntities
                .Select(c => Character.Create(c.Id, c.OwnerId, c.System, c.CharacterName, c.CharData).Character)
                .ToList();
            // Mapping сделать адекватный в другом методе

            return characters;
        }

        public async Task<Guid> Create(Character character)
        {
            var characterEntity = new CharacterEntity
            {
                Id = character.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                OwnerId = character.OwnerId,
                CharacterName = character.CharacterName,
                CharData = character.DataJson,
            };

            await _dbContext.Characters.AddAsync(characterEntity);
            await _dbContext.SaveChangesAsync();

            return characterEntity.Id;
        }

        public async Task<Guid> Update(Guid id, DateTime createdAt, DateTime updatedAt, Guid ownerId, GameSystem system, string characterName, string dataJson, Guid? partyId)
        {
            await _dbContext.Characters
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.UpdatedAt, c => c.UpdatedAt)
                    .SetProperty(c => c.CharacterName, c => c.CharacterName)
                    .SetProperty(c => c.CharData, c => c.CharData)
                    );

            return id;
        }

        public async Task Delete(Guid id)
        {
            await _dbContext.Characters
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();
        }

    }
}
