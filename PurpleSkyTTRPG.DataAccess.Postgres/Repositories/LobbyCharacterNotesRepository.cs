using Microsoft.EntityFrameworkCore;
using PurpleSkyTTRPG.Core.Models;
using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Repositories
{
    public class LobbyCharacterNotesRepository
    {
        private readonly TTRPGDbContext _dbContext;

        public LobbyCharacterNotesRepository(TTRPGDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LobbyCharacterNote>> Get()
        {
            var lobbyCharacterNoteEntities = await _dbContext.LobbyCharacterNotes
                .AsNoTracking()
                .ToListAsync();

            var lobbieCharacterNotes = lobbyCharacterNoteEntities
                .Select(l => LobbyCharacterNote.Create(l.Id, l.LobbyCharacterId, l.Title, l.Text, l.NoteVisibility).LobbyCharacterNote)
                .ToList();

            return lobbieCharacterNotes;
        }

        public async Task<Guid> Create(LobbyCharacterNote lobbyCharacterNote)
        {
            var lobbyCharacterNoteEntity = new LobbyCharacterNoteEntity
            {
                Id = lobbyCharacterNote.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                LobbyCharacterId = lobbyCharacterNote.LobbyCharacterId,
                Title = lobbyCharacterNote.Title,
                Text = lobbyCharacterNote.Text,
                NoteVisibility = lobbyCharacterNote.NoteVisibility,
            };

            await _dbContext.LobbyCharacterNotes.AddAsync(lobbyCharacterNoteEntity);
            await _dbContext.SaveChangesAsync();

            return lobbyCharacterNoteEntity.Id;
        }

        public async Task<Guid> Update(LobbyCharacterNote lobbyCharacterNote)
        {
            await _dbContext.LobbyCharacterNotes
                .Where(l => l.Id == lobbyCharacterNote.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(l => l.UpdatedAt, DateTime.UtcNow)
                    .SetProperty(l => l.Title, lobbyCharacterNote.Title)
                    .SetProperty(l => l.Text, lobbyCharacterNote.Text)
                    .SetProperty(l => l.NoteVisibility, lobbyCharacterNote.NoteVisibility));

            return lobbyCharacterNote.Id;
        }

        public async Task Delete(Guid id)
        {
            await _dbContext.LobbyCharacterNotes
                .Where(l => l.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
