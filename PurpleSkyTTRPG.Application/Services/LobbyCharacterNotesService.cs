using PurpleSkyTTRPG.Core.Interfaces;
using PurpleSkyTTRPG.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleSkyTTRPG.Application.Services
{
    public class LobbyCharacterNotesService : ILobbyCharacterNotesService
    {
        private readonly ILobbyCharacterNotesRepository _lobbyCharacterNotesRepository;

        public LobbyCharacterNotesService(ILobbyCharacterNotesRepository lobbyCharacterNotesRepository)
        {
            _lobbyCharacterNotesRepository = lobbyCharacterNotesRepository;
        }

        public async Task<List<LobbyCharacterNote>> GetCharactersAsync()
        {
            return await _lobbyCharacterNotesRepository.Get();
        }

        public async Task<Guid> CreateCharacterAsync(LobbyCharacterNote lobbyCharacterNote)
        {
            return await _lobbyCharacterNotesRepository.Create(lobbyCharacterNote);
        }

        public async Task<Guid> UpdateLobbyCharacterNoteAsync(LobbyCharacterNote lobbyCharacterNote)
        {
            return await _lobbyCharacterNotesRepository.Update(lobbyCharacterNote);
        }

        public async Task<Guid> DeleteLobbyCharacterNoteAsync(Guid id)
        {
            return await _lobbyCharacterNotesRepository.Delete(id);
        }
    }
}
