using PurpleSkyTTRPG.Core.Enum;
using PurpleSkyTTRPG.DataAccess.Postgres.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Persistence
{
    public class LobbyCharacterNoteEntity : BaseAudit
    {
        public Guid LobbyCharacterId { get; set; }

        public LobbyCharacterEntity LobbyCharacter { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public NotesVisibility NoteVisibility { get; set; }

    }
}
