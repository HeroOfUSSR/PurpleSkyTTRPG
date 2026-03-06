using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Persistence
{
    public class LobbyCharacterEntity : BaseAudit
    {
        public Guid LobbyId { get; set; }
        public LobbyEntity Lobby { get; set; }


        public Guid CharacterId { get; set; }
        public CharacterEntity Character { get; set; }

        public ICollection<LobbyCharacterNoteEntity> LobbyCharacterNotes { get; set; }
    }
}
