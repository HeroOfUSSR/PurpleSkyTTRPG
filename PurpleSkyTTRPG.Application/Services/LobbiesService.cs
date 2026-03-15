using PurpleSkyTTRPG.Core.Interfaces;
using PurpleSkyTTRPG.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleSkyTTRPG.Application.Services
{
    public class LobbiesService : ILobbiesService
    {
        private readonly ILobbiesRepository _lobbiesRepository;

        public LobbiesService(ILobbiesRepository lobbiesRepository)
        {
            _lobbiesRepository = lobbiesRepository;
        }

        public async Task<List<Lobby>> GetLobbiesAsync()
        {
            return await _lobbiesRepository.Get();
        }

        public async Task<Guid> CreateLobbyAsync(Lobby newLobby)
        {
            return await _lobbiesRepository.Create(newLobby);
        }

        public async Task<Guid> UpdateLobbyAsync(Lobby newLobby)
        {
            return await _lobbiesRepository.Update(newLobby);
        }

        public async Task<Guid> DeleteLobbyAsync(Guid id)
        {
            return await _lobbiesRepository.Delete(id);
        }
    }
}
