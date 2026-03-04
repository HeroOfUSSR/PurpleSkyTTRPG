using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.Core.Models
{
    public class LobbyCharacter
    {
        private LobbyCharacter(Guid id, Guid lobbyId, Guid characterId)
        {
            Id = id;
            LobbyId = lobbyId;
            CharacterId = characterId;
        }

        public Guid Id { get; }
        public Guid LobbyId { get; }
        public Guid CharacterId { get; }

        public static (LobbyCharacter LobbyCharacter, string Error) Create(Guid id, Guid lobbyId, Guid characterId)
        {
            var error = string.Empty;

            if (lobbyId == Guid.Empty)
            {
                error = "LobbyId cannot be empty";
            }
            else if (characterId == Guid.Empty)
            {
                error = "CharacterId cannot be empty";
            }

            var lobbyCharacter = new LobbyCharacter(id, lobbyId, characterId);

            return (lobbyCharacter, error);
        }
    }
}
