using PurpleSkyTTRPG.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleSkyTTRPG.DataAccess.Postgres.Persistence
{
    public class NoteVisibilityEntity
    {
        public Guid LobbyCharacterNoteId { get; set; }
        public LobbyCharacterNote LobbyCharacterNote { get; set; }


        public Guid ProfileId { get; set; }
        public ProfileEntity Profile { get; set; }

    }
}
