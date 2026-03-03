using PurpleSkyTTRPG.Core.Enum;
using PurpleSkyTTRPG.DataAccess.Postgres.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Persistence
{
    public class LobbyCharacterNoteEntity : BaseAudit
    {
        public Guid lobbyCharacterId { get; set; }

        public LobbyCharacterEntity LobbyCharacter { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public NoteVisibility NoteVisibility { get; set; }

    }
}
